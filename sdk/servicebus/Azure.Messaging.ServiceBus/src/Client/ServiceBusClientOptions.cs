﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
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
        /// The set of options to use for determining whether a failed operation should be retried and,
        /// if so, the amount of time to wait between retry attempts.  These options also control the
        /// amount of time allowed for receiving messages and other interactions with the Service Bus service.
        /// </summary>
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
        /// Gets or sets whether or not to enable metrics for the associated <see cref="ServiceBusClient"/> instance.
        /// If set to <value>true</value>, <see cref="ServiceBusClient.GetTransportMetrics"/> can be called.
        /// </summary>
        internal bool EnableTransportMetrics { get; set; }

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
                EnableTransportMetrics = EnableTransportMetrics
            };
    }
}
