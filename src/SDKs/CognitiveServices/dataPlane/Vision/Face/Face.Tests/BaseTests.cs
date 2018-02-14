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

        protected IFaceAPI GetFaceClient(DelegatingHandler handler)
        {
            IFaceAPI client = new FaceAPI(new ApiKeyServiceClientCredentials(FaceSubscriptionKey), handlers: handler)
            {
                AzureRegion = Face.AzureRegions.Westus
            };

            return client;
        }
    }
}
