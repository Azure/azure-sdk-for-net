// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.VectorStores;

namespace Azure.AI.Extensions.OpenAI;

/// <summary> Provides vector store operations for an Azure AI project through the OpenAI vector store API. </summary>
public partial class ProjectVectorStoresClient : VectorStoreClient
{
    internal ProjectVectorStoresClient(ClientPipeline pipeline, OpenAIClientOptions options)
        : base(pipeline, options)
    {
    }

    /// <summary> Initializes a new instance of <see cref="ProjectVectorStoresClient"/> for mocking. </summary>
    protected ProjectVectorStoresClient()
    { }
}
