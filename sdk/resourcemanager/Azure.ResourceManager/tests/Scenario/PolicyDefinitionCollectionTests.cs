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
    public class PolicyDefinitionCollectionTests : ResourceManagerTestBase
    {
        public PolicyDefinitionCollectionTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtSubscription()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string policyDefinitionName = Recording.GenerateAssetName("polDef-");
            SubscriptionPolicyDefinition policyDefinition = await CreatePolicyDefinitionAtSubscription(subscription, policyDefinitionName);
            Assert.AreEqual(policyDefinitionName, policyDefinition.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetSubscriptionPolicyDefinitions().CreateOrUpdateAsync(true, null, policyDefinition.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetSubscriptionPolicyDefinitions().CreateOrUpdateAsync(true, policyDefinitionName, null));
            await policyDefinition.DeleteAsync(true);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtMgmtGroup()
        {
            //This test uses a pre-created management group.
            ManagementGroup mgmtGroup = await GetCreatedManagementGroup();
            string policyDefinitionName = Recording.GenerateAssetName("polDef-");
            ManagementGroupPolicyDefinition policyDefinition = await CreatePolicyDefinitionAtMgmtGroup(mgmtGroup, policyDefinitionName);
            Assert.AreEqual(policyDefinitionName, policyDefinition.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetManagementGroupPolicyDefinitions().CreateOrUpdateAsync(true, null, policyDefinition.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetManagementGroupPolicyDefinitions().CreateOrUpdateAsync(true, policyDefinitionName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string policyDefinitionName = Recording.GenerateAssetName("polDef-");
            SubscriptionPolicyDefinition policyDefinition = await CreatePolicyDefinitionAtSubscription(subscription, policyDefinitionName);
            int count = 0;
            await foreach (var tempPolicyDefinition in subscription.GetSubscriptionPolicyDefinitions().GetAllAsync())
            {
                count++;
            }
            Assert.Greater(count, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListByTenant()
        {
            string filter = "category eq 'Compute'";
            await foreach (var tenant in Client.GetTenants().GetAllAsync())
            {
                await foreach (var builtInPolicyDefinition in tenant.GetTenantPolicyDefinitions().GetAllAsync(filter))
                {
                    Assert.AreEqual(builtInPolicyDefinition.Data.PolicyType, PolicyType.BuiltIn);
                }
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string policyDefinitionName = Recording.GenerateAssetName("polDef-");
            SubscriptionPolicyDefinition policyDefinition = await CreatePolicyDefinitionAtSubscription(subscription, policyDefinitionName);
            SubscriptionPolicyDefinition getPolicyDefinition = await subscription.GetSubscriptionPolicyDefinitions().GetAsync(policyDefinitionName);
            AssertValidPolicyDefinition(policyDefinition, getPolicyDefinition);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetByTenant()
        {
            await foreach (var tenant in Client.GetTenants().GetAllAsync())
            {
                TenantPolicyDefinition getBuiltInPolicyDefinition = await tenant.GetTenantPolicyDefinitions().GetAsync("04d53d87-841c-4f23-8a5b-21564380b55e");
                Assert.AreEqual(getBuiltInPolicyDefinition.Data.DisplayName, "Deploy Diagnostic Settings for Service Bus to Log Analytics workspace");
            }
        }

        private static void AssertValidPolicyDefinition(SubscriptionPolicyDefinition model, SubscriptionPolicyDefinition getResult)
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
