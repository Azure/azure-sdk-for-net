// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.IO;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Http.Internal;
using System.Text.Json;
using Azure.Core.Diagnostics;
using Azure.AI.Agents.Persistent;
using System.Linq;

namespace Azure.AI.Projects.Tests;
public class Sample_Agent_Evaluations : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [SyncOnly]
    public void AgentEvaluationsExampleSync()
    {
        #region Snippet:AI_Projects_AgentEvaluationsExampleSync
#if SNIPPET
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif

        var projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

        Console.WriteLine("Create an agent");
        PersistentAgentsClient agentsClient = projectClient.GetPersistentAgentsClient();
        PersistentAgent agent = agentsClient.Administration.CreateAgent(
            model: modelDeploymentName,
            name: "My Agent",
            instructions: "You are helpful agent."
        );
        Console.WriteLine($"Created agent, agent ID: {agent.Id}");

        Console.WriteLine("Create a thread for the agent");
        PersistentAgentThread thread = agentsClient.Threads.CreateThread();
        Console.WriteLine($"Created thread, thread ID: {thread.Id}");

        Console.WriteLine("Add a message to the thread");
        PersistentThreadMessage message = agentsClient.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "Hello, tell me a joke."
        );
        Console.WriteLine($"Added message, message ID: {message.Id}");

        Console.WriteLine("Run the agent on the thread");
        ThreadRun run = agentsClient.Runs.CreateRun(
            thread.Id,
            agent.Id
        );
        Console.WriteLine($"Created run, run ID: {run.Id}");

        Console.WriteLine("Wait for the run to complete");
        while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress || run.Status == RunStatus.RequiresAction)
        {
            System.Threading.Thread.Sleep(1);
            run = agentsClient.Runs.GetRun(thread.Id, run.Id);
            Console.WriteLine($"Run status: {run.Status}");
        }

        Console.WriteLine("Create the agent evaluation");
        AgentEvaluationRequest evaluationRequest = new AgentEvaluationRequest(
            runId: run.Id,
            evaluators: new Dictionary<string, EvaluatorConfiguration>
            {
                {
                    "violence", new EvaluatorConfiguration(
                        id: EvaluatorIDs.Violence
                    )
                },
                {
                    "hate_unfairness", new EvaluatorConfiguration(
                        id: EvaluatorIDs.HateUnfairness
                    )
                },
                {
                    "relevance", new EvaluatorConfiguration(
                        id: EvaluatorIDs.Relevance
                    )
                }
            },
            appInsightsConnectionString: projectClient.Telemetry.GetConnectionString()
        )
        {
            ThreadId = thread.Id,
            SamplingConfiguration = new AgentEvaluationSamplingConfiguration(name: "test", samplingPercent: 100, maxRequestRate: 100),
            RedactionConfiguration = new AgentEvaluationRedactionConfiguration()
            {
                RedactScoreProperties = false
            }
        };

        AgentEvaluation agentEvaluation = projectClient.GetEvaluationsClient().CreateAgentEvaluation(evaluationRequest);
        Console.WriteLine($"Created agent evaluation: {agentEvaluation}");

        Console.WriteLine("Delete thread and agent");
        agentsClient.Threads.DeleteThread(thread.Id);
        agentsClient.Administration.DeleteAgent(agent.Id);
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task AgentEvaluationsExampleAsync()
    {
        #region Snippet:AI_Projects_AgentEvaluationsExampleAsync
#if SNIPPET
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif

        var projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

        Console.WriteLine("Create an agent");
        PersistentAgentsClient agentsClient = projectClient.GetPersistentAgentsClient();
        PersistentAgent agent = await agentsClient.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "My Agent",
            instructions: "You are helpful agent."
        );
        Console.WriteLine($"Created agent, agent ID: {agent.Id}");

        Console.WriteLine("Create a thread for the agent");
        PersistentAgentThread thread = await agentsClient.Threads.CreateThreadAsync();
        Console.WriteLine($"Created thread, thread ID: {thread.Id}");

        Console.WriteLine("Add a message to the thread");
        PersistentThreadMessage message = await agentsClient.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "Hello, tell me a joke."
        );
        Console.WriteLine($"Added message, message ID: {message.Id}");

        Console.WriteLine("Run the agent on the thread");
        ThreadRun run = await agentsClient.Runs.CreateRunAsync(
            thread.Id,
            agent.Id
        );
        Console.WriteLine($"Created run, run ID: {run.Id}");

        Console.WriteLine("Wait for the run to complete");
        while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress || run.Status == RunStatus.RequiresAction)
        {
            System.Threading.Thread.Sleep(1);
            run = agentsClient.Runs.GetRun(thread.Id, run.Id);
            Console.WriteLine($"Run status: {run.Status}");
        }

        Console.WriteLine("Create the agent evaluation");
        AgentEvaluationRequest evaluationRequest = new AgentEvaluationRequest(
            runId: run.Id,
            evaluators: new Dictionary<string, EvaluatorConfiguration>
            {
                {
                    "violence", new EvaluatorConfiguration(
                        id: EvaluatorIDs.Violence
                    )
                },
                {
                    "hate_unfairness", new EvaluatorConfiguration(
                        id: EvaluatorIDs.HateUnfairness
                    )
                },
                {
                    "relevance", new EvaluatorConfiguration(
                        id: EvaluatorIDs.Relevance
                    )
                }
            },
            appInsightsConnectionString: projectClient.Telemetry.GetConnectionString()
        )
        {
            ThreadId = thread.Id,
            SamplingConfiguration = new AgentEvaluationSamplingConfiguration(name: "test", samplingPercent: 100, maxRequestRate: 100),
            RedactionConfiguration = new AgentEvaluationRedactionConfiguration()
            {
                RedactScoreProperties = false
            }
        };

        AgentEvaluation agentEvaluation = await projectClient.GetEvaluationsClient().CreateAgentEvaluationAsync(evaluationRequest);
        Console.WriteLine($"Created agent evaluation: {agentEvaluation}");

        Console.WriteLine("Delete thread and agent");
        await agentsClient.Threads.DeleteThreadAsync(thread.Id);
        await agentsClient.Administration.DeleteAgentAsync(agent.Id);
        #endregion
    }
}
