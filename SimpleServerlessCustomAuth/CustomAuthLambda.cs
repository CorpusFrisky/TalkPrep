using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Auth.AccessControlPolicy;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace SimpleServerlessCustomAuth
{
    public class CustomAuthLambda
    {
        private static Policy _unauthorizedPolicy;

        public CustomAuthLambda()
        {
            _unauthorizedPolicy = new Policy("Unauthorized",
                new List<Statement>()
                {
                    new Statement(Statement.StatementEffect.Deny)
                });
        }
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Policy FunctionHandler(APIGatewayCustomAuthorizerRequest authRequest, ILambdaContext context)
        {
            if (string.Equals(authRequest?.AuthorizationToken, "allow", StringComparison.OrdinalIgnoreCase))
            {
                return new Policy("WelcomeIn", 
                    new List<Statement>()
                    {
                        new Statement(Statement.StatementEffect.Allow)
                        {
                            Actions = new List<ActionIdentifier>()
                            {
                                new ActionIdentifier("execute-api:Invoke")
                            },
                            Resources = new List<Resource>()
                            {
                                new Resource(authRequest.MethodArn)
                            }
                        }
                    });
            }

            return _unauthorizedPolicy;
        }
    }
}
