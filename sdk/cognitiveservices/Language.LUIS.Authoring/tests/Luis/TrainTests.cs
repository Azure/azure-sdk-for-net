namespace LUIS.Authoring.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    [Collection("TestCollection")]
    public class TrainTests : BaseTest
    {
        [Fact]
        public void GetStatus()
        {
            UseClientFor(async client =>
            {
                var versionId = "0.1";
                await client.Train.TrainVersionAsync(GlobalAppId, versionId);
                var result = await client.Train.GetStatusAsync(GlobalAppId, versionId);
                var finishStates = new string[] { "Success", "UpToDate" };

                while (!result.All(r => finishStates.Contains(r.Details.Status)))
                {
                    await Task.Delay(1000);
                    result = await client.Train.GetStatusAsync(GlobalAppId, versionId);
                }

                foreach (var trainResult in result)
                {
                    switch (trainResult.Details.Status)
                    {
                        case "Success":
                        case "UpToDate":
                            Assert.Null(trainResult.Details.FailureReason);
                            break;
                        case "Fail":
                        case "InProgress":
                        default:
                            Assert.False(true);
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

                await client.Train.TrainVersionAsync(GlobalAppId, versionId);
                var result = await client.Train.GetStatusAsync(GlobalAppId, versionId);
                var finishStates = new string[] { "Success", "UpToDate" };

                while (!result.All(r => finishStates.Contains(r.Details.Status)))
                {
                    await Task.Delay(1000);
                    result = await client.Train.GetStatusAsync(GlobalAppId, versionId);
                }

                var secondTrainResult = await client.Train.TrainVersionAsync(GlobalAppId, versionId);

                Assert.Equal("UpToDate", secondTrainResult.Status);
            });
        }
    }
}
