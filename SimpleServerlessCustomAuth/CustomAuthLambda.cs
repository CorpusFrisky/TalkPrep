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
        private static APIGatewayCustomAuthorizerPolicy _unauthorizedPolicy;

        public CustomAuthLambda()
        {
            _unauthorizedPolicy = new APIGatewayCustomAuthorizerPolicy()
            {
                Statement = new List<APIGatewayCustomAuthorizerPolicy.IAMPolicyStatement>()
                {
                    new APIGatewayCustomAuthorizerPolicy.IAMPolicyStatement()
                    {
                        Effect = "Deny"
                    }
                }
            };
        }

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="authRequest"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public APIGatewayCustomAuthorizerResponse FunctionHandler(APIGatewayCustomAuthorizerRequest authRequest,
            ILambdaContext context)
        {
            var authenticated = authRequest != null && String.Equals(authRequest.AuthorizationToken, "allow");

            var policy = new APIGatewayCustomAuthorizerPolicy()
            {
                Statement = new List<APIGatewayCustomAuthorizerPolicy.IAMPolicyStatement>()
                {
                    new APIGatewayCustomAuthorizerPolicy.IAMPolicyStatement()
                    {
                        Action = new HashSet<string>() {"execute-api:Invoke"},
                        Effect = authenticated ? "Allow" : "Deny",
                        Resource = new HashSet<string>() {authRequest.MethodArn}
                    }
                }
            };

            return new APIGatewayCustomAuthorizerResponse()
            {
                PolicyDocument = policy
            };
        }
    }
}
