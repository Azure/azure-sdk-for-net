﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.VectorStores;

/// <summary>
/// The scenario client used for vector store operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
[Experimental("OPENAI001")]
internal partial class AzureVectorStoreClient : VectorStoreClient
{
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    internal AzureVectorStoreClient(ClientPipeline pipeline, Uri endpoint, AzureOpenAIClientOptions options)
        : base(pipeline, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        options ??= new();

        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    protected AzureVectorStoreClient()
    { }

    internal override CreateVectorStoreOperation CreateCreateVectorStoreOperation(ClientResult<VectorStore> result)
    {
        return new AzureCreateVectorStoreOperation(Pipeline, _endpoint, result, _apiVersion);
    }

    internal override AddFileToVectorStoreOperation CreateAddFileToVectorStoreOperation(ClientResult<VectorStoreFileAssociation> result)
    {
        return new AzureAddFileToVectorStoreOperation(Pipeline, _endpoint, result, _apiVersion);
    }

    internal override CreateBatchFileJobOperation CreateBatchFileJobOperation(ClientResult<VectorStoreBatchFileJob> result)
    {
        return new AzureCreateBatchFileJobOperation(Pipeline, _endpoint, result, _apiVersion);
    }
}

#endif