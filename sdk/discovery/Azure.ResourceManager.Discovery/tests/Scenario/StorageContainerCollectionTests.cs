// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests.Scenario
{
    public class StorageContainerCollectionTests : DiscoveryManagementTestBase
    {
        private const string ResourceGroupName = "rgname";
        private const string StorageContainerName = "sanitized-storagecontainer";

        public StorageContainerCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup() => InitializeClient();

        private StorageContainerCollection GetStorageContainerCollection()
            => GetResourceGroupReference(ResourceGroupName).GetStorageContainers();

        private StorageContainerResource GetStorageContainerReference()
            => Client.GetStorageContainerResource(StorageContainerResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, StorageContainerName));

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ArmOperation<StorageContainerResource> operation = await GetStorageContainerCollection().CreateOrUpdateAsync(WaitUntil.Completed, StorageContainerName, new StorageContainerData(AzureLocation.UKSouth));

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(StorageContainerName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<StorageContainerResource> response = await GetStorageContainerCollection().GetAsync(StorageContainerName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(StorageContainerName));
        }

        [RecordedTest]
        public async Task ListByResourceGroup()
        {
            List<StorageContainerResource> items = new List<StorageContainerResource>();
            await foreach (StorageContainerResource item in GetStorageContainerCollection().GetAllAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task ListBySubscription()
        {
            List<StorageContainerResource> items = new List<StorageContainerResource>();
            await foreach (StorageContainerResource item in GetSubscriptionReference().GetStorageContainersAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Update()
        {
            ArmOperation<StorageContainerResource> operation = await GetStorageContainerReference().UpdateAsync(WaitUntil.Completed, new StorageContainerData(AzureLocation.UKSouth));

            Assert.That(operation.Value.Data.Name, Is.EqualTo(StorageContainerName));
        }

        [RecordedTest]
        public async Task Delete()
        {
            ArmOperation operation = await GetStorageContainerReference().DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
