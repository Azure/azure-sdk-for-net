// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Azure.Communication.Chat.Notifications.Models
{
    public class ChatThreadPropertiesUpdatedEvent : ChatThreadEvent
    {
        internal ChatThreadPropertiesUpdatedEvent(bool isRunningSynchronously, CancellationToken cancellationToken = default) : base(isRunningSynchronously, cancellationToken)
        {
        }

        public ChatThreadProperties Properties { get; }

        public DateTimeOffset UpdatedOn { get; }

        public ChatParticipant UpdatedBy { get; }
    }
}
