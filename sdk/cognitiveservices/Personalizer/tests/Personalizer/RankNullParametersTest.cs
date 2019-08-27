using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class RankNullParametersTest : BaseTests
    {
        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6213")]
        public async Task RankNullParameters()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "RankNullParameters");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                IList<RankableAction> actions = new List<RankableAction>();
                actions.Add(new RankableAction
                {
                    Id = "Person",
                    Features =
                        new List<object>() { new { videoType = "documentary", videoLength = 35, director = "CarlSagan" }, new { mostWatchedByAge = "30-35" } }
                });

                var request = new RankRequest(actions);

                // Action
                RankResponse response = await client.RankAsync(request);

                // Assert
                Assert.Equal(actions.Count, response.Ranking.Count);
                for (int i = 0; i < response.Ranking.Count; i++)
                {
                    Assert.Equal(actions[i].Id, response.Ranking[i].Id);
                }
            }
        }
    }
}
