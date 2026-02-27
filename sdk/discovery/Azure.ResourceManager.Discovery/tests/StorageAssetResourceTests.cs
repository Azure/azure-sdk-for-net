// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests
{
    /// <summary>
    /// Tests for StorageAsset resource operations.
    /// StorageAsset is a child resource of StorageContainer.
    /// </summary>
    public class StorageAssetResourceTests : DiscoveryManagementTestBase
    {
        public StorageAssetResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("Requires existing StorageContainer and StorageAssets")]
        public async Task ListStorageAssetsByStorageContainer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // TODO: Replace with actual storage container name from TestEnvironment
            var storageContainerName = "test-storagecontainer";
            var storageContainer = await resourceGroup.GetStorageContainers().GetAsync(storageContainerName);

            // Act
            var storageAssets = new List<StorageAssetResource>();
            await foreach (var storageAsset in storageContainer.Value.GetStorageAssets().GetAllAsync())
            {
                storageAssets.Add(storageAsset);
            }

            // Assert
            Assert.That(storageAssets, Is.Not.Null);
        }

        [RecordedTest]
        [Ignore("Requires existing StorageContainer and StorageAsset")]
        public async Task GetStorageAsset()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // TODO: Replace with actual storage container and asset names from TestEnvironment
            var storageContainerName = "test-storagecontainer";
            var storageContainer = await resourceGroup.GetStorageContainers().GetAsync(storageContainerName);
            var storageAssetName = "test-storageasset";

            // Act
            var storageAsset = await storageContainer.Value.GetStorageAssets().GetAsync(storageAssetName);

            // Assert
            Assert.That(storageAsset.Value, Is.Not.Null);
            Assert.That(storageAsset.Value.Data.Name, Is.EqualTo(storageAssetName));
        }

        [RecordedTest]
        [Ignore("Requires StorageAssetProperties with path configuration")]
        public async Task CreateStorageAsset()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // TODO: Replace with actual storage container name
            var storageContainerName = "test-storagecontainer";
            var storageContainer = await resourceGroup.GetStorageContainers().GetAsync(storageContainerName);
            var storageAssetName = Recording.GenerateAssetName("asset-");

            // TODO: StorageAsset creation requires:
            // 1. StorageAssetProperties with path configuration
            var storageAssetData = new StorageAssetData(DefaultLocation)
            {
                Tags =
                {
                    { "test", "value" }
                }
            };

            // Act
            var operation = await storageContainer.Value.GetStorageAssets().CreateOrUpdateAsync(
                WaitUntil.Completed,
                storageAssetName,
                storageAssetData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(storageAssetName));
        }

        [RecordedTest]
        [Ignore("Requires existing StorageAsset to update")]
        public async Task UpdateStorageAsset()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // TODO: Replace with actual storage container and asset names from TestEnvironment
            var storageContainerName = "test-storagecontainer";
            var storageContainer = await resourceGroup.GetStorageContainers().GetAsync(storageContainerName);
            var storageAssetName = "test-storageasset";
            var storageAsset = await storageContainer.Value.GetStorageAssets().GetAsync(storageAssetName);

            // Create update data with modified tags
            var updateData = storageAsset.Value.Data;
            updateData.Tags["updated"] = "true";

            // Act
            var operation = await storageContainer.Value.GetStorageAssets().CreateOrUpdateAsync(
                WaitUntil.Completed,
                storageAssetName,
                updateData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Tags.ContainsKey("updated"), Is.True);
        }

        [RecordedTest]
        [Ignore("Requires existing StorageAsset to delete")]
        public async Task DeleteStorageAsset()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // TODO: Replace with actual storage container name
            var storageContainerName = "test-storagecontainer";
            var storageContainer = await resourceGroup.GetStorageContainers().GetAsync(storageContainerName);

            // TODO: Either create a StorageAsset first, then delete it
            // Or use an existing asset that can be deleted
            var storageAssetName = "asset-to-delete";
            var storageAsset = await storageContainer.Value.GetStorageAssets().GetAsync(storageAssetName);

            // Act
            var operation = await storageAsset.Value.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
