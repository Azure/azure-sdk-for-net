// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    /// Property
    /// </summary>
    public class ChatThreadDeletedEvent : ChatThreadEvent
    {
        internal ChatThreadDeletedEvent(bool isRunningSynchronously, CancellationToken cancellationToken = default) : base(isRunningSynchronously, cancellationToken)
        {
        }

        /// <summary>
        /// Property
        /// </summary>
        public DateTimeOffset? DeletedOn { get; }

        /// <summary>
        /// Property
        /// </summary>
        public ChatParticipant DeletedBy { get; }
    }
}
