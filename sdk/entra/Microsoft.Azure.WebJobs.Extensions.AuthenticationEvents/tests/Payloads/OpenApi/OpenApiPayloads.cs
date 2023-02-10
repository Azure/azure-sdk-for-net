namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Payloads.OpenApi
{
    /// <summary>Test data for OpenApi</summary>
    public static class OpenApiPayloads
    {
        /// <summary>Gets the open API document body.</summary>
        /// <value>The open API document.</value>
        public static string OpenApiDocument
        {
            get
            {
                return PayloadHelper.GetPayload("OpenApi.OpenApiDocument.json");
            }
        }

        /// <summary>Gets the open API document merged sample payload.</summary>
        /// <value>The open API document merged.</value>
        public static string OpenApiDocumentMerge
        {
            get
            {
                return PayloadHelper.GetPayload("OpenApi.OpenApiDocumentMerge.json");

            }
        }
    }
}
