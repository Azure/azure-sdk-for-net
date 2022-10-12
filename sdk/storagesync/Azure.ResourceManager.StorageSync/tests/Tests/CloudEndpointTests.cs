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

        private string _storageSyncServiceName;
        private string _syncGroupName;
        private string _cloudEndpointName;
        private StorageSyncServiceCreateOrUpdateContent _storageSyncServiceCreateOrUpdateContent;
        private StorageSyncGroupCreateOrUpdateContent _storageSyncGroupCreateOrUpdateContent;
        private CloudEndpointCreateOrUpdateContent _cloudEndpointCreateOrUpdateContent;
        private StorageSyncServiceResource _storageSyncServiceResource;
        private StorageSyncGroupResource _storageSyncGroupResource;

        public CloudEndpointTests(bool async) : base(async) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task CreateStorageSyncResources()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            _storageSyncServiceName = Recording.GenerateAssetName("sss-cepcreate");
            _syncGroupName = Recording.GenerateAssetName("sg-cepcreate");
            _cloudEndpointName = Recording.GenerateAssetName("cepcreate");

            _storageSyncServiceCreateOrUpdateContent = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
            _storageSyncGroupCreateOrUpdateContent = StorageSyncManagementTestUtilities.GetDefaultSyncGroupParameters();
            _cloudEndpointCreateOrUpdateContent = StorageSyncManagementTestUtilities.GetDefaultCloudEndpointParameters();

            // Create StorageSyncService
            _storageSyncServiceResource = (await _resourceGroup.GetStorageSyncServices().CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, _storageSyncServiceCreateOrUpdateContent)).Value;
            Assert.NotNull(_storageSyncServiceResource);
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(_storageSyncServiceResource, true);

            // Create StorageSyncGroup
            _storageSyncGroupResource = (await _storageSyncServiceResource.GetStorageSyncGroups().CreateOrUpdateAsync(WaitUntil.Completed, _syncGroupName, _storageSyncGroupCreateOrUpdateContent)).Value;
            Assert.NotNull(_storageSyncGroupResource);
            StorageSyncManagementTestUtilities.VerifySyncGroupProperties(_storageSyncGroupResource, true);
        }

        [TearDown]
        public async Task DeleteStorageSyncResources()
        {
            var storageSyncServiseExists = (await _resourceGroup.GetStorageSyncServices().ExistsAsync(_storageSyncServiceName)).Value;
            if (storageSyncServiseExists)
            {
                var storageSyncService = (await _resourceGroup.GetStorageSyncServiceAsync(_storageSyncServiceName)).Value;
                if ((await storageSyncService.GetStorageSyncGroups().ExistsAsync(_syncGroupName)).Value)
                {
                    var syncGroupResource = (await storageSyncService.GetStorageSyncGroupAsync(_syncGroupName)).Value;
                    if ((await syncGroupResource.GetCloudEndpoints().ExistsAsync(_cloudEndpointName)).Value)
                    {
                        var cloudEndpointResource = (await syncGroupResource.GetCloudEndpointAsync(_cloudEndpointName)).Value;
                        await cloudEndpointResource.DeleteAsync(WaitUntil.Completed);
                    }
                    await syncGroupResource.DeleteAsync(WaitUntil.Completed);
                }
                await storageSyncService.DeleteAsync(WaitUntil.Completed);
            }
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
            StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResource, false);
        }

        [Test]
        [RecordedTest]
        public async Task CloudEndpointListTest()
        {
            // Get CloudEndpointCollection
            CloudEndpointCollection cloundEndpointCollection = _storageSyncGroupResource.GetCloudEndpoints();
            Assert.NotNull(cloundEndpointCollection);

            // Create CloudEndpoint
            CloudEndpointResource cloudEndpointResource = (await cloundEndpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, _cloudEndpointName, _cloudEndpointCreateOrUpdateContent)).Value;
            Assert.NotNull(cloudEndpointResource);
            StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResource, true);

            // Verify CloundEndpointCollection contains a single CloudEndpoint
            List<CloudEndpointResource> cloudEndpointResources = await cloundEndpointCollection.ToEnumerableAsync();
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
