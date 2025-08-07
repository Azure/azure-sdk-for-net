// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.AI.Inference
{
    // CUSTOM CODE NOTE:
    //  This nested type is internalized to facilitate better abstraction of internet- vs. local-data-based images via
    //  ChatMessageImageContentItem.

    internal partial class ChatMessageImageUrl
    {
        /// <summary> The URL of the image. </summary>
        public string Url { get; }

        public ChatMessageImageUrl(Uri uri, ChatMessageImageDetailLevel? detailLevel)
        {
            Url = uri.AbsoluteUri;
            Detail = detailLevel;
        }

        public ChatMessageImageUrl(BinaryData bytes, string mimeType, ChatMessageImageDetailLevel? detailLevel)
        {
            string base64ImageData = Convert.ToBase64String(bytes.ToArray());
            Url = $"data:{mimeType};base64,{base64ImageData}";
            Detail = detailLevel;
        }

        public ChatMessageImageUrl(Stream stream, string mimeType, ChatMessageImageDetailLevel? detailLevel)
            : this(BinaryData.FromStream(stream), mimeType, detailLevel)
        { }
    }
}
