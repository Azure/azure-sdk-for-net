using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents;

namespace AuthEventsTrigger
{
    public static class AuthEventsTrigger
    {
        #region Snippet:AuthEventsTriggerExample
        #region Snippet:AuthEventsTriggerParameters
        [FunctionName("onTokenIssuanceStart")]
        public static WebJobsAuthenticationEventResponse Run(
        [WebJobsAuthenticationEventsTriggerAttribute(
            AudienceAppId = "<custom_authentication_extension_app_id>",
            AuthorityUrl = "<authority_uri>", 
            AuthorizedPartyAppId = "<authorized_party_app_id>")] WebJobsTokenIssuanceStartRequest request, ILogger log)
        #endregion
        {
            try
            {
                // Checks if the request is successful and did the token validation pass
                if (request.RequestStatus == WebJobsAuthenticationEventsRequestStatusType.Successful)
                {
                    // Fetches information about the user from external data store
                    // Add new claims to the token's response
                    request.Response.Actions.Add(
                        new WebJobsProvideClaimsForToken(
                            new WebJobsAuthenticationEventsTokenClaim("dateOfBirth", "01/01/2000"),
                            new WebJobsAuthenticationEventsTokenClaim("customRoles", "Writer", "Editor"),
                            new WebJobsAuthenticationEventsTokenClaim("apiVersion", "1.0.0"),
                            new WebJobsAuthenticationEventsTokenClaim(
                                "correlationId", 
                                request.Data.AuthenticationContext.CorrelationId.ToString())));
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
        #endregion
    }
}