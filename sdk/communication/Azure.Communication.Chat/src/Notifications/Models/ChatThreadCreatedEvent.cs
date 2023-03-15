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
    public class ChatThreadCreatedEvent : ChatThreadEvent
    {
        internal ChatThreadCreatedEvent(bool isRunningSynchronously, CancellationToken cancellationToken = default) : base(isRunningSynchronously, cancellationToken)
        {
        }

        /// <summary>
        /// Property
        /// </summary>
        public DateTimeOffset? CreatedOn { get; }

        /// <summary>
        /// Property
        /// </summary>
        public ChatThreadProperties Properties { get; }

        /// <summary>
        /// Property
        /// </summary>
        public List<ChatParticipant> Participants { get; } = new List<ChatParticipant>();

        /// <summary>
        /// Property
        /// </summary>
        public ChatParticipant CreatedBy { get; }
    }
}
