// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.AI.OpenAI.Chat;
using Azure.AI.OpenAI.Internal;
using OpenAI.Chat;

#pragma warning disable AZC0112

namespace Azure.AI.OpenAI.Chat;

public static partial class AzureChatCompletionExtensions
{
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
    public static AzureChatMessageContext GetAzureMessageContext(this ChatCompletion chatCompletion)
    {
        return AdditionalPropertyHelpers.GetAdditionalProperty<AzureChatMessageContext>(
            chatCompletion.Choices?[0]?.Message?.SerializedAdditionalRawData,
            "context");
    }
}
