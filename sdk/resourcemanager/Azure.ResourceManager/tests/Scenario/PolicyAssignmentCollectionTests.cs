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
            Assert.That(policyAssignment.Data.Name, Is.EqualTo(policyAssignmentName));
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
            Assert.That(policyAssignment.Data.Name, Is.EqualTo(policyAssignmentName));
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
            Assert.That(policyAssignment.Data.Name, Is.EqualTo(policyAssignmentName));
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
            Assert.That(policyAssignment.Data.Name, Is.EqualTo(policyAssignmentName));
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
            Assert.That(count, Is.EqualTo(1));
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
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            Assert.That(getResult.Data.Location, Is.EqualTo(model.Data.Location));
            Assert.That(getResult.Data.DisplayName, Is.EqualTo(model.Data.DisplayName));
            Assert.That(getResult.Data.PolicyDefinitionId, Is.EqualTo(model.Data.PolicyDefinitionId));
            Assert.That(getResult.Data.Scope, Is.EqualTo(model.Data.Scope));
            Assert.That(getResult.Data.ExcludedScopes, Is.EqualTo(model.Data.ExcludedScopes));
            if (model.Data.Parameters != null || getResult.Data.Parameters != null)
            {
                Assert.That(model.Data.Parameters, Is.Not.Null);
                Assert.That(getResult.Data.Parameters, Is.Not.Null);
                Assert.That(getResult.Data.Parameters.Count, Is.EqualTo(model.Data.Parameters.Count));
                foreach (KeyValuePair<string, ArmPolicyParameterValue> kv in model.Data.Parameters)
                {
                    Assert.That(getResult.Data.Parameters.ContainsKey(kv.Key), Is.True);
                    Assert.That(getResult.Data.Parameters[kv.Key], Is.EqualTo(kv.Value.Value));
                }
            }
            Assert.That(getResult.Data.Description, Is.EqualTo(model.Data.Description));
            Assert.That(getResult.Data.Metadata.ToArray(), Is.EqualTo(model.Data.Metadata.ToArray()));
            Assert.That(getResult.Data.EnforcementMode, Is.EqualTo(model.Data.EnforcementMode));
            if (model.Data.NonComplianceMessages != null || getResult.Data.NonComplianceMessages != null)
            {
                Assert.That(model.Data.NonComplianceMessages, Is.Not.Null);
                Assert.That(getResult.Data.NonComplianceMessages, Is.Not.Null);
                Assert.That(getResult.Data.NonComplianceMessages.Count, Is.EqualTo(model.Data.NonComplianceMessages.Count));
                for (int i = 0; i < model.Data.NonComplianceMessages.Count; ++i)
                {
                    Assert.That(getResult.Data.NonComplianceMessages[i].Message, Is.EqualTo(model.Data.NonComplianceMessages[i].Message));
                    Assert.That(getResult.Data.NonComplianceMessages[i].PolicyDefinitionReferenceId, Is.EqualTo(model.Data.NonComplianceMessages[i].PolicyDefinitionReferenceId));
                }
            }
        }
    }
}
