// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class PolicyAssignmentCollectionTests : ResourceManagerTestBase
    {
        public PolicyAssignmentCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtMgmtGroup()
        {
            //This test uses a pre-created management group.
            ManagementGroupResource mgmtGroup = await GetCreatedManagementGroup();
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignmentResource policyAssignment = await CreatePolicyAssignment(mgmtGroup, policyAssignmentName);
            Assert.AreEqual(policyAssignmentName, policyAssignment.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetPolicyAssignments().CreateOrUpdateAsync(WaitUntil.Completed, null, policyAssignment.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetPolicyAssignments().CreateOrUpdateAsync(WaitUntil.Completed, policyAssignmentName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtResourceGroup()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName);
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignmentResource policyAssignment = await CreatePolicyAssignment(rg, policyAssignmentName);
            Assert.AreEqual(policyAssignmentName, policyAssignment.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetPolicyAssignments().CreateOrUpdateAsync(WaitUntil.Completed, null, policyAssignment.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetPolicyAssignments().CreateOrUpdateAsync(WaitUntil.Completed, policyAssignmentName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtSubscription()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignmentResource policyAssignment = await CreatePolicyAssignment(subscription, policyAssignmentName);
            Assert.AreEqual(policyAssignmentName, policyAssignment.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetPolicyAssignments().CreateOrUpdateAsync(WaitUntil.Completed, null, policyAssignment.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetPolicyAssignments().CreateOrUpdateAsync(WaitUntil.Completed, policyAssignmentName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtResource()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName);
            string vnName = Recording.GenerateAssetName("testVn-");
            GenericResource vn = await CreateGenericVirtualNetwork(subscription, rg, vnName);
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignmentResource policyAssignment = await CreatePolicyAssignment(vn, policyAssignmentName);
            Assert.AreEqual(policyAssignmentName, policyAssignment.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn.GetPolicyAssignments().CreateOrUpdateAsync(WaitUntil.Completed, null, policyAssignment.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn.GetPolicyAssignments().CreateOrUpdateAsync(WaitUntil.Completed, policyAssignmentName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName);
            string policyAssignmentName1 = Recording.GenerateAssetName("polAssign-");
            string policyAssignmentName2 = Recording.GenerateAssetName("polAssign-");
            string policyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/0015ea4d-51ff-4ce3-8d8c-f3f8f0179a56";
            _ = await CreatePolicyAssignment(rg, policyAssignmentName1);
            _ = await CreatePolicyAssignment(rg, policyAssignmentName2, policyDefinitionId);
            int count = 0;
            string filter = $"policyDefinitionId eq '{policyDefinitionId}'";
            await foreach (var policyAssignment in rg.GetPolicyAssignments().GetAllAsync(filter))
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName);
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignmentResource policyAssignment = await CreatePolicyAssignment(rg, policyAssignmentName);
            PolicyAssignmentResource getPolicyAssignment = await rg.GetPolicyAssignments().GetAsync(policyAssignmentName);
            AssertValidPolicyAssignment(policyAssignment, getPolicyAssignment);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetPolicyAssignments().GetAsync(null));
        }

        private void AssertValidPolicyAssignment(PolicyAssignmentResource model, PolicyAssignmentResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.Location, getResult.Data.Location);
            Assert.AreEqual(model.Data.DisplayName, getResult.Data.DisplayName);
            Assert.AreEqual(model.Data.PolicyDefinitionId, getResult.Data.PolicyDefinitionId);
            Assert.AreEqual(model.Data.Scope, getResult.Data.Scope);
            Assert.AreEqual(model.Data.ExcludedScopes, getResult.Data.ExcludedScopes);
            if (model.Data.Parameters != null || getResult.Data.Parameters != null)
            {
                Assert.NotNull(model.Data.Parameters);
                Assert.NotNull(getResult.Data.Parameters);
                Assert.AreEqual(model.Data.Parameters.Count, getResult.Data.Parameters.Count);
                foreach (KeyValuePair<string, ArmPolicyParameterValue> kv in model.Data.Parameters)
                {
                    Assert.True(getResult.Data.Parameters.ContainsKey(kv.Key));
                    Assert.AreEqual(kv.Value.Value, getResult.Data.Parameters[kv.Key]);
                }
            }
            Assert.AreEqual(model.Data.Description, getResult.Data.Description);
            Assert.AreEqual(model.Data.Metadata.ToArray(), getResult.Data.Metadata.ToArray());
            Assert.AreEqual(model.Data.EnforcementMode, getResult.Data.EnforcementMode);
            if (model.Data.NonComplianceMessages != null || getResult.Data.NonComplianceMessages != null)
            {
                Assert.NotNull(model.Data.NonComplianceMessages);
                Assert.NotNull(getResult.Data.NonComplianceMessages);
                Assert.AreEqual(model.Data.NonComplianceMessages.Count, getResult.Data.NonComplianceMessages.Count);
                for (int i = 0; i < model.Data.NonComplianceMessages.Count; ++i)
                {
                    Assert.AreEqual(model.Data.NonComplianceMessages[i].Message, getResult.Data.NonComplianceMessages[i].Message);
                    Assert.AreEqual(model.Data.NonComplianceMessages[i].PolicyDefinitionReferenceId, getResult.Data.NonComplianceMessages[i].PolicyDefinitionReferenceId);
                }
            }
        }
    }
}
