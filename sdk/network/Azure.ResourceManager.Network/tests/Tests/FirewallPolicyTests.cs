// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/24577")]
    public class FirewallPolicyTests : NetworkServiceClientTestBase
    {
        private ResourceGroup _resourceGroup;
        private VirtualNetwork _network;
        private PublicIPAddress _publicIPAddress;
        private AzureFirewall _firewall;

        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceIdentifier _networkIdentifier;
        private ResourceIdentifier _publicIPAddressIdentifier;
        private ResourceIdentifier _firewallIdentifier;

        public FirewallPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("FirewallPolicyRG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;

            VirtualNetworkData vnetData = new VirtualNetworkData()
            {
                Location = Location.WestUS2,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.26.0.0/16", }
                },
                Subnets = {
                    new SubnetData() { Name = "Default", AddressPrefix = "10.26.1.0/26", },
                    new SubnetData() { Name = "AzureFirewallSubnet", AddressPrefix = "10.26.2.0/26", },
                },
            };
            var vnetLro = await rg.GetVirtualNetworks().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("vnet-"), vnetData);
            _network = vnetLro.Value;
            _networkIdentifier = _network.Id;

            PublicIPAddressData ipData = new PublicIPAddressData()
            {
                Location = Location.WestUS2,
                PublicIPAllocationMethod = IPAllocationMethod.Static,
                Sku = new PublicIPAddressSku() { Name = PublicIPAddressSkuName.Standard },
            };
            var ipLro = await rg.GetPublicIPAddresses().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("publicIp-"), ipData);
            _publicIPAddress = ipLro.Value;
            _publicIPAddressIdentifier = _publicIPAddress.Id;

            AzureFirewallData firewallData = new AzureFirewallData();
            firewallData.Location = Location.WestUS2;
            firewallData.IpConfigurations.Add(new AzureFirewallIPConfiguration()
            {
                Name = "fwpip",
                PublicIPAddress = new WritableSubResource() { Id = _publicIPAddressIdentifier },
                Subnet = new WritableSubResource() { Id = _networkIdentifier.ToString() + "/subnets/AzureFirewallSubnet" },
            });
            var firewallLro = await rg.GetAzureFirewalls().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("firewall-"), firewallData);
            _firewall = firewallLro.Value;
            _firewallIdentifier = _firewall.Id;

            StopSessionRecording();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
            _network = await _resourceGroup.GetVirtualNetworks().GetAsync(_networkIdentifier.Name);
            _publicIPAddress = await _resourceGroup.GetPublicIPAddresses().GetAsync(_publicIPAddressIdentifier.Name);
            _firewall = await _resourceGroup.GetAzureFirewalls().GetAsync(_firewallIdentifier.Name);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to research how to associate with firewalls")]
        public async Task CreateOrUpdate()
        {
            string FirewallPolicyName = Recording.GenerateAssetName("policy-");
            FirewallPolicyData data = new FirewallPolicyData();
            data.Location = Location.WestUS2;
            await _resourceGroup.GetFirewallPolicies().CreateOrUpdateAsync(FirewallPolicyName, data);
        }
    }
}
