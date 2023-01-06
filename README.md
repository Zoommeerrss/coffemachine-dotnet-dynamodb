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
