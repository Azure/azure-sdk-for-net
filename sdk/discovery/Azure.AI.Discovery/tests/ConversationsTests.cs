// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Discovery.Tests
{
    /// <summary>
    /// Tests for Conversations operations.
    /// Covers all 5 methods: Get, Create, Update, Delete, GetAll (Paged).
    ///
    /// Every test that needs a conversation creates one inline and captures the
    /// server-assigned name to avoid stale IDs and ordering dependencies.
    /// </summary>
    public class ConversationsTests : WorkspaceClientTestBase
    {
        public ConversationsTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Helper: create a conversation and return its server-assigned name.
        /// </summary>
        private async Task<string> CreateConversationAsync(
            DiscoveryConversationsClient conversationsClient,
            string projectName,
            string investigationName)
        {
            string investigationPath = $"/projects/{projectName}/investigations/{investigationName}";
            var created = await conversationsClient.CreateAsync(projectName, investigationPath);
            Assert.That(created.Value, Is.Not.Null);
            return created.Value.Name;
        }

        /// <summary>
        /// Helper: best-effort cleanup — delete a conversation, ignoring failures.
        /// </summary>
        private async System.Threading.Tasks.Task DeleteConversationQuietAsync(
            DiscoveryConversationsClient conversationsClient,
            string conversationName)
        {
            try
            {
                await conversationsClient.DeleteAsync(conversationName);
            }
            catch { }
        }

        [RecordedTest]
        public async Task ListConversations()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var conversationsClient = client.GetDiscoveryConversationsClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            // Ensure at least one conversation exists
            string conversationName = await CreateConversationAsync(
                conversationsClient, projectName, investigationName);
            try
            {
                // Act
                var result = await conversationsClient.GetAllAsync(projectName: projectName);
                var conversations = result.Value;

                // Assert
                Assert.That(conversations, Is.Not.Null);
            }
            finally
            {
                await DeleteConversationQuietAsync(conversationsClient, conversationName);
            }
        }

        [RecordedTest]
        public async Task GetConversation()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var conversationsClient = client.GetDiscoveryConversationsClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            string conversationName = await CreateConversationAsync(
                conversationsClient, projectName, investigationName);
            try
            {
                // Act
                var conversation = await conversationsClient.GetAsync(conversationName);

                // Assert
                ValidateResponse(conversation.Value, "DiscoveryConversation");
                Assert.That(conversation.Value.Name, Is.EqualTo(conversationName));
            }
            finally
            {
                await DeleteConversationQuietAsync(conversationsClient, conversationName);
            }
        }

        [RecordedTest]
        public async Task CreateConversation()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var conversationsClient = client.GetDiscoveryConversationsClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;
            string investigationPath = $"/projects/{projectName}/investigations/{investigationName}";

            // Act
            var conversation = await conversationsClient.CreateAsync(projectName, investigationPath);

            // Assert
            ValidateResponse(conversation.Value, "DiscoveryConversation");
            Assert.That(conversation.Value, Is.Not.Null);

            // Cleanup
            await DeleteConversationQuietAsync(conversationsClient, conversation.Value.Name);
        }

        [RecordedTest]
        public async Task UpdateConversation()
        {
            // Arrange
            WorkspaceClient client = CreateWorkspaceClient();
            var conversationsClient = client.GetDiscoveryConversationsClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            string conversationName = await CreateConversationAsync(
                conversationsClient, projectName, investigationName);
            try
            {
                // Act - PATCH via RequestContent
                var content = RequestContent.Create(new { displayName = TestConstants.UpdatedConversationDisplayName });
                var response = await conversationsClient.UpdateAsync(conversationName, content);

                // Assert
                Assert.That(response.Status, Is.EqualTo(200));
            }
            finally
            {
                await DeleteConversationQuietAsync(conversationsClient, conversationName);
            }
        }

        [RecordedTest]
        public async Task DeleteConversation()
        {
            // Arrange — create a sacrificial conversation to delete
            WorkspaceClient client = CreateWorkspaceClient();
            var conversationsClient = client.GetDiscoveryConversationsClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            string conversationName = await CreateConversationAsync(
                conversationsClient, projectName, investigationName);

            // Act & Assert — should not throw
            await conversationsClient.DeleteAsync(conversationName);
        }

        [RecordedTest]
        public async Task GetConversationWithNoMessages()
        {
            // Arrange - create a fresh conversation with no messages
            WorkspaceClient client = CreateWorkspaceClient();
            var conversationsClient = client.GetDiscoveryConversationsClient();
            string projectName = TestEnvironment.ProjectName;
            string investigationName = TestEnvironment.InvestigationName;

            string conversationName = await CreateConversationAsync(
                conversationsClient, projectName, investigationName);
            try
            {
                // Act - get the conversation that has no messages
                var conversation = await conversationsClient.GetAsync(conversationName);

                // Assert
                Assert.That(conversation.Value, Is.Not.Null);
                Assert.That(conversation.Value.Name, Is.EqualTo(conversationName));
            }
            finally
            {
                await DeleteConversationQuietAsync(conversationsClient, conversationName);
            }
        }
    }
}