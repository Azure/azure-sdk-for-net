// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

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
                    "\"i\":{\"constant\":1,\"id\":\"Person\"}," +
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
    }
}
