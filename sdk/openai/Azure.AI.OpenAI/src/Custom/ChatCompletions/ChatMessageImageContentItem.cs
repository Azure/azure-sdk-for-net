// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Mime;
using Azure.Core;

namespace Azure.AI.OpenAI;

public partial class ChatMessageImageContentItem : ChatMessageContentItem
{
    // CUSTOM CODE NOTE:
    //   This addition allows the direct use of a Uri with the content item constructor rather than needing an
    //   intervening instantiation of the Image URL type.

    /// <summary>
    /// The remote location from which the model should retrieve the provided image.
    /// </summary>
    /// <remarks>
    /// This field is mutually exclusive with <see cref="ImageData"/>. Instances of
    /// <see cref="ChatMessageImageContentItem"/> use either a URL or BinaryData image source.
    /// </remarks>
    public Uri ImageUri { get; }
    /// <summary>
    /// The binary image data the model should use for the ocntent item.
    /// </summary>
    /// <remarks>
    /// This field is mutually exclusive with <see cref="ImageUri"/>. Instances of
    /// <see cref="ChatMessageImageContentItem"/> use either a URL or BinaryData image source.
    /// </remarks>
    public BinaryData ImageData { get; }
    /// <summary>
    /// The image format identifier, e.g. 'image/jpeg', that describes the binary content of <see cref="ImageData"/>.
    /// This field is not used when instead providing a URL.
    /// </summary>
    public string ImageDataFormat { get; }
    /// <inheritdoc cref="InternalChatMessageImageUrl.Detail"/>
    public ChatMessageImageDetailLevel? DetailLevel => InternalImageUrlOrData.Detail;

    internal InternalChatMessageImageUrl InternalImageUrlOrData { get; }

    /// <summary> Initializes a new instance of ChatMessageImageContentItem using default detail. </summary>
    /// <param name="imageUri"> An internet location, which must be accessible to the model,from which the image may be retrieved. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="imageUri"/> is null. </exception>
    public ChatMessageImageContentItem(Uri imageUri)
        : this(new InternalChatMessageImageUrl(imageUri.AbsoluteUri))
    {
        ImageUri = imageUri;
    }

    /// <summary> Initializes a new instance of ChatMessageImageContentItem. </summary>
    /// <param name="imageUri"> An internet location, which must be accessible to the model,from which the image may be retrieved. </param>
    /// <param name="detailLevel"> The image detail level the model should use when evaluating the image. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="imageUri"/> is null. </exception>
    public ChatMessageImageContentItem(Uri imageUri, ChatMessageImageDetailLevel detailLevel)
        : this(new InternalChatMessageImageUrl(imageUri.AbsoluteUri, detailLevel))
    {
        ImageUri = imageUri;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatMessageImageContentItem"/> using JPEG image data and the
    /// default <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="jpegImageData"> The image data to provide to the model. </param>
    public ChatMessageImageContentItem(BinaryData jpegImageData)
        : this(new InternalChatMessageImageUrl(jpegImageData))
    {
        ImageData = jpegImageData;
        ImageDataFormat = MediaTypeNames.Image.Jpeg;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatMessageImageContentItem"/> using JPEG image data and a
    /// specified <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="jpegImageData"> The image data to provide to the model. </param>
    /// <param name="detailLevel"> The detail level to use when processing the provided image data. </param>
    public ChatMessageImageContentItem(BinaryData jpegImageData, ChatMessageImageDetailLevel detailLevel)
        : this(new InternalChatMessageImageUrl(jpegImageData, detailLevel))
    {
        ImageData = jpegImageData;
        ImageDataFormat = MediaTypeNames.Image.Jpeg;
        // detailLevel is retaiend via InternalChatMessageImageUrl
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatMessageImageContentItem"/> using image data in a specified format
    /// and the default <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="imageData"> The image data to provide to the model. </param>
    /// <param name="imageDataFormat"> The image format string, e.g. 'image/jpeg', associated with the data. </param>
    public ChatMessageImageContentItem(BinaryData imageData, string imageDataFormat)
        : this(new InternalChatMessageImageUrl(imageData, imageDataFormat))
    {
        ImageData = imageData;
        ImageDataFormat = imageDataFormat;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ChatMessageImageContentItem"/> using image data in a specified format
    /// and a specified <see cref="ChatMessageImageDetailLevel"/> setting.
    /// </summary>
    /// <param name="imageData"> The image data to provide to the model. </param>
    /// <param name="imageDataFormat"> The image format string, e.g. 'image/jpeg', associated with the data. </param>
    /// <param name="detailLevel"> The detail level to use when processing the provided image data. </param>
    public ChatMessageImageContentItem(BinaryData imageData, string imageDataFormat, ChatMessageImageDetailLevel detailLevel)
        : this(new InternalChatMessageImageUrl(imageData, imageDataFormat, detailLevel))
    {
        ImageData = imageData;
        ImageDataFormat = imageDataFormat;
        // detailLevel is retaiend via InternalChatMessageImageUrl
    }

    /// <summary> Initializes a new instance of <see cref="ChatMessageImageContentItem"/>. </summary>
    /// <param name="imageUrl"> An internet location, which must be accessible to the model,from which the image may be retrieved. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="imageUrl"/> is null. </exception>
    internal ChatMessageImageContentItem(InternalChatMessageImageUrl imageUrl)
    {
        Argument.AssertNotNull(imageUrl, nameof(imageUrl));

        Type = "image_url";
        InternalImageUrlOrData = imageUrl;
    }

    /// <summary> Initializes a new instance of <see cref="ChatMessageImageContentItem"/>. </summary>
    /// <param name="type"> The discriminated object type. </param>
    /// <param name="imageUrl"> An internet location, which must be accessible to the model,from which the image may be retrieved. </param>
    internal ChatMessageImageContentItem(string type, InternalChatMessageImageUrl imageUrl) : base(type)
    {
        InternalImageUrlOrData = imageUrl;
    }
}
