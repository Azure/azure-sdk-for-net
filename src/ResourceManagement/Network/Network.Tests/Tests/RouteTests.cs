namespace Network.Tests.Tests
{
    using System.Linq;
    using System.Net;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Test;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Networks.Tests.Helpers;
    using ResourceGroups.Tests;
    using Xunit;

    public class RouteTests
    {
        [Fact]
        public void RoutesApiTest()
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

                // Get Route
                var getRouteResponse = networkManagementClient.Routes.Get(
                    resourceGroupName,
                    routeTableName,
                    route1Name);

                Assert.Equal(routeTableName, getRouteTableResponse.Name);
                Assert.Equal(1, getRouteTableResponse.Routes.Count);
                Assert.Equal(getRouteResponse.Name, getRouteTableResponse.Routes[0].Name);
                Assert.Equal(getRouteResponse.AddressPrefix, getRouteTableResponse.Routes[0].AddressPrefix);
                Assert.Equal(getRouteResponse.NextHopIpAddress, getRouteTableResponse.Routes[0].NextHopIpAddress);
                Assert.Equal(getRouteResponse.NextHopType, getRouteTableResponse.Routes[0].NextHopType);

                // Add another route
                var route2 = new Route()
                {
                    AddressPrefix = "10.0.1.0/24",
                    Name = route2Name,
                    NextHopType = RouteNextHopType.VnetLocal
                };

                networkManagementClient.Routes.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        route2Name,
                        route2);

                getRouteTableResponse = networkManagementClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);
                Assert.Equal(routeTableName, getRouteTableResponse.Name);
                Assert.Equal(2, getRouteTableResponse.Routes.Count);
                Assert.Equal(route2Name, getRouteTableResponse.Routes[1].Name);
                Assert.Equal("10.0.1.0/24", getRouteTableResponse.Routes[1].AddressPrefix);
                Assert.True(string.IsNullOrEmpty(getRouteTableResponse.Routes[1].NextHopIpAddress));
                Assert.Equal(RouteNextHopType.VnetLocal, getRouteTableResponse.Routes[1].NextHopType);

                var getRouteResponse2 = networkManagementClient.Routes.Get(
                    resourceGroupName,
                    routeTableName,
                    route2Name);

                Assert.Equal(getRouteResponse2.Name, getRouteTableResponse.Routes[1].Name);
                Assert.Equal(getRouteResponse2.AddressPrefix, getRouteTableResponse.Routes[1].AddressPrefix);
                Assert.Equal(getRouteResponse2.NextHopIpAddress, getRouteTableResponse.Routes[1].NextHopIpAddress);
                Assert.Equal(getRouteResponse2.NextHopType, getRouteTableResponse.Routes[1].NextHopType);

                // list route
                var listRouteResponse = networkManagementClient.Routes.List(
                    resourceGroupName,
                    routeTableName);

                Assert.Equal(2, listRouteResponse.Count());
                Assert.Equal(getRouteResponse.Name, listRouteResponse.First().Name);
                Assert.Equal(getRouteResponse.AddressPrefix, listRouteResponse.First().AddressPrefix);
                Assert.Equal(getRouteResponse.NextHopIpAddress, listRouteResponse.First().NextHopIpAddress);
                Assert.Equal(getRouteResponse.NextHopType, listRouteResponse.First().NextHopType);
                Assert.Equal(getRouteResponse2.Name, listRouteResponse.ElementAt(1).Name);
                Assert.Equal(getRouteResponse2.AddressPrefix, listRouteResponse.ElementAt(1).AddressPrefix);
                Assert.Equal(getRouteResponse2.NextHopIpAddress, listRouteResponse.ElementAt(1).NextHopIpAddress);
                Assert.Equal(getRouteResponse2.NextHopType, listRouteResponse.ElementAt(1).NextHopType);

                // Delete a route
                networkManagementClient.Routes.Delete(resourceGroupName, routeTableName, route1Name);

                listRouteResponse = networkManagementClient.Routes.List(
                    resourceGroupName,
                    routeTableName);

                Assert.Equal(1, listRouteResponse.Count());
                Assert.Equal(getRouteResponse2.Name, listRouteResponse.First().Name);
                Assert.Equal(getRouteResponse2.AddressPrefix, listRouteResponse.First().AddressPrefix);
                Assert.Equal(getRouteResponse2.NextHopIpAddress, listRouteResponse.First().NextHopIpAddress);
                Assert.Equal(getRouteResponse2.NextHopType, listRouteResponse.First().NextHopType);

                // Delete route
                networkManagementClient.Routes.Delete(
                    resourceGroupName,
                    routeTableName,
                    route2Name);

                listRouteResponse = networkManagementClient.Routes.List(
                    resourceGroupName,
                    routeTableName);

                Assert.Equal(0, listRouteResponse.Count());

                // Delete RouteTable
                networkManagementClient.RouteTables.Delete(
                    resourceGroupName,
                    routeTableName);
                
                // Verify delete
                var listRouteTableResponse = networkManagementClient.RouteTables.List(resourceGroupName);

                Assert.Equal(0, listRouteTableResponse.Count());
            }
        }

        [Fact]
        public void RoutesHopTypeTest()
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
                string route3Name = TestUtilities.GenerateName();
                string route4Name = TestUtilities.GenerateName();

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

                // Add another route
                var route2 = new Route()
                {
                    AddressPrefix = "10.0.1.0/24",
                    Name = route2Name,
                    NextHopType = RouteNextHopType.VnetLocal
                };

                networkManagementClient.Routes.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        route2Name,
                        route2);

                // Add another route
                var route3 = new Route()
                {
                    AddressPrefix = "0.0.0.0/0",
                    Name = route3Name,
                    NextHopType = RouteNextHopType.Internet
                };

                networkManagementClient.Routes.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        route3Name,
                        route3);

                // Add another route
                var route4 = new Route()
                {
                    AddressPrefix = "10.0.2.0/24",
                    Name = route4Name,
                    NextHopType = RouteNextHopType.None
                };

                networkManagementClient.Routes.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        route4Name,
                        route4);

                getRouteTableResponse = networkManagementClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);
                Assert.Equal(routeTableName, getRouteTableResponse.Name);
                Assert.Equal(4, getRouteTableResponse.Routes.Count);
                Assert.Equal(route2Name, getRouteTableResponse.Routes[1].Name);
                Assert.Equal(RouteNextHopType.VirtualAppliance, getRouteTableResponse.Routes[0].NextHopType);
                Assert.Equal(RouteNextHopType.VnetLocal, getRouteTableResponse.Routes[1].NextHopType);
                Assert.Equal(RouteNextHopType.Internet, getRouteTableResponse.Routes[2].NextHopType);
                Assert.Equal(RouteNextHopType.None, getRouteTableResponse.Routes[3].NextHopType);

                // Delete RouteTable
                networkManagementClient.RouteTables.Delete(resourceGroupName, routeTableName);

                // Verify delete
                var listRouteTableResponse = networkManagementClient.RouteTables.List(resourceGroupName);

                Assert.Equal(0, listRouteTableResponse.Count());
            }
        }
    }
}