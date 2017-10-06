using Microsoft.CognitiveServices.Search.EntitySearch;
using System.Net.Http;

namespace EntitySearchSDK.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        private static string SubscriptionKey = "fake";

        static BaseTests()
        {
            // Retrieve the configuration information.
            SubscriptionKey = "fake";
            // Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");
        }

        protected IEntitySearchAPI GetClient(DelegatingHandler handler)
        {
            return new EntitySearchAPI(new ApiKeyServiceClientCredentials(SubscriptionKey), handler)
            {
                AzureRegion1 = Microsoft.CognitiveServices.Search.EntitySearch.Models.AzureRegion.Westus
            };
        }
    }
}
