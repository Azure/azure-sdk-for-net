// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

[Ignore("Samples represented as tests only for validation of compilation.")]
public class Sample_ResponseBasic : AgentsTestBase
{
    [Test]
    [AsyncOnly]
    public async Task AgentResponse()
    {
        #region Snippet:Sample_CreateAgentClient_ResponseBasic
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateResponse_Async
        OpenAIClient openAIClient = client.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
        OpenAIResponse response = await responseClient.CreateResponseAsync("What is the size of France in square miles?");

        #endregion

        #region Snippet:Sample_WriteOutput_ResponseBasic_Async
        while (response.Status != ResponseStatus.Incomplete || response.Status != ResponseStatus.Failed || response.Status != ResponseStatus.Completed)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            response = await responseClient.GetResponseAsync(responseId: response.Id);
        }

        Console.WriteLine(response.GetOutputText());
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AgentResponseSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #region Snippet:Sample_CreateResponse_Sync
        OpenAIClient openAIClient = client.GetOpenAIClient();
        OpenAIResponseClient responsesClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);

        OpenAIResponse response = responsesClient.CreateResponse("What is the size of France in square miles?");
        #endregion

        #region Snippet:Sample_WriteOutput_ResponseBasic_Sync
        while (response.Status != ResponseStatus.Incomplete || response.Status != ResponseStatus.Failed || response.Status != ResponseStatus.Completed)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            response = responsesClient.GetResponse(responseId: response.Id);
        }

        Console.WriteLine(response.GetOutputText());
        #endregion
    }

    public Sample_ResponseBasic(bool isAsync) : base(isAsync)
    { }
}
