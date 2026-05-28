// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class ConnectionMonitorTests : NetworkServiceClientTestBase
    {
        public ConnectionMonitorTests(bool isAsync) : base(isAsync)
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

        private ConnectionMonitorCollection ConnectionMonitors
        {
            get
            {
                return GetResourceGroup("NetworkWatcherRG").GetNetworkWatchers().Get("NetworkWatcher_westus2").Value.GetConnectionMonitors();
            }
        }

        [Test]
        [Ignore("Track2: ApiVersion does not meet the requirements")]
        public async Task PutConnectionMonitorTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            var resourceGroup = await CreateResourceGroup(resourceGroupName, location);
            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with a template
            var vm = await CreateWindowsVM(virtualMachineName, networkInterfaceName, location, resourceGroup);

            //Deploy networkWatcherAgent on VM
            await deployWindowsNetworkAgent(virtualMachineName, location, resourceGroup);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcherResource properties = new NetworkWatcherResource { Location = location };
            //await networkWatcherCollection.CreateOrUpdateAsync(true, "NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName = "cm";
            var cm = new ConnectionMonitorCreateOrUpdateContent
            {
                Location = location,
                Source = new ConnectionMonitorSource(vm.Id),
                Destination = new ConnectionMonitorDestination
                {
                    Address = "bing.com",
                    Port = 80
                },
                MonitoringIntervalInSeconds = 30
            };

            var putConnectionMonitorOperation = await ConnectionMonitors.CreateOrUpdateAsync(WaitUntil.Completed, connectionMonitorName, cm);
            Response<ConnectionMonitorResource> putConnectionMonitor = await putConnectionMonitorOperation.WaitForCompletionAsync();;

            Assert.AreEqual("Running", putConnectionMonitor.Value.Data.MonitoringStatus);
            Assert.AreEqual("centraluseuap", putConnectionMonitor.Value.Data.Location);
            Assert.AreEqual(30, putConnectionMonitor.Value.Data.MonitoringIntervalInSeconds);
            Assert.AreEqual(connectionMonitorName, putConnectionMonitor.Value.Data.Name);
            Assert.AreEqual(vm.Id, putConnectionMonitor.Value.Data.Source.ResourceId);
            Assert.AreEqual("bing.com", putConnectionMonitor.Value.Data.Destination.Address);
            Assert.AreEqual(80, putConnectionMonitor.Value.Data.Destination.Port);
        }

        [Test]
        [Ignore("Track2: ApiVersion does not meet the requirements")]
        public async Task StopConnectionMonitorTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            var resourceGroup = await CreateResourceGroup(resourceGroupName, location);
            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with a template
            var vm = await CreateWindowsVM(virtualMachineName, networkInterfaceName, location, resourceGroup);

            //Deploy networkWatcherAgent on VM
            await deployWindowsNetworkAgent(virtualMachineName, location, resourceGroup);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcherResource properties = new NetworkWatcherResource { Location = location };
            //await networkWatcherCollection.CreateOrUpdateAsync(true, "NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName = Recording.GenerateAssetName("azsmnet");
            var cm = new ConnectionMonitorCreateOrUpdateContent
            {
                Location = location,
                Source = new ConnectionMonitorSource(vm.Id),
                Destination = new ConnectionMonitorDestination
                {
                    Address = "bing.com",
                    Port = 80
                },
                MonitoringIntervalInSeconds = 30
            };

            var putConnectionMonitorOperation = await ConnectionMonitors.CreateOrUpdateAsync(WaitUntil.Completed, connectionMonitorName, cm);
            Response<ConnectionMonitorResource> putConnectionMonitor = await putConnectionMonitorOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Running", putConnectionMonitor.Value.Data.MonitoringStatus);

            Operation connectionMonitorsStopOperation = await ConnectionMonitors.Get(connectionMonitorName).Value.StopAsync(WaitUntil.Completed);
            await connectionMonitorsStopOperation.WaitForCompletionResponseAsync();;

            Response<ConnectionMonitorResource> getConnectionMonitor = await ConnectionMonitors.GetAsync(connectionMonitorName);
            Assert.AreEqual("Stopped", getConnectionMonitor.Value.Data.MonitoringStatus);
        }

        [Test]
        [Ignore("Track2: ApiVersion does not meet the requirements")]
        public async Task UpdateConnectionMonitorTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            var resourceGroup = await CreateResourceGroup (resourceGroupName, location);
            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with a template
            var vm = await CreateWindowsVM(virtualMachineName, networkInterfaceName, location, resourceGroup);

            //Deploy networkWatcherAgent on VM
            await deployWindowsNetworkAgent (virtualMachineName, location, resourceGroup);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcherResource properties = new NetworkWatcherResource { Location = location };
            //await networkWatcherCollection.CreateOrUpdateAsync(true, "NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName = Recording.GenerateAssetName("azsmnet");
            var cm = new ConnectionMonitorCreateOrUpdateContent
            {
                Location = location,
                Source = new ConnectionMonitorSource(vm.Id),
                Destination = new ConnectionMonitorDestination
                {
                    Address = "bing.com",
                    Port = 80
                },
                MonitoringIntervalInSeconds = 30
            };

            var putConnectionMonitorOperation = await ConnectionMonitors.CreateOrUpdateAsync(WaitUntil.Completed, connectionMonitorName, cm);
            Response<ConnectionMonitorResource> putConnectionMonitor = await putConnectionMonitorOperation.WaitForCompletionAsync();;
            Assert.AreEqual(30, putConnectionMonitor.Value.Data.MonitoringIntervalInSeconds);

            cm.MonitoringIntervalInSeconds = 60;
            var updateConnectionMonitorOperation = await ConnectionMonitors.CreateOrUpdateAsync(WaitUntil.Completed, connectionMonitorName, cm);
            Response<ConnectionMonitorResource> updateConnectionMonitor = await updateConnectionMonitorOperation.WaitForCompletionAsync();;
            Assert.AreEqual(60, updateConnectionMonitor.Value.Data.MonitoringIntervalInSeconds);
        }

        [Test]
        [Ignore("Track2: ApiVersion does not meet the requirements")]
        public async Task DeleteConnectionMonitorTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            var resourceGroup = await CreateResourceGroup (resourceGroupName, location);
            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with a template
            var vm = await CreateWindowsVM(virtualMachineName, networkInterfaceName, location, resourceGroup);

            //Deploy networkWatcherAgent on VM
            await deployWindowsNetworkAgent (virtualMachineName, location, resourceGroup);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcherResource properties = new NetworkWatcherResource { Location = location };
            //await networkWatcherCollection.CreateOrUpdateAsync(true, "NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName1 = Recording.GenerateAssetName("azsmnet");
            string connectionMonitorName2 = Recording.GenerateAssetName("azsmnet");
            var cm = new ConnectionMonitorCreateOrUpdateContent
            {
                Location = location,
                Source = new ConnectionMonitorSource(vm.Id),
                Destination = new ConnectionMonitorDestination
                {
                    Address = "bing.com",
                    Port = 80
                },
                MonitoringIntervalInSeconds = 30,
                AutoStart = false
            };

            var connectionMonitor1Operation = await ConnectionMonitors.CreateOrUpdateAsync(WaitUntil.Completed, connectionMonitorName1, cm);
            await connectionMonitor1Operation.WaitForCompletionAsync();;
            var connectionMonitor2Operation = await ConnectionMonitors.CreateOrUpdateAsync(WaitUntil.Completed, connectionMonitorName2, cm);
            var connectionMonitor2 = (await connectionMonitor2Operation.WaitForCompletionAsync()).Value;

            AsyncPageable<ConnectionMonitorResource> getConnectionMonitors1AP = ConnectionMonitors.GetAllAsync();
            Task<List<ConnectionMonitorResource>> getConnectionMonitors1 = getConnectionMonitors1AP.ToEnumerableAsync();
            Assert.AreEqual(2, getConnectionMonitors1.Result.Count);

            var operation = await connectionMonitor2.DeleteAsync(WaitUntil.Completed);
            await operation.WaitForCompletionResponseAsync();
            // TODO: restore to use Delete of the specific resource collection: ADO 5998
            //Operation connectionMonitorsDeleteOperation = await ConnectionMonitors.Get(connectionMonitorName2).Value.DeleteAsync(true);
            //await connectionMonitorsDeleteOperation.WaitForCompletionAsync();;
            AsyncPageable<ConnectionMonitorResource> getConnectionMonitors2 = ConnectionMonitors.GetAllAsync();
            Has.One.EqualTo(getConnectionMonitors2);
        }
    }
}
