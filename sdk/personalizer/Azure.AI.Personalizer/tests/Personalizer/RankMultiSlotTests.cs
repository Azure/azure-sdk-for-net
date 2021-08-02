// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class RankMultiSlotTests : PersonalizerTestBase
    {
        public RankMultiSlotTests(bool isAsync) : base(isAsync)
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
        public async Task RankMultiSlotNullParameters()
        {
            PersonalizerClient client = GetPersonalizerClient();
            PersonalizerRankMultiSlotOptions request = new PersonalizerRankMultiSlotOptions(actions, slots);
            // Action
            PersonalizerMultiSlotRankResult response = await client.RankMultiSlotAsync(request);
            // Assert
            Assert.AreEqual(slots.Count, response.Slots.Count);
            // Assertions for first slot
            PersonalizerSlotResult responseSlot1 = response.Slots[0];
            Assert.AreEqual(slot1.Id, responseSlot1.SlotId);
            Assert.AreEqual("NewsArticle", responseSlot1.RewardActionId);
            // Assertions for second slot
            PersonalizerSlotResult responseSlot2 = response.Slots[1];
            Assert.AreEqual(slot2.Id, responseSlot2.SlotId);
            Assert.AreEqual("SportsArticle", responseSlot2.RewardActionId);
        }

        [Test]
        public async Task RankMultiSlot()
        {
            PersonalizerClient client = GetPersonalizerClient();
            string eventId = "sdkTestEventId";
            PersonalizerRankMultiSlotOptions request = new PersonalizerRankMultiSlotOptions(actions, slots, contextFeatures, eventId);
            // Action
            PersonalizerMultiSlotRankResult response = await client.RankMultiSlotAsync(request);
            // Assert
            Assert.AreEqual(slots.Count, response.Slots.Count);
            // Assertions for first slot
            PersonalizerSlotResult responseSlot1 = response.Slots[0];
            Assert.AreEqual(slot1.Id, responseSlot1.SlotId);
            Assert.AreEqual("NewsArticle", responseSlot1.RewardActionId);
            // Assertions for second slot
            PersonalizerSlotResult responseSlot2 = response.Slots[1];
            Assert.AreEqual(slot2.Id, responseSlot2.SlotId);
            Assert.AreEqual("SportsArticle", responseSlot2.RewardActionId);
        }

        [Test]
        public async Task RankMultiSlotNoOptions()
        {
            PersonalizerClient client = GetPersonalizerClient();
            // Action
            PersonalizerMultiSlotRankResult response = await client.RankMultiSlotAsync(actions, slots, contextFeatures);
            // Assert
            Assert.AreEqual(slots.Count, response.Slots.Count);
            // Assertions for first slot
            PersonalizerSlotResult responseSlot1 = response.Slots[0];
            Assert.AreEqual(slot1.Id, responseSlot1.SlotId);
            Assert.AreEqual("NewsArticle", responseSlot1.RewardActionId);
            // Assertions for second slot
            PersonalizerSlotResult responseSlot2 = response.Slots[1];
            Assert.AreEqual(slot2.Id, responseSlot2.SlotId);
            Assert.AreEqual("SportsArticle", responseSlot2.RewardActionId);
        }
    }
}
