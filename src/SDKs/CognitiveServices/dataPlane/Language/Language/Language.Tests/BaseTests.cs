using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System.Net.Http;

namespace Language.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        private static string SubscriptionKey = "000";

        protected ITextAnalyticsAPI GetClient(DelegatingHandler handler)
        {
            return new TextAnalyticsAPI(new ApiKeyServiceClientCredentials(SubscriptionKey), handlers: handler)
            {
                AzureRegion = AzureRegions.Westus
            };
        }
    }
}
