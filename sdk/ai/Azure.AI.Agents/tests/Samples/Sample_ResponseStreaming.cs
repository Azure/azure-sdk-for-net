// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Agents.Tests.Samples;

public class Sample_ResponseStreaming : AgentsTestBase
{
    [Test]
    [AsyncOnly]
    public async Task AgentResponseSteaming()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_ResponseStreaming
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateResponseStreaming
        OpenAIClient openAIClient = client.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
        #endregion

        #region Snippet:Sample_WriteOutput_ResponseStreaming_Async
        await foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreamingAsync("What is the size of France in square miles?"))
        {
            if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
            {
                Console.WriteLine($"Stream response created with ID: {createUpdate.Response.Id}");
            }
            else if (streamResponse is StreamingResponseOutputTextDeltaUpdate textDelta)
            {
                Console.WriteLine($"Delta: {textDelta.Delta}");
            }
            else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
            {
                Console.WriteLine($"Response done with full message: {textDoneUpdate.Text}");
            }
            else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
            {
                throw new InvalidOperationException($"The stream has failed with the error: {errorUpdate.Message}");
            }
        }
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AgentResponseStreamingSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        OpenAIClient openAIClient = client.GetOpenAIClient();
        OpenAIResponseClient responsesClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);

        #region Snippet:Sample_WriteOutput_ResponseStreaming_Sync
        foreach (StreamingResponseUpdate streamResponse in responsesClient.CreateResponseStreaming("What is the size of France in square miles?"))
        {
            if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
            {
                Console.WriteLine($"Stream response created with ID: {createUpdate.Response.Id}");
            }
            else if (streamResponse is StreamingResponseOutputTextDeltaUpdate textDelta)
            {
                Console.WriteLine($"Delta: {textDelta.Delta}");
            }
            else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
            {
                Console.WriteLine($"Response done with full message: {textDoneUpdate.Text}");
            }
            else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
            {
                throw new InvalidOperationException($"The stream has failed with the error: {errorUpdate.Message}");
            }
        }
        #endregion
    }

    public Sample_ResponseStreaming(bool isAsync) : base(isAsync)
    { }
}
