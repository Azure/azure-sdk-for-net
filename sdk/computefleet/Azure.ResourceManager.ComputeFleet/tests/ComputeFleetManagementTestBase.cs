// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ComputeFleet.Tests
{
    public class ComputeFleetManagementTestBase : ManagementRecordedTestBase<ComputeFleetManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected AzureLocation DefaultLocation => AzureLocation.EastUS2;

        protected ResourceGroupResource _resourceGroup;
        protected GenericResourceCollection _genericResourceCollection;

        protected ComputeFleetManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ComputeFleetManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription)
        {
            string rgName = Recording.GenerateAssetName("testFleetRG-");
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<GenericResource> CreateVirtualNetwork()
        {
            var ip = await CreatePublicIPAddress();
            var nat = await CreateNatGateway(ip.Data.Id);
            var nsg = await CreateNetworkSecurityGroups();
            var vnetName = Recording.GenerateAssetName("testVNet-");
            var subnetName = Recording.GenerateAssetName("testSubnet-");
            ResourceIdentifier vnetId = new ResourceIdentifier($"{_resourceGroup.Id}/providers/Microsoft.Network/virtualNetworks/{vnetName}");
            var addressSpaces = new Dictionary<string, object>()
            {
                { "addressPrefixes", new List<string>() { "10.0.0.0/16" } }
            };
            var subnet = new Dictionary<string, object>()
            {
                { "name", subnetName },
                { "properties", new Dictionary<string, object>()
                {
                    { "addressPrefix", "10.0.2.0/24" },
                    { "networkSecurityGroup", new Dictionary<string, object>()
                        {
                            {"id", nsg.Data.Id.ToString() }
                        }
                    },
                    { "natGateway", new Dictionary<string, object>()
                        {
                            {"id", nat.Data.Id.ToString() }
                        }
                    }
                } }
            };
            var subnets = new List<object>() { subnet };
            var input = new GenericResourceData(DefaultLocation)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "addressSpace", addressSpaces },
                    { "subnets", subnets }
                })
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetId, input);
            return operation.Value;
        }

        protected ResourceIdentifier GetSubnetId(GenericResource vnet)
        {
            var properties = vnet.Data.Properties.ToObjectFromJson() as Dictionary<string, object>;
            var subnets = properties["subnets"] as IEnumerable<object>;
            var subnet = subnets.First() as IDictionary<string, object>;
            return new ResourceIdentifier(subnet["id"] as string);
        }

        protected async Task<GenericResource> CreateNetworkSecurityGroups()
        {
            var networkSecurityGroups = Recording.GenerateAssetName("testVNetSecurityGroups-");
            ResourceIdentifier networkSecurityGroupsId = new ResourceIdentifier($"{_resourceGroup.Id}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroups}");
            var input = new GenericResourceData(DefaultLocation){};
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, networkSecurityGroupsId, input);
            return operation.Value;
        }

        protected async Task<GenericResource> CreatePublicIPAddress()
        {
            var publicIPAddressName = Recording.GenerateAssetName("testPublicIP-");
            ResourceIdentifier publicIPAddress = new ResourceIdentifier($"{_resourceGroup.Id}/providers/Microsoft.Network/publicIPAddresses/{publicIPAddressName}");
            var input = new GenericResourceData(DefaultLocation) {
                Sku = new() { Name = "Standard" },
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "publicIPAllocationMethod", "Static"}
                })
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, publicIPAddress, input);
            return operation.Value;
        }

        protected async Task<GenericResource> CreateNatGateway(ResourceIdentifier publicIp)
        {
            var natName = Recording.GenerateAssetName("testNatGateway-");
            ResourceIdentifier nat = new ResourceIdentifier($"{_resourceGroup.Id}/providers/Microsoft.Network/natGateways/{natName}");
            var input = new GenericResourceData(DefaultLocation)
            {
                Sku = new() { Name = "Standard" },
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "publicIpAddresses", new List<object>()
                        {
                            new Dictionary<string, object>()
                            {
                                { "id", publicIp.ToString() }
                            }
                        }
                    }
                })
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nat, input);
            return operation.Value;
        }
    }
}
