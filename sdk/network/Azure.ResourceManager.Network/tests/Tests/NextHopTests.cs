// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Compute.Models;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class NextHopTests : NetworkTestsManagementClientBase
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

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task NextHopApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
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
            //await NetworkManagementClient.NetworkWatchers.CreateOrUpdateAsync(resourceGroupName, networkWatcherName, properties);

            string sourceIPAddress = NetworkManagementClient.NetworkInterfaces
                                                            .GetAsync(resourceGroupName, networkInterfaceName).Result.Value.IpConfigurations
                                                            .FirstOrDefault().PrivateIPAddress;

            Response<VirtualMachine> getVm = await ComputeManagementClient.VirtualMachines.GetAsync(resourceGroupName, virtualMachineName);

            //Use DestinationIPAddress from Route Table
            NextHopParameters nhProperties1 = new NextHopParameters(getVm.Value.Id, sourceIPAddress, "10.1.3.6");

            NextHopParameters nhProperties2 = new NextHopParameters(getVm.Value.Id, sourceIPAddress, "12.11.12.14");

            NetworkWatchersGetNextHopOperation getNextHop1Operation = await NetworkManagementClient.NetworkWatchers.StartGetNextHopAsync("NetworkWatcherRG", "NetworkWatcher_westus2", nhProperties1);
            Response<NextHopResult> getNextHop1 = await WaitForCompletionAsync(getNextHop1Operation);

            NetworkWatchersGetNextHopOperation getNextHop2Operation = await NetworkManagementClient.NetworkWatchers.StartGetNextHopAsync("NetworkWatcherRG", "NetworkWatcher_westus2", nhProperties2);
            Response<NextHopResult> getNextHop2 = await WaitForCompletionAsync(getNextHop2Operation);

            Response<RouteTable> routeTable = await NetworkManagementClient.RouteTables.GetAsync(resourceGroupName, resourceGroupName + "RT");

            //Validation
            Assert.AreEqual("10.0.1.2", getNextHop1.Value.NextHopIpAddress);
            Assert.AreEqual(routeTable.Value.Id, getNextHop1.Value.RouteTableId);
            Assert.AreEqual("Internet", getNextHop2.Value.NextHopType.ToString());
            Assert.AreEqual("System Route", getNextHop2.Value.RouteTableId);
        }
    }
}
