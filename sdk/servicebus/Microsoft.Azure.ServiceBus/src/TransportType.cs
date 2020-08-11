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
        /// <remarks>This is the default value. It runs on port 5671. </remarks>
        /// </summary>
        Amqp = 0,

        /// <summary>
        /// Uses AMQP over WebSockets
        /// </summary>
        /// <remarks>This runs on port 443 with wss URI scheme. This could be used in scenarios where traffic to port 5671 is blocked. 
        /// To setup a proxy connection, please configure system default proxy. Proxy currently is supported only in  .NET 4.5.1 and higher or .NET Core 2.1 and higher.</remarks>
        AmqpWebSockets = 1
    }
}
