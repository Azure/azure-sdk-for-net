using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.Personalizer.Tests
{
    public class RankServerFeaturesTest : BaseTests
    {
        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6213")]
        public async Task RankServerFeatures()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "RankServerFeatures");

                IPersonalizerClient client = GetClient(HttpMockServer.CreateInstance());

                IList<object> contextFeatures = new List<object>() {
                    new { Features = new { day = "tuesday", time = "night", weather = "rainy" } },
                    new { Features = new { userId = "1234", payingUser = true, favoriteGenre = "documentary", hoursOnSite = 0.12, lastwatchedType = "movie" } }
                };

                IList<RankableAction> actions = new List<RankableAction>();
                actions.Add(new RankableAction
                {
                    Id = "Person1",
                    Features =
                        new List<object>() { new { videoType = "documentary", videoLength = 35, director = "CarlSagan" }, new { mostWatchedByAge = "30-35" } }
                });
                actions.Add(new RankableAction
                {
                    Id = "Person2",
                    Features =
                        new List<object>() { new { videoType = "documentary", videoLength = 35, director = "CarlSagan" }, new { mostWatchedByAge = "40-45" } }
                });

                IList<string> excludeActions = new List<string> { "Person1" };
                string eventId = "123456789";

                var request = new RankRequest(actions, contextFeatures, excludeActions, eventId);

                // Action
                RankResponse response = await client.RankAsync(request);

                // Assert
                Assert.Equal(eventId, response.EventId);
                Assert.Equal(actions.Count, response.Ranking.Count);
                for (int i = 0; i < response.Ranking.Count; i++)
                {
                    Assert.Equal(actions[i].Id, response.Ranking[i].Id);
                }

            }
        }
    }
}
