// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

#pragma warning disable IDE0051 // Remove unused private members

namespace Azure.Data.AI.Tests.Samples
{
    public class SemanticRerankerSamples
    {
        private void CreateClient()
        {
            #region Snippet:SemanticReranker_CreateClient
            Uri endpoint = new Uri("<semantic-reranker-endpoint>");
            AzureKeyCredential credential = new AzureKeyCredential("<api-key>");
            InferenceClient client = new InferenceClient(endpoint, credential);
            #endregion Snippet:SemanticReranker_CreateClient
        }

        private async Task RerankDocuments(InferenceClient client)
        {
            #region Snippet:SemanticReranker_RerankDocuments
            var request = new SemanticRerankingOptions(
                "What is the capital of France?",
                new[]
                {
                    "Paris is the capital of France.",
                    "Berlin is the capital of Germany."
                })
            {
                TopK = 1,
                ReturnDocuments = true
            };

            Response<SemanticRerankingResult> response = await client.SemanticRerankAsync(request);
            SemanticRerankingMetadata metadata = response.Value.Metadata;
            #endregion Snippet:SemanticReranker_RerankDocuments
        }

        private async Task RerankJsonDocuments(InferenceClient client)
        {
            #region Snippet:SemanticReranker_RerankJsonDocuments
            var request = new SemanticRerankingOptions(
                "What is the capital of France?",
                new[] { "{\"id\":\"france\",\"meta\":{\"content\":\"Paris is the capital of France.\"}}" })
            {
                DocumentType = SemanticRerankingDocumentType.Json,
                TargetPaths = { "meta.content", "id" }
            };

            Response<SemanticRerankingResult> response = await client.SemanticRerankAsync(request);
            #endregion Snippet:SemanticReranker_RerankJsonDocuments
        }
    }
}
