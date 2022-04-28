// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// A set of metrics that can be used to monitor communication between the client and service.
    /// </summary>
    public class ServiceBusTransportMetrics
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusTransportMetrics"/> class for mocking.
        /// </summary>
        protected internal ServiceBusTransportMetrics()
        {
        }

        /// <summary>
        /// Gets the last time that a heartbeat was received from the Service Bus service. These heartbeats are sent from the
        /// service approximately every 30 seconds.
        /// </summary>
        public DateTimeOffset? LastHeartBeat { get; internal set; }

        /// <summary>
        /// Gets the last time that a connection was opened for the associated <see cref="ServiceBusClient"/> instance.
        /// </summary>
        public DateTimeOffset? LastConnectionOpen { get; internal set; }

        /// <summary>
        /// Gets the last time that a connection was closed for the associated <see cref="ServiceBusClient"/> instance. If the <see cref="ServiceBusClient"/>
        /// was disposed, then this time will not be updated again. It may be updated multiple times if the close is initiated by the service.
        /// </summary>
        public DateTimeOffset? LastConnectionClose { get; internal set; }

        internal ServiceBusTransportMetrics Clone() =>
            new()
            {
                LastHeartBeat = LastHeartBeat,
                LastConnectionOpen = LastConnectionOpen,
                LastConnectionClose = LastConnectionClose
            };
    }
}