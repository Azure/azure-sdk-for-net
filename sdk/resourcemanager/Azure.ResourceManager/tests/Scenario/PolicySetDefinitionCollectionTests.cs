// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.ManagementGroups.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class PolicySetDefinitionCollectionTests : ResourceManagerTestBase
    {
        public PolicySetDefinitionCollectionTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtSubscription()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string policyDefinitionName = Recording.GenerateAssetName("polDef-");
            SubscriptionPolicyDefinitionResource policyDefinition = await CreatePolicyDefinitionAtSubscription(subscription, policyDefinitionName);
            string policySetDefinitionName = Recording.GenerateAssetName("polSetDef-");
            SubscriptionPolicySetDefinitionResource policySetDefinition = await CreatePolicySetDefinitionAtSubscription(subscription, policyDefinition, policySetDefinitionName);
            Assert.AreEqual(policySetDefinitionName, policySetDefinition.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetSubscriptionPolicySetDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, null, policySetDefinition.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetSubscriptionPolicySetDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, policySetDefinitionName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtMgmtGroup()
        {
            //This test uses a pre-created management group.
            ManagementGroupResource mgmtGroup = await GetCreatedManagementGroup();
            string policyDefinitionName = Recording.GenerateAssetName("polDef-");
            ManagementGroupPolicyDefinitionResource policyDefinition = await CreatePolicyDefinitionAtMgmtGroup(mgmtGroup, policyDefinitionName);
            string policySetDefinitionName = Recording.GenerateAssetName("polSetDef-");
            ManagementGroupPolicySetDefinitionResource policySetDefinition = await CreatePolicySetDefinitionAtMgmtGroup(mgmtGroup, policyDefinition, policySetDefinitionName);
            Assert.AreEqual(policySetDefinitionName, policySetDefinition.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetManagementGroupPolicySetDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, null, policySetDefinition.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetManagementGroupPolicySetDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, policySetDefinitionName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string policyDefinitionName = Recording.GenerateAssetName("polDef-");
            SubscriptionPolicyDefinitionResource policyDefinition = await CreatePolicyDefinitionAtSubscription(subscription, policyDefinitionName);
            string policySetDefinitionName = Recording.GenerateAssetName("polSetDef-");
            SubscriptionPolicySetDefinitionResource policySetDefinition = await CreatePolicySetDefinitionAtSubscription(subscription, policyDefinition, policySetDefinitionName);
            int count = 0;
            string policyType = "Custom";
            string filter = $"policyType eq '{policyType}'";
            await foreach (var tempPolicySetDefinition in subscription.GetSubscriptionPolicySetDefinitions().GetAllAsync(filter))
            {
                count++;
            }
            Assert.Greater(count, 0);
        }

        [TestCase]
        [RecordedTest]
        [LiveOnly(Reason = "Test regularly times out in playback mode.")]
        public async Task ListByTenant()
        {
            await foreach (var tenant in Client.GetTenants().GetAllAsync())
            {
                await foreach (var builtInPolicySetDefinition in tenant.GetTenantPolicySetDefinitions().GetAllAsync())
                {
                    Assert.AreEqual(builtInPolicySetDefinition.Data.PolicyType, PolicyType.BuiltIn);
                }
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string policyDefinitionName = Recording.GenerateAssetName("polDef-");
            SubscriptionPolicyDefinitionResource policyDefinition = await CreatePolicyDefinitionAtSubscription(subscription, policyDefinitionName);
            string policySetDefinitionName = Recording.GenerateAssetName("polSetDef-");
            SubscriptionPolicySetDefinitionResource policySetDefinition = await CreatePolicySetDefinitionAtSubscription(subscription, policyDefinition, policySetDefinitionName);
            SubscriptionPolicySetDefinitionResource getPolicySetDefinition = await subscription.GetSubscriptionPolicySetDefinitions().GetAsync(policySetDefinitionName);
            AssertValidPolicySetDefinition(policySetDefinition, getPolicySetDefinition);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetByTenant()
        {
            await foreach (var tenant in Client.GetTenants().GetAllAsync())
            {
                TenantPolicySetDefinitionResource getBuiltInPolicySetDefinition = await tenant.GetTenantPolicySetDefinitions().GetAsync("75714362-cae7-409e-9b99-a8e5075b7fad");
                Assert.AreEqual(getBuiltInPolicySetDefinition.Data.DisplayName, "Enable Azure Monitor for Virtual Machine Scale Sets");
            }
        }

        private static void AssertValidPolicySetDefinition(SubscriptionPolicySetDefinitionResource model, SubscriptionPolicySetDefinitionResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.PolicyType, getResult.Data.PolicyType);
            Assert.AreEqual(model.Data.DisplayName, getResult.Data.DisplayName);
            Assert.AreEqual(model.Data.Description, getResult.Data.Description);
            Assert.AreEqual(model.Data.Metadata.ToArray(), getResult.Data.Metadata.ToArray());
            if (model.Data.Parameters != null || getResult.Data.Parameters != null)
            {
                Assert.NotNull(model.Data.Parameters);
                Assert.NotNull(getResult.Data.Parameters);
                Assert.AreEqual(model.Data.Parameters.Count, getResult.Data.Parameters.Count);
                foreach (KeyValuePair<string, ArmPolicyParameter> kvp in model.Data.Parameters)
                {
                    Assert.AreEqual(getResult.Data.Parameters.ContainsKey(kvp.Key), true);
                    ArmPolicyParameter getParameterDefinitionsValue = getResult.Data.Parameters[kvp.Key];
                    Assert.AreEqual(kvp.Value.ParameterType, getParameterDefinitionsValue.ParameterType);
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
