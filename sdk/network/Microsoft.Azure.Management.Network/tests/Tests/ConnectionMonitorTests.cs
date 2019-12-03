using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;


namespace Network.Tests.Tests
{
    using System.Linq;

    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Helpers;
    using Microsoft.Azure.Management.Compute.Models;

    public class ConnectionMonitorTests
    {
        [Fact(Skip = "Disable tests")]
        public void PutConnectionMonitorTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1, true);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var computeManagementClient = NetworkManagementTestUtilities.GetComputeManagementClientWithHandler(context, handler3);

                string location = "centraluseuap";

                string resourceGroupName = TestUtilities.GenerateName();
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string virtualMachineName = TestUtilities.GenerateName();
                string networkInterfaceName = TestUtilities.GenerateName();
                string networkSecurityGroupName = virtualMachineName + "-nsg";

                //Deploy VM with a template
                DeploymentUpdate.CreateVm(
                    resourcesClient: resourcesClient,
                    resourceGroupName: resourceGroupName,
                    location: location,
                    virtualMachineName: virtualMachineName,
                    storageAccountName: TestUtilities.GenerateName(),
                    networkInterfaceName: networkInterfaceName,
                    networkSecurityGroupName: networkSecurityGroupName,
                    diagnosticsStorageAccountName: TestUtilities.GenerateName(),
                    deploymentName: TestUtilities.GenerateName()
                    );

                var getVm = computeManagementClient.VirtualMachines.Get(resourceGroupName, virtualMachineName);

                //Deploy networkWatcherAgent on VM
                VirtualMachineExtension parameters = new VirtualMachineExtension
                {
                    Publisher = "Microsoft.Azure.NetworkWatcher",
                    TypeHandlerVersion = "1.4",
                    VirtualMachineExtensionType = "NetworkWatcherAgentWindows",
                    Location = location
                };

                var addExtension = computeManagementClient.VirtualMachineExtensions.CreateOrUpdate(resourceGroupName, getVm.Name, "NetworkWatcherAgent", parameters);

                string networkWatcherName = TestUtilities.GenerateName();
                NetworkWatcher properties = new NetworkWatcher
                {
                    Location = location
                };

                //Create network Watcher
                var createNetworkWatcher = networkManagementClient.NetworkWatchers.CreateOrUpdate(resourceGroupName, networkWatcherName, properties);

                string connectionMonitorName = "cm";
                ConnectionMonitor cm = new ConnectionMonitor
                {
                    Location = location,
                    Source = new ConnectionMonitorSource
                    {
                        ResourceId = getVm.Id
                    },
                    Destination = new ConnectionMonitorDestination
                    {
                        Address = "bing.com",
                        Port = 80
                    },
                    MonitoringIntervalInSeconds = 30
                };

