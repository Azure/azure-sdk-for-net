// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Core
{
    /// <summary>
    ///   The set of extension methods for the <see cref="ServiceBusClientOptions" />
    ///   class.
    /// </summary>
    ///
    internal static class OptionsExtensions
    {
        /// <summary>
        ///   Creates a new copy of the current <see cref="ServiceBusClientOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        ///
        /// <returns>A new copy of <see cref="ServiceBusClientOptions" />.</returns>
        ///
        public static ServiceBusClientOptions Clone(this ServiceBusClientOptions instance) =>
            new ServiceBusClientOptions
            {
                TransportType = instance.TransportType,
                Proxy = instance.Proxy
            };
    }
}
