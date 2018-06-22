namespace LUIS.Authoring.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class TrainTests : BaseTest
    {
        [Fact]
        public void GetStatus()
        {
            UseClientFor(async client =>
            {
                var versionId = "0.1";
                var result = await client.Train.GetStatusAsync(appId, versionId);

                foreach (var trainResult in result)
                {
                    switch (trainResult.Details.Status)
                    {
                        case "Success":
                            Assert.NotNull(trainResult.Details.TrainingDateTime);
                            Assert.Null(trainResult.Details.FailureReason);
                            break;
                        case "Fail":
                            Assert.NotNull(trainResult.Details.FailureReason);
                            Assert.Null(trainResult.Details.TrainingDateTime);
                            break;
                        case "UpToDate":
                            Assert.NotNull(trainResult.Details.TrainingDateTime);
                            Assert.Null(trainResult.Details.FailureReason);
                            break;
                        case "InProgress":
                            Assert.Null(trainResult.Details.TrainingDateTime);
                            Assert.Null(trainResult.Details.FailureReason);
                            break;
                    }
                }

            });
        }


        [Fact]
        public void TrainVersion()
        {
            UseClientFor(async client =>
            {
                var versionId = "0.1";

                var result = await client.Train.TrainVersionAsync(appId, versionId);
                var finishStates = new string[] { "Success", "UpToDate" };

                while (!finishStates.Contains(result.Status))
                {
                    await Task.Delay(1000);
                    result = await client.Train.TrainVersionAsync(appId, versionId);
                }

                result = await client.Train.TrainVersionAsync(appId, versionId);

                Assert.Equal("UpToDate", result.Status);
            });
        }
    }
}
