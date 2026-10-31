// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Cdn.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests.Unit
{
    public class FrontDoorRuleSetDataSerializationTests
    {
        [Test]
        public void BatchModeRuleSetSerializesRequestBody()
        {
            var data = new FrontDoorRuleSetData
            {
                IsBatchMode = true,
            };
            var rule = new BatchRuleProperties("rule1")
            {
                Order = 1,
                MatchProcessingBehavior = MatchProcessingBehavior.Continue,
            };
            rule.Actions.Add(new DeliveryRuleResponseHeaderAction(
                new HeaderActionProperties(HeaderAction.Overwrite, "X-Test") { Value = "value" }));
            data.Rules.Add(rule);

            using JsonDocument doc = JsonDocument.Parse(ModelReaderWriter.Write(data, ModelReaderWriterOptions.Json).ToString());
            JsonElement properties = doc.RootElement.GetProperty("properties");

            Assert.IsTrue(properties.GetProperty("batchMode").GetBoolean());
            JsonElement rules = properties.GetProperty("rules");
            Assert.AreEqual(1, rules.GetArrayLength());
            JsonElement serializedRule = rules[0];
            Assert.AreEqual("rule1", serializedRule.GetProperty("ruleName").GetString());
            Assert.AreEqual(1, serializedRule.GetProperty("order").GetInt32());
            Assert.AreEqual("Continue", serializedRule.GetProperty("matchProcessingBehavior").GetString());
            JsonElement action = serializedRule.GetProperty("actions")[0];
            Assert.AreEqual("ModifyResponseHeader", action.GetProperty("name").GetString());
            Assert.AreEqual("X-Test", action.GetProperty("parameters").GetProperty("headerName").GetString());
        }

        [Test]
        public void BatchModeRuleSetDeserializesResponseBody()
        {
            const string json = @"{
                ""id"": ""/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Cdn/profiles/profile/ruleSets/ruleSet1"",
                ""name"": ""ruleSet1"",
                ""type"": ""Microsoft.Cdn/profiles/ruleSets"",
                ""properties"": {
                    ""batchMode"": true,
                    ""rules"": [
                        {
                            ""ruleName"": ""rule1"",
                            ""ruleSetName"": ""ruleSet1"",
                            ""order"": 1,
                            ""conditions"": [],
                            ""actions"": [
                                {
                                    ""name"": ""ModifyResponseHeader"",
                                    ""parameters"": {
                                        ""typeName"": ""DeliveryRuleHeaderActionParameters"",
                                        ""headerAction"": ""Overwrite"",
                                        ""headerName"": ""X-Test"",
                                        ""value"": ""value""
                                    }
                                }
                            ],
                            ""matchProcessingBehavior"": ""Stop""
                        }
                    ]
                }
            }";

            FrontDoorRuleSetData data = ModelReaderWriter.Read<FrontDoorRuleSetData>(BinaryData.FromString(json), ModelReaderWriterOptions.Json);

            Assert.IsTrue(data.IsBatchMode);
            Assert.AreEqual(1, data.Rules.Count);
            BatchRuleProperties rule = data.Rules[0];
            Assert.AreEqual("rule1", rule.RuleName);
            Assert.AreEqual("ruleSet1", rule.RuleSetName);
            Assert.AreEqual(1, rule.Order);
            Assert.AreEqual(MatchProcessingBehavior.Stop, rule.MatchProcessingBehavior);
            var action = rule.Actions[0] as DeliveryRuleResponseHeaderAction;
            Assert.IsNotNull(action);
            Assert.AreEqual(HeaderAction.Overwrite, action.Properties.HeaderAction);
            Assert.AreEqual("X-Test", action.Properties.HeaderName);
            Assert.AreEqual("value", action.Properties.Value);
        }
    }
}
