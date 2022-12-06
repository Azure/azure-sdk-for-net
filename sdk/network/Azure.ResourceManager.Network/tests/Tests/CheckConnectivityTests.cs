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
    public class CheckConnectivityTests : NetworkServiceClientTestBase
    {
        public CheckConnectivityTests(bool isAsync) : base(isAsync)
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
        [Ignore("Review this after preview")]
        public async Task CheckConnectivityVmToInternetTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");
            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName, location);

            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with a template
            var vm = await CreateWindowsVM(virtualMachineName, networkInterfaceName, location, resourceGroup);

            //Deploy networkWatcherAgent on VM
            await deployWindowsNetworkAgent(virtualMachineName, location, resourceGroup);

            //Create network Watcher
            string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            var properties = new NetworkWatcherData { Location = location };
            await resourceGroup.GetNetworkWatchers().CreateOrUpdateAsync(WaitUntil.Completed, networkWatcherName, properties);

            ConnectivityContent connectivityParameters =
                new ConnectivityContent(new ConnectivitySource(vm.Id), new ConnectivityDestination { Address = "bing.com", Port = 80 });

            Operation<ConnectivityInformation> connectivityCheckOperation = await GetResourceGroup("NetworkWatcherRG").GetNetworkWatchers().Get("NetworkWatcher_westus2").Value.CheckConnectivityAsync(WaitUntil.Completed, connectivityParameters);
            Response<ConnectivityInformation> connectivityCheck = await connectivityCheckOperation.WaitForCompletionAsync();;

            //Validation
            Assert.AreEqual("Reachable", connectivityCheck.Value.NetworkConnectionStatus.ToString());
            Assert.AreEqual(0, connectivityCheck.Value.ProbesFailed);
            Assert.AreEqual("Source", connectivityCheck.Value.Hops.FirstOrDefault().ConnectivityHopType);
            Assert.AreEqual("Internet", connectivityCheck.Value.Hops.LastOrDefault().ConnectivityHopType);
        }
    }
}
