// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    /// <summary>
    /// AMQP Transport Type
    /// </summary>
    public enum TransportType
    {
        /// <summary>
        /// Uses AMQP over TCP.
        /// <remarks>This is the default value.</remarks>
        /// </summary>
        Amqp = 0,
        /// <summary>
        /// Uses AMQP over WebSockets
        /// </summary>
        AmqpWebSockets = 1
    }
}
