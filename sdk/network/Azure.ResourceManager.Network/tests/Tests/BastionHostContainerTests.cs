// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    internal class BastionHostContainerTests : NetworkServiceClientTestBase
    {
        private ResourceGroup _resourceGroup;
        private Subnet _subnet;
        private PublicIPAddress _publicIPAddress;

        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceIdentifier _subnetIdentifier;
        private ResourceIdentifier _publicIPAddressIdentifier;

        public BastionHostContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("bastionrg-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            VirtualNetworkData vnetData = new VirtualNetworkData();
            vnetData.Location = Location.WestUS2;
            vnetData.AddressSpace = new AddressSpace();
            vnetData.AddressSpace.AddressPrefixes.Add("10.0.0.0/16");
            var vnetLro = await rg.GetVirtualNetworks().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("vnet-"), vnetData);
            VirtualNetwork vnet = vnetLro.Value;
            SubnetData subnetData = new SubnetData();
            subnetData.AddressPrefix = "10.0.0.0/24";
            var subnetLro = await vnet.GetSubnets().CreateOrUpdateAsync("AzureBastionSubnet", subnetData);
            _subnetIdentifier = subnetLro.Value.Id;
            PublicIPAddressData ipData = new PublicIPAddressData();
            ipData.Location = Location.WestUS2;
            ipData.PublicIPAllocationMethod = IPAllocationMethod.Static;
            ipData.Sku = new PublicIPAddressSku();
            ipData.Sku.Name = PublicIPAddressSkuName.Standard;
            var ipLro = await rg.GetPublicIPAddresses().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("ip-"), ipData);
            _publicIPAddressIdentifier = ipLro.Value.Id;
            StopSessionRecording();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
            VirtualNetwork vnet = await _resourceGroup.GetVirtualNetworks().GetAsync(_subnetIdentifier.Parent.Name);
            _subnet = await vnet.GetSubnets().GetAsync(_subnetIdentifier.Name);
            _publicIPAddress = await _resourceGroup.GetPublicIPAddresses().GetAsync(_publicIPAddressIdentifier.Name);
        }

        private async Task<BastionHost> CreateBastionHost(string bastionName)
        {
            BastionHostData data = new BastionHostData();
            data.Location = Location.WestUS2;
            BastionHostIPConfiguration ipConfig = new BastionHostIPConfiguration();
            ipConfig.Name = Recording.GenerateAssetName("bastionIPConfig-");
            ipConfig.Subnet = new Models.SubResource();
            ipConfig.Subnet.Id = _subnet.Id;
            ipConfig.PublicIPAddress = new Models.SubResource();
            ipConfig.PublicIPAddress.Id = _publicIPAddress.Id;
            data.IpConfigurations.Add(ipConfig);
            var bastionLro = await _resourceGroup.GetBastionHosts().CreateOrUpdateAsync(bastionName, data);
            return bastionLro.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string bastionName = Recording.GenerateAssetName("bastion-");
            BastionHost bastionHost = await CreateBastionHost(bastionName);
            Assert.IsNotNull(bastionHost.Data);
            Assert.AreEqual(bastionName, bastionHost.Data.Name);
            Assert.AreEqual(Location.WestUS2.ToString(), bastionHost.Data.Location);
        }
    }
}
