// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageSync.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageSync.Tests
{
    public class SyncGroupTests : StorageSyncManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private string _syncGroupName;
        private StorageSyncGroupCreateOrUpdateContent _storageSyncGroupCreateOrUpdateContent;
        private StorageSyncServiceResource _storageSyncServiceResource;

        public SyncGroupTests(bool async) : base(async, ModeFromSourceCode)
        {
        }

        [SetUp]
        public async Task CreateStorageSyncResources()
        {
            // Create resources required for testing StorageSyncGroup
            _resourceGroup = await CreateResourceGroupAsync();
            _storageSyncServiceResource = await CreateSyncServiceAsync(_resourceGroup);

            _syncGroupName = Recording.GenerateAssetName("sg-cepcreate");
            _storageSyncGroupCreateOrUpdateContent = StorageSyncManagementTestUtilities.GetDefaultSyncGroupParameters();
        }

        [TearDown]
        public async Task RemoveStorageSyncResources()
        {
            bool syncGroupExists = await _storageSyncServiceResource.GetStorageSyncGroups().ExistsAsync(_syncGroupName);
            if (syncGroupExists)
            {
                await (await _storageSyncServiceResource.GetStorageSyncGroupAsync(_syncGroupName)).Value?.DeleteAsync(WaitUntil.Completed);
            }
            await _storageSyncServiceResource.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task SyncGroupCreateTest()
        {
            // Create StorageSyncGroup
            StorageSyncGroupResource syncGroupResource = (await _storageSyncServiceResource.GetStorageSyncGroups().CreateOrUpdateAsync(WaitUntil.Completed, _syncGroupName, _storageSyncGroupCreateOrUpdateContent)).Value;
            Assert.That(syncGroupResource, Is.Not.Null);
            StorageSyncManagementTestUtilities.VerifySyncGroupProperties(syncGroupResource, true);
        }

        [Test]
        [RecordedTest]
        public async Task SyncGroupGetTest()
        {
            // Create StorageSyncGroup
            StorageSyncGroupResource syncGroupResource = (await _storageSyncServiceResource.GetStorageSyncGroups().CreateOrUpdateAsync(WaitUntil.Completed, _syncGroupName, _storageSyncGroupCreateOrUpdateContent)).Value;
            Assert.That(syncGroupResource, Is.Not.Null);

            // Get StorageSyncGroup
            syncGroupResource = (await _storageSyncServiceResource.GetStorageSyncGroupAsync(_syncGroupName)).Value;
            Assert.That(syncGroupResource, Is.Not.Null);
            StorageSyncManagementTestUtilities.VerifySyncGroupProperties(syncGroupResource, false);
        }

        [Test]
        [RecordedTest]
        public async Task SyncGroupListTest()
        {
            // Get SyncGroupCollection
            StorageSyncGroupCollection syncGroupCollection = _storageSyncServiceResource.GetStorageSyncGroups();
            Assert.That(syncGroupCollection, Is.Not.Null);

            // Create StorageSyncGroup
            StorageSyncGroupResource syncGroupResource = (await syncGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, _syncGroupName, _storageSyncGroupCreateOrUpdateContent)).Value;
            Assert.That(syncGroupResource, Is.Not.Null);
            StorageSyncManagementTestUtilities.VerifySyncGroupProperties(syncGroupResource, true);

            // Verify StorageSyncGroupCollection contains a single CloudEndpoint
            List<StorageSyncGroupResource> syncGroupResources = await syncGroupCollection.ToEnumerableAsync();
            Assert.That(syncGroupResources, Is.Not.Null);
            Assert.That(syncGroupResources.Count(), Is.EqualTo(1));
            StorageSyncManagementTestUtilities.VerifySyncGroupProperties(syncGroupResources.First(), false);
        }

        [Test]
        [RecordedTest]
        public async Task SyncGroupDeleteTest()
        {
            // Get SyncGroupCollection
            StorageSyncGroupCollection syncGroupCollection = _storageSyncServiceResource.GetStorageSyncGroups();
            Assert.That(syncGroupCollection, Is.Not.Null);

            // Delete SyncGroup before it's created
            var deleteException = Assert.ThrowsAsync<RequestFailedException>(async () => (await _storageSyncServiceResource.GetStorageSyncGroupAsync(_syncGroupName)).Value?.Delete(WaitUntil.Completed));
            Assert.That(deleteException.Status, Is.EqualTo(404));
            Assert.That((await syncGroupCollection.ExistsAsync(_syncGroupName)).Value, Is.False);

            // Create StorageSyncGroup
            StorageSyncGroupResource syncGroupResource = (await syncGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, _syncGroupName, _storageSyncGroupCreateOrUpdateContent)).Value;
            Assert.That(syncGroupResource, Is.Not.Null);
            StorageSyncManagementTestUtilities.VerifySyncGroupProperties(syncGroupResource, true);

            // Delete StorageSyncGroup
            await syncGroupResource.DeleteAsync(WaitUntil.Completed);

            // Verify StorageSyncGroup has been deleted.
            Assert.That((await syncGroupCollection.ExistsAsync(_syncGroupName)).Value, Is.False);
        }
    }
}
