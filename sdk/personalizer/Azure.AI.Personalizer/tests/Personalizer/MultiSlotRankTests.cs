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

        private static IList<RankableAction> actions = new List<RankableAction>()
        {
            new RankableAction(
                id: "NewsArticle",
                features: new List<object>() { new { Type = "News" }}
                ),
            new RankableAction(
                id: "SportsArticle",
                features: new List<object>() { new { Type = "Sports" }}
                ),
            new RankableAction(
                id: "EntertainmentArticle",
                features: new List<object>() { new { Type = "Entertainment" }}
            )
        };

        private static SlotRequest slot1 = new SlotRequest(
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

        private static SlotRequest slot2 = new SlotRequest(
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

        private static IList<SlotRequest> slots = new List<SlotRequest>()
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
            MultiSlotRankRequest request = new MultiSlotRankRequest(actions, slots);
            // Action
            MultiSlotRankResponse response = await client.MultiSlot.RankAsync(request);
            // Assert
            Assert.AreEqual(slots.Count, response.Slots.Count);
            // Assertions for first slot
            SlotResponse responseSlot1 = response.Slots[0];
            Assert.AreEqual(slot1.Id, responseSlot1.Id);
            Assert.AreEqual("NewsArticle", responseSlot1.RewardActionId);
            // Assertions for second slot
            SlotResponse responseSlot2 = response.Slots[1];
            Assert.AreEqual(slot2.Id, responseSlot2.Id);
            Assert.AreEqual("SportsArticle", responseSlot2.RewardActionId);
        }

        [Test]
        public async Task MultiSlotRank()
        {
            PersonalizerClient client = GetPersonalizerClient();
            string eventId = "sdkTestEventId";
            MultiSlotRankRequest request = new MultiSlotRankRequest(actions, slots, contextFeatures, eventId);
            // Action
            MultiSlotRankResponse response = await client.MultiSlot.RankAsync(request);
            // Assert
            Assert.AreEqual(slots.Count, response.Slots.Count);
            // Assertions for first slot
            SlotResponse responseSlot1 = response.Slots[0];
            Assert.AreEqual(slot1.Id, responseSlot1.Id);
            Assert.AreEqual("NewsArticle", responseSlot1.RewardActionId);
            // Assertions for second slot
            SlotResponse responseSlot2 = response.Slots[1];
            Assert.AreEqual(slot2.Id, responseSlot2.Id);
            Assert.AreEqual("SportsArticle", responseSlot2.RewardActionId);
        }
    }
}
