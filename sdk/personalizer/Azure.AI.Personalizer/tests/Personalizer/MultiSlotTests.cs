// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class MultiSlotTests : PersonalizerTestBase
    {
        public MultiSlotTests(bool isAsync) : base(isAsync)
        {
        }

        public static IList<PersonalizerRankableAction> actions = new List<PersonalizerRankableAction>()
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

        public static IList<PersonalizerSlotOptions> slots = new List<PersonalizerSlotOptions>()
        {
            slot1,
            slot2
        };

        public static IList<object> contextFeatures = new List<object>()
        {
            new { User = new { ProfileType = "AnonymousUser", LatLong = "47.6,-122.1"} },
            new { Environment = new { DayOfMonth = "28", MonthOfYear = "8", Weather = "Sunny"} },
            new { Device = new { Mobile = true, Windows = true} },
            new { RecentActivity = new { ItemsInCart = 3} }
        };

        [Test]
        public async Task MultiSlotTest()
        {
            PersonalizerClient client = await GetPersonalizerClientAsync(isSingleSlot: false);
            await MultiSlotTestInner(client);
        }

        [Test]
        public async Task MultiSlotLocalInferenceTest()
        {
            PersonalizerClient client = await GetPersonalizerClientAsync(isSingleSlot: false, isLocalInference: true);
            await MultiSlotTestInner(client);
        }

        private async Task MultiSlotTestInner(PersonalizerClient client)
        {
            await RankMultiSlotNullParameters(client);
            await RankMultiSlotNoOptions(client);
            await RankMultiSlot(client);
            await Reward(client);
            await RewardForOneSlot(client);
            await Activate(client);
        }

        private async Task RankMultiSlotNullParameters(PersonalizerClient client)
        {
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

        private async Task RankMultiSlot(PersonalizerClient client)
        {
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

        private async Task RankMultiSlotNoOptions(PersonalizerClient client)
        {
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

        private async Task Reward(PersonalizerClient client)
        {
            PersonalizerSlotReward slotReward = new PersonalizerSlotReward("testSlot", 1);
            PersonalizerRewardMultiSlotOptions rewardRequest = new PersonalizerRewardMultiSlotOptions(new List<PersonalizerSlotReward> { slotReward });
            await client.RewardMultiSlotAsync("123456789", rewardRequest);
        }

        private async Task RewardForOneSlot(PersonalizerClient client)
        {
            await client.RewardMultiSlotAsync("123456789", "testSlot", 1);
        }

        private async Task Activate(PersonalizerClient client)
        {
            await client.ActivateMultiSlotAsync("123456789");
        }
    }
}
