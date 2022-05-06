// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Chat
{
    /// <summary> Options for the notification message. </summary>
    public class SendNotificationOptions
    {
        /// <summary> The from identifier that is owned by the authenticated account. </summary>
        public string From { get; set; }
        /// <summary> The channel user identifiers of the recipient. </summary>
        public string To { get; set; }
        /// <summary> The cross-platform messaging notification type. </summary>
        public NotificationType? Type { get; set; }
        /// <summary> Broadcasr chat message content. </summary>
        public string Content { get; set; }
        /// <summary> The media Object. </summary>
        public NotificationMedia Media { get; set; }
        /// <summary> The template object used to create message templates. </summary>
        public NotificationTemplate Template { get; set; }
    }
}
