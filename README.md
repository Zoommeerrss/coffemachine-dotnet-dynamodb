# coffemachine-dotnet-dynamodb

Simple .Net Project using AWS DynamoDB and AWS Localstack

## Installation

Go to NuGet Manager and install the following dependencies:

```bash
-AWSSDK.DynamoDBv2
-LocalStack.Client
-LocalStack.Client.Extensions
-Swashbuckle.AspNetCore (Swagger)
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
