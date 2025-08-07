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
            Assert.NotNull(data.ChangeNumber);
        }

        // Regression test for ManagedRuleSetRuleGroup deserialization with mixed string/number rule IDs
        [Test]
        public void DeserializeManagedRuleSetRuleGroupWithMixedRuleTypes()
        {
            using var sr = new StreamReader(Path.Combine("TestData", "ManagedRuleSetRuleGroup.json"));
            using var jsonContent = JsonDocument.Parse(sr.BaseStream);
            var data = ManagedRuleSetRuleGroup.DeserializeManagedRuleSetRuleGroup(jsonContent.RootElement);

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
    }
}
