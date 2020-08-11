using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;

namespace Network.Tests.Tests
{
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Helpers;

    public class PacketCaptureTests
    {
        [Fact(Skip="Disable tests")]
        public void PacketCaptureApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
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

                //Deploy VM with template
                Deployments.CreateVm(
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

                string pcName1 = "pc1";
                string pcName2 = "pc2";

                PacketCapture pcProperties = new PacketCapture();
                pcProperties.Target = getVm.Id;

                pcProperties.StorageLocation = new PacketCaptureStorageLocation
                {
                    FilePath = @"C:\tmp\Capture.cap"
                };

                var createPacketCapture1 = networkManagementClient.PacketCaptures.Create(resourceGroupName, networkWatcherName, pcName1, pcProperties);
                var getPacketCapture = networkManagementClient.PacketCaptures.Get(resourceGroupName, networkWatcherName, pcName1);
                var queryPC = networkManagementClient.PacketCaptures.GetStatus(resourceGroupName, networkWatcherName, pcName1);

                //Validation
                Assert.Equal(pcName1, createPacketCapture1.Name);
                Assert.Equal(1073741824, createPacketCapture1.TotalBytesPerSession);
                Assert.Equal(0, createPacketCapture1.BytesToCapturePerPacket);
                Assert.Equal(18000, createPacketCapture1.TimeLimitInSeconds);
                Assert.Equal(@"C:\tmp\Capture.cap", createPacketCapture1.StorageLocation.FilePath);
                Assert.Equal("Succeeded", getPacketCapture.ProvisioningState);

                var createPacketCapture2 = networkManagementClient.PacketCaptures.Create(resourceGroupName, networkWatcherName, pcName2, pcProperties);
                var listPCByRg1 = networkManagementClient.PacketCaptures.List(resourceGroupName, networkWatcherName);
                networkManagementClient.PacketCaptures.Stop(resourceGroupName, networkWatcherName, pcName1);
                var queryPCAfterStop = networkManagementClient.PacketCaptures.GetStatus(resourceGroupName, networkWatcherName, pcName1);
                networkManagementClient.PacketCaptures.Delete(resourceGroupName, networkWatcherName, pcName1);
                var listPCByRg2 = networkManagementClient.PacketCaptures.List(resourceGroupName, networkWatcherName);


                //Validation
                Assert.Equal(2, listPCByRg1.Count());
                Assert.Equal("Stopped", queryPCAfterStop.PacketCaptureStatus);
                Assert.Equal("Manual", queryPCAfterStop.StopReason);
                Assert.Single(listPCByRg2);
            }
        }
    }
}

