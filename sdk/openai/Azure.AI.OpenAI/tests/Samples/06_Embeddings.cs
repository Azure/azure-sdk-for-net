// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Threading.Tasks;
using Azure.Identity;
using OpenAI.Embeddings;

namespace Azure.AI.OpenAI.Samples;

public partial class AzureOpenAISamples
{
    public void EmbeddingBasic()
    {
        #region Snippet:EmbeddingBasic
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());

        // Replace with your deployment name
        EmbeddingClient client = azureClient.GetEmbeddingClient("my-gpt-35-turbo-deployment");

        ClientResult<OpenAIEmbedding> embeddingResult = client.GenerateEmbedding("The quick brown fox jumped over the lazy dog");

        if (embeddingResult?.Value != null)
        {
            float[] embedding = embeddingResult.Value.ToFloats().ToArray();

            Console.WriteLine($"Embedding Length: {embedding.Length}");
            Console.WriteLine("Embedding Values:");
            foreach (float value in embedding)
            {
                Console.Write($"{value}, ");
            }
        }
        else
        {
            Console.WriteLine("Failed to generate embedding or received null value.");
        }
        #endregion
    }

    public async Task EmbeddingBasicAsync()
    {
        #region Snippet:EmbeddingBasicAsync
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());

        // Replace with your deployment name
        EmbeddingClient client = azureClient.GetEmbeddingClient("my-gpt-35-turbo-deployment");

        ClientResult<OpenAIEmbedding> embeddingResult = await client.GenerateEmbeddingAsync("The quick brown fox jumped over the lazy dog");

        if (embeddingResult?.Value != null)
        {
            float[] embedding = embeddingResult.Value.ToFloats().ToArray();

            Console.WriteLine($"Embedding Length: {embedding.Length}");
            Console.WriteLine("Embedding Values:");
            foreach (float value in embedding)
            {
                Console.Write($"{value}, ");
            }
        }
        else
        {
            Console.WriteLine("Failed to generate embedding or received null value.");
        }
        #endregion
    }
}
