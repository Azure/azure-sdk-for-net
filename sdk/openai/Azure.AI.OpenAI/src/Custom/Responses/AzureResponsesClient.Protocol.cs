// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Azure.AI.OpenAI.Responses;

[Experimental("OPENAI002")]
internal partial class AzureOpenAIResponseClient
{
    internal override PipelineMessage CreateCreateResponseRequest(
        BinaryContent content,
        RequestOptions requestOptions)
            => new AzureOpenAIPipelineMessageBuilder(Pipeline, _aoaiEndpoint, _apiVersion, string.Empty)
                .WithPath("responses")
                .WithMethod("POST")
                .WithContent(content, "application/json")
                .WithResponseContentBuffering(requestOptions?.BufferResponse)
                .WithOptions(requestOptions)
                .Build();

    internal override PipelineMessage CreateCancelResponseRequest(string responseId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _aoaiEndpoint, _apiVersion, string.Empty)
            .WithPath("responses", responseId, "cancel")
            .WithMethod("POST")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetResponseRequest(string responseId, IEnumerable<InternalIncludable> includables, bool? stream, int? startingAfter, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _aoaiEndpoint, _apiVersion, string.Empty)
            .WithPath("responses", responseId)
            .WithOptionalQueryParameter("include[]", $"{GetIncludeQueryStringValue(includables)}", escape: false)
            .WithOptionalQueryParameter("stream", stream)
            .WithOptionalQueryParameter("starting_after", startingAfter)
            .WithMethod("GET")
            .WithOptions(options)
            .Build();

    internal PipelineMessage CreateGetInputItemsRequest(string responseId, int? limit, string order, string after, string before, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _aoaiEndpoint, _apiVersion, string.Empty)
            .WithPath("responses", responseId, "input_items")
            .WithMethod("GET")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateDeleteResponseRequest(string responseId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _aoaiEndpoint, _apiVersion, string.Empty)
        .WithPath("responses", responseId)
        .WithMethod("DELETE")
        .WithOptions(options)
        .Build();

    private static string GetIncludeQueryStringValue(IEnumerable<InternalIncludable> include)
    {
        if (include?.Any() != true)
        {
            return string.Empty;
        }
        StringBuilder valueBuilder = new();
        foreach (InternalIncludable item in include)
        {
            if (valueBuilder.Length > 0)
            {
                valueBuilder.Append(',');
            }
            valueBuilder.Append(item.ToString());
        }
        return valueBuilder.ToString();
    }
}

#endif
