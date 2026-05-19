// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Extensions.OpenAI;
using Azure.AI.Projects;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

public class Sample_conversation_CRUD : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task ConversationCRUDAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_ConversationCRUD
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateConversations_ConversationCRUD_Async
        ProjectConversation conversation1 = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationAsync();
        Console.WriteLine($"Created conversation (id: {conversation1.Id})");

        ProjectConversation conversation2 = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationAsync();
        Console.WriteLine($"Created conversation (id: {conversation2.Id})");
        #endregion

        #region Snippet:Sample_GetConversation_ConversationCRUD_Async
        ProjectConversation conversation = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().GetProjectConversationAsync(conversationId: conversation1.Id);
        Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
        #endregion

        #region Snippet:Sample_ListConversations_ConversationCRUD_Async
        await foreach (ProjectConversation res in projectClient.ProjectOpenAIClient.GetProjectConversationsClient().GetProjectConversationsAsync())
        {
            Console.WriteLine($"Listed conversation (id: {res.Id})");
        }
        #endregion

        #region Snippet:Sample_UpdateConversations_ConversationCRUD_Async
        ProjectConversationUpdateOptions updateOptions = new()
        {
            Metadata = { ["key"] = "value" },
        };
        await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().UpdateProjectConversationAsync(conversation.Id, updateOptions);

        // Get the updated conversation.
        conversation = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().GetProjectConversationAsync(conversation1.Id);
        Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
        #endregion

        #region Snippet:Sample_DeleteConversations_ConversationCRUD_Async
        await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().DeleteConversationAsync(conversationId: conversation1.Id);
        await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().DeleteConversationAsync(conversationId: conversation2.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void ConversationCRUDSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateConversations_ConversationCRUD_Sync
        ProjectConversation conversation1 = projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversation();
        Console.WriteLine($"Created conversation (id: {conversation1.Id})");

        ProjectConversation conversation2 = projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversation();
        Console.WriteLine($"Created conversation (id: {conversation2.Id})");
        #endregion

        #region Snippet:Sample_GetConversation_ConversationCRUD_Sync
        ProjectConversation conversation = projectClient.ProjectOpenAIClient.GetProjectConversationsClient().GetProjectConversation(conversationId: conversation1.Id);
        Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
        #endregion

        #region Snippet:Sample_ListConversations_ConversationCRUD_Sync
        foreach (ProjectConversation res in projectClient.ProjectOpenAIClient.GetProjectConversationsClient().GetProjectConversations())
        {
            Console.WriteLine($"Listed conversation (id: {res.Id})");
        }
        #endregion

        #region Snippet:Sample_UpdateConversations_ConversationCRUD_Sync
        ProjectConversationUpdateOptions updateOptions = new()
        {
            Metadata = { ["key"] = "value" },
        };
        projectClient.ProjectOpenAIClient.GetProjectConversationsClient().UpdateProjectConversation(conversation1.Id, updateOptions);

        // Get the updated conversation.
        conversation = projectClient.ProjectOpenAIClient.GetProjectConversationsClient().GetProjectConversation(conversationId: conversation1.Id);
        Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
        #endregion

        #region Snippet:Sample_DeleteConversations_ConversationCRUD_Sync
        projectClient.ProjectOpenAIClient.GetProjectConversationsClient().DeleteConversation(conversationId: conversation1.Id);
        projectClient.ProjectOpenAIClient.GetProjectConversationsClient().DeleteConversation(conversationId: conversation2.Id);
        #endregion
    }

    public Sample_conversation_CRUD(bool isAsync) : base(isAsync)
    { }
}
