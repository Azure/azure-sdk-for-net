// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
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
    public class PacketCaptureTests : NetworkTestsManagementClientBase
    {
        public PacketCaptureTests(bool isAsync) : base(isAsync)
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
        public async Task PacketCaptureApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with template
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

            string pcName1 = "pc1";
            string pcName2 = "pc2";

            PacketCapture pcProperties = new PacketCapture(getVm.Value.Id, new PacketCaptureStorageLocation { FilePath = @"C:\tmp\Capture.cap" });

            PacketCapturesCreateOperation createPacketCapture1Operation = await NetworkManagementClient.PacketCaptures.StartCreateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", pcName1, pcProperties);
            Response<PacketCaptureResult> createPacketCapture1 = await WaitForCompletionAsync(createPacketCapture1Operation);
            Response<PacketCaptureResult> getPacketCapture = await NetworkManagementClient.PacketCaptures.GetAsync("NetworkWatcherRG", "NetworkWatcher_westus2", pcName1);
            PacketCapturesGetStatusOperation queryPCOperation = await NetworkManagementClient.PacketCaptures.StartGetStatusAsync("NetworkWatcherRG", "NetworkWatcher_westus2", pcName1);
            await WaitForCompletionAsync(queryPCOperation);

            //Validation
            Assert.AreEqual(pcName1, createPacketCapture1.Value.Name);
            Assert.AreEqual(1073741824, createPacketCapture1.Value.TotalBytesPerSession);
            Assert.AreEqual(0, createPacketCapture1.Value.BytesToCapturePerPacket);
            Assert.AreEqual(18000, createPacketCapture1.Value.TimeLimitInSeconds);
            Assert.AreEqual(@"C:\tmp\Capture.cap", createPacketCapture1.Value.StorageLocation.FilePath);
            Assert.AreEqual("Succeeded", getPacketCapture.Value.ProvisioningState.ToString());

            PacketCapturesCreateOperation packetCapturesCreateOperation = await NetworkManagementClient.PacketCaptures.StartCreateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", pcName2, pcProperties);
            await WaitForCompletionAsync(packetCapturesCreateOperation);

            AsyncPageable<PacketCaptureResult> listPCByRg1AP = NetworkManagementClient.PacketCaptures.ListAsync("NetworkWatcherRG", "NetworkWatcher_westus2");
            List<PacketCaptureResult> listPCByRg1 = await listPCByRg1AP.ToEnumerableAsync();

            PacketCapturesStopOperation packetCapturesStopOperation = await NetworkManagementClient.PacketCaptures.StartStopAsync("NetworkWatcherRG", "NetworkWatcher_westus2", pcName1);
            await WaitForCompletionAsync(packetCapturesStopOperation);

            PacketCapturesGetStatusOperation queryPCAfterStopOperation = await NetworkManagementClient.PacketCaptures.StartGetStatusAsync("NetworkWatcherRG", "NetworkWatcher_westus2", pcName1);
            Response<PacketCaptureQueryStatusResult> queryPCAfterStop = await WaitForCompletionAsync(queryPCAfterStopOperation);

            PacketCapturesDeleteOperation packetCapturesDeleteOperation = await NetworkManagementClient.PacketCaptures.StartDeleteAsync("NetworkWatcherRG", "NetworkWatcher_westus2", pcName1);
            await WaitForCompletionAsync(packetCapturesDeleteOperation);
            AsyncPageable<PacketCaptureResult> listPCByRg2 = NetworkManagementClient.PacketCaptures.ListAsync("NetworkWatcherRG", "NetworkWatcher_westus2");

            //Validation
            Assert.AreEqual(2, listPCByRg1.Count());
            Assert.AreEqual("Stopped", queryPCAfterStop.Value.PacketCaptureStatus.ToString());
            Assert.AreEqual("Manual", queryPCAfterStop.Value.StopReason);
            Has.One.EqualTo(listPCByRg2);
        }
    }
}
