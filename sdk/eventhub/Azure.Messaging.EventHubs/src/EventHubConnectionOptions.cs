// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using Azure.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="EventHubConnection" />
    ///   to configure its behavior.
    /// </summary>
    ///
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples">Event Hubs samples and discussion</seealso>
    ///
    public class EventHubConnectionOptions
    {
        // <summary>The amount of time to allow a connection to have no observed traffic before considering it idle.</summary>
        private TimeSpan _connectionIdleTimeout = TimeSpan.FromMinutes(1);

        /// <summary>
        ///   The type of protocol and transport that will be used for communicating with the Event Hubs
        ///   service.
        /// </summary>
        ///
        /// <value>The default transport is AMQP over TCP.</value>
        ///
        public EventHubsTransportType TransportType { get; set; } = EventHubsTransportType.AmqpTcp;

        /// <summary>
        ///   The amount of time to allow a connection to have no observed traffic before considering
        ///   it idle and eligible to close.
        /// </summary>
        ///
        /// <value>The default idle timeout is 60 seconds.  The timeout must be a positive value.</value>
        ///
        /// <remarks>
        ///   If a connection is closed due to being idle, the Event Hubs clients will automatically
        ///   reopen the connection when it is needed for a network operation.  An idle connection
        ///   being closed does not cause client errors or interfere with normal operation.
        ///
        ///   It is recommended to use the default value unless your application has special needs and
        ///   you've tested the impact of changing the idle timeout.
        /// </remarks>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested timeout is negative.</exception>
        ///
        public TimeSpan ConnectionIdleTimeout
        {
            get => _connectionIdleTimeout;
            set
            {
                Argument.AssertNotNegative(value, nameof(ConnectionIdleTimeout));
                _connectionIdleTimeout = value;
            }
        }

        /// <summary>
        ///   The size of the buffer used for sending information via the active transport.
        /// </summary>
        ///
        /// <value>The size of the buffer, in bytes.  The default value is -1, which instructs the transport to use the host's default buffer size.</value>
        ///
        /// <remarks>
        ///   This value is used to configure the <see cref="Socket.SendBufferSize" /> used by
        ///   the active transport.  It is recommended that the host's default buffer size be used
        ///   unless there is a specific application scenario that requires it to be adjusted and
        ///   the new value has been tested thoroughly.
        /// </remarks>
        ///
        public int SendBufferSizeInBytes { get; set; } = -1;

        /// <summary>
        ///   The size of the buffer used for receiving information via the active transport.
        /// </summary>
        ///
        /// <value>The size of the buffer, in bytes.  The default value is -1, which instructs the transport to use the host's default buffer size.</value>
        ///
        /// <remarks>
        ///   This value is used to configure the <see cref="Socket.ReceiveBufferSize" /> used by
        ///   the active transport.  It is recommended that the host's default buffer size be used
        ///   unless there is a specific application scenario that requires it to be adjusted and
        ///   the new value has been tested thoroughly.
        /// </remarks>
        ///
        public int ReceiveBufferSizeInBytes { get; set; } = -1;

        /// <summary>
        ///   The proxy to use for communication over web sockets.
        /// </summary>
        ///
        /// <remarks>
        ///   A proxy cannot be used for communication over TCP; if the <see cref="TransportType" /> is not set
        ///   to <see cref="EventHubsTransportType.AmqpWebSockets" />, specifying a proxy is invalid.
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
        ///   A <see cref="RemoteCertificateValidationCallback" /> delegate allowing custom logic to be considered for
        ///   validation of the remote certificate responsible for encrypting communication.
        /// </summary>
        ///
        /// <value>The callback will be invoked any time a connection is established, including any reconnect attempts.</value>
        ///
        public RemoteCertificateValidationCallback CertificateValidationCallback { get; set; }

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
