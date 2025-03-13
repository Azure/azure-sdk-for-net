// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.Network.Tests
{
    public class FirewallTests : NetworkServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private VirtualNetworkResource _network;
        private PublicIPAddressResource _publicIPAddress;
        private string _firewallName;

        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceIdentifier _networkIdentifier;
        private ResourceIdentifier _publicIPAddressIdentifier;

        public FirewallTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            SubscriptionResource subscription = await GlobalClient.GetDefaultSubscriptionAsync();
            var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("FirewallRG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;

            VirtualNetworkData vnetData = new VirtualNetworkData()
            {
                Location = AzureLocation.WestUS2,
                AddressSpace = new VirtualNetworkAddressSpace()
                {
                    AddressPrefixes = { "10.20.0.0/16", }
                },
                Subnets = {
                    new SubnetData() { Name = "Default", AddressPrefix = "10.20.1.0/26", },
                    new SubnetData() { Name = "AzureFirewallSubnet", AddressPrefix = "10.20.2.0/26", },
                },
            };
            var vnetLro = await rg.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("vnet-"), vnetData);
            _network = vnetLro.Value;
            _networkIdentifier = _network.Id;

            PublicIPAddressData ipData = new PublicIPAddressData()
            {
                Location = AzureLocation.WestUS2,
                PublicIPAllocationMethod = NetworkIPAllocationMethod.Static,
                Sku = new PublicIPAddressSku() { Name = PublicIPAddressSkuName.Standard },
            };
            var ipLro = await rg.GetPublicIPAddresses().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("publicIp-"), ipData);
            _publicIPAddress = ipLro.Value;
            _publicIPAddressIdentifier = _publicIPAddress.Id;

            _firewallName = SessionRecording.GenerateAssetName("firewall-");
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
            _network = await _resourceGroup.GetVirtualNetworks().GetAsync(_networkIdentifier.Name);
            _publicIPAddress = await _resourceGroup.GetPublicIPAddresses().GetAsync(_publicIPAddressIdentifier.Name);
        }

        [TearDown]
        public async Task Teardown()
        {
            if (await _resourceGroup.GetAzureFirewalls().ExistsAsync(_firewallName))
            {
                AzureFirewallResource firewall = await _resourceGroup.GetAzureFirewalls().GetAsync(_firewallName);
                await firewall.DeleteAsync(WaitUntil.Completed);
            }
        }

        public async Task<AzureFirewallResource> CreateFirewallAsync()
        {
            AzureFirewallData firewallData = new AzureFirewallData();
            firewallData.Location = AzureLocation.WestUS2;
            firewallData.IPConfigurations.Add(new AzureFirewallIPConfiguration()
            {
                Name = "fwpip",
                PublicIPAddress = new WritableSubResource() { Id = _publicIPAddressIdentifier },
                Subnet = new WritableSubResource() { Id = _networkIdentifier.AppendChildResource("subnets", "AzureFirewallSubnet") },
            });
            var firewallLro = await (await _resourceGroup.GetAzureFirewalls().CreateOrUpdateAsync(WaitUntil.Completed, _firewallName, firewallData)).WaitForCompletionAsync();
            return firewallLro.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            AzureFirewallResource firewall = await CreateFirewallAsync();
            Assert.IsNotNull(firewall.Data);
            Assert.AreEqual(_firewallName, firewall.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            await CreateFirewallAsync();
            var firewall = await _resourceGroup.GetAzureFirewalls().GetAsync(_firewallName);
            Assert.IsNotNull(firewall.Value.Data);
            Assert.AreEqual(_firewallName, firewall.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            await CreateFirewallAsync();
            List<AzureFirewallResource> firewallList = await _resourceGroup.GetAzureFirewalls().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, firewallList.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Exists()
        {
            await CreateFirewallAsync();
            Assert.True(await _resourceGroup.GetAzureFirewalls().ExistsAsync(_firewallName));
            Assert.False(await _resourceGroup.GetAzureFirewalls().ExistsAsync(_firewallName + "0"));
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            AzureFirewallResource firewall = await CreateFirewallAsync();
            List<AzureFirewallResource> firewallList = await _resourceGroup.GetAzureFirewalls().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, firewallList.Count);

            await firewall.DeleteAsync(WaitUntil.Completed);
            firewallList = await _resourceGroup.GetAzureFirewalls().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, firewallList.Count);
        }
    }
}
