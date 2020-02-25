// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Core
{
    /// <summary>
    ///   The set of extension methods for the <see cref="ServiceBusConnectionOptions" />
    ///   class.
    /// </summary>
    ///
    internal static class OptionsExtensions
    {
        /// <summary>
        ///   Creates a new copy of the current <see cref="ServiceBusConnectionOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        ///
        /// <returns>A new copy of <see cref="ServiceBusConnectionOptions" />.</returns>
        ///
        public static ServiceBusConnectionOptions Clone(this ServiceBusConnectionOptions instance) =>
            new ServiceBusConnectionOptions
            {
                TransportType = instance.TransportType,
                Proxy = instance.Proxy
            };

        internal static ServiceBusReceiverClientOptions ToServiceBusReceiverClientOptions(this ServiceBusProcessorClientOptions options)
        {
            return new ServiceBusReceiverClientOptions
            {
                ConnectionOptions = options.ConnectionOptions.Clone(),
                RetryOptions = options.RetryOptions.Clone(),
                ReceiveMode = options.ReceiveMode,
                IsSessionEntity = options.IsSessionEntity,
                SessionId = options.SessionId
            };
        }
    }
}
