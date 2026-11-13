// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Azure.AI.OpenAI.Responses;

[Experimental("OPENAI002")]
internal partial class AzureResponsesClient
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

    internal override PipelineMessage CreateGetResponseRequest(string responseId, IEnumerable<IncludedResponseProperty> include, bool? stream, int? startingAfter, bool? includeObfuscation, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _aoaiEndpoint, _apiVersion, string.Empty)
            .WithPath("responses", responseId)
            .WithOptionalQueryParameter("include[]", $"{GetIncludeQueryStringValue(include)}", escape: false)
            .WithOptionalQueryParameter("stream", stream)
            .WithOptionalQueryParameter("starting_after", startingAfter)
            .WithMethod("GET")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateGetResponseInputItemsRequest(string responseId, int? limit, string order, string after, string before, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _aoaiEndpoint, _apiVersion, string.Empty)
            .WithPath("responses", responseId, "input_items")
            .WithOptionalQueryParameter("limit", limit)
            .WithOptionalQueryParameter("order", order)
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("before", before)
            .WithMethod("GET")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateDeleteResponseRequest(string responseId, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _aoaiEndpoint, _apiVersion, string.Empty)
        .WithPath("responses", responseId)
        .WithMethod("DELETE")
        .WithOptions(options)
        .Build();

    private static string GetIncludeQueryStringValue(IEnumerable<IncludedResponseProperty> include)
    {
        if (include?.Any() != true)
        {
            return string.Empty;
        }
        StringBuilder valueBuilder = new();
        foreach (IncludedResponseProperty item in include)
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
