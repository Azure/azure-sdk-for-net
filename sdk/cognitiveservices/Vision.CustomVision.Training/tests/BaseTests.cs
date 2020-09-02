namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Tests
{
    using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public abstract class BaseTests : IClassFixture<ProjectIdFixture>
    {
        public static readonly string TrainingKey = string.Empty;

        public const string Endpoint = "https://southcentralus.api.cognitive.microsoft.com/";

        public static HttpRecorderMode RecorderMode = HttpRecorderMode.Playback;

        public static string PredictionResourceId = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{predictionResourceProviderName}";

        private ProjectIdFixture fixture;

        static BaseTests()
        {
#if RECORD_MODE
            TrainingKey = "";
            RecorderMode = HttpRecorderMode.Record;
            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();

            var executingAssemblyPath = new Uri(typeof(BaseTests).GetTypeInfo().Assembly.CodeBase);
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath.AbsolutePath), @"..\..\..\SessionRecords");

            // Clean up previous run of projects at the start of this test.
            var credentials = new ApiKeyServiceClientCredentials(TrainingKey);
            var client = new CustomVisionTrainingClient(credentials)
            {
                Endpoint = Endpoint
            };
            ProjectBuilderHelper.CleanUpOldProjects(client);
#endif
        }

        public BaseTests(ProjectIdFixture fixture)
        {
            this.fixture = fixture;
        }

        public static ICustomVisionTrainingClient GetTrainingClient(bool addHandler = true)
        {
            var credentials = new ApiKeyServiceClientCredentials(TrainingKey);
            ICustomVisionTrainingClient client = (addHandler) ?
                new CustomVisionTrainingClient(credentials, handlers: HttpMockServer.CreateInstance()) :
                new CustomVisionTrainingClient(credentials);

            client.Endpoint = Endpoint;

            return client;
        }

        public ProjectWrapper CreateTrainedImageClassificationProject(Guid? domain = null)
        {
#if RECORD_MODE
            var iteration = ProjectBuilderHelper.CreateTrainedImageClassificationProject(GetTrainingClient(), PredictionResourceId, domain);
            this.fixture.TestToIterationMapping[HttpMockServer.TestIdentity] = iteration;

            return new ProjectWrapper(iteration.ProjectId, iteration.Id);
#else
            return new ProjectWrapper(this.fixture.TestToIterationMapping[HttpMockServer.TestIdentity].ProjectId, this.fixture.TestToIterationMapping[HttpMockServer.TestIdentity].Id);
#endif
        }

        public ProjectWrapper CreateTrainedObjDetectionProject()
        {
#if RECORD_MODE
            var iteration = ProjectBuilderHelper.CreateTrainedObjDetectionProject(GetTrainingClient(), PredictionResourceId);
            this.fixture.TestToIterationMapping[HttpMockServer.TestIdentity] = iteration;

            return new ProjectWrapper(iteration.ProjectId, iteration.Id);
#else
            return new ProjectWrapper(this.fixture.TestToIterationMapping[HttpMockServer.TestIdentity].ProjectId, this.fixture.TestToIterationMapping[HttpMockServer.TestIdentity].Id);
#endif
        }
    }
}
