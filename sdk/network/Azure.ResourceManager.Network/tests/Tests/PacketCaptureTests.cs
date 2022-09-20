// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
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

        [Test]
        [RecordedTest]
        [Ignore("Review after preview")]
        public async Task PacketCaptureApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            var resourceGroup = await CreateResourceGroup(resourceGroupName, location);
            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with template
            var vm = await CreateWindowsVM(virtualMachineName, networkInterfaceName, location, resourceGroup);

            //Deploy networkWatcherAgent on VM
            await deployWindowsNetworkAgent(virtualMachineName, location, resourceGroup);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcherResource properties = new NetworkWatcherResource { Location = location };
            //await networkWatcherCollection.CreateOrUpdateAsync(true, "NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            string pcName1 = "pc1";
            string pcName2 = "pc2";

            var pcProperties = new PacketCaptureCreateOrUpdateContent(vm.Id, new PacketCaptureStorageLocation(){/*Id = getVm.Value.Data.Id, StorageLocation = new PacketCaptureStorageLocation { FilePath = @"C:\tmp\Capture.cap" }*/});

            var packetCaptureCollection = GetNetworkWatcherCollection("NetworkWatcherRG").Get("NetworkWatcher_westus2").Value.GetPacketCaptures();
            var  createPacketCapture1Operation = await packetCaptureCollection.CreateOrUpdateAsync(WaitUntil.Completed, pcName1, pcProperties);
            var createPacketCapture1 = await createPacketCapture1Operation.WaitForCompletionAsync();;
            Response<PacketCaptureResource> getPacketCapture = await packetCaptureCollection.GetAsync(pcName1);
            var queryPCOperation = await getPacketCapture.Value.GetStatusAsync(WaitUntil.Completed);
            await queryPCOperation.WaitForCompletionAsync();;

            //Validation
            Assert.AreEqual(pcName1, createPacketCapture1.Value.Data.Name);
            Assert.AreEqual(1073741824, createPacketCapture1.Value.Data.TotalBytesPerSession);
            Assert.AreEqual(0, createPacketCapture1.Value.Data.BytesToCapturePerPacket);
            Assert.AreEqual(18000, createPacketCapture1.Value.Data.TimeLimitInSeconds);
            Assert.AreEqual(@"C:\tmp\Capture.cap", createPacketCapture1.Value.Data.StorageLocation.FilePath);
            Assert.AreEqual("Succeeded", getPacketCapture.Value.Data.ProvisioningState.ToString());

            var  packetCapturesCreateOperation = await packetCaptureCollection.CreateOrUpdateAsync(WaitUntil.Completed, pcName2, pcProperties);
            await packetCapturesCreateOperation.WaitForCompletionAsync();;

            AsyncPageable<PacketCaptureResource> listPCByRg1AP = packetCaptureCollection.GetAllAsync();
            List<PacketCaptureResource> listPCByRg1 = await listPCByRg1AP.ToEnumerableAsync();

            var packetCapturesStopOperation = await getPacketCapture.Value.StopAsync(WaitUntil.Completed);
            await packetCapturesStopOperation.WaitForCompletionResponseAsync();;

            var queryPCAfterStopOperation = await getPacketCapture.Value.GetStatusAsync(WaitUntil.Completed);
            Response<PacketCaptureQueryStatusResult> queryPCAfterStop = await queryPCAfterStopOperation.WaitForCompletionAsync();;

            var packetCapturesDeleteOperation = await getPacketCapture.Value.DeleteAsync(WaitUntil.Completed);
            await packetCapturesDeleteOperation.WaitForCompletionResponseAsync();;
            AsyncPageable<PacketCaptureResource> listPCByRg2 = packetCaptureCollection.GetAllAsync();

            //Validation
            Assert.AreEqual(2, listPCByRg1.Count());
            Assert.AreEqual("Stopped", queryPCAfterStop.Value.PacketCaptureStatus.ToString());
            Assert.AreEqual("Manual", queryPCAfterStop.Value.StopReason);
            Has.One.EqualTo(listPCByRg2);
        }
    }
}
