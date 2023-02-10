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
    public class RouteTests : NetworkServiceClientTestBase
    {
        private SubscriptionResource _subscription;

        public RouteTests(bool isAsync, string apiVersion)
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
        public async Task RoutesApiTest()
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

            // Get Route
            Response<RouteResource> getRouteResponse = await getRouteTableResponse.Value.GetRoutes().GetAsync(route1Name);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Data.Name);
            Assert.AreEqual(1, getRouteTableResponse.Value.Data.Routes.Count);
            Assert.AreEqual(getRouteResponse.Value.Data.Name, getRouteTableResponse.Value.Data.Routes[0].Name);
            Assert.AreEqual(getRouteResponse.Value.Data.AddressPrefix, getRouteTableResponse.Value.Data.Routes[0].AddressPrefix);
            Assert.AreEqual(getRouteResponse.Value.Data.NextHopIPAddress, getRouteTableResponse.Value.Data.Routes[0].NextHopIPAddress);
            Assert.AreEqual(getRouteResponse.Value.Data.NextHopType, getRouteTableResponse.Value.Data.Routes[0].NextHopType);

            // Add another route
            var route2 = new RouteData()
            {
                AddressPrefix = "10.0.1.0/24",
                Name = route2Name,
                NextHopType = RouteNextHopType.VnetLocal
            };

            await getRouteTableResponse.Value.GetRoutes().CreateOrUpdateAsync(WaitUntil.Completed, route2Name, route2);

            getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Data.Name);
            Assert.AreEqual(2, getRouteTableResponse.Value.Data.Routes.Count);
            Assert.AreEqual(route2Name, getRouteTableResponse.Value.Data.Routes[1].Name);
            Assert.AreEqual("10.0.1.0/24", getRouteTableResponse.Value.Data.Routes[1].AddressPrefix);
            Assert.True(string.IsNullOrEmpty(getRouteTableResponse.Value.Data.Routes[1].NextHopIPAddress));
            Assert.AreEqual(RouteNextHopType.VnetLocal, getRouteTableResponse.Value.Data.Routes[1].NextHopType);

            Response<RouteResource> getRouteResponse2 = await getRouteTableResponse.Value.GetRoutes().GetAsync(route2Name);
            Assert.AreEqual(getRouteResponse2.Value.Data.Name, getRouteTableResponse.Value.Data.Routes[1].Name);
            Assert.AreEqual(getRouteResponse2.Value.Data.AddressPrefix, getRouteTableResponse.Value.Data.Routes[1].AddressPrefix);
            Assert.AreEqual(getRouteResponse2.Value.Data.NextHopIPAddress, getRouteTableResponse.Value.Data.Routes[1].NextHopIPAddress);
            Assert.AreEqual(getRouteResponse2.Value.Data.NextHopType, getRouteTableResponse.Value.Data.Routes[1].NextHopType);

            // list route
            AsyncPageable<RouteResource> listRouteResponseAP = getRouteTableResponse.Value.GetRoutes().GetAllAsync();
            List<RouteResource> listRouteResponse = await listRouteResponseAP.ToEnumerableAsync();
            Assert.AreEqual(2, listRouteResponse.Count());
            Assert.AreEqual(getRouteResponse.Value.Data.Name, listRouteResponse.First().Data.Name);
            Assert.AreEqual(getRouteResponse.Value.Data.AddressPrefix, listRouteResponse.First().Data.AddressPrefix);
            Assert.AreEqual(getRouteResponse.Value.Data.NextHopIPAddress, listRouteResponse.First().Data.NextHopIPAddress);
            Assert.AreEqual(getRouteResponse.Value.Data.NextHopType, listRouteResponse.First().Data.NextHopType);
            Assert.AreEqual(getRouteResponse2.Value.Data.Name, listRouteResponse.ElementAt(1).Data.Name);
            Assert.AreEqual(getRouteResponse2.Value.Data.AddressPrefix, listRouteResponse.ElementAt(1).Data.AddressPrefix);
            Assert.AreEqual(getRouteResponse2.Value.Data.NextHopIPAddress, listRouteResponse.ElementAt(1).Data.NextHopIPAddress);
            Assert.AreEqual(getRouteResponse2.Value.Data.NextHopType, listRouteResponse.ElementAt(1).Data.NextHopType);

            // Delete a route
            await getRouteResponse.Value.DeleteAsync(WaitUntil.Completed);
            listRouteResponseAP = getRouteTableResponse.Value.GetRoutes().GetAllAsync();
            listRouteResponse = await listRouteResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(listRouteResponse);
            Assert.AreEqual(getRouteResponse2.Value.Data.Name, listRouteResponse.First().Data.Name);
            Assert.AreEqual(getRouteResponse2.Value.Data.AddressPrefix, listRouteResponse.First().Data.AddressPrefix);
            Assert.AreEqual(getRouteResponse2.Value.Data.NextHopIPAddress, listRouteResponse.First().Data.NextHopIPAddress);
            Assert.AreEqual(getRouteResponse2.Value.Data.NextHopType, listRouteResponse.First().Data.NextHopType);

            // Delete route
            await getRouteResponse2.Value.DeleteAsync(WaitUntil.Completed);

            listRouteResponseAP = getRouteTableResponse.Value.GetRoutes().GetAllAsync();
            listRouteResponse = await listRouteResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listRouteResponse);

            // Delete RouteTable
            await getRouteTableResponse.Value.DeleteAsync(WaitUntil.Completed);

            // Verify delete
            AsyncPageable<RouteTableResource> listRouteTableResponseAP = routeTableCollection.GetAllAsync();
            List<RouteTableResource> listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listRouteTableResponse);
        }

        [Test]
        [RecordedTest]
        public async Task RoutesHopTypeTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);
            string routeTableName = Recording.GenerateAssetName("azsmnet");
            string route1Name = Recording.GenerateAssetName("azsmnet");
            string route2Name = Recording.GenerateAssetName("azsmnet");
            string route3Name = Recording.GenerateAssetName("azsmnet");
            string route4Name = Recording.GenerateAssetName("azsmnet");

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
            var putRouteTableResponseOperation =
                await routeTableCollection.CreateOrUpdateAsync(WaitUntil.Completed, routeTableName, routeTable);
            Response<RouteTableResource> putRouteTableResponse = await putRouteTableResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putRouteTableResponse.Value.Data.ProvisioningState.ToString());

            // Get RouteTable
            Response<RouteTableResource> getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Data.Name);
            Assert.AreEqual(1, getRouteTableResponse.Value.Data.Routes.Count);
            Assert.AreEqual(route1Name, getRouteTableResponse.Value.Data.Routes[0].Name);

            // Add another route
            var route2 = new RouteData()
            {
                AddressPrefix = "10.0.1.0/24",
                Name = route2Name,
                NextHopType = RouteNextHopType.VnetLocal
            };
            await getRouteTableResponse.Value.GetRoutes().CreateOrUpdateAsync(WaitUntil.Completed, route2Name, route2);

            // Add another route
            var route3 = new RouteData()
            {
                AddressPrefix = "0.0.0.0/0",
                Name = route3Name,
                NextHopType = RouteNextHopType.Internet
            };
            await getRouteTableResponse.Value.GetRoutes().CreateOrUpdateAsync(WaitUntil.Completed, route3Name, route3);

            // Add another route
            var route4 = new RouteData()
            {
                AddressPrefix = "10.0.2.0/24",
                Name = route4Name,
                NextHopType = RouteNextHopType.None
            };
            await getRouteTableResponse.Value.GetRoutes().CreateOrUpdateAsync(WaitUntil.Completed, route4Name, route4);

            getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Data.Name);
            Assert.AreEqual(4, getRouteTableResponse.Value.Data.Routes.Count);
            Assert.AreEqual(route2Name, getRouteTableResponse.Value.Data.Routes[1].Name);
            Assert.AreEqual(RouteNextHopType.VirtualAppliance, getRouteTableResponse.Value.Data.Routes[0].NextHopType);
            Assert.AreEqual(RouteNextHopType.VnetLocal, getRouteTableResponse.Value.Data.Routes[1].NextHopType);
            Assert.AreEqual(RouteNextHopType.Internet, getRouteTableResponse.Value.Data.Routes[2].NextHopType);
            Assert.AreEqual(RouteNextHopType.None, getRouteTableResponse.Value.Data.Routes[3].NextHopType);

            // Delete RouteTable
            await getRouteTableResponse.Value.DeleteAsync(WaitUntil.Completed);

            // Verify delete
            AsyncPageable<RouteTableResource> listRouteTableResponseAP = routeTableCollection.GetAllAsync();
            List<RouteTableResource> listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listRouteTableResponse);
        }
    }
}