                var putConnectionMonitor = networkManagementClient.ConnectionMonitors.CreateOrUpdate(resourceGroupName, networkWatcherName, connectionMonitorName, cm);
                Assert.Equal("Running", putConnectionMonitor.MonitoringStatus);
                Assert.Equal("centraluseuap", putConnectionMonitor.Location);
                Assert.Equal(30, putConnectionMonitor.MonitoringIntervalInSeconds);
                Assert.Equal(connectionMonitorName, putConnectionMonitor.Name);
                Assert.Equal(getVm.Id, putConnectionMonitor.Source.ResourceId);
                Assert.Equal("bing.com", putConnectionMonitor.Destination.Address);
                Assert.Equal(80, putConnectionMonitor.Destination.Port);
            }
        }

        [Fact(Skip = "Disable tests")]
        public void StartConnectionMonitorTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1, true);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var computeManagementClient = NetworkManagementTestUtilities.GetComputeManagementClientWithHandler(context, handler3);

                string location = "centraluseuap";

                string resourceGroupName = TestUtilities.GenerateName();
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string virtualMachineName = TestUtilities.GenerateName();
                string networkInterfaceName = TestUtilities.GenerateName();
                string networkSecurityGroupName = virtualMachineName + "-nsg";

                //Deploy VM with a template
                DeploymentUpdate.CreateVm(
                    resourcesClient: resourcesClient,
                    resourceGroupName: resourceGroupName,
                    location: location,
                    virtualMachineName: virtualMachineName,
                    storageAccountName: TestUtilities.GenerateName(),
                    networkInterfaceName: networkInterfaceName,
                    networkSecurityGroupName: networkSecurityGroupName,
                    diagnosticsStorageAccountName: TestUtilities.GenerateName(),
                    deploymentName: TestUtilities.GenerateName()
                    );

                var getVm = computeManagementClient.VirtualMachines.Get(resourceGroupName, virtualMachineName);

                //Deploy networkWatcherAgent on VM
                VirtualMachineExtension parameters = new VirtualMachineExtension
                {
                    Publisher = "Microsoft.Azure.NetworkWatcher",
                    TypeHandlerVersion = "1.4",
                    VirtualMachineExtensionType = "NetworkWatcherAgentWindows",
                    Location = location
                };

                var addExtension = computeManagementClient.VirtualMachineExtensions.CreateOrUpdate(resourceGroupName, getVm.Name, "NetworkWatcherAgent", parameters);

                string networkWatcherName = TestUtilities.GenerateName();
                NetworkWatcher properties = new NetworkWatcher
                {
                    Location = location
                };

                //Create network Watcher
                var createNetworkWatcher = networkManagementClient.NetworkWatchers.CreateOrUpdate(resourceGroupName, networkWatcherName, properties);

                string connectionMonitorName = TestUtilities.GenerateName();
                ConnectionMonitor cm = new ConnectionMonitor
                {
                    Location = location,
                    Source = new ConnectionMonitorSource
                    {
                        ResourceId = getVm.Id
                    },
                    Destination = new ConnectionMonitorDestination
                    {
                        Address = "bing.com",
                        Port = 80
                    },
                    MonitoringIntervalInSeconds = 30,
                    AutoStart = false
                };

                var putConnectionMonitor = networkManagementClient.ConnectionMonitors.CreateOrUpdate(resourceGroupName, networkWatcherName, connectionMonitorName, cm);
                Assert.Equal("NotStarted", putConnectionMonitor.MonitoringStatus);

                networkManagementClient.ConnectionMonitors.Start(resourceGroupName, networkWatcherName, connectionMonitorName);
                var getConnectionMonitor = networkManagementClient.ConnectionMonitors.Get(resourceGroupName, networkWatcherName, connectionMonitorName);
                Assert.Equal("Running", getConnectionMonitor.MonitoringStatus);
            }
        }

        [Fact(Skip = "Disable tests")]
        public void StopConnectionMonitorTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1, true);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var computeManagementClient = NetworkManagementTestUtilities.GetComputeManagementClientWithHandler(context, handler3);

                string location = "centraluseuap";

                string resourceGroupName = TestUtilities.GenerateName();
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string virtualMachineName = TestUtilities.GenerateName();
                string networkInterfaceName = TestUtilities.GenerateName();
                string networkSecurityGroupName = virtualMachineName + "-nsg";

                //Deploy VM with a template
                DeploymentUpdate.CreateVm(
                    resourcesClient: resourcesClient,
                    resourceGroupName: resourceGroupName,
                    location: location,
                    virtualMachineName: virtualMachineName,
                    storageAccountName: TestUtilities.GenerateName(),
                    networkInterfaceName: networkInterfaceName,
                    networkSecurityGroupName: networkSecurityGroupName,
                    diagnosticsStorageAccountName: TestUtilities.GenerateName(),
                    deploymentName: TestUtilities.GenerateName()
                    );

                var getVm = computeManagementClient.VirtualMachines.Get(resourceGroupName, virtualMachineName);

                //Deploy networkWatcherAgent on VM
                VirtualMachineExtension parameters = new VirtualMachineExtension
                {
                    Publisher = "Microsoft.Azure.NetworkWatcher",
                    TypeHandlerVersion = "1.4",
                    VirtualMachineExtensionType = "NetworkWatcherAgentWindows",
                    Location = location
                };

                var addExtension = computeManagementClient.VirtualMachineExtensions.CreateOrUpdate(resourceGroupName, getVm.Name, "NetworkWatcherAgent", parameters);

                string networkWatcherName = TestUtilities.GenerateName();
                NetworkWatcher properties = new NetworkWatcher
                {
                    Location = location
                };

                //Create network Watcher
                var createNetworkWatcher = networkManagementClient.NetworkWatchers.CreateOrUpdate(resourceGroupName, networkWatcherName, properties);

                string connectionMonitorName = TestUtilities.GenerateName();
                ConnectionMonitor cm = new ConnectionMonitor
                {
                    Location = location,
                    Source = new ConnectionMonitorSource
                    {
                        ResourceId = getVm.Id
                    },
                    Destination = new ConnectionMonitorDestination
                    {
                        Address = "bing.com",
                        Port = 80
                    },
                    MonitoringIntervalInSeconds = 30
                };

                var putConnectionMonitor = networkManagementClient.ConnectionMonitors.CreateOrUpdate(resourceGroupName, networkWatcherName, connectionMonitorName, cm);
                Assert.Equal("Running", putConnectionMonitor.MonitoringStatus);

                networkManagementClient.ConnectionMonitors.Stop(resourceGroupName, networkWatcherName, connectionMonitorName);
                var getConnectionMonitor = networkManagementClient.ConnectionMonitors.Get(resourceGroupName, networkWatcherName, connectionMonitorName);
                Assert.Equal("Stopped", getConnectionMonitor.MonitoringStatus);
            }
        }

        [Fact(Skip = "Disable tests")]
        public void QueryConnectionMonitorTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1, true);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var computeManagementClient = NetworkManagementTestUtilities.GetComputeManagementClientWithHandler(context, handler3);

                string location = "centraluseuap";

                string resourceGroupName = TestUtilities.GenerateName();
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string virtualMachineName = TestUtilities.GenerateName();
                string networkInterfaceName = TestUtilities.GenerateName();
                string networkSecurityGroupName = virtualMachineName + "-nsg";

                //Deploy VM with a template
                DeploymentUpdate.CreateVm(
                    resourcesClient: resourcesClient,
                    resourceGroupName: resourceGroupName,
                    location: location,
                    virtualMachineName: virtualMachineName,
                    storageAccountName: TestUtilities.GenerateName(),
                    networkInterfaceName: networkInterfaceName,
                    networkSecurityGroupName: networkSecurityGroupName,
                    diagnosticsStorageAccountName: TestUtilities.GenerateName(),
                    deploymentName: TestUtilities.GenerateName()
                    );

                var getVm = computeManagementClient.VirtualMachines.Get(resourceGroupName, virtualMachineName);

                //Deploy networkWatcherAgent on VM
                VirtualMachineExtension parameters = new VirtualMachineExtension
                {
                    Publisher = "Microsoft.Azure.NetworkWatcher",
                    TypeHandlerVersion = "1.4",
                    VirtualMachineExtensionType = "NetworkWatcherAgentWindows",
                    Location = location
                };

                var addExtension = computeManagementClient.VirtualMachineExtensions.CreateOrUpdate(resourceGroupName, getVm.Name, "NetworkWatcherAgent", parameters);

                string networkWatcherName = TestUtilities.GenerateName();
                NetworkWatcher properties = new NetworkWatcher
                {
                    Location = location
                };

                //Create network Watcher
                var createNetworkWatcher = networkManagementClient.NetworkWatchers.CreateOrUpdate(resourceGroupName, networkWatcherName, properties);

                string connectionMonitorName = TestUtilities.GenerateName();
                ConnectionMonitor cm = new ConnectionMonitor
                {
                    Location = location,
                    Source = new ConnectionMonitorSource
                    {
                        ResourceId = getVm.Id
                    },
                    Destination = new ConnectionMonitorDestination
                    {
                        Address = "bing.com",
                        Port = 80
                    },
                    MonitoringIntervalInSeconds = 30
                };

                var putConnectionMonitor = networkManagementClient.ConnectionMonitors.CreateOrUpdate(resourceGroupName, networkWatcherName, connectionMonitorName, cm);
                networkManagementClient.ConnectionMonitors.Start(resourceGroupName, networkWatcherName, connectionMonitorName);
                networkManagementClient.ConnectionMonitors.Stop(resourceGroupName, networkWatcherName, connectionMonitorName);
                var queryResult = networkManagementClient.ConnectionMonitors.Query(resourceGroupName, networkWatcherName, connectionMonitorName);
                Assert.Single(queryResult.States);
                Assert.Equal("Reachable", queryResult.States[0].ConnectionState);
                Assert.Equal("InProgress", queryResult.States[0].EvaluationState);
                Assert.Equal(2, queryResult.States[0].Hops.Count());
            }
        }

        [Fact(Skip = "Disable tests")]
        public void UpdateConnectionMonitorTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1, true);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var computeManagementClient = NetworkManagementTestUtilities.GetComputeManagementClientWithHandler(context, handler3);

                string location = "centraluseuap";

                string resourceGroupName = TestUtilities.GenerateName();
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string virtualMachineName = TestUtilities.GenerateName();
                string networkInterfaceName = TestUtilities.GenerateName();
                string networkSecurityGroupName = virtualMachineName + "-nsg";

                //Deploy VM with a template
                DeploymentUpdate.CreateVm(
                    resourcesClient: resourcesClient,
                    resourceGroupName: resourceGroupName,
                    location: location,
                    virtualMachineName: virtualMachineName,
                    storageAccountName: TestUtilities.GenerateName(),
                    networkInterfaceName: networkInterfaceName,
                    networkSecurityGroupName: networkSecurityGroupName,
                    diagnosticsStorageAccountName: TestUtilities.GenerateName(),
                    deploymentName: TestUtilities.GenerateName()
                    );

                var getVm = computeManagementClient.VirtualMachines.Get(resourceGroupName, virtualMachineName);

                //Deploy networkWatcherAgent on VM
                VirtualMachineExtension parameters = new VirtualMachineExtension
                {
                    Publisher = "Microsoft.Azure.NetworkWatcher",
                    TypeHandlerVersion = "1.4",
                    VirtualMachineExtensionType = "NetworkWatcherAgentWindows",
                    Location = location
                };

                var addExtension = computeManagementClient.VirtualMachineExtensions.CreateOrUpdate(resourceGroupName, getVm.Name, "NetworkWatcherAgent", parameters);

                string networkWatcherName = TestUtilities.GenerateName();
                NetworkWatcher properties = new NetworkWatcher
                {
                    Location = location
                };

                //Create network Watcher
                var createNetworkWatcher = networkManagementClient.NetworkWatchers.CreateOrUpdate(resourceGroupName, networkWatcherName, properties);

                string connectionMonitorName = TestUtilities.GenerateName();
                ConnectionMonitor cm = new ConnectionMonitor
                {
                    Location = location,
                    Source = new ConnectionMonitorSource
                    {
                        ResourceId = getVm.Id
                    },
                    Destination = new ConnectionMonitorDestination
                    {
                        Address = "bing.com",
                        Port = 80
                    },
                    MonitoringIntervalInSeconds = 30
                };

                var putConnectionMonitor = networkManagementClient.ConnectionMonitors.CreateOrUpdate(resourceGroupName, networkWatcherName, connectionMonitorName, cm);
                Assert.Equal(30, putConnectionMonitor.MonitoringIntervalInSeconds);

                cm.MonitoringIntervalInSeconds = 60;
                var updateConnectionMonitor = networkManagementClient.ConnectionMonitors.CreateOrUpdate(resourceGroupName, networkWatcherName, connectionMonitorName, cm);
                Assert.Equal(60, updateConnectionMonitor.MonitoringIntervalInSeconds);
            }
        }

        [Fact(Skip = "Disable tests")]
        public void DeleteConnectionMonitorTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1, true);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var computeManagementClient = NetworkManagementTestUtilities.GetComputeManagementClientWithHandler(context, handler3);

                string location = "centraluseuap";

                string resourceGroupName = TestUtilities.GenerateName();
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string virtualMachineName = TestUtilities.GenerateName();
                string networkInterfaceName = TestUtilities.GenerateName();
                string networkSecurityGroupName = virtualMachineName + "-nsg";

                //Deploy VM with a template
                DeploymentUpdate.CreateVm(
                    resourcesClient: resourcesClient,
                    resourceGroupName: resourceGroupName,
                    location: location,
                    virtualMachineName: virtualMachineName,
                    storageAccountName: TestUtilities.GenerateName(),
                    networkInterfaceName: networkInterfaceName,
                    networkSecurityGroupName: networkSecurityGroupName,
                    diagnosticsStorageAccountName: TestUtilities.GenerateName(),
                    deploymentName: TestUtilities.GenerateName()
                    );

                var getVm = computeManagementClient.VirtualMachines.Get(resourceGroupName, virtualMachineName);

                //Deploy networkWatcherAgent on VM
                VirtualMachineExtension parameters = new VirtualMachineExtension
                {
                    Publisher = "Microsoft.Azure.NetworkWatcher",
                    TypeHandlerVersion = "1.4",
                    VirtualMachineExtensionType = "NetworkWatcherAgentWindows",
                    Location = location
                };

                var addExtension = computeManagementClient.VirtualMachineExtensions.CreateOrUpdate(resourceGroupName, getVm.Name, "NetworkWatcherAgent", parameters);

                string networkWatcherName = TestUtilities.GenerateName();
                NetworkWatcher properties = new NetworkWatcher
                {
                    Location = location
                };

                //Create network Watcher
                var createNetworkWatcher = networkManagementClient.NetworkWatchers.CreateOrUpdate(resourceGroupName, networkWatcherName, properties);

                string connectionMonitorName1 = TestUtilities.GenerateName();
                string connectionMonitorName2 = TestUtilities.GenerateName();
                ConnectionMonitor cm = new ConnectionMonitor
                {
                    Location = location,
                    Source = new ConnectionMonitorSource
                    {
                        ResourceId = getVm.Id
                    },
                    Destination = new ConnectionMonitorDestination
                    {
                        Address = "bing.com",
                        Port = 80
                    },
                    MonitoringIntervalInSeconds = 30,
                    AutoStart = false
                };

                var connectionMonitor1 = networkManagementClient.ConnectionMonitors.CreateOrUpdate(resourceGroupName, networkWatcherName, connectionMonitorName1, cm);
                var connectionMonitor2 = networkManagementClient.ConnectionMonitors.CreateOrUpdate(resourceGroupName, networkWatcherName, connectionMonitorName2, cm);

                var getConnectionMonitors1 = networkManagementClient.ConnectionMonitors.List(resourceGroupName, networkWatcherName);
                Assert.Equal(2, getConnectionMonitors1.Count());

                networkManagementClient.ConnectionMonitors.Delete(resourceGroupName, networkWatcherName, connectionMonitorName2);
                var getConnectionMonitors2 = networkManagementClient.ConnectionMonitors.List(resourceGroupName, networkWatcherName);
                Assert.Single(getConnectionMonitors2);
            }
        }
    }
}

