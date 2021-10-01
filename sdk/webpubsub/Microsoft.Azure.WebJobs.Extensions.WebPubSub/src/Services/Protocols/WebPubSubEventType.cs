// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// Event type.
    /// </summary>
    public enum WebPubSubEventType
    {
        /// <summary>
        /// system event, including connect, connected, disconnected.
        /// </summary>
        System,
        /// <summary>
        /// user event.
        /// </summary>
        User
    }
}
