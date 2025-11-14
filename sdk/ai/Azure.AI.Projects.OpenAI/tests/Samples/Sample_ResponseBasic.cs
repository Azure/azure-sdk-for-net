// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

public class Sample_ResponseBasic : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task AgentResponse()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_ResponseBasic
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateResponse_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);
        OpenAIResponse response = await responseClient.CreateResponseAsync("What is the size of France in square miles?");

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
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #region Snippet:Sample_CreateResponse_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);
        OpenAIResponse response = responseClient.CreateResponse("What is the size of France in square miles?");
        #endregion

        #region Snippet:Sample_WriteOutput_ResponseBasic_Sync
        Console.WriteLine(response.GetOutputText());
        #endregion
    }

    public Sample_ResponseBasic(bool isAsync) : base(isAsync)
    { }
}
