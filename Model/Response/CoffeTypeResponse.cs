using Amazon.DynamoDBv2.DataModel;
using System;

namespace CoffeMachine.Model.Response
{
    public class CoffeTypeResponse
    {
        public CoffeTypeResponse() { }

        public CoffeTypeResponse(int httpStatusCode)
        {
            this.HttpStatusCode = httpStatusCode;
        }

        public CoffeTypeResponse(int httpStatusCode, object response)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Response = response;
        }

        // partition key or hask key
        public int HttpStatusCode { get; set; }

        // sort key or range key
        public object Response { get; set; }

        public string ToString()
        {
            return $"CoffeTypeResponse: {HttpStatusCode}, {Response}";
        }
    }
}
