// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.AI.Inference;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;
public class Sample_Embeddings
{
    [Test]
    public void BasicEmbedding()
    {
        var connectionString = Environment.GetEnvironmentVariable("AZURE_AI_CONNECTION_STRING");
        InferenceClient client = new AIProjectClient(connectionString, new DefaultAzureCredential()).GetInferenceClient();

        EmbeddingsClient embeddingsClient = client.GetEmbeddingsClient();

        var input = new List<string> { "King", "Queen", "Jack", "Page" };
        var requestOptions = new EmbeddingsOptions(input);

        Response<EmbeddingsResult> response = embeddingsClient.Embed(requestOptions);
        foreach (EmbeddingItem item in response.Value.Data)
        {
            List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
            Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
        }
    }
}
