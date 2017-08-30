using Microsoft.CognitiveServices.Vision.Face;
using System;
using System.Net.Http;

namespace FaceSDK.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        private static string SubscriptionKey = "";
        private static string Region = null;

        static BaseTests()
        {
            // Retrieve the configuration information.
            SubscriptionKey = "";
            // Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");
            Region = "WestUS";
        }

        protected IFaceAPI GetClient(DelegatingHandler handler)
        {
            IFaceAPI client;
            client = new FaceAPI(handlers: handler);
            client.AzureRegion1 = Region;
            client.SubscriptionKey = SubscriptionKey;

            return client;
        }
    }
}
