// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Chat
{
    /// <summary> Options for the notification message. </summary>
    public class SendThreadlessMessageOptions
    {
        /// <summary> The from identifier that is owned by the authenticated account. </summary>
        public string From { get; set; }
        /// <summary> The channel user identifiers of the recipient. </summary>
        public string To { get; set; }
        /// <summary> The cross-platform threadless message type. </summary>
        public ThreadlessMessageType? Type { get; set; }
        /// <summary> Threadless message content. </summary>
        public string Content { get; set; }
        /// <summary> The media Object. </summary>
        public MessageMedia Media { get; set; }
        /// <summary> The template object used to create message templates. </summary>
        public MessageTemplate Template { get; set; }
    }
}
