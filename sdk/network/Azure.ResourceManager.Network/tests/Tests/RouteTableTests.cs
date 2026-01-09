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

namespace Azure.ResourceManager.Network.Tests
{
    [ClientTestFixture(true, "2021-04-01", "2018-11-01")]
    public class RouteTableTests : NetworkServiceClientTestBase
    {
        private SubscriptionResource _subscription;

        public RouteTableTests(bool isAsync, string apiVersion)
        : base(isAsync, RouteTableResource.ResourceType, apiVersion)
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
        }

        [Test]
        [RecordedTest]
        public async Task EmptyRouteTableTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);
            string routeTableName = Recording.GenerateAssetName("azsmnet");
            var routeTable = new RouteTableData() { Location = location, };

            // Put RouteTable
            var routeTableCollection = resourceGroup.GetRouteTables();
            var putRouteTableResponseOperation = await routeTableCollection.CreateOrUpdateAsync(WaitUntil.Completed, routeTableName, routeTable);
            Response<RouteTableResource> putRouteTableResponse = await putRouteTableResponseOperation.WaitForCompletionAsync();;
            Assert.That(putRouteTableResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get RouteTable
            Response<RouteTableResource> getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            Assert.Multiple(() =>
            {
                Assert.That(getRouteTableResponse.Value.Data.Name, Is.EqualTo(routeTableName));
                Assert.That(getRouteTableResponse.Value.Data.Routes.Any(), Is.False);
            });

            // List RouteTable
            AsyncPageable<RouteTableResource> listRouteTableResponseAP = routeTableCollection.GetAllAsync();
            List<RouteTableResource> listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(listRouteTableResponse);
            Assert.Multiple(() =>
            {
                Assert.That(listRouteTableResponse.First().Data.Name, Is.EqualTo(getRouteTableResponse.Value.Data.Name));
                Assert.That(listRouteTableResponse.First().Id, Is.EqualTo(getRouteTableResponse.Value.Id));
            });

            // Delete RouteTable
            var deleteOperation = await getRouteTableResponse.Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Verify delete
            listRouteTableResponseAP = routeTableCollection.GetAllAsync();
            listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();

            Assert.That(listRouteTableResponse, Is.Empty);
        }

        [Test]
        [RecordedTest]
        public async Task RouteTableApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);
            string routeTableName = Recording.GenerateAssetName("azsmnet");
            string route1Name = Recording.GenerateAssetName("azsmnet");
            string route2Name = Recording.GenerateAssetName("azsmnet");

            var routeTable = new RouteTableData() { Location = location, };

            // Add a route
            var route1 = new RouteData()
            {
                AddressPrefix = "192.168.1.0/24",
                Name = route1Name,
                NextHopIPAddress = "23.108.1.1",
                NextHopType = RouteNextHopType.VirtualAppliance
            };

            routeTable.Routes.Add(route1);

            // Put RouteTable
            var routeTableCollection = resourceGroup.GetRouteTables();
            var putRouteTableResponseOperation = await routeTableCollection.CreateOrUpdateAsync(WaitUntil.Completed, routeTableName, routeTable);
            Response<RouteTableResource> putRouteTableResponse = await putRouteTableResponseOperation.WaitForCompletionAsync();;
            Assert.That(putRouteTableResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get RouteTable
            Response<RouteTableResource> getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            Assert.Multiple(() =>
            {
                Assert.That(getRouteTableResponse.Value.Data.Name, Is.EqualTo(routeTableName));
                Assert.That(getRouteTableResponse.Value.Data.Routes, Has.Count.EqualTo(1));
            });
            Assert.Multiple(() =>
            {
                Assert.That(getRouteTableResponse.Value.Data.Routes[0].Name, Is.EqualTo(route1Name));
                Assert.That(getRouteTableResponse.Value.Data.Routes[0].AddressPrefix, Is.EqualTo("192.168.1.0/24"));
                Assert.That(getRouteTableResponse.Value.Data.Routes[0].NextHopIPAddress, Is.EqualTo("23.108.1.1"));
                Assert.That(getRouteTableResponse.Value.Data.Routes[0].NextHopType, Is.EqualTo(RouteNextHopType.VirtualAppliance));
            });

            // Add another route
            var route2 = new RouteData()
            {
                AddressPrefix = "10.0.1.0/24",
                Name = route2Name,
                NextHopType = RouteNextHopType.VnetLocal
            };
            getRouteTableResponse.Value.Data.Routes.Add(route2);

            await routeTableCollection.CreateOrUpdateAsync(WaitUntil.Completed, routeTableName, getRouteTableResponse.Value.Data);

            getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            Assert.Multiple(() =>
            {
                Assert.That(getRouteTableResponse.Value.Data.Name, Is.EqualTo(routeTableName));
                Assert.That(getRouteTableResponse.Value.Data.Routes, Has.Count.EqualTo(2));
            });
            Assert.Multiple(() =>
            {
                Assert.That(getRouteTableResponse.Value.Data.Routes[1].Name, Is.EqualTo(route2Name));
                Assert.That(getRouteTableResponse.Value.Data.Routes[1].AddressPrefix, Is.EqualTo("10.0.1.0/24"));
                Assert.That(string.IsNullOrEmpty(getRouteTableResponse.Value.Data.Routes[1].NextHopIPAddress), Is.True);
                Assert.That(getRouteTableResponse.Value.Data.Routes[1].NextHopType, Is.EqualTo(RouteNextHopType.VnetLocal));
            });

            // Delete a route
            getRouteTableResponse.Value.Data.Routes.RemoveAt(0);

            await routeTableCollection.CreateOrUpdateAsync(WaitUntil.Completed, routeTableName, getRouteTableResponse.Value.Data);

            getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            Assert.Multiple(() =>
            {
                Assert.That(getRouteTableResponse.Value.Data.Name, Is.EqualTo(routeTableName));
                Assert.That(getRouteTableResponse.Value.Data.Routes, Has.Count.EqualTo(1));
            });
            Assert.Multiple(() =>
            {
                Assert.That(getRouteTableResponse.Value.Data.Routes[0].Name, Is.EqualTo(route2Name));
                Assert.That(getRouteTableResponse.Value.Data.Routes[0].AddressPrefix, Is.EqualTo("10.0.1.0/24"));
                Assert.That(string.IsNullOrEmpty(getRouteTableResponse.Value.Data.Routes[0].NextHopIPAddress), Is.True);
                Assert.That(getRouteTableResponse.Value.Data.Routes[0].NextHopType, Is.EqualTo(RouteNextHopType.VnetLocal));
            });

            // Delete RouteTable
            var deleteOperation = await getRouteTableResponse.Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Verify delete
            AsyncPageable<RouteTableResource> listRouteTableResponseAP = routeTableCollection.GetAllAsync();
            List<RouteTableResource> listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();
            Assert.That(listRouteTableResponse, Is.Empty);
        }

        [Test]
        [RecordedTest]
        public async Task SubnetRouteTableTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);
            string routeTableName = Recording.GenerateAssetName("azsmnet");
            string route1Name = Recording.GenerateAssetName("azsmnet");

            var routeTable = new RouteTableData() { Location = location, };

            var route1 = new RouteData()
            {
                AddressPrefix = "192.168.1.0/24",
                Name = route1Name,
                NextHopIPAddress = "23.108.1.1",
                NextHopType = RouteNextHopType.VirtualAppliance
            };

            routeTable.Routes.Add(route1);

            // Put RouteTable
            var routeTableCollection = resourceGroup.GetRouteTables();
            var putRouteTableResponseOperation = await routeTableCollection.CreateOrUpdateAsync(WaitUntil.Completed, routeTableName, routeTable);
            Response<RouteTableResource> putRouteTableResponse = await putRouteTableResponseOperation.WaitForCompletionAsync();;
            Assert.That(putRouteTableResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get RouteTable
            Response<RouteTableResource> getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);

            // Verify that the subnet reference is null
            Assert.That(getRouteTableResponse.Value.Data.Subnets, Is.Empty);

            // Create Vnet with subnet and add a route table
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            var vnet = new VirtualNetworkData()
            {
                Location = location,

                AddressSpace = new VirtualNetworkAddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = {
                    new SubnetData()
                    {
                        Name = subnetName,
                        AddressPrefix = "10.0.0.0/24",
                        RouteTable = new RouteTableData()
                        {
                            Id = getRouteTableResponse.Value.Id,
                        }
                    }
                }
            };

            var putVnetResponseOperation = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet);
            Response<VirtualNetworkResource> putVnetResponse = await putVnetResponseOperation.WaitForCompletionAsync();;
            Assert.That(putVnetResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            Response<SubnetResource> getSubnetResponse = await putVnetResponse.Value.GetSubnets().GetAsync(subnetName);
            Assert.That(getRouteTableResponse.Value.Id.ToString(), Is.EqualTo(getSubnetResponse.Value.Data.RouteTable.Id));

            // Get RouteTable
            getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            Assert.That(getRouteTableResponse.Value.Data.Subnets, Has.Count.EqualTo(1));
            Assert.That(getRouteTableResponse.Value.Data.Subnets[0].Id, Is.EqualTo(getSubnetResponse.Value.Id));
        }
    }
}
