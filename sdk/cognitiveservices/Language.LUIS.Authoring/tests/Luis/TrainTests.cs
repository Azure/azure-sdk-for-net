namespace LUIS.Authoring.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class TrainTests : BaseTest
    {
        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
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


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6211")]
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
