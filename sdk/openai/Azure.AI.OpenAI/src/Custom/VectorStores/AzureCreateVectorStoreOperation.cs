// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.VectorStores;

[Experimental("OPENAI001")]
internal partial class AzureCreateVectorStoreOperation : CreateVectorStoreOperation
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    internal AzureCreateVectorStoreOperation(
        ClientPipeline pipeline,
        Uri endpoint,
        ClientResult<VectorStore> result,
        string apiVersion)
        : base(pipeline, endpoint, result)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _apiVersion = apiVersion;
    }
}

#endif