using Microsoft.Azure.CognitiveServices.Vision.FormRecognizer;
using System.Net.Http;

namespace FormRecognizerSDK.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        private static readonly string FormRecognizerSubscriptionKey;

        static BaseTests()
        {
            // Retrieve the configuration information.
            FormRecognizerSubscriptionKey = "";
        }

        protected IFormRecognizerClient GetFormRecognizerClient(DelegatingHandler handler)
        {
            IFormRecognizerClient client = new FormRecognizerClient(new ApiKeyServiceClientCredentials(FormRecognizerSubscriptionKey), handlers: handler)
            {
                Endpoint = "https://westus.api.cognitive.microsoft.com"
            };

            return client;
        }
    }
}
