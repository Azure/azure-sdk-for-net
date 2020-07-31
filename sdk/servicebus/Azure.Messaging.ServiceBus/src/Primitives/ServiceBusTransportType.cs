// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   Specifies the type of protocol and transport that will be used for communicating with
    ///   Azure Service Bus.
    /// </summary>
    ///
    public enum ServiceBusTransportType
    {
        /// <summary>The connection uses the AMQP protocol over TCP.</summary>
        AmqpTcp,

        /// <summary>The connection uses the AMQP protocol over web sockets.</summary>
        AmqpWebSockets
    }
}
