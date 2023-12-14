// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ResourceMover.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.ResourceManager.Network;

namespace Azure.ResourceManager.ResourceMover.Tests
{
    public class ResourceMoverManagementTestBase : ManagementRecordedTestBase<ResourceMoverManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected ResourceMoverManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            IgnoreNetworkDependencyVersions();
        }

        protected ResourceMoverManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            IgnoreNetworkDependencyVersions();
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgName, AzureLocation location)
        {
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<MoverResourceSetResource> CreateMoverResourceSet(ResourceGroupResource rg, string moverResourceSetName)
        {
            MoverResourceSetData input = new MoverResourceSetData("eastus2")
            {
                Properties = new MoverResourceSetProperties() { SourceLocation = AzureLocation.EastUS, TargetLocation = AzureLocation.EastUS2 },
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            var lro = await rg.GetMoverResourceSets().CreateOrUpdateAsync(WaitUntil.Completed, moverResourceSetName, input);
            return lro.Value;
        }

        protected async Task<VirtualNetworkResource> CreareVirtualNetwork(ResourceGroupResource rg, string vnetName)
        {
            VirtualNetworkData virtualNetworkData = new VirtualNetworkData()
            {
                Location = AzureLocation.EastUS,
                Subnets =
                {
                    new SubnetData()
                    {
                        Name = Recording.GenerateAssetName("Subnet-"),
                        AddressPrefix = "10.0.0.0/24"
                    }
                },
                AddressPrefixes = { "10.0.0.0/16" }
            };
            var lro = await rg.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, virtualNetworkData);
            return lro.Value;
        }

        protected async Task<MoverResource> CreateMoverResource(MoverResourceSetResource moverResourceSet, ResourceIdentifier vnetId, string moverResourceName, string targetVnetName)
        {
            MoverResourceData input = new MoverResourceData
            {
                Properties = new MoverResourceProperties(vnetId)
                {
                    ResourceSettings = new MoverVirtualNetworkResourceSettings() { TargetResourceName = targetVnetName }
                }
            };
            var lro = await moverResourceSet.GetMoverResources().CreateOrUpdateAsync(WaitUntil.Completed, moverResourceName, input);
            return lro.Value;
        }
    }
}
