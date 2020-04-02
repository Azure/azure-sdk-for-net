﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Messaging.ServiceBus.Core
{
    /// <summary>
    ///   The set of extension methods for the <see cref="ServiceBusTransportType" /> enumeration.
    /// </summary>
    ///
    internal static class TransportTypeExtensions
    {
        /// <summary>The URI scheme used for an AMQP-based connection.</summary>
        private const string AmqpUriScheme = "amqps";

        /// <summary>
        ///   Determines the URI scheme to be used for the given connection type.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        ///
        /// <returns>The scheme that should be used for the given connection type when forming an associated URI.</returns>
        ///
        public static string GetUriScheme(this ServiceBusTransportType instance)
        {
            switch (instance)
            {
                case ServiceBusTransportType.AmqpTcp:
                case ServiceBusTransportType.AmqpWebSockets:
                    return AmqpUriScheme;

                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidTransportType, instance.ToString(), nameof(instance)));
            }
        }

        /// <summary>
        ///   Determines whether the specified transport makes use of web sockets.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        ///
        /// <returns><c>true</c> if the transport uses web sockets; otherwise, <c>false</c>.</returns>
        ///
        public static bool IsWebSocketTransport(this ServiceBusTransportType instance) => (instance == ServiceBusTransportType.AmqpWebSockets);
    }
}
