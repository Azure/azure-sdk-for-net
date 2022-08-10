using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.CustomAuthenticationExtension;
using Microsoft.Azure.WebJobs.Extensions.CustomAuthenticationExtension.TokenIssuanceStart;
using Microsoft.Azure.WebJobs.Extensions.CustomAuthenticationExtension.TokenIssuanceStart.Actions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace HttpTriggerTester
{
    /// <summary>Example functions for token augmentation</summary>
    class Function
    {
        /// <summary>The entry point for the Azure Function</summary>
        /// <param name="request">Strongly Typed request data for a token issuance start request</param>
        /// <param name="log">Logger</param>
        /// <returns>The augmented token response or error.</returns>
        [FunctionName("onTokenIssuanceStart")]
        public async static Task<IActionResult> Run(
            [CustomAuthenticationTrigger] TokenIssuanceStartRequest request, ILogger log)
        {
            try
            {
                //Is the request successful and did the token validation pass.
                if (request.RequestStatus == AuthEventConvertStatusTypes.Successful)
                {
                    // Fetch information about user from external data store

                    //Add new claims to the token's response
                    request.Response.Actions.Add(new ProvideClaimsForToken(
                                                  new TokenClaim("DateOfBirth", "01/01/2000"),
                                                  new TokenClaim("CustomRoles", "Writer", "Editor")
                                              ));
                }
                else
                {
                    //If the request failed for any reason, i.e. Token validation, output the failed request status
                    log.LogInformation(request.StatusMessage);
                }
                return await request.Completed();
            }
            catch (Exception ex)
            {
                return request.Failed(ex.Message);
            }
        }

        /// <summary>The entry point for the Azure Function if type to be used as a string</summary>
        /// <param name="request">Json string request data for a token issuance start request</param>
        /// <param name="log">Logger</param>
        /// <returns>The augmented token response or error.</returns>
        [FunctionName("onTokenIssuanceString")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public async static Task<string> RunString(
                [CustomAuthenticationTrigger] string request, ILogger log)
        {
            try
            {
                // Load the string into a valid Json Object
                dynamic jRequest = JObject.Parse(request);
                //Is the request successful and did the token validation pass.
                if (jRequest["requestStatus"] == "Successful")
                {
                    //Add new claims to the token's response
                    jRequest.response.actions.Add(JObject.Parse(@"{
	                    'type': 'ProvideClaimsForToken',
	                    'claims': [
		                    {
			                    'DateOfBirth': '01/01/2000'
		                    },
		                    {
			                    'CustomRoles': [
				                    'Writer',
				                    'Editor'
			                    ]
		                    }
	                    ]
                    }"));
                }

                return await Task.FromResult<string>(jRequest.response.ToString());
            }
            catch (Exception ex)
            {
                return $"{{'error':'{ex.Message}'}}";
            }
        }
    }
}



/*
* Examples of otherway to add
request.Response.Actions.Add(new ProviderClaimsForTokenAction()
{
    Claims = new List<Claim>(new Claim[]
    {
        new Claim("hello", "world"),
        new Claim("Values", "1", "2", "3", "4")
    })
});

ProviderClaimsForTokenAction providerClaimsForTokenAction = new ProviderClaimsForTokenAction();
providerClaimsForTokenAction.AddClaim("hello", "world");
providerClaimsForTokenAction.AddClaim("Values", "1", "2", "3", "4");
request.Response.Actions.Add(providerClaimsForTokenAction);

*/
// request.Response.Description = "A Test Description";