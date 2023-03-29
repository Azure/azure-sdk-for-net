// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    /// model class
    /// </summary>
    public class ChatMessageDeletedEvent : ChatUserEvent
    {
        internal ChatMessageDeletedEvent(bool isRunningSynchronously, CancellationToken cancellationToken = default) : base(isRunningSynchronously, cancellationToken)
        {
        }

        /// <summary>
        /// Property
        /// </summary>
        public DateTimeOffset DeletedOn { get; }

        /// <summary>
        /// Property
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Property
        /// </summary>
        public string SenderDisplayName { get; }

        /// <summary>
        /// Property
        /// </summary>
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// Property
        /// </summary>
        public string Version { get; }
    }
}
