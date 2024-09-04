// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.PrivateDns.Tests
{
    public class PrivateDnsManagementTestBase : ManagementRecordedTestBase<PrivateDnsManagementTestEnvironment>
    {
        private const string DefaultVnetAddressPrefix = "10.0.0.0/16";
        private const string DefaultVnetSubnetName = "DefaultSubnet";
        private const string DefaultSubnetAddressPrefix = "10.0.0.0/24";

        protected ArmClient Client { get; private set; }
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;
        protected const string DefaultResourceGroupName = "PrivateDnsRG";

        protected PrivateDnsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected PrivateDnsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(string rgNamePrefix = DefaultResourceGroupName)
        {
            var subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<PrivateDnsZoneResource> CreatePrivateZone(ResourceGroupResource resourceGroup,string zoneName)
        {
            var data = new PrivateDnsZoneData("global")
            {
            };
            var privateZone = await resourceGroup.GetPrivateDnsZones().CreateOrUpdateAsync(WaitUntil.Completed,zoneName,data);
            return privateZone.Value;
        }

        protected async Task<VirtualNetworkResource> CreateVirtualNetwork(ResourceGroupResource resourceGroup, string vnetName)
        {
            var virtualNetworkData = new VirtualNetworkData
            {
                Location = DefaultLocation,
                AddressPrefixes = { DefaultVnetAddressPrefix },
                Subnets =
                {
                    new SubnetData
                    {
                        Name = DefaultVnetSubnetName,
                        AddressPrefix = DefaultSubnetAddressPrefix,
                    }
                }
            };

            var virtualNetwork = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, virtualNetworkData);
            return virtualNetwork.Value;
        }

        protected async Task<VirtualNetworkLinkResource> CreateOrUpdateVirtualNetworkLink(PrivateDnsZoneResource privateZone, string linkName, VirtualNetworkLinkData vnetLinkData)
        {
            var vnetLinkResponse = await privateZone.GetVirtualNetworkLinks().CreateOrUpdateAsync(WaitUntil.Completed, linkName, vnetLinkData);
            return vnetLinkResponse.Value;
        }
    }
}
