using System.Collections.Generic;
using System.Net;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace SimpleServerless.Services
{
    public class UserLambdas
    {
        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public UserLambdas()
        {
        }


        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns>The list of blogs</returns>
        public APIGatewayProxyResponse GetUser(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("GetUser called.");

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "Hello AWS Serverless",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }
    }
}
