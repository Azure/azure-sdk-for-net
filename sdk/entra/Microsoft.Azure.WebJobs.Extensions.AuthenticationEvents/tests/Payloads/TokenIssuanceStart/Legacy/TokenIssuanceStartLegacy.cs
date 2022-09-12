namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Payloads.TokenIssuanceStart.Legacy
{
    /// <summary>Test data for the Token Issuance Start Request version: Legacy</summary>
    public static class TokenIssuanceStartLegacy
    {
        /// <summary>The expected response payload.</summary>
        /// <value>The expected payload.</value>
        public static string ExpectedPayload
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.Legacy.ExpectedPayload.json");
            }
        }

        /// <summary>Mocks the data expected from the function execution.</summary>
        /// <value>The function response.</value>
        public static string ActionResponse
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.Legacy.ActionResponse.json");
            }
        }

        /// <summary>Gets the request schema body.</summary>
        /// <value>The request schema.</value>
        public static string RequestSchema
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.Legacy.RequestSchema.json");

            }
        }

        /// <summary>Gets the response schema body.</summary>
        /// <value>The response schema.</value>
        public static string ResponseSchema
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.Legacy.ResponseSchema.json");

            }
        }

        /// <summary>Gets the version name space.</summary>
        /// <value>The version name space.</value>
        public static string VersionNameSpace
        {
            get { return "TokenIssuanceStart.preview_10_01_2021"; }
        }
    }
}
