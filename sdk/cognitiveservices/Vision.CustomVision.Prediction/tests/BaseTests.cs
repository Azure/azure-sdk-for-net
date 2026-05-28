namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Tests
{
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
    using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training;
    using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Tests;
    using System;
    using System.IO;
    using System.Reflection;

    public abstract class BaseTests
    {
        private static readonly string PredictionKey = string.Empty;
        private const string Endpoint = "https://southcentralus.api.cognitive.microsoft.com";

        protected static readonly Guid ClassificationProjectId = Guid.Parse("e3c7fd20-0c05-4c8c-886d-be4ea92e01c8");
        protected static readonly Guid ObjectDetectionProjectId = Guid.Parse("b5154425-001a-4204-b98a-165b4842e11c");

        protected static readonly string ClassificationPublishedName = ProjectBuilderHelper.ClassificationPublishName;
        protected static readonly string ObjDetectionPublishedName = ProjectBuilderHelper.ObjDetectionPublishName;

        protected static HttpRecorderMode RecorderMode = HttpRecorderMode.Playback;

        static BaseTests()
        {
#if RECORD_MODE
            RecorderMode = HttpRecorderMode.Record;
            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();

            var executingAssemblyPath = new Uri(typeof(BaseTests).GetTypeInfo().Assembly.CodeBase);
            //HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath.AbsolutePath), @"SessionRecords");

            var credentials = new Training.ApiKeyServiceClientCredentials("<Add training key>");
            ICustomVisionTrainingClient trainingClient = new CustomVisionTrainingClient(credentials);
            trainingClient.Endpoint = Endpoint;

            ProjectBuilderHelper.CleanUpOldProjects(trainingClient);

            HttpMockServer.Initialize(typeof(BaseTests).Name, "Unused", RecorderMode);

            var predictionResourceId = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{predictionResourceName}";
            ClassificationProjectId = ProjectBuilderHelper.CreateTrainedImageClassificationProject(trainingClient, predictionResourceId).ProjectId;
            ObjectDetectionProjectId = ProjectBuilderHelper.CreateTrainedObjDetectionProject(trainingClient, predictionResourceId).ProjectId;
#endif
        }

        protected ICustomVisionPredictionClient GetPredictionClientClient()
        {
            var credentials = new Prediction.ApiKeyServiceClientCredentials(PredictionKey);
            ICustomVisionPredictionClient client = new CustomVisionPredictionClient(credentials, handlers: HttpMockServer.CreateInstance())
            {
                Endpoint = Endpoint
            };

            return client;
        }
    }
}
