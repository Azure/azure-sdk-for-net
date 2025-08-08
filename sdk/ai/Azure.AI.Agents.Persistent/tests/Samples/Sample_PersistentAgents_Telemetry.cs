// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry;
using Azure.Monitor.OpenTelemetry.Exporter;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_Telemetry : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task TracingToConsoleExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
                        .AddSource("Azure.AI.Agents.Persistent.*") // Add the required sources name
                        .SetResourceBuilder(OpenTelemetry.Resources.ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
                        .AddConsoleExporter() // Export traces to the console
                        .Build();

        using (tracerProvider)
        {
            PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

            // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
            PersistentAgent agent = await client.Administration.CreateAgentAsync(
                model: modelDeploymentName,
                name: "Math Tutor",
                instructions: "You are a personal math tutor. Write and run code to answer math questions."
            );

            PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

            PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
                thread.Id,
                MessageRole.User,
                "I need to solve the equation `3x + 11 = 14`. Can you help me?");

            // Intermission: message is now correlated with thread
            // Intermission: listing messages will retrieve the message just added

            AsyncPageable<PersistentThreadMessage> messagesList = client.Messages.GetMessagesAsync(thread.Id);
            List<PersistentThreadMessage> messagesOne = await messagesList.ToListAsync();
            Assert.AreEqual(message.Id, messagesOne[0].Id);

            ThreadRun run = await client.Runs.CreateRunAsync(
                thread.Id,
                agent.Id,
                additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");

            do
            {
                await Task.Delay(TimeSpan.FromMilliseconds(500));
                run = await client.Runs.GetRunAsync(thread.Id, run.Id);
            }
            while (run.Status == RunStatus.Queued
                || run.Status == RunStatus.InProgress);
            Assert.AreEqual(
                RunStatus.Completed,
                run.Status,
                run.LastError?.Message);

            AsyncPageable<PersistentThreadMessage> messages
                = client.Messages.GetMessagesAsync(
                    threadId: thread.Id, order: ListSortOrder.Ascending);

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

            // NOTE: Comment out these two lines if you plan to reuse the agent later.
            await client.Threads.DeleteThreadAsync(threadId: thread.Id);
            await client.Administration.DeleteAgentAsync(agentId: agent.Id);
        }
    }

    [Test]
    [SyncOnly]
    public void TracingToConsoleExampleSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        #region Snippet:EnableActivitySourceToGetTraces
        AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);
        #endregion
        #region Snippet:DisableContentRecordingForTraces
        AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", false);
        #endregion
        #region Snippet:AgentsTelemetrySetupTracingToConsole
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
                        .AddSource("Azure.AI.Agents.Persistent.*") // Add the required sources name
                        .SetResourceBuilder(OpenTelemetry.Resources.ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
                        .AddConsoleExporter() // Export traces to the console
                        .Build();
        #endregion

        using (tracerProvider)
        {
            PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

            // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
            PersistentAgent agent = client.Administration.CreateAgent(
                model: modelDeploymentName,
                name: "Math Tutor",
                instructions: "You are a personal math tutor. Write and run code to answer math questions."
            );

            PersistentAgentThread thread = client.Threads.CreateThread();

            PersistentThreadMessage message = client.Messages.CreateMessage(
                thread.Id,
                MessageRole.User,
                "I need to solve the equation `3x + 11 = 14`. Can you help me?");

            // Intermission: message is now correlated with thread
            // Intermission: listing messages will retrieve the message just added

            List<PersistentThreadMessage> messagesList = [.. client.Messages.GetMessages(thread.Id)];
            Assert.AreEqual(message.Id, messagesList[0].Id);

            ThreadRun run = client.Runs.CreateRun(
                thread.Id,
                agent.Id,
                additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");

            do
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                run = client.Runs.GetRun(thread.Id, run.Id);
            }
            while (run.Status == RunStatus.Queued
                || run.Status == RunStatus.InProgress);
            Assert.AreEqual(
                RunStatus.Completed,
                run.Status,
                run.LastError?.Message);

            Pageable<PersistentThreadMessage> messages
                = client.Messages.GetMessages(
                    threadId: thread.Id, order: ListSortOrder.Ascending);

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

            // NOTE: Comment out these two lines if you plan to reuse the agent later.
            client.Threads.DeleteThread(threadId: thread.Id);
            client.Administration.DeleteAgent(agentId: agent.Id);
        }
    }

    [Test]
    [AsyncOnly]
    public async Task TracingToAzureMonitorExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("Azure.AI.Agents.Persistent.*")
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
            .AddAzureMonitorTraceExporter().Build();

        using (tracerProvider)
        {
            PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

            // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
            PersistentAgent agent = await client.Administration.CreateAgentAsync(
                model: modelDeploymentName,
                name: "Math Tutor",
                instructions: "You are a personal math tutor. Write and run code to answer math questions."
            );

            PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

            PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
                thread.Id,
                MessageRole.User,
                "I need to solve the equation `3x + 11 = 14`. Can you help me?");

            // Intermission: message is now correlated with thread
            // Intermission: listing messages will retrieve the message just added

            AsyncPageable<PersistentThreadMessage> messagesList = client.Messages.GetMessagesAsync(thread.Id);
            List<PersistentThreadMessage> messagesOne = await messagesList.ToListAsync();
            Assert.AreEqual(message.Id, messagesOne[0].Id);

            ThreadRun run = await client.Runs.CreateRunAsync(
                thread.Id,
                agent.Id,
                additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");

            do
            {
                await Task.Delay(TimeSpan.FromMilliseconds(500));
                run = await client.Runs.GetRunAsync(thread.Id, run.Id);
            }
            while (run.Status == RunStatus.Queued
                || run.Status == RunStatus.InProgress);
            Assert.AreEqual(
                RunStatus.Completed,
                run.Status,
                run.LastError?.Message);

            AsyncPageable<PersistentThreadMessage> messages
                = client.Messages.GetMessagesAsync(
                    threadId: thread.Id, order: ListSortOrder.Ascending);

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

            // NOTE: Comment out these two lines if you plan to reuse the agent later.
            await client.Threads.DeleteThreadAsync(threadId: thread.Id);
            await client.Administration.DeleteAgentAsync(agentId: agent.Id);
        }
    }

    [Test]
    [SyncOnly]
    public void TracingToAzureMonitorExampleSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        #region Snippet:AgentsTelemetrySetupTracingToAzureMonitor
        var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("Azure.AI.Agents.Persistent.*")
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
            .AddAzureMonitorTraceExporter().Build();
        #endregion

        using (tracerProvider)
        {
            PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

            // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
            PersistentAgent agent = client.Administration.CreateAgent(
                model: modelDeploymentName,
                name: "Math Tutor",
                instructions: "You are a personal math tutor. Write and run code to answer math questions."
            );

            PersistentAgentThread thread = client.Threads.CreateThread();

            PersistentThreadMessage message = client.Messages.CreateMessage(
                thread.Id,
                MessageRole.User,
                "I need to solve the equation `3x + 11 = 14`. Can you help me?");

            // Intermission: message is now correlated with thread
            // Intermission: listing messages will retrieve the message just added

            List<PersistentThreadMessage> messagesList = [.. client.Messages.GetMessages(thread.Id)];
            Assert.AreEqual(message.Id, messagesList[0].Id);

            ThreadRun run = client.Runs.CreateRun(
                thread.Id,
                agent.Id,
                additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");

            do
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                run = client.Runs.GetRun(thread.Id, run.Id);
            }
            while (run.Status == RunStatus.Queued
                || run.Status == RunStatus.InProgress);
            Assert.AreEqual(
                RunStatus.Completed,
                run.Status,
                run.LastError?.Message);

            Pageable<PersistentThreadMessage> messages
                = client.Messages.GetMessages(
                    threadId: thread.Id, order: ListSortOrder.Ascending);

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
            // NOTE: Comment out these two lines if you plan to reuse the agent later.
            client.Threads.DeleteThread(threadId: thread.Id);
            client.Administration.DeleteAgent(agentId: agent.Id);
        }
    }
}
