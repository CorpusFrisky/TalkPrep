using System.Collections.Generic;
using System.Net;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using SimpleServerlessSharedLib.Services;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace SimpleServerless.Services
{
    public class UserLambdas
    {
        private readonly UserService _userService;
        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public UserLambdas()
        {
            _userService = new UserService();
        }


        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns>The list of blogs</returns>
        public APIGatewayProxyResponse GetUserById(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("GetUser called.");
            var id = int.Parse(request.PathParameters["id"]);

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(_userService.GetUser(id)),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }
    }
}
