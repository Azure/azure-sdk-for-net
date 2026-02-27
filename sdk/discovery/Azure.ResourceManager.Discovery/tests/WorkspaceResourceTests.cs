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
    /// Tests for Workspace resource operations.
    /// </summary>
    public class WorkspaceResourceTests : DiscoveryManagementTestBase
    {
        public WorkspaceResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ListWorkspacesBySubscription()
        {
            // Arrange & Act
            var workspaces = new List<WorkspaceResource>();
            await foreach (var workspace in DefaultSubscription.GetWorkspacesAsync())
            {
                workspaces.Add(workspace);
            }

            // Assert
            Assert.That(workspaces, Is.Not.Null);
            // List may be empty but should not throw
        }

        [RecordedTest]
        public async Task ListWorkspacesByResourceGroup()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // Act
            var workspaces = new List<WorkspaceResource>();
            await foreach (var workspace in resourceGroup.GetWorkspaces().GetAllAsync())
            {
                workspaces.Add(workspace);
            }

            // Assert
            Assert.That(workspaces, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetWorkspace()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspaceName = TestEnvironment.WorkspaceName;

            // Act
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(workspaceName);

            // Assert
            Assert.That(workspace.Value, Is.Not.Null);
            Assert.That(workspace.Value.Data.Name, Is.EqualTo(workspaceName));
        }

        [RecordedTest]
        [Ignore("Requires WorkspaceProperties with Identity (user-assigned managed identity resource ID) and linked supercomputer")]
        public async Task CreateWorkspace()
        {
            // Arrange
            var resourceGroup = await CreateResourceGroupAsync();
            var workspaceName = Recording.GenerateAssetName("workspace-");

            // TODO: Workspace creation requires:
            // 1. A user-assigned managed identity
            // 2. WorkspaceProperties with the Identity object
            // 3. Optionally linked supercomputer IDs
            // Example:
            // var identityId = new ResourceIdentifier("/subscriptions/.../resourceGroups/.../providers/Microsoft.ManagedIdentity/userAssignedIdentities/...");
            // var identity = new Discovery.Models.Identity(identityId);
            // var properties = new WorkspaceProperties(identity);
            // var workspaceData = new WorkspaceData(DefaultLocation) { Properties = properties };

            var workspaceData = new WorkspaceData(DefaultLocation)
            {
                Tags =
                {
                    { "test", "value" }
                }
            };

            // Act
            var operation = await resourceGroup.GetWorkspaces().CreateOrUpdateAsync(
                WaitUntil.Completed,
                workspaceName,
                workspaceData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(workspaceName));
        }

        [RecordedTest]
        [Ignore("Requires existing workspace to delete - should create first then delete")]
        public async Task DeleteWorkspace()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // TODO: Either:
            // 1. Create a workspace first, then delete it
            // 2. Or use TestEnvironment.WorkspaceName if deletion is acceptable
            var workspaceName = "workspace-to-delete";
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(workspaceName);

            // Act
            var operation = await workspace.Value.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }

        [RecordedTest]
        [Ignore("Requires existing workspace with properties that can be updated")]
        public async Task UpdateWorkspace()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspaceName = TestEnvironment.WorkspaceName;
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(workspaceName);

            // Create update data with modified tags
            var updateData = workspace.Value.Data;
            updateData.Tags["updated"] = "true";

            // Act
            var operation = await resourceGroup.GetWorkspaces().CreateOrUpdateAsync(
                WaitUntil.Completed,
                workspaceName,
                updateData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Tags.ContainsKey("updated"), Is.True);
        }
    }
}
