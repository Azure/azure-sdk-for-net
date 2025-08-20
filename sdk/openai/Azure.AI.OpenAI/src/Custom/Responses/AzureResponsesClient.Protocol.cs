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
        string accept,
        RequestOptions requestOptions)
            => new AzureOpenAIPipelineMessageBuilder(Pipeline, _aoaiEndpoint, _apiVersion, string.Empty)
                .WithPath("responses")
                .WithMethod("POST")
                .WithAccept(accept)
                .WithContent(content, "application/json")
                .WithResponseContentBuffering(requestOptions?.BufferResponse)
                .WithOptions(requestOptions)
                .Build();

    internal override PipelineMessage CreateGetResponseRequest(string responseId, IEnumerable<InternalCreateResponsesRequestIncludable> include, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _aoaiEndpoint, _apiVersion, string.Empty)
            .WithPath("responses", responseId)
            .WithOptionalQueryParameter("include[]", $"{GetIncludeQueryStringValue(include)}", escape: false)
            .WithMethod("GET")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage CreateListInputItemsRequest(string responseId, int? limit, string order, string after, string before, RequestOptions options)
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

    private static string GetIncludeQueryStringValue(IEnumerable<InternalCreateResponsesRequestIncludable> include)
    {
        if (include?.Any() != true)
        {
            return string.Empty;
        }
        StringBuilder valueBuilder = new();
        foreach (InternalCreateResponsesRequestIncludable item in include)
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