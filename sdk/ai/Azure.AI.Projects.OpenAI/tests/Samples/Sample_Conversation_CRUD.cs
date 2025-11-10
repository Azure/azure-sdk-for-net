// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

[Ignore("Samples represented as tests only for validation of compilation.")]
public class Sample_conversation_CRUD : AgentsTestBase
{
    [Test]
    [AsyncOnly]
    public async Task ConversationCRUDAsync()
    {
        #region Snippet:Sample_CreateAgentClient_ConversationCRUD
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
#endif
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateConversations_ConversationCRUD_Async
        AgentConversation conversation1 = await client.OpenAI.Conversations.CreateAgentConversationAsync();
        Console.WriteLine($"Created conversation (id: {conversation1.Id})");

        AgentConversation conversation2 = await client.OpenAI.Conversations.CreateAgentConversationAsync();
        Console.WriteLine($"Created conversation (id: {conversation2.Id})");
        #endregion

        #region Snippet:Sample_GetConversation_ConversationCRUD_Async
        AgentConversation conversation = await client.OpenAI.Conversations.GetAgentConversationAsync(conversationId: conversation1.Id);
        Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
        #endregion

        #region Snippet:Sample_ListConversations_ConversationCRUD_Async
        await foreach (AgentConversation res in client.OpenAI.Conversations.GetAgentConversationsAsync()){
            Console.WriteLine($"Listed conversation (id: {res.Id})");
        }
        #endregion

        #region Snippet:Sample_UpdateConversations_ConversationCRUD_Async
        ProjectConversationUpdateOptions updateOptions = new()
        {
            Metadata = { ["key"] = "value" },
        };
        await client.OpenAI.Conversations.UpdateAgentConversationAsync(conversation.Id, updateOptions);

        // Get the updated conversation.
        conversation = await client.OpenAI.Conversations.GetAgentConversationAsync(conversation1.Id);
        Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
        #endregion

        #region Snippet:Sample_DeleteConversations_ConversationCRUD_Async
        await client.OpenAI.Conversations.DeleteConversationAsync(conversationId: conversation1.Id);
        await client.OpenAI.Conversations.DeleteConversationAsync(conversationId: conversation2.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void ConversationCRUDSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
#endif
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateConversations_ConversationCRUD_Sync
        AgentConversation conversation1 = client.OpenAI.Conversations.CreateAgentConversation();
        Console.WriteLine($"Created conversation (id: {conversation1.Id})");

        AgentConversation conversation2 = client.OpenAI.Conversations.CreateAgentConversation();
        Console.WriteLine($"Created conversation (id: {conversation2.Id})");
        #endregion

        #region Snippet:Sample_GetConversation_ConversationCRUD_Sync
        AgentConversation conversation = client.OpenAI.Conversations.GetAgentConversation(conversationId: conversation1.Id);
        Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
        #endregion

        #region Snippet:Sample_ListConversations_ConversationCRUD_Sync
        foreach (AgentConversation res in client.OpenAI.Conversations.GetAgentConversations())
        {
            Console.WriteLine($"Listed conversation (id: {res.Id})");
        }
        #endregion

        #region Snippet:Sample_UpdateConversations_ConversationCRUD_Sync
        ProjectConversationUpdateOptions updateOptions = new()
        {
            Metadata = { ["key"] = "value" },
        };
        client.OpenAI.Conversations.UpdateAgentConversation(conversation1.Id, updateOptions);

        // Get the updated conversation.
        conversation = client.OpenAI.Conversations.GetAgentConversation(conversationId: conversation1.Id);
        Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
        #endregion

        #region Snippet:Sample_DeleteConversations_ConversationCRUD_Sync
        client.OpenAI.Conversations.DeleteConversation(conversationId: conversation1.Id);
        client.OpenAI.Conversations.DeleteConversation(conversationId: conversation2.Id);
        #endregion
    }

    public Sample_conversation_CRUD(bool isAsync) : base(isAsync)
    { }
}
