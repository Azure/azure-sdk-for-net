## Sample of Mapping claims using NuGet

Below is sample code for adding a string and string array as two new claims to the response with the NuGet
```csharp

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart;
using Microsoft.Extensions.Logging;

namespace AuthEventsTrigger
{
    public static class AuthEventsTrigger
    {
        // The WebJobsAuthenticationEventsTriggerAttribute attribute can be used to specify audience app ID, 
        // authority URL and authorized party app id. 
        // This is an alternative route to setting up Authorization values instead of Environment variables or EzAuth
        [FunctionName("onTokenIssuanceStart")]
        public static WebJobsAuthenticationEventResponse Run(
            [WebJobsAuthenticationEventsTrigger(
                    AudienceAppId = "Enter custom authentication extension app ID here",
                    AuthorityUrl = "Enter authority URI here",
                    AuthorizedPartyAppId = "Enter the Authorized Party App Id here")]
            WebJobsTokenIssuanceStartRequest request, ILogger log)
        {
            try
            {
                // Checks if the request is successful and did the token validation pass 
                if (request.RequestStatus == WebJobsAuthenticationEventsRequestStatusType.Successful)
                {
                    var claimValue = GetMyCustomClaimFromADFS(
                        GetAccessToken(),
                        request.Data.TenantId.ToString(),
                        request.Data.AuthenticationContext.User.UserPrincipalName,
                        log);

                    // Create a list of claims to be added to the token 
                    var claims = new[]
                    {
                        // Set the claim value from the source and add it to the list of claims 
                        new WebJobsAuthenticationEventsTokenClaim("mappedClaimName", claimValue),
                        new WebJobsAuthenticationEventsTokenClaim("customRole", "Writer", "Editor")
                    };

                    // Add new claims to the response 
                    request.Response.Actions.Add(new WebJobsProvideClaimsForToken(claims));
                }
                else
                {
                    // If the request fails, such as in token validation, output the failed request status, 
                    // such as in token validation or response validation. 
                    log.LogInformation(request.StatusMessage);
                }
                return request.Completed();
            }
            catch (Exception ex)
            {
                return request.Failed(ex);
            }
        }

        /// <summary>
        /// Filler function to return value for the custom claim
        /// </summary>
        private static string GetMyCustomClaimFromADFS(string tenantId, string upn, ILogger log)
        {
            try
            {
                if (string.IsNullOrEmpty(tenantId) || string.IsNullOrEmpty(upn))
                {
                    throw new ArgumentNullException();
                }
                throw new NotImplementedException();
            }
            catch (NotImplementedException)
            {
                return "DefaultValue";
            }
        }
    }
}
```

#### Response
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
400
``` json
{
    "errors": [
        "WebJobsTokenIssuanceStartRequest: WebJobsTokenIssuanceStartData: WebJobsAuthenticationEventsContext: WebJobsAuthenticationEventsContextUser: The UserPrincipalName field is required."
    ]
}
```