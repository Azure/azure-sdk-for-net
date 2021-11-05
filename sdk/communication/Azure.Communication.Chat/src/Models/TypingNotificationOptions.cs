// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Chat
{
    /// <summary> Options for the typing notification. </summary>
    public class TypingNotificationOptions
    {
        /// <summary>The display name of the message sender. This property is used to populate sender name for push notifications.</summary>
        public string SenderDisplayName { get; set; }
    }
}
