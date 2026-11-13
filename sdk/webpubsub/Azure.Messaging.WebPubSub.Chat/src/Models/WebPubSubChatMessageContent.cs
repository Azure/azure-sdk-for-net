// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Messaging.WebPubSub.Chat
{
    [CodeGenSuppress("WebPubSubChatMessageContent")]
    public partial class WebPubSubChatMessageContent
    {
        internal WebPubSubChatMessageContent()
        {
        }

        /// <summary> Gets the text content. </summary>
        public string Text { get; }

        /// <summary> Gets the binary content, serialized as a Base64-encoded string. </summary>
        public BinaryData Binary { get; }

        /// <summary> Creates message content containing text. </summary>
        /// <param name="text"> The text content. </param>
        /// <returns> Message content containing only text. </returns>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        public static WebPubSubChatMessageContent FromText(string text)
        {
            Argument.AssertNotNull(text, nameof(text));

            return new WebPubSubChatMessageContent(text, null, additionalBinaryDataProperties: null);
        }

        /// <summary> Creates message content containing binary data. </summary>
        /// <param name="binary"> The binary content. </param>
        /// <returns> Message content containing only binary data. </returns>
        /// <exception cref="ArgumentNullException"> <paramref name="binary"/> is null. </exception>
        public static WebPubSubChatMessageContent FromBinary(BinaryData binary)
        {
            Argument.AssertNotNull(binary, nameof(binary));

            return new WebPubSubChatMessageContent(null, binary, additionalBinaryDataProperties: null);
        }
    }
}
