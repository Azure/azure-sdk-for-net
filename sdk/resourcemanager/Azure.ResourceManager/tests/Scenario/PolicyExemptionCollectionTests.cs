// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class PolicyExemptionCollectionTests : ResourceManagerTestBase
    {
        public PolicyExemptionCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtMgmtGroup()
        {
            //This test uses a pre-created management group.
            ManagementGroup mgmtGroup = await GetCreatedManagementGroup();
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignment policyAssignment = await CreatePolicyAssignment(mgmtGroup, policyAssignmentName);
            string policyExemptionName = Recording.GenerateAssetName("polExemp-");
            PolicyExemption policyExemption = await CreatePolicyExemption(mgmtGroup, policyAssignment, policyExemptionName);
            Assert.AreEqual(policyExemptionName, policyExemption.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetPolicyExemptions().CreateOrUpdateAsync(true, null, policyExemption.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetPolicyExemptions().CreateOrUpdateAsync(true, policyExemptionName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtResourceGroup()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroup rg = await CreateResourceGroup(subscription, rgName);
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignment policyAssignment = await CreatePolicyAssignment(rg, policyAssignmentName);
            string policyExemptionName = Recording.GenerateAssetName("polExemp-");
            PolicyExemption policyExemption = await CreatePolicyExemption(rg, policyAssignment, policyExemptionName);
            Assert.AreEqual(policyExemptionName, policyExemption.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetPolicyExemptions().CreateOrUpdateAsync(true, null, policyExemption.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetPolicyExemptions().CreateOrUpdateAsync(true, policyExemptionName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtSubscription()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignment policyAssignment = await CreatePolicyAssignment(subscription, policyAssignmentName);
            string policyExemptionName = Recording.GenerateAssetName("polExemp-");
            PolicyExemption policyExemption = await CreatePolicyExemption(subscription, policyAssignment, policyExemptionName);
            Assert.AreEqual(policyExemptionName, policyExemption.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetPolicyExemptions().CreateOrUpdateAsync(true, null, policyExemption.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetPolicyExemptions().CreateOrUpdateAsync(true, policyExemptionName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtResource()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroup rg = await CreateResourceGroup(subscription, rgName);
            string vnName = Recording.GenerateAssetName("testVn-");
            GenericResource vn = await CreateGenericVirtualNetwork(subscription, rg, vnName);
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignment policyAssignment = await CreatePolicyAssignment(vn, policyAssignmentName);
            string policyExemptionName = Recording.GenerateAssetName("polExemp-");
            PolicyExemption policyExemption = await CreatePolicyExemption(vn, policyAssignment, policyExemptionName);
            Assert.AreEqual(policyExemptionName, policyExemption.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn.GetPolicyExemptions().CreateOrUpdateAsync(true, null, policyExemption.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn.GetPolicyExemptions().CreateOrUpdateAsync(true, policyExemptionName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroup rg = await CreateResourceGroup(subscription, rgName);
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignment policyAssignment = await CreatePolicyAssignment(rg, policyAssignmentName);
            string policyExemptionName1 = Recording.GenerateAssetName("polExemp-");
            string policyExemptionName2 = Recording.GenerateAssetName("polExemp-");
            _ = await CreatePolicyExemption(rg, policyAssignment, policyExemptionName1);
            _ = await CreatePolicyExemption(rg, policyAssignment, policyExemptionName2);
            int count = 0;
            string filter = $"policyAssignmentId eq '{policyAssignment.Id}'";
            await foreach (var policyExemption in rg.GetPolicyExemptions().GetAllAsync(filter))
            {
                count++;
            }
            Assert.AreEqual(count, 2);
        }
        
        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroup rg = await CreateResourceGroup(subscription, rgName);
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignment policyAssignment = await CreatePolicyAssignment(rg, policyAssignmentName);
            string policyExemptionName = Recording.GenerateAssetName("polExemp-");
            PolicyExemption policyExemption = await CreatePolicyExemption(rg, policyAssignment, policyExemptionName);
            PolicyExemption getPolicyExemption = await rg.GetPolicyExemptions().GetAsync(policyExemptionName);
            AssertValidPolicyExemption(policyExemption, getPolicyExemption);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetPolicyExemptions().GetAsync(null));
        }

        private void AssertValidPolicyExemption(PolicyExemption model, PolicyExemption getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            if(model.Data.SystemData != null || getResult.Data.SystemData != null)
            {
                Assert.NotNull(model.Data.SystemData);
                Assert.NotNull(getResult.Data.SystemData);
                Assert.AreEqual(model.Data.SystemData.CreatedAt, getResult.Data.SystemData.CreatedAt);
                Assert.AreEqual(model.Data.SystemData.CreatedBy, getResult.Data.SystemData.CreatedBy);
                Assert.AreEqual(model.Data.SystemData.CreatedByType, getResult.Data.SystemData.CreatedByType);
                Assert.AreEqual(model.Data.SystemData.LastModifiedAt, getResult.Data.SystemData.LastModifiedAt);
                Assert.AreEqual(model.Data.SystemData.LastModifiedBy, getResult.Data.SystemData.LastModifiedBy);
                Assert.AreEqual(model.Data.SystemData.LastModifiedByType, getResult.Data.SystemData.LastModifiedByType);
            }
            Assert.AreEqual(model.Data.PolicyAssignmentId, getResult.Data.PolicyAssignmentId);
            Assert.AreEqual(model.Data.PolicyDefinitionReferenceIds, getResult.Data.PolicyDefinitionReferenceIds);
            Assert.AreEqual(model.Data.ExemptionCategory, getResult.Data.ExemptionCategory);
            Assert.AreEqual(model.Data.ExpiresOn, getResult.Data.ExpiresOn);
            Assert.AreEqual(model.Data.DisplayName, getResult.Data.DisplayName);
            Assert.AreEqual(model.Data.Description, getResult.Data.Description);
            Assert.AreEqual(model.Data.Metadata, getResult.Data.Metadata);
        }
    }
}
