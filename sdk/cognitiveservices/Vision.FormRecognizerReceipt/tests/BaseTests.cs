using Microsoft.Azure.CognitiveServices.FormRecognizerReceipt;
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

        protected IFormRecognizerReceiptClient GetFormRecognizerClient(params DelegatingHandler[] handler)
        {
            IFormRecognizerReceiptClient client = new FormRecognizerReceiptClient(new ApiKeyServiceClientCredentials(FormRecognizerSubscriptionKey), handlers: handler)
            {
                Endpoint = new System.Uri(@"https://westus.api.cognitive.microsoft.com").ToString()
            };

            return client;
        }
    }
}
