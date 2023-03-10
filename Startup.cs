using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using CoffeMachine.Datastore.MySQL;
using CoffeMachine.Datastore.MySQL.Repository;
using CoffeMachine.Datastore.MySQL.Repository.port;
using CoffeMachine.Service;
using CoffeMachine.Service.port;
using LocalStack.Client.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CoffeMachine
{
    public class Startup
    {

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }

        // Environment
        public IHostEnvironment env { get; set; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHealthChecks();

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoffeMachine API", Version = "v1" });
            });

            // DynamoDB
            var credentials = new BasicAWSCredentials("AKIA6ISFFOL2UYYT3WX4", "fa50bf94-d965-452b-ae1a-18ffa47ed90f");
            var config = new AmazonDynamoDBConfig()
            {
                RegionEndpoint = RegionEndpoint.SAEast1
            };
            config.ServiceURL = "http://localhost:4566";

            var awsDynamoDBClient = new AmazonDynamoDBClient(credentials, config);
            services.AddSingleton<IAmazonDynamoDB>(awsDynamoDBClient);
            services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

            services.AddLocalStack(Configuration);
            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            services.AddAwsService<IAmazonDynamoDB>();

            // MySQL
            string mySqlConnectionStr = Configuration.GetConnectionString("MySQLConnection");
            services.AddDbContextPool<IngredientContext>(options => options.UseMySQL(mySqlConnectionStr));

            // Personalized Repository
            services.AddScoped<IIngredientRepository, IngredientRepositoryImpl>();

            // Personalized Services
            services.AddScoped<ICoffeService, CoffeServiceImpl>();
            services.AddScoped<IIngredientService, IngredientServiceImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoffeMachine API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
