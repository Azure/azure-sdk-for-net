// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests.Scenario
{
    public class StorageAssetCollectionTests : DiscoveryManagementTestBase
    {
        private const string ResourceGroupName = "rgname";
        private const string StorageContainerName = "sanitized-storagecontainer";
        private const string StorageAssetName = "sanitized-storageasset";

        public StorageAssetCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup() => InitializeClient();

        private DiscoveryStorageAssetCollection GetStorageAssetCollection()
            => Client.GetDiscoveryStorageContainerResource(DiscoveryStorageContainerResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, StorageContainerName)).GetDiscoveryStorageAssets();

        private DiscoveryStorageAssetResource GetStorageAssetReference()
            => Client.GetDiscoveryStorageAssetResource(DiscoveryStorageAssetResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, StorageContainerName, StorageAssetName));

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ArmOperation<DiscoveryStorageAssetResource> operation = await GetStorageAssetCollection().CreateOrUpdateAsync(WaitUntil.Completed, StorageAssetName, new DiscoveryStorageAssetData(AzureLocation.UKSouth));

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(StorageAssetName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<DiscoveryStorageAssetResource> response = await GetStorageAssetCollection().GetAsync(StorageAssetName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(StorageAssetName));
        }

        [RecordedTest]
        public async Task ListByStorageContainer()
        {
            List<DiscoveryStorageAssetResource> items = new List<DiscoveryStorageAssetResource>();
            await foreach (DiscoveryStorageAssetResource item in GetStorageAssetCollection().GetAllAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Update()
        {
            ArmOperation<DiscoveryStorageAssetResource> operation = await GetStorageAssetReference().UpdateAsync(WaitUntil.Completed, new DiscoveryStorageAssetData(AzureLocation.UKSouth));

            Assert.That(operation.Value.Data.Name, Is.EqualTo(StorageAssetName));
        }

        [RecordedTest]
        public async Task Delete()
        {
            ArmOperation operation = await GetStorageAssetReference().DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
