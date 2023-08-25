// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Net;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="ServiceBusConnection" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class ServiceBusClientOptions
    {
        private ServiceBusRetryOptions _retryOptions = new ServiceBusRetryOptions();
        private TimeSpan _connectionIdleTimeout = TimeSpan.FromMinutes(1);

        /// <summary>
        ///   The type of protocol and transport that will be used for communicating with the Service Bus
        ///   service.
        /// </summary>
        ///
        public ServiceBusTransportType TransportType { get; set; } = ServiceBusTransportType.AmqpTcp;

        /// <summary>
        ///   The proxy to use for communication over web sockets.
        /// </summary>
        ///
        /// <remarks>
        ///   A proxy cannot be used for communication over TCP; if web sockets are not in
        ///   use, specifying a proxy is an invalid option.
        /// </remarks>
        ///
        public IWebProxy WebProxy { get; set; }

        /// <summary>
        /// A property used to set the <see cref="ServiceBusClient"/> ID to identify the client. This can be used to correlate logs
        /// and exceptions. If <c>null</c> or empty, a random unique value will be used.
        /// </summary>
        ///
        public string Identifier { get; set; }

        /// <summary>
        ///   A custom endpoint address that can be used when establishing the connection to the Service Bus
        ///   service.
        /// </summary>
        ///
        /// <remarks>
        ///   The custom endpoint address will be used in place of the default endpoint provided by the Service
        ///   Bus namespace when establishing the connection. The connection string or fully qualified namespace
        ///   will still be needed in order to validate the connection with the service.
        /// </remarks>
        ///
        public Uri CustomEndpointAddress { get; set; }

        /// <summary>
        ///   The amount of time to allow a connection to have no observed traffic before considering
        ///   it idle and eligible to close.
        /// </summary>
        ///
        /// <value>The default idle timeout is 60 seconds.  The timeout must be a positive value.</value>
        ///
        /// <remarks>
        ///   If a connection is closed due to being idle, the <see cref="ServiceBusClient" /> will automatically
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
        /// The set of options to use for determining whether a failed service operation should be retried and,
        /// if so, the amount of time to wait between retry attempts.  These options also control the
        /// amount of time allowed for the individual network operations used for interactions with the Service Bus service.
        /// </summary>
        /// <remarks>
        /// The retry options are only considered for interactions with the Service Bus service. They do not apply to failures in the
        /// <see cref="ServiceBusProcessor.ProcessMessageAsync" /> handler. Developers are responsible for error handling and retries
        /// as part of their event handler.
        ///</remarks>
        public ServiceBusRetryOptions RetryOptions
        {
            get => _retryOptions;
            set
            {
                Argument.AssertNotNull(value, nameof(RetryOptions));
                _retryOptions = value;
            }
        }

        /// <summary>
        /// Gets or sets a flag that indicates whether or not transactions may span multiple
        /// Service Bus entities.
        /// </summary>
        ///<value>
        /// <c>true</c>, when cross-entity transactions are enabled; <c>false</c> when
        /// transactions are not being used or should be limited to a single entity.
        ///</value>
        public bool EnableCrossEntityTransactions { get; set; }

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

        /// <summary>
        ///   Creates a new copy of the current <see cref="ServiceBusClientOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="ServiceBusClientOptions" />.</returns>
        ///
        internal ServiceBusClientOptions Clone() =>
            new ServiceBusClientOptions
            {
                TransportType = TransportType,
                WebProxy = WebProxy,
                RetryOptions = RetryOptions.Clone(),
                EnableCrossEntityTransactions = EnableCrossEntityTransactions,
                CustomEndpointAddress = CustomEndpointAddress,
                ConnectionIdleTimeout = ConnectionIdleTimeout,
                Identifier = Identifier
            };
    }
}
