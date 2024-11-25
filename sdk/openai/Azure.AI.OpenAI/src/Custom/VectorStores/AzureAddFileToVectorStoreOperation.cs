// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel.Primitives;
using System.ClientModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.VectorStores;
[Experimental("OPENAI001")]
internal partial class AzureAddFileToVectorStoreOperation : AddFileToVectorStoreOperation
{
    private readonly string _apiVersion;
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;
    internal AzureAddFileToVectorStoreOperation(
        ClientPipeline pipeline,
        Uri endpoint,
        ClientResult<VectorStoreFileAssociation> result,
        string apiVersion)
        : base(pipeline, endpoint, result)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _apiVersion = apiVersion;
    }
}

#endif