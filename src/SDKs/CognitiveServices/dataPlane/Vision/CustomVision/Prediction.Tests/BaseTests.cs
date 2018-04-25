using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Net.Http;

namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Tests
{
    public abstract class BaseTests
    {
        private static readonly string PredictionKey;
        protected static readonly Guid ProjectId;
        static BaseTests()
        {
            PredictionKey = "";
            ProjectId = Guid.Parse("e222c033-5f5d-4a23-bde9-8343f19c0a01");
        }

        protected IPredictionEndpoint GetPredictionEndpointClient(DelegatingHandler handler)
        {
            IPredictionEndpoint client = new PredictionEndpoint(handlers: handler)
            {
                ApiKey = PredictionKey
            };

            return client;
        }
    }
}
