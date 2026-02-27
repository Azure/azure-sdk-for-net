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
    /// Tests for StorageContainer resource operations.
    /// StorageContainer is a top-level resource under ResourceGroup.
    /// </summary>
    public class StorageContainerResourceTests : DiscoveryManagementTestBase
    {
        public StorageContainerResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("Requires existing StorageContainer in the subscription")]
        public async Task ListStorageContainersBySubscription()
        {
            // Arrange & Act
            var storageContainers = new List<StorageContainerResource>();
            await foreach (var storageContainer in DefaultSubscription.GetStorageContainersAsync())
            {
                storageContainers.Add(storageContainer);
            }

            // Assert
            Assert.That(storageContainers, Is.Not.Null);
        }

        [RecordedTest]
        [Ignore("Requires existing StorageContainer in the resource group")]
        public async Task ListStorageContainersByResourceGroup()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // Act
            var storageContainers = new List<StorageContainerResource>();
            await foreach (var storageContainer in resourceGroup.GetStorageContainers().GetAllAsync())
            {
                storageContainers.Add(storageContainer);
            }

            // Assert
            Assert.That(storageContainers, Is.Not.Null);
        }

        [RecordedTest]
        [Ignore("Requires existing StorageContainer")]
        public async Task GetStorageContainer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // TODO: Replace with actual storage container name from TestEnvironment
            var storageContainerName = "test-storagecontainer";

            // Act
            var storageContainer = await resourceGroup.GetStorageContainers().GetAsync(storageContainerName);

            // Assert
            Assert.That(storageContainer.Value, Is.Not.Null);
            Assert.That(storageContainer.Value.Data.Name, Is.EqualTo(storageContainerName));
        }

        [RecordedTest]
        [Ignore("Requires StorageContainerProperties with storage configuration")]
        public async Task CreateStorageContainer()
        {
            // Arrange
            var resourceGroup = await CreateResourceGroupAsync();
            var storageContainerName = Recording.GenerateAssetName("storage-");

            // TODO: StorageContainer creation requires:
            // 1. StorageContainerProperties with storage store configuration
            // 2. Network configuration
            var storageContainerData = new StorageContainerData(DefaultLocation)
            {
                Tags =
                {
                    { "test", "value" }
                }
            };

            // Act
            var operation = await resourceGroup.GetStorageContainers().CreateOrUpdateAsync(
                WaitUntil.Completed,
                storageContainerName,
                storageContainerData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(storageContainerName));
        }

        [RecordedTest]
        [Ignore("Requires existing StorageContainer to update")]
        public async Task UpdateStorageContainer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // TODO: Replace with actual storage container name from TestEnvironment
            var storageContainerName = "test-storagecontainer";
            var storageContainer = await resourceGroup.GetStorageContainers().GetAsync(storageContainerName);

            // Create update data with modified tags
            var updateData = storageContainer.Value.Data;
            updateData.Tags["updated"] = "true";

            // Act
            var operation = await resourceGroup.GetStorageContainers().CreateOrUpdateAsync(
                WaitUntil.Completed,
                storageContainerName,
                updateData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Tags.ContainsKey("updated"), Is.True);
        }

        [RecordedTest]
        [Ignore("Requires existing StorageContainer to delete")]
        public async Task DeleteStorageContainer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // TODO: Either create a StorageContainer first, then delete it
            // Or use an existing container that can be deleted
            var storageContainerName = "storage-to-delete";
            var storageContainer = await resourceGroup.GetStorageContainers().GetAsync(storageContainerName);

            // Act
            var operation = await storageContainer.Value.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
