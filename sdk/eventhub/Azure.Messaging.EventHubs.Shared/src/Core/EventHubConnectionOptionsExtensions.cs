// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   The set of extension methods for the <see cref="EventHubConnectionOptions" />
    ///   class.
    /// </summary>
    ///
    internal static class EventHubConnectionOptionsExtensions
    {
        /// <summary>
        ///   Creates a new copy of the current <see cref="EventHubConnectionOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        ///
        /// <returns>A new copy of <see cref="EventHubConnectionOptions" />.</returns>
        ///
        public static EventHubConnectionOptions Clone(this EventHubConnectionOptions instance) =>
            new EventHubConnectionOptions
            {
                TransportType = instance.TransportType,
                Proxy = instance.Proxy,
                CustomEndpointAddress = instance.CustomEndpointAddress
            };
    }
}
