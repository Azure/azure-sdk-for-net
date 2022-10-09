// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    public class SecurityCenterManagementTestBase : ManagementRecordedTestBase<SecurityCenterManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected const string rgNamePrefix = "SecurityCenterRG";
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;

        protected SecurityCenterManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected SecurityCenterManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<VirtualNetworkResource> CreateDefaultNetwork(ResourceGroupResource resourceGroup, string vnetName)
        {
            // Create a NSG
            string nsgName = "MyResourceGroupNSG";
            var nsgData = new NetworkSecurityGroupData() { Location = resourceGroup.Data.Location, };
            var nsg = await resourceGroup.GetNetworkSecurityGroups().CreateOrUpdateAsync(WaitUntil.Completed, nsgName, nsgData);

            VirtualNetworkData data = new VirtualNetworkData()
            {
                Location = resourceGroup.Data.Location,
            };
            data.AddressPrefixes.Add("10.10.0.0/16");
            data.Subnets.Add(new SubnetData() { Name = "subnet1", AddressPrefix = "10.10.1.0/24", PrivateLinkServiceNetworkPolicy = VirtualNetworkPrivateLinkServiceNetworkPolicy.Disabled, NetworkSecurityGroup = nsg.Value.Data });
            data.Subnets.Add(new SubnetData() { Name = "subnet2", AddressPrefix = "10.10.2.0/24" });
            var vnet = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, data);
            return vnet.Value;
        }
    }
}
