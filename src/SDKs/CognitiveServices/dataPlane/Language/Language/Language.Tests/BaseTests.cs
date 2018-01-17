using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using System.Net.Http;

namespace Language.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        private static string SubscriptionKey = "";
        private static string Region = null;

        static BaseTests()
        {
            // Retrieve the configuration information.

            Region = "WestUS";
        }

        protected ITextAnalyticsAPI GetClient(DelegatingHandler handler)
        {
            ITextAnalyticsAPI client;
            client = new TextAnalyticsAPI(handlers: handler);
            client.SubscriptionKey = SubscriptionKey;

            return client;
        }
    }
}
