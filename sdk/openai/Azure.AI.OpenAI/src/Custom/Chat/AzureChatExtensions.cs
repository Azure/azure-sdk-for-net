// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Internal;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable AZC0112

namespace Azure.AI.OpenAI.Chat;

[Experimental("AOAI001")]
public static partial class AzureChatExtensions
{
    [Experimental("AOAI001")]
    public static void AddDataSource(this ChatCompletionOptions options, ChatDataSource dataSource)
    {
        options.SerializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

        IList<ChatDataSource> existingSources
            = AdditionalPropertyHelpers.GetAdditionalListProperty<ChatDataSource>(
                options.SerializedAdditionalRawData,
                "data_sources")
            ?? new ChangeTrackingList<ChatDataSource>();
        existingSources.Add(dataSource);
        AdditionalPropertyHelpers.SetAdditionalProperty(
            options.SerializedAdditionalRawData,
            "data_sources",
            existingSources);
    }

    [Experimental("AOAI001")]
    public static IReadOnlyList<ChatDataSource> GetDataSources(this ChatCompletionOptions options)
    {
        return AdditionalPropertyHelpers.GetAdditionalListProperty<ChatDataSource>(
            options.SerializedAdditionalRawData,
            "data_sources") as IReadOnlyList<ChatDataSource>;
    }

    [Experimental("AOAI001")]
    public static RequestContentFilterResult GetRequestContentFilterResult(this ChatCompletion chatCompletion)
    {
        return AdditionalPropertyHelpers.GetAdditionalListProperty<RequestContentFilterResult>(
            chatCompletion.SerializedAdditionalRawData,
            "prompt_filter_results")?[0];
    }

    [Experimental("AOAI001")]
    public static ResponseContentFilterResult GetResponseContentFilterResult(this ChatCompletion chatCompletion)
    {
        return AdditionalPropertyHelpers.GetAdditionalProperty<ResponseContentFilterResult>(
            chatCompletion.Choices?[0]?.SerializedAdditionalRawData,
            "content_filter_results");
    }

    [Experimental("AOAI001")]
    public static ChatMessageContext GetMessageContext(this ChatCompletion chatCompletion)
    {
        return AdditionalPropertyHelpers.GetAdditionalProperty<ChatMessageContext>(
            chatCompletion.Choices?[0]?.Message?.SerializedAdditionalRawData,
            "context");
    }

    [Experimental("AOAI001")]
    public static ChatMessageContext GetMessageContext(this StreamingChatCompletionUpdate chatUpdate)
    {
        if (chatUpdate.Choices?.Count > 0)
        {
            return AdditionalPropertyHelpers.GetAdditionalProperty<ChatMessageContext>(
                chatUpdate.Choices[0].Delta?.SerializedAdditionalRawData,
                "context");
        }
        return null;
    }

    [Experimental("AOAI001")]
    public static RequestContentFilterResult GetRequestContentFilterResult(this StreamingChatCompletionUpdate chatUpdate)
    {
        return AdditionalPropertyHelpers.GetAdditionalListProperty<RequestContentFilterResult>(
            chatUpdate.SerializedAdditionalRawData,
            "prompt_filter_results")?[0];
    }

    [Experimental("AOAI001")]
    public static ResponseContentFilterResult GetResponseContentFilterResult(this StreamingChatCompletionUpdate chatUpdate)
    {
        return AdditionalPropertyHelpers.GetAdditionalProperty<ResponseContentFilterResult>(
            chatUpdate?.Choices?.ElementAtOrDefault(0)?.SerializedAdditionalRawData,
            "content_filter_results");
    }
}