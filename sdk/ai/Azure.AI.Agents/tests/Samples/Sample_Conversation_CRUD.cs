// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Tests.Samples;

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
        AgentsClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateConversations_ConversationCRUD_Async
        ConversationClient conversationClient = client.GetConversationClient();
        AgentConversation conversation1 = await conversationClient.CreateConversationAsync();
        Console.WriteLine($"Created conversation (id: {conversation1.Id})");

        AgentConversation conversation2 = await conversationClient.CreateConversationAsync();
        Console.WriteLine($"Created conversation (id: {conversation2.Id})");
        #endregion

        #region Snippet:Sample_GetConversation_ConversationCRUD_Async
        AgentConversation conversation = await conversationClient.GetConversationAsync(conversationId: conversation1.Id);
        Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
        #endregion

        #region Snippet:Sample_ListConversations_ConversationCRUD_Async
        await foreach (AgentConversation res in conversationClient.GetConversationsAsync()){
            Console.WriteLine($"Listed conversation (id: {res.Id})");
        }
        #endregion

        #region Snippet:Sample_UpdateConversations_ConversationCRUD_Async
        AgentConversationUpdateOptions updateOptions = new()
        {
            Metadata = { ["key"] = "value" },
        };
        await conversationClient.UpdateConversationAsync(conversation.Id, updateOptions);

        // Get the updated conversation.
        conversation = await conversationClient.GetConversationAsync(conversation1.Id);
        Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
        #endregion

        #region Snippet:Sample_DeleteConversations_ConversationCRUD_Async
        AgentConversationDeletionResult result = await conversationClient.DeleteConversationAsync(conversationId: conversation1.Id);
        Console.WriteLine($"Conversation deleted(id: {result.Id}, deleted:{result.Deleted})");
        result = await conversationClient.DeleteConversationAsync(conversationId: conversation2.Id);
        Console.WriteLine($"Conversation deleted(id: {result.Id}, deleted:{result.Deleted})");
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
        AgentsClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateConversations_ConversationCRUD_Sync
        ConversationClient conversationClient = client.GetConversationClient();
        AgentConversation conversation1 = conversationClient.CreateConversation();
        Console.WriteLine($"Created conversation (id: {conversation1.Id})");

        AgentConversation conversation2 = conversationClient.CreateConversation();
        Console.WriteLine($"Created conversation (id: {conversation2.Id})");
        #endregion

        #region Snippet:Sample_GetConversation_ConversationCRUD_Sync
        AgentConversation conversation = conversationClient.GetConversation(conversationId: conversation1.Id);
        Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
        #endregion

        #region Snippet:Sample_ListConversations_ConversationCRUD_Sync
        foreach (AgentConversation res in conversationClient.GetConversations())
        {
            Console.WriteLine($"Listed conversation (id: {res.Id})");
        }
        #endregion

        #region Snippet:Sample_UpdateConversations_ConversationCRUD_Sync
        AgentConversationUpdateOptions updateOptions = new()
        {
            Metadata = { ["key"] = "value" },
        };
        conversationClient.UpdateConversation(conversation1.Id, updateOptions);

        // Get the updated conversation.
        conversation = conversationClient.GetConversation(conversationId: conversation1.Id);
        Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
        #endregion

        #region Snippet:Sample_DeleteConversations_ConversationCRUD_Sync
        AgentConversationDeletionResult result = conversationClient.DeleteConversation(conversationId: conversation1.Id);
        Console.WriteLine($"Conversation deleted(id: {result.Id}, deleted:{result.Deleted})");
        result = conversationClient.DeleteConversation(conversationId: conversation2.Id);
        Console.WriteLine($"Conversation deleted(id: {result.Id}, deleted:{result.Deleted})");
        #endregion
    }

    public Sample_conversation_CRUD(bool isAsync) : base(isAsync)
    { }
}
