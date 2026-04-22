// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

public class Sample_ResponseBasic : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task AgentResponse()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_ResponseBasic
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateResponse_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForModel(modelDeploymentName);
        ResponseResult response = await responseClient.CreateResponseAsync("What is the size of France in square miles?");

        #endregion

        #region Snippet:Sample_WriteOutput_ResponseBasic_Async
        Console.WriteLine(response.GetOutputText());
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AgentResponseSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #region Snippet:Sample_CreateResponse_Sync
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForModel(modelDeploymentName);
        ResponseResult response = responseClient.CreateResponse("What is the size of France in square miles?");
        #endregion

        #region Snippet:Sample_WriteOutput_ResponseBasic_Sync
        Console.WriteLine(response.GetOutputText());
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task ListResponses()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var agentName = System.Environment.GetEnvironmentVariable("FOUNDRY_AGENT_NAME");
        var conversationId = System.Environment.GetEnvironmentVariable("KNOWN_CONVERSATION_ID");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var agentName = TestEnvironment.FOUNDRY_AGENT_NAME;
        string conversationId = TestEnvironment.KNOWN_CONVERSATION_ID;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_ListResponses_Async
        await foreach (ResponseResult response
            in projectClient.ProjectOpenAIClient.GetProjectResponsesClient().GetProjectResponsesAsync(agent: new AgentReference(agentName), conversationId: conversationId))
        {
            Console.WriteLine($"Matching response: {response.Id}");
        }
        #endregion
    }
    public Sample_ResponseBasic(bool isAsync) : base(isAsync)
    { }
}
