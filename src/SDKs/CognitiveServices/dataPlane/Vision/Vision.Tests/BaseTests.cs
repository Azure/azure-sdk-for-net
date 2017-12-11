using Microsoft.Azure.CognitiveServices.Vision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using System;
using System.Net.Http;
using Face = Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Vision = Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace FaceSDK.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        private static string FaceSubscriptionKey = "";
        private static string ComputerVisionSubscriptionKey = "";

        static BaseTests()
        {
            // Retrieve the configuration information.
            FaceSubscriptionKey = "";
            ComputerVisionSubscriptionKey = "";
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
        }

        protected IFaceAPI GetFaceClient(DelegatingHandler handler)
        {
            IFaceAPI client;
            client = new FaceAPI(new ApiKeyServiceClientCredentials(FaceSubscriptionKey), handlers: handler);
            client.AzureRegion = Face.AzureRegions.Westcentralus;

            return client;
        }

        protected IComputerVisionAPI GetComputerVisionClient(DelegatingHandler handler)
        {
            IComputerVisionAPI client;
            client = new ComputerVisionAPI(new ApiKeyServiceClientCredentials(ComputerVisionSubscriptionKey), handlers: handler);
            client.AzureRegion = Vision.AzureRegions.Westcentralus;

            return client;
        }
    }
}
