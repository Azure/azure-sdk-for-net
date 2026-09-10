// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.AI.OpenAI.Internal;
using OpenAI.Images;

// AZC0112: Azure.AI.OpenAI is granted InternalsVisibleTo by System.ClientModel and OpenAI and is the
// intended caller of these members. The upstream types predate the [Friend] attribute the rule looks for.
#pragma warning disable AZC0112

namespace Azure.AI.OpenAI.Images;

/// <summary> Provides extension methods for accessing Azure-specific content filter results on generated images. </summary>
[Experimental("AOAI001")]
public static class AzureImageExtensions
{
    /// <summary> Gets the content filter result for the prompt that generated this image. </summary>
    /// <param name="image"> The <see cref="GeneratedImage"/> to retrieve the filter result from. </param>
    /// <returns> The <see cref="RequestImageContentFilterResult"/>, or <c>null</c> if no filter result is available. </returns>
    [Experimental("AOAI001")]
    public static RequestImageContentFilterResult GetRequestContentFilterResult(this GeneratedImage image)
    {
        return AdditionalPropertyHelpers.GetAdditionalPropertyAsRequestImageContentFilterResult(
            image.SerializedAdditionalRawData,
            "prompt_filter_results");
    }

    /// <summary> Gets the content filter result for the generated image content. </summary>
    /// <param name="image"> The <see cref="GeneratedImage"/> to retrieve the filter result from. </param>
    /// <returns> The <see cref="ResponseImageContentFilterResult"/>, or <c>null</c> if no filter result is available. </returns>
    [Experimental("AOAI001")]
    public static ResponseImageContentFilterResult GetResponseContentFilterResult(this GeneratedImage image)
    {
        return AdditionalPropertyHelpers.GetAdditionalPropertyAsResponseImageContentFilterResult(
            image.SerializedAdditionalRawData,
            "content_filter_results");
    }
}
