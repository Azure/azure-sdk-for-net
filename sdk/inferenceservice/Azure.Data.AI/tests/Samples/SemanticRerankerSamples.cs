// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

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
            InferenceServiceClient client = new InferenceServiceClient(endpoint, credential);
            #endregion Snippet:SemanticReranker_CreateClient
        }
    }
}
