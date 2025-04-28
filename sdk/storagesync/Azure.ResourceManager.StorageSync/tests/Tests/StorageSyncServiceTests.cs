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
    public class StorageSyncServiceTests : StorageSyncManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private string _storageSyncServiceName;
        private StorageSyncServiceCreateOrUpdateContent _storageSyncServiceCreateOrUpdateContent;

        public StorageSyncServiceTests(bool async) : base(async , ModeFromSourceCode)
        {
        }

        [SetUp]
        public async Task CreateStorageSyncResources()
        {
            // Create resources required for testing StorageSyncService
            _resourceGroup = await CreateResourceGroupAsync();

            _storageSyncServiceName = Recording.GenerateAssetName(DefaultStorageSyncServiceRecordingName);
            _storageSyncServiceCreateOrUpdateContent = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
        }

        [Test]
        [RecordedTest]
        public async Task StorageSyncServiceCreateTest()
        {
            // Create StorageSyncService
            StorageSyncServiceResource storageSyncServiceResource = (await _resourceGroup.GetStorageSyncServices().CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, _storageSyncServiceCreateOrUpdateContent)).Value;
            Assert.NotNull(storageSyncServiceResource);
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);
        }

        [Test]
        [RecordedTest]
        public async Task StorageSyncServiceUpdateTest()
        {
            // Create StorageSyncService
            StorageSyncServiceResource storageSyncServiceResource = (await _resourceGroup.GetStorageSyncServices().CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, _storageSyncServiceCreateOrUpdateContent)).Value;
            Assert.NotNull(storageSyncServiceResource);
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

            // Update StorageSyncService
            StorageSyncServiceCreateOrUpdateContent storageSyncServiceUpdateContent = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
            StorageSyncServiceResource storageSyncServiceUpdatedResource = (await _resourceGroup.GetStorageSyncServices().CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, storageSyncServiceUpdateContent)).Value;
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceUpdatedResource, true);
        }

        [Test]
        [RecordedTest]
        public async Task StorageSyncServiceGetTest()
        {
            // Create StorageSyncService
            StorageSyncServiceResource storageSyncServiceResource = (await _resourceGroup.GetStorageSyncServices().CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, _storageSyncServiceCreateOrUpdateContent)).Value;
            Assert.NotNull(storageSyncServiceResource);
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

            // Get StorageSyncService
            storageSyncServiceResource = (await _resourceGroup.GetStorageSyncServiceAsync(_storageSyncServiceName)).Value;
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, false);
        }

        [Test]
        [RecordedTest]
        public async Task StorageSyncServiceListTest()
        {
            // Get StorageSyncServiceCollection
            StorageSyncServiceCollection storageSyncServiceCollection = _resourceGroup.GetStorageSyncServices();
            Assert.NotNull(storageSyncServiceCollection);

            // Create StorageSyncService
            StorageSyncServiceResource storageSyncServiceResource = (await storageSyncServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, _storageSyncServiceCreateOrUpdateContent)).Value;
            Assert.NotNull(storageSyncServiceResource);
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

            // Verify StorageSyncServiceCollection contains a single StorageSyncService
            List<StorageSyncServiceResource> storageSyncServiceResources = await storageSyncServiceCollection.ToEnumerableAsync();
            Assert.NotNull(storageSyncServiceResources);
            Assert.AreEqual(storageSyncServiceResources.Count(), 1);
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, false);

            // Retrieve list of StorageSyncServices for given Subscription
            var syncServiceResourcesFromSubscription = await DefaultSubscription.GetStorageSyncServicesAsync().ToEnumerableAsync(); //.ToEnumerableAsync();

            // Change the number if json has more results under this subscription.
            Assert.True(1 <= syncServiceResourcesFromSubscription.Count());

            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(syncServiceResourcesFromSubscription.Single(r => r.Id.Name == _storageSyncServiceName), false);
        }

        [Test]
        [RecordedTest]
        public async Task StorageSyncServiceDeleteTest()
        {
            // Get StorageSyncServiceCollection
            StorageSyncServiceCollection storageSyncServiceCollection = _resourceGroup.GetStorageSyncServices();
            Assert.NotNull(storageSyncServiceCollection);

            // Delete StorageSyncService before its created.
            var deleteException = Assert.ThrowsAsync<RequestFailedException>(async () => (await _resourceGroup.GetStorageSyncServiceAsync(_storageSyncServiceName)).Value?.Delete(WaitUntil.Completed));
            Assert.AreEqual(404, deleteException.Status);
            Assert.IsFalse((await storageSyncServiceCollection.ExistsAsync(_storageSyncServiceName)).Value);

            // Create StorageSyncService
            StorageSyncServiceResource storageSyncServiceResource = (await storageSyncServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, _storageSyncServiceCreateOrUpdateContent)).Value;
            Assert.NotNull(storageSyncServiceResource);
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

            // Delete StorageSyncService
            await storageSyncServiceResource.DeleteAsync(WaitUntil.Completed);

            // Verify StorageSyncService has been deleted.
            Assert.IsFalse((await _resourceGroup.GetStorageSyncServices().ExistsAsync(_storageSyncServiceName)).Value);
        }

        [Test]
        [RecordedTest]
        public async Task StorageSyncServiceCheckNameAvailabilityTest()
        {
            // Get StorageSyncServiceCollection
            StorageSyncServiceCollection storageSyncServiceCollection = _resourceGroup.GetStorageSyncServices();
            Assert.NotNull(storageSyncServiceCollection);

            // Verify StorageSyncService with that name does not exist
            bool exists = await storageSyncServiceCollection.ExistsAsync(_storageSyncServiceName);
            Assert.IsFalse(exists);

            // Create StorageSyncService
            StorageSyncServiceResource storageSyncServiceResource = (await storageSyncServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, _storageSyncServiceCreateOrUpdateContent)).Value;
            Assert.NotNull(storageSyncServiceResource);
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

            // Verify StorageSyncService with that name now exists
            exists = await storageSyncServiceCollection.ExistsAsync(_storageSyncServiceName);
            Assert.IsTrue(exists);
        }

        [Test]
        [RecordedTest]
        public async Task StorageSyncServiceBadRequestTest()
        {
            // Get StorageSyncServiceCollection
            StorageSyncServiceCollection storageSyncServiceCollection = _resourceGroup.GetStorageSyncServices();
            Assert.NotNull(storageSyncServiceCollection);

            // Create StorageSyncService
            StorageSyncServiceResource storageSyncServiceResource = (await _resourceGroup.GetStorageSyncServices().CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, _storageSyncServiceCreateOrUpdateContent)).Value;

            // Attempt to create bad StorageSyncService
            string badStorageSyncServiceName = Recording.GenerateAssetName("#$%badsss");
            Assert.ThrowsAsync<RequestFailedException>(async () => await _resourceGroup.GetStorageSyncServices().CreateOrUpdateAsync(WaitUntil.Completed, badStorageSyncServiceName, _storageSyncServiceCreateOrUpdateContent));
        }
    }
}
