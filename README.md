# coffemachine-dotnet-dynamodb

Simple .Net Project using AWS DynamoDB with AWS Localstack together and MySQL with Entity Framework

## Installation

Go to NuGet Manager and install the following dependencies:

```bash
-AWSSDK.DynamoDBv2
-LocalStack.Client
-LocalStack.Client.Extensions
-Swashbuckle.AspNetCore (Swagger)
-MySql.Data.EntityFrameworkCore 8.0.22
```

## Usage

After install all dependencies, open the Solution file on the Visual Studio (I've used VS 2019)
```bash
CoffeMachine.sln
```
## Swagger

With the app running, just call the following URL to use the Swagger GUI

```bash
http://localhost:<PORT>/swagger
```

To start the app from Swagger directly, just configure the launchSettings.json file located in the Properties folder replacing the default launchUrl parameter to swagger:

```bash
"CoffeMachine": {
    "commandName": "Project",
    "launchBrowser": true,
    "launchUrl": "swagger", // replaced coffemachine by swagger
    "applicationUrl": "https://localhost:5001;http://localhost:5000",
    "environmentVariables": {
    "ASPNETCORE_ENVIRONMENT": "Development"
    }
}
```

## Docker

With the Docker Desktop installed, open a command-line prompt then run the following command:

```bash
>docker-compose up -d
```

This command with prepare the docker local image containing the AWS Localstack running on localhost and port 4566

After the AWS Localstack image installation run the command below in a browser of your preference. If it run, you are ready to go forward with your labs.

```bash
http://localhost:4566/health
```

## MySQL with MySql.Data.EntityFrameworkCore 8.0.22

Here you are a new resource added on this simple project. Now you can use DynamoDB for basic parameters table and MySQL for relational model

Again, all you need is go to the Nuget and install the MySql.Data.EntityFrameworkCore 8.0.22 dependency. 

After that you have to follow some steps to setup the MySQL Database on this app and you'll be able to use all features available in the MySql.Data.EntityFrameworkCore 8.0.22

An important thing to say is about the .net framework used here. The version I've tested is 3.1 and all of those components will work exactly after you've been installed all dependencies described on the top!'

Just take a look on the files below. They have all you need to know to go ahead with your labs!

```bash
-appsettings.json:31
-Startup.cs:64-65, 68, 72
-Ingredient.cs
-IngredientContext.cs
-IngredientRepositoryImpl.cs
-IngredientServiceImpl.cs
-IngredientController.cs
-IngredientConverter.cs
```

If you could understand all of those components you'll absolutly be able to use MySQL Database in a .Net Microservice easily!

Obviously you'll find out lots of implementation styles along the internet and you company so, fell free to use it if you think that it could help you some day.

Thanks for comming and happy code!