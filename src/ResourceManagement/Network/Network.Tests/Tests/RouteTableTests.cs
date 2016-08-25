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
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Networks.Tests.Helpers;
    using ResourceGroups.Tests;
    using Xunit;
    using Microsoft.Azure.Test.HttpRecorder;

    public class RouteTableTests
    {
        public RouteTableTests()
        {
            HttpMockServer.RecordsDirectory = "SessionRecords";
        }

        [Fact]
        public void EmptyRouteTableTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/routeTables");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup { Location = location });

                string routeTableName = TestUtilities.GenerateName();

                var routeTable = new RouteTable() { Location = location, };

                // Put RouteTable
                var putRouteTableResponse =
                    networkManagementClient.RouteTables.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        routeTable);

                Assert.Equal("Succeeded", putRouteTableResponse.ProvisioningState);

                // Get RouteTable
                var getRouteTableResponse = networkManagementClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);

                Assert.Equal(routeTableName, getRouteTableResponse.Name);
                Assert.False(getRouteTableResponse.Routes.Any());

                // List RouteTable
                var listRouteTableResponse = networkManagementClient.RouteTables.List(resourceGroupName);

                Assert.Equal(1, listRouteTableResponse.Count());
                Assert.Equal(getRouteTableResponse.Name, listRouteTableResponse.First().Name);
                Assert.Equal(getRouteTableResponse.Id, listRouteTableResponse.First().Id);

                // Delete RouteTable
                networkManagementClient.RouteTables.Delete(resourceGroupName, routeTableName);
                
                // Verify delete
                listRouteTableResponse = networkManagementClient.RouteTables.List(resourceGroupName);

                Assert.Equal(0, listRouteTableResponse.Count());
            }
        }

        [Fact]
        public void RouteTableApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/routeTables");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup { Location = location });

                string routeTableName = TestUtilities.GenerateName();
                string route1Name = TestUtilities.GenerateName();
                string route2Name = TestUtilities.GenerateName();

                var routeTable = new RouteTable() { Location = location, };
                routeTable.Routes = new List<Route>();

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
                    networkManagementClient.RouteTables.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        routeTable);

                Assert.Equal("Succeeded", putRouteTableResponse.ProvisioningState);

                // Get RouteTable
                var getRouteTableResponse = networkManagementClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);

                Assert.Equal(routeTableName, getRouteTableResponse.Name);
                Assert.Equal(1, getRouteTableResponse.Routes.Count);
                Assert.Equal(route1Name, getRouteTableResponse.Routes[0].Name);
                Assert.Equal("192.168.1.0/24", getRouteTableResponse.Routes[0].AddressPrefix);
                Assert.Equal("23.108.1.1", getRouteTableResponse.Routes[0].NextHopIpAddress);
                Assert.Equal(RouteNextHopType.VirtualAppliance, getRouteTableResponse.Routes[0].NextHopType);

                // Add another route
                var route2 = new Route()
                {
                    AddressPrefix = "10.0.1.0/24",
                    Name = route2Name,
                    NextHopType = RouteNextHopType.VnetLocal
                };
                getRouteTableResponse.Routes.Add(route2);

                networkManagementClient.RouteTables.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        getRouteTableResponse);

                getRouteTableResponse = networkManagementClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);
                Assert.Equal(routeTableName, getRouteTableResponse.Name);
                Assert.Equal(2, getRouteTableResponse.Routes.Count);
                Assert.Equal(route2Name, getRouteTableResponse.Routes[1].Name);
                Assert.Equal("10.0.1.0/24", getRouteTableResponse.Routes[1].AddressPrefix);
                Assert.True(string.IsNullOrEmpty(getRouteTableResponse.Routes[1].NextHopIpAddress));
                Assert.Equal(RouteNextHopType.VnetLocal, getRouteTableResponse.Routes[1].NextHopType);


                // Delete a route
                getRouteTableResponse.Routes.RemoveAt(0);

                networkManagementClient.RouteTables.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        getRouteTableResponse);

                getRouteTableResponse = networkManagementClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);
                Assert.Equal(routeTableName, getRouteTableResponse.Name);
                Assert.Equal(1, getRouteTableResponse.Routes.Count);
                Assert.Equal(route2Name, getRouteTableResponse.Routes[0].Name);
                Assert.Equal("10.0.1.0/24", getRouteTableResponse.Routes[0].AddressPrefix);
                Assert.True(string.IsNullOrEmpty(getRouteTableResponse.Routes[0].NextHopIpAddress));
                Assert.Equal(RouteNextHopType.VnetLocal, getRouteTableResponse.Routes[0].NextHopType);

                // Delete RouteTable
                networkManagementClient.RouteTables.Delete(resourceGroupName, routeTableName);
                
                // Verify delete
                var listRouteTableResponse = networkManagementClient.RouteTables.List(resourceGroupName);

                Assert.Equal(0, listRouteTableResponse.Count());
            }
        }

        [Fact]
        public void SubnetRouteTableTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/routeTables");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup { Location = location });

                string routeTableName = TestUtilities.GenerateName();
                string route1Name = TestUtilities.GenerateName();

                var routeTable = new RouteTable() { Location = location, };
                routeTable.Routes = new List<Route>();

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
                    networkManagementClient.RouteTables.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        routeTable);

                Assert.Equal("Succeeded", putRouteTableResponse.ProvisioningState);

                // Get RouteTable
                var getRouteTableResponse = networkManagementClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);

                // Verify that the subnet reference is null
                Assert.Null(getRouteTableResponse.Subnets);

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
                            RouteTable = new RouteTable()
                                {
                                    Id = getRouteTableResponse.Id,
                                }
                        }
                    }
                };

                var putVnetResponse = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);
                Assert.Equal("Succeeded", putVnetResponse.ProvisioningState);

                var getSubnetResponse = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName);
                Assert.Equal(getSubnetResponse.RouteTable.Id, getRouteTableResponse.Id);

                // Get RouteTable
                getRouteTableResponse = networkManagementClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);
                Assert.Equal(1, getRouteTableResponse.Subnets.Count);
                Assert.Equal(getSubnetResponse.Id, getRouteTableResponse.Subnets[0].Id);
            }
        }
    }
}