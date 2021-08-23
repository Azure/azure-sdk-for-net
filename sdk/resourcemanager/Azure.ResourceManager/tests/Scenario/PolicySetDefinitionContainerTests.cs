// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
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
    public class PolicySetDefinitionContainerTests : ResourceManagerTestBase
    {
        public PolicySetDefinitionContainerTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtSubscription()
        {
            string policyDefinitionName = Recording.GenerateAssetName("testPolDef-1-");
            PolicyDefinitionData policyDefinitionData = CreatePolicyDefinitionData(policyDefinitionName);
            PolicyDefinition policyDefinition = (await Client.DefaultSubscription.GetPolicyDefinitions().CreateOrUpdateAsync(policyDefinitionName, policyDefinitionData)).Value;
            string policySetDefinitionName = Recording.GenerateAssetName("polSetDef-C-");
            PolicySetDefinitionData policySetDefinitionData = CreatePolicySetDefinitionData(policySetDefinitionName, policyDefinition);
            PolicySetDefinition policySetDefinition = (await Client.DefaultSubscription.GetPolicySetDefinitions().CreateOrUpdateAsync(policySetDefinitionName, policySetDefinitionData)).Value;
            Assert.AreEqual(policySetDefinitionName, policySetDefinition.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetPolicySetDefinitions().CreateOrUpdateAsync(null, policySetDefinitionData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetPolicySetDefinitions().CreateOrUpdateAsync(policySetDefinitionName, null));
            await policySetDefinition.DeleteAsync();
            await policyDefinition.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtMgmtGroup()
        {
            //If you want to change this test, ensure you have the right access to management group, otherwise the test will fail and unable to re-record.
            string mgmtGroupName = Recording.GenerateAssetName("testMgmtGroup-");
            ManagementGroup mgmtGroup = await Client.GetManagementGroups().CreateOrUpdateAsync(mgmtGroupName, new CreateManagementGroupOptions());
            string policyDefinitionName = Recording.GenerateAssetName("testPolDef-2-");
            PolicyDefinitionData policyDefinitionData = CreatePolicyDefinitionData(policyDefinitionName);
            PolicyDefinition policyDefinition = (await mgmtGroup.GetPolicyDefinitions().CreateOrUpdateAsync(policyDefinitionName, policyDefinitionData)).Value;
            string policySetDefinitionName = Recording.GenerateAssetName("polSetDef-C-");
            PolicySetDefinitionData policySetDefinitionData = CreatePolicySetDefinitionData(policySetDefinitionName, policyDefinition);
            PolicySetDefinition policySetDefinition = (await mgmtGroup.GetPolicySetDefinitions().CreateOrUpdateAsync(policySetDefinitionName, policySetDefinitionData)).Value;
            Assert.AreEqual(policySetDefinitionName, policySetDefinition.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetPolicySetDefinitions().CreateOrUpdateAsync(null, policySetDefinitionData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetPolicySetDefinitions().CreateOrUpdateAsync(policySetDefinitionName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            string policyDefinitionName = Recording.GenerateAssetName("testPolDef-3-");
            PolicyDefinitionData policyDefinitionData = CreatePolicyDefinitionData(policyDefinitionName);
            PolicyDefinition policyDefinition = (await Client.DefaultSubscription.GetPolicyDefinitions().CreateOrUpdateAsync(policyDefinitionName, policyDefinitionData)).Value;
            string policySetDefinitionName = Recording.GenerateAssetName("polSetDef-L-");
            PolicySetDefinitionData policySetDefinitionData = CreatePolicySetDefinitionData(policySetDefinitionName, policyDefinition);
            PolicySetDefinition policySetDefinition = (await Client.DefaultSubscription.GetPolicySetDefinitions().CreateOrUpdateAsync(policySetDefinitionName, policySetDefinitionData)).Value;
            int count = 0;
            string policyType = "Custom";
            string filter = $"policyType eq '{policyType}'";
            await foreach (var tempPolicySetDefinition in Client.DefaultSubscription.GetPolicySetDefinitions().GetAllAsync(filter))
            {
                count++;
            }
            Assert.AreEqual(count, 1);
            await policySetDefinition.DeleteAsync();
            await policyDefinition.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task ListByTenant()
        {
            await foreach (var tempTenant in Client.GetTenants().GetAllAsync())
            {
                await foreach (var builtInPolicyDefinition in tempTenant.GetAllBuiltInPolicySetDefinitionsAsync())
                {
                    Assert.AreEqual(builtInPolicyDefinition.Data.PolicyType, PolicyType.BuiltIn);
                }
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string policyDefinitionName = Recording.GenerateAssetName("tesPolDef-4-");
            PolicyDefinitionData policyDefinitionData = CreatePolicyDefinitionData(policyDefinitionName);
            PolicyDefinition policyDefinition = (await Client.DefaultSubscription.GetPolicyDefinitions().CreateOrUpdateAsync(policyDefinitionName, policyDefinitionData)).Value;
            string policySetDefinitionName = Recording.GenerateAssetName("polSetDef-G-");
            PolicySetDefinitionData policySetDefinitionData = CreatePolicySetDefinitionData(policySetDefinitionName, policyDefinition);
            PolicySetDefinition policySetDefinition = (await Client.DefaultSubscription.GetPolicySetDefinitions().CreateOrUpdateAsync(policySetDefinitionName, policySetDefinitionData)).Value;
            PolicySetDefinition getPolicySetDefinition = await Client.DefaultSubscription.GetPolicySetDefinitions().GetAsync(policySetDefinitionName);
            AssertValidPolicySetDefinition(policySetDefinition, getPolicySetDefinition);
            await policySetDefinition.DeleteAsync();
            await policyDefinition.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task GetByTenant()
        {
            await foreach (var tempTenant in Client.GetTenants().GetAllAsync())
            {
                PolicySetDefinition getBuiltInPolicyDefinition = await tempTenant.GetBuiltInPolicySetDefinitionAsync("75714362-cae7-409e-9b99-a8e5075b7fad");
                Assert.AreEqual(getBuiltInPolicyDefinition.Data.DisplayName, "Enable Azure Monitor for Virtual Machine Scale Sets");
            }
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
        private static PolicySetDefinitionData CreatePolicySetDefinitionData(string displayName, PolicyDefinition policyDefinition) => new PolicySetDefinitionData
        {
            DisplayName = $"AutoTest ${displayName}",
            PolicyDefinitions = { new PolicyDefinitionReference(policyDefinition.Id) }
        };
        private static void AssertValidPolicySetDefinition(PolicySetDefinition model, PolicySetDefinition getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.PolicyType, getResult.Data.PolicyType);
            Assert.AreEqual(model.Data.DisplayName, getResult.Data.DisplayName);
            Assert.AreEqual(model.Data.Description, getResult.Data.Description);
            Assert.AreEqual(model.Data.Metadata, getResult.Data.Metadata);
            if (model.Data.Parameters != null || getResult.Data.Parameters != null)
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
                    if (kvp.Value.Metadata != null || getParameterDefinitionsValue.Metadata != null)
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
            Assert.AreEqual(model.Data.PolicyDefinitions.Count, getResult.Data.PolicyDefinitions.Count);
            foreach (var expectedDefinition in model.Data.PolicyDefinitions)
            {
                var resultDefinitions = getResult.Data.PolicyDefinitions.Where(def => def.PolicyDefinitionId.Equals(expectedDefinition.PolicyDefinitionId));
                Assert.True(resultDefinitions.Count() > 0);
                var resultDefinition = resultDefinitions.Single(def => expectedDefinition.PolicyDefinitionReferenceId == null || expectedDefinition.PolicyDefinitionReferenceId.Equals(def.PolicyDefinitionReferenceId, StringComparison.Ordinal));
                if (expectedDefinition.GroupNames != null)
                {
                    Assert.AreEqual(expectedDefinition.GroupNames.Count(), resultDefinition.GroupNames.Count());
                    Assert.AreEqual(expectedDefinition.GroupNames.Count(), expectedDefinition.GroupNames.Intersect(resultDefinition.GroupNames).Count());
                }
                else
                {
                    Assert.Null(resultDefinition.GroupNames);
                }
            }

            if (model.Data.PolicyDefinitionGroups != null)
            {
                foreach (var group in model.Data.PolicyDefinitionGroups)
                {
                    Assert.AreEqual(1, getResult.Data.PolicyDefinitionGroups.Count(resultGroup => resultGroup.Name.Equals(group.Name, StringComparison.Ordinal)));
                }
            }
            else
            {
                Assert.Null(getResult.Data.PolicyDefinitionGroups);
            }
        }
    }
}
