// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Messaging.WebPubSub.Chat
{
    // PATCH uses UpdateMessageOptions; preserve the original required-argument constructor.
    [CodeGenSuppress("WebPubSubChatMessage")]
    public partial class WebPubSubChatMessage
    {
        // ModelReaderWriter needs a non-public parameterless constructor for deserialization.
        internal WebPubSubChatMessage()
        {
        }

        /// <summary> Initializes a new instance of <see cref="WebPubSubChatMessage"/>. </summary>
        /// <param name="createdBy"> User who created the message. </param>
        /// <param name="content"> Message content. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="createdBy"/> or <paramref name="content"/> is null. </exception>
        public WebPubSubChatMessage(string createdBy, WebPubSubChatMessageContent content)
        {
            Argument.AssertNotNull(createdBy, nameof(createdBy));
            Argument.AssertNotNull(content, nameof(content));

            CreatedBy = createdBy;
            Content = content;
        }
    }
}
