// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class NextHopTests : NetworkServiceClientTestBase
    {
        public NextHopTests(bool isAsync) : base(isAsync)
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
        [Ignore("Review after preview")]
        public async Task NextHopApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            var resourceGroup = await CreateResourceGroup(resourceGroupName, location);
            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");

            //Deploy VM wih VNet,SubnetResource and RouteResource Table from template
            var vm = await CreateLinuxVM(virtualMachineName, networkInterfaceName, location, resourceGroup);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create Network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcherResource properties = new NetworkWatcherResource { Location = location };
            //await networkWatcherCollection.CreateOrUpdateAsync(true, resourceGroupName, networkWatcherName, properties);

            var networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();
            string sourceIPAddress = networkInterfaceCollection
                                                            .GetAsync(networkInterfaceName).Result.Value.Data.IPConfigurations
                                                            .FirstOrDefault().PrivateIPAddress;

            //Use DestinationIPAddress from RouteResource Table
            NextHopContent nhProperties1 = new NextHopContent(vm.Id, sourceIPAddress, "10.1.3.6");

            NextHopContent nhProperties2 = new NextHopContent(vm.Id, sourceIPAddress, "12.11.12.14");

            var networkWatcherCollection = resourceGroup.GetNetworkWatchers();
            var networkWatcherResponse = await networkWatcherCollection.GetAsync("NetworkWatcher_westus2");
            var getNextHop1Operation = await networkWatcherResponse.Value.GetNextHopAsync(WaitUntil.Completed, nhProperties1);
            Response<NextHopResult> getNextHop1 = await getNextHop1Operation.WaitForCompletionAsync();;

            var getNextHop2Operation = await networkWatcherResponse.Value.GetNextHopAsync(WaitUntil.Completed, nhProperties2);
            Response<NextHopResult> getNextHop2 = await getNextHop2Operation.WaitForCompletionAsync();;

            Response<RouteTableResource> routeTable = await resourceGroup.GetRouteTables().GetAsync(resourceGroupName + "RT");

            //Validation
            Assert.AreEqual("10.0.1.2", getNextHop1.Value.NextHopIPAddress);
            Assert.AreEqual(routeTable.Value.Id, getNextHop1.Value.RouteTableId);
            Assert.AreEqual("Internet", getNextHop2.Value.NextHopType.ToString());
            Assert.AreEqual("System Route", getNextHop2.Value.RouteTableId);
        }
    }
}
