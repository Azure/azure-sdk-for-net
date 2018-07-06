using Microsoft.Azure.CognitiveServices.Vision.Face;
using System.Net.Http;
using Face = Microsoft.Azure.CognitiveServices.Vision.Face.Models;

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
            IFaceClient client = new FaceClient(new ApiKeyServiceClientCredentials(FaceSubscriptionKey), handlers: handler);

            return client;
        }
    }
}
