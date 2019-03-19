using Microsoft.Azure.CognitiveServices.AnomalyDetector;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AnomalyDetectorSDK.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        private static readonly string AnomalyDetectorSubscriptionKey;

        static BaseTests()
        {
            // Retrieve the configuration information.
            AnomalyDetectorSubscriptionKey = "";
        }

        protected IAnomalyDetectorClient GetAnomalyDetectorClient(DelegatingHandler handler)
        {
            IAnomalyDetectorClient client = new AnomalyDetectorClient(new ApiKeyServiceClientCredentials(AnomalyDetectorSubscriptionKey), handlers: handler)
            {
                Endpoint = "https://westus2.api.cognitive.microsoft.com"
            };

            return client;
        }


    }
}
