// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   Specifies the type of connection what will be used for communicating with
    ///   Azure Event Hubs.
    /// </summary>
    ///
    public enum ConnectionType
    {
        /// <summary>The connection uses the AMQP prototcol over TCP.</summary>
        AmqpTcp,

        /// <summary>The connection uses the AMQP prototcol over web sockets.</summary>
        AmqpWebSockets
    }
}
