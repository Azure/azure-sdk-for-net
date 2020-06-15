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
    public class RouteTests : NetworkTestsManagementClientBase
    {
        public RouteTests(bool isAsync) : base(isAsync)
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
        public async Task RoutesApiTest()
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

            // Get Route
            Response<Route> getRouteResponse = await NetworkManagementClient.Routes.GetAsync(resourceGroupName, routeTableName, route1Name);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Name);
            Assert.AreEqual(1, getRouteTableResponse.Value.Routes.Count);
            Assert.AreEqual(getRouteResponse.Value.Name, getRouteTableResponse.Value.Routes[0].Name);
            Assert.AreEqual(getRouteResponse.Value.AddressPrefix, getRouteTableResponse.Value.Routes[0].AddressPrefix);
            Assert.AreEqual(getRouteResponse.Value.NextHopIpAddress, getRouteTableResponse.Value.Routes[0].NextHopIpAddress);
            Assert.AreEqual(getRouteResponse.Value.NextHopType, getRouteTableResponse.Value.Routes[0].NextHopType);

            // Add another route
            Route route2 = new Route()
            {
                AddressPrefix = "10.0.1.0/24",
                Name = route2Name,
                NextHopType = RouteNextHopType.VnetLocal
            };

            await NetworkManagementClient.Routes.StartCreateOrUpdateAsync(resourceGroupName, routeTableName, route2Name, route2);

            getRouteTableResponse = await NetworkManagementClient.RouteTables.GetAsync(resourceGroupName, routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Name);
            Assert.AreEqual(2, getRouteTableResponse.Value.Routes.Count);
            Assert.AreEqual(route2Name, getRouteTableResponse.Value.Routes[1].Name);
            Assert.AreEqual("10.0.1.0/24", getRouteTableResponse.Value.Routes[1].AddressPrefix);
            Assert.True(string.IsNullOrEmpty(getRouteTableResponse.Value.Routes[1].NextHopIpAddress));
            Assert.AreEqual(RouteNextHopType.VnetLocal, getRouteTableResponse.Value.Routes[1].NextHopType);

            Response<Route> getRouteResponse2 = await NetworkManagementClient.Routes.GetAsync(resourceGroupName, routeTableName, route2Name);
            Assert.AreEqual(getRouteResponse2.Value.Name, getRouteTableResponse.Value.Routes[1].Name);
            Assert.AreEqual(getRouteResponse2.Value.AddressPrefix, getRouteTableResponse.Value.Routes[1].AddressPrefix);
            Assert.AreEqual(getRouteResponse2.Value.NextHopIpAddress, getRouteTableResponse.Value.Routes[1].NextHopIpAddress);
            Assert.AreEqual(getRouteResponse2.Value.NextHopType, getRouteTableResponse.Value.Routes[1].NextHopType);

            // list route
            AsyncPageable<Route> listRouteResponseAP = NetworkManagementClient.Routes.ListAsync(resourceGroupName, routeTableName);
            List<Route> listRouteResponse = await listRouteResponseAP.ToEnumerableAsync();
            Assert.AreEqual(2, listRouteResponse.Count());
            Assert.AreEqual(getRouteResponse.Value.Name, listRouteResponse.First().Name);
            Assert.AreEqual(getRouteResponse.Value.AddressPrefix, listRouteResponse.First().AddressPrefix);
            Assert.AreEqual(getRouteResponse.Value.NextHopIpAddress, listRouteResponse.First().NextHopIpAddress);
            Assert.AreEqual(getRouteResponse.Value.NextHopType, listRouteResponse.First().NextHopType);
            Assert.AreEqual(getRouteResponse2.Value.Name, listRouteResponse.ElementAt(1).Name);
            Assert.AreEqual(getRouteResponse2.Value.AddressPrefix, listRouteResponse.ElementAt(1).AddressPrefix);
            Assert.AreEqual(getRouteResponse2.Value.NextHopIpAddress, listRouteResponse.ElementAt(1).NextHopIpAddress);
            Assert.AreEqual(getRouteResponse2.Value.NextHopType, listRouteResponse.ElementAt(1).NextHopType);

            // Delete a route
            await NetworkManagementClient.Routes.StartDeleteAsync(resourceGroupName, routeTableName, route1Name);
            listRouteResponseAP = NetworkManagementClient.Routes.ListAsync(resourceGroupName, routeTableName);
            listRouteResponse = await listRouteResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(listRouteResponse);
            Assert.AreEqual(getRouteResponse2.Value.Name, listRouteResponse.First().Name);
            Assert.AreEqual(getRouteResponse2.Value.AddressPrefix, listRouteResponse.First().AddressPrefix);
            Assert.AreEqual(getRouteResponse2.Value.NextHopIpAddress, listRouteResponse.First().NextHopIpAddress);
            Assert.AreEqual(getRouteResponse2.Value.NextHopType, listRouteResponse.First().NextHopType);

            // Delete route
            await NetworkManagementClient.Routes.StartDeleteAsync(resourceGroupName, routeTableName, route2Name);

            listRouteResponseAP = NetworkManagementClient.Routes.ListAsync(resourceGroupName, routeTableName);
            listRouteResponse = await listRouteResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listRouteResponse);

            // Delete RouteTable
            await NetworkManagementClient.RouteTables.StartDeleteAsync(resourceGroupName, routeTableName);

            // Verify delete
            AsyncPageable<RouteTable> listRouteTableResponseAP = NetworkManagementClient.RouteTables.ListAsync(resourceGroupName);
            List<RouteTable> listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listRouteTableResponse);
        }

        [Test]
        public async Task RoutesHopTypeTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/routeTables");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
            string routeTableName = Recording.GenerateAssetName("azsmnet");
            string route1Name = Recording.GenerateAssetName("azsmnet");
            string route2Name = Recording.GenerateAssetName("azsmnet");
            string route3Name = Recording.GenerateAssetName("azsmnet");
            string route4Name = Recording.GenerateAssetName("azsmnet");

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
            RouteTablesCreateOrUpdateOperation putRouteTableResponseOperation =
                await NetworkManagementClient.RouteTables.StartCreateOrUpdateAsync(resourceGroupName, routeTableName, routeTable);
            Response<RouteTable> putRouteTableResponse = await WaitForCompletionAsync(putRouteTableResponseOperation);
            Assert.AreEqual("Succeeded", putRouteTableResponse.Value.ProvisioningState.ToString());

            // Get RouteTable
            Response<RouteTable> getRouteTableResponse = await NetworkManagementClient.RouteTables.GetAsync(resourceGroupName, routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Name);
            Assert.AreEqual(1, getRouteTableResponse.Value.Routes.Count);
            Assert.AreEqual(route1Name, getRouteTableResponse.Value.Routes[0].Name);

            // Add another route
            Route route2 = new Route()
            {
                AddressPrefix = "10.0.1.0/24",
                Name = route2Name,
                NextHopType = RouteNextHopType.VnetLocal
            };
            await NetworkManagementClient.Routes.StartCreateOrUpdateAsync(resourceGroupName, routeTableName, route2Name, route2);

            // Add another route
            Route route3 = new Route()
            {
                AddressPrefix = "0.0.0.0/0",
                Name = route3Name,
                NextHopType = RouteNextHopType.Internet
            };
            await NetworkManagementClient.Routes.StartCreateOrUpdateAsync(resourceGroupName, routeTableName, route3Name, route3);

            // Add another route
            Route route4 = new Route()
            {
                AddressPrefix = "10.0.2.0/24",
                Name = route4Name,
                NextHopType = RouteNextHopType.None
            };
            await NetworkManagementClient.Routes.StartCreateOrUpdateAsync(resourceGroupName, routeTableName, route4Name, route4);

            getRouteTableResponse = await NetworkManagementClient.RouteTables.GetAsync(resourceGroupName, routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Name);
            Assert.AreEqual(4, getRouteTableResponse.Value.Routes.Count);
            Assert.AreEqual(route2Name, getRouteTableResponse.Value.Routes[1].Name);
            Assert.AreEqual(RouteNextHopType.VirtualAppliance, getRouteTableResponse.Value.Routes[0].NextHopType);
            Assert.AreEqual(RouteNextHopType.VnetLocal, getRouteTableResponse.Value.Routes[1].NextHopType);
            Assert.AreEqual(RouteNextHopType.Internet, getRouteTableResponse.Value.Routes[2].NextHopType);
            Assert.AreEqual(RouteNextHopType.None, getRouteTableResponse.Value.Routes[3].NextHopType);

            // Delete RouteTable
            await NetworkManagementClient.RouteTables.StartDeleteAsync(resourceGroupName, routeTableName);

            // Verify delete
            AsyncPageable<RouteTable> listRouteTableResponseAP = NetworkManagementClient.RouteTables.ListAsync(resourceGroupName);
            List<RouteTable> listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listRouteTableResponse);
        }
    }
}
