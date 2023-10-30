// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples
{
    public partial class EmbeddingsSamples
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GenerateEmbeddings()
        {
            string endpoint = "https://myaccount.openai.azure.com/";
            var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

            #region Snippet:GenerateEmbeddings
            string deploymentOrModelName = "text-embedding-ada-002";
            EmbeddingsOptions embeddingsOptions = new("Your text string goes here");
            Response<Embeddings> response = await client.GetEmbeddingsAsync(deploymentOrModelName, embeddingsOptions);

            // The response includes the generated embedding.
            EmbeddingItem item = response.Value.Data[0];
            ReadOnlyMemory<float> embedding = item.Embedding;
            #endregion
        }
    }
}
