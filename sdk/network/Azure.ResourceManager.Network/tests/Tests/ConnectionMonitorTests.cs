// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
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

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        private ConnectionMonitorContainer ConnectionMonitors
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
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new Resources.Models.ResourceGroup(location));
            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with a template
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

            Response<VirtualMachine> getVm = await ComputeManagementClient.VirtualMachines.GetAsync(resourceGroupName, virtualMachineName);

            //Deploy networkWatcherAgent on VM
            VirtualMachineExtension parameters = new VirtualMachineExtension(location)
            {
                Publisher = "Microsoft.Azure.NetworkWatcher",
                TypeHandlerVersion = "1.4",
                TypePropertiesType = "NetworkWatcherAgentWindows"
            };

            VirtualMachineExtensionsCreateOrUpdateOperation createOrUpdateOperation = await ComputeManagementClient.VirtualMachineExtensions.StartCreateOrUpdateAsync(resourceGroupName, getVm.Value.Name, "NetworkWatcherAgent", parameters);
            await WaitForCompletionAsync(createOrUpdateOperation);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcher properties = new NetworkWatcher { Location = location };
            //await networkWatcherContainer.CreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName = "cm";
            var cm = new ConnectionMonitorInput
            {
                Location = location,
                Source = new ConnectionMonitorSource(getVm.Value.Id),
                Destination = new ConnectionMonitorDestination
                {
                    Address = "bing.com",
                    Port = 80
                },
                MonitoringIntervalInSeconds = 30
            };

            var putConnectionMonitorOperation = await ConnectionMonitors.StartCreateOrUpdateAsync(connectionMonitorName, cm);
            Response<ConnectionMonitor> putConnectionMonitor = await WaitForCompletionAsync(putConnectionMonitorOperation);

            Assert.AreEqual("Running", putConnectionMonitor.Value.Data.MonitoringStatus);
            Assert.AreEqual("centraluseuap", putConnectionMonitor.Value.Data.Location);
            Assert.AreEqual(30, putConnectionMonitor.Value.Data.MonitoringIntervalInSeconds);
            Assert.AreEqual(connectionMonitorName, putConnectionMonitor.Value.Data.Name);
            Assert.AreEqual(getVm.Value.Id, putConnectionMonitor.Value.Data.Source.ResourceId);
            Assert.AreEqual("bing.com", putConnectionMonitor.Value.Data.Destination.Address);
            Assert.AreEqual(80, putConnectionMonitor.Value.Data.Destination.Port);
        }

        [Test]
        [Ignore("Track2: ApiVersion does not meet the requirements")]
        public async Task StartConnectionMonitorTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new Resources.Models.ResourceGroup(location));

            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with a template
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

            Response<VirtualMachine> getVm = await ComputeManagementClient.VirtualMachines.GetAsync(resourceGroupName, virtualMachineName);

            //Deploy networkWatcherAgent on VM
            VirtualMachineExtension parameters = new VirtualMachineExtension(location)
            {
                Publisher = "Microsoft.Azure.NetworkWatcher",
                TypeHandlerVersion = "1.4",
                TypePropertiesType = "NetworkWatcherAgentWindows"
            };

            VirtualMachineExtensionsCreateOrUpdateOperation createOrUpdateOperation = await ComputeManagementClient.VirtualMachineExtensions.StartCreateOrUpdateAsync(resourceGroupName, getVm.Value.Name, "NetworkWatcherAgent", parameters);
            await WaitForCompletionAsync(createOrUpdateOperation);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcher properties = new NetworkWatcher { Location = location };
            //await networkWatcherContainer.CreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName = Recording.GenerateAssetName("azsmnet");
            var cm = new ConnectionMonitorInput
            {
                Location = location,
                Source = new ConnectionMonitorSource(getVm.Value.Id),
                Destination = new ConnectionMonitorDestination
                {
                    Address = "bing.com",
                    Port = 80
                },
                MonitoringIntervalInSeconds = 30,
                AutoStart = false
            };

            var putConnectionMonitorOperation = await ConnectionMonitors.StartCreateOrUpdateAsync(connectionMonitorName, cm);
            Response<ConnectionMonitor> putConnectionMonitor = await WaitForCompletionAsync(putConnectionMonitorOperation);
            Assert.AreEqual("NotStarted", putConnectionMonitor.Value.Data.MonitoringStatus);

            Operation connectionMonitorsStartOperation = await ConnectionMonitors.Get(connectionMonitorName).Value.StartStartAsync();
            await WaitForCompletionAsync(connectionMonitorsStartOperation);

            Response<ConnectionMonitor> getConnectionMonitor = await ConnectionMonitors.GetAsync(connectionMonitorName);
            Assert.AreEqual("Running", getConnectionMonitor.Value.Data.MonitoringStatus);
        }

        [Test]
        [Ignore("Track2: ApiVersion does not meet the requirements")]
        public async Task StopConnectionMonitorTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new Resources.Models.ResourceGroup(location));
            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with a template
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

            Response<VirtualMachine> getVm = await ComputeManagementClient.VirtualMachines.GetAsync(resourceGroupName, virtualMachineName);

            //Deploy networkWatcherAgent on VM
            VirtualMachineExtension parameters = new VirtualMachineExtension(location)
            {
                Publisher = "Microsoft.Azure.NetworkWatcher",
                TypeHandlerVersion = "1.4",
                TypePropertiesType = "NetworkWatcherAgentWindows"
            };

            VirtualMachineExtensionsCreateOrUpdateOperation createOrUpdateOperation = await ComputeManagementClient.VirtualMachineExtensions.StartCreateOrUpdateAsync(resourceGroupName, getVm.Value.Name, "NetworkWatcherAgent", parameters);
            await WaitForCompletionAsync(createOrUpdateOperation);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcher properties = new NetworkWatcher { Location = location };
            //await networkWatcherContainer.CreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName = Recording.GenerateAssetName("azsmnet");
            var cm = new ConnectionMonitorInput
            {
                Location = location,
                Source = new ConnectionMonitorSource(getVm.Value.Id),
                Destination = new ConnectionMonitorDestination
                {
                    Address = "bing.com",
                    Port = 80
                },
                MonitoringIntervalInSeconds = 30
            };

            var putConnectionMonitorOperation = await ConnectionMonitors.StartCreateOrUpdateAsync(connectionMonitorName, cm);
            Response<ConnectionMonitor> putConnectionMonitor = await WaitForCompletionAsync(putConnectionMonitorOperation);
            Assert.AreEqual("Running", putConnectionMonitor.Value.Data.MonitoringStatus);

            Operation connectionMonitorsStopOperation = await ConnectionMonitors.Get(connectionMonitorName).Value.StartStopAsync();
            await WaitForCompletionAsync(connectionMonitorsStopOperation);

            Response<ConnectionMonitor> getConnectionMonitor = await ConnectionMonitors.GetAsync(connectionMonitorName);
            Assert.AreEqual("Stopped", getConnectionMonitor.Value.Data.MonitoringStatus);
        }

        [Test]
        [Ignore("Track2: ApiVersion does not meet the requirements")]
        public async Task QueryConnectionMonitorTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new Resources.Models.ResourceGroup(location));
            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with a template
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

            Response<VirtualMachine> getVm = await ComputeManagementClient.VirtualMachines.GetAsync(resourceGroupName, virtualMachineName);

            //Deploy networkWatcherAgent on VM
            VirtualMachineExtension parameters = new VirtualMachineExtension(location)
            {
                Publisher = "Microsoft.Azure.NetworkWatcher",
                TypeHandlerVersion = "1.4",
                TypePropertiesType = "NetworkWatcherAgentWindows"
            };

            VirtualMachineExtensionsCreateOrUpdateOperation createOrUpdateOperation = await ComputeManagementClient.VirtualMachineExtensions.StartCreateOrUpdateAsync(resourceGroupName, getVm.Value.Name, "NetworkWatcherAgent", parameters);
            await WaitForCompletionAsync(createOrUpdateOperation);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcher properties = new NetworkWatcher { Location = location };
            //await networkWatcherContainer.CreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName = Recording.GenerateAssetName("azsmnet");
            var cm = new ConnectionMonitorInput
            {
                Location = location,
                Source = new ConnectionMonitorSource(getVm.Value.Id),
                Destination = new ConnectionMonitorDestination
                {
                    Address = "bing.com",
                    Port = 80
                },
                MonitoringIntervalInSeconds = 30
            };

            var putConnectionMonitorOperation = await ConnectionMonitors.StartCreateOrUpdateAsync(connectionMonitorName, cm);
            await WaitForCompletionAsync(putConnectionMonitorOperation);

            Operation connectionMonitorsStartOperation = await ConnectionMonitors.Get(connectionMonitorName).Value.StartStartAsync();
            await WaitForCompletionAsync(connectionMonitorsStartOperation);

            Operation connectionMonitorsStopOperation = await ConnectionMonitors.Get(connectionMonitorName).Value.StartStopAsync();
            await WaitForCompletionAsync(connectionMonitorsStopOperation);

            Operation<ConnectionMonitorQueryResult> queryResultOperation = await ConnectionMonitors.Get(connectionMonitorName).Value.StartQueryAsync();
            Response<ConnectionMonitorQueryResult> queryResult = await WaitForCompletionAsync(queryResultOperation);
            //Has.One.EqualTo(queryResult.States);
            Assert.AreEqual("Reachable", queryResult.Value.States[0].ConnectionState);
            Assert.AreEqual("InProgress", queryResult.Value.States[0].EvaluationState);
            Assert.AreEqual(2, queryResult.Value.States[0].Hops.Count);
        }

        [Test]
        [Ignore("Track2: ApiVersion does not meet the requirements")]
        public async Task UpdateConnectionMonitorTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new Resources.Models.ResourceGroup(location));
            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with a template
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

            Response<VirtualMachine> getVm = await ComputeManagementClient.VirtualMachines.GetAsync(resourceGroupName, virtualMachineName);

            //Deploy networkWatcherAgent on VM
            VirtualMachineExtension parameters = new VirtualMachineExtension(location)
            {
                Publisher = "Microsoft.Azure.NetworkWatcher",
                TypeHandlerVersion = "1.4",
                TypePropertiesType = "NetworkWatcherAgentWindows"
            };

            VirtualMachineExtensionsCreateOrUpdateOperation createOrUpdateOperation = await ComputeManagementClient.VirtualMachineExtensions.StartCreateOrUpdateAsync(resourceGroupName, getVm.Value.Name, "NetworkWatcherAgent", parameters);
            await WaitForCompletionAsync(createOrUpdateOperation);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcher properties = new NetworkWatcher { Location = location };
            //await networkWatcherContainer.CreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName = Recording.GenerateAssetName("azsmnet");
            var cm = new ConnectionMonitorInput
            {
                Location = location,
                Source = new ConnectionMonitorSource(getVm.Value.Id),
                Destination = new ConnectionMonitorDestination
                {
                    Address = "bing.com",
                    Port = 80
                },
                MonitoringIntervalInSeconds = 30
            };

            var putConnectionMonitorOperation = await ConnectionMonitors.StartCreateOrUpdateAsync(connectionMonitorName, cm);
            Response<ConnectionMonitor> putConnectionMonitor = await WaitForCompletionAsync(putConnectionMonitorOperation);
            Assert.AreEqual(30, putConnectionMonitor.Value.Data.MonitoringIntervalInSeconds);

            cm.MonitoringIntervalInSeconds = 60;
            var updateConnectionMonitorOperation = await ConnectionMonitors.StartCreateOrUpdateAsync(connectionMonitorName, cm);
            Response<ConnectionMonitor> updateConnectionMonitor = await WaitForCompletionAsync(updateConnectionMonitorOperation);
            Assert.AreEqual(60, updateConnectionMonitor.Value.Data.MonitoringIntervalInSeconds);
        }

        [Test]
        [Ignore("Track2: ApiVersion does not meet the requirements")]
        public async Task DeleteConnectionMonitorTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new Resources.Models.ResourceGroup(location));
            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with a template
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

            Response<VirtualMachine> getVm = await ComputeManagementClient.VirtualMachines.GetAsync(resourceGroupName, virtualMachineName);

            //Deploy networkWatcherAgent on VM
            VirtualMachineExtension parameters = new VirtualMachineExtension(location)
            {
                Publisher = "Microsoft.Azure.NetworkWatcher",
                TypeHandlerVersion = "1.4",
                TypePropertiesType = "NetworkWatcherAgentWindows"
            };

            VirtualMachineExtensionsCreateOrUpdateOperation createOrUpdateOperation = await ComputeManagementClient.VirtualMachineExtensions.StartCreateOrUpdateAsync(resourceGroupName, getVm.Value.Name, "NetworkWatcherAgent", parameters);
            await WaitForCompletionAsync(createOrUpdateOperation);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcher properties = new NetworkWatcher { Location = location };
            //await networkWatcherContainer.CreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName1 = Recording.GenerateAssetName("azsmnet");
            string connectionMonitorName2 = Recording.GenerateAssetName("azsmnet");
            var cm = new ConnectionMonitorInput
            {
                Location = location,
                Source = new ConnectionMonitorSource(getVm.Value.Id),
                Destination = new ConnectionMonitorDestination
                {
                    Address = "bing.com",
                    Port = 80
                },
                MonitoringIntervalInSeconds = 30,
                AutoStart = false
            };

            var connectionMonitor1Operation = await ConnectionMonitors.StartCreateOrUpdateAsync(connectionMonitorName1, cm);
            await WaitForCompletionAsync(connectionMonitor1Operation);
            var connectionMonitor2Operation = await ConnectionMonitors.StartCreateOrUpdateAsync(connectionMonitorName2, cm);
            await WaitForCompletionAsync(connectionMonitor2Operation);

            AsyncPageable<ConnectionMonitor> getConnectionMonitors1AP = ConnectionMonitors.GetAllAsync();
            Task<List<ConnectionMonitor>> getConnectionMonitors1 = getConnectionMonitors1AP.ToEnumerableAsync();
            Assert.AreEqual(2, getConnectionMonitors1.Result.Count);

            var operation = await ArmClient.GetGenericResourceOperations(ConnectionMonitors.Get(connectionMonitorName2).Value.Data.Id).StartDeleteAsync();
            await WaitForCompletionAsync(operation);
            // TODO: restore to use Delete of the specific resource container: ADO 5998
            //Operation connectionMonitorsDeleteOperation = await ConnectionMonitors.Get(connectionMonitorName2).Value.StartDeleteAsync();
            //await WaitForCompletionAsync(connectionMonitorsDeleteOperation);
            AsyncPageable<ConnectionMonitor> getConnectionMonitors2 = ConnectionMonitors.GetAllAsync();
            Has.One.EqualTo(getConnectionMonitors2);
        }
    }
}
