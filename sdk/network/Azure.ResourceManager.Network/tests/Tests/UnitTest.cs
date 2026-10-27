// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class UnitTest
    {
        // This is the test for fix of issue: https://github.com/Azure/azure-sdk-for-net/issues/46767
        [Test]
        public void DeserializeChangeNumber()
        {
            using var sr = new StreamReader(Path.Combine("TestData", "ServiceTags.json"));
            using var jsonContent = JsonDocument.Parse(sr.BaseStream);
            var data = AzureFirewallIPGroups.DeserializeAzureFirewallIPGroups(jsonContent.RootElement, ModelReaderWriterOptions.Json);
            Assert.NotNull(data.ChangeNumber);
        }

        // Regression test for ManagedRuleSetRuleGroup deserialization with mixed string/number rule IDs
        [Test]
        public void DeserializeManagedRuleSetRuleGroupWithMixedRuleTypes()
        {
            using var sr = new StreamReader(Path.Combine("TestData", "ManagedRuleSetRuleGroup.json"));
            using var jsonContent = JsonDocument.Parse(sr.BaseStream);
            var data = ManagedRuleSetRuleGroup.DeserializeManagedRuleSetRuleGroup(jsonContent.RootElement, ModelReaderWriterOptions.Json);

            Assert.NotNull(data.Rules);
            Assert.AreEqual(6, data.Rules.Count);

            // Verify that both string and numeric rule IDs are properly converted to strings
            Assert.AreEqual("920100", data.Rules[0]); // Originally string
            Assert.AreEqual("920110", data.Rules[1]); // Originally number
            Assert.AreEqual("920120", data.Rules[2]); // Originally string
            Assert.AreEqual("920130", data.Rules[3]); // Originally number
            Assert.AreEqual("920140", data.Rules[4]); // Originally string
            Assert.AreEqual("920150", data.Rules[5]); // Originally number
        }

        [TestCase("[800116]", new[] { "800116" })]
        [TestCase("[\"800116\"]", new[] { "800116" })]
        [TestCase("[800116,\"920100\",9223372036854775808]", new[] { "800116", "920100", "9223372036854775808" })]
        [TestCase("[null,800116,\"920100\"]", new string[] { null, "800116", "920100" })]
        [TestCase("[]", new string[0])]
        [TestCase("null", new string[0])]
        [TestCase(null, new string[0])]
        public void ReadManagedRuleSetRuleGroup(string rulesJson, string[] expectedRules)
        {
            string rulesProperty = rulesJson == null ? string.Empty : ",\"rules\":" + rulesJson;
            var json = BinaryData.FromString("{\"ruleGroupName\":\"Known-CVEs\"" + rulesProperty + "}");

            foreach (var options in new[] { ModelReaderWriterOptions.Json, new ModelReaderWriterOptions("W") })
            {
                var data = ModelReaderWriter.Read<ManagedRuleSetRuleGroup>(json, options, AzureResourceManagerNetworkContext.Default);

                Assert.That(data.RuleGroupName, Is.EqualTo("Known-CVEs"));
                Assert.That(data.Rules, Is.EqualTo(expectedRules));
            }
        }

        [TestCase("[true]")]
        [TestCase("[{}]")]
        [TestCase("[[]]")]
        public void DeserializeManagedRuleSetRuleGroupRejectsInvalidRuleTypes(string rulesJson)
        {
            using var document = JsonDocument.Parse("{\"ruleGroupName\":\"Known-CVEs\",\"rules\":" + rulesJson + "}");

            Assert.Throws<InvalidOperationException>(() =>
                ManagedRuleSetRuleGroup.DeserializeManagedRuleSetRuleGroup(document.RootElement, ModelReaderWriterOptions.Json));
        }

        [Test]
        public void ManagedRuleSetRuleGroupPreservesUnknownProperties()
        {
            var json = BinaryData.FromString("{\"ruleGroupName\":\"Known-CVEs\",\"rules\":[800116],\"futureProperty\":{\"value\":1}}");
            var data = ModelReaderWriter.Read<ManagedRuleSetRuleGroup>(json, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default);

            using var document = JsonDocument.Parse(ModelReaderWriter.Write(data, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default));

            Assert.That(document.RootElement.GetProperty("rules")[0].GetString(), Is.EqualTo("800116"));
            Assert.That(document.RootElement.GetProperty("futureProperty").GetProperty("value").GetInt32(), Is.EqualTo(1));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task GetWebApplicationFirewallPolicyWithNumericDisabledRules(bool async)
        {
            const string subscriptionId = "00000000-0000-0000-0000-000000000001";
            var resourceId = WebApplicationFirewallPolicyResource.CreateResourceIdentifier(subscriptionId, "test-rg", "test-policy");
            string json = """
                {
                  "id": "RESOURCE_ID",
                  "name": "test-policy",
                  "type": "Microsoft.Network/ApplicationGatewayWebApplicationFirewallPolicies",
                  "location": "eastus",
                  "properties": {
                    "managedRules": {
                      "managedRuleSets": [
                        {
                          "ruleSetType": "OWASP",
                          "ruleSetVersion": "3.2",
                          "ruleGroupOverrides": [],
                          "computedDisabledRules": [
                            {
                              "ruleGroupName": "Known-CVEs",
                              "rules": [800116]
                            }
                          ]
                        }
                      ]
                    }
                  }
                }
                """.Replace("RESOURCE_ID", resourceId.ToString());
            var transport = new MockTransport(new MockResponse(200).SetContent(json));
            var client = new ArmClient(new MockCredential(), subscriptionId, new ArmClientOptions { Transport = transport });
            var resource = client.GetWebApplicationFirewallPolicyResource(resourceId);

            var response = async ? await resource.GetAsync() : resource.Get();

            var ruleGroup = response.Value.Data.ManagedRules.ManagedRuleSets[0].ComputedDisabledRules[0];
            Assert.That(ruleGroup.RuleGroupName, Is.EqualTo("Known-CVEs"));
            Assert.That(ruleGroup.Rules, Is.EqualTo(new[] { "800116" }));
        }
    }
}
