﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private VirtualNetwork virtualNetwork;
        private GenericResource privateDnsZone;
        private Resources.ResourceGroup resourceGroup;
        private StorageAccount storageAccount;
        private Subscription _subscription;

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
        private async Task<Response<VirtualNetwork>> createVirtualNetwork()
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
            return await resourceGroup.GetVirtualNetworks().CreateOrUpdate(true, name, vnet).WaitForCompletionAsync();
        }

        private async Task<StorageAccount> createStorageAccount()
        {
            var name = Recording.GenerateAssetName("testsa");
            var parameters = new StorageAccountCreateParameters(new Storage.Models.Sku(SkuName.StandardLRS),Kind.Storage,TestEnvironment.Location);
            return (await resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(true, name,parameters)).Value;
            //var storageAccountId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{resourceGroup.Data.Name}/providers/Microsoft.Storage/storageAccounts/{name}";

        //var storageParameters = new Storage.Models.StorageAccountCreateParameters(new Storage.Models.Sku(Storage.Models.SkuName.StandardLRS), Storage.Models.Kind.Storage, TestEnvironment.Location);
        //var accountOperation = await StorageManagementClient.StorageAccounts.CreateAsync(resourceGroup.Data.Name, name, storageParameters);
        //Response<Storage.Models.StorageAccount> account = await accountOperation.WaitForCompletionAsync();
        //return account.Value;

            //return (await ArmClient.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(true, storageAccountId, new GenericResourceData(TestEnvironment.Location)
            //{
            //    //Sku = new Resources.Models.Sku(),
            //    Kind = "storage",
            //})).Value;
        }

        private async Task CleanUpVirtualNetwork()
        {
            if (virtualNetwork != null)
            {
                await virtualNetwork.DeleteAsync(true);
            }
            if (privateDnsZone != null)
            {
                await privateDnsZone.DeleteAsync(true);
            }
            if (storageAccount != null)
            {
                //await StorageManagementClient.StorageAccounts.DeleteAsync(resourceGroup.Data.Name, storageAccount.Name);
                await storageAccount.DeleteAsync(true);
            }
        }

        [Test]
        [RecordedTest]
        [Ignore("We need to replace storage management with either generic resource or template")]
        public async Task PrivateEndpointTest()
        {
            virtualNetwork = (await createVirtualNetwork()).Value;
            storageAccount = await createStorageAccount();

            // create
            var privateEndpointCollection = resourceGroup.GetPrivateEndpoints();
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
                        //PrivateLinkServiceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{resourceGroup.Data.Name}/providers/Microsoft.Storage/storageAccounts/{storageAccount.Name}",
                        PrivateLinkServiceId = storageAccount.Id,
                        RequestMessage = "SDK test",
                        GroupIds = { "storage" }
                    }
                },
            };

            var privateEndpoint = (await privateEndpointCollection.CreateOrUpdateAsync(true, name, privateEndpointData)).Value;
            Assert.AreEqual(name, privateEndpoint.Data.Name);
            Assert.AreEqual(TestEnvironment.Location, privateEndpoint.Data.Location);
            Assert.IsEmpty(privateEndpoint.Data.Tags);

            // get
            privateEndpoint = (await privateEndpointCollection.GetAsync(name)).Value;
            Assert.AreEqual(name, privateEndpoint.Data.Name);
            Assert.AreEqual(TestEnvironment.Location, privateEndpoint.Data.Location);
            Assert.IsEmpty(privateEndpoint.Data.Tags);

            // update
            privateEndpointData.Tags.Add("test", "test");
            privateEndpoint = (await privateEndpointCollection.CreateOrUpdateAsync(true, name, privateEndpointData)).Value;
            Assert.AreEqual(name, privateEndpoint.Data.Name);
            Assert.AreEqual(TestEnvironment.Location, privateEndpoint.Data.Location);
            Assert.That(privateEndpoint.Data.Tags, Has.Count.EqualTo(1));
            Assert.That(privateEndpoint.Data.Tags, Does.ContainKey("test").WithValue("test"));

            // list
            var privateEndpoints = (await privateEndpointCollection.GetAllAsync().ToEnumerableAsync());
            Assert.That(privateEndpoints, Has.Count.EqualTo(1));
            Assert.AreEqual(name, privateEndpoint.Data.Name);

            // delete
            await privateEndpoint.DeleteAsync(true);

            // list all
            privateEndpoints = (await _subscription.GetPrivateEndpointsAsync().ToEnumerableAsync());
            Assert.That(privateEndpoints, Has.None.Matches<PrivateEndpoint>(p => p.Data.Name == name));
        }

        [Test]
        [RecordedTest]
        [Ignore("We need to replace storage management with either generic resource or template")]
        public async Task PrivateDnsZoneGroupTest()
        {
            virtualNetwork = (await createVirtualNetwork()).Value;
            storageAccount = await createStorageAccount();

            // create
            var privateEndpointCollection = resourceGroup.GetPrivateEndpoints();
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
                        //PrivateLinkServiceId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/sdktest7669/providers/Microsoft.KeyVault/vaults/TierRuanKeyVaultJustTest",
                        PrivateLinkServiceId = storageAccount.Id,
                        RequestMessage = "SDK test",
                        GroupIds = { "storage" }
                    }
                },
            };

            var privateEndpoint = (await privateEndpointCollection.CreateOrUpdateAsync(true, name, privateEndpointData)).Value;

            var privateDnsZoneName = Recording.GenerateAssetName("private_dns_zone");
            var privateDnsZoneResourceId = new ResourceIdentifier($"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{resourceGroup.Data.Name}/Microsoft.Network/privateDnsZones/{privateDnsZoneName}");
            privateDnsZone = ArmClient.GetGenericResources().CreateOrUpdate(true, privateDnsZoneResourceId, new GenericResourceData(TestEnvironment.Location)).Value;

            var privateDnsZoneGroupName = Recording.GenerateAssetName("private_dns_zone_group");
            var privateDnsZoneGroupCollection = privateEndpoint.GetPrivateDnsZoneGroups();
            var privateDnsZoneGroup = (await privateDnsZoneGroupCollection.CreateOrUpdateAsync(true, privateDnsZoneGroupName, new PrivateDnsZoneGroupData {
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
            privateDnsZoneGroup = (await privateDnsZoneGroupCollection.CreateOrUpdateAsync(true, privateDnsZoneGroupName, new PrivateDnsZoneGroupData {})).Value;
            Assert.IsEmpty(privateDnsZoneGroup.Data.PrivateDnsZoneConfigs);

            // delete
            await privateDnsZoneGroup.DeleteAsync(true);

            // list again
            groups = (await privateDnsZoneGroupCollection.GetAllAsync().ToEnumerableAsync());
            Assert.IsEmpty(groups);

            await privateEndpoint.DeleteAsync(true);
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
            var types = await resourceGroup.GetAvailablePrivateEndpointTypesAsync(TestEnvironment.Location).ToEnumerableAsync();
            Assert.IsNotEmpty(types);
        }
    }
}
