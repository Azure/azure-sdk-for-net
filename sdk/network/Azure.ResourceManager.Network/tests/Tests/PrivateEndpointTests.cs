// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class PrivateEndpointTests : NetworkServiceClientTestBase
    {
        private VirtualNetwork virtualNetwork;
        private GenericResource privateDnsZone;

        public PrivateEndpointTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        private async Task<Response<ResourceGroup>> createResourceGroup()
        {
            var name = Recording.GenerateAssetName("pe_rg");
            // TODO: create it through resource management, or we can instrutment ArmClient?
            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/privateEndpoints");
            await ResourceGroupsOperations.CreateOrUpdateAsync(name, new Resources.Models.ResourceGroup(location));
            return await ArmClient.DefaultSubscription.GetResourceGroups().GetAsync(name);
        }

        // TODO: create it through resource management, or we can instrutment ArmClient?
        private async Task<Response<VirtualNetwork>> createVirtualNetwork(ResourceGroup resourceGroup)
        {
            var name = Recording.GenerateAssetName("pe_vnet");
            var vnet = new VirtualNetworkData()
            {
                Location = TestEnvironment.Location,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = { new SubnetData() {
                    Name = "default",
                    AddressPrefix = "10.0.1.0/24",
                    PrivateEndpointNetworkPolicies = VirtualNetworkPrivateEndpointNetworkPolicies.Disabled
                }}
            };
            return await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(name, vnet);
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
            await CleanUpVirtualNetwork();
        }

        private async Task CleanUpVirtualNetwork()
        {
            if (virtualNetwork != null)
            {
                await virtualNetwork.DeleteAsync();
            }
            if (privateDnsZone != null)
            {
                await privateDnsZone.DeleteAsync();
            }
        }

        [Test]
        public async Task PrivateEndpointTest()
        {
            var resourceGroup = (await createResourceGroup()).Value;
            virtualNetwork = (await createVirtualNetwork(resourceGroup)).Value;

            // create
            var privateEndpointContainer = resourceGroup.GetPrivateEndpoints();
            var name = Recording.GenerateAssetName("pe");
            System.Console.WriteLine($"Subnet ID: {virtualNetwork.Data.Subnets[0].Id}");
            var privateEndpointData = new PrivateEndpointData
            {
                Location = TestEnvironment.Location,
                Subnet = virtualNetwork.Data.Subnets[0],
                PrivateLinkServiceConnections = {
                    new PrivateLinkServiceConnection
                    {
                        Name = Recording.GenerateAssetName("pec"),
                        // TODO: externalize or create the service on-demand, like virtual network
                        PrivateLinkServiceId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/sdktest7669/providers/Microsoft.KeyVault/vaults/TierRuanKeyVaultJustTest",
                        RequestMessage = "SDK test",
                        GroupIds = { "vault" }
                    }
                },
            };

            var privateEndpoint = (await privateEndpointContainer.CreateOrUpdateAsync(name, privateEndpointData)).Value;
            Assert.AreEqual(name, privateEndpoint.Data.Name);
            Assert.AreEqual(TestEnvironment.Location, privateEndpoint.Data.Location);
            Assert.IsEmpty(privateEndpoint.Data.Tags);

            // get
            privateEndpoint = (await privateEndpointContainer.GetAsync(name)).Value;
            Assert.AreEqual(name, privateEndpoint.Data.Name);
            Assert.AreEqual(TestEnvironment.Location, privateEndpoint.Data.Location);
            Assert.IsEmpty(privateEndpoint.Data.Tags);

            // update
            privateEndpointData.Tags.Add("test", "test");
            privateEndpoint = (await privateEndpointContainer.CreateOrUpdateAsync(name, privateEndpointData)).Value;
            Assert.AreEqual(name, privateEndpoint.Data.Name);
            Assert.AreEqual(TestEnvironment.Location, privateEndpoint.Data.Location);
            Assert.That(privateEndpoint.Data.Tags, Has.Count.EqualTo(1));
            Assert.That(privateEndpoint.Data.Tags, Does.ContainKey("test").WithValue("test"));

            // list
            var privateEndpoints = (await privateEndpointContainer.GetAllAsync().ToEnumerableAsync());
            Assert.That(privateEndpoints, Has.Count.EqualTo(1));
            Assert.AreEqual(name, privateEndpoint.Data.Name);

            // delete
            await privateEndpoint.DeleteAsync();

            // list all
            privateEndpoints = (await ArmClient.DefaultSubscription.GetPrivateEndpointsAsync().ToEnumerableAsync());
            Assert.That(privateEndpoints, Has.None.Matches<PrivateEndpoint>(p => p.Data.Name == name));
        }

        [Test]
        public async Task PrivateDnsZoneGroupTest()
        {
            var resourceGroup = (await createResourceGroup()).Value;
            virtualNetwork = (await createVirtualNetwork(resourceGroup)).Value;

            // create
            var privateEndpointContainer = resourceGroup.GetPrivateEndpoints();
            var name = Recording.GenerateAssetName("pe");
            System.Console.WriteLine($"Subnet ID: {virtualNetwork.Data.Subnets[0].Id}");
            var privateEndpointData = new PrivateEndpointData
            {
                Location = TestEnvironment.Location,
                Subnet = virtualNetwork.Data.Subnets[0],
                PrivateLinkServiceConnections = {
                    new PrivateLinkServiceConnection
                    {
                        Name = Recording.GenerateAssetName("pec"),
                        // TODO: externalize or create the service on-demand, like virtual network
                        PrivateLinkServiceId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/sdktest7669/providers/Microsoft.KeyVault/vaults/TierRuanKeyVaultJustTest",
                        RequestMessage = "SDK test",
                        GroupIds = { "vault" }
                    }
                },
            };

            var privateEndpoint = (await privateEndpointContainer.CreateOrUpdateAsync(name, privateEndpointData)).Value;

            var privateDnsZoneName = Recording.GenerateAssetName("private_dns_zone");
            var privateDnsZoneResourceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{resourceGroup.Data.Name}/Microsoft.Network/privateDnsZones/{privateDnsZoneName}";
            privateDnsZone = ArmClient.DefaultSubscription.GetGenericResources().CreateOrUpdate(privateDnsZoneResourceId, new GenericResourceData { }).Value;

            var privateDnsZoneGroupName = Recording.GenerateAssetName("private_dns_zone_group");
            var privateDnsZoneGroupContainer = privateEndpoint.GetPrivateDnsZoneGroups();
            var privateDnsZoneGroup = (await privateDnsZoneGroupContainer.CreateOrUpdateAsync(privateDnsZoneGroupName, new PrivateDnsZoneGroupData {
                PrivateDnsZoneConfigs = {
                    new PrivateDnsZoneConfig
                    {
                        Name = privateDnsZoneName,
                        PrivateDnsZoneId = privateDnsZone.Id,
                    }
                }
            })).Value;
            Assert.IsNotEmpty(privateDnsZoneGroup.Data.PrivateDnsZoneConfigs);
            Assert.That(privateDnsZoneGroup.Data.PrivateDnsZoneConfigs, Has.Count.EqualTo(1));
            Assert.AreEqual(privateDnsZoneName, privateDnsZoneGroup.Data.PrivateDnsZoneConfigs[0].Name);
            Assert.AreEqual(privateDnsZone.Id, privateDnsZoneGroup.Data.PrivateDnsZoneConfigs[0].PrivateDnsZoneId);

            // list
            var groups = (await privateDnsZoneGroupContainer.GetAllAsync().ToEnumerableAsync());
            Assert.That(groups, Has.Count.EqualTo(1));
            privateDnsZoneGroup = groups[0];
            Assert.IsNotEmpty(privateDnsZoneGroup.Data.PrivateDnsZoneConfigs);
            Assert.That(privateDnsZoneGroup.Data.PrivateDnsZoneConfigs, Has.Count.EqualTo(1));
            Assert.AreEqual(privateDnsZoneName, privateDnsZoneGroup.Data.PrivateDnsZoneConfigs[0].Name);
            Assert.AreEqual(privateDnsZone.Id, privateDnsZoneGroup.Data.PrivateDnsZoneConfigs[0].PrivateDnsZoneId);

            // get
            privateDnsZoneGroup = (await privateDnsZoneGroupContainer.GetAsync(privateDnsZoneGroupName)).Value;
            Assert.IsNotEmpty(privateDnsZoneGroup.Data.PrivateDnsZoneConfigs);
            Assert.That(privateDnsZoneGroup.Data.PrivateDnsZoneConfigs, Has.Count.EqualTo(1));
            Assert.AreEqual(privateDnsZoneName, privateDnsZoneGroup.Data.PrivateDnsZoneConfigs[0].Name);
            Assert.AreEqual(privateDnsZone.Id, privateDnsZoneGroup.Data.PrivateDnsZoneConfigs[0].PrivateDnsZoneId);

            // update
            privateDnsZoneGroup = (await privateDnsZoneGroupContainer.CreateOrUpdateAsync(privateDnsZoneGroupName, new PrivateDnsZoneGroupData {})).Value;
            Assert.IsEmpty(privateDnsZoneGroup.Data.PrivateDnsZoneConfigs);

            // delete
            await privateDnsZoneGroup.DeleteAsync();

            // list again
            groups = (await privateDnsZoneGroupContainer.GetAllAsync().ToEnumerableAsync());
            Assert.IsEmpty(groups);

            await privateEndpoint.DeleteAsync();
        }

        [Test]
        public async Task AvailablePrivateEndpointTypeTest()
        {
            var types = await ArmClient.DefaultSubscription.GetAvailablePrivateEndpointTypesAsync(TestEnvironment.Location).ToEnumerableAsync();
            Assert.IsNotEmpty(types);
        }

        [Test]
        public async Task AvailablePrivateEndpointInResourceGroupTypeTest()
        {
            var resourceGroup = (await createResourceGroup()).Value;
            var types = await ArmClient.DefaultSubscription.GetAvailablePrivateEndpointTypesByResourceGroupAsync(TestEnvironment.Location, resourceGroup.Data.Name).ToEnumerableAsync();
            Assert.IsNotEmpty(types);
        }
    }
}
