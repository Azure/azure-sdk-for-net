// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_Bing_Custom_Search : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task BingCustomSearchExampleAsync()
    {
        #region Snippet:AgentsBingCustomSearch_CreateProject
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var connectionId = System.Environment.GetEnvironmentVariable("BING_CUSTOM_CONNECTION_ID");
        var configurationName = System.Environment.GetEnvironmentVariable("BING_CONFIGURATION_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var connectionId = TestEnvironment.BING_CUSTOM_CONNECTION_ID;
        var configurationName = TestEnvironment.BING_CONFIGURATION_NAME;
#endif
        PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
        #endregion
        #region Snippet:AgentsBingCustomSearch_GetConnection
        BingCustomSearchToolDefinition bingCustomSearchTool = new(
            new BingCustomSearchToolParameters(connectionId, configurationName) // Replace with your actual configuration instance name
        );
        #endregion
        #region Snippet:AgentsBingCustomSearchAsync_CreateAgent
        // NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
        PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
           model: modelDeploymentName,
           name: "my-agent",
           instructions: "You are a helpful agent.",
           tools: [ bingCustomSearchTool ]);
        #endregion
        // Create thread for communication
        #region Snippet:AgentsBingCustomSearchAsync_CreateThreadMessage
        PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();

        // Create message to thread
        PersistentThreadMessage message = await agentClient.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "How many medals did the USA win in the 2024 summer olympics?");

        // Run the agent
        ThreadRun run = await agentClient.Runs.CreateRunAsync(thread, agent);
        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await agentClient.Runs.GetRunAsync(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);

        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:AgentsBingCustomSearchAsync_Print
        AsyncPageable<PersistentThreadMessage> messages = agentClient.Messages.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );

        await foreach (PersistentThreadMessage threadMessage in messages)
        {
            Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            foreach (MessageContent contentItem in threadMessage.ContentItems)
            {
                if (contentItem is MessageTextContent textItem)
                {
                    string response = textItem.Text;
                    if (textItem.Annotations != null)
                    {
                        foreach (MessageTextAnnotation annotation in textItem.Annotations)
                        {
                            if (annotation is MessageTextUriCitationAnnotation uriAnnotation)
                            {
                                response = response.Replace(uriAnnotation.Text, $" [{uriAnnotation.UriCitation.Title}]({uriAnnotation.UriCitation.Uri})");
                            }
                        }
                    }
                    Console.Write($"Agent response: {response}");
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}>");
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region Snippet:AgentsBingCustomSearchCleanupAsync
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        await agentClient.Threads.DeleteThreadAsync(threadId: thread.Id);
        await agentClient.Administration.DeleteAgentAsync(agentId: agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void BingCustomSearchExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var connectionId = System.Environment.GetEnvironmentVariable("BING_CUSTOM_CONNECTION_ID");
        var configurationName = System.Environment.GetEnvironmentVariable("BING_CONFIGURATION_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var connectionId = TestEnvironment.BING_CUSTOM_CONNECTION_ID;
        var configurationName = TestEnvironment.BING_CONFIGURATION_NAME;
#endif
        PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
        BingCustomSearchToolDefinition bingCustomSearchTool = new(
            new BingCustomSearchToolParameters(connectionId, configurationName) // Replace with your actual configuration instance name
        );
        #region Snippet:AgentsBingCustomSearch_CreateAgent
        // NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
        PersistentAgent agent = agentClient.Administration.CreateAgent(
           model: modelDeploymentName,
           name: "my-agent",
           instructions: "You are a helpful agent.",
           tools: [bingCustomSearchTool]);
        #endregion
        // Create thread for communication
        #region Snippet:AgentsBingCustomSearch_CreateThreadMessage
        PersistentAgentThread thread = agentClient.Threads.CreateThread();

        // Create message to thread
        PersistentThreadMessage message = agentClient.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "How many medals did the USA win in the 2024 summer olympics?");

        // Run the agent
        ThreadRun run = agentClient.Runs.CreateRun(thread, agent);
        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = agentClient.Runs.GetRun(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);

        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:AgentsBingCustomSearch_Print
        Pageable<PersistentThreadMessage> messages = agentClient.Messages.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );

        foreach (PersistentThreadMessage threadMessage in messages)
        {
            Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            foreach (MessageContent contentItem in threadMessage.ContentItems)
            {
                if (contentItem is MessageTextContent textItem)
                {
                    string response = textItem.Text;
                    if (textItem.Annotations != null)
                    {
                        foreach (MessageTextAnnotation annotation in textItem.Annotations)
                        {
                            if (annotation is MessageTextUriCitationAnnotation uriAnnotation)
                            {
                                response = response.Replace(uriAnnotation.Text, $" [{uriAnnotation.UriCitation.Title}]({uriAnnotation.UriCitation.Uri})");
                            }
                        }
                    }
                    Console.Write($"Agent response: {response}");
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}>");
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region Snippet:AgentsBingCustomSearchCleanup
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        agentClient.Threads.DeleteThread(threadId: thread.Id);
        agentClient.Administration.DeleteAgent(agentId: agent.Id);
        #endregion
    }
}
