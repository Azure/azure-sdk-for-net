// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI;

// CUSTOM CODE NOTE:
//  These changes facilitate the additional use of BinaryData and also hiding the interior type.

/// <summary> An internet location from which the model may retrieve an image. </summary>
internal partial class InternalChatMessageImageUrl
{
    /// <summary>
    /// Creates a new instance of <see cref="InternalChatMessageImageUrl"/> using local JPEG image data and the default
    /// <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="jpegImageData"> The local image data to provide to the model. </param>
    public InternalChatMessageImageUrl(BinaryData jpegImageData)
    {
        Argument.AssertNotNull(jpegImageData, nameof(jpegImageData));
        UrlOrEncodedData = GetEncodedImageData(jpegImageData, MediaTypeNames.Image.Jpeg);
    }

    /// <summary>
    /// Creates a new instance of <see cref="InternalChatMessageImageUrl"/> using local image data in a specified format and
    /// the default <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="imageData"> The local image data to provide to the model. </param>
    /// <param name="imageDataFormat"> The image format, e.g. 'image/jpeg', for the image data. </param>
    public InternalChatMessageImageUrl(BinaryData imageData, string imageDataFormat)
    {
        Argument.AssertNotNull(imageData, nameof(imageData));
        Argument.AssertNotNull(imageDataFormat, nameof(imageDataFormat));
        UrlOrEncodedData = GetEncodedImageData(imageData, imageDataFormat);
    }

    /// <summary>
    /// Creates a new instance of <see cref="InternalChatMessageImageUrl"/> using local JPEG image data and a specified
    /// <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="jpegImageData"> The local image data to provide to the model. </param>
    /// <param name="detail"> The detail level to use when processing the provided image data. </param>
    public InternalChatMessageImageUrl(BinaryData jpegImageData, ChatMessageImageDetailLevel detail)
    {
        Argument.AssertNotNull(jpegImageData, nameof(jpegImageData));
        Argument.AssertNotNull(detail, nameof(detail));
        UrlOrEncodedData = GetEncodedImageData(jpegImageData, MediaTypeNames.Image.Jpeg);
        Detail = detail;
    }

    /// <summary>
    /// Creates a new instance of <see cref="InternalChatMessageImageUrl"/> using local image data in a specified format and
    /// a specified <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="imageData"> The local image data to provide to the model. </param>
    /// <param name="imageDataFormat"> The image format, e.g. 'image/jpeg', for the image data. </param>
    /// <param name="detail"> The detail level to use when processing the provided image data. </param>
    public InternalChatMessageImageUrl(BinaryData imageData, string imageDataFormat, ChatMessageImageDetailLevel detail)
    {
        Argument.AssertNotNull(imageData, nameof(imageData));
        Argument.AssertNotNull(imageDataFormat, nameof(imageDataFormat));
        Argument.AssertNotNull(detail, nameof(detail));
        UrlOrEncodedData = GetEncodedImageData(imageData, imageDataFormat);
        Detail = detail;
    }

    private static string GetEncodedImageData(BinaryData imageData, string imageDataFormat)
    {
        byte[] imageDataBytes = imageData.ToArray();
        string encodedImageData = Convert.ToBase64String(imageDataBytes);
        return $"data:{imageDataFormat};base64,{encodedImageData}";
    }
}
