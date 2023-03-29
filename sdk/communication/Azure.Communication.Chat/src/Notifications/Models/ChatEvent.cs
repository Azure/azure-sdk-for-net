// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Communication.Chat.Notifications.Models
{
    /// <summary>
    /// Chat event
    /// </summary>
    public abstract class ChatEvent : SyncAsyncEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatEvent"/> class.
        /// </summary>
        /// <param name="isRunningSynchronously"></param>
        /// <param name="cancellationToken"></param>
        internal ChatEvent(bool isRunningSynchronously, CancellationToken cancellationToken = default) : base(isRunningSynchronously, cancellationToken)
        {
        }

        /// <summary>
        /// Chat Thread Id of the event.
        /// </summary>
        public string ThreadId { get; }
    }
}
