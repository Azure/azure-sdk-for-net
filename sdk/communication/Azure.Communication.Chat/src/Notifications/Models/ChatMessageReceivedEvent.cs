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
    public class ChatMessageReceivedEvent : ChatUserEvent
    {
        internal ChatMessageReceivedEvent(bool isRunningSynchronously, CancellationToken cancellationToken = default) : base(isRunningSynchronously, cancellationToken)
        {
        }

        /// <summary>
        /// Property
        /// </summary>
        public ChatMessageType Type { get; }

        /// <summary>
        /// Property
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Property
        /// </summary>
        public string Priority { get; }
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
        public DateTimeOffset? CreatedOn { get; }

        /// <summary>
        /// Property
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Property
        /// </summary>
        public Dictionary<string, string> MetaData { get; } = new Dictionary<string, string>();
    }
}
