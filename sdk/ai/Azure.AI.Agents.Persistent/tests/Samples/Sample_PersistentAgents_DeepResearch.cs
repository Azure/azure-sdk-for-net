// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_DeepResearch : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task DeepResearchExample()
    {
        #region Snippet:DeepResearch_CreateClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var deepResearchModelDeploymentName = System.Environment.GetEnvironmentVariable("DEEP_RESEARCH_MODEL_DEPLOYMENT_NAME");
        var connectionId = System.Environment.GetEnvironmentVariable("AZURE_BING_CONECTION_ID");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var deepResearchModelDeploymentName = TestEnvironment.DEEP_RESEARCH_MODEL_DEPLOYMENT_NAME;
        var connectionId = TestEnvironment.BING_CONNECTION_ID;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #endregion

        #region Snippet:DeepResearch_CreateTools
        DeepResearchToolDefinition deepResearch = new(
            new DeepResearchDetails(
                model: deepResearchModelDeploymentName,
                bingGroundingConnections: [
                    new DeepResearchBingGroundingConnection(connectionId)
                ]
            )
        );
        #endregion

        // Step 1: Create an agent
        #region Snippet:DeepResearch_CreateAgent
        // NOTE: To reuse existing agent, fetch it with get_agent(agent_id)
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "Science Tutor",
            instructions: "You are a helpful Agent that assists in researching scientific topics.",
            tools: [deepResearch]
        );
        #endregion

        // Step 2: Create a thread and run.
        #region Snippet:DeepResearch_CreateThreadAndRun
        PersistentAgentThreadCreationOptions threadOp = new();
        threadOp.Messages.Add(new ThreadMessageOptions(
                role: MessageRole.User,
                content: "Research the current state of studies on orca intelligence and orca language, " +
                "including what is currently known about orcas' cognitive capabilities, " +
                "communication systems and problem-solving reflected in recent publications in top thier scientific " +
                "journals like Science, Nature and PNAS."
            ));
        ThreadAndRunOptions opts = new()
        {
            ThreadOptions = threadOp,
        };
        ThreadRun run = await client.CreateThreadAndRunAsync(
            assistantId: agent.Id,
            options: opts
        );

        Console.WriteLine("Start processing the message... this may take a few minutes to finish. Be patient!");
        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await client.Runs.GetRunAsync(run.ThreadId, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:DeepResearch_ListMessages
        AsyncPageable<PersistentThreadMessage> messages
            = client.Messages.GetMessagesAsync(
                threadId: run.ThreadId, order: ListSortOrder.Ascending);

        PrintMessagesAndSaveSummary(await messages.ToListAsync(), "research_summary.md");
        #endregion
        #region Snippet:DeepResearch_Cleanup
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        await client.Threads.DeleteThreadAsync(threadId: run.ThreadId);
        await client.Administration.DeleteAgentAsync(agentId: agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void DeepResearchExampleSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var deepResearchModelDeploymentName = System.Environment.GetEnvironmentVariable("DEEP_RESEARCH_MODEL_DEPLOYMENT_NAME");
        var connectionId = System.Environment.GetEnvironmentVariable("AZURE_BING_CONNECTION_ID");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var deepResearchModelDeploymentName = TestEnvironment.DEEP_RESEARCH_MODEL_DEPLOYMENT_NAME;
        var connectionId = TestEnvironment.BING_CONNECTION_ID;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

        DeepResearchToolDefinition deepResearch = new(
            new DeepResearchDetails(
                model: deepResearchModelDeploymentName,
                bingGroundingConnections: [
                    new DeepResearchBingGroundingConnection(connectionId)
                ]
            )
        );

        // Step 1: Create an agent
        #region Snippet:DeepResearchSync_CreateAgent
        // NOTE: To reuse existing agent, fetch it with get_agent(agent_id)
        PersistentAgent agent = client.Administration.CreateAgent(
            model: modelDeploymentName,
            name: "Science Tutor",
            instructions: "You are a helpful Agent that assists in researching scientific topics.",
            tools: [deepResearch]
        );
        #endregion

        // Step 2: Create a thread and run.
        #region Snippet:DeepResearchSync_CreateThreadAndRun
        PersistentAgentThreadCreationOptions threadOp = new();
        threadOp.Messages.Add(new ThreadMessageOptions(
                role: MessageRole.User,
                content: "Research the current state of studies on orca intelligence and orca language, " +
                "including what is currently known about orcas' cognitive capabilities, " +
                "communication systems and problem-solving reflected in recent publications in top thier scientific " +
                "journals like Science, Nature and PNAS."
            ));
        ThreadAndRunOptions opts = new()
        {
            ThreadOptions = threadOp,
        };
        ThreadRun run = client.CreateThreadAndRun(
            assistantId: agent.Id,
            options: opts
        );

        Console.WriteLine("Start processing the message... this may take a few minutes to finish. Be patient!");
        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = client.Runs.GetRun(run.ThreadId, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:DeepResearchSync_ListMessages
        Pageable<PersistentThreadMessage> messages
            = client.Messages.GetMessages(
                threadId: run.ThreadId, order: ListSortOrder.Ascending);
        PrintMessagesAndSaveSummary([..messages], "research_summary.md");
        #endregion

        #region Snippet:DeepResearchSync_Cleanup
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        client.Threads.DeleteThread(threadId: run.ThreadId);
        client.Administration.DeleteAgent(agentId: agent.Id);
        #endregion
    }

    #region Snippet:DeepResearch_PrintMessages
    private static void PrintMessagesAndSaveSummary(IEnumerable<PersistentThreadMessage> messages, string summaryFilePath)
    {
        string lastAgentMessage = default;
        foreach (PersistentThreadMessage threadMessage in messages)
        {
            StringBuilder sbAgentMessage = new();
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
                    if (threadMessage.Role == MessageRole.Agent)
                        sbAgentMessage.Append(response);
                    Console.Write($"Agent response: {response}");
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
            if (threadMessage.Role == MessageRole.Agent)
                lastAgentMessage = sbAgentMessage.ToString();
        }
        if (!string.IsNullOrEmpty(lastAgentMessage))
        {
            File.WriteAllText(
                path: summaryFilePath,
                contents: lastAgentMessage);
        }
    }
    #endregion
}
