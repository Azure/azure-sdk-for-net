using Microsoft.Azure.CognitiveServices.Vision;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System;
using System.Net.Http;

namespace FaceSDK.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        private static string SubscriptionKey = "";

        static BaseTests()
        {
            // Retrieve the configuration information.
            SubscriptionKey = "";
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
        }

        protected IFaceAPI GetClient(DelegatingHandler handler)
        {
            IFaceAPI client;
            client = new FaceAPI(new ApiKeyServiceClientCredentials(SubscriptionKey), handlers: handler);
            client.AzureRegion = AzureRegions.Westcentralus;

            return client;
        }
    }
}
