// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Inference;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class Sample_AIInference : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [SyncOnly]
    public void InferenceChatCompletion()
    {
        #region Snippet:ExtensionsChatClientSync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient client = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ChatCompletionsClient chatClient = client.GetChatCompletionsClient();

        var requestOptions = new ChatCompletionsOptions()
        {
            Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
            Model = modelDeploymentName
        };
        Response<ChatCompletions> response = chatClient.Complete(requestOptions);
        Console.WriteLine(response.Value.Content);
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task InferenceChatCompletionAsync()
    {
        #region Snippet:ExtensionsChatClientAsync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient client = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ChatCompletionsClient chatClient = client.GetChatCompletionsClient();

        var requestOptions = new ChatCompletionsOptions()
        {
            Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
            Model = modelDeploymentName
        };
        Response<ChatCompletions> response = await chatClient.CompleteAsync(requestOptions);
        Console.WriteLine(response.Value.Content);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void InferenceEmbedding()
    {
        #region Snippet:ExtensionsEmbeddingSync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient client = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        EmbeddingsClient embeddingsClient = client.GetEmbeddingsClient();

        var input = new List<string> { "first phrase", "second phrase", "third phrase" };
        var requestOptions = new EmbeddingsOptions(input)
        {
            Model = modelDeploymentName
        };

        Response<EmbeddingsResult> response = embeddingsClient.Embed(requestOptions);
        foreach (EmbeddingItem item in response.Value.Data)
        {
            List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
            Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
        }
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task InferenceEmbeddingAsync()
    {
        #region Snippet:ExtensionsEmbeddingAsync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient client = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        EmbeddingsClient embeddingsClient = client.GetEmbeddingsClient();

        var input = new List<string> { "first phrase", "second phrase", "third phrase" };
        var requestOptions = new EmbeddingsOptions(input)
        {
            Model = modelDeploymentName
        };

        Response<EmbeddingsResult> response = await embeddingsClient.EmbedAsync(requestOptions);
        foreach (EmbeddingItem item in response.Value.Data)
        {
            List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
            Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
        }
        #endregion
    }

    // [Test]
    // public void ThrowsWhenNoConnection()
    // {
    //     var endpoint = TestEnvironment.PROJECTENDPOINT;
    //     var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
    //     AIProjectClient client = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

    //     var ex = Assert.Throws<InvalidOperationException>(() =>
    //     {
    //         ChatCompletionsClient chatClient = client.GetChatCompletionsClient();
    //     });

    //     Assert.AreEqual(
    //         $"No connections found for '{ConnectionType.Serverless}'. At least one connection is required. Please add a new connection in the Azure AI Foundry portal by following the instructions here: https://aka.ms/azsdk/azure-ai-projects/how-to/connections-add",
    //         ex.Message);
    //     Console.WriteLine(ex.Message);
    // }
}