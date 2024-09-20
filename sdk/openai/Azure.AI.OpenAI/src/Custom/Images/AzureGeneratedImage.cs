// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Internal;
using OpenAI.Images;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

public static class AzureGeneratedImageExtensions
{
    [Experimental("AOAI001")]
    public static ImageContentFilterResultForPrompt GetContentFilterResultForPrompt(this GeneratedImage image)
    {
        return AdditionalPropertyHelpers.GetAdditionalProperty<ImageContentFilterResultForPrompt>(
            image.SerializedAdditionalRawData,
            "prompt_filter_results");
    }

    [Experimental("AOAI001")]
    public static ImageContentFilterResultForResponse GetContentFilterResultForResponse(this GeneratedImage image)
    {
        return AdditionalPropertyHelpers.GetAdditionalProperty<ImageContentFilterResultForResponse>(
            image.SerializedAdditionalRawData,
            "content_filter_results");
    }
}
