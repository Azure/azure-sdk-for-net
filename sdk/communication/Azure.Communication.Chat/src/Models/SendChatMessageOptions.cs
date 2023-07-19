// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.Chat
{
    /// <summary> Options for the chat message. </summary>
    public class SendChatMessageOptions
    {
        /// <summary>Content for the message</summary>
        public string Content { get; set; }
        /// <summary>The message type.</summary>
        public ChatMessageType MessageType { get; set; }
        /// <summary>The display name of the message sender. This property is used to populate sender name for push notifications.</summary>
        public string SenderDisplayName { get; set; }
        /// <summary> Properties bag for custom attributes to the message in the form of key-value pair. </summary>
        public IDictionary<string, string> Metadata { get; } = new Dictionary<string, string>();
    }
}
