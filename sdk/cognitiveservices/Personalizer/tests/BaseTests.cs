using System.Net.Http;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        // BaseEndpoint only contains protocol and hostname
        private static string BaseEndpoint = "http://localhost:5000";
        private static string ApiKey = "000";

        protected IPersonalizerClient GetClient(DelegatingHandler handler)
        {
            return new PersonalizerClient(new ApiKeyServiceClientCredentials(ApiKey), handlers: handler)
            {
                Endpoint = BaseEndpoint
            };
        }
    }
}
