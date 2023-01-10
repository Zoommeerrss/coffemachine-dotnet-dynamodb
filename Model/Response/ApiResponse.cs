using Amazon.DynamoDBv2.DataModel;
using System;

namespace CoffeMachine.Model.Response
{
    public class ApiResponse<TResult>
    {
        public ApiResponse() { }

        public ApiResponse(int httpStatusCode)
        {
            this.HttpStatusCode = httpStatusCode;
        }

        public ApiResponse(int httpStatusCode, TResult response)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Response = response;
        }

        // partition key or hask key
        public int HttpStatusCode { get; set; }

        // sort key or range key
        public TResult Response { get; set; }

        public string ToString()
        {
            return $"ApiResponse: {HttpStatusCode}, {Response}";
        }
    }
}
