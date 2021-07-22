// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Personalizer.Models;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class MultiSlotRankTests : PersonalizerTestBase
    {
        public MultiSlotRankTests(bool isAsync) : base(isAsync)
        {
        }

        private static IList<PersonalizerRankableAction> actions = new List<PersonalizerRankableAction>()
        {
            new PersonalizerRankableAction(
                id: "NewsArticle",
                features: new List<object>() { new { Type = "News" }}
                ),
            new PersonalizerRankableAction(
                id: "SportsArticle",
                features: new List<object>() { new { Type = "Sports" }}
                ),
            new PersonalizerRankableAction(
                id: "EntertainmentArticle",
                features: new List<object>() { new { Type = "Entertainment" }}
            )
        };

        private static PersonalizerSlotOptions slot1 = new PersonalizerSlotOptions(
            id: "Main Article",
            baselineAction: "NewsArticle",
            features: new List<object>()
            {
                new
                {
                    Size = "Large",
                    Position = "Top Middle"
                }
            },
            excludedActions: new List<string>() { "SportsArticle", "EntertainmentArticle" }
            );

        private static PersonalizerSlotOptions slot2 = new PersonalizerSlotOptions(
            id: "Side Bar",
            baselineAction: "SportsArticle",
            features: new List<object>()
            {
                new
                {
                    Size = "Small",
                    Position = "Bottom Right"
                }
            },
            excludedActions: new List<string>() { "EntertainmentArticle" }
            );

        private static IList<PersonalizerSlotOptions> slots = new List<PersonalizerSlotOptions>()
        {
            slot1,
            slot2
        };

        private static IList<object> contextFeatures = new List<object>()
        {
            new { User = new { ProfileType = "AnonymousUser", LatLong = "47.6,-122.1"} },
            new { Environment = new { DayOfMonth = "28", MonthOfYear = "8", Weather = "Sunny"} },
            new { Device = new { Mobile = true, Windows = true} },
            new { RecentActivity = new { ItemsInCart = 3} }
        };

        [Test]
        public async Task MultiSlotRankNullParameters()
        {
            PersonalizerClient client = GetPersonalizerClient();
            PersonalizerMultiSlotRankOptions request = new PersonalizerMultiSlotRankOptions(actions, slots);
            // Action
            PersonalizerMultiSlotRankResult response = await client.MultiSlotRankAsync(request);
            // Assert
            Assert.AreEqual(slots.Count, response.Slots.Count);
            // Assertions for first slot
            PersonalizerSlotResult responseSlot1 = response.Slots[0];
            Assert.AreEqual(slot1.Id, responseSlot1.Id);
            Assert.AreEqual("NewsArticle", responseSlot1.RewardActionId);
            // Assertions for second slot
            PersonalizerSlotResult responseSlot2 = response.Slots[1];
            Assert.AreEqual(slot2.Id, responseSlot2.Id);
            Assert.AreEqual("SportsArticle", responseSlot2.RewardActionId);
        }

        [Test]
        public async Task MultiSlotRank()
        {
            PersonalizerClient client = GetPersonalizerClient();
            string eventId = "sdkTestEventId";
            PersonalizerMultiSlotRankOptions request = new PersonalizerMultiSlotRankOptions(actions, slots, contextFeatures, eventId);
            // Action
            PersonalizerMultiSlotRankResult response = await client.MultiSlotRankAsync(request);
            // Assert
            Assert.AreEqual(slots.Count, response.Slots.Count);
            // Assertions for first slot
            PersonalizerSlotResult responseSlot1 = response.Slots[0];
            Assert.AreEqual(slot1.Id, responseSlot1.Id);
            Assert.AreEqual("NewsArticle", responseSlot1.RewardActionId);
            // Assertions for second slot
            PersonalizerSlotResult responseSlot2 = response.Slots[1];
            Assert.AreEqual(slot2.Id, responseSlot2.Id);
            Assert.AreEqual("SportsArticle", responseSlot2.RewardActionId);
        }
    }
}
