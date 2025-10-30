// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.AI.Agents;

internal partial class InternalOpenAIAsyncCollectionResultOfT<TData> : AsyncCollectionResult<TData>
{
    private readonly ClientPipeline _pipeline;
    private readonly Func<InternalOpenAICollectionResultOptions, RequestOptions, PipelineMessage> _messageGenerator;
    private readonly Func<JsonElement, ModelReaderWriterOptions, TData> _dataItemDeserializer;
    private readonly InternalOpenAICollectionResultOptions _resultOptions;
    private readonly RequestOptions _requestOptions;

    public InternalOpenAIAsyncCollectionResultOfT(
        ClientPipeline pipeline,
        Func<InternalOpenAICollectionResultOptions, RequestOptions, PipelineMessage> messageGenerator,
        Func<JsonElement, ModelReaderWriterOptions, TData> dataItemDeserializer,
        InternalOpenAICollectionResultOptions resultOptions,
        RequestOptions requestOptions)
    {
        _pipeline = pipeline;
        _messageGenerator = messageGenerator;
        _dataItemDeserializer = dataItemDeserializer;
        _resultOptions = resultOptions;
        _requestOptions = requestOptions;
    }

    public override ContinuationToken GetContinuationToken(ClientResult rawPage)
    {
        InternalOpenAIPaginatedListResultOfT<TData> page = GetPageFromResult(rawPage);
        if (page.HasMore)
        {
            return ContinuationToken.FromBytes(rawPage.GetRawResponse().Content);
        }
        return null;
    }

    public ReadOnlyCollection<TData> GetDataFromPage(ClientResult rawPage)
    {
        return GetPageFromResult(rawPage);
    }

    protected override async IAsyncEnumerable<TData> GetValuesFromPageAsync(ClientResult rawPage)
    {
        InternalOpenAIPaginatedListResultOfT<TData> page = GetPageFromResult(rawPage);

        foreach (TData dataItem in page)
        {
            yield return dataItem;
            await Task.Yield();
        }
    }

    public override async IAsyncEnumerable<ClientResult> GetRawPagesAsync()
    {
        PipelineMessage message = _messageGenerator.Invoke(_resultOptions, _requestOptions);
        while (true)
        {
            _ = await _pipeline.ProcessMessageAsync(message, _requestOptions).ConfigureAwait(false);
            ClientResult result = ClientResult.FromResponse(message.Response);
            yield return result;

            InternalOpenAIPaginatedListResultOfT<TData> page = GetPageFromResult(result);

            if (!page.HasMore)
            {
                yield break;
            }

            message = _messageGenerator.Invoke(_resultOptions.GetCloneForPage(page), _requestOptions);
        }
    }

    private InternalOpenAIPaginatedListResultOfT<TData> GetPageFromResult(ClientResult result)
    {
        using JsonDocument pageDocument = JsonDocument.Parse(result.GetRawResponse().Content);
        InternalOpenAIPaginatedListResultOfT<TData> typedDataResult
            = InternalOpenAIPaginatedListResultOfT<TData>.DeserializeInternalOpenAIPaginatedListResultOfT(
                pageDocument.RootElement,
                _dataItemDeserializer,
                options: ModelReaderWriterOptions.Json);
        return typedDataResult;
    }
}
