// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Management.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class PolicyDefinitionContainerTests : ResourceManagerTestBase
    {
        public PolicyDefinitionContainerTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtSubscription()
        {
            string policyDefinitionName = Recording.GenerateAssetName("polDef-C-");
            PolicyDefinitionData policyDefinitionData = CreatePolicyDefinitionData(policyDefinitionName);
            PolicyDefinition policyDefinition = await Client.DefaultSubscription.GetPolicyDefinitions().CreateOrUpdateAsync(policyDefinitionName, policyDefinitionData);
            Assert.AreEqual(policyDefinitionName, policyDefinition.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetPolicyDefinitions().CreateOrUpdateAsync(null, policyDefinitionData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetPolicyDefinitions().CreateOrUpdateAsync(policyDefinitionName, null));
            await policyDefinition.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtMgmtGroup()
        {
            //If you want to change this test, ensure you have the right access to management group, otherwise the test will fail and unable to re-record.
            string mgmtGroupName = Recording.GenerateAssetName("testMgmtGroup-");
            ManagementGroup mgmtGroup = await Client.GetManagementGroups().CreateOrUpdateAsync(mgmtGroupName, new CreateManagementGroupOptions());
            string policyDefinitionName = Recording.GenerateAssetName("polDef-C-");
            PolicyDefinitionData policyDefinitionData = CreatePolicyDefinitionData(policyDefinitionName);
            PolicyDefinition policyDefinition = await mgmtGroup.GetPolicyDefinitions().CreateOrUpdateAsync(policyDefinitionName, policyDefinitionData);
            Assert.AreEqual(policyDefinitionName, policyDefinition.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetPolicyDefinitions().CreateOrUpdateAsync(null, policyDefinitionData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetPolicyDefinitions().CreateOrUpdateAsync(policyDefinitionName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            string policyDefinitionName = Recording.GenerateAssetName("polDef-L-");
            PolicyDefinitionData policyDefinitionData = CreatePolicyDefinitionData(policyDefinitionName);
            PolicyDefinition policyDefinition = await Client.DefaultSubscription.GetPolicyDefinitions().CreateOrUpdateAsync(policyDefinitionName, policyDefinitionData);
            int count = 0;
            string policyType = "Custom";
            string filter = $"policyType eq '{policyType}'";
            await foreach (var tempPolicyDefinition in Client.DefaultSubscription.GetPolicyDefinitions().GetAllAsync(filter))
            {
                count++;
            }
            Assert.AreEqual(count, 1);
            await policyDefinition.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string policyDefinitionName = Recording.GenerateAssetName("polDef-G-");
            PolicyDefinitionData policyDefinitionData = CreatePolicyDefinitionData(policyDefinitionName);
            PolicyDefinition policyDefinition = await Client.DefaultSubscription.GetPolicyDefinitions().CreateOrUpdateAsync(policyDefinitionName, policyDefinitionData);
            PolicyDefinition getPolicyDefinition = await Client.DefaultSubscription.GetPolicyDefinitions().GetAsync(policyDefinitionName);
            AssertValidPolicyDefinition(policyDefinition, getPolicyDefinition);
            await policyDefinition.DeleteAsync();
        }
        private static PolicyDefinitionData CreatePolicyDefinitionData(string displayName) => new PolicyDefinitionData
        {
            DisplayName = $"AutoTest ${displayName}",
            PolicyRule = new Dictionary<string, object>
                {
                    {
                        "if", new Dictionary<string, object>
                        {
                            { "source", "action" },
                            { "equals", "ResourceProviderTestHost/TestResourceType/TestResourceTypeNestedOne/write"}
                        }
                    },
                    {
                        "then", new Dictionary<string, object>
                        {
                            { "effect", "deny" }
                        }
                    }
                }
        };
        private static void AssertValidPolicyDefinition(PolicyDefinition model, PolicyDefinition getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.PolicyType, getResult.Data.PolicyType);
            Assert.AreEqual(model.Data.Mode, getResult.Data.Mode);
            Assert.AreEqual(model.Data.DisplayName, getResult.Data.DisplayName);
            Assert.AreEqual(model.Data.Description, getResult.Data.Description);
            Assert.AreEqual(model.Data.PolicyRule, getResult.Data.PolicyRule);
            Assert.AreEqual(model.Data.Metadata, getResult.Data.Metadata);
            if(model.Data.Parameters != null || getResult.Data.Parameters != null)
            {
                Assert.NotNull(model.Data.Parameters);
                Assert.NotNull(getResult.Data.Parameters);
                Assert.AreEqual(model.Data.Parameters.Count, getResult.Data.Parameters.Count);
                foreach (KeyValuePair<string, ParameterDefinitionsValue> kvp in model.Data.Parameters)
                {
                    Assert.AreEqual(getResult.Data.Parameters.ContainsKey(kvp.Key), true);
                    ParameterDefinitionsValue getParameterDefinitionsValue = getResult.Data.Parameters[kvp.Key];
                    Assert.AreEqual(kvp.Value.Type, getParameterDefinitionsValue.Type);
                    if (kvp.Value.AllowedValues != null || getParameterDefinitionsValue.AllowedValues != null)
                    {
                        Assert.NotNull(kvp.Value.AllowedValues);
                        Assert.NotNull(getParameterDefinitionsValue.AllowedValues);
                        Assert.AreEqual(kvp.Value.AllowedValues.Count, getParameterDefinitionsValue.AllowedValues.Count);
                        for (int i = 0; i < kvp.Value.AllowedValues.Count; ++i)
                        {
                            Assert.AreEqual(kvp.Value.AllowedValues[i], getParameterDefinitionsValue.AllowedValues[i]);
                        }
                    }
                    Assert.AreEqual(kvp.Value.DefaultValue, getParameterDefinitionsValue.DefaultValue);
                    if(kvp.Value.Metadata != null || getParameterDefinitionsValue.Metadata != null)
                    {
                        Assert.NotNull(kvp.Value.Metadata);
                        Assert.NotNull(getParameterDefinitionsValue.Metadata);
                        Assert.AreEqual(kvp.Value.Metadata.DisplayName, getParameterDefinitionsValue.Metadata.DisplayName);
                        Assert.AreEqual(kvp.Value.Metadata.Description, getParameterDefinitionsValue.Metadata.Description);
                        Assert.AreEqual(kvp.Value.Metadata.StrongType, getParameterDefinitionsValue.Metadata.StrongType);
                        Assert.AreEqual(kvp.Value.Metadata.AssignPermissions, getParameterDefinitionsValue.Metadata.AssignPermissions);
                        Assert.AreEqual(kvp.Value.Metadata.AdditionalProperties, getParameterDefinitionsValue.Metadata.AdditionalProperties);
                    }
                }
            }
        }
    }
}
