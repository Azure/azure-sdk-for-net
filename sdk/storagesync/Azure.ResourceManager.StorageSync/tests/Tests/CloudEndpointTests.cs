// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.StorageSync.Models;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using Azure.Core.TestFramework;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.StorageSync.Tests
{
    public class CloudEndpointTests : StorageSyncManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private StorageSyncServiceResource _storageSyncServiceResource;
        private StorageSyncGroupResource _storageSyncGroupResource;

        private string _cloudEndpointName;
        private CloudEndpointCreateOrUpdateContent _cloudEndpointCreateOrUpdateContent;

        public CloudEndpointTests(bool async) : base(async, ModeFromSourceCode )
        {
        }

        [SetUp]
        public async Task CreateStorageSyncResources()
        {
            // Create resources required for testing CloudEndpointResource
            _resourceGroup = await CreateResourceGroupAsync();
            _storageSyncServiceResource = await CreateSyncServiceAsync(_resourceGroup);
            _storageSyncGroupResource = await CreateSyncGroupAsync(_storageSyncServiceResource);

            _cloudEndpointName = Recording.GenerateAssetName("afs-sdk-cep-create");
            _cloudEndpointCreateOrUpdateContent = StorageSyncManagementTestUtilities.GetDefaultCloudEndpointParameters();
        }

        [TearDown]
        public async Task DeleteStorageSyncResources()
        {
            var cloudEndpointExists = (await _storageSyncGroupResource.GetCloudEndpoints().ExistsAsync(_cloudEndpointName)).Value;

            if (cloudEndpointExists)
            {
                CloudEndpointResource cloudEndpointResource = (await _storageSyncGroupResource.GetCloudEndpointAsync(_cloudEndpointName)).Value;
                await cloudEndpointResource.DeleteAsync(WaitUntil.Completed);
            }

            await _storageSyncGroupResource.DeleteAsync(WaitUntil.Completed);
            await _storageSyncServiceResource.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task CloudEndpointCreateTest()
        {
            // Create CloudEndpoint
            CloudEndpointResource cloudEndpointResource = (await _storageSyncGroupResource.GetCloudEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, _cloudEndpointName, _cloudEndpointCreateOrUpdateContent)).Value;
            Assert.NotNull(cloudEndpointResource);
            StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResource, true);
        }

        [Test]
        [RecordedTest]
        public async Task CloudEndpointGetTest()
        {
            // Create CloudEndpoint
            CloudEndpointResource cloudEndpointResource = (await _storageSyncGroupResource.GetCloudEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, _cloudEndpointName, _cloudEndpointCreateOrUpdateContent)).Value;
            Assert.NotNull(cloudEndpointResource);
            StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResource, true);

            // Get CloudEndpoint
            cloudEndpointResource = (await _storageSyncGroupResource.GetCloudEndpointAsync(_cloudEndpointName)).Value;
            Assert.NotNull(cloudEndpointResource);
            StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResource, false);
        }

        [Test]
        [RecordedTest]
        public async Task CloudEndpointListTest()
        {
            // Get CloudEndpointCollection
            CloudEndpointCollection cloudEndpointCollection = _storageSyncGroupResource.GetCloudEndpoints();
            Assert.NotNull(cloudEndpointCollection);

            // Create CloudEndpoint
            CloudEndpointResource cloudEndpointResource = (await cloudEndpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, _cloudEndpointName, _cloudEndpointCreateOrUpdateContent)).Value;
            Assert.NotNull(cloudEndpointResource);
            StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResource, true);

            // Verify CloundEndpointCollection contains a single CloudEndpoint
            List<CloudEndpointResource> cloudEndpointResources = await cloudEndpointCollection.ToEnumerableAsync();
            Assert.NotNull(cloudEndpointResources);
            Assert.AreEqual(cloudEndpointResources.Count(), 1);

            StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResources.First(), false);
        }

        [Test]
        [RecordedTest]
        public async Task CloudEndpointDeleteTest()
        {
            // Get CloudEndpointCollection
            CloudEndpointCollection cloundEndpointCollection = _storageSyncGroupResource.GetCloudEndpoints();
            Assert.NotNull(cloundEndpointCollection);

            // Delete CloudEndpoint before its created.
            var deleteException = Assert.ThrowsAsync<RequestFailedException>(async () => (await _storageSyncGroupResource.GetCloudEndpointAsync(_cloudEndpointName)).Value?.Delete(WaitUntil.Completed));
            Assert.AreEqual(404, deleteException.Status);
            Assert.IsFalse((await cloundEndpointCollection.ExistsAsync(_cloudEndpointName)).Value);

            // Create CloudEndpoint
            CloudEndpointResource cloudEndpointResource = (await cloundEndpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, _cloudEndpointName, _cloudEndpointCreateOrUpdateContent)).Value;
            Assert.NotNull(cloudEndpointResource);
            StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResource, true);

            // Delete CloudEndpoint
            await cloudEndpointResource.DeleteAsync(WaitUntil.Completed);

            // Verify cloudendpoint has been deleted.
            Assert.IsFalse((await cloundEndpointCollection.ExistsAsync(_cloudEndpointName)).Value);
        }

        [Test]
        [RecordedTest]
        public async Task CloudEndpointInvokeChangeDetectionTest()
        {
            // Create CloudEndpoint
            CloudEndpointResource cloudEndpointResource = (await _storageSyncGroupResource.GetCloudEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, _cloudEndpointName, _cloudEndpointCreateOrUpdateContent)).Value;
            Assert.NotNull(cloudEndpointResource);
            StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResource, true);

            // Trigger change detection with directory
            var triggerChangeDetectionContentWithDirectory = new TriggerChangeDetectionContent();
            triggerChangeDetectionContentWithDirectory.Paths.Add("");
            triggerChangeDetectionContentWithDirectory.ChangeDetectionMode = ChangeDetectionMode.Recursive;
            await cloudEndpointResource.TriggerChangeDetectionAsync(WaitUntil.Completed, triggerChangeDetectionContentWithDirectory);

            // Trigger change detection with individual path
            var triggerChangeDetectionContentWithIndividualPath = new TriggerChangeDetectionContent();
            triggerChangeDetectionContentWithIndividualPath.Paths.Add("");
            triggerChangeDetectionContentWithIndividualPath.ChangeDetectionMode = ChangeDetectionMode.Recursive;
            await cloudEndpointResource.TriggerChangeDetectionAsync(WaitUntil.Completed, triggerChangeDetectionContentWithIndividualPath);
        }
    }
}
