// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    /// model class
    /// </summary>
    public class ParticipantsAddedEvent : ChatThreadEvent
    {
        internal ParticipantsAddedEvent(bool isRunningSynchronously, CancellationToken cancellationToken = default) : base(isRunningSynchronously, cancellationToken)
        {
        }

        /// <summary>
        /// Property
        /// </summary>
        public DateTimeOffset AddedOn { get; }

        /// <summary>
        /// Property
        /// </summary>
        public ChatParticipant AddedBy { get; }

        /// <summary>
        /// Property
        /// </summary>
        public List<ChatParticipant> ParticipantsAdded { get; } = new List<ChatParticipant>();
    }
}
