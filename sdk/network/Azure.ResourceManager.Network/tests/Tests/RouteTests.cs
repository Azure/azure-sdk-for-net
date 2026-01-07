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
            Assert.That(putRouteTableResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get RouteTable
            Response<RouteTableResource> getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            Assert.That(getRouteTableResponse.Value.Data.Name, Is.EqualTo(routeTableName));
            Assert.That(getRouteTableResponse.Value.Data.Routes.Count, Is.EqualTo(1));
            Assert.That(getRouteTableResponse.Value.Data.Routes[0].Name, Is.EqualTo(route1Name));
            Assert.That(getRouteTableResponse.Value.Data.Routes[0].AddressPrefix, Is.EqualTo("192.168.1.0/24"));
            Assert.That(getRouteTableResponse.Value.Data.Routes[0].NextHopIPAddress, Is.EqualTo("23.108.1.1"));
            Assert.That(getRouteTableResponse.Value.Data.Routes[0].NextHopType, Is.EqualTo(RouteNextHopType.VirtualAppliance));

            // Get Route
            Response<RouteResource> getRouteResponse = await getRouteTableResponse.Value.GetRoutes().GetAsync(route1Name);
            Assert.That(getRouteTableResponse.Value.Data.Name, Is.EqualTo(routeTableName));
            Assert.That(getRouteTableResponse.Value.Data.Routes.Count, Is.EqualTo(1));
            Assert.That(getRouteTableResponse.Value.Data.Routes[0].Name, Is.EqualTo(getRouteResponse.Value.Data.Name));
            Assert.That(getRouteTableResponse.Value.Data.Routes[0].AddressPrefix, Is.EqualTo(getRouteResponse.Value.Data.AddressPrefix));
            Assert.That(getRouteTableResponse.Value.Data.Routes[0].NextHopIPAddress, Is.EqualTo(getRouteResponse.Value.Data.NextHopIPAddress));
            Assert.That(getRouteTableResponse.Value.Data.Routes[0].NextHopType, Is.EqualTo(getRouteResponse.Value.Data.NextHopType));

            // Add another route
            var route2 = new RouteData()
            {
                AddressPrefix = "10.0.1.0/24",
                Name = route2Name,
                NextHopType = RouteNextHopType.VnetLocal
            };

            await getRouteTableResponse.Value.GetRoutes().CreateOrUpdateAsync(WaitUntil.Completed, route2Name, route2);

            getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            Assert.That(getRouteTableResponse.Value.Data.Name, Is.EqualTo(routeTableName));
            Assert.That(getRouteTableResponse.Value.Data.Routes.Count, Is.EqualTo(2));
            Assert.That(getRouteTableResponse.Value.Data.Routes[1].Name, Is.EqualTo(route2Name));
            Assert.That(getRouteTableResponse.Value.Data.Routes[1].AddressPrefix, Is.EqualTo("10.0.1.0/24"));
            Assert.That(string.IsNullOrEmpty(getRouteTableResponse.Value.Data.Routes[1].NextHopIPAddress), Is.True);
            Assert.That(getRouteTableResponse.Value.Data.Routes[1].NextHopType, Is.EqualTo(RouteNextHopType.VnetLocal));

            Response<RouteResource> getRouteResponse2 = await getRouteTableResponse.Value.GetRoutes().GetAsync(route2Name);
            Assert.That(getRouteTableResponse.Value.Data.Routes[1].Name, Is.EqualTo(getRouteResponse2.Value.Data.Name));
            Assert.That(getRouteTableResponse.Value.Data.Routes[1].AddressPrefix, Is.EqualTo(getRouteResponse2.Value.Data.AddressPrefix));
            Assert.That(getRouteTableResponse.Value.Data.Routes[1].NextHopIPAddress, Is.EqualTo(getRouteResponse2.Value.Data.NextHopIPAddress));
            Assert.That(getRouteTableResponse.Value.Data.Routes[1].NextHopType, Is.EqualTo(getRouteResponse2.Value.Data.NextHopType));

            // list route
            AsyncPageable<RouteResource> listRouteResponseAP = getRouteTableResponse.Value.GetRoutes().GetAllAsync();
            List<RouteResource> listRouteResponse = await listRouteResponseAP.ToEnumerableAsync();
            Assert.That(listRouteResponse.Count(), Is.EqualTo(2));
            Assert.That(listRouteResponse.First().Data.Name, Is.EqualTo(getRouteResponse.Value.Data.Name));
            Assert.That(listRouteResponse.First().Data.AddressPrefix, Is.EqualTo(getRouteResponse.Value.Data.AddressPrefix));
            Assert.That(listRouteResponse.First().Data.NextHopIPAddress, Is.EqualTo(getRouteResponse.Value.Data.NextHopIPAddress));
            Assert.That(listRouteResponse.First().Data.NextHopType, Is.EqualTo(getRouteResponse.Value.Data.NextHopType));
            Assert.That(listRouteResponse.ElementAt(1).Data.Name, Is.EqualTo(getRouteResponse2.Value.Data.Name));
            Assert.That(listRouteResponse.ElementAt(1).Data.AddressPrefix, Is.EqualTo(getRouteResponse2.Value.Data.AddressPrefix));
            Assert.That(listRouteResponse.ElementAt(1).Data.NextHopIPAddress, Is.EqualTo(getRouteResponse2.Value.Data.NextHopIPAddress));
            Assert.That(listRouteResponse.ElementAt(1).Data.NextHopType, Is.EqualTo(getRouteResponse2.Value.Data.NextHopType));

            // Delete a route
            await getRouteResponse.Value.DeleteAsync(WaitUntil.Completed);
            listRouteResponseAP = getRouteTableResponse.Value.GetRoutes().GetAllAsync();
            listRouteResponse = await listRouteResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(listRouteResponse);
            Assert.That(listRouteResponse.First().Data.Name, Is.EqualTo(getRouteResponse2.Value.Data.Name));
            Assert.That(listRouteResponse.First().Data.AddressPrefix, Is.EqualTo(getRouteResponse2.Value.Data.AddressPrefix));
            Assert.That(listRouteResponse.First().Data.NextHopIPAddress, Is.EqualTo(getRouteResponse2.Value.Data.NextHopIPAddress));
            Assert.That(listRouteResponse.First().Data.NextHopType, Is.EqualTo(getRouteResponse2.Value.Data.NextHopType));

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
            Assert.That(putRouteTableResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get RouteTable
            Response<RouteTableResource> getRouteTableResponse = await routeTableCollection.GetAsync(routeTableName);
            Assert.That(getRouteTableResponse.Value.Data.Name, Is.EqualTo(routeTableName));
            Assert.That(getRouteTableResponse.Value.Data.Routes.Count, Is.EqualTo(1));
            Assert.That(getRouteTableResponse.Value.Data.Routes[0].Name, Is.EqualTo(route1Name));

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
            Assert.That(getRouteTableResponse.Value.Data.Name, Is.EqualTo(routeTableName));
            Assert.That(getRouteTableResponse.Value.Data.Routes.Count, Is.EqualTo(4));
            Assert.That(getRouteTableResponse.Value.Data.Routes[1].Name, Is.EqualTo(route2Name));
            Assert.That(getRouteTableResponse.Value.Data.Routes[0].NextHopType, Is.EqualTo(RouteNextHopType.VirtualAppliance));
            Assert.That(getRouteTableResponse.Value.Data.Routes[1].NextHopType, Is.EqualTo(RouteNextHopType.VnetLocal));
            Assert.That(getRouteTableResponse.Value.Data.Routes[2].NextHopType, Is.EqualTo(RouteNextHopType.Internet));
            Assert.That(getRouteTableResponse.Value.Data.Routes[3].NextHopType, Is.EqualTo(RouteNextHopType.None));

            // Delete RouteTable
            await getRouteTableResponse.Value.DeleteAsync(WaitUntil.Completed);

            // Verify delete
            AsyncPageable<RouteTableResource> listRouteTableResponseAP = routeTableCollection.GetAllAsync();
            List<RouteTableResource> listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listRouteTableResponse);
        }
    }
}
