﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.VectorStores;
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

    internal AzureVectorStoreClient(
        ClientPipeline pipeline,
        Uri endpoint,
        AzureOpenAIClientOptions options)
            : base(pipeline, endpoint, options)
    {
        options ??= new();
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    protected AzureVectorStoreClient()
    { }
}
