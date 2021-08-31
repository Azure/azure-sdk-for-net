// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class PolicyExemptionContainerTests : ResourceManagerTestBase
    {
        public PolicyExemptionContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Live)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroup rg = (await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName)).Value;
            string policyAssignmentName = Recording.GenerateAssetName("testPolAssign-");
            PolicyAssignmentData policyAssignmentData = new PolicyAssignmentData
            {
                DisplayName = $"AutoTest ${policyAssignmentName}",
                PolicyDefinitionId = PolicyDefinitionId
            };
            PolicyAssignment policyAssignment = (await rg.GetPolicyAssignments().CreateOrUpdateAsync(policyAssignmentName, policyAssignmentData)).Value;
            string policyExemptionName = Recording.GenerateAssetName("polExemp-C-");
            PolicyExemptionData policyExemptionData = new PolicyExemptionData(policyAssignment.Id, new ExemptionCategory("Waiver"));
            PolicyExemption policyExemption = (await rg.GetPolicyExemptions().CreateOrUpdateAsync(policyExemptionName, policyExemptionData)).Value;
            Assert.AreEqual(policyExemptionName, policyExemption.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetPolicyExemptions().CreateOrUpdateAsync(null, policyExemptionData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetPolicyExemptions().CreateOrUpdateAsync(policyExemptionName, null));
        }
    
        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            string rgName = Recording.GenerateAssetName("testRg-2-");
            ResourceGroup rg = (await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName)).Value;
            string policyAssignmentName = Recording.GenerateAssetName("testPolAssign-");
            string policyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/0015ea4d-51ff-4ce3-8d8c-f3f8f0179a56";
            PolicyAssignmentData policyAssignmentData = new PolicyAssignmentData
            {
                DisplayName = $"AutoTest ${policyAssignmentName}",
                PolicyDefinitionId = policyDefinitionId
            };
            PolicyAssignment policyAssignment = (await rg.GetPolicyAssignments().CreateOrUpdateAsync(policyAssignmentName, policyAssignmentData)).Value;
            string policyExemptionName1 = Recording.GenerateAssetName("polExemp-L-");
            string policyExemptionName2 = Recording.GenerateAssetName("polExemp-L-");
            PolicyExemptionData policyExemptionData = new PolicyExemptionData(policyAssignment.Id, new ExemptionCategory("Waiver"));
            _ = await rg.GetPolicyExemptions().CreateOrUpdateAsync(policyExemptionName1, policyExemptionData);
            _ = await rg.GetPolicyExemptions().CreateOrUpdateAsync(policyExemptionName2, policyExemptionData);
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
            string rgName = Recording.GenerateAssetName("testRg-3-");
            ResourceGroup rg = (await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName)).Value;
            string policyAssignmentName = Recording.GenerateAssetName("testPolAssign-");
            PolicyAssignmentData policyAssignmentData = new PolicyAssignmentData
            {
                DisplayName = $"AutoTest ${policyAssignmentName}",
                PolicyDefinitionId = PolicyDefinitionId
            };
            PolicyAssignment policyAssignment = (await rg.GetPolicyAssignments().CreateOrUpdateAsync(policyAssignmentName, policyAssignmentData)).Value;
            string policyExemptionName = Recording.GenerateAssetName("polExemp-G-");
            PolicyExemptionData policyExemptionData = new PolicyExemptionData(policyAssignment.Id, new ExemptionCategory("Waiver"));
            PolicyExemption policyExemption = (await rg.GetPolicyExemptions().CreateOrUpdateAsync(policyExemptionName, policyExemptionData)).Value;
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
        // test values
        private const string PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d";
    }
}
