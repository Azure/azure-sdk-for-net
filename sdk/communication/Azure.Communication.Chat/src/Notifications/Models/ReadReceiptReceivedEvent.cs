// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Azure.Communication.Chat.Notifications.Models
{
    public class ReadReceiptReceivedEvent : ChatUserEvent
    {
        internal ReadReceiptReceivedEvent(bool isRunningSynchronously, CancellationToken cancellationToken = default) : base(isRunningSynchronously, cancellationToken)
        {
        }

        public string ChatMessageId { get; }

        public DateTimeOffset ReadOn { get; }
    }
}
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
