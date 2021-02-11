// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The mode in which links will be closed.
    /// </summary>
    internal enum LinkCloseMode
    {
        /// <summary>
        /// The link will be detached when closing.
        /// </summary>
        Detach = 0
    }
}
