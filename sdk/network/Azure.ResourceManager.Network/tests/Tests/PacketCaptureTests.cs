// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
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
    public class PacketCaptureTests : NetworkServiceClientTestBase
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

        //[TearDown]
        //public async Task CleanupResourceGroup()
        //{
        //    await CleanupResourceGroupsAsync();
        //}

        [Test]
        public async Task PacketCaptureApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new Resources.Models.ResourceGroup(location));
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
            await createOrUpdateOperation.WaitForCompletionAsync();;

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcher properties = new NetworkWatcher { Location = location };
            //await networkWatcherContainer.CreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string pcName1 = "pc1";
            string pcName2 = "pc2";

            var pcProperties = new PacketCaptureInput(getVm.Value.Id, new PacketCaptureStorageLocation(){/*Id = getVm.Value.Data.Id, StorageLocation = new PacketCaptureStorageLocation { FilePath = @"C:\tmp\Capture.cap" }*/});

            var packetCaptureContainer = GetNetworkWatcherContainer("NetworkWatcherRG").Get("NetworkWatcher_westus2").Value.GetPacketCaptures();
            PacketCapturesCreateOperation createPacketCapture1Operation = await packetCaptureContainer.StartCreateOrUpdateAsync(pcName1, pcProperties);
            var createPacketCapture1 = await createPacketCapture1Operation.WaitForCompletionAsync();;
            Response<PacketCapture> getPacketCapture = await packetCaptureContainer.GetAsync(pcName1);
            PacketCapturesGetStatusOperation queryPCOperation = await getPacketCapture.Value.StartGetStatusAsync();
            await queryPCOperation.WaitForCompletionAsync();;

            //Validation
            Assert.AreEqual(pcName1, createPacketCapture1.Value.Data.Name);
            Assert.AreEqual(1073741824, createPacketCapture1.Value.Data.TotalBytesPerSession);
            Assert.AreEqual(0, createPacketCapture1.Value.Data.BytesToCapturePerPacket);
            Assert.AreEqual(18000, createPacketCapture1.Value.Data.TimeLimitInSeconds);
            Assert.AreEqual(@"C:\tmp\Capture.cap", createPacketCapture1.Value.Data.StorageLocation.FilePath);
            Assert.AreEqual("Succeeded", getPacketCapture.Value.Data.ProvisioningState.ToString());

            PacketCapturesCreateOperation packetCapturesCreateOperation = await packetCaptureContainer.StartCreateOrUpdateAsync(pcName2, pcProperties);
            await packetCapturesCreateOperation.WaitForCompletionAsync();;

            AsyncPageable<PacketCapture> listPCByRg1AP = packetCaptureContainer.GetAllAsync();
            List<PacketCapture> listPCByRg1 = await listPCByRg1AP.ToEnumerableAsync();

            PacketCapturesStopOperation packetCapturesStopOperation = await getPacketCapture.Value.StartStopAsync();
            await packetCapturesStopOperation.WaitForCompletionResponseAsync();;

            PacketCapturesGetStatusOperation queryPCAfterStopOperation = await getPacketCapture.Value.StartGetStatusAsync();
            Response<PacketCaptureQueryStatusResult> queryPCAfterStop = await queryPCAfterStopOperation.WaitForCompletionAsync();;

            PacketCapturesDeleteOperation packetCapturesDeleteOperation = await getPacketCapture.Value.StartDeleteAsync();
            await packetCapturesDeleteOperation.WaitForCompletionResponseAsync();;
            AsyncPageable<PacketCapture> listPCByRg2 = packetCaptureContainer.GetAllAsync();

            //Validation
            Assert.AreEqual(2, listPCByRg1.Count());
            Assert.AreEqual("Stopped", queryPCAfterStop.Value.PacketCaptureStatus.ToString());
            Assert.AreEqual("Manual", queryPCAfterStop.Value.StopReason);
            Has.One.EqualTo(listPCByRg2);
        }
    }
}
