// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Chat
{
    /// <summary> Options for the broadcast message. </summary>
    public class SendBroadcastMessageOptions
    {
        /// <summary> The from identifier that is owned by the authenticated account. </summary>
        public string From { get; set; }
        /// <summary> The channel user identifiers of the recipient. </summary>
        public string To { get; set; }
        /// <summary> The broadcast chat message type. </summary>
        public BroadcastChatMessageType? Type { get; set; }
        /// <summary> Broadcasr chat message content. </summary>
        public string Content { get; set; }
        /// <summary> The media Object. </summary>
        public ChatMedia Media { get; set; }
        /// <summary> The template object used to create message templates. </summary>
        public ChatTemplate Template { get; set; }
    }
}
