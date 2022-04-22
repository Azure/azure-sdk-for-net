// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class RankTests : PersonalizerTestBase
    {
        public RankTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task SingleSlotRankTests()
        {
            PersonalizerClient client = await GetPersonalizerClientAsync(isSingleSlot: true);
            await RankNullParameters(client);
            await RankServerFeatures(client);
            await RankNullParameters(client);
        }

        private async Task RankNullParameters(PersonalizerClient client)
        {
            IList<PersonalizerRankableAction> actions = new List<PersonalizerRankableAction>();
            actions.Add
                (new PersonalizerRankableAction(
                    id: "Person",
                    features:
                    new List<object>() { new { videoType = "documentary", videoLength = 35, director = "CarlSagan" }, new { mostWatchedByAge = "30-35" } }
            ));
            var request = new PersonalizerRankOptions(actions);
            // Action
            PersonalizerRankResult response = await client.RankAsync(request);
            // Assert
            Assert.AreEqual(actions.Count, response.Ranking.Count);
            for (int i = 0; i < response.Ranking.Count; i++)
            {
                Assert.AreEqual(actions[i].Id, response.Ranking[i].Id);
            }
        }

        private async Task RankServerFeatures(PersonalizerClient client)
        {
            IList<object> contextFeatures = new List<object>() {
                new { Features = new { day = "tuesday", time = "night", weather = "rainy" } },
                new { Features = new { userId = "1234", payingUser = true, favoriteGenre = "documentary", hoursOnSite = 0.12, lastwatchedType = "movie" } }
            };
            IList<PersonalizerRankableAction> actions = new List<PersonalizerRankableAction>();
            actions.Add(
                new PersonalizerRankableAction(
                    id: "Person1",
                    features:
                    new List<object>() { new { videoType = "documentary", videoLength = 35, director = "CarlSagan" }, new { mostWatchedByAge = "30-35" } }
            ));
            actions.Add(
                new PersonalizerRankableAction(
                    id: "Person2",
                    features:
                        new List<object>() { new { videoType = "documentary", videoLength = 35, director = "CarlSagan" }, new { mostWatchedByAge = "40-45" } }
            ));
            IList<string> excludeActions = new List<string> { "Person1" };
            string eventId = "123456789";
            var request = new PersonalizerRankOptions(actions, contextFeatures, excludeActions, eventId);
            // Action
            PersonalizerRankResult response = await client.RankAsync(request);
            // Assert
            Assert.AreEqual(eventId, response.EventId);
            Assert.AreEqual(actions.Count, response.Ranking.Count);
            for (int i = 0; i < response.Ranking.Count; i++)
            {
                Assert.AreEqual(actions[i].Id, response.Ranking[i].Id);
            }
        }

        private async Task RankWithNoOptions(PersonalizerClient client)
        {
            IList<object> contextFeatures = new List<object>() {
            new { Features = new { day = "tuesday", time = "night", weather = "rainy" } },
            new { Features = new { userId = "1234", payingUser = true, favoriteGenre = "documentary", hoursOnSite = 0.12, lastwatchedType = "movie" } }
            };
            IList<PersonalizerRankableAction> actions = new List<PersonalizerRankableAction>();
            actions.Add(
                new PersonalizerRankableAction(
                    id: "Person1",
                    features:
                    new List<object>() { new { videoType = "documentary", videoLength = 35, director = "CarlSagan" }, new { mostWatchedByAge = "30-35" } }
            ));
            actions.Add(
                new PersonalizerRankableAction(
                    id: "Person2",
                    features:
                        new List<object>() { new { videoType = "documentary", videoLength = 35, director = "CarlSagan" }, new { mostWatchedByAge = "40-45" } }
            ));
            // Action
            PersonalizerRankResult response = await client.RankAsync(actions, contextFeatures);
            Assert.AreEqual(actions.Count, response.Ranking.Count);
        }
    }
}
