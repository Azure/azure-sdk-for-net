// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    // NOTE: comment these out because this resource comes from a preview swagger
    //public class PolicyExemptionCollectionTests : ResourceManagerTestBase
    //{
    //    public PolicyExemptionCollectionTests(bool isAsync)
    //        : base(isAsync)//, RecordedTestMode.Record)
    //    {
    //    }

    //    [TestCase]
    //    [RecordedTest]
    //    public async Task CreateOrUpdateAtMgmtGroup()
    //    {
    //        //This test uses a pre-created management group.
    //        ManagementGroupResource mgmtGroup = await GetCreatedManagementGroup();
    //        string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
    //        PolicyAssignmentResource policyAssignment = await CreatePolicyAssignment(mgmtGroup, policyAssignmentName);
    //        string policyExemptionName = Recording.GenerateAssetName("polExemp-");
    //        PolicyExemptionResource policyExemption = await CreatePolicyExemption(mgmtGroup, policyAssignment, policyExemptionName);
    //        Assert.AreEqual(policyExemptionName, policyExemption.Data.Name);
    //        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetPolicyExemptions().CreateOrUpdateAsync(WaitUntil.Completed, null, policyExemption.Data));
    //        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetPolicyExemptions().CreateOrUpdateAsync(WaitUntil.Completed, policyExemptionName, null));
    //    }

    //    [TestCase]
    //    [RecordedTest]
    //    public async Task CreateOrUpdateAtResourceGroup()
    //    {
    //        SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
    //        string rgName = Recording.GenerateAssetName("testRg-");
    //        ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName);
    //        string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
    //        PolicyAssignmentResource policyAssignment = await CreatePolicyAssignment(rg, policyAssignmentName);
    //        string policyExemptionName = Recording.GenerateAssetName("polExemp-");
    //        PolicyExemptionResource policyExemption = await CreatePolicyExemption(rg, policyAssignment, policyExemptionName);
    //        Assert.AreEqual(policyExemptionName, policyExemption.Data.Name);
    //        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetPolicyExemptions().CreateOrUpdateAsync(WaitUntil.Completed, null, policyExemption.Data));
    //        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetPolicyExemptions().CreateOrUpdateAsync(WaitUntil.Completed, policyExemptionName, null));
    //    }

    //    [TestCase]
    //    [RecordedTest]
    //    public async Task CreateOrUpdateAtSubscription()
    //    {
    //        SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
    //        string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
    //        PolicyAssignmentResource policyAssignment = await CreatePolicyAssignment(subscription, policyAssignmentName);
    //        string policyExemptionName = Recording.GenerateAssetName("polExemp-");
    //        PolicyExemptionResource policyExemption = await CreatePolicyExemption(subscription, policyAssignment, policyExemptionName);
    //        Assert.AreEqual(policyExemptionName, policyExemption.Data.Name);
    //        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetPolicyExemptions().CreateOrUpdateAsync(WaitUntil.Completed, null, policyExemption.Data));
    //        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetPolicyExemptions().CreateOrUpdateAsync(WaitUntil.Completed, policyExemptionName, null));
    //    }

    //    [TestCase]
    //    [RecordedTest]
    //    public async Task CreateOrUpdateAtResource()
    //    {
    //        SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
    //        string rgName = Recording.GenerateAssetName("testRg-");
    //        ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName);
    //        string vnName = Recording.GenerateAssetName("testVn-");
    //        GenericResource vn = await CreateGenericVirtualNetwork(subscription, rg, vnName);
    //        string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
    //        PolicyAssignmentResource policyAssignment = await CreatePolicyAssignment(vn, policyAssignmentName);
    //        string policyExemptionName = Recording.GenerateAssetName("polExemp-");
    //        PolicyExemptionResource policyExemption = await CreatePolicyExemption(vn, policyAssignment, policyExemptionName);
    //        Assert.AreEqual(policyExemptionName, policyExemption.Data.Name);
    //        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn.GetPolicyExemptions().CreateOrUpdateAsync(WaitUntil.Completed, null, policyExemption.Data));
    //        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn.GetPolicyExemptions().CreateOrUpdateAsync(WaitUntil.Completed, policyExemptionName, null));
    //    }

    //    [TestCase]
    //    [RecordedTest]
    //    public async Task List()
    //    {
    //        SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
    //        string rgName = Recording.GenerateAssetName("testRg-");
    //        ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName);
    //        string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
    //        PolicyAssignmentResource policyAssignment = await CreatePolicyAssignment(rg, policyAssignmentName);
    //        string policyExemptionName1 = Recording.GenerateAssetName("polExemp-");
    //        string policyExemptionName2 = Recording.GenerateAssetName("polExemp-");
    //        _ = await CreatePolicyExemption(rg, policyAssignment, policyExemptionName1);
    //        _ = await CreatePolicyExemption(rg, policyAssignment, policyExemptionName2);
    //        int count = 0;
    //        string filter = $"policyAssignmentId eq '{policyAssignment.Id}'";
    //        await foreach (var policyExemption in rg.GetPolicyExemptions().GetAllAsync(filter))
    //        {
    //            count++;
    //        }
    //        Assert.AreEqual(count, 2);
    //    }
        
    //    [TestCase]
    //    [RecordedTest]
    //    public async Task Get()
    //    {
    //        SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
    //        string rgName = Recording.GenerateAssetName("testRg-");
    //        ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName);
    //        string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
    //        PolicyAssignmentResource policyAssignment = await CreatePolicyAssignment(rg, policyAssignmentName);
    //        string policyExemptionName = Recording.GenerateAssetName("polExemp-");
    //        PolicyExemptionResource policyExemption = await CreatePolicyExemption(rg, policyAssignment, policyExemptionName);
    //        PolicyExemptionResource getPolicyExemption = await rg.GetPolicyExemptions().GetAsync(policyExemptionName);
    //        AssertValidPolicyExemption(policyExemption, getPolicyExemption);
    //        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetPolicyExemptions().GetAsync(null));
    //    }

    //    private void AssertValidPolicyExemption(PolicyExemptionResource model, PolicyExemptionResource getResult)
    //    {
    //        Assert.AreEqual(model.Data.Name, getResult.Data.Name);
    //        Assert.AreEqual(model.Data.Id, getResult.Data.Id);
    //        Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
    //        if(model.Data.SystemData != null || getResult.Data.SystemData != null)
    //        {
    //            Assert.NotNull(model.Data.SystemData);
    //            Assert.NotNull(getResult.Data.SystemData);
    //            Assert.AreEqual(model.Data.SystemData.CreatedOn, getResult.Data.SystemData.CreatedOn);
    //            Assert.AreEqual(model.Data.SystemData.CreatedBy, getResult.Data.SystemData.CreatedBy);
    //            Assert.AreEqual(model.Data.SystemData.CreatedByType, getResult.Data.SystemData.CreatedByType);
    //            Assert.AreEqual(model.Data.SystemData.LastModifiedOn, getResult.Data.SystemData.LastModifiedOn);
    //            Assert.AreEqual(model.Data.SystemData.LastModifiedBy, getResult.Data.SystemData.LastModifiedBy);
    //            Assert.AreEqual(model.Data.SystemData.LastModifiedByType, getResult.Data.SystemData.LastModifiedByType);
    //        }
    //        Assert.AreEqual(model.Data.PolicyAssignmentId, getResult.Data.PolicyAssignmentId);
    //        Assert.AreEqual(model.Data.PolicyDefinitionReferenceIds, getResult.Data.PolicyDefinitionReferenceIds);
    //        Assert.AreEqual(model.Data.ExemptionCategory, getResult.Data.ExemptionCategory);
    //        Assert.AreEqual(model.Data.ExpiresOn, getResult.Data.ExpiresOn);
    //        Assert.AreEqual(model.Data.DisplayName, getResult.Data.DisplayName);
    //        Assert.AreEqual(model.Data.Description, getResult.Data.Description);
    //        Assert.AreEqual(model.Data.Metadata, getResult.Data.Metadata);
    //    }
    //}
}
