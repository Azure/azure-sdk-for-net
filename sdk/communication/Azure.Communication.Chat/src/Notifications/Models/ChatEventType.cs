// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    /// model class
    /// </summary>
    internal sealed class ChatEventType
    {
        private ChatEventType(string value) { Value = value; }
        /// <summary>
        /// Property
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Property
        /// </summary>
        public static ChatEventType ChatMessageReceived { get { return new ChatEventType("chatMessageReceived"); } }
        /// <summary>
        /// Property
        /// </summary>
        public static ChatEventType ChatMessageEdited { get { return new ChatEventType("chatMessageEdited"); } }
        /// <summary>
        /// Property
        /// </summary>
        public static ChatEventType ChatMessageDeleted { get { return new ChatEventType("chatMessageDeleted"); } }
        /// <summary>
        /// Property
        /// </summary>
        public static ChatEventType TypingIndicatorReceived { get { return new ChatEventType("typingIndicatorReceived"); } }
        /// <summary>
        /// Property
        /// </summary>
        public static ChatEventType ReadReceiptReceived { get { return new ChatEventType("readReceiptReceived"); } }
        /// <summary>
        /// Property
        /// </summary>
        public static ChatEventType ChatThreadCreated { get { return new ChatEventType("chatThreadCreated"); } }
        /// <summary>
        /// Property
        /// </summary>
        public static ChatEventType ChatThreadDeleted { get { return new ChatEventType("chatThreadDeleted"); } }
        /// <summary>
        /// Property
        /// </summary>
        public static ChatEventType ChatThreadPropertiesUpdated { get { return new ChatEventType("chatThreadPropertiesUpdated"); } }
        /// <summary>
        /// Property
        /// </summary>
        public static ChatEventType ParticipantsAdded { get { return new ChatEventType("participantsAdded"); } }

        /// <summary>
        /// Property
        /// </summary>
        public static ChatEventType ParticipantsRemoved { get { return new ChatEventType("participantsRemoved"); } }

        /// <summary>
        /// Property
        /// </summary>
        public static ChatEventType RealTimeNotificationConnected { get { return new ChatEventType("realTimeNotificationConnected"); } }

        /// <summary>
        /// Property
        /// </summary>
        public static ChatEventType RealTimeNotificationDisconnected { get { return new ChatEventType("realTimeNotificationDisconnected"); } }

        /// <summary>
        /// Property
        /// </summary>
        public override string ToString()
        {
            return Value;
        }
    }
}
