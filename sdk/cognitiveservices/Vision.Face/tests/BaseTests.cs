using Microsoft.Azure.CognitiveServices.Vision.Face;
using System.Net.Http;

namespace FaceSDK.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        private static readonly string FaceSubscriptionKey;

        static BaseTests()
        {
            // Retrieve the configuration information.
            FaceSubscriptionKey = "";
        }

        protected IFaceClient GetFaceClient(DelegatingHandler handler)
        {
            IFaceClient client = new FaceClient(new ApiKeyServiceClientCredentials(FaceSubscriptionKey), handlers: handler)
            {
                Endpoint = "https://westus.api.cognitive.microsoft.com"
            };

            return client;
        }
    }
}
