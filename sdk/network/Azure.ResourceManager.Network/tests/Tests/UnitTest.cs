// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json;
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
            var data = AzureFirewallIPGroups.DeserializeAzureFirewallIPGroups(jsonContent.RootElement);
            Assert.That(data.ChangeNumber, Is.Not.Null);
        }

        // Regression test for ManagedRuleSetRuleGroup deserialization with mixed string/number rule IDs
        [Test]
        public void DeserializeManagedRuleSetRuleGroupWithMixedRuleTypes()
        {
            using var sr = new StreamReader(Path.Combine("TestData", "ManagedRuleSetRuleGroup.json"));
            using var jsonContent = JsonDocument.Parse(sr.BaseStream);
            var data = ManagedRuleSetRuleGroup.DeserializeManagedRuleSetRuleGroup(jsonContent.RootElement);

            Assert.That(data.Rules, Is.Not.Null);
            Assert.That(data.Rules, Has.Count.EqualTo(6));

            Assert.Multiple(() =>
            {
                // Verify that both string and numeric rule IDs are properly converted to strings
                Assert.That(data.Rules[0], Is.EqualTo("920100")); // Originally string
                Assert.That(data.Rules[1], Is.EqualTo("920110")); // Originally number
                Assert.That(data.Rules[2], Is.EqualTo("920120")); // Originally string
                Assert.That(data.Rules[3], Is.EqualTo("920130")); // Originally number
                Assert.That(data.Rules[4], Is.EqualTo("920140")); // Originally string
                Assert.That(data.Rules[5], Is.EqualTo("920150")); // Originally number
            });
        }
    }
}
