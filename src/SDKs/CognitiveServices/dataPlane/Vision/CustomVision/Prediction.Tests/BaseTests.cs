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
            ProjectId = Guid.Parse("32cb8dd6-19f8-4f08-afef-360b2e46274e");

#if RECORD_MODE
            PredictionKey = "";

            RecorderMode = HttpRecorderMode.Record;
            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();

            var executingAssemblyPath = new Uri(typeof(BaseTests).GetTypeInfo().Assembly.CodeBase);
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath.AbsolutePath), @"..\..\..\SessionRecords");
#endif
        }

        protected ICustomVisionPredictionClient GetPredictionClientClient()
        {
            ICustomVisionPredictionClient client = new CustomVisionPredictionClient(handlers: HttpMockServer.CreateInstance())
            {
                ApiKey = PredictionKey,
                Endpoint = "https://southcentralus.api.cognitive.microsoft.com"
            };

            return client;
        }
    }
}
