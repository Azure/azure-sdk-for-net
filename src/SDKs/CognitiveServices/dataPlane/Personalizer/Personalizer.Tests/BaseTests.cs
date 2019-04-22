using Microsoft.Azure.CognitiveServices.Personalizer;
using System.Net.Http;

namespace Personalizer.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        private static readonly string ApiKey;

        static BaseTests()
        {
            // Retrieve the configuration information.
            ApiKey = "";
        }

        protected IPersonalizerClient GetClient(DelegatingHandler handler)
        {
            IPersonalizerClient client = new PersonalizerClient(new ApiKeyServiceClientCredentials(ApiKey), handlers: handler)
            {
                Endpoint = "https://westus.api.cognitive.microsoft.com"
            };

            return client;
        }
    }
}
