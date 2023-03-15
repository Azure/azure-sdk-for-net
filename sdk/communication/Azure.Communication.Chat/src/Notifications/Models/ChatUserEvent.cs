// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Communication.Chat.Notifications.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public abstract class ChatUserEvent : ChatEvent
    {
        internal ChatUserEvent(bool isRunningSynchronously, CancellationToken cancellationToken = default) : base(isRunningSynchronously, cancellationToken)
        {
        }
        public string senderId { get; }
        public string recipientMri { get; }
        public string recipientId { get; }
        public CommunicationIdentifier sender { get; }
        public CommunicationIdentifier recipient { get; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}
