// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Chat;
using Azure.AI.OpenAI.Internal;
using OpenAI.Chat;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable AZC0112

namespace Azure.AI.OpenAI.Chat;

public static partial class AzureStreamingChatCompletionUpdateExtensions
{
    [Experimental("AOAI001")]
    public static AzureChatMessageContext GetAzureMessageContext(this StreamingChatCompletionUpdate chatUpdate)
    {
        if (chatUpdate.Choices?.Count > 0)
        {
            return AdditionalPropertyHelpers.GetAdditionalProperty<AzureChatMessageContext>(
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
