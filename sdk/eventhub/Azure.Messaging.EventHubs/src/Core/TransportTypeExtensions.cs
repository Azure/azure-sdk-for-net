// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   The set of extension methods for the <see cref="TransportType" /> enumeration.
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
        public static string GetUriScheme(this TransportType instance)
        {
            switch (instance)
            {
                case TransportType.AmqpTcp:
                case TransportType.AmqpWebSockets:
                    return AmqpUriScheme;

                default:
                    throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.InvalidTransportType, instance.ToString(), nameof(instance)));
            }
        }
    }
}
