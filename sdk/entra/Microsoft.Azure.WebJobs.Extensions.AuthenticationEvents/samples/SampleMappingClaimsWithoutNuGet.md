## Sample of mapping claims without the NuGet

Below is sample code for adding a string and string array as two new claims to the response without the NuGet.
There is no token validation, request or response validation in the below code. If one is to use below for production usuage, we recommend at minimum to add token validation. 

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

namespace MyCustomClaimsProvider
{
    public static class Function1
    {
        /// <summary>
        /// Main function to read in the request, and set the claims.
        /// </summary>
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                // No built in Token Validation.
                // We can not assert the token was verified by EazyAuth either without adding additional code.
                // No request validation.
                log.LogInformation("C# HTTP trigger function processed a request.");
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                // Dynamic object to read the request body, and get the user's UPN and tenant ID
                dynamic data = JsonConvert.DeserializeObject(requestBody);

                // Read the upn and tenantId from the Microsoft Entra request body
                string upn = data?.data.authenticationContext.user.userPrincipalName;
                string tenantId = data?.data.tenantId;

                var claimValue = GetMyCustomClaimFromADFS(GetAccessToken(), tenantId, upn, log);

                // Claims to return to Microsoft Entra
                ResponseContent r = new();
                r.Data.Actions[0].Claims.CustomClaimValue = claimValue;
                r.Data.Actions[0].Claims.CustomRoles.Add("Writer");
                r.Data.Actions[0].Claims.CustomRoles.Add("Editor");

                // No response validation.

                return new OkObjectResult(r);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                return new InternalServerErrorResult();
            }
        }

        /// <summary>
        /// Filler function to return value for the custom claim
        /// </summary>
        private static string GetMyCustomClaimFromADFS(string tenantId, string upn, ILogger log)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                return "DefaultValue";
            }
        }
    }

    public class ResponseContent
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
        public ResponseContent()
        {
            Data = new Data();
        }
    }

    public class Data
    {
        [JsonProperty("@odata.type")]
        public string Odatatype { get; set; }
        public List<Action> Actions { get; set; }
        public Data()
        {
            Odatatype = "microsoft.graph.onTokenIssuanceStartResponseData";
            Actions = new List<Action>
            {
                new()
            };
        }
    }

    public class Action
    {
        [JsonProperty("@odata.type")]
        public string Odatatype { get; set; }
        public Claims Claims { get; set; }
        public Action()
        {
            Odatatype = "microsoft.graph.tokenIssuanceStart.provideClaimsForToken";
            Claims = new Claims();
        }
    }

    public class Claims
    {
        public string CustomClaimValue { get; set; }

        public List<string> CustomRoles { get; set; }

        public Claims()
        {
            CustomRoles = new List<string>();
        }
    }
}
```


#### Response with valid request
200
``` json
{
    "data": {
        "@odata.type": "microsoft.graph.onTokenIssuanceStartResponseData",
        "actions": [
            {
                "@odata.type": "microsoft.graph.tokenIssuanceStart.provideClaimsForToken",
                "claims": {
                    "customClaimValue": "DefaultValue",
                    "customRoles": [
                        "Writer",
                        "Editor"
                    ]
                }
            }
        ]
    }
}
```

#### Response with invalid request
500