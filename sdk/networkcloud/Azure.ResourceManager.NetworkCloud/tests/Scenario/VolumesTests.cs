// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.ResourceManager.NetworkCloud.Tests.ScenarioTests
{
    public class VolumesTests : NetworkCloudManagementTestBase
    {
        public VolumesTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public VolumesTests(bool isAsync) : base(isAsync) {}

        [Test]
        [RecordedTest]
        public async Task Volumes()
        {
            string volumeName = Recording.GenerateAssetName("volume");
            string resourceGroupName = TestEnvironment.ResourceGroup;
            string subscriptionId = TestEnvironment.SubscriptionId;

            // Create ResourceIds
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceIdentifier volumeResourceId = NetworkCloudVolumeResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, volumeName);

            // Create Resource Group Object and Volume Collections Object
            ResourceGroupResource resourceGroupResource = Client.GetResourceGroupResource(resourceGroupResourceId);
            NetworkCloudVolumeCollection collection = resourceGroupResource.GetNetworkCloudVolumes();

            // Create Volume
            NetworkCloudVolumeData createData = new NetworkCloudVolumeData(TestEnvironment.Location, new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation"), 10);
            ArmOperation<NetworkCloudVolumeResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName, createData);
            Assert.AreEqual(createResult.Value.Data.Name, volumeName);

            // Get Volume
            NetworkCloudVolumeResource volume = Client.GetNetworkCloudVolumeResource(volumeResourceId);
            NetworkCloudVolumeResource getResult = await volume.GetAsync();
            Assert.AreEqual(volumeName, getResult.Data.Name);

            // Update Volume
            NetworkCloudVolumePatch updateData = new NetworkCloudVolumePatch()
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                    ["key2"] = "myvalue2",
                },
            };
            Response<NetworkCloudVolumeResource> updateResult = await volume.UpdateAsync(updateData);
            Assert.AreEqual(updateData.Tags, updateResult.Value.Data.Tags);

            // List Volumes by Resource Group
            var listByResourceGroupResult = new List<NetworkCloudVolumeResource>();
            await foreach (NetworkCloudVolumeResource volumeResource in collection.GetAllAsync())
            {
                listByResourceGroupResult.Add(volumeResource);
            }
            Assert.IsNotEmpty(listByResourceGroupResult);

            // List Volumes by Subscription
            var listBySubscriptionResult = new List<NetworkCloudVolumeResource>();
            await foreach (NetworkCloudVolumeResource volumeResource in SubscriptionResource.GetNetworkCloudVolumesAsync())
            {
                listBySubscriptionResult.Add(volumeResource);
            }
            Assert.IsNotEmpty(listBySubscriptionResult);

            // Delete Volume
            var deleteResult = await volume.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}
