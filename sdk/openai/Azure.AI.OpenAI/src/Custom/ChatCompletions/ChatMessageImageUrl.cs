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
internal partial class ChatMessageImageUrl
{
    /// <summary> The remote URL of the image, which must be accessible to the model. </summary>
    /// <remarks> The use of a remote URL is mutually exclusive with <see cref="ImageData"/>. </remarks>
    [CodeGenMemberSerializationHooks(SerializationValueHook = nameof(SerializeImage))]
    public Uri Url { get; }

    /// <summary> The local image data to provide to the model. </summary>
    /// <remarks> The use of a remote URL is mutually exclusive with <see cref="Url"/>. </remarks>
    public BinaryData ImageData { get; }

    /// <summary>
    /// The string format representation of the image data, e.g. 'image/jpeg'.
    /// </summary>
    /// <remarks>
    /// <see cref="MediaTypeNames.Image"/> provides a convenient collection of possible formats.
    /// <see cref="MediaTypeNames.Image.Jpeg"/> is the default format when not otherwise provided.
    /// </remarks>
    public string ImageDataFormat { get; }

    /// <summary>
    /// Creates a new instance of <see cref="ChatMessageImageUrl"/> using local JPEG image data and the default
    /// <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="jpegImageData"> The local image data to provide to the model. </param>
    public ChatMessageImageUrl(BinaryData jpegImageData)
        : this(jpegImageData, MediaTypeNames.Image.Jpeg)
    {
        Argument.AssertNotNull(jpegImageData, nameof(jpegImageData));
    }

    /// <summary>
    /// Creates a new instance of <see cref="ChatMessageImageUrl"/> using local image data in a specified format and
    /// the default <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="imageData"> The local image data to provide to the model. </param>
    /// <param name="imageDataFormat"> The image format, e.g. 'image/jpeg', for the image data. </param>
    public ChatMessageImageUrl(BinaryData imageData, string imageDataFormat)
    {
        Argument.AssertNotNull(imageData, nameof(imageData));
        Argument.AssertNotNull(imageDataFormat, nameof(imageDataFormat));
        ImageData = imageData;
        ImageDataFormat = imageDataFormat;
    }

    /// <summary>
    /// Creates a new instance of <see cref="ChatMessageImageUrl"/> using local JPEG image data and a specified
    /// <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="jpegImageData"> The local image data to provide to the model. </param>
    /// <param name="detail"> The detail level to use when processing the provided image data. </param>
    public ChatMessageImageUrl(BinaryData jpegImageData, ChatMessageImageDetailLevel detail)
        : this(jpegImageData, MediaTypeNames.Image.Jpeg, detail)
    {
        Argument.AssertNotNull(jpegImageData, nameof(jpegImageData));
        Argument.AssertNotNull(detail, nameof(detail));
    }

    /// <summary>
    /// Creates a new instance of <see cref="ChatMessageImageUrl"/> using local image data in a specified format and
    /// a specified <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="imageData"> The local image data to provide to the model. </param>
    /// <param name="imageDataFormat"> The image format, e.g. 'image/jpeg', for the image data. </param>
    /// <param name="detail"> The detail level to use when processing the provided image data. </param>
    public ChatMessageImageUrl(BinaryData imageData, string imageDataFormat, ChatMessageImageDetailLevel detail)
    {
        ImageData = imageData;
        ImageDataFormat = imageDataFormat;
        Detail = detail;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SerializeImage(Utf8JsonWriter writer)
    {
        if (Optional.IsDefined(Url))
        {
            writer.WriteStringValue(Url.AbsoluteUri);
        }
        else if (Optional.IsDefined(ImageData))
        {
            writer.WriteStringValue($"data:{ImageDataFormat};base64,{Convert.ToBase64String(ImageData.ToArray())}");
        }
    }
}
