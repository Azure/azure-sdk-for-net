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
using Azure.Core;

namespace Azure.ResourceManager.Network.Tests
{
    internal class BastionHostCollectionTests : NetworkServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private SubnetResource _subnet;
        private PublicIPAddressResource _publicIPAddress;
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
            SubscriptionResource subscription = await GlobalClient.GetDefaultSubscriptionAsync();
            var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("bastionrg-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            VirtualNetworkData vnetData = new VirtualNetworkData();
            vnetData.Location = AzureLocation.WestUS2;
            vnetData.AddressSpace = new VirtualNetworkAddressSpace();
            vnetData.AddressSpace.AddressPrefixes.Add("10.0.0.0/16");
            var vnetLro = await rg.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("vnet-"), vnetData);
            VirtualNetworkResource vnet = vnetLro.Value;
            SubnetData subnetData = new SubnetData();
            subnetData.AddressPrefix = "10.0.0.0/24";
            var subnetLro = await vnet.GetSubnets().CreateOrUpdateAsync(WaitUntil.Completed, "AzureBastionSubnet", subnetData);
            _subnetIdentifier = subnetLro.Value.Id;
            PublicIPAddressData ipData = new PublicIPAddressData();
            ipData.Location = AzureLocation.WestUS2;
            ipData.PublicIPAllocationMethod = NetworkIPAllocationMethod.Static;
            ipData.Sku = new PublicIPAddressSku();
            ipData.Sku.Name = PublicIPAddressSkuName.Standard;
            var ipLro = await rg.GetPublicIPAddresses().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("ip-"), ipData);
            _publicIPAddressIdentifier = ipLro.Value.Id;
            _bastionName = SessionRecording.GenerateAssetName("bastion-");
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            var _ = await client.GetDefaultSubscriptionAsync(); // TODO: hack to avoid mismatch of recordings so we don't need to re-record for the change. Remove when you need to run live tests next time.
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
            VirtualNetworkResource vnet = await _resourceGroup.GetVirtualNetworks().GetAsync(_subnetIdentifier.Parent.Name);
            _subnet = await vnet.GetSubnets().GetAsync(_subnetIdentifier.Name);
            _publicIPAddress = await _resourceGroup.GetPublicIPAddresses().GetAsync(_publicIPAddressIdentifier.Name);
        }

        [TearDown]
        public async Task TestTearDown()
        {
            if (await _resourceGroup.GetBastionHosts().ExistsAsync(_bastionName))
            {
                BastionHostResource bastion = await _resourceGroup.GetBastionHosts().GetAsync(_bastionName);
                await bastion.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<BastionHostResource> CreateBastionHost(string bastionName)
        {
            BastionHostData data = new BastionHostData();
            data.Location = AzureLocation.WestUS2;
            BastionHostIPConfiguration ipConfig = new BastionHostIPConfiguration();
            ipConfig.Name = Recording.GenerateAssetName("bastionIPConfig-");
            ipConfig.Subnet = new WritableSubResource();
            ipConfig.Subnet.Id = _subnet.Id;
            ipConfig.PublicIPAddress = new WritableSubResource();
            ipConfig.PublicIPAddress.Id = _publicIPAddress.Id;
            data.IPConfigurations.Add(ipConfig);
            var bastionLro = await _resourceGroup.GetBastionHosts().CreateOrUpdateAsync(WaitUntil.Completed, bastionName, data);
            return bastionLro.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            BastionHostResource bastionHost = await CreateBastionHost(_bastionName);
            Assert.IsNotNull(bastionHost.Data);
            Assert.AreEqual(_bastionName, bastionHost.Data.Name);
            Assert.AreEqual(AzureLocation.WestUS2, bastionHost.Data.Location);
            Assert.AreEqual(0, bastionHost.Data.Tags.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            BastionHostResource bastionHost = await CreateBastionHost(_bastionName);
            var bastion = await _resourceGroup.GetBastionHosts().GetAsync(_bastionName);
            Assert.IsNotNull(bastion.Value.Data);
            Assert.AreEqual(_bastionName, bastion.Value.Data.Name);
            Assert.AreEqual(AzureLocation.WestUS2, bastion.Value.Data.Location);
            Assert.AreEqual(0, bastion.Value.Data.Tags.Count);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            BastionHostResource bastionHost = await CreateBastionHost(_bastionName);
            List<BastionHostResource> BastionList = await _resourceGroup.GetBastionHosts().GetAllAsync().ToEnumerableAsync();
            Has.One.EqualTo(BastionList);
            Assert.AreEqual(_bastionName, BastionList[0].Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exists()
        {
            BastionHostResource bastionHost = await CreateBastionHost(_bastionName);
            Assert.IsTrue(await _resourceGroup.GetBastionHosts().ExistsAsync(_bastionName));
            Assert.IsFalse(await _resourceGroup.GetBastionHosts().ExistsAsync(_bastionName + "1"));
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            BastionHostResource bastionHost = await CreateBastionHost(_bastionName);
            await bastionHost.DeleteAsync(WaitUntil.Completed);
            List<BastionHostResource> bastionList = await _resourceGroup.GetBastionHosts().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(bastionList);
        }
    }
}
