// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public async Task Volumes()
        {
            string volumeName = Recording.GenerateAssetName("volume");
            string resourceGroupName = TestEnvironment.ResourceGroup;
            string subscriptionId = TestEnvironment.SubscriptionId;

            // Create ResourceIds
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceIdentifier volumeResourceId = VolumeResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, volumeName);

            // Create Resource Group Object and Volume Collections Object
            ResourceGroupResource resourceGroupResource = Client.GetResourceGroupResource(resourceGroupResourceId);
            VolumeCollection collection = resourceGroupResource.GetVolumes();

            // Create Volume
            VolumeData createData = new VolumeData(TestEnvironment.Location, new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation"), 10);
            ArmOperation<VolumeResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeName, createData);
            Assert.AreEqual(createResult.Value.Data.Name, volumeName);

            // Get Volume
            VolumeResource volume = Client.GetVolumeResource(volumeResourceId);
            VolumeResource getResult = await volume.GetAsync();
            Assert.AreEqual(volumeName, getResult.Data.Name);

            // Update Volume
            VolumePatch updateData = new VolumePatch()
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                    ["key2"] = "myvalue2",
                },
            };
            Response<VolumeResource> updateResult = await volume.UpdateAsync(updateData);
            Assert.AreEqual(updateData.Tags, updateResult.Value.Data.Tags);

            // List Volumes by Resource Group
            var listByResourceGroupResult = new List<VolumeResource>();
            await foreach (VolumeResource volumeResource in collection.GetAllAsync())
            {
                listByResourceGroupResult.Add(volumeResource);
            }
            Assert.IsNotEmpty(listByResourceGroupResult);

            // List Volumes by Subscription
            var listBySubscriptionResult = new List<VolumeResource>();
            await foreach (VolumeResource volumeResource in SubscriptionResource.GetVolumesAsync())
            {
                listBySubscriptionResult.Add(volumeResource);
            }
            Assert.IsNotEmpty(listBySubscriptionResult);

            // Delete Volume
            var deleteResult = await volume.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}
