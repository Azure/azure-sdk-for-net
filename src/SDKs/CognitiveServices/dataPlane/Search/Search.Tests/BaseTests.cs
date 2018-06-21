using Microsoft.Azure.CognitiveServices.Search;
using Microsoft.Azure.CognitiveServices.Search.EntitySearch;
using Microsoft.Azure.CognitiveServices.Search.WebSearch;
using System.Net.Http;

namespace SearchSDK.Tests
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

        protected dynamic GetClient(DelegatingHandler handler, SearchTypes searchType)
        {
            switch (searchType)
            {
                case SearchTypes.EntitySearch:
                    return new EntitySearchAPI(new ApiKeyServiceClientCredentials(SubscriptionKey), handler);
                case SearchTypes.WebSearch:
                    return new WebSearchAPI(new ApiKeyServiceClientCredentials(SubscriptionKey), handler);
                default:
                    return null;
            }
        }
    }
}
