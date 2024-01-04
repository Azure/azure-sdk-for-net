// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.OpenAI;

public partial class ChatMessageImageContentItem : ChatMessageContentItem
{
    // CUSTOM CODE NOTE:
    //   This addition allows the direct use of a Uri with the content item constructor rather than needing an
    //   intervening instantiation of the Image URL type.

    /// <inheritdoc cref="ChatMessageImageUrl.Url" />
    public Uri Url => ImageUrl.Url;

    /// <inheritdoc cref="ChatMessageImageUrl.ImageData" />
    public BinaryData Data => ImageUrl.ImageData;

    /// <summary> An internet location, which must be accessible to the model,from which the image may be retrieved. </summary>
    internal ChatMessageImageUrl ImageUrl { get; }

    /// <summary> Initializes a new instance of ChatMessageImageContentItem using default detail. </summary>
    /// <param name="imageUri"> An internet location, which must be accessible to the model,from which the image may be retrieved. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="imageUri"/> is null. </exception>
    public ChatMessageImageContentItem(Uri imageUri)
        : this(new ChatMessageImageUrl(imageUri))
    { }

    /// <summary> Initializes a new instance of ChatMessageImageContentItem. </summary>
    /// <param name="imageUri"> An internet location, which must be accessible to the model,from which the image may be retrieved. </param>
    /// <param name="detailLevel"> The image detail level the model should use when evaluating the image. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="imageUri"/> is null. </exception>
    public ChatMessageImageContentItem(Uri imageUri, ChatMessageImageDetailLevel detailLevel)
        : this(new ChatMessageImageUrl(imageUri, detailLevel))
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatMessageImageContentItem"/> using JPEG image data and the
    /// default <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="imageData"> The image data to provide to the model. </param>
    public ChatMessageImageContentItem(BinaryData imageData)
        : this(new ChatMessageImageUrl(imageData))
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatMessageImageContentItem"/> using JPEG image data and a
    /// specified <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="imageData"> The image data to provide to the model. </param>
    /// <param name="detailLevel"> The detail level to use when processing the provided image data. </param>
    public ChatMessageImageContentItem(BinaryData imageData, ChatMessageImageDetailLevel detailLevel)
        : this(new ChatMessageImageUrl(imageData, detailLevel))
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatMessageImageContentItem"/> using image data in a specified format
    /// and the default <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="imageData"> The image data to provide to the model. </param>
    /// <param name="imageDataFormat"> The image format string, e.g. 'image/jpeg', associated with the data. </param>
    public ChatMessageImageContentItem(BinaryData imageData, string imageDataFormat)
        : this(new ChatMessageImageUrl(imageData, imageDataFormat))
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatMessageImageContentItem"/> using image data in a specified format
    /// and a specified <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="imageData"> The image data to provide to the model. </param>
    /// <param name="imageDataFormat"> The image format string, e.g. 'image/jpeg', associated with the data. </param>
    /// <param name="detailLevel"> The detail level to use when processing the provided image data. </param>
    public ChatMessageImageContentItem(BinaryData imageData, string imageDataFormat, ChatMessageImageDetailLevel detailLevel)
        : this(new ChatMessageImageUrl(imageData, imageDataFormat, detailLevel))
    { }

    /// <summary> Initializes a new instance of <see cref="ChatMessageImageContentItem"/>. </summary>
    /// <param name="imageUrl"> An internet location, which must be accessible to the model,from which the image may be retrieved. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="imageUrl"/> is null. </exception>
    internal ChatMessageImageContentItem(ChatMessageImageUrl imageUrl)
    {
        Argument.AssertNotNull(imageUrl, nameof(imageUrl));

        Type = "image_url";
        ImageUrl = imageUrl;
    }

    /// <summary> Initializes a new instance of <see cref="ChatMessageImageContentItem"/>. </summary>
    /// <param name="type"> The discriminated object type. </param>
    /// <param name="imageUrl"> An internet location, which must be accessible to the model,from which the image may be retrieved. </param>
    internal ChatMessageImageContentItem(string type, ChatMessageImageUrl imageUrl) : base(type)
    {
        ImageUrl = imageUrl;
    }
}
