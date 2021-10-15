// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/24577")]
    public class RouteTableTests : NetworkServiceClientTestBase
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
            var routeTableContainer = resourceGroup.GetRouteTables();
            var putRouteTableResponseOperation = await routeTableContainer.CreateOrUpdateAsync(routeTableName, routeTable);
            Response<RouteTable> putRouteTableResponse = await putRouteTableResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putRouteTableResponse.Value.Data.ProvisioningState.ToString());

            // Get RouteTable
            Response<RouteTable> getRouteTableResponse = await routeTableContainer.GetAsync(routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Data.Name);
            Assert.False(getRouteTableResponse.Value.Data.Routes.Any());

            // List RouteTable
            AsyncPageable<RouteTable> listRouteTableResponseAP = routeTableContainer.GetAllAsync();
            List<RouteTable> listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(listRouteTableResponse);
            Assert.AreEqual(getRouteTableResponse.Value.Data.Name, listRouteTableResponse.First().Data.Name);
            Assert.AreEqual(getRouteTableResponse.Value.Id, listRouteTableResponse.First().Id);

            // Delete RouteTable
            var deleteOperation = await getRouteTableResponse.Value.DeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Verify delete
            listRouteTableResponseAP = routeTableContainer.GetAllAsync();
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
                NextHopIpAddress = "23.108.1.1",
                NextHopType = RouteNextHopType.VirtualAppliance
            };

            routeTable.Routes.Add(route1);

            // Put RouteTable
            var routeTableContainer = resourceGroup.GetRouteTables();
            var putRouteTableResponseOperation = await routeTableContainer.CreateOrUpdateAsync(routeTableName, routeTable);
            Response<RouteTable> putRouteTableResponse = await putRouteTableResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putRouteTableResponse.Value.Data.ProvisioningState.ToString());

            // Get RouteTable
            Response<RouteTable> getRouteTableResponse = await routeTableContainer.GetAsync(routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Data.Name);
            Assert.AreEqual(1, getRouteTableResponse.Value.Data.Routes.Count);
            Assert.AreEqual(route1Name, getRouteTableResponse.Value.Data.Routes[0].Name);
            Assert.AreEqual("192.168.1.0/24", getRouteTableResponse.Value.Data.Routes[0].AddressPrefix);
            Assert.AreEqual("23.108.1.1", getRouteTableResponse.Value.Data.Routes[0].NextHopIpAddress);
            Assert.AreEqual(RouteNextHopType.VirtualAppliance, getRouteTableResponse.Value.Data.Routes[0].NextHopType);

            // Add another route
            var route2 = new RouteData()
            {
                AddressPrefix = "10.0.1.0/24",
                Name = route2Name,
                NextHopType = RouteNextHopType.VnetLocal
            };
            getRouteTableResponse.Value.Data.Routes.Add(route2);

            await routeTableContainer.CreateOrUpdateAsync(routeTableName, getRouteTableResponse.Value.Data);

            getRouteTableResponse = await routeTableContainer.GetAsync(routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Data.Name);
            Assert.AreEqual(2, getRouteTableResponse.Value.Data.Routes.Count);
            Assert.AreEqual(route2Name, getRouteTableResponse.Value.Data.Routes[1].Name);
            Assert.AreEqual("10.0.1.0/24", getRouteTableResponse.Value.Data.Routes[1].AddressPrefix);
            Assert.True(string.IsNullOrEmpty(getRouteTableResponse.Value.Data.Routes[1].NextHopIpAddress));
            Assert.AreEqual(RouteNextHopType.VnetLocal, getRouteTableResponse.Value.Data.Routes[1].NextHopType);

            // Delete a route
            getRouteTableResponse.Value.Data.Routes.RemoveAt(0);

            await routeTableContainer.CreateOrUpdateAsync(routeTableName, getRouteTableResponse.Value.Data);

            getRouteTableResponse = await routeTableContainer.GetAsync(routeTableName);
            Assert.AreEqual(routeTableName, getRouteTableResponse.Value.Data.Name);
            Assert.AreEqual(1, getRouteTableResponse.Value.Data.Routes.Count);
            Assert.AreEqual(route2Name, getRouteTableResponse.Value.Data.Routes[0].Name);
            Assert.AreEqual("10.0.1.0/24", getRouteTableResponse.Value.Data.Routes[0].AddressPrefix);
            Assert.True(string.IsNullOrEmpty(getRouteTableResponse.Value.Data.Routes[0].NextHopIpAddress));
            Assert.AreEqual(RouteNextHopType.VnetLocal, getRouteTableResponse.Value.Data.Routes[0].NextHopType);

            // Delete RouteTable
            var deleteOperation = await getRouteTableResponse.Value.DeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Verify delete
            AsyncPageable<RouteTable> listRouteTableResponseAP = routeTableContainer.GetAllAsync();
            List<RouteTable> listRouteTableResponse = await listRouteTableResponseAP.ToEnumerableAsync();
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
                NextHopIpAddress = "23.108.1.1",
                NextHopType = RouteNextHopType.VirtualAppliance
            };

            routeTable.Routes.Add(route1);

            // Put RouteTable
            var routeTableContainer = resourceGroup.GetRouteTables();
            var putRouteTableResponseOperation = await routeTableContainer.CreateOrUpdateAsync(routeTableName, routeTable);
            Response<RouteTable> putRouteTableResponse = await putRouteTableResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putRouteTableResponse.Value.Data.ProvisioningState.ToString());

            // Get RouteTable
            Response<RouteTable> getRouteTableResponse = await routeTableContainer.GetAsync(routeTableName);

            // Verify that the subnet reference is null
            Assert.IsEmpty(getRouteTableResponse.Value.Data.Subnets);

            // Create Vnet with subnet and add a route table
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            var vnet = new VirtualNetworkData()
            {
                Location = location,

                AddressSpace = new AddressSpace()
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

            var putVnetResponseOperation = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(vnetName, vnet);
            Response<VirtualNetwork> putVnetResponse = await putVnetResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putVnetResponse.Value.Data.ProvisioningState.ToString());

            Response<Subnet> getSubnetResponse = await putVnetResponse.Value.GetSubnets().GetAsync(subnetName);
            Assert.AreEqual(getSubnetResponse.Value.Data.RouteTable.Id, getRouteTableResponse.Value.Id);

            // Get RouteTable
            getRouteTableResponse = await routeTableContainer.GetAsync(routeTableName);
            Assert.AreEqual(1, getRouteTableResponse.Value.Data.Subnets.Count);
            Assert.AreEqual(getSubnetResponse.Value.Id, getRouteTableResponse.Value.Data.Subnets[0].Id);
        }
    }
}
