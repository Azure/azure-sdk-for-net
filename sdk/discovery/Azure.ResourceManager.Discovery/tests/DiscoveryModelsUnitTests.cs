// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Discovery.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests
{
    /// <summary>
    /// Unit tests for Azure.ResourceManager.Discovery models.
    /// These tests verify model initialization without making HTTP calls.
    /// </summary>
    public class DiscoveryModelsUnitTests
    {
        [Test]
        public void BookshelfData_CanBeInitialized()
        {
            // Arrange & Act
            var bookshelf = new BookshelfData(AzureLocation.EastUS);

            // Assert
            Assert.That(bookshelf, Is.Not.Null);
            Assert.That(bookshelf.Location.Name, Is.EqualTo("eastus"));
        }

        [Test]
        public void WorkspaceData_CanBeInitialized()
        {
            // Arrange & Act
            var workspace = new WorkspaceData(AzureLocation.EastUS);

            // Assert
            Assert.That(workspace, Is.Not.Null);
            Assert.That(workspace.Location.Name, Is.EqualTo("eastus"));
        }

        [Test]
        public void ProjectData_CanBeInitialized()
        {
            // Arrange & Act
            var project = new ProjectData(AzureLocation.EastUS);

            // Assert
            Assert.That(project, Is.Not.Null);
            Assert.That(project.Location.Name, Is.EqualTo("eastus"));
        }

        [Test]
        public void SupercomputerData_CanBeInitialized()
        {
            // Arrange & Act
            var supercomputer = new SupercomputerData(AzureLocation.EastUS);

            // Assert
            Assert.That(supercomputer, Is.Not.Null);
            Assert.That(supercomputer.Location.Name, Is.EqualTo("eastus"));
        }

        [Test]
        public void NodePoolData_CanBeInitialized()
        {
            // Arrange & Act - NodePoolData requires AzureLocation
            var nodePool = new NodePoolData(AzureLocation.EastUS);

            // Assert
            Assert.That(nodePool, Is.Not.Null);
            Assert.That(nodePool.Location.Name, Is.EqualTo("eastus"));
        }

        [Test]
        public void StorageContainerData_CanBeInitialized()
        {
            // Arrange & Act - StorageContainerData requires AzureLocation
            var storageContainer = new StorageContainerData(AzureLocation.EastUS);

            // Assert
            Assert.That(storageContainer, Is.Not.Null);
            Assert.That(storageContainer.Location.Name, Is.EqualTo("eastus"));
        }

        [Test]
        public void StorageAssetData_CanBeInitialized()
        {
            // Arrange & Act - StorageAssetData requires AzureLocation
            var storageAsset = new StorageAssetData(AzureLocation.EastUS);

            // Assert
            Assert.That(storageAsset, Is.Not.Null);
            Assert.That(storageAsset.Location.Name, Is.EqualTo("eastus"));
        }

        [Test]
        public void ChatModelDeploymentData_CanBeInitialized()
        {
            // Arrange & Act - ChatModelDeploymentData requires AzureLocation
            var deployment = new ChatModelDeploymentData(AzureLocation.EastUS);

            // Assert
            Assert.That(deployment, Is.Not.Null);
            Assert.That(deployment.Location.Name, Is.EqualTo("eastus"));
        }

        [Test]
        public void ToolData_CanBeInitialized()
        {
            // Arrange & Act - ToolData requires AzureLocation
            var tool = new ToolData(AzureLocation.EastUS);

            // Assert
            Assert.That(tool, Is.Not.Null);
            Assert.That(tool.Location.Name, Is.EqualTo("eastus"));
        }

        [Test]
        public void ProvisioningState_EnumValuesExist()
        {
            // Assert - verify enum values can be accessed (actual name is ProvisioningState, not DiscoveryProvisioningState)
            Assert.That(ProvisioningState.Succeeded.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(ProvisioningState.Failed.ToString(), Is.EqualTo("Failed"));
            Assert.That(ProvisioningState.Canceled.ToString(), Is.EqualTo("Canceled"));
        }

        [Test]
        public void ArmDiscoveryModelFactory_CanCreateBookshelfData()
        {
            // Arrange & Act
            var bookshelf = ArmDiscoveryModelFactory.BookshelfData(
                location: AzureLocation.EastUS);

            // Assert
            Assert.That(bookshelf, Is.Not.Null);
        }

        [Test]
        public void ArmDiscoveryModelFactory_CanCreateWorkspaceData()
        {
            // Arrange & Act
            var workspace = ArmDiscoveryModelFactory.WorkspaceData(
                location: AzureLocation.EastUS);

            // Assert
            Assert.That(workspace, Is.Not.Null);
        }
    }
}
