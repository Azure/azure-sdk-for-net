// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.AI.Inference;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class Sample_AIInference : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    public void InferenceChatCompletion()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        AIProjectClient client = new AIProjectClient(connectionString);
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
    }

    [Test]
    public void InferenceEmbedding()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.EMBEDDINGMODELDEPLOYMENTNAME;

        AIProjectClient client = new AIProjectClient(connectionString);
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
    }
}
