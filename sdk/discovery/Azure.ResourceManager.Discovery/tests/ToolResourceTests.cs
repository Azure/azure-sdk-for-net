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
    /// Tests for Tool resource operations.
    /// Tool is a top-level resource under ResourceGroup.
    /// </summary>
    public class ToolResourceTests : DiscoveryManagementTestBase
    {
        public ToolResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("Requires existing Tool in the subscription")]
        public async Task ListToolsBySubscription()
        {
            // Arrange & Act
            var tools = new List<ToolResource>();
            await foreach (var tool in DefaultSubscription.GetToolsAsync())
            {
                tools.Add(tool);
            }

            // Assert
            Assert.That(tools, Is.Not.Null);
        }

        [RecordedTest]
        [Ignore("Requires existing Tool in the resource group")]
        public async Task ListToolsByResourceGroup()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // Act
            var tools = new List<ToolResource>();
            await foreach (var tool in resourceGroup.GetTools().GetAllAsync())
            {
                tools.Add(tool);
            }

            // Assert
            Assert.That(tools, Is.Not.Null);
        }

        [RecordedTest]
        [Ignore("Requires existing Tool")]
        public async Task GetTool()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // TODO: Replace with actual tool name from TestEnvironment
            var toolName = "test-tool";

            // Act
            var tool = await resourceGroup.GetTools().GetAsync(toolName);

            // Assert
            Assert.That(tool.Value, Is.Not.Null);
            Assert.That(tool.Value.Data.Name, Is.EqualTo(toolName));
        }

        [RecordedTest]
        [Ignore("Requires ToolProperties with tool configuration")]
        public async Task CreateTool()
        {
            // Arrange
            var resourceGroup = await CreateResourceGroupAsync();
            var toolName = Recording.GenerateAssetName("tool-");

            // TODO: Tool creation requires:
            // 1. ToolProperties with tool configuration
            var toolData = new ToolData(DefaultLocation)
            {
                Tags =
                {
                    { "test", "value" }
                }
            };

            // Act
            var operation = await resourceGroup.GetTools().CreateOrUpdateAsync(
                WaitUntil.Completed,
                toolName,
                toolData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(toolName));
        }

        [RecordedTest]
        [Ignore("Requires existing Tool to update")]
        public async Task UpdateTool()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // TODO: Replace with actual tool name from TestEnvironment
            var toolName = "test-tool";
            var tool = await resourceGroup.GetTools().GetAsync(toolName);

            // Create update data with modified tags
            var updateData = tool.Value.Data;
            updateData.Tags["updated"] = "true";

            // Act
            var operation = await resourceGroup.GetTools().CreateOrUpdateAsync(
                WaitUntil.Completed,
                toolName,
                updateData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Tags.ContainsKey("updated"), Is.True);
        }

        [RecordedTest]
        [Ignore("Requires existing Tool to delete")]
        public async Task DeleteTool()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // TODO: Either create a Tool first, then delete it
            // Or use an existing tool that can be deleted
            var toolName = "tool-to-delete";
            var tool = await resourceGroup.GetTools().GetAsync(toolName);

            // Act
            var operation = await tool.Value.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
