// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.AI.Inference;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class Sample_Embeddings : SamplesBase<AIProjectsTestEnvironment>
{
    /*
    Instructions:
    1. If you are using a Serverless connection, you need to set the environment variable "USE_SERVERLESS_CONNECTION" to "true".
    2. If this environment variable is not set, the default connection type (AzureAI services) will be used.
    */

    [Test]
    public void BasicEmbedding()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;

        EmbeddingsClient embeddingsClient = new AIProjectClient(connectionString, new DefaultAzureCredential()).GetEmbeddingsClient();

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
