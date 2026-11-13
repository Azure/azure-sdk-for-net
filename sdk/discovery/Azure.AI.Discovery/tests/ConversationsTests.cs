// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Discovery.Tests
{
    /// <summary>
    /// Tests for conversation operations on <see cref="DiscoveryConversationsClient"/>
    /// (create, get, list, update, delete). Ported from the Python
    /// <c>test_conversations.py</c> suite.
    /// </summary>
    public class ConversationsTests : DiscoveryTestBase
    {
        public ConversationsTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<DiscoveryConversation> CreateConversationAsync(DiscoveryConversationsClient client, string displayName)
        {
            return await client.CreateAsync(
                projectName: TestEnvironment.ProjectName,
                investigationName: InvestigationPath(),
                displayName: displayName);
        }

        [RecordedTest]
        [Order(1)]
        public async Task CreateConversation()
        {
            DiscoveryConversationsClient client = CreateConversationsClient();
            DiscoveryConversation conversation = await CreateConversationAsync(client, "Test conversation");

            Assert.That(conversation, Is.Not.Null);
            Assert.That(conversation.ProjectName, Is.EqualTo(TestEnvironment.ProjectName));
            Assert.That(conversation.Name, Is.Not.Null);
            Assert.That(conversation.CreatedOn, Is.Not.Null);
        }

        [RecordedTest]
        [Order(3)]
        public async Task GetConversation()
        {
            DiscoveryConversationsClient client = CreateConversationsClient();
            DiscoveryConversation created = await CreateConversationAsync(client, "Conversation for get test");

            DiscoveryConversation conversation = await client.GetAsync(created.Name);

            Assert.That(conversation, Is.Not.Null);
            Assert.That(conversation.Name, Is.EqualTo(created.Name));
            Assert.That(conversation.ProjectName, Is.EqualTo(TestEnvironment.ProjectName));
            Assert.That(conversation.CreatedOn, Is.Not.Null);
        }

        [RecordedTest]
        [Order(2)]
        public async Task ListConversations()
        {
            DiscoveryConversationsClient client = CreateConversationsClient();
            DiscoveryConversation created = await CreateConversationAsync(client, "Conversation for list test");

            PagedConversation page = await client.GetAllAsync(projectName: TestEnvironment.ProjectName);

            Assert.That(page.Value, Is.Not.Null);
            Assert.That(page.Value.Count, Is.GreaterThan(0));
            bool found = false;
            foreach (DiscoveryConversation conv in page.Value)
            {
                Assert.That(conv.ProjectName, Is.EqualTo(TestEnvironment.ProjectName));
                Assert.That(conv.CreatedOn, Is.Not.Null);
                Assert.That(conv.InvestigationName, Is.Not.Null);
                if (conv.Name == created.Name)
                {
                    found = true;
                }
            }
            Assert.That(found, Is.True, "Conversation created in this test should appear in the list results.");
        }

        [RecordedTest]
        [Order(4)]
        public async Task UpdateConversation()
        {
            DiscoveryConversationsClient client = CreateConversationsClient();
            DiscoveryConversation created = await CreateConversationAsync(client, "Conversation to update");

            RequestContent content = RequestContent.Create(new { displayName = "Updated conversation" });
            Response response = await client.StableUpdateAsync(created.Name, content);
            var updated = (DiscoveryConversation)response;

            Assert.That(updated.DisplayName, Is.EqualTo("Updated conversation"));
            Assert.That(updated.LastModifiedOn, Is.Not.Null);
        }

        [RecordedTest]
        [Order(5)]
        public async Task DeleteConversation()
        {
            DiscoveryConversationsClient client = CreateConversationsClient();
            DiscoveryConversation created = await CreateConversationAsync(client, "Conversation to delete");

            Response response = await client.DeleteAsync(created.Name);

            Assert.That(response.Status, Is.InRange(200, 299));
        }
    }
}
