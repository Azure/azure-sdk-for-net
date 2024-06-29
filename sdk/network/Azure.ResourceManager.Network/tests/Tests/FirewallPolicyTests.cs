// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class FirewallPolicyTests : NetworkServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private VirtualNetworkResource _network;
        private PublicIPAddressResource _publicIPAddress;
        private AzureFirewallResource _firewall;

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
            SubscriptionResource subscription = await GlobalClient.GetDefaultSubscriptionAsync();
            var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("FirewallPolicyRG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;

            VirtualNetworkData vnetData = new VirtualNetworkData()
            {
                Location = AzureLocation.WestUS2,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.26.0.0/16", }
                },
                Subnets = {
                    new SubnetData() { Name = "Default", AddressPrefix = "10.26.1.0/26", },
                    new SubnetData() { Name = "AzureFirewallSubnet", AddressPrefix = "10.26.2.0/26", },
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

            AzureFirewallData firewallData = new AzureFirewallData();
            firewallData.Location = AzureLocation.WestUS2;
            firewallData.IPConfigurations.Add(new AzureFirewallIPConfiguration()
            {
                Name = "fwpip",
                PublicIPAddress = new WritableSubResource() { Id = _publicIPAddressIdentifier },
                Subnet = new WritableSubResource() { Id = _networkIdentifier.AppendChildResource("subnets", "AzureFirewallSubnet") },
            });
            var firewallLro = await rg.GetAzureFirewalls().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("firewall-"), firewallData);
            _firewall = firewallLro.Value;
            _firewallIdentifier = _firewall.Id;

            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
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
            data.Location = AzureLocation.WestUS2;
            await _resourceGroup.GetFirewallPolicies().CreateOrUpdateAsync(WaitUntil.Completed, FirewallPolicyName, data);
        }
    }
}
