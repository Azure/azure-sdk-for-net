using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System.Net.Http;
using Vision = Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace ComputerVisionSDK.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        private static readonly string ComputerVisionSubscriptionKey;

        static BaseTests()
        {
            // Retrieve the configuration information.
            ComputerVisionSubscriptionKey = "";
        }

        protected IComputerVisionAPI GetComputerVisionClient(DelegatingHandler handler)
        {
            IComputerVisionAPI client = new ComputerVisionAPI(new ApiKeyServiceClientCredentials(ComputerVisionSubscriptionKey), handlers: handler)
            {
                AzureRegion = Vision.AzureRegions.Westus
            };

            return client;
        }
    }
}
