// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Inference;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class Sample_AIInference : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [SyncOnly]
    public void InferenceChatCompletion()
    {
        #region Snippet:AI_Projects_ChatClientSync
#if SNIPPET
        var projectEndpoint = new Uri(System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT"));
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = new Uri(TestEnvironment.PROJECTENDPOINT);
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var inferenceEndpoint = $"{projectEndpoint.GetLeftPart(UriPartial.Authority)}/models";

        AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

        var credential = new DefaultAzureCredential();
        BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://ai.azure.com/.default" });
        clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

        ChatCompletionsClient chatClient = new ChatCompletionsClient(new Uri(inferenceEndpoint), credential, clientOptions);

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
        #region Snippet:AI_Projects_ChatClientAsync
#if SNIPPET
        var projectEndpoint = new Uri(System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT"));
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = new Uri(TestEnvironment.PROJECTENDPOINT);
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var inferenceEndpoint = $"{projectEndpoint.GetLeftPart(UriPartial.Authority)}/models";

        AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

        var credential = new DefaultAzureCredential();
        BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://ai.azure.com/.default" });
        clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

        ChatCompletionsClient chatClient = new ChatCompletionsClient(new Uri(inferenceEndpoint), credential, clientOptions);

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
        #region Snippet:AI_Projects_EmbeddingSync
#if SNIPPET
        var projectEndpoint = new Uri(System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT"));
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = new Uri(TestEnvironment.PROJECTENDPOINT);
        var modelDeploymentName = TestEnvironment.EMBEDDINGSMODELDEPLOYMENTNAME;
#endif
        var inferenceEndpoint = $"{projectEndpoint.GetLeftPart(UriPartial.Authority)}/models";

        AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

        var credential = new DefaultAzureCredential();
        BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://ai.azure.com/.default" });
        clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

        EmbeddingsClient embeddingsClient = new EmbeddingsClient(new Uri(inferenceEndpoint), credential, clientOptions);

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
        #region Snippet:AI_Projects_EmbeddingAsync
#if SNIPPET
        var projectEndpoint = new Uri(System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT"));
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = new Uri(TestEnvironment.PROJECTENDPOINT);
        var modelDeploymentName = TestEnvironment.EMBEDDINGSMODELDEPLOYMENTNAME;
#endif
        var inferenceEndpoint = $"{projectEndpoint.GetLeftPart(UriPartial.Authority)}/models";

        AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

        var credential = new DefaultAzureCredential();
        BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://ai.azure.com/.default" });
        clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

        EmbeddingsClient embeddingsClient = new EmbeddingsClient(new Uri(inferenceEndpoint), credential, clientOptions);

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

    [Test]
    [SyncOnly]
    public void InferenceImageEmbedding()
    {
        #region Snippet:AI_Projects_ImageEmbeddingSync
#if SNIPPET
        var projectEndpoint = new Uri(System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT"));
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = new Uri(TestEnvironment.PROJECTENDPOINT);
        var modelDeploymentName = TestEnvironment.EMBEDDINGSMODELDEPLOYMENTNAME;
#endif
        var inferenceEndpoint = $"{projectEndpoint.GetLeftPart(UriPartial.Authority)}/models";

        AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

        var credential = new DefaultAzureCredential();
        BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://ai.azure.com/.default" });
        clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

        ImageEmbeddingsClient imageEmbeddingsClient = new ImageEmbeddingsClient(new Uri(inferenceEndpoint), credential, clientOptions);

        List<ImageEmbeddingInput> input = new List<ImageEmbeddingInput>
        {
#if SNIPPET
            ImageEmbeddingInput.Load(imageFilePath:"sampleImage.png", imageFormat:"png")
#else
            ImageEmbeddingInput.Load(TestEnvironment.TESTIMAGEPNGINPUTPATH, "png"),
#endif
        };

        var requestOptions = new ImageEmbeddingsOptions(input)
        {
            Model = modelDeploymentName
        };

        Response<EmbeddingsResult> response = imageEmbeddingsClient.Embed(requestOptions);
        foreach (EmbeddingItem item in response.Value.Data)
        {
            List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
            Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
        }
#endregion

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Value, Is.InstanceOf<EmbeddingsResult>());
        Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
        Assert.AreEqual(response.Value.Data.Count, input.Count);
        for (int i = 0; i < input.Count; i++)
        {
            Assert.AreEqual(response.Value.Data[i].Index, i);
            Assert.That(response.Value.Data[i].Embedding, Is.Not.Null.Or.Empty);
            var embedding = response.Value.Data[i].Embedding.ToObjectFromJson<List<float>>();
            Assert.That(embedding.Count, Is.GreaterThan(0));
        }
    }

    [Test]
    [AsyncOnly]
    public async Task InferenceImageEmbeddingAsync()
    {
        #region Snippet:AI_Projects_ImageEmbeddingAsync
#if SNIPPET
        var projectEndpoint = new Uri(System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT"));
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = new Uri(TestEnvironment.PROJECTENDPOINT);
        var modelDeploymentName = TestEnvironment.EMBEDDINGSMODELDEPLOYMENTNAME;
#endif
        var inferenceEndpoint = $"{projectEndpoint.GetLeftPart(UriPartial.Authority)}/models";

        AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

        var credential = new DefaultAzureCredential();
        BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://ai.azure.com/.default" });
        clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

        ImageEmbeddingsClient imageEmbeddingsClient = new ImageEmbeddingsClient(new Uri(inferenceEndpoint), credential, clientOptions);

        List<ImageEmbeddingInput> input = new List<ImageEmbeddingInput>
        {
#if SNIPPET
            ImageEmbeddingInput.Load(imageFilePath:"sampleImage.png", imageFormat:"png")
#else
            ImageEmbeddingInput.Load(TestEnvironment.TESTIMAGEPNGINPUTPATH, "png"),
#endif
        };

        var requestOptions = new ImageEmbeddingsOptions(input)
        {
            Model = modelDeploymentName
        };

        Response<EmbeddingsResult> response = await imageEmbeddingsClient.EmbedAsync(requestOptions);
        foreach (EmbeddingItem item in response.Value.Data)
        {
            List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
            Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
        }
        #endregion

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Value, Is.InstanceOf<EmbeddingsResult>());
        Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
        Assert.AreEqual(response.Value.Data.Count, input.Count);
        for (int i = 0; i < input.Count; i++)
        {
            Assert.AreEqual(response.Value.Data[i].Index, i);
            Assert.That(response.Value.Data[i].Embedding, Is.Not.Null.Or.Empty);
            var embedding = response.Value.Data[i].Embedding.ToObjectFromJson<List<float>>();
            Assert.That(embedding.Count, Is.GreaterThan(0));
        }
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
