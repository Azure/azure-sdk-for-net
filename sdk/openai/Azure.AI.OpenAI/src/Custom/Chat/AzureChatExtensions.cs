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

        IList<ChatDataSource> existingSources =
            AdditionalPropertyHelpers.GetAdditionalPropertyAsListOfChatDataSource(
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
        return AdditionalPropertyHelpers.GetAdditionalPropertyAsListOfChatDataSource(
            options.SerializedAdditionalRawData,
            "data_sources") as IReadOnlyList<ChatDataSource>;
    }

    [Experimental("AOAI001")]
    public static void SetNewMaxCompletionTokensPropertyEnabled(this ChatCompletionOptions options, bool newPropertyEnabled = true)
    {
        if (newPropertyEnabled)
        {
            // Blocking serialization of max_tokens via dictionary acts as a signal to skip pre-serialization fixup
            options.SerializedAdditionalRawData ??= new Dictionary<string, BinaryData>();
            AdditionalPropertyHelpers.SetEmptySentinelValue(options.SerializedAdditionalRawData, "max_tokens");
        }
        else
        {
            // In the absence of a dictionary serialization block to max_tokens, the newer property name will
            // automatically be blocked and the older property name will be used via dictionary override
            if (options?.SerializedAdditionalRawData?.ContainsKey("max_tokens") == true)
            {
                options?.SerializedAdditionalRawData?.Remove("max_tokens");
            }
        }
    }

    [Experimental("AOAI001")]
    public static RequestContentFilterResult GetRequestContentFilterResult(this ChatCompletion chatCompletion)
    {
        return AdditionalPropertyHelpers.GetAdditionalPropertyAsListOfRequestContentFilterResult(
            chatCompletion.SerializedAdditionalRawData,
            "prompt_filter_results")?[0];
    }

    [Experimental("AOAI001")]
    public static ResponseContentFilterResult GetResponseContentFilterResult(this ChatCompletion chatCompletion)
    {
        return AdditionalPropertyHelpers.GetAdditionalPropertyAsResponseContentFilterResult(
            chatCompletion.Choices?[0]?.SerializedAdditionalRawData,
            "content_filter_results");
    }

    [Experimental("AOAI001")]
    public static ChatMessageContext GetMessageContext(this ChatCompletion chatCompletion)
    {
        return AdditionalPropertyHelpers.GetAdditionalPropertyAsChatMessageContext(
            chatCompletion.Choices?[0]?.Message?.SerializedAdditionalRawData,
            "context");
    }

    [Experimental("AOAI001")]
    public static ChatMessageContext GetMessageContext(this StreamingChatCompletionUpdate chatUpdate)
    {
        if (chatUpdate.Choices?.Count > 0)
        {
            return AdditionalPropertyHelpers.GetAdditionalPropertyAsChatMessageContext(
                chatUpdate.Choices[0].Delta?.SerializedAdditionalRawData,
                "context");
        }
        return null;
    }

    [Experimental("AOAI001")]
    public static RequestContentFilterResult GetRequestContentFilterResult(this StreamingChatCompletionUpdate chatUpdate)
    {
        return AdditionalPropertyHelpers.GetAdditionalPropertyAsListOfRequestContentFilterResult(
            chatUpdate.SerializedAdditionalRawData,
            "prompt_filter_results")?[0];
    }

    [Experimental("AOAI001")]
    public static ResponseContentFilterResult GetResponseContentFilterResult(this StreamingChatCompletionUpdate chatUpdate)
    {
        return AdditionalPropertyHelpers.GetAdditionalPropertyAsResponseContentFilterResult(
            chatUpdate?.Choices?.ElementAtOrDefault(0)?.SerializedAdditionalRawData,
            "content_filter_results");
    }

    [Experimental("AOAI001")]
    public static void SetUserSecurityContext(this ChatCompletionOptions options, UserSecurityContext userSecurityContext)
    {
        options.SerializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

        AdditionalPropertyHelpers.SetAdditionalProperty(
            options.SerializedAdditionalRawData,
            "user_security_context",
            userSecurityContext);
    }

    [Experimental("AOAI001")]
    public static UserSecurityContext GetUserSecurityContext(this ChatCompletionOptions options)
    {
        return AdditionalPropertyHelpers.GetAdditionalPropertyAsUserSecurityContext(
            options.SerializedAdditionalRawData,
            "user_security_context");
    }

    [Experimental("AOAI001")]
    public static string GetMessageReasoningContent(this ChatCompletion chatCompletion)
    {
        if (chatCompletion?.Choices?.FirstOrDefault()?.Message?.SerializedAdditionalRawData?.TryGetValue("reasoning_content", out BinaryData reasoningContentData) == true
            && reasoningContentData?.ToString() is string retrievedReasoningContent)
        {
            return retrievedReasoningContent;
        }
        return null;
    }
}