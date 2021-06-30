// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Personalizer.Models;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class RankTests : PersonalizerTestBase
    {
        public RankTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task RankNullParameters()
        {
            PersonalizerClient client = GetPersonalizerClient();
            IList<RankableAction> actions = new List<RankableAction>();
            actions.Add
                (new RankableAction(
                    id: "Person",
                    features:
                    new List<object>() { new { videoType = "documentary", videoLength = 35, director = "CarlSagan" }, new { mostWatchedByAge = "30-35" } }
            ));
            var request = new RankRequest(actions);
            // Action
            RankResponse response = await client.PersonalizerBase.RankAsync(request);
            // Assert
            Assert.AreEqual(actions.Count, response.Ranking.Count);
            for (int i = 0; i < response.Ranking.Count; i++)
            {
                Assert.AreEqual(actions[i].Id, response.Ranking[i].Id);
            }
        }

        [Test]
        public async Task RankServerFeatures()
        {
            PersonalizerClient client = GetPersonalizerClient();
            IList<object> contextFeatures = new List<object>() {
                new { Features = new { day = "tuesday", time = "night", weather = "rainy" } },
                new { Features = new { userId = "1234", payingUser = true, favoriteGenre = "documentary", hoursOnSite = 0.12, lastwatchedType = "movie" } }
            };
            IList<RankableAction> actions = new List<RankableAction>();
            actions.Add(
                new RankableAction(
                    id: "Person1",
                    features:
                    new List<object>() { new { videoType = "documentary", videoLength = 35, director = "CarlSagan" }, new { mostWatchedByAge = "30-35" } }
            ));
            actions.Add(
                new RankableAction(
                    id: "Person2",
                    features:
                        new List<object>() { new { videoType = "documentary", videoLength = 35, director = "CarlSagan" }, new { mostWatchedByAge = "40-45" }}
            ));
            IList<string> excludeActions = new List<string> { "Person1" };
            string eventId = "123456789";
            var request = new RankRequest(actions, contextFeatures, excludeActions, eventId);
            // Action
            RankResponse response = await client.PersonalizerBase.RankAsync(request);
            // Assert
            Assert.AreEqual(eventId, response.EventId);
            Assert.AreEqual(actions.Count, response.Ranking.Count);
            for (int i = 0; i < response.Ranking.Count; i++)
            {
                Assert.AreEqual(actions[i].Id, response.Ranking[i].Id);
            }
        }
    }
}
