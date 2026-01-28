// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageSync.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageSync.Tests
{
    public class StorageSyncServiceTests : StorageSyncManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private string _storageSyncServiceName;
        private StorageSyncServiceCreateOrUpdateContent _storageSyncServiceCreateOrUpdateContent;

        public StorageSyncServiceTests(bool async) : base(async, ModeFromSourceCode)
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
            Assert.That(storageSyncServiceResource, Is.Not.Null);
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);
        }

        [Test]
        [RecordedTest]
        public async Task StorageSyncServiceUpdateTest()
        {
            // Create StorageSyncService
            StorageSyncServiceResource storageSyncServiceResource = (await _resourceGroup.GetStorageSyncServices().CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, _storageSyncServiceCreateOrUpdateContent)).Value;
            Assert.That(storageSyncServiceResource, Is.Not.Null);
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
            Assert.That(storageSyncServiceResource, Is.Not.Null);
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
            Assert.That(storageSyncServiceCollection, Is.Not.Null);

            // Create StorageSyncService
            StorageSyncServiceResource storageSyncServiceResource = (await storageSyncServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, _storageSyncServiceCreateOrUpdateContent)).Value;
            Assert.That(storageSyncServiceResource, Is.Not.Null);
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

            // Verify StorageSyncServiceCollection contains a single StorageSyncService
            List<StorageSyncServiceResource> storageSyncServiceResources = await storageSyncServiceCollection.ToEnumerableAsync();
            Assert.That(storageSyncServiceResources, Is.Not.Null);
            Assert.That(storageSyncServiceResources.Count(), Is.EqualTo(1));
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, false);

            // Retrieve list of StorageSyncServices for given Subscription
            var syncServiceResourcesFromSubscription = await DefaultSubscription.GetStorageSyncServicesAsync().ToEnumerableAsync(); //.ToEnumerableAsync();

            // Change the number if json has more results under this subscription.
            Assert.That(1 <= syncServiceResourcesFromSubscription.Count(), Is.True);

            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(syncServiceResourcesFromSubscription.Single(r => r.Id.Name == _storageSyncServiceName), false);
        }

        [Test]
        [RecordedTest]
        public async Task StorageSyncServiceDeleteTest()
        {
            // Get StorageSyncServiceCollection
            StorageSyncServiceCollection storageSyncServiceCollection = _resourceGroup.GetStorageSyncServices();
            Assert.That(storageSyncServiceCollection, Is.Not.Null);

            // Delete StorageSyncService before its created.
            var deleteException = Assert.ThrowsAsync<RequestFailedException>(async () => (await _resourceGroup.GetStorageSyncServiceAsync(_storageSyncServiceName)).Value?.Delete(WaitUntil.Completed));
            Assert.That(deleteException.Status, Is.EqualTo(404));
            Assert.That((await storageSyncServiceCollection.ExistsAsync(_storageSyncServiceName)).Value, Is.False);

            // Create StorageSyncService
            StorageSyncServiceResource storageSyncServiceResource = (await storageSyncServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, _storageSyncServiceCreateOrUpdateContent)).Value;
            Assert.That(storageSyncServiceResource, Is.Not.Null);
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

            // Delete StorageSyncService
            await storageSyncServiceResource.DeleteAsync(WaitUntil.Completed);

            // Verify StorageSyncService has been deleted.
            Assert.That((await _resourceGroup.GetStorageSyncServices().ExistsAsync(_storageSyncServiceName)).Value, Is.False);
        }

        [Test]
        [RecordedTest]
        public async Task StorageSyncServiceCheckNameAvailabilityTest()
        {
            // Get StorageSyncServiceCollection
            StorageSyncServiceCollection storageSyncServiceCollection = _resourceGroup.GetStorageSyncServices();
            Assert.That(storageSyncServiceCollection, Is.Not.Null);

            // Verify StorageSyncService with that name does not exist
            bool exists = await storageSyncServiceCollection.ExistsAsync(_storageSyncServiceName);
            Assert.That(exists, Is.False);

            // Create StorageSyncService
            StorageSyncServiceResource storageSyncServiceResource = (await storageSyncServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, _storageSyncServiceCreateOrUpdateContent)).Value;
            Assert.That(storageSyncServiceResource, Is.Not.Null);
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

            // Verify StorageSyncService with that name now exists
            exists = await storageSyncServiceCollection.ExistsAsync(_storageSyncServiceName);
            Assert.That(exists, Is.True);
        }

        [Test]
        [RecordedTest]
        public async Task StorageSyncServiceBadRequestTest()
        {
            // Get StorageSyncServiceCollection
            StorageSyncServiceCollection storageSyncServiceCollection = _resourceGroup.GetStorageSyncServices();
            Assert.That(storageSyncServiceCollection, Is.Not.Null);

            // Create StorageSyncService
            StorageSyncServiceResource storageSyncServiceResource = (await _resourceGroup.GetStorageSyncServices().CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, _storageSyncServiceCreateOrUpdateContent)).Value;

            // Attempt to create bad StorageSyncService
            string badStorageSyncServiceName = Recording.GenerateAssetName("#$%badsss");
            Assert.ThrowsAsync<RequestFailedException>(async () => await _resourceGroup.GetStorageSyncServices().CreateOrUpdateAsync(WaitUntil.Completed, badStorageSyncServiceName, _storageSyncServiceCreateOrUpdateContent));
        }
    }
}
