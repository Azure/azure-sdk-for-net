// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
            DecisionContext decisionContext = new DecisionContext(contextFeatures.Select(f => BinaryData.FromObjectAsJson(f)).ToList(), actions);
            Assert.Multiple(() =>
            {
                Assert.That(decisionContext.ContextFeatures, Has.Count.EqualTo(1));
                Assert.That(decisionContext.Documents, Has.Count.EqualTo(1));
            });
            Assert.That(decisionContext.Documents[0].ActionFeatures, Has.Count.EqualTo(2));

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
            #pragma warning disable SYSLIB0020
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                Converters =
                {
                     new JsonBinaryDataConverter(),
                },
                IgnoreNullValues = true
            };
            var contextJson = JsonSerializer.Serialize(decisionContext, jsonSerializerOptions);
#pragma warning restore SYSLIB0020
            Assert.That(contextJson, Is.EqualTo(expectedJson));
        }
    }
}
