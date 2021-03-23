// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Net;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="EventHubConnection" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class EventHubConnectionOptions
    {
        /// <summary>
        ///   The type of protocol and transport that will be used for communicating with the Event Hubs
        ///   service.
        /// </summary>
        ///
        /// <value>The default transport is AMQP over TCP.</value>
        ///
        public EventHubsTransportType TransportType { get; set; } = EventHubsTransportType.AmqpTcp;

        /// <summary>
        ///   The proxy to use for communication over web sockets.
        /// </summary>
        ///
        /// <remarks>
        ///   A proxy cannot be used for communication over TCP; if web sockets are not in
        ///   use, specifying a proxy is an invalid option.
        /// </remarks>
        ///
        public IWebProxy Proxy { get; set; }

        /// <summary>
        ///   The address to use for establishing a connection to the Event Hubs service, allowing network requests to be
        ///   routed through any application gateways or other paths needed for the host environment.
        /// </summary>
        ///
        /// <value>
        ///   This address will override the default endpoint of the Event Hubs namespace when making the network request
        ///   to the service.  The default endpoint specified in a connection string or by a fully qualified namespace will
        ///   still be needed to negotiate the connection with the Event Hubs service.
        /// </value>
        ///
        public Uri CustomEndpointAddress { get; set; }

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
