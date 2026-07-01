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
        [Ignore("Recording not yet captured")]
        public async Task CreateWorkspace()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspaceName = "test-wrksp-dotnet01";

            var subscriptionId = DefaultSubscription.Data.SubscriptionId;
            var miId = new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourcegroups/olawal/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myidentity");

            var workspaceData = new WorkspaceData(DefaultLocation)
            {
                Properties = new WorkspaceProperties(new Discovery.Models.Identity(miId))
                {
                    AgentSubnetId = new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/olawal/providers/Microsoft.Network/virtualNetworks/newapiv/subnets/default3"),
                    PrivateEndpointSubnetId = new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/olawal/providers/Microsoft.Network/virtualNetworks/newapiv/subnets/default"),
                    WorkspaceSubnetId = new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/olawal/providers/Microsoft.Network/virtualNetworks/newapiv/subnets/default2"),
                    CustomerManagedKeys = Discovery.Models.CustomerManagedKeys.Enabled,
                    KeyVaultProperties = new Discovery.Models.KeyVaultProperties(new System.Uri("https://newapik.vault.azure.net/"), "discoverykey")
                    {
                        KeyVersion = "2c9db3cf55d247b4a1c1831fbbdad906"
                    },
                    LogAnalyticsClusterId = new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/olawal/providers/Microsoft.OperationalInsights/clusters/mycluse"),
                    PublicNetworkAccess = Discovery.Models.PublicNetworkAccess.Disabled,
                },
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
            var workspaceName = "test-wrksp-dotnet01";
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

            // Update tags matching Python/Java pattern
            var updateData = workspace.Value.Data;
            updateData.Tags["SkipAutoDeleteTill"] = "2026-12-31";

            // Act
            var operation = await resourceGroup.GetWorkspaces().CreateOrUpdateAsync(
                WaitUntil.Completed,
                workspaceName,
                updateData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Tags.ContainsKey("SkipAutoDeleteTill"), Is.True);
        }
    }
}
