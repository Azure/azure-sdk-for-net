// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    ///
    /// </summary>
    public class TypingIndicatorReceivedEvent : ChatUserEvent
    {
        internal TypingIndicatorReceivedEvent(bool isRunningSynchronously, CancellationToken cancellationToken = default) : base(isRunningSynchronously, cancellationToken)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public string Version { get; }

        /// <summary>
        ///
        /// </summary>
        public DateTimeOffset ReceivedOn { get; }

        /// <summary>
        ///
        /// </summary>
        public string SenderDisplayName { get; }
    }
}
