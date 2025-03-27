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
            : base(model, key, Helpers.CreateOptions(endpoint))
        {
        }

        public ModelEmbeddingsClient(string model, Uri endpoint, TokenCredential credential)
            : base(Helpers.CreatePipeline(credential), model, Helpers.CreateOptions(endpoint))
        {
        }
    }
}
