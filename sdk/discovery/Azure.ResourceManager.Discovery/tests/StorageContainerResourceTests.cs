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
    /// Tests for StorageContainer resource operations.
    /// StorageContainer is a top-level resource under ResourceGroup.
    /// </summary>
    public class StorageContainerResourceTests : DiscoveryManagementTestBase
    {
        public StorageContainerResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
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
        public async Task GetStorageContainer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var storageContainerName = TestEnvironment.StorageContainerName;

            // Act
            var storageContainer = await resourceGroup.GetStorageContainers().GetAsync(storageContainerName);

            // Assert
            Assert.That(storageContainer.Value, Is.Not.Null);
            Assert.That(storageContainer.Value.Data.Name, Is.EqualTo(storageContainerName));
        }

        [RecordedTest]
        public async Task CreateStorageContainer()
        {
            // Arrange - matching Python/Java payload
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var storageContainerName = "test-sc-dotnet01";

            var subscriptionId = DefaultSubscription.Data.SubscriptionId;
            var storageAccountId = new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/olawal/providers/Microsoft.Storage/storageAccounts/mytststr");

            var storageContainerData = new StorageContainerData(DefaultLocation)
            {
                Properties = new StorageContainerProperties(
                    new AzureStorageBlobStore(storageAccountId)),
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
        public async Task UpdateStorageContainer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var storageContainerName = TestEnvironment.StorageContainerName;
            var storageContainer = await resourceGroup.GetStorageContainers().GetAsync(storageContainerName);

            // Update tags matching Python/Java pattern
            var updateData = storageContainer.Value.Data;
            updateData.Tags["SkipAutoDeleteTill"] = "2026-12-31";

            // Act
            var operation = await resourceGroup.GetStorageContainers().CreateOrUpdateAsync(
                WaitUntil.Completed,
                storageContainerName,
                updateData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Tags.ContainsKey("SkipAutoDeleteTill"), Is.True);
        }

        [RecordedTest]
        public async Task DeleteStorageContainer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var storageContainerName = "test-sc-dotnet01";
            var storageContainer = await resourceGroup.GetStorageContainers().GetAsync(storageContainerName);

            // Act
            var operation = await storageContainer.Value.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
