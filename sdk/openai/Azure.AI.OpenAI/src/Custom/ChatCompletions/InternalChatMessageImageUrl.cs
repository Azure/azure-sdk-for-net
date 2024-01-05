// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI;

// CUSTOM CODE NOTE:
//  These changes facilitate the additional use of BinaryData and also hiding the interior type.

/// <summary> An internet location from which the model may retrieve an image. </summary>
internal partial class InternalChatMessageImageUrl
{
    /// <summary>
    /// Creates a new instance of <see cref="InternalChatMessageImageUrl"/> using local image data in a specified format and
    /// the default <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="imageData"> The local image data to provide to the model. </param>
    /// <param name="imageDataFormat"> The image format, e.g. 'image/jpeg', for the image data. </param>
    /// <param name="detailLevel"> The detail level to use when processing the provided image data. </param>
    public InternalChatMessageImageUrl(BinaryData imageData, string imageDataFormat, ChatMessageImageDetailLevel? detailLevel = null)
    {
        Argument.AssertNotNull(imageData, nameof(imageData));
        Argument.AssertNotNull(imageDataFormat, nameof(imageDataFormat));
        byte[] imageDataBytes = imageData.ToArray();
        string encodedImageData = Convert.ToBase64String(imageDataBytes);
        UrlOrEncodedData = $"data:{imageDataFormat};base64,{encodedImageData}";
        Detail = detailLevel;
    }
}
