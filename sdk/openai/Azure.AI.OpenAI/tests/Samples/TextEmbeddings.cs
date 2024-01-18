// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples;

public partial class TextEmbeddings
{
    [Test]
    [Ignore("Only verifying that the sample builds")]
    public async Task GenerateEmbeddings()
    {
        string endpoint = "https://myaccount.openai.azure.com/";
        var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

        #region Snippet:GenerateEmbeddings
        EmbeddingsOptions embeddingsOptions = new()
        {
            DeploymentName = "text-embedding-ada-002",
            Input = { "Your text string goes here" },
        };
        Response<Embeddings> response = await client.GetEmbeddingsAsync(embeddingsOptions);

        // The response includes the generated embedding.
        EmbeddingItem item = response.Value.Data[0];
        ReadOnlyMemory<float> embedding = item.Embedding;
        #endregion
    }
}
