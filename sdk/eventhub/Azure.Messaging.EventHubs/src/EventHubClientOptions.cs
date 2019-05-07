// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Net;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="EventHubClient" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class EventHubClientOptions
    {
        /// <summary>
        ///   The version of the Event Hubs service API that the client should use for
        ///   operations.
        /// </summary>
        ///
        public ServiceVersion ServiceVersion { get; protected set; }

        /// <summary>
        ///   The policy to use for determining whether a failed operation should be retried and,
        ///   if so, the amount of time to wait between retry attempts.
        /// </summary>
        ///
        public RetryPolicy RetryPolicy { get; set; } = RetryPolicy.Default;

        /// <summary>
        ///   The type of connection that will be used for communicating with the Event Hubs
        ///   service.
        /// </summary>
        ///
        public ConnectionType ConnectionType { get; set; } = ConnectionType.AmqpTcp;

        /// <summary>
        ///   Gets or sets the timeout that will be used by default for operations associated with
        ///   the requested Event Hub.
        /// </summary>
        ///
        public TimeSpan OperationTimeout { get; set; } = TimeSpan.FromMinutes(1);

        /// <summary>
        ///   The proxy to use for communication over web sockets.  If not specified,
        ///   the system-wide proxy settings will be honored.
        /// </summary>
        ///
        /// <remarks>
        ///   A proxy cannot be used for communication over TCP; if web sockets are not in
        ///   use, any specified proxy will be ignored.
        /// </remarks>
        ///
        public IWebProxy Proxy { get; set; } = null;

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClientOptions"/> class.
        /// </summary>
        ///
        /// <param name="serviceVersion">The version of the Event Hubs service API that the client should use for operations.</param>
        ///
        public EventHubClientOptions(ServiceVersion serviceVersion)
        {
            ServiceVersion = serviceVersion;
        }

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" />, is equal to this instance.
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
