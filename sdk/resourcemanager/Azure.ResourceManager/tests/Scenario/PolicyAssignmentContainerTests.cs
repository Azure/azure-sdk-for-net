// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Management.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;

namespace Azure.ResourceManager.Tests
{
    public class PolicyAssignmentContainerTests : ResourceManagerTestBase
    {
        public PolicyAssignmentContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtMgmtGroup()
        {
            //If you want to change this test, ensure you have the right access to management group, otherwise the test will fail and unable to re-record.
            string mgmtGroupName = Recording.GenerateAssetName("testMgmtGroup-");
            ManagementGroup mgmtGroup = await Client.GetManagementGroups().CreateOrUpdateAsync(mgmtGroupName, new CreateManagementGroupOptions());
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-C-");
            PolicyAssignmentData policyAssignmentData = new PolicyAssignmentData
            {
                DisplayName = $"AutoTest ${policyAssignmentName}",
                PolicyDefinitionId = PolicyDefinitionId
            };
            PolicyAssignment policyAssignment = (await mgmtGroup.GetPolicyAssignments().CreateOrUpdateAsync(policyAssignmentName, policyAssignmentData)).Value;
            Assert.AreEqual(policyAssignmentName, policyAssignment.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetPolicyAssignments().CreateOrUpdateAsync(null, policyAssignmentData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await mgmtGroup.GetPolicyAssignments().CreateOrUpdateAsync(policyAssignmentName, null));
        }
        
        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtResourceGroup()
        {
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            string policyAsignmentName = Recording.GenerateAssetName("polAssign-C-");
            PolicyAssignmentData policyAssignmentData = new PolicyAssignmentData
            {
                DisplayName = $"AutoTest ${policyAsignmentName}",
                PolicyDefinitionId = PolicyDefinitionId
            };
            PolicyAssignment policyAssignment = (await rg.GetPolicyAssignments().CreateOrUpdateAsync(policyAsignmentName, policyAssignmentData)).Value;
            Assert.AreEqual(policyAsignmentName, policyAssignment.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetPolicyAssignments().CreateOrUpdateAsync(null, policyAssignmentData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetPolicyAssignments().CreateOrUpdateAsync(policyAsignmentName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtSubscription()
        {
            string policyAsignmentName = Recording.GenerateAssetName("polAssign-C-");
            PolicyAssignmentData policyAssignmentData = new PolicyAssignmentData
            {
                DisplayName = $"AutoTest ${policyAsignmentName}",
                PolicyDefinitionId = PolicyDefinitionId
            };
            PolicyAssignment policyAssignment = (await Client.DefaultSubscription.GetPolicyAssignments().CreateOrUpdateAsync(policyAsignmentName, policyAssignmentData)).Value;
            Assert.AreEqual(policyAsignmentName, policyAssignment.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetPolicyAssignments().CreateOrUpdateAsync(null, policyAssignmentData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetPolicyAssignments().CreateOrUpdateAsync(policyAsignmentName, null));
            await policyAssignment.DeleteAsync();
        }
               
        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtResource()
        {
            string rgName = Recording.GenerateAssetName("testRg-2-");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            string vnName = Recording.GenerateAssetName("testVn-");
            GenericResourceData vnData = ConstructGenericVirtualNetwork();
            ResourceIdentifier vnId = rg.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", vnName);
            GenericResource vn = await Client.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(vnId, vnData);
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-C-");
            PolicyAssignmentData policyAssignmentData = new PolicyAssignmentData
            {
                DisplayName = $"AutoTest ${policyAssignmentName}",
                PolicyDefinitionId = PolicyDefinitionId
            };
            PolicyAssignment policyAssignment = (await vn.GetPolicyAssignments().CreateOrUpdateAsync(policyAssignmentName, policyAssignmentData)).Value;
            Assert.AreEqual(policyAssignmentName, policyAssignment.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn.GetPolicyAssignments().CreateOrUpdateAsync(null, policyAssignmentData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn.GetPolicyAssignments().CreateOrUpdateAsync(policyAssignmentName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            string rgName = Recording.GenerateAssetName("testRg-3-");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            string policyAssignmentName1 = Recording.GenerateAssetName("polAssign-L-");
            string policyAssignmentName2 = Recording.GenerateAssetName("polAssign-L-");
            string policyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/0015ea4d-51ff-4ce3-8d8c-f3f8f0179a56";
            PolicyAssignmentData policyAssignmentData1 = new PolicyAssignmentData
            {
                DisplayName = $"AutoTest ${policyAssignmentName1}",
                PolicyDefinitionId = policyDefinitionId
            };
            PolicyAssignmentData policyAssignmentData2 = new PolicyAssignmentData
            {
                DisplayName = $"AutoTest ${policyAssignmentName1}",
                PolicyDefinitionId = policyDefinitionId
            };
            _ = await rg.GetPolicyAssignments().CreateOrUpdateAsync(policyAssignmentName1, policyAssignmentData1);
            _ = await rg.GetPolicyAssignments().CreateOrUpdateAsync(policyAssignmentName2, policyAssignmentData2);
            int count = 0;
            string filter = $"policyDefinitionId eq '{policyDefinitionId}'";
            await foreach (var policyAssignment in rg.GetPolicyAssignments().GetAllAsync(filter))
            {
                count++;
            }
            Assert.AreEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-G-");
            PolicyAssignmentData policyAssignmentData = new PolicyAssignmentData
            {
                DisplayName = $"AutoTest ${policyAssignmentName}",
                PolicyDefinitionId = PolicyDefinitionId
            };
            PolicyAssignment policyAssignment = (await rg.GetPolicyAssignments().CreateOrUpdateAsync(policyAssignmentName, policyAssignmentData)).Value;
            PolicyAssignment getPolicyAssignment = await rg.GetPolicyAssignments().GetAsync(policyAssignmentName);
            AssertValidPolicyAssignment(policyAssignment, getPolicyAssignment);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetPolicyAssignments().GetAsync(null));
        }
        
        private GenericResourceData ConstructGenericVirtualNetwork()
        {
            var virtualNetwork = new GenericResourceData(Location.WestUS2)
            {
                Properties = new JsonObject()
                {
                    {"addressSpace", new JsonObject()
                        {
                            {"addressPrefixes", new List<string>(){"10.0.0.0/16" } }
                        }
                    }
                }
            };
            return virtualNetwork;
        }
        private void AssertValidPolicyAssignment(PolicyAssignment model, PolicyAssignment getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.Location, getResult.Data.Location);
            Assert.AreEqual(model.Data.Identity, getResult.Data.Identity);
            Assert.AreEqual(model.Data.DisplayName, getResult.Data.DisplayName);
            Assert.AreEqual(model.Data.PolicyDefinitionId, getResult.Data.PolicyDefinitionId);
            Assert.AreEqual(model.Data.Scope, getResult.Data.Scope);
            Assert.AreEqual(model.Data.NotScopes, getResult.Data.NotScopes);
            if (model.Data.Parameters != null || getResult.Data.Parameters != null)
            {
                Assert.NotNull(model.Data.Parameters);
                Assert.NotNull(getResult.Data.Parameters);
                Assert.AreEqual(model.Data.Parameters.Count, getResult.Data.Parameters.Count);
                foreach(KeyValuePair<string, ParameterValuesValue> kv in model.Data.Parameters)
                {
                    Assert.True(getResult.Data.Parameters.ContainsKey(kv.Key));
                    Assert.AreEqual(kv.Value.Value, getResult.Data.Parameters[kv.Key]);
                }
            }
            Assert.AreEqual(model.Data.Description, getResult.Data.Description);
            Assert.AreEqual(model.Data.Metadata, getResult.Data.Metadata);
            Assert.AreEqual(model.Data.EnforcementMode, getResult.Data.EnforcementMode);
            if(model.Data.NonComplianceMessages != null || getResult.Data.NonComplianceMessages != null)
            {
                Assert.NotNull(model.Data.NonComplianceMessages);
                Assert.NotNull(getResult.Data.NonComplianceMessages);
                Assert.AreEqual(model.Data.NonComplianceMessages.Count, getResult.Data.NonComplianceMessages.Count);
                for(int i = 0; i < model.Data.NonComplianceMessages.Count; ++i)
                {
                    Assert.AreEqual(model.Data.NonComplianceMessages[i].Message, getResult.Data.NonComplianceMessages[i].Message);
                    Assert.AreEqual(model.Data.NonComplianceMessages[i].PolicyDefinitionReferenceId, getResult.Data.NonComplianceMessages[i].PolicyDefinitionReferenceId);
                }
            }
        }
        // test values
        private const string PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d";
    }

}
