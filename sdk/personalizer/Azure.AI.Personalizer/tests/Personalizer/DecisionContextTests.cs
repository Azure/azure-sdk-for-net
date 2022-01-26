// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class DecisionContextTests
    {
        [Test]
        public void DecisionContextConstructorTest()
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
            DecisionContext decisionContext = new DecisionContext(contextFeatures, actions);
            Assert.AreEqual(decisionContext.ContextFeatures.Count, 1);
            Assert.IsTrue(decisionContext.ContextFeatures[0].Equals("{\"Features\":{\"day\":\"Monday\",\"time\":\"morning\",\"weather\":\"sunny\"}}"));
            Assert.AreEqual(decisionContext.Documents.Length, 1);
            Assert.AreEqual(decisionContext.Documents[0].JSON.Count, 2);
            Assert.IsTrue(decisionContext.Documents[0].JSON[0].Equals("{\"videoType\":\"documentary\",\"videoLength\":35,\"director\":\"CarlSagan\"}"));
            Assert.IsTrue(decisionContext.Documents[0].JSON[1].Equals("{\"mostWatchedByAge\":\"30-35\"}"));
        }
    }
}
