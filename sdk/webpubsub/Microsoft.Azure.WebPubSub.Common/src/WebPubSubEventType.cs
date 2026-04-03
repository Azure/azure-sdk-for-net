// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Event type.
    /// </summary>
    public enum WebPubSubEventType
    {
        /// <summary>
        /// system event, including connect, connected, disconnected.
        /// </summary>
        System = 0,
        /// <summary>
        /// user event.
        /// </summary>
        User = 1,
        /// <summary>
        /// group presence event.
        /// </summary>
        GroupPresence = 2
    }
}
