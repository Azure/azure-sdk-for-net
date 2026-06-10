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
    /// Tests for Private Endpoint related resource operations.
    /// Includes:
    /// - WorkspacePrivateEndpointConnection
    /// - WorkspacePrivateLinkResource
    /// - BookshelfPrivateEndpointConnection
    /// - BookshelfPrivateLinkResource
    /// </summary>
    public class PrivateEndpointResourceTests : DiscoveryManagementTestBase
    {
        public PrivateEndpointResourceTests(bool isAsync) : base(isAsync)
        {
        }

        #region Workspace Private Endpoint Connection Tests

        [RecordedTest]
        [Ignore("Requires existing private endpoint connections for the workspace")]
        public async Task ListWorkspacePrivateEndpointConnections()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);

            // Act
            var connections = new List<WorkspacePrivateEndpointConnectionResource>();
            await foreach (var connection in workspace.Value.GetWorkspacePrivateEndpointConnections().GetAllAsync())
            {
                connections.Add(connection);
            }

            // Assert
            Assert.That(connections, Is.Not.Null);
        }

        [RecordedTest]
        [Ignore("Requires existing private endpoint connection")]
        public async Task GetWorkspacePrivateEndpointConnection()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);

            // TODO: Replace with actual private endpoint connection name
            var connectionName = "test-pe-connection";

            // Act
            var connection = await workspace.Value.GetWorkspacePrivateEndpointConnections().GetAsync(connectionName);

            // Assert
            Assert.That(connection.Value, Is.Not.Null);
            Assert.That(connection.Value.Data.Name, Is.EqualTo(connectionName));
        }

        [RecordedTest]
        [Ignore("Requires private endpoint configuration and network setup")]
        public async Task CreateWorkspacePrivateEndpointConnection()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);
            var connectionName = Recording.GenerateAssetName("pe-conn-");

            // TODO: Private endpoint connection creation requires:
            // 1. PrivateEndpointConnectionProperties with connection state
            // 2. Existing private endpoint in a VNet
            var connectionData = new WorkspacePrivateEndpointConnectionData();

            // Act
            var operation = await workspace.Value.GetWorkspacePrivateEndpointConnections().CreateOrUpdateAsync(
                WaitUntil.Completed,
                connectionName,
                connectionData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(connectionName));
        }

        [RecordedTest]
        [Ignore("Requires existing private endpoint connection to delete")]
        public async Task DeleteWorkspacePrivateEndpointConnection()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);

            // TODO: Replace with actual private endpoint connection name
            var connectionName = "pe-conn-to-delete";
            var connection = await workspace.Value.GetWorkspacePrivateEndpointConnections().GetAsync(connectionName);

            // Act
            var operation = await connection.Value.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }

        #endregion

        #region Workspace Private Link Resource Tests

        [RecordedTest]
        [Ignore("Requires workspace configured for private endpoint")]
        public async Task ListWorkspacePrivateLinkResources()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);

            // Act
            var linkResources = new List<WorkspacePrivateLinkResource>();
            await foreach (var linkResource in workspace.Value.GetWorkspacePrivateLinkResources().GetAllAsync())
            {
                linkResources.Add(linkResource);
            }

            // Assert
            Assert.That(linkResources, Is.Not.Null);
        }

        [RecordedTest]
        [Ignore("Requires workspace configured for private endpoint")]
        public async Task GetWorkspacePrivateLinkResource()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);

            // TODO: Replace with actual private link resource name (typically "workspace" or similar)
            var linkResourceName = "workspace";

            // Act
            var linkResource = await workspace.Value.GetWorkspacePrivateLinkResources().GetAsync(linkResourceName);

            // Assert
            Assert.That(linkResource.Value, Is.Not.Null);
        }

        #endregion

        #region Bookshelf Private Endpoint Connection Tests

        [RecordedTest]
        [Ignore("Requires existing private endpoint connections for the bookshelf")]
        public async Task ListBookshelfPrivateEndpointConnections()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var bookshelf = await resourceGroup.GetBookshelves().GetAsync(TestEnvironment.BookshelfName);

            // Act
            var connections = new List<BookshelfPrivateEndpointConnectionResource>();
            await foreach (var connection in bookshelf.Value.GetBookshelfPrivateEndpointConnections().GetAllAsync())
            {
                connections.Add(connection);
            }

            // Assert
            Assert.That(connections, Is.Not.Null);
        }

        [RecordedTest]
        [Ignore("Requires existing private endpoint connection")]
        public async Task GetBookshelfPrivateEndpointConnection()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var bookshelf = await resourceGroup.GetBookshelves().GetAsync(TestEnvironment.BookshelfName);

            // TODO: Replace with actual private endpoint connection name
            var connectionName = "test-pe-connection";

            // Act
            var connection = await bookshelf.Value.GetBookshelfPrivateEndpointConnections().GetAsync(connectionName);

            // Assert
            Assert.That(connection.Value, Is.Not.Null);
            Assert.That(connection.Value.Data.Name, Is.EqualTo(connectionName));
        }

        [RecordedTest]
        [Ignore("Requires private endpoint configuration and network setup")]
        public async Task CreateBookshelfPrivateEndpointConnection()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var bookshelf = await resourceGroup.GetBookshelves().GetAsync(TestEnvironment.BookshelfName);
            var connectionName = Recording.GenerateAssetName("pe-conn-");

            // TODO: Private endpoint connection creation requires:
            // 1. PrivateEndpointConnectionProperties with connection state
            // 2. Existing private endpoint in a VNet
            var connectionData = new BookshelfPrivateEndpointConnectionData();

            // Act
            var operation = await bookshelf.Value.GetBookshelfPrivateEndpointConnections().CreateOrUpdateAsync(
                WaitUntil.Completed,
                connectionName,
                connectionData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(connectionName));
        }

        [RecordedTest]
        [Ignore("Requires existing private endpoint connection to delete")]
        public async Task DeleteBookshelfPrivateEndpointConnection()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var bookshelf = await resourceGroup.GetBookshelves().GetAsync(TestEnvironment.BookshelfName);

            // TODO: Replace with actual private endpoint connection name
            var connectionName = "pe-conn-to-delete";
            var connection = await bookshelf.Value.GetBookshelfPrivateEndpointConnections().GetAsync(connectionName);

            // Act
            var operation = await connection.Value.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }

        #endregion

        #region Bookshelf Private Link Resource Tests

        [RecordedTest]
        [Ignore("Requires bookshelf configured for private endpoint")]
        public async Task ListBookshelfPrivateLinkResources()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var bookshelf = await resourceGroup.GetBookshelves().GetAsync(TestEnvironment.BookshelfName);

            // Act
            var linkResources = new List<BookshelfPrivateLinkResource>();
            await foreach (var linkResource in bookshelf.Value.GetBookshelfPrivateLinkResources().GetAllAsync())
            {
                linkResources.Add(linkResource);
            }

            // Assert
            Assert.That(linkResources, Is.Not.Null);
        }

        [RecordedTest]
        [Ignore("Requires bookshelf configured for private endpoint")]
        public async Task GetBookshelfPrivateLinkResource()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var bookshelf = await resourceGroup.GetBookshelves().GetAsync(TestEnvironment.BookshelfName);

            // TODO: Replace with actual private link resource name (typically "bookshelf" or similar)
            var linkResourceName = "bookshelf";

            // Act
            var linkResource = await bookshelf.Value.GetBookshelfPrivateLinkResources().GetAsync(linkResourceName);

            // Assert
            Assert.That(linkResource.Value, Is.Not.Null);
        }

        #endregion
    }
}
