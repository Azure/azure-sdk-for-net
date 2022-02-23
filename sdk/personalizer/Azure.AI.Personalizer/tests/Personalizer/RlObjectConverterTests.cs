// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;
using static Azure.AI.Personalizer.Tests.PersonalizerTestBase;

namespace Azure.AI.Personalizer.Tests
{
    public class RlObjectConverterTests
    {
        private PersonalizerSlotOptions slot = new PersonalizerSlotOptions(
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

        [Test]
        public void ConvertToContextJsonTest()
        {
            IEnumerable<object> contextFeatures = new List<object>() {
                new { Features = new { day = "Monday", time = "morning", weather = "sunny" } },
            };
            List<PersonalizerRankableAction> actions = new List<PersonalizerRankableAction>();
            actions.Add
                (new PersonalizerRankableAction(
                    id: "Person",
                    features:
                    new List<object>() { new { videoType = "documentary", videoLength = 35, director = "CarlSagan" }, new { mostWatchedByAge = "30-35" } }
            ));
            string contextJson = RlObjectConverter.ConvertToContextJson(contextFeatures, actions);
            string expectedJson =
                "{\"FromUrl\":[{" +
                    "\"Features\":{" +
                        "\"day\":\"Monday\"," +
                        "\"time\":\"morning\"," +
                        "\"weather\":\"sunny\"}}]," +
                "\"_multi\":[{" +
                    "\"_tag\":\"Person\"," +
                    "\"j\":[{" +
                        "\"videoType\":\"documentary\"," +
                        "\"videoLength\":35," +
                        "\"director\":\"CarlSagan\"" +
                        "}," +
                        "{\"mostWatchedByAge\":\"30-35\"}" +
                        "]" +
                    "}]" +
                "}";
            Assert.IsTrue(contextJson.Equals(expectedJson));
        }

        [Test]
        public void GetIncludedActionsForSlotTest()
        {
            Dictionary<string, int> actionIdToActionIndex = new Dictionary<string, int>();
            actionIdToActionIndex.Add("NewArticle", 0);
            actionIdToActionIndex.Add("SportsArticle", 1);
            actionIdToActionIndex.Add("EntertainmentArticle", 2);
            IList<object> features = RlObjectConverter.GetIncludedActionsForSlot(slot, actionIdToActionIndex);
        }

        [Test]
        public void ExtractBaselineActionsFromRankRequestTest()
        {
            PersonalizerRankMultiSlotOptions request = new PersonalizerRankMultiSlotOptions(
                MultiSlotTests.actions, MultiSlotTests.slots, MultiSlotTests.contextFeatures, "testEventId");
            int[] baselineActions = RlObjectConverter.ExtractBaselineActionsFromRankRequest(request);
            Assert.AreEqual(2, baselineActions.Length);
            Assert.AreEqual(0, baselineActions[0]);
            Assert.AreEqual(1, baselineActions[1]);
        }

        [Test]
        public void GetActionIdToIndexMappingTest()
        {
            Dictionary<string, int> idToIndex = RlObjectConverter.GetActionIdToIndexMapping(MultiSlotTests.actions);
            Assert.AreEqual(3, idToIndex.Keys.Count);
            Assert.AreEqual(idToIndex["NewsArticle"], 0);
            Assert.AreEqual(idToIndex["SportsArticle"], 1);
            Assert.AreEqual(idToIndex["EntertainmentArticle"], 2);
        }

        [Test]
        public void GenerateRankResultTest()
        {
            List<PersonalizerRankableAction> originalActions = GetActions();
            List<PersonalizerRankableAction> rankableActions = new List<PersonalizerRankableAction>();
            List<PersonalizerRankableAction> excludedActions = new List<PersonalizerRankableAction>();
            rankableActions.Add(originalActions[1]);
            rankableActions.Add(originalActions[2]);
            rankableActions.Add(originalActions[3]);
            excludedActions.Add(originalActions[0]);

            List<ActionProbabilityWrapper> rankedActions = new List<ActionProbabilityWrapper>
            {
                new ActionProbabilityWrapperForTest(0, 0.7f),
                new ActionProbabilityWrapperForTest(1, 0.2f),
                new ActionProbabilityWrapperForTest(2, 0.1f)
            };

            RankingResponseWrapper responseWrapper = new RankingResponseWrapperForTest(rankedActions);

            string eventId = "testEventId";

            PersonalizerRankResult rankResponse = RlObjectConverter.GenerateRankResult(originalActions, rankableActions, excludedActions, responseWrapper, eventId);
            Assert.AreEqual("action1", rankResponse.RewardActionId);
            Assert.AreEqual(originalActions.Count, rankResponse.Ranking.Count);
            for (int i = 0; i < rankResponse.Ranking.Count; i++)
            {
                Assert.AreEqual(originalActions[i].Id, rankResponse.Ranking[i].Id);
            }
        }

        [Test]
        public void GenerateMultiSlotRankResponseTest()
        {
            string eventId = "testEventId";
            List<PersonalizerRankableAction> actions = GetActions();

            List<ActionProbabilityWrapper> rankedActionsSlot1 = new List<ActionProbabilityWrapper>
            {
                new ActionProbabilityWrapperForTest(1, 0.8f),
                new ActionProbabilityWrapperForTest(2, 0.1f),
                new ActionProbabilityWrapperForTest(0, 0.1f)
            };

            List<ActionProbabilityWrapper> rankedActionsSlot2 = new List<ActionProbabilityWrapper>
            {
                new ActionProbabilityWrapperForTest(2, 0.9f),
                new ActionProbabilityWrapperForTest(0, 0.1f)
            };

            List<ActionProbabilityWrapper> rankedActionsSlot3 = new List<ActionProbabilityWrapper>
            {
                new ActionProbabilityWrapperForTest(0, 1.0f)
            };

            // setup response
            List<SlotRankingWrapper> rankedSlots = new List<SlotRankingWrapper>
            {
                new SlotRankingWrapperForTest(1, "slot1", rankedActionsSlot1),
                new SlotRankingWrapperForTest(2, "slot2", rankedActionsSlot2),
                new SlotRankingWrapperForTest(0, "slot3", rankedActionsSlot3)
            };

            MultiSlotResponseDetailedWrapper multiSlotResponseWrapper = new MultiSlotResponseWrapperForTest(rankedSlots);

            PersonalizerMultiSlotRankResult response = RlObjectConverter.GenerateMultiSlotRankResponse(actions, multiSlotResponseWrapper, eventId);

            int actionCount = rankedSlots.Count;
            Assert.AreEqual(actionCount, response.Slots.Count);
            for (int i = 0; i < actionCount; i++)
            {
                // Assert indices were assigned correctly
                var rankedAction = actions[(int)rankedSlots[i].ChosenAction];
                Assert.AreEqual(rankedAction.Id, response.Slots[i].RewardActionId);
            }

            Assert.AreEqual(eventId, response.EventId);
        }

        private List<PersonalizerRankableAction> GetActions()
        {
            var action0 = new PersonalizerRankableAction(
                    id: "action0",
                    features:
                    new List<object>() { new { SiteId = "testId0" } }
            );
            action0.Index = 0;
            var action1 = new PersonalizerRankableAction(
                    id: "action1",
                    features:
                    new List<object>() { new { SiteId = "testId1" } }
            );
            action1.Index = 1;
            var action2 = new PersonalizerRankableAction(
                    id: "action2",
                    features:
                    new List<object>() { new { SiteId = "testId2" } }
            );
            action2.Index = 2;
            var action3 = new PersonalizerRankableAction(
                    id: "action3",
                    features:
                    new List<object>() { new { SiteId = "testId3" } }
            );
            action3.Index = 3;
            List<PersonalizerRankableAction> actions = new List<PersonalizerRankableAction>();
            actions.Add(action0);
            actions.Add(action1);
            actions.Add(action2);
            actions.Add(action3);

            return actions;
        }
    }
}
