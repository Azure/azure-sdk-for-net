// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Azure.ResourceManager.Network.Tests
{
    internal class BastionHostCollectionTests : NetworkServiceClientTestBase
    {
        private ResourceGroup _resourceGroup;
        private Subnet _subnet;
        private PublicIPAddress _publicIPAddress;
        private string _bastionName;

        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceIdentifier _subnetIdentifier;
        private ResourceIdentifier _publicIPAddressIdentifier;

        public BastionHostCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            Subscription subscription = await GlobalClient.GetDefaultSubscriptionAsync();
            var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("bastionrg-"), new ResourceGroupData(Location.WestUS2));
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
            _bastionName = SessionRecording.GenerateAssetName("bastion-");
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            var _ = await client.GetDefaultSubscriptionAsync(); // TODO: hack to avoid mismatch of recordings so we don't need to re-record for the change. Remove when you need to run live tests next time.
            _resourceGroup = await client.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
            VirtualNetwork vnet = await _resourceGroup.GetVirtualNetworks().GetAsync(_subnetIdentifier.Parent.Name);
            _subnet = await vnet.GetSubnets().GetAsync(_subnetIdentifier.Name);
            _publicIPAddress = await _resourceGroup.GetPublicIPAddresses().GetAsync(_publicIPAddressIdentifier.Name);
        }

        [TearDown]
        public async Task TestTearDown()
        {
            if (_resourceGroup.GetBastionHosts().CheckIfExists(_bastionName))
            {
                BastionHost bastion = await _resourceGroup.GetBastionHosts().GetAsync(_bastionName);
                await bastion.DeleteAsync();
            }
        }

        private async Task<BastionHost> CreateBastionHost(string bastionName)
        {
            BastionHostData data = new BastionHostData();
            data.Location = Location.WestUS2;
            BastionHostIPConfiguration ipConfig = new BastionHostIPConfiguration();
            ipConfig.Name = Recording.GenerateAssetName("bastionIPConfig-");
            ipConfig.Subnet = new WritableSubResource();
            ipConfig.Subnet.Id = _subnet.Id;
            ipConfig.PublicIPAddress = new WritableSubResource();
            ipConfig.PublicIPAddress.Id = _publicIPAddress.Id;
            data.IpConfigurations.Add(ipConfig);
            var bastionLro = await _resourceGroup.GetBastionHosts().CreateOrUpdateAsync(bastionName, data);
            return bastionLro.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            BastionHost bastionHost = await CreateBastionHost(_bastionName);
            Assert.IsNotNull(bastionHost.Data);
            Assert.AreEqual(_bastionName, bastionHost.Data.Name);
            Assert.AreEqual(Location.WestUS2.ToString(), bastionHost.Data.Location);
            Assert.AreEqual(0, bastionHost.Data.Tags.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            BastionHost bastionHost = await CreateBastionHost(_bastionName);
            var bastion = await _resourceGroup.GetBastionHosts().GetAsync(_bastionName);
            Assert.IsNotNull(bastion.Value.Data);
            Assert.AreEqual(_bastionName, bastion.Value.Data.Name);
            Assert.AreEqual(Location.WestUS2.ToString(), bastion.Value.Data.Location);
            Assert.AreEqual(0, bastion.Value.Data.Tags.Count);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            BastionHost bastionHost = await CreateBastionHost(_bastionName);
            List<BastionHost> BastionList = await _resourceGroup.GetBastionHosts().GetAllAsync().ToEnumerableAsync();
            Has.One.EqualTo(BastionList);
            Assert.AreEqual(_bastionName, BastionList[0].Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            BastionHost bastionHost = await CreateBastionHost(_bastionName);
            Assert.IsTrue(_resourceGroup.GetBastionHosts().CheckIfExists(_bastionName));
            Assert.IsFalse(_resourceGroup.GetBastionHosts().CheckIfExists(_bastionName + "1"));
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            BastionHost bastionHost = await CreateBastionHost(_bastionName);
            await bastionHost.DeleteAsync();
            List<BastionHost> bastionList = await _resourceGroup.GetBastionHosts().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(bastionList);
        }
    }
}
