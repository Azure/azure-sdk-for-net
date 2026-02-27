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
    /// Tests for Supercomputer resource operations.
    /// </summary>
    public class SupercomputerResourceTests : DiscoveryManagementTestBase
    {
        public SupercomputerResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]

        public async Task ListSupercomputersBySubscription()
        {
            // Arrange & Act
            var supercomputers = new List<SupercomputerResource>();
            await foreach (var supercomputer in DefaultSubscription.GetSupercomputersAsync())
            {
                supercomputers.Add(supercomputer);
            }

            // Assert
            Assert.That(supercomputers, Is.Not.Null);
            // List may be empty but should not throw
        }

        [RecordedTest]

        public async Task ListSupercomputersByResourceGroup()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // Act
            var supercomputers = new List<SupercomputerResource>();
            await foreach (var supercomputer in resourceGroup.GetSupercomputers().GetAllAsync())
            {
                supercomputers.Add(supercomputer);
            }

            // Assert
            Assert.That(supercomputers, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetSupercomputer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var supercomputerName = TestEnvironment.SupercomputerName;

            // Act
            var supercomputer = await resourceGroup.GetSupercomputers().GetAsync(supercomputerName);

            // Assert
            Assert.That(supercomputer.Value, Is.Not.Null);
            Assert.That(supercomputer.Value.Data.Name, Is.EqualTo(supercomputerName));
        }

        [RecordedTest]
        [Ignore("Requires SupercomputerProperties with SupercomputerIdentities and network configuration")]
        public async Task CreateSupercomputer()
        {
            // Arrange
            var resourceGroup = await CreateResourceGroupAsync();
            var supercomputerName = Recording.GenerateAssetName("supercomputer-");

            // TODO: Supercomputer creation requires:
            // 1. SupercomputerProperties with SupercomputerIdentities
            // 2. Network configuration (subnet IDs, etc.)
            var supercomputerData = new SupercomputerData(DefaultLocation)
            {
                Tags =
                {
                    { "test", "value" }
                }
            };

            // Act
            var operation = await resourceGroup.GetSupercomputers().CreateOrUpdateAsync(
                WaitUntil.Completed,
                supercomputerName,
                supercomputerData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(supercomputerName));
        }

        [RecordedTest]
        [Ignore("Requires existing supercomputer to delete - should create first then delete")]
        public async Task DeleteSupercomputer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // TODO: Either create a supercomputer first, then delete it
            // Or use TestEnvironment.SupercomputerName if deletion is acceptable
            var supercomputerName = "supercomputer-to-delete";
            var supercomputer = await resourceGroup.GetSupercomputers().GetAsync(supercomputerName);

            // Act
            var operation = await supercomputer.Value.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }

        [RecordedTest]
        [Ignore("Requires existing supercomputer with properties that can be updated")]
        public async Task UpdateSupercomputer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var supercomputerName = TestEnvironment.SupercomputerName;
            var supercomputer = await resourceGroup.GetSupercomputers().GetAsync(supercomputerName);

            // Create update data with modified tags
            var updateData = supercomputer.Value.Data;
            updateData.Tags["updated"] = "true";

            // Act
            var operation = await resourceGroup.GetSupercomputers().CreateOrUpdateAsync(
                WaitUntil.Completed,
                supercomputerName,
                updateData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Tags.ContainsKey("updated"), Is.True);
        }
    }
}
