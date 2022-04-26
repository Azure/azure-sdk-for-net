// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The event args specified when the state of the connection with the service changes.
    /// </summary>
    public class ServiceBusConnectionEventArgs : EventArgs
    {
        /// <inheritdoc cref="ServiceBusClient.FullyQualifiedNamespace"/>
        public string FullyQualifiedNamespace { get; }

        /// <summary>
        /// The proxy being used when communicating with the service.
        /// </summary>
        public IWebProxy Proxy { get; }

        /// <inheritdoc cref="ServiceBusClient.TransportType"/>
        public ServiceBusTransportType TransportType { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="ServiceBusConnectionEventArgs"/>.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified namespace.</param>
        /// <param name="transportType">The transport type in use when communicating with the service.</param>
        /// <param name="proxy">The proxy being used when communicating with the service.</param>
        public ServiceBusConnectionEventArgs(string fullyQualifiedNamespace, ServiceBusTransportType transportType, IWebProxy proxy)
        {
            FullyQualifiedNamespace = fullyQualifiedNamespace;
            TransportType = transportType;
            Proxy = proxy;
        }
    }
}