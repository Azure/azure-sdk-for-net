// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
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

        //[TearDown]
        //public async Task CleanupResourceGroup()
        //{
        //    await CleanupResourceGroupsAsync();
        //}

        [Test]
        public async Task NextHopApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new Resources.Models.ResourceGroup(location));
            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");

            //Deploy VM wih VNet,Subnet and Route Table from template
            await CreateVm(
                     resourcesClient: ResourceManagementClient,
                     resourceGroupName: resourceGroupName,
                     location: location,
                     virtualMachineName: virtualMachineName,
                     storageAccountName: Recording.GenerateAssetName("azsmnet"),
                     networkInterfaceName: networkInterfaceName,
                     networkSecurityGroupName: networkSecurityGroupName,
                     diagnosticsStorageAccountName: Recording.GenerateAssetName("azsmnet"),
                     deploymentName: Recording.GenerateAssetName("azsmnet"),
                     adminPassword: Recording.GenerateAlphaNumericId("AzureSDKNetworkTest#")
                     );

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create Network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcher properties = new NetworkWatcher { Location = location };
            //await networkWatcherContainer.CreateOrUpdateAsync(resourceGroupName, networkWatcherName, properties);

            var networkInterfaceContainer = GetNetworkInterfaceContainer(resourceGroupName);
            string sourceIPAddress = networkInterfaceContainer
                                                            .GetAsync(networkInterfaceName).Result.Value.Data.IpConfigurations
                                                            .FirstOrDefault().PrivateIPAddress;

            Response<VirtualMachine> getVm = await ComputeManagementClient.VirtualMachines.GetAsync(resourceGroupName, virtualMachineName);

            //Use DestinationIPAddress from Route Table
            NextHopParameters nhProperties1 = new NextHopParameters(getVm.Value.Id, sourceIPAddress, "10.1.3.6");

            NextHopParameters nhProperties2 = new NextHopParameters(getVm.Value.Id, sourceIPAddress, "12.11.12.14");

            var networkWatcherContainer = GetNetworkWatcherContainer(resourceGroupName);
            var networkWatcherResponse = await networkWatcherContainer.GetAsync("NetworkWatcher_westus2");
            NetworkWatchersGetNextHopOperation getNextHop1Operation = await networkWatcherResponse.Value.StartGetNextHopAsync(nhProperties1);
            Response<NextHopResult> getNextHop1 = await getNextHop1Operation.WaitForCompletionAsync();;

            NetworkWatchersGetNextHopOperation getNextHop2Operation = await networkWatcherResponse.Value.StartGetNextHopAsync(nhProperties2);
            Response<NextHopResult> getNextHop2 = await getNextHop2Operation.WaitForCompletionAsync();;

            Response<RouteTable> routeTable = await GetRouteTableContainer(resourceGroupName).GetAsync(resourceGroupName + "RT");

            //Validation
            Assert.AreEqual("10.0.1.2", getNextHop1.Value.NextHopIpAddress);
            Assert.AreEqual(routeTable.Value.Id, getNextHop1.Value.RouteTableId);
            Assert.AreEqual("Internet", getNextHop2.Value.NextHopType.ToString());
            Assert.AreEqual("System Route", getNextHop2.Value.RouteTableId);
        }
    }
}
