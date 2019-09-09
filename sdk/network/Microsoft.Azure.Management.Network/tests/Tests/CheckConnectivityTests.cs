using System.Collections.Generic;
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

    public class CheckConnectivityTests
    {
        [Fact(Skip = "DisableTests")]
        public void CheckConnectivityVmToInternetTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1, true);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var computeManagementClient = NetworkManagementTestUtilities.GetComputeManagementClientWithHandler(context, handler3);

                string location = "westcentralus";

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
                VirtualMachineExtension parameters = new VirtualMachineExtension();
                parameters.Publisher = "Microsoft.Azure.NetworkWatcher.Edp";
                parameters.TypeHandlerVersion = "1.4";
                parameters.VirtualMachineExtensionType = "NetworkWatcherAgentWindows";
                parameters.Location = location;

                var addExtension = computeManagementClient.VirtualMachineExtensions.CreateOrUpdate(resourceGroupName, getVm.Name, "NetworkWatcherAgent", parameters);

                string networkWatcherName = TestUtilities.GenerateName();
                NetworkWatcher properties = new NetworkWatcher();
                properties.Location = location;

                //Create network Watcher
                var createNetworkWatcher = networkManagementClient.NetworkWatchers.CreateOrUpdate(resourceGroupName, networkWatcherName, properties);

                ConnectivityParameters connectivityParameters = new ConnectivityParameters();
                connectivityParameters.Source = new ConnectivitySource();
                connectivityParameters.Source.ResourceId = getVm.Id;
                connectivityParameters.Destination = new ConnectivityDestination();
                connectivityParameters.Destination.Address = "bing.com";
                connectivityParameters.Destination.Port = 80;

                var connectivityCheck = networkManagementClient.NetworkWatchers.CheckConnectivity(resourceGroupName, networkWatcherName, connectivityParameters);

                //Validation
                Assert.Equal("Reachable", connectivityCheck.ConnectionStatus);
                Assert.Equal(0, connectivityCheck.ProbesFailed);
                Assert.Equal("Source", connectivityCheck.Hops.FirstOrDefault().Type);
                Assert.Equal("Internet", connectivityCheck.Hops.LastOrDefault().Type);
            }
        }
    }
}

