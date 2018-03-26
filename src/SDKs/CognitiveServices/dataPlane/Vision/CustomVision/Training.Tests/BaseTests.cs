using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Net.Http;

namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Tests
{
    public abstract class BaseTests
    {
        private static readonly string TrainingKey;

        protected static Guid FoodDomain = Guid.Parse("C151D5B5-DD07-472A-ACC8-15D29DEA8518");
        protected static Guid GeneralDomain = Guid.Parse("EE85A74C-405E-4ADC-BB47-FFA8CA0C9F31");
        protected static Guid ProjectId = Guid.Parse("e222c033-5f5d-4a23-bde9-8343f19c0a01");

        static BaseTests()
        {
            TrainingKey = "";
        }

        protected ITrainingApi GetTrainingApiClient(DelegatingHandler handler)
        {
            ITrainingApi client = new TrainingApi(handlers: handler)
            {
                ApiKey = TrainingKey
            };

            return client;
        }
    }
}
