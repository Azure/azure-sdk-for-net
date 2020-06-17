// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class RouteTableTests : NetworkTestsManagementClientBase
    {
        public RouteTableTests(bool isAsync) : base(isAsync)
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

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task EmptyRouteTableTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/routeTables");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
            string routeTableName = Recording.GenerateAssetName("azsmnet");
            RouteTable routeTable = new RouteTable() { Location = location, };

            // Put RouteTable
            RouteTablesCreateOrUpdateOperation putRouteTableResponseOperation = await NetworkManagementClient.RouteTables.StartCreateOrUpdateAsync(resourceGroupName, routeTableName, routeTable);
            Response<RouteTable> putRouteTableResponse = await WaitForCompletionAsync(putRouteTableResponseOperation);
            Assert.AreEqual("Succeeded", putRouteTableResponse.Value.ProvisioningState.ToString());

            // Get RouteTable
            Response<RouteTable> getRouteTableResponse = await NetworkManagementClient.RouteTables.GetAsync(resourceGroupName, routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Name);
            Assert.False(getRouteTableResponse.Value.Routes.Any());

            // List RouteTable
            AsyncPageable<RouteTable> listRouteTableResponseAP = NetworkManagementClient.RouteTables.ListAsync(resourceGroupName);
            List<RouteTable> listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(listRouteTableResponse);
            Assert.AreEqual(getRouteTableResponse.Value.Name, listRouteTableResponse.First().Name);
            Assert.AreEqual(getRouteTableResponse.Value.Id, listRouteTableResponse.First().Id);

            // Delete RouteTable
            RouteTablesDeleteOperation deleteOperation = await NetworkManagementClient.RouteTables.StartDeleteAsync(resourceGroupName, routeTableName);
            await WaitForCompletionAsync(deleteOperation);

            // Verify delete
            listRouteTableResponseAP = NetworkManagementClient.RouteTables.ListAsync(resourceGroupName);
            listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();

            Assert.IsEmpty(listRouteTableResponse);
        }

        [Test]
        public async Task RouteTableApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/routeTables");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
            string routeTableName = Recording.GenerateAssetName("azsmnet");
            string route1Name = Recording.GenerateAssetName("azsmnet");
            string route2Name = Recording.GenerateAssetName("azsmnet");

            RouteTable routeTable = new RouteTable() { Location = location, };
            routeTable.Routes = new List<Route>();

            // Add a route
            Route route1 = new Route()
            {
                AddressPrefix = "192.168.1.0/24",
                Name = route1Name,
                NextHopIpAddress = "23.108.1.1",
                NextHopType = RouteNextHopType.VirtualAppliance
            };

            routeTable.Routes.Add(route1);

            // Put RouteTable
            RouteTablesCreateOrUpdateOperation putRouteTableResponseOperation = await NetworkManagementClient.RouteTables.StartCreateOrUpdateAsync(resourceGroupName, routeTableName, routeTable);
            Response<RouteTable> putRouteTableResponse = await WaitForCompletionAsync(putRouteTableResponseOperation);
            Assert.AreEqual("Succeeded", putRouteTableResponse.Value.ProvisioningState.ToString());

            // Get RouteTable
            Response<RouteTable> getRouteTableResponse = await NetworkManagementClient.RouteTables.GetAsync(resourceGroupName, routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Name);
            Assert.AreEqual(1, getRouteTableResponse.Value.Routes.Count);
            Assert.AreEqual(route1Name, getRouteTableResponse.Value.Routes[0].Name);
            Assert.AreEqual("192.168.1.0/24", getRouteTableResponse.Value.Routes[0].AddressPrefix);
            Assert.AreEqual("23.108.1.1", getRouteTableResponse.Value.Routes[0].NextHopIpAddress);
            Assert.AreEqual(RouteNextHopType.VirtualAppliance, getRouteTableResponse.Value.Routes[0].NextHopType);

            // Add another route
            Route route2 = new Route()
            {
                AddressPrefix = "10.0.1.0/24",
                Name = route2Name,
                NextHopType = RouteNextHopType.VnetLocal
            };
            getRouteTableResponse.Value.Routes.Add(route2);

            await NetworkManagementClient.RouteTables.StartCreateOrUpdateAsync(resourceGroupName, routeTableName, getRouteTableResponse);

            getRouteTableResponse = await NetworkManagementClient.RouteTables.GetAsync(resourceGroupName, routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Name);
            Assert.AreEqual(2, getRouteTableResponse.Value.Routes.Count);
            Assert.AreEqual(route2Name, getRouteTableResponse.Value.Routes[1].Name);
            Assert.AreEqual("10.0.1.0/24", getRouteTableResponse.Value.Routes[1].AddressPrefix);
            Assert.True(string.IsNullOrEmpty(getRouteTableResponse.Value.Routes[1].NextHopIpAddress));
            Assert.AreEqual(RouteNextHopType.VnetLocal, getRouteTableResponse.Value.Routes[1].NextHopType);

            // Delete a route
            getRouteTableResponse.Value.Routes.RemoveAt(0);

            await NetworkManagementClient.RouteTables.StartCreateOrUpdateAsync(resourceGroupName, routeTableName, getRouteTableResponse);

            getRouteTableResponse = await NetworkManagementClient.RouteTables.GetAsync(resourceGroupName, routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Name);
            Assert.AreEqual(1, getRouteTableResponse.Value.Routes.Count);
            Assert.AreEqual(route2Name, getRouteTableResponse.Value.Routes[0].Name);
            Assert.AreEqual("10.0.1.0/24", getRouteTableResponse.Value.Routes[0].AddressPrefix);
            Assert.True(string.IsNullOrEmpty(getRouteTableResponse.Value.Routes[0].NextHopIpAddress));
            Assert.AreEqual(RouteNextHopType.VnetLocal, getRouteTableResponse.Value.Routes[0].NextHopType);

            // Delete RouteTable
            RouteTablesDeleteOperation deleteOperation = await NetworkManagementClient.RouteTables.StartDeleteAsync(resourceGroupName, routeTableName);
            await WaitForCompletionAsync(deleteOperation);

            // Verify delete
            AsyncPageable<RouteTable> listRouteTableResponseAP = NetworkManagementClient.RouteTables.ListAsync(resourceGroupName);
            List<RouteTable> listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listRouteTableResponse);
        }

        [Test]
        public async Task SubnetRouteTableTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/routeTables");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
            string routeTableName = Recording.GenerateAssetName("azsmnet");
            string route1Name = Recording.GenerateAssetName("azsmnet");

            RouteTable routeTable = new RouteTable() { Location = location, };
            routeTable.Routes = new List<Route>();

            Route route1 = new Route()
            {
                AddressPrefix = "192.168.1.0/24",
                Name = route1Name,
                NextHopIpAddress = "23.108.1.1",
                NextHopType = RouteNextHopType.VirtualAppliance
            };

            routeTable.Routes.Add(route1);

            // Put RouteTable
            RouteTablesCreateOrUpdateOperation putRouteTableResponseOperation = await NetworkManagementClient.RouteTables.StartCreateOrUpdateAsync(resourceGroupName, routeTableName, routeTable);
            Response<RouteTable> putRouteTableResponse = await WaitForCompletionAsync(putRouteTableResponseOperation);
            Assert.AreEqual("Succeeded", putRouteTableResponse.Value.ProvisioningState.ToString());

            // Get RouteTable
            Response<RouteTable> getRouteTableResponse = await NetworkManagementClient.RouteTables.GetAsync(resourceGroupName, routeTableName);

            // Verify that the subnet reference is null
            Assert.Null(getRouteTableResponse.Value.Subnets);

            // Create Vnet with subnet and add a route table
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            var vnet = new VirtualNetwork()
            {
                Location = location,

                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = new List<string>() { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = new List<string>() { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = new List<Subnet>()
                {
                    new Subnet()
                    {
                        Name = subnetName,
                        AddressPrefix = "10.0.0.0/24",
                        RouteTable = new RouteTable()
                        {
                            Id = getRouteTableResponse.Value.Id,
                        }
                    }
                }
            };

            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            Response<VirtualNetwork> putVnetResponse = await WaitForCompletionAsync(putVnetResponseOperation);
            Assert.AreEqual("Succeeded", putVnetResponse.Value.ProvisioningState.ToString());

            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);
            Assert.AreEqual(getSubnetResponse.Value.RouteTable.Id, getRouteTableResponse.Value.Id);

            // Get RouteTable
            getRouteTableResponse = await NetworkManagementClient.RouteTables.GetAsync(resourceGroupName, routeTableName);
            Assert.AreEqual(1, getRouteTableResponse.Value.Subnets.Count);
            Assert.AreEqual(getSubnetResponse.Value.Id, getRouteTableResponse.Value.Subnets[0].Id);
        }
    }
}
