// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    /// <summary>
    /// Specifies the SKU/tier of the messaging namespace.
    /// </summary>
    public enum MessagingSku
    {
        /// <summary>
        /// Basic namespace. Shared Resource. Only queues are available.
        /// </summary>
        Basic = 1,

        /// <summary>
        /// Standard namespace. Shared Resource. Queues and topics.
        /// </summary>
        Standard = 2,

        /// <summary>
        /// Premium namespace. Dedicated Resource. Queues and topics.
        /// </summary>
        Premium = 3,

        /// <summary>
        /// Other SKUs.
        /// </summary>
        Others = 99
    }
}
