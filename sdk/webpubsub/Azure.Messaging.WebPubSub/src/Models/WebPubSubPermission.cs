// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// Web PubSub permissions.
    /// </summary>
    [CodeGenModel("WebPubSubPermission")]
    public enum WebPubSubPermission
    {
        /// <summary>
        /// Permission to send messages to a group.
        /// </summary>
        SendToGroup = 1,

        /// <summary>
        /// Permission to join and leave a group.
        /// </summary>
        JoinLeaveGroup = 2
    }
}
