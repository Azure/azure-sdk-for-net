// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Compute;
using Azure.Management.Compute.Models;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class ConnectionMonitorTests : NetworkTestsManagementClientBase
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

        [Test]
        [Ignore("Track2: ApiVersion does not meet the requirements")]
        public async Task PutConnectionMonitorTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
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
            //await NetworkManagementClient.NetworkWatchers.CreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName = "cm";
            ConnectionMonitor cm = new ConnectionMonitor
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

            Operation<ConnectionMonitorResult> putConnectionMonitorOperation = await NetworkManagementClient.ConnectionMonitors.StartCreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName, cm);
            Response<ConnectionMonitorResult> putConnectionMonitor = await WaitForCompletionAsync(putConnectionMonitorOperation);

            Assert.AreEqual("Running", putConnectionMonitor.Value.MonitoringStatus);
            Assert.AreEqual("centraluseuap", putConnectionMonitor.Value.Location);
            Assert.AreEqual(30, putConnectionMonitor.Value.MonitoringIntervalInSeconds);
            Assert.AreEqual(connectionMonitorName, putConnectionMonitor.Value.Name);
            Assert.AreEqual(getVm.Value.Id, putConnectionMonitor.Value.Source.ResourceId);
            Assert.AreEqual("bing.com", putConnectionMonitor.Value.Destination.Address);
            Assert.AreEqual(80, putConnectionMonitor.Value.Destination.Port);
        }

        [Test]
        [Ignore("Track2: ApiVersion does not meet the requirements")]
        public async Task StartConnectionMonitorTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

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
            //await NetworkManagementClient.NetworkWatchers.CreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName = Recording.GenerateAssetName("azsmnet");
            ConnectionMonitor cm = new ConnectionMonitor
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

            Operation<ConnectionMonitorResult> putConnectionMonitorOperation = await NetworkManagementClient.ConnectionMonitors.StartCreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName, cm);
            Response<ConnectionMonitorResult> putConnectionMonitor = await WaitForCompletionAsync(putConnectionMonitorOperation);
            Assert.AreEqual("NotStarted", putConnectionMonitor.Value.MonitoringStatus);

            ConnectionMonitorsStartOperation connectionMonitorsStartOperation = await NetworkManagementClient.ConnectionMonitors.StartStartAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName);
            await WaitForCompletionAsync(connectionMonitorsStartOperation);

            Response<ConnectionMonitorResult> getConnectionMonitor = await NetworkManagementClient.ConnectionMonitors.GetAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName);
            Assert.AreEqual("Running", getConnectionMonitor.Value.MonitoringStatus);
        }

        [Test]
        [Ignore("Track2: ApiVersion does not meet the requirements")]
        public async Task StopConnectionMonitorTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
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
            //await NetworkManagementClient.NetworkWatchers.CreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName = Recording.GenerateAssetName("azsmnet");
            ConnectionMonitor cm = new ConnectionMonitor
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

            Operation<ConnectionMonitorResult> putConnectionMonitorOperation = await NetworkManagementClient.ConnectionMonitors.StartCreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName, cm);
            Response<ConnectionMonitorResult> putConnectionMonitor = await WaitForCompletionAsync(putConnectionMonitorOperation);
            Assert.AreEqual("Running", putConnectionMonitor.Value.MonitoringStatus);

            ConnectionMonitorsStopOperation connectionMonitorsStopOperation = await NetworkManagementClient.ConnectionMonitors.StartStopAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName);
            await WaitForCompletionAsync(connectionMonitorsStopOperation);

            Response<ConnectionMonitorResult> getConnectionMonitor = await NetworkManagementClient.ConnectionMonitors.GetAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName);
            Assert.AreEqual("Stopped", getConnectionMonitor.Value.MonitoringStatus);
        }

        [Test]
        [Ignore("Track2: ApiVersion does not meet the requirements")]
        public async Task QueryConnectionMonitorTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
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
            //await NetworkManagementClient.NetworkWatchers.CreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName = Recording.GenerateAssetName("azsmnet");
            ConnectionMonitor cm = new ConnectionMonitor
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

            Operation<ConnectionMonitorResult> putConnectionMonitorOperation = await NetworkManagementClient.ConnectionMonitors.StartCreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName, cm);
            await WaitForCompletionAsync(putConnectionMonitorOperation);

            ConnectionMonitorsStartOperation connectionMonitorsStartOperation = await NetworkManagementClient.ConnectionMonitors.StartStartAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName);
            await WaitForCompletionAsync(connectionMonitorsStartOperation);

            ConnectionMonitorsStopOperation connectionMonitorsStopOperation = await NetworkManagementClient.ConnectionMonitors.StartStopAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName);
            await WaitForCompletionAsync(connectionMonitorsStopOperation);

            Operation<ConnectionMonitorQueryResult> queryResultOperation = await NetworkManagementClient.ConnectionMonitors.StartQueryAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName);
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
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
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
            //await NetworkManagementClient.NetworkWatchers.CreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName = Recording.GenerateAssetName("azsmnet");
            ConnectionMonitor cm = new ConnectionMonitor
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

            Operation<ConnectionMonitorResult> putConnectionMonitorOperation = await NetworkManagementClient.ConnectionMonitors.StartCreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName, cm);
            Response<ConnectionMonitorResult> putConnectionMonitor = await WaitForCompletionAsync(putConnectionMonitorOperation);
            Assert.AreEqual(30, putConnectionMonitor.Value.MonitoringIntervalInSeconds);

            cm.MonitoringIntervalInSeconds = 60;
            Operation<ConnectionMonitorResult> updateConnectionMonitorOperation = await NetworkManagementClient.ConnectionMonitors.StartCreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName, cm);
            Response<ConnectionMonitorResult> updateConnectionMonitor = await WaitForCompletionAsync(updateConnectionMonitorOperation);
            Assert.AreEqual(60, updateConnectionMonitor.Value.MonitoringIntervalInSeconds);
        }

        [Test]
        [Ignore("Track2: ApiVersion does not meet the requirements")]
        public async Task DeleteConnectionMonitorTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
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
            //await NetworkManagementClient.NetworkWatchers.CreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string connectionMonitorName1 = Recording.GenerateAssetName("azsmnet");
            string connectionMonitorName2 = Recording.GenerateAssetName("azsmnet");
            ConnectionMonitor cm = new ConnectionMonitor
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

            Operation<ConnectionMonitorResult> connectionMonitor1Operation = await NetworkManagementClient.ConnectionMonitors.StartCreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName1, cm);
            await WaitForCompletionAsync(connectionMonitor1Operation);
            Operation<ConnectionMonitorResult> connectionMonitor2Operation = await NetworkManagementClient.ConnectionMonitors.StartCreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName2, cm);
            await WaitForCompletionAsync(connectionMonitor2Operation);

            AsyncPageable<ConnectionMonitorResult> getConnectionMonitors1AP = NetworkManagementClient.ConnectionMonitors.ListAsync("NetworkWatcherRG", "NetworkWatcher_westus2");
            Task<List<ConnectionMonitorResult>> getConnectionMonitors1 = getConnectionMonitors1AP.ToEnumerableAsync();
            Assert.AreEqual(2, getConnectionMonitors1.Result.Count);

            ConnectionMonitorsDeleteOperation connectionMonitorsDeleteOperation = await NetworkManagementClient.ConnectionMonitors.StartDeleteAsync("NetworkWatcherRG", "NetworkWatcher_westus2", connectionMonitorName2);
            await WaitForCompletionAsync(connectionMonitorsDeleteOperation);
            AsyncPageable<ConnectionMonitorResult> getConnectionMonitors2 = NetworkManagementClient.ConnectionMonitors.ListAsync("NetworkWatcherRG", "NetworkWatcher_westus2");
            Has.One.EqualTo(getConnectionMonitors2);
        }
    }
}
