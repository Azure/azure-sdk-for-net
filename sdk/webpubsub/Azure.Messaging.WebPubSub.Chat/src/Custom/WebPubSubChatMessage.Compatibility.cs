// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.WebPubSub.Chat
{
    public partial class WebPubSubChatMessage
    {
        /// <summary> Initializes a new instance of <see cref="WebPubSubChatMessage"/>. </summary>
        /// <param name="createdBy"> The user who created the message. </param>
        /// <param name="content"> The message content. </param>
        /// <exception cref="ArgumentNullException"> An argument is null. </exception>
        public WebPubSubChatMessage(string createdBy, WebPubSubChatMessageContent content) : this()
        {
            if (createdBy is null)
            {
                throw new ArgumentNullException(nameof(createdBy));
            }

            if (content is null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            CreatedBy = createdBy;
            Content = content;
        }
    }
}
