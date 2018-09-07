namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Tests
{
    using Microsoft.Azure.Test.HttpRecorder;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Reflection;

    public abstract class BaseTests
    {
        private static readonly string PredictionKey = string.Empty;
        protected static readonly Guid ProjectId;
        protected static HttpRecorderMode RecorderMode = HttpRecorderMode.Playback;

        static BaseTests()
        {
            ProjectId = Guid.Parse("1896e6d9-5090-4733-882f-4f14632fec37");

#if RECORD_MODE
            PredictionKey = "";

            RecorderMode = HttpRecorderMode.Record;
            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();

            string executingAssemblyPath = typeof(BaseTests).GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), @"..\..\..\SessionRecords");
#endif
        }

        protected IPredictionEndpoint GetPredictionClientClient()
        {
            IPredictionEndpoint client = new PredictionEndpoint(handlers: HttpMockServer.CreateInstance())
            {
                ApiKey = PredictionKey
            };

            return client;
        }
    }
}
