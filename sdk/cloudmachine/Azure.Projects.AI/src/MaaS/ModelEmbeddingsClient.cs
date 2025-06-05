// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using OpenAI.Embeddings;
using System;
using System.ClientModel;

namespace Azure.AI.Models
{
    internal class ModelEmbeddingsClient : EmbeddingClient
    {
        public ModelEmbeddingsClient(string model, Uri endpoint, ApiKeyCredential key)
            : base(model, key, MaaSClientHelpers.CreateOptions(endpoint))
        {
        }

        public ModelEmbeddingsClient(string model, Uri endpoint, TokenCredential credential)
            : base(MaaSClientHelpers.CreatePipeline(credential), model, MaaSClientHelpers.CreateOptions(endpoint))
        {
        }
    }
}
