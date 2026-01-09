// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.VectorStores;

namespace Azure.AI.Projects.OpenAI;

public partial class ProjectVectorStoresClient : VectorStoreClient
{
    internal ProjectVectorStoresClient(ClientPipeline pipeline, OpenAIClientOptions options)
        : base(pipeline, options)
    {
    }

    protected ProjectVectorStoresClient()
    { }
}
