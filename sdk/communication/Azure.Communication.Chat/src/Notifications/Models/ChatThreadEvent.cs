// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    /// Property
    /// </summary>
    public abstract class ChatThreadEvent : ChatEvent
    {
        internal ChatThreadEvent(bool isRunningSynchronously, CancellationToken cancellationToken = default) : base(isRunningSynchronously, cancellationToken)
        {
        }

        /// <summary>
        /// Property
        /// </summary>
        public string Version { get; }
    }
#pragma warning restore CS1591
}
