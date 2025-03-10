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
            Assert.AreEqual("Succeeded", putRouteTableResponse.Value.Data.ProvisioningState.ToString());

            // Get RouteTable
            Response<RouteTableResource> getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Data.Name);
            Assert.False(getRouteTableResponse.Value.Data.Routes.Any());

            // List RouteTable
            AsyncPageable<RouteTableResource> listRouteTableResponseAP = routeTableCollection.GetAllAsync();
            List<RouteTableResource> listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(listRouteTableResponse);
            Assert.AreEqual(getRouteTableResponse.Value.Data.Name, listRouteTableResponse.First().Data.Name);
            Assert.AreEqual(getRouteTableResponse.Value.Id, listRouteTableResponse.First().Id);

            // Delete RouteTable
            var deleteOperation = await getRouteTableResponse.Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Verify delete
            listRouteTableResponseAP = routeTableCollection.GetAllAsync();
            listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();

            Assert.IsEmpty(listRouteTableResponse);
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
            Assert.AreEqual("Succeeded", putRouteTableResponse.Value.Data.ProvisioningState.ToString());

            // Get RouteTable
            Response<RouteTableResource> getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Data.Name);
            Assert.AreEqual(1, getRouteTableResponse.Value.Data.Routes.Count);
            Assert.AreEqual(route1Name, getRouteTableResponse.Value.Data.Routes[0].Name);
            Assert.AreEqual("192.168.1.0/24", getRouteTableResponse.Value.Data.Routes[0].AddressPrefix);
            Assert.AreEqual("23.108.1.1", getRouteTableResponse.Value.Data.Routes[0].NextHopIPAddress);
            Assert.AreEqual(RouteNextHopType.VirtualAppliance, getRouteTableResponse.Value.Data.Routes[0].NextHopType);

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
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Data.Name);
            Assert.AreEqual(2, getRouteTableResponse.Value.Data.Routes.Count);
            Assert.AreEqual(route2Name, getRouteTableResponse.Value.Data.Routes[1].Name);
            Assert.AreEqual("10.0.1.0/24", getRouteTableResponse.Value.Data.Routes[1].AddressPrefix);
            Assert.True(string.IsNullOrEmpty(getRouteTableResponse.Value.Data.Routes[1].NextHopIPAddress));
            Assert.AreEqual(RouteNextHopType.VnetLocal, getRouteTableResponse.Value.Data.Routes[1].NextHopType);

            // Delete a route
            getRouteTableResponse.Value.Data.Routes.RemoveAt(0);

            await routeTableCollection.CreateOrUpdateAsync(WaitUntil.Completed, routeTableName, getRouteTableResponse.Value.Data);

            getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Data.Name);
            Assert.AreEqual(1, getRouteTableResponse.Value.Data.Routes.Count);
            Assert.AreEqual(route2Name, getRouteTableResponse.Value.Data.Routes[0].Name);
            Assert.AreEqual("10.0.1.0/24", getRouteTableResponse.Value.Data.Routes[0].AddressPrefix);
            Assert.True(string.IsNullOrEmpty(getRouteTableResponse.Value.Data.Routes[0].NextHopIPAddress));
            Assert.AreEqual(RouteNextHopType.VnetLocal, getRouteTableResponse.Value.Data.Routes[0].NextHopType);

            // Delete RouteTable
            var deleteOperation = await getRouteTableResponse.Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Verify delete
            AsyncPageable<RouteTableResource> listRouteTableResponseAP = routeTableCollection.GetAllAsync();
            List<RouteTableResource> listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listRouteTableResponse);
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
            Assert.AreEqual("Succeeded", putRouteTableResponse.Value.Data.ProvisioningState.ToString());

            // Get RouteTable
            Response<RouteTableResource> getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);

            // Verify that the subnet reference is null
            Assert.IsEmpty(getRouteTableResponse.Value.Data.Subnets);

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
            Assert.AreEqual("Succeeded", putVnetResponse.Value.Data.ProvisioningState.ToString());

            Response<SubnetResource> getSubnetResponse = await putVnetResponse.Value.GetSubnets().GetAsync(subnetName);
            Assert.AreEqual(getSubnetResponse.Value.Data.RouteTable.Id, getRouteTableResponse.Value.Id.ToString());

            // Get RouteTable
            getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            Assert.AreEqual(1, getRouteTableResponse.Value.Data.Subnets.Count);
            Assert.AreEqual(getSubnetResponse.Value.Id, getRouteTableResponse.Value.Data.Subnets[0].Id);
        }
    }
}
