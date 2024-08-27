// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.VectorStores;

internal partial class AzureVectorStoresPageEnumerator : VectorStoresPageEnumerator
{
    private readonly Uri _endpoint;
    private readonly string _apiVersion;

    public AzureVectorStoresPageEnumerator(
        ClientPipeline pipeline,
        Uri endpoint,
        int? limit, string order, string after, string before,
        string apiVersion,
        RequestOptions options)
        : base(pipeline, endpoint, limit, order, after, before, options)
    {
        _endpoint = endpoint;
        _apiVersion = apiVersion;
    }

    internal override async Task<ClientResult> GetVectorStoresAsync(int? limit, string order, string after, string before, RequestOptions options)
    {
        using PipelineMessage message = CreateGetVectorStoresRequest(limit, order, after, before, options);
        return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    internal override ClientResult GetVectorStores(int? limit, string order, string after, string before, RequestOptions options)
    {
        using PipelineMessage message = CreateGetVectorStoresRequest(limit, order, after, before, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    private new PipelineMessage CreateGetVectorStoresRequest(int? limit, string order, string after, string before, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion)
            .WithAssistantsHeader()
            .WithOptions(options)
            .WithMethod("GET")
            .WithAccept("application/json")
            .WithCommonListParameters(limit, order, after, before)
            .WithPath("vector_stores")
            .Build();
}
