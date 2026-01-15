// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string policyDefinitionName = Recording.GenerateAssetName("polDef-");
            SubscriptionPolicyDefinitionResource policyDefinition = await CreatePolicyDefinitionAtSubscription(subscription, policyDefinitionName);
            Assert.That(policyDefinition.Data.Name, Is.EqualTo(policyDefinitionName));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetSubscriptionPolicyDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, null, policyDefinition.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetSubscriptionPolicyDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, policyDefinitionName, null));
            await policyDefinition.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtMgmtGroup()
        {
            //This test uses a pre-created management group.
            ManagementGroupResource mgmtGroup = await GetCreatedManagementGroup();
            string policyDefinitionName = Recording.GenerateAssetName("polDef-");
            ManagementGroupPolicyDefinitionResource policyDefinition = await CreatePolicyDefinitionAtMgmtGroup(mgmtGroup, policyDefinitionName);
            Assert.That(policyDefinition.Data.Name, Is.EqualTo(policyDefinitionName));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetManagementGroupPolicyDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, null, policyDefinition.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetManagementGroupPolicyDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, policyDefinitionName, null));
        }

        [TestCase]
        [RecordedTest]
        [LiveOnly]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string policyDefinitionName = Recording.GenerateAssetName("polDef-");
            SubscriptionPolicyDefinitionResource policyDefinition = await CreatePolicyDefinitionAtSubscription(subscription, policyDefinitionName);
            int count = 0;
            await foreach (var tempPolicyDefinition in subscription.GetSubscriptionPolicyDefinitions().GetAllAsync())
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
            string filter = "category eq 'Compute'";
            await foreach (var tenant in Client.GetTenants().GetAllAsync())
            {
                await foreach (var builtInPolicyDefinition in tenant.GetTenantPolicyDefinitions().GetAllAsync(filter))
                {
                    Assert.That(PolicyType.BuiltIn, Is.EqualTo(builtInPolicyDefinition.Data.PolicyType));
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
            SubscriptionPolicyDefinitionResource getPolicyDefinition = await subscription.GetSubscriptionPolicyDefinitions().GetAsync(policyDefinitionName);
            AssertValidPolicyDefinition(policyDefinition, getPolicyDefinition);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetByTenant()
        {
            await foreach (var tenant in Client.GetTenants().GetAllAsync())
            {
                TenantPolicyDefinitionResource getBuiltInPolicyDefinition = await tenant.GetTenantPolicyDefinitions().GetAsync("04d53d87-841c-4f23-8a5b-21564380b55e");
                Assert.That(getBuiltInPolicyDefinition.Data.DisplayName, Is.EqualTo("Deploy Diagnostic Settings for Service Bus to Log Analytics workspace"));
            }
        }

        private static void AssertValidPolicyDefinition(SubscriptionPolicyDefinitionResource model, SubscriptionPolicyDefinitionResource getResult)
        {
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            Assert.That(getResult.Data.PolicyType, Is.EqualTo(model.Data.PolicyType));
            Assert.That(getResult.Data.Mode, Is.EqualTo(model.Data.Mode));
            Assert.That(getResult.Data.DisplayName, Is.EqualTo(model.Data.DisplayName));
            Assert.That(getResult.Data.Description, Is.EqualTo(model.Data.Description));
            Assert.That(getResult.Data.PolicyRule.ToArray(), Is.EqualTo(model.Data.PolicyRule.ToArray()));
            Assert.That(getResult.Data.Metadata.ToArray(), Is.EqualTo(model.Data.Metadata.ToArray()));
            if(model.Data.Parameters != null || getResult.Data.Parameters != null)
            {
                Assert.NotNull(model.Data.Parameters);
                Assert.NotNull(getResult.Data.Parameters);
                Assert.That(getResult.Data.Parameters.Count, Is.EqualTo(model.Data.Parameters.Count));
                foreach (KeyValuePair<string, ArmPolicyParameter> kvp in model.Data.Parameters)
                {
                    Assert.That(getResult.Data.Parameters.ContainsKey(kvp.Key), Is.EqualTo(true));
                    ArmPolicyParameter getParameterDefinitionsValue = getResult.Data.Parameters[kvp.Key];
                    Assert.That(getParameterDefinitionsValue.ParameterType, Is.EqualTo(kvp.Value.ParameterType));
                    if (kvp.Value.AllowedValues != null || getParameterDefinitionsValue.AllowedValues != null)
                    {
                        Assert.NotNull(kvp.Value.AllowedValues);
                        Assert.NotNull(getParameterDefinitionsValue.AllowedValues);
                        Assert.That(getParameterDefinitionsValue.AllowedValues.Count, Is.EqualTo(kvp.Value.AllowedValues.Count));
                        for (int i = 0; i < kvp.Value.AllowedValues.Count; ++i)
                        {
                            Assert.That(getParameterDefinitionsValue.AllowedValues[i], Is.EqualTo(kvp.Value.AllowedValues[i]));
                        }
                    }
                    Assert.That(getParameterDefinitionsValue.DefaultValue, Is.EqualTo(kvp.Value.DefaultValue));
                    if(kvp.Value.Metadata != null || getParameterDefinitionsValue.Metadata != null)
                    {
                        Assert.NotNull(kvp.Value.Metadata);
                        Assert.NotNull(getParameterDefinitionsValue.Metadata);
                        Assert.That(getParameterDefinitionsValue.Metadata.DisplayName, Is.EqualTo(kvp.Value.Metadata.DisplayName));
                        Assert.That(getParameterDefinitionsValue.Metadata.Description, Is.EqualTo(kvp.Value.Metadata.Description));
                        Assert.That(getParameterDefinitionsValue.Metadata.StrongType, Is.EqualTo(kvp.Value.Metadata.StrongType));
                        Assert.That(getParameterDefinitionsValue.Metadata.AssignPermissions, Is.EqualTo(kvp.Value.Metadata.AssignPermissions));
                        Assert.That(getParameterDefinitionsValue.Metadata.AdditionalProperties, Is.EqualTo(kvp.Value.Metadata.AdditionalProperties));
                    }
                }
            }
        }
    }
}
