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

        private DiscoveryStorageContainerCollection GetStorageContainerCollection()
            => GetResourceGroupReference(ResourceGroupName).GetDiscoveryStorageContainers();

        private DiscoveryStorageContainerResource GetStorageContainerReference()
            => Client.GetDiscoveryStorageContainerResource(DiscoveryStorageContainerResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, StorageContainerName));

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ArmOperation<DiscoveryStorageContainerResource> operation = await GetStorageContainerCollection().CreateOrUpdateAsync(WaitUntil.Completed, StorageContainerName, new DiscoveryStorageContainerData(AzureLocation.UKSouth));

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(StorageContainerName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<DiscoveryStorageContainerResource> response = await GetStorageContainerCollection().GetAsync(StorageContainerName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(StorageContainerName));
        }

        [RecordedTest]
        public async Task ListByResourceGroup()
        {
            List<DiscoveryStorageContainerResource> items = new List<DiscoveryStorageContainerResource>();
            await foreach (DiscoveryStorageContainerResource item in GetStorageContainerCollection().GetAllAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task ListBySubscription()
        {
            List<DiscoveryStorageContainerResource> items = new List<DiscoveryStorageContainerResource>();
            await foreach (DiscoveryStorageContainerResource item in GetSubscriptionReference().GetDiscoveryStorageContainersAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Update()
        {
            ArmOperation<DiscoveryStorageContainerResource> operation = await GetStorageContainerReference().UpdateAsync(WaitUntil.Completed, new DiscoveryStorageContainerData(AzureLocation.UKSouth));

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
