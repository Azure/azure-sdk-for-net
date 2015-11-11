namespace Network.Tests.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Test;
    using Networks.Tests.Helpers;
    using ResourceGroups.Tests;
    using Xunit;

    public class RouteTableTests
    {
        [Fact]
        public void EmptyRouteTableTest()
        {
            var handler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient =
                    NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/routeTables");
                
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup { Location = location });

                string routeTableName = TestUtilities.GenerateName();

                var routeTable = new RouteTable() { Location = location, };

                // Put RouteTable
                var putRouteTableResponse =
                    networkResourceProviderClient.RouteTables.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        routeTable);

                Assert.Equal(HttpStatusCode.OK, putRouteTableResponse.StatusCode);
                Assert.Equal("Succeeded", putRouteTableResponse.Status);

                // Get RouteTable
                var getRouteTableResponse = networkResourceProviderClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);

                Assert.Equal(routeTableName, getRouteTableResponse.RouteTable.Name);
                Assert.False(getRouteTableResponse.RouteTable.Routes.Any());

                // List RouteTable
                var listRouteTableResponse = networkResourceProviderClient.RouteTables.List(resourceGroupName);

                Assert.Equal(HttpStatusCode.OK, listRouteTableResponse.StatusCode);
                Assert.Equal(1, listRouteTableResponse.RouteTables.Count);
                Assert.Equal(getRouteTableResponse.RouteTable.Name, listRouteTableResponse.RouteTables[0].Name);
                Assert.Equal(getRouteTableResponse.RouteTable.Id, listRouteTableResponse.RouteTables[0].Id);

                // Delete RouteTable
                var deleteRouteTableResponse = networkResourceProviderClient.RouteTables.Delete(
                    resourceGroupName,
                    routeTableName);
                Assert.Equal(HttpStatusCode.OK, deleteRouteTableResponse.StatusCode);

                // Verify delete
                listRouteTableResponse = networkResourceProviderClient.RouteTables.List(resourceGroupName);

                Assert.Equal(HttpStatusCode.OK, listRouteTableResponse.StatusCode);
                Assert.Equal(0, listRouteTableResponse.RouteTables.Count);
            }
        }

        [Fact]
        public void RouteTableApiTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient =
                    NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/routeTables");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup { Location = location });

                string routeTableName = TestUtilities.GenerateName();
                string route1Name = TestUtilities.GenerateName();
                string route2Name = TestUtilities.GenerateName();

                var routeTable = new RouteTable() { Location = location, };

                // Add a route
                var route1 = new Route()
                                {
                                    AddressPrefix = "192.168.1.0/24",
                                    Name = route1Name,
                                    NextHopIpAddress = "23.108.1.1",
                                    NextHopType = RouteNextHopType.VirtualAppliance
                                };

                routeTable.Routes.Add(route1);

                // Put RouteTable
                var putRouteTableResponse =
                    networkResourceProviderClient.RouteTables.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        routeTable);

                Assert.Equal(HttpStatusCode.OK, putRouteTableResponse.StatusCode);
                Assert.Equal("Succeeded", putRouteTableResponse.Status);

                // Get RouteTable
                var getRouteTableResponse = networkResourceProviderClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);

                Assert.Equal(routeTableName, getRouteTableResponse.RouteTable.Name);
                Assert.Equal(1, getRouteTableResponse.RouteTable.Routes.Count);
                Assert.Equal(route1Name, getRouteTableResponse.RouteTable.Routes[0].Name);
                Assert.Equal("192.168.1.0/24", getRouteTableResponse.RouteTable.Routes[0].AddressPrefix);
                Assert.Equal("23.108.1.1", getRouteTableResponse.RouteTable.Routes[0].NextHopIpAddress);
                Assert.Equal(RouteNextHopType.VirtualAppliance, getRouteTableResponse.RouteTable.Routes[0].NextHopType);

                // Add another route
                var route2 = new Route()
                {
                    AddressPrefix = "10.0.1.0/24",
                    Name = route2Name,
                    NextHopType = RouteNextHopType.VnetLocal
                };
                getRouteTableResponse.RouteTable.Routes.Add(route2);

                networkResourceProviderClient.RouteTables.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        getRouteTableResponse.RouteTable);

                getRouteTableResponse = networkResourceProviderClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);
                Assert.Equal(routeTableName, getRouteTableResponse.RouteTable.Name);
                Assert.Equal(2, getRouteTableResponse.RouteTable.Routes.Count);
                Assert.Equal(route2Name, getRouteTableResponse.RouteTable.Routes[1].Name);
                Assert.Equal("10.0.1.0/24", getRouteTableResponse.RouteTable.Routes[1].AddressPrefix);
                Assert.True(string.IsNullOrEmpty(getRouteTableResponse.RouteTable.Routes[1].NextHopIpAddress));
                Assert.Equal(RouteNextHopType.VnetLocal, getRouteTableResponse.RouteTable.Routes[1].NextHopType);


                // Delete a route
                getRouteTableResponse.RouteTable.Routes.RemoveAt(0);

                networkResourceProviderClient.RouteTables.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        getRouteTableResponse.RouteTable);

                getRouteTableResponse = networkResourceProviderClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);
                Assert.Equal(routeTableName, getRouteTableResponse.RouteTable.Name);
                Assert.Equal(1, getRouteTableResponse.RouteTable.Routes.Count);
                Assert.Equal(route2Name, getRouteTableResponse.RouteTable.Routes[0].Name);
                Assert.Equal("10.0.1.0/24", getRouteTableResponse.RouteTable.Routes[0].AddressPrefix);
                Assert.True(string.IsNullOrEmpty(getRouteTableResponse.RouteTable.Routes[0].NextHopIpAddress));
                Assert.Equal(RouteNextHopType.VnetLocal, getRouteTableResponse.RouteTable.Routes[0].NextHopType);

                // Delete RouteTable
                var deleteRouteTableResponse = networkResourceProviderClient.RouteTables.Delete(
                    resourceGroupName,
                    routeTableName);
                Assert.Equal(HttpStatusCode.OK, deleteRouteTableResponse.StatusCode);

                // Verify delete
                var listRouteTableResponse = networkResourceProviderClient.RouteTables.List(resourceGroupName);

                Assert.Equal(HttpStatusCode.OK, listRouteTableResponse.StatusCode);
                Assert.Equal(0, listRouteTableResponse.RouteTables.Count);
            }
        }

        [Fact]
        public void SubnetRouteTableTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient =
                    NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/routeTables");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup { Location = location });

                string routeTableName = TestUtilities.GenerateName();
                string route1Name = TestUtilities.GenerateName();

                var routeTable = new RouteTable() { Location = location, };

                var route1 = new Route()
                {
                    AddressPrefix = "192.168.1.0/24",
                    Name = route1Name,
                    NextHopIpAddress = "23.108.1.1",
                    NextHopType = RouteNextHopType.VirtualAppliance
                };

                routeTable.Routes.Add(route1);

                // Put RouteTable
                var putRouteTableResponse =
                    networkResourceProviderClient.RouteTables.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        routeTable);

                Assert.Equal(HttpStatusCode.OK, putRouteTableResponse.StatusCode);
                Assert.Equal("Succeeded", putRouteTableResponse.Status);

                // Get RouteTable
                var getRouteTableResponse = networkResourceProviderClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);

                // Verify that the subnet reference is null
                Assert.False(getRouteTableResponse.RouteTable.Subnets.Any());

                // Create Vnet with subnet and add a route table
                string vnetName = TestUtilities.GenerateName();
                string subnetName = TestUtilities.GenerateName();

                var vnet = new VirtualNetwork()
                {
                    Location = location,

                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                    {
                        "10.0.0.0/16",
                    }
                    },
                    DhcpOptions = new DhcpOptions()
                    {
                        DnsServers = new List<string>()
                    {
                        "10.1.1.1",
                        "10.1.2.4"
                    }
                    },
                    Subnets = new List<Subnet>()
                    {
                        new Subnet()
                        {
                            Name = subnetName,
                            AddressPrefix = "10.0.0.0/24",
                            RouteTable = new ResourceId()
                                {
                                    Id = getRouteTableResponse.RouteTable.Id,
                                }
                        }
                    }
                };

                var putVnetResponse = networkResourceProviderClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);
                Assert.Equal(HttpStatusCode.OK, putVnetResponse.StatusCode);

                var getSubnetResponse = networkResourceProviderClient.Subnets.Get(resourceGroupName, vnetName, subnetName);
                Assert.Equal(getSubnetResponse.Subnet.RouteTable.Id, getRouteTableResponse.RouteTable.Id);

                // Get RouteTable
                getRouteTableResponse = networkResourceProviderClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);
                Assert.Equal(1, getRouteTableResponse.RouteTable.Subnets.Count);
                Assert.Equal(getSubnetResponse.Subnet.Id, getRouteTableResponse.RouteTable.Subnets[0].Id);
            }
        }
    }
}
