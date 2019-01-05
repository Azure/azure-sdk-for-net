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
            return new FaceClient(new ApiKeyServiceClientCredentials(FaceSubscriptionKey), endpoint: "https://westus.api.cognitive.microsoft.com", handlers: handler);
        }
    }
}
