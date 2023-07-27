// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;

namespace Azure.ResourceManager.Tests
{
    public class ResourceManagerTestBase : ManagementRecordedTestBase<ResourceManagerTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected ResourceManagerTestBase(bool isAsync, ResourceType resourceType, string apiVersion, RecordedTestMode? mode = null)
            : base(isAsync, resourceType, apiVersion, mode)
        {
        }

        protected ResourceManagerTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ResourceManagerTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected static GenericResourceData ConstructGenericAvailabilitySet()
        {
            var data = new GenericResourceData(AzureLocation.WestUS2)
            {
                Tags = { },
                Sku = new ResourcesSku()
                {
                    Name = "Aligned"
                },
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                    {
                        {"platformUpdateDomainCount", 5},
                        {"platformFaultDomainCount", 2}
                    })
            };
            return data;
        }

        protected async Task<GenericResource> CreateGenericAvailabilitySetAsync(ResourceIdentifier rgId)
        {
            var genericResources = Client.GetGenericResources();
            GenericResourceData data = ConstructGenericAvailabilitySet();
            var asetId = rgId.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
            var op = await genericResources.CreateOrUpdateAsync(WaitUntil.Completed, asetId, data);
            return op.Value;
        }

        protected async Task<ArmOperation<GenericResource>> StartCreateGenericAvailabilitySetAsync(ResourceIdentifier rgId)
        {
            var genericResources = Client.GetGenericResources();
            GenericResourceData data = ConstructGenericAvailabilitySet();
            var asetId = rgId.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
            return await genericResources.CreateOrUpdateAsync(WaitUntil.Started, asetId, data);
        }

        protected static void AssertAreEqual(GenericResource aset, GenericResource aset2)
        {
            Assert.AreEqual(aset.Data.Id, aset2.Data.Id);
            Assert.AreEqual(aset.Data.Identity, aset2.Data.Identity);
            Assert.AreEqual(aset.Data.Kind, aset2.Data.Kind);
            Assert.AreEqual(aset.Data.Location, aset2.Data.Location);
            Assert.AreEqual(aset.Data.ManagedBy, aset2.Data.ManagedBy);
            Assert.AreEqual(aset.Data.Name, aset2.Data.Name);
            Assert.AreEqual(aset.Data.Plan, aset2.Data.Plan);
            if (aset.Data.Sku != null && aset2.Data.Sku != null)
            {
                Assert.NotNull(aset.Data.Sku);
                Assert.NotNull(aset2.Data.Sku);
                Assert.AreEqual(aset.Data.Sku.Name, aset2.Data.Sku.Name);
                Assert.AreEqual(aset.Data.Sku.Tier, aset2.Data.Sku.Tier);
                Assert.AreEqual(aset.Data.Sku.Size, aset2.Data.Sku.Size);
                Assert.AreEqual(aset.Data.Sku.Family, aset2.Data.Sku.Family);
                Assert.AreEqual(aset.Data.Sku.Model, aset2.Data.Sku.Model);
                Assert.AreEqual(aset.Data.Sku.Capacity, aset2.Data.Sku.Capacity);
            }
            //TODO: Add equal for Properties and Tags
        }

        protected static async Task<int> GetResourceCountAsync(AsyncPageable<GenericResource> genericResources)
        {
            int result = 0;
            await foreach (var resource in genericResources)
                result++;
            return result;
        }
        protected void CompareMgmtGroups(ManagementGroupResource expected, ManagementGroupResource actual)
        {
            Assert.AreEqual(expected.Data.DisplayName, actual.Data.DisplayName);
            Assert.AreEqual(expected.Data.Id, actual.Data.Id);
            Assert.AreEqual(expected.Data.Name, actual.Data.Name);
            Assert.AreEqual(expected.Data.TenantId, actual.Data.TenantId);
            Assert.AreEqual(expected.Data.ResourceType, actual.Data.ResourceType);
            Assert.IsNotNull(actual.Data.Details, "Details were null");
            Assert.IsNotNull(actual.Data.Children, "Children were null");
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgName)
        {
            ResourceGroupData input = new ResourceGroupData(AzureLocation.WestUS);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<ManagementLockResource> CreateManagementLockObject(ArmResource armResource, string lockName)
        {
            ManagementLockData input = new ManagementLockData(new ManagementLockLevel("CanNotDelete"));
            ArmOperation<ManagementLockResource> lro = await armResource.GetManagementLocks().CreateOrUpdateAsync(WaitUntil.Completed, lockName, input);
            return lro.Value;
        }

        private GenericResourceData ConstructGenericVirtualNetworkData()
        {
            var properties = new JsonObject()
            {
                {"addressSpace", new JsonObject()
                    {
                        {"addressPrefixes", new List<string>(){"10.0.0.0/16" } }
                    }
                }
            };
            var virtualNetwork = new GenericResourceData(AzureLocation.WestUS2)
            {
                Properties = BinaryData.FromObjectAsJson(properties),
            };
            return virtualNetwork;
        }

        protected async Task<GenericResource> CreateGenericVirtualNetwork(SubscriptionResource subscription, ResourceGroupResource rg, string vnName) // TODO: remove subscription parameter
        {
            GenericResourceData input = ConstructGenericVirtualNetworkData();
            ResourceIdentifier vnId = rg.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", vnName);
            ArmOperation<GenericResource> lro = await Client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, vnId, input);
            return lro.Value;
        }

        protected async Task<ManagementGroupResource> GetCreatedManagementGroup()
        {
            return await Client.GetManagementGroups().GetAsync("TestMgmtGroup");
        }

        protected async Task<PolicyAssignmentResource> CreatePolicyAssignment(ArmResource armResource, string policyAssignmentName, string PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d")
        {
            PolicyAssignmentData input = new PolicyAssignmentData
            {
                DisplayName = $"Test ${policyAssignmentName}",
                PolicyDefinitionId = PolicyDefinitionId
            };
            ArmOperation<PolicyAssignmentResource> lro = await armResource.GetPolicyAssignments().CreateOrUpdateAsync(WaitUntil.Completed, policyAssignmentName, input);
            return lro.Value;
        }

        private static PolicyDefinitionData ConstructPolicyDefinitionData(string displayName) => new PolicyDefinitionData
        {
            DisplayName = $"Test ${displayName}",
            PolicyRule = BinaryData.FromObjectAsJson(new Dictionary<string, object>
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
                })
        };

        protected async Task<SubscriptionPolicyDefinitionResource> CreatePolicyDefinitionAtSubscription(SubscriptionResource subscription, string policyDefinitionName)
        {
            PolicyDefinitionData input = ConstructPolicyDefinitionData(policyDefinitionName);
            ArmOperation<SubscriptionPolicyDefinitionResource> lro = await subscription.GetSubscriptionPolicyDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, policyDefinitionName, input);
            return lro.Value;
        }

        protected async Task<ManagementGroupPolicyDefinitionResource> CreatePolicyDefinitionAtMgmtGroup(ManagementGroupResource mgmtGroup, string policyDefinitionName)
        {
            PolicyDefinitionData input = ConstructPolicyDefinitionData(policyDefinitionName);
            ArmOperation<ManagementGroupPolicyDefinitionResource> lro = await mgmtGroup.GetManagementGroupPolicyDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, policyDefinitionName, input);
            return lro.Value;
        }

        //protected async Task<PolicyExemptionResource> CreatePolicyExemption(ArmResource armResource, PolicyAssignmentResource policyAssignment, string policyExemptionName)
        //{
        //    PolicyExemptionData input = new PolicyExemptionData(policyAssignment.Id, new ExemptionCategory("Waiver"));
        //    ArmOperation<PolicyExemptionResource> lro = await armResource.GetPolicyExemptions().CreateOrUpdateAsync(WaitUntil.Completed, policyExemptionName, input);
        //    return lro.Value;
        //}

        protected async Task<SubscriptionPolicySetDefinitionResource> CreatePolicySetDefinitionAtSubscription(SubscriptionResource subscription, SubscriptionPolicyDefinitionResource policyDefinition, string policySetDefinitionName)
        {
            PolicySetDefinitionData input = new PolicySetDefinitionData
            {
                DisplayName = $"Test ${policySetDefinitionName}",
                PolicyDefinitions = { new PolicyDefinitionReference(policyDefinition.Id) }
            };
            ArmOperation<SubscriptionPolicySetDefinitionResource> lro = await subscription.GetSubscriptionPolicySetDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, policySetDefinitionName, input);
            return lro.Value;
        }

        protected async Task<ManagementGroupPolicySetDefinitionResource> CreatePolicySetDefinitionAtMgmtGroup(ManagementGroupResource mgmtGroup, ManagementGroupPolicyDefinitionResource policyDefinition, string policySetDefinitionName)
        {
            PolicySetDefinitionData input = new PolicySetDefinitionData
            {
                DisplayName = $"Test ${policySetDefinitionName}",
                PolicyDefinitions = { new PolicyDefinitionReference(policyDefinition.Id) }
            };
            ArmOperation<ManagementGroupPolicySetDefinitionResource> lro = await mgmtGroup.GetManagementGroupPolicySetDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, policySetDefinitionName, input);
            return lro.Value;
        }

        //protected async Task<ResourceLinkResource> CreateResourceLink(TenantResource tenant, GenericResource vn1, GenericResource vn2, string resourceLinkName)
        //{
        //    ResourceIdentifier resourceLinkId = new ResourceIdentifier(vn1.Id + "/providers/Microsoft.Resources/links/" + resourceLinkName);
        //    ResourceLinkProperties properties = new ResourceLinkProperties(vn2.Id);
        //    ResourceLinkData data = new ResourceLinkData()
        //    {
        //        Properties = properties
        //    };
        //    ArmOperation<ResourceLinkResource> lro = await tenant.GetResourceLinks(resourceLinkId).CreateOrUpdateAsync(WaitUntil.Completed, data);
        //    return lro.Value;
        //}
    }
}
