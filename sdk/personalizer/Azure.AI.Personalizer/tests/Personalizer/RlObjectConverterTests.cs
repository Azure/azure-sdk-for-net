// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class RlObjectConverterTests
    {
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
    }
}
