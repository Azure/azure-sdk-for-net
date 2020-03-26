namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Tests
{
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training;
    using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Tests;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Reflection;

    public abstract class BaseTests
    {
        private static readonly string PredictionKey = string.Empty;
        private const string Endpoint = "https://southcentralus.api.cognitive.microsoft.com";

        protected static readonly Guid ClassificationProjectId = Guid.Parse("eac7b96a-c848-4b83-a920-c834407c4f80");
        protected static readonly Guid ObjectDetectionProjectId = Guid.Parse("7bbd16f5-6511-424e-81ac-e06bb54348d1");

        protected static readonly string ClassificationPublishedName = ProjectBuilderHelper.ClassificationPublishName;
        protected static readonly string ObjDetectionPublishedName = ProjectBuilderHelper.ObjDetectionPublishName;

        protected static HttpRecorderMode RecorderMode = HttpRecorderMode.Playback;

        static BaseTests()
        {
#if RECORD_MODE
            PredictionKey = "";

            RecorderMode = HttpRecorderMode.Record;
            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();

            var executingAssemblyPath = new Uri(typeof(BaseTests).GetTypeInfo().Assembly.CodeBase);
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath.AbsolutePath), @"..\..\..\SessionRecords");

            var credentials = new ApiKeyServiceClientCredentials("");
            ICustomVisionTrainingClient trainingClient = new CustomVisionTrainingClient(credentials);
            trainingClient.Endpoint = Endpoint;

            HttpMockServer.Initialize(typeof(BaseTests).Name, "Unused", RecorderMode);

            var predictionResourceId = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{predictionResourceName}";
            ClassificationProjectId = ProjectBuilderHelper.CreateTrainedImageClassificationProject(trainingClient, predictionResourceId).ProjectId;
            ObjectDetectionProjectId = ProjectBuilderHelper.CreateTrainedObjDetectionProject(trainingClient, predictionResourceId).ProjectId;
#endif
        }

        protected ICustomVisionPredictionClient GetPredictionClientClient()
        {
            var credentials = new ApiKeyServiceClientCredentials(PredictionKey);
            ICustomVisionPredictionClient client = new CustomVisionPredictionClient(credentials, handlers: HttpMockServer.CreateInstance())
            {
                Endpoint = Endpoint
            };

            return client;
        }
    }
}
