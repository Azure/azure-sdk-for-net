// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   The set of extension methods for the <see cref="EventHubsTransportType" /> enumeration.
    /// </summary>
    ///
    internal static class TransportTypeExtensions
    {
        /// <summary>The URI scheme used for a TLS-secured AMQP-based connection.</summary>
        private const string AmqpTlsUriScheme = "amqps";

        /// <summary>The URI scheme used for an insecure AMQP-based connection.</summary>
        private const string AmqpInsecureUriScheme = "amqp";

        /// <summary>
        ///   Determines the URI scheme to be used for the given connection type.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        /// <param name="useTls"><c>true</c> if the scheme should be for a TLS-secured connection; otherwise, <c>false</c>.</param>
        ///
        /// <returns>The scheme that should be used for the given connection type when forming an associated URI.</returns>
        ///
        public static string GetUriScheme(this EventHubsTransportType instance,
                                          bool useTls = true)
        {
            switch (instance)
            {
                case EventHubsTransportType.AmqpTcp when useTls:
                case EventHubsTransportType.AmqpWebSockets when useTls:
                    return AmqpTlsUriScheme;

                case EventHubsTransportType.AmqpTcp:
                case EventHubsTransportType.AmqpWebSockets:
                    return AmqpInsecureUriScheme;

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
        public static bool IsWebSocketTransport(this EventHubsTransportType instance) => (instance == EventHubsTransportType.AmqpWebSockets);
    }
}
