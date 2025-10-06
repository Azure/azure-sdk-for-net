// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_Connected_Agent : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task ConnectedAgentExampleAsync()
    {
        #region Snippet:AgentsConnectedAgent_CreateProject
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
        #endregion
        // Create a sub-agent first
        #region Snippet:AgentsConnectedAgentAsync_CreateSubAgent
        // NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
        PersistentAgent subAgent = await agentClient.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "math-helper",
            instructions: "You are a helpful assistant specialized in mathematics. Solve mathematical problems step by step and provide clear explanations.");
        #endregion
        #region Snippet:AgentsConnectedAgent_GetConnectedAgent
        ConnectedAgentToolDefinition connectedAgentTool = new(
            new ConnectedAgentDetails(
                id: subAgent.Id,
                name: "MathHelper",
                description: "A specialized mathematics assistant that can solve complex mathematical problems and provide step-by-step explanations."
            )
        );
        #endregion
        #region Snippet:AgentsConnectedAgentAsync_CreateAgent
        // NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
        PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
           model: modelDeploymentName,
           name: "main-agent",
           instructions: "You are a helpful assistant. When users ask mathematical questions, use the MathHelper tool to get specialized mathematical assistance.",
           tools: [ connectedAgentTool ]);
        #endregion
        // Create thread for communication
        #region Snippet:AgentsConnectedAgentAsync_CreateThreadMessage
        PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();

        // Create message to thread
        PersistentThreadMessage message = await agentClient.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the derivative of x^3 + 2x^2 - 5x + 7? Please explain step by step.");

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

        #region Snippet:AgentsConnectedAgentAsync_Print
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
                    Console.Write(textItem.Text);
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region Snippet:AgentsConnectedAgentCleanupAsync
        // NOTE: Comment out these three lines if you plan to reuse the agent later.
        await agentClient.Threads.DeleteThreadAsync(threadId: thread.Id);
        await agentClient.Administration.DeleteAgentAsync(agentId: agent.Id);
        await agentClient.Administration.DeleteAgentAsync(agentId: subAgent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void ConnectedAgentExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
        // Create a sub-agent first
        #region Snippet:AgentsConnectedAgent_CreateSubAgent
        // NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
        PersistentAgent subAgent = agentClient.Administration.CreateAgent(
            model: modelDeploymentName,
            name: "math-helper",
            instructions: "You are a helpful assistant specialized in mathematics. Solve mathematical problems step by step and provide clear explanations.");
        #endregion
        ConnectedAgentToolDefinition connectedAgentTool = new(
            new ConnectedAgentDetails(
                id: subAgent.Id,
                name: "MathHelper",
                description: "A specialized mathematics assistant that can solve complex mathematical problems and provide step-by-step explanations."
            )
        );
        #region Snippet:AgentsConnectedAgent_CreateAgent
        // NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
        PersistentAgent agent = agentClient.Administration.CreateAgent(
           model: modelDeploymentName,
           name: "main-agent",
           instructions: "You are a helpful assistant. When users ask mathematical questions, use the MathHelper tool to get specialized mathematical assistance.",
           tools: [connectedAgentTool]);
        #endregion
        // Create thread for communication
        #region Snippet:AgentsConnectedAgent_CreateThreadMessage
        PersistentAgentThread thread = agentClient.Threads.CreateThread();

        // Create message to thread
        PersistentThreadMessage message = agentClient.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What is the derivative of x^3 + 2x^2 - 5x + 7? Please explain step by step.");

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

        #region Snippet:AgentsConnectedAgent_Print
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
                    Console.Write(textItem.Text);
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region Snippet:AgentsConnectedAgentCleanup
        // NOTE: Comment out these three lines if you plan to reuse the agent later.
        agentClient.Threads.DeleteThread(threadId: thread.Id);
        agentClient.Administration.DeleteAgent(agentId: agent.Id);
        agentClient.Administration.DeleteAgent(agentId: subAgent.Id);
        #endregion
    }
}
