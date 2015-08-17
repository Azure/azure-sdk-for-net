namespace Network.Tests.Tests
{
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

    public class RouteTests
    {
        [Fact]
        public void RoutesApiTest()
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

                // Get Route
                var getRouteResponse = networkResourceProviderClient.Routes.Get(
                    resourceGroupName,
                    routeTableName,
                    route1Name);

                Assert.Equal(routeTableName, getRouteTableResponse.RouteTable.Name);
                Assert.Equal(1, getRouteTableResponse.RouteTable.Routes.Count);
                Assert.Equal(getRouteResponse.Route.Name, getRouteTableResponse.RouteTable.Routes[0].Name);
                Assert.Equal(getRouteResponse.Route.AddressPrefix, getRouteTableResponse.RouteTable.Routes[0].AddressPrefix);
                Assert.Equal(getRouteResponse.Route.NextHopIpAddress, getRouteTableResponse.RouteTable.Routes[0].NextHopIpAddress);
                Assert.Equal(getRouteResponse.Route.NextHopType, getRouteTableResponse.RouteTable.Routes[0].NextHopType);

                // Add another route
                var route2 = new Route()
                {
                    AddressPrefix = "10.0.1.0/24",
                    Name = route2Name,
                    NextHopType = RouteNextHopType.VnetLocal
                };
                
                networkResourceProviderClient.Routes.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        route2Name,
                        route2);

                getRouteTableResponse = networkResourceProviderClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);
                Assert.Equal(routeTableName, getRouteTableResponse.RouteTable.Name);
                Assert.Equal(2, getRouteTableResponse.RouteTable.Routes.Count);
                Assert.Equal(route2Name, getRouteTableResponse.RouteTable.Routes[1].Name);
                Assert.Equal("10.0.1.0/24", getRouteTableResponse.RouteTable.Routes[1].AddressPrefix);
                Assert.True(string.IsNullOrEmpty(getRouteTableResponse.RouteTable.Routes[1].NextHopIpAddress));
                Assert.Equal(RouteNextHopType.VnetLocal, getRouteTableResponse.RouteTable.Routes[1].NextHopType);

                var getRouteResponse2 = networkResourceProviderClient.Routes.Get(
                    resourceGroupName,
                    routeTableName,
                    route2Name);

                Assert.Equal(getRouteResponse2.Route.Name, getRouteTableResponse.RouteTable.Routes[1].Name);
                Assert.Equal(getRouteResponse2.Route.AddressPrefix, getRouteTableResponse.RouteTable.Routes[1].AddressPrefix);
                Assert.Equal(getRouteResponse2.Route.NextHopIpAddress, getRouteTableResponse.RouteTable.Routes[1].NextHopIpAddress);
                Assert.Equal(getRouteResponse2.Route.NextHopType, getRouteTableResponse.RouteTable.Routes[1].NextHopType);

                // list route
                var listRouteResponse = networkResourceProviderClient.Routes.List(
                    resourceGroupName,
                    routeTableName);

                Assert.Equal(2, listRouteResponse.Routes.Count);
                Assert.Equal(getRouteResponse.Route.Name, listRouteResponse.Routes[0].Name);
                Assert.Equal(getRouteResponse.Route.AddressPrefix, listRouteResponse.Routes[0].AddressPrefix);
                Assert.Equal(getRouteResponse.Route.NextHopIpAddress, listRouteResponse.Routes[0].NextHopIpAddress);
                Assert.Equal(getRouteResponse.Route.NextHopType, listRouteResponse.Routes[0].NextHopType);
                Assert.Equal(getRouteResponse2.Route.Name, listRouteResponse.Routes[1].Name);
                Assert.Equal(getRouteResponse2.Route.AddressPrefix, listRouteResponse.Routes[1].AddressPrefix);
                Assert.Equal(getRouteResponse2.Route.NextHopIpAddress, listRouteResponse.Routes[1].NextHopIpAddress);
                Assert.Equal(getRouteResponse2.Route.NextHopType, listRouteResponse.Routes[1].NextHopType);

                // Delete a route
                var deleteRouteResponse = networkResourceProviderClient.Routes.Delete(
                    resourceGroupName,
                    routeTableName,
                    route1Name);
                Assert.Equal(HttpStatusCode.OK, deleteRouteResponse.StatusCode);

                listRouteResponse = networkResourceProviderClient.Routes.List(
                    resourceGroupName,
                    routeTableName);
                
                Assert.Equal(1, listRouteResponse.Routes.Count);
                Assert.Equal(getRouteResponse2.Route.Name, listRouteResponse.Routes[0].Name);
                Assert.Equal(getRouteResponse2.Route.AddressPrefix, listRouteResponse.Routes[0].AddressPrefix);
                Assert.Equal(getRouteResponse2.Route.NextHopIpAddress, listRouteResponse.Routes[0].NextHopIpAddress);
                Assert.Equal(getRouteResponse2.Route.NextHopType, listRouteResponse.Routes[0].NextHopType);

                // Delete route
                deleteRouteResponse = networkResourceProviderClient.Routes.Delete(
                    resourceGroupName,
                    routeTableName,
                    route2Name);

                listRouteResponse = networkResourceProviderClient.Routes.List(
                    resourceGroupName,
                    routeTableName);

                Assert.Equal(0, listRouteResponse.Routes.Count);

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
        public void RoutesHopTypeTest()
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
                string route3Name = TestUtilities.GenerateName();
                string route4Name = TestUtilities.GenerateName();

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

                // Add another route
                var route2 = new Route()
                {
                    AddressPrefix = "10.0.1.0/24",
                    Name = route2Name,
                    NextHopType = RouteNextHopType.VnetLocal
                };

                networkResourceProviderClient.Routes.CreateOrUpdate(
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

                networkResourceProviderClient.Routes.CreateOrUpdate(
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

                networkResourceProviderClient.Routes.CreateOrUpdate(
                        resourceGroupName,
                        routeTableName,
                        route4Name,
                        route4);

                getRouteTableResponse = networkResourceProviderClient.RouteTables.Get(
                    resourceGroupName,
                    routeTableName);
                Assert.Equal(routeTableName, getRouteTableResponse.RouteTable.Name);
                Assert.Equal(4, getRouteTableResponse.RouteTable.Routes.Count);
                Assert.Equal(route2Name, getRouteTableResponse.RouteTable.Routes[1].Name);
                Assert.Equal(RouteNextHopType.VirtualAppliance, getRouteTableResponse.RouteTable.Routes[0].NextHopType);
                Assert.Equal(RouteNextHopType.VnetLocal, getRouteTableResponse.RouteTable.Routes[1].NextHopType);
                Assert.Equal(RouteNextHopType.Internet, getRouteTableResponse.RouteTable.Routes[2].NextHopType);
                Assert.Equal(RouteNextHopType.None, getRouteTableResponse.RouteTable.Routes[3].NextHopType);

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
    }
}
