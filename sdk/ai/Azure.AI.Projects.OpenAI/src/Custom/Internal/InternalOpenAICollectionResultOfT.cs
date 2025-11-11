// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Azure.AI.Projects.OpenAI;

internal partial class InternalOpenAICollectionResultOfT<TData> : CollectionResult<TData>
{
    private readonly ClientPipeline _pipeline;
    private readonly Func<InternalOpenAICollectionResultOptions, RequestOptions, PipelineMessage> _messageGenerator;
    private readonly Func<JsonElement, ModelReaderWriterOptions, TData> _dataItemDeserializer;
    private readonly InternalOpenAICollectionResultOptions _resultOptions;
    private readonly RequestOptions _requestOptions;

    public InternalOpenAICollectionResultOfT(
        ClientPipeline pipeline,
        Func<InternalOpenAICollectionResultOptions, RequestOptions, PipelineMessage> messageGenerator,
        Func<JsonElement, ModelReaderWriterOptions, TData> dataItemDeserializer,
        InternalOpenAICollectionResultOptions resultOptions,
        RequestOptions requestOptions)
    {
        Argument.AssertNotNull(pipeline, nameof(pipeline));
        Argument.AssertNotNull(messageGenerator, nameof(messageGenerator));

        _pipeline = pipeline;
        _messageGenerator = messageGenerator;
        _dataItemDeserializer = dataItemDeserializer;
        _resultOptions = resultOptions;
        _requestOptions = requestOptions;
    }

    public override IEnumerable<ClientResult> GetRawPages()
    {
        PipelineMessage message = _messageGenerator.Invoke(_resultOptions, _requestOptions);
        while (true)
        {
            _ = _pipeline.ProcessMessage(message, _requestOptions);
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

    protected override IEnumerable<TData> GetValuesFromPage(ClientResult rawPage)
    {
        return GetPageFromResult(rawPage);
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
