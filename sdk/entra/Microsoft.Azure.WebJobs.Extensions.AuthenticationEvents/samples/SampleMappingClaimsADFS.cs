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
                    var accessToken = GetAccessToken();
                    var claimValue = GetMyCustomClaimFromADFS(accessToken, log);

                    // Create a list of claims to be added to the token 
                    var claims = new[]
                    {
                        // Set the claim value from the source and add it to the list of claims 
                        new WebJobsAuthenticationEventsTokenClaim("mappedClaimName", claimValue)
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
        /// Sudo code sample of getting an access token to ADFS
        /// </summary>
        /// <returns>Access token to external data store such as ADFS</returns>
        private static string GetAccessToken()
        {
            // not implemented as this is just sample code
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sudo code sample of getting custom claims from an external data store
        /// Fetches information about the user from external data store
        /// Add new claims to the token's response
        /// API endpoint to get user data
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        private static string GetMyCustomClaimFromADFS(string accessToken, ILogger log)
        {
            string userInfoEndpoint = "https://your-adfs-server/adfs/api/userinfo";
            using HttpClient client = new();

            // Set the Authorization header with the Bearer token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Send the request to the API endpoint
            HttpResponseMessage response = client.GetAsync(userInfoEndpoint).Result;

            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                // Parse the response string as JSON Document
                using JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ReadAsStringAsync().Result);

                // Access data dynamically using JSON Document
                // Get the custom claim value for specified property
                return jsonDocument.RootElement.GetProperty("myCustomClaimsKey").GetString();
            }
            else
            {
                // Log if the request fails
                log.LogError("Status Code: " + response.StatusCode);
                log.LogError("Response: " + response.Content.ReadAsStringAsync().Result);
                return null;
            }
        }
    }
}
