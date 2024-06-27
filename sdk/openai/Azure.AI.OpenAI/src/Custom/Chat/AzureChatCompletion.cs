﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.AI.OpenAI.Chat;
using Azure.AI.OpenAI.Internal;
using OpenAI.Chat;

#pragma warning disable AZC0112

namespace Azure.AI.OpenAI;

public static partial class AzureChatCompletionExtensions
{
    [Experimental("AOAI001")]
    public static ContentFilterResultForPrompt GetContentFilterResultForPrompt(this ChatCompletion chatCompletion)
    {
        return AdditionalPropertyHelpers.GetAdditionalListProperty<ContentFilterResultForPrompt>(
            chatCompletion._serializedAdditionalRawData,
            "prompt_filter_results")?[0];
    }

    [Experimental("AOAI001")]
    public static ContentFilterResultForResponse GetContentFilterResultForResponse(this ChatCompletion chatCompletion)
    {
        return AdditionalPropertyHelpers.GetAdditionalProperty<ContentFilterResultForResponse>(
            chatCompletion.Choices?[0]?._serializedAdditionalRawData,
            "content_filter_results");
    }

    [Experimental("AOAI001")]
    public static AzureChatMessageContext GetAzureMessageContext(this ChatCompletion chatCompletion)
    {
        return AdditionalPropertyHelpers.GetAdditionalProperty<AzureChatMessageContext>(
            chatCompletion.Choices?[0]?.Message?._serializedAdditionalRawData,
            "context");
    }
}
