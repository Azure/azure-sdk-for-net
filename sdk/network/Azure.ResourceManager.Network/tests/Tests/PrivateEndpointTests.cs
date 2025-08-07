// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Network.Models;
using Azure.Core;

namespace Azure.ResourceManager.Network.Tests
{
    public class PrivateEndpointTests : NetworkServiceClientTestBase
    {
        private VirtualNetworkResource virtualNetwork;
        private GenericResource privateDnsZone;
        private ResourceGroupResource resourceGroup;
        private ResourceIdentifier storageAccountId;
        private SubscriptionResource _subscription;

        public PrivateEndpointTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
            _subscription = await ArmClient.GetDefaultSubscriptionAsync();
            resourceGroup = (await CreateResourceGroup(Recording.GenerateAssetName("pe_rg")));
        }

        // TODO: create it through resource management, or we can instrutment ArmClient?
        private async Task<Response<VirtualNetworkResource>> CreateVirtualNetwork(string vnetName)
        {
            var vnet = new VirtualNetworkData()
            {
                Location = TestEnvironment.Location,
                AddressSpace = new VirtualNetworkAddressSpace()
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
                    PrivateEndpointNetworkPolicy = VirtualNetworkPrivateEndpointNetworkPolicy.Disabled
                }}
            };
            return await resourceGroup.GetVirtualNetworks().CreateOrUpdate(WaitUntil.Completed, vnetName, vnet).WaitForCompletionAsync();
        }

        private async Task<StorageAccountResource> CreateStorageAccount(string storageAccountName)
        {
            var parameters = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardLrs), StorageKind.Storage,TestEnvironment.Location);
            return (await resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, parameters)).Value;
        }

        private async Task CleanUpVirtualNetwork()
        {
            if (virtualNetwork != null)
            {
                await virtualNetwork.DeleteAsync(WaitUntil.Completed);
            }
            if (privateDnsZone != null)
            {
                await privateDnsZone.DeleteAsync(WaitUntil.Completed);
            }
            if (storageAccountId != null)
            {
                await ArmClient.GetStorageAccountResource(storageAccountId).DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        [Ignore("We need to replace storage management with either generic resource or template")]
        public async Task PrivateEndpointTest()
        {
            var privateEndpointName = Recording.GenerateAssetName("pe");
            var vnetName = Recording.GenerateAssetName("pe_vnet");
            var storageAccountName = Recording.GenerateAssetName("testsa");
            var privateLinkServiceName = Recording.GenerateAssetName("pec");

            virtualNetwork = await CreateVirtualNetwork(vnetName);
            if (Mode == RecordedTestMode.Playback)
            {
                storageAccountId = StorageAccountResource.CreateResourceIdentifier(resourceGroup.Id.SubscriptionId, resourceGroup.Id.Name, storageAccountName);
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    var storageAccount = await CreateStorageAccount(storageAccountName);
                    storageAccountId = storageAccount.Id;
                }
            }

            // create
            var privateEndpointCollection = resourceGroup.GetPrivateEndpoints();
            System.Console.WriteLine($"SubnetResource ID: {virtualNetwork.Data.Subnets[0].Id}");
            var privateEndpointData = new PrivateEndpointData
            {
                Location = TestEnvironment.Location,
                Subnet = virtualNetwork.Data.Subnets[0],
                PrivateLinkServiceConnections = {
                    new NetworkPrivateLinkServiceConnection
                    {
                        Name = privateLinkServiceName,
                        // TODO: externalize or create the service on-demand, like virtual network
                        //PrivateLinkServiceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{resourceGroup.Data.Name}/providers/Microsoft.Storage/storageAccounts/{storageAccount.Name}",
                        PrivateLinkServiceId = storageAccountId,
                        RequestMessage = "SDK test",
                        GroupIds = { "storage" }
                    }
                },
            };

            var privateEndpoint = (await privateEndpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointName, privateEndpointData)).Value;
            Assert.AreEqual(privateEndpointName, privateEndpoint.Data.Name);
            Assert.AreEqual(TestEnvironment.Location, privateEndpoint.Data.Location);
            Assert.IsEmpty(privateEndpoint.Data.Tags);

            // get
            privateEndpoint = (await privateEndpointCollection.GetAsync(privateEndpointName)).Value;
            Assert.AreEqual(privateEndpointName, privateEndpoint.Data.Name);
            Assert.AreEqual(TestEnvironment.Location, privateEndpoint.Data.Location);
            Assert.IsEmpty(privateEndpoint.Data.Tags);

            // update
            privateEndpointData.Tags.Add("test", "test");
            privateEndpoint = (await privateEndpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointName, privateEndpointData)).Value;
            Assert.AreEqual(privateEndpointName, privateEndpoint.Data.Name);
            Assert.AreEqual(TestEnvironment.Location, privateEndpoint.Data.Location);
            Assert.That(privateEndpoint.Data.Tags, Has.Count.EqualTo(1));
            Assert.That(privateEndpoint.Data.Tags, Does.ContainKey("test").WithValue("test"));

            // list
            var privateEndpoints = (await privateEndpointCollection.GetAllAsync().ToEnumerableAsync());
            Assert.That(privateEndpoints, Has.Count.EqualTo(1));
            Assert.AreEqual(privateEndpointName, privateEndpoint.Data.Name);

            // delete
            await privateEndpoint.DeleteAsync(WaitUntil.Completed);

            // list all
            privateEndpoints = (await _subscription.GetPrivateEndpointsAsync().ToEnumerableAsync());
            Assert.That(privateEndpoints, Has.None.Matches<PrivateEndpointResource>(p => p.Data.Name == privateEndpointName));
        }

        [Test]
        [RecordedTest]
        [Ignore("We need to replace storage management with either generic resource or template")]
        public async Task PrivateDnsZoneGroupTest()
        {
            var privateEndpointName = Recording.GenerateAssetName("pe");
            var vnetName = Recording.GenerateAssetName("pe_vnet");
            var storageAccountName = Recording.GenerateAssetName("testsa");
            var privateLinkServiceName = Recording.GenerateAssetName("pec");

            virtualNetwork = await CreateVirtualNetwork(vnetName);
            if (Mode == RecordedTestMode.Playback)
            {
                storageAccountId = StorageAccountResource.CreateResourceIdentifier(resourceGroup.Id.SubscriptionId, resourceGroup.Id.Name, storageAccountName);
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    var storageAccount = await CreateStorageAccount(storageAccountName);
                    storageAccountId = storageAccount.Id;
                }
            }

            // create
            var privateEndpointCollection = resourceGroup.GetPrivateEndpoints();
            System.Console.WriteLine($"SubnetResource ID: {virtualNetwork.Data.Subnets[0].Id}");
            var privateEndpointData = new PrivateEndpointData
            {
                Location = TestEnvironment.Location,
                Subnet = virtualNetwork.Data.Subnets[0],
                PrivateLinkServiceConnections = {
                    new NetworkPrivateLinkServiceConnection
                    {
                        Name = privateLinkServiceName,
                        // TODO: externalize or create the service on-demand, like virtual network
                        //PrivateLinkServiceId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/sdktest7669/providers/Microsoft.KeyVault/vaults/TierRuanKeyVaultJustTest",
                        PrivateLinkServiceId = storageAccountId,
                        RequestMessage = "SDK test",
                        GroupIds = { "storage" }
                    }
                },
            };

            var privateEndpoint = (await privateEndpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointName, privateEndpointData)).Value;

            var privateDnsZoneName = Recording.GenerateAssetName("private_dns_zone");
            var privateDnsZoneResourceId = new ResourceIdentifier($"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{resourceGroup.Data.Name}/Microsoft.Network/privateDnsZones/{privateDnsZoneName}");
            privateDnsZone = ArmClient.GetGenericResources().CreateOrUpdate(WaitUntil.Completed, privateDnsZoneResourceId, new GenericResourceData(TestEnvironment.Location)).Value;

            var privateDnsZoneGroupName = Recording.GenerateAssetName("private_dns_zone_group");
            var privateDnsZoneGroupCollection = privateEndpoint.GetPrivateDnsZoneGroups();
            var privateDnsZoneGroup = (await privateDnsZoneGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, privateDnsZoneGroupName, new PrivateDnsZoneGroupData {
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
            var groups = (await privateDnsZoneGroupCollection.GetAllAsync().ToEnumerableAsync());
            Assert.That(groups, Has.Count.EqualTo(1));
            privateDnsZoneGroup = groups[0];
            Assert.IsNotEmpty(privateDnsZoneGroup.Data.PrivateDnsZoneConfigs);
            Assert.That(privateDnsZoneGroup.Data.PrivateDnsZoneConfigs, Has.Count.EqualTo(1));
            Assert.AreEqual(privateDnsZoneName, privateDnsZoneGroup.Data.PrivateDnsZoneConfigs[0].Name);
            Assert.AreEqual(privateDnsZone.Id, privateDnsZoneGroup.Data.PrivateDnsZoneConfigs[0].PrivateDnsZoneId);

            // get
            privateDnsZoneGroup = (await privateDnsZoneGroupCollection.GetAsync(privateDnsZoneGroupName)).Value;
            Assert.IsNotEmpty(privateDnsZoneGroup.Data.PrivateDnsZoneConfigs);
            Assert.That(privateDnsZoneGroup.Data.PrivateDnsZoneConfigs, Has.Count.EqualTo(1));
            Assert.AreEqual(privateDnsZoneName, privateDnsZoneGroup.Data.PrivateDnsZoneConfigs[0].Name);
            Assert.AreEqual(privateDnsZone.Id, privateDnsZoneGroup.Data.PrivateDnsZoneConfigs[0].PrivateDnsZoneId);

            // update
            privateDnsZoneGroup = (await privateDnsZoneGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, privateDnsZoneGroupName, new PrivateDnsZoneGroupData {})).Value;
            Assert.IsEmpty(privateDnsZoneGroup.Data.PrivateDnsZoneConfigs);

            // delete
            await privateDnsZoneGroup.DeleteAsync(WaitUntil.Completed);

            // list again
            groups = (await privateDnsZoneGroupCollection.GetAllAsync().ToEnumerableAsync());
            Assert.IsEmpty(groups);

            await privateEndpoint.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task AvailablePrivateEndpointTypeTest()
        {
            var types = await _subscription.GetAvailablePrivateEndpointTypesAsync(TestEnvironment.Location).ToEnumerableAsync();
            Assert.IsNotEmpty(types);
        }

        [Test]
        [RecordedTest]
        public async Task AvailablePrivateEndpointInResourceGroupTypeTest()
        {
            var types = await resourceGroup.GetAvailablePrivateEndpointTypesByResourceGroupAsync(TestEnvironment.Location).ToEnumerableAsync();
            Assert.IsNotEmpty(types);
        }
    }
}
