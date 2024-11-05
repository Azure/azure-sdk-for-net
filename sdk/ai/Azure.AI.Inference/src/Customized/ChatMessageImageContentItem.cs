// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace Azure.AI.Inference
{
    public partial class ChatMessageImageContentItem : ChatMessageContentItem
    {
        // CUSTOM CODE NOTE:
        //   - Hide the ImageUrl property for easier, direct use of the content item
        //   - Provide custom Uri, BinaryData, and Stream constructors

        internal ChatMessageImageUrl ImageUrl { get; }

        /// <summary>
        /// Initializes a new instance of ChatMessageImageContentItem that refers to an image at another location via URL.
        /// </summary>
        /// <remarks>
        /// This constructor should only be used for file references. To use binary data, streams, or a file directly,
        /// please refer to the alternate constructors.
        /// </remarks>
        /// <param name="imageUri"> An internet location, which must be accessible to the model, from which the image may be retrieved. </param>
        /// <param name="detailLevel"> The image detail level the model should use when evaluating the image. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageUri"/> is null. </exception>
        public ChatMessageImageContentItem(Uri imageUri, ChatMessageImageDetailLevel? detailLevel = null)
            : this(new ChatMessageImageUrl(imageUri, detailLevel))
        { }

        /// <summary>
        /// Initializes a new instance of ChatMessageImageContentItem from a BinaryData instance containing image
        /// information in a known format.
        /// </summary>
        /// <param name="bytes"> The image data to provide as content. </param>
        /// <param name="mimeType"> The MIME type, e.g. <c>image/png</c>, matching the format of the image data. </param>
        /// <param name="detailLevel"> The image detail level the model should use when evaluating the image. </param>
        public ChatMessageImageContentItem(BinaryData bytes, string mimeType, ChatMessageImageDetailLevel? detailLevel = null)
            : this(new ChatMessageImageUrl(bytes, mimeType, detailLevel))
        { }

        /// <summary>
        /// Initializes a new instance of ChatMessageImageContentItem from a BinaryData instance containing image
        /// information in a known format.
        /// </summary>
        /// <param name="stream"> The image data to provide as content. </param>
        /// <param name="mimeType"> The MIME type, e.g. <c>image/png</c>, matching the format of the image data. </param>
        /// <param name="detailLevel"> The image detail level the model should use when evaluating the image. </param>
        public ChatMessageImageContentItem(Stream stream, string mimeType, ChatMessageImageDetailLevel? detailLevel = null)
            : this(new ChatMessageImageUrl(stream, mimeType, detailLevel))
        { }

        /// <summary>
        /// Initializes a new instance of ChatMessageImageContentItem from a file pointer to an image
        /// in a known format.
        /// </summary>
        /// <param name="imageFilePath"> The path to the image to use. </param>
        /// <param name="mimeType"> The MIME type, e.g. <c>image/png</c>, matching the format of the image data. </param>
        /// <param name="detailLevel"> The image detail level the model should use when evaluating the image. </param>
        public ChatMessageImageContentItem(string imageFilePath, string mimeType, ChatMessageImageDetailLevel? detailLevel = null)
        {
            Stream fileStream = File.OpenRead(imageFilePath);

            Type = "image_url";
            ImageUrl = new ChatMessageImageUrl(fileStream, mimeType, detailLevel);
        }

        /// <summary> Initializes a new instance of <see cref="ChatMessageImageContentItem"/>. </summary>
        /// <param name="imageUrl"> An internet location, which must be accessible to the model,from which the image may be retrieved. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageUrl"/> is null. </exception>
        internal ChatMessageImageContentItem(ChatMessageImageUrl imageUrl)
        {
            Argument.AssertNotNull(imageUrl, nameof(imageUrl));

            Type = "image_url";
            ImageUrl = imageUrl;
        }
    }
}
