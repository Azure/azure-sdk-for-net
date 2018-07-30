using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System.Net.Http;

namespace Language.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        // BaseEndpoint only contains protocol and hostname
        private static string BaseEndpoint = "https://westus.api.cognitive.microsoft.com";
        private static string SubscriptionKey = "000";

        protected ITextAnalyticsClient GetClient(DelegatingHandler handler)
        {
            return new TextAnalyticsClient(new ApiKeyServiceClientCredentials(SubscriptionKey), handlers: handler)
            {
                Endpoint = BaseEndpoint
            };
        }
    }
}
