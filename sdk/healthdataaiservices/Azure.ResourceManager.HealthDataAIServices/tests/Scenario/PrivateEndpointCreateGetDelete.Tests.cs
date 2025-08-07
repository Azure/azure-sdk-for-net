// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HealthDataAIServices.Tests
{
    [TestFixture]
    public class PrivateEndpointCreateGetDelete : HealthDataAIServicesManagementTestBase
    {
        public PrivateEndpointCreateGetDelete() : base(true)
        {
        }

        //         [SetUp]
        //         public async Task ClearAndInitialize()
        //         {
        //             if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
        //             {
        //                 await InitializeClients();
        //             }
        //         }
        //
        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task TestAddressCRUDOperations()
        {
            ResourceGroupResource rg = await CreateResourceGroup("testRg");
            string deidServiceName = Recording.GenerateAssetName("deidService");

            // Create
            DeidServiceResource deidService = (await rg.GetDeidServices().CreateOrUpdateAsync(WaitUntil.Completed, deidServiceName, new DeidServiceData(Location))).Value;

            // Create Private Link
            string privateEndpointName = Recording.GenerateAssetName("deid-pe-");
            PrivateEndpointResource _ = await CreatePrivateEndpoint(privateEndpointName, rg, deidService.Id);

            var peCollection = deidService.GetHealthDataAIServicesPrivateEndpointConnectionResources();

            int count = 0;
            await foreach (var peI in peCollection.GetAllAsync())
            {
                count++;
                Assert.IsTrue(peI.Data.Name.StartsWith(privateEndpointName), $"PrivateEndpointConnection ({peI.Data.Name}) name should start with {privateEndpointName}.");
            }

            Assert.AreEqual(1, count, "Should only have one PrivateEndpointConnection.");
        }

        protected async Task<PrivateEndpointResource> CreatePrivateEndpoint(string name, ResourceGroupResource rg, ResourceIdentifier DeidServiceId)
        {
            var vnetName = Recording.GenerateAssetName("vnet-");
            var pecName = Recording.GenerateAssetName("pec");
            var vnet = new VirtualNetworkData()
            {
                Location = AzureLocation.WestUS,
                Subnets = { new SubnetData() {
                    Name = "default",
                    AddressPrefix = "10.0.1.0/24",
                    PrivateEndpointNetworkPolicy = VirtualNetworkPrivateEndpointNetworkPolicy.Disabled
                }}
            };
            vnet.AddressPrefixes.Add("10.0.0.0/16");
            vnet.DhcpOptionsDnsServers.Add("10.1.1.1");
            vnet.DhcpOptionsDnsServers.Add("10.1.2.4");

            VirtualNetworkResource vnetResource = (await rg.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet)).Value;
            ResourceIdentifier subnetID = vnetResource.Data.Subnets[0].Id;

            var privateEndpointData = new PrivateEndpointData
            {
                Location = AzureLocation.WestUS,
                Subnet = new SubnetData() { Id = subnetID },
                ManualPrivateLinkServiceConnections = {
                    new NetworkPrivateLinkServiceConnection
                    {
                        Name = pecName,
                        PrivateLinkServiceId = DeidServiceId,

                        RequestMessage = "SDK test",
                        GroupIds = { "deid" }
                    }
                },
            };

            return (await rg.GetPrivateEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, name, privateEndpointData)).Value;
        }
    }
}
