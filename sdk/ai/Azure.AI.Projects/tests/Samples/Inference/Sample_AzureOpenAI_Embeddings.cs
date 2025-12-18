// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Embeddings;

namespace Azure.AI.Projects.Tests.Samples;

public class Sample_AzureOpenAI_Embeddings : SamplesBase
{
    [Test]
    [SyncOnly]
    public void AzureOpenAIEmbeddings()
    {
        #region Snippet:AI_Projects_AzureOpenAIEmbeddingsSync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("EMBEDDINGS_MODEL_DEPLOYMENT_NAME");
        var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
#else
        var endpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.TEXTEMBEDDINGSMODELDEPLOYMENTNAME;
        var connectionName = "";
        try
        {
            connectionName = TestEnvironment.AOAI_CONNECTION_NAME;
        }
        catch
        {
            connectionName = null;
        }

#endif
        Console.WriteLine("Create the Azure OpenAI embedding client");
        var credential = new DefaultAzureCredential();
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), credential);

        ClientConnection connection = projectClient.GetConnection(typeof(AzureOpenAIClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }
        uri = new Uri($"https://{uri.Host}");

        AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(uri, credential);
        EmbeddingClient embeddingsClient = azureOpenAIClient.GetEmbeddingClient(deploymentName: modelDeploymentName);

        Console.WriteLine("Generate an embedding");
        OpenAIEmbedding result = embeddingsClient.GenerateEmbedding("List all the rainbow colors");
        Console.WriteLine($"Generated embedding with {result.ToFloats().Length} dimensions");
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task AzureOpenAIEmbeddingsAsync()
    {
        #region Snippet:AI_Projects_AzureOpenAIEmbeddingsAsync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("EMBEDDINGS_MODEL_DEPLOYMENT_NAME");
        var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
#else
        var endpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.TEXTEMBEDDINGSMODELDEPLOYMENTNAME;
        var connectionName = "";
        try
        {
            connectionName = TestEnvironment.AOAI_CONNECTION_NAME;
        }
        catch
        {
            connectionName = null;
        }

#endif
        Console.WriteLine("Create the Azure OpenAI embedding client");
        var credential = new DefaultAzureCredential();
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), credential);

        ClientConnection connection = projectClient.GetConnection(typeof(AzureOpenAIClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }
        uri = new Uri($"https://{uri.Host}");

        AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(uri, credential);
        EmbeddingClient embeddingsClient = azureOpenAIClient.GetEmbeddingClient(deploymentName: modelDeploymentName);

        Console.WriteLine("Generate an embedding");
        OpenAIEmbedding result = await embeddingsClient.GenerateEmbeddingAsync("List all the rainbow colors");
        Console.WriteLine($"Generated embedding with {result.ToFloats().Length} dimensions");
        #endregion
    }

    public Sample_AzureOpenAI_Embeddings(bool isAsync) : base(isAsync)
    { }
}
