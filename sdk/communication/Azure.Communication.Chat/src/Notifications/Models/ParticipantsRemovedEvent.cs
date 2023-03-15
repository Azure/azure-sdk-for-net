// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    /// Moddel Class
    /// </summary>
    public class ParticipantsRemovedEvent : ChatThreadEvent
    {
        internal ParticipantsRemovedEvent(bool isRunningSynchronously, CancellationToken cancellationToken = default) : base(isRunningSynchronously, cancellationToken)
        {
        }

        /// <summary>
        /// Property
        /// </summary>
        public DateTimeOffset? RemovedOn { get; }

        /// <summary>
        /// Property
        /// </summary>
        public ChatParticipant RemovedBy { get; }

        /// <summary>
        /// Property
        /// </summary>
        public List<ChatParticipant> ParticipantsRemoved { get; } = new List<ChatParticipant>();
    }
}
