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
    /// Tests for ChatModelDeployment resource operations.
    /// ChatModelDeployment is a child resource of Workspace.
    /// </summary>
    public class ChatModelDeploymentResourceTests : DiscoveryManagementTestBase
    {
        public ChatModelDeploymentResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("Requires existing ChatModelDeployment in the workspace")]
        public async Task ListChatModelDeploymentsByWorkspace()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);

            // Act
            var chatModelDeployments = new List<ChatModelDeploymentResource>();
            await foreach (var chatModelDeployment in workspace.Value.GetChatModelDeployments().GetAllAsync())
            {
                chatModelDeployments.Add(chatModelDeployment);
            }

            // Assert
            Assert.That(chatModelDeployments, Is.Not.Null);
        }

        [RecordedTest]
        [Ignore("Requires existing ChatModelDeployment in the workspace")]
        public async Task GetChatModelDeployment()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);
            var chatModelDeploymentName = TestEnvironment.ChatModelDeploymentName;

            // Act
            var chatModelDeployment = await workspace.Value.GetChatModelDeployments().GetAsync(chatModelDeploymentName);

            // Assert
            Assert.That(chatModelDeployment.Value, Is.Not.Null);
            Assert.That(chatModelDeployment.Value.Data.Name, Is.EqualTo(chatModelDeploymentName));
        }

        [RecordedTest]
        [Ignore("Requires ChatModelDeploymentProperties with model configuration")]
        public async Task CreateChatModelDeployment()
        {
            // Arrange - matching Python/Java payload (modelFormat=OpenAI, modelName=gpt-4o)
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);
            var chatModelDeploymentName = "test-cmd-dotnet01";

            var chatModelDeploymentData = new ChatModelDeploymentData(DefaultLocation)
            {
                Properties = new ChatModelDeploymentProperties("OpenAI", "gpt-4o"),
            };

            // Act
            var operation = await workspace.Value.GetChatModelDeployments().CreateOrUpdateAsync(
                WaitUntil.Completed,
                chatModelDeploymentName,
                chatModelDeploymentData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(chatModelDeploymentName));
        }

        [RecordedTest]
        [Ignore("Requires existing ChatModelDeployment to update")]
        public async Task UpdateChatModelDeployment()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);
            var chatModelDeploymentName = TestEnvironment.ChatModelDeploymentName;
            var chatModelDeployment = await workspace.Value.GetChatModelDeployments().GetAsync(chatModelDeploymentName);

            // Update tags matching Python/Java pattern
            var updateData = chatModelDeployment.Value.Data;
            updateData.Tags["SkipAutoDeleteTill"] = "2026-12-31";

            // Act
            var operation = await workspace.Value.GetChatModelDeployments().CreateOrUpdateAsync(
                WaitUntil.Completed,
                chatModelDeploymentName,
                updateData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Tags.ContainsKey("SkipAutoDeleteTill"), Is.True);
        }

        [RecordedTest]
        [Ignore("Requires existing ChatModelDeployment to delete")]
        public async Task DeleteChatModelDeployment()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var workspace = await resourceGroup.GetWorkspaces().GetAsync(TestEnvironment.WorkspaceName);
            var chatModelDeploymentName = "test-cmd-dotnet01";
            var chatModelDeployment = await workspace.Value.GetChatModelDeployments().GetAsync(chatModelDeploymentName);

            // Act
            var operation = await chatModelDeployment.Value.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
