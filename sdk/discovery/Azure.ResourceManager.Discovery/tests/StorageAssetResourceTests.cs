// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Discovery.Models;
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
        public async Task ListStorageAssetsByStorageContainer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var storageContainerName = TestEnvironment.StorageContainerName;
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
        public async Task GetStorageAsset()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var storageContainerName = TestEnvironment.StorageContainerName;
            var storageContainer = await resourceGroup.GetStorageContainers().GetAsync(storageContainerName);
            var storageAssetName = TestEnvironment.StorageAssetName;

            // Act
            var storageAsset = await storageContainer.Value.GetStorageAssets().GetAsync(storageAssetName);

            // Assert
            Assert.That(storageAsset.Value, Is.Not.Null);
            Assert.That(storageAsset.Value.Data.Name, Is.EqualTo(storageAssetName));
        }

        [RecordedTest]
        public async Task CreateStorageAsset()
        {
            // Arrange - matching Python/Java payload
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var storageContainerName = TestEnvironment.StorageContainerName;
            var storageContainer = await resourceGroup.GetStorageContainers().GetAsync(storageContainerName);
            var storageAssetName = "test-sa-dotnet01";

            var storageAssetData = new StorageAssetData(DefaultLocation)
            {
                Properties = new StorageAssetProperties("Test storage asset for .NET SDK validation")
                {
                    Path = "data/test-assets",
                },
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
        public async Task UpdateStorageAsset()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var storageContainerName = TestEnvironment.StorageContainerName;
            var storageContainer = await resourceGroup.GetStorageContainers().GetAsync(storageContainerName);
            var storageAssetName = TestEnvironment.StorageAssetName;
            var storageAsset = await storageContainer.Value.GetStorageAssets().GetAsync(storageAssetName);

            // Update tags matching Python/Java pattern
            var updateData = storageAsset.Value.Data;
            updateData.Tags["SkipAutoDeleteTill"] = "2026-12-31";

            // Act
            var operation = await storageContainer.Value.GetStorageAssets().CreateOrUpdateAsync(
                WaitUntil.Completed,
                storageAssetName,
                updateData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Tags.ContainsKey("SkipAutoDeleteTill"), Is.True);
        }

        [RecordedTest]
        public async Task DeleteStorageAsset()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var storageContainerName = TestEnvironment.StorageContainerName;
            var storageContainer = await resourceGroup.GetStorageContainers().GetAsync(storageContainerName);
            var storageAssetName = "test-sa-dotnet01";
            var storageAsset = await storageContainer.Value.GetStorageAssets().GetAsync(storageAssetName);

            // Act
            var operation = await storageAsset.Value.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
