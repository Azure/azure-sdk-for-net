// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core;

    /// <summary>
    /// An interface showing the common functionality between all Service Bus clients.
    /// </summary>
    public interface IClientEntity
    {
        /// <summary>
        /// Gets the ID to identify this client. This can be used to correlate logs and exceptions.
        /// </summary>
        /// <remarks>Every new client has a unique ID (in that process).</remarks>
        string ClientId { get; }

        /// <summary>
        /// Returns true if the client is closed or closing.
        /// </summary>
        bool IsClosedOrClosing { get; }

        /// <summary>
        /// Gets the entity path.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Duration after which individual operations will timeout.
        /// </summary>
        TimeSpan OperationTimeout { get; set; }

        /// <summary>
        /// Closes the Client. Closes the connections opened by it.
        /// </summary>
        Task CloseAsync();

        /// <summary>
        /// Connection object to the service bus namespace.
        /// </summary>
        ServiceBusConnection ServiceBusConnection { get; }

        /// <summary>
        /// Returns true if connection is owned and false if connection is shared.
        /// </summary>
        bool OwnsConnection { get; }

        /// <summary>
        /// Gets a list of currently registered plugins for this client.
        /// </summary>
        IList<ServiceBusPlugin> RegisteredPlugins { get; }

        /// <summary>
        /// Registers a <see cref="ServiceBusPlugin"/> to be used with this client.
        /// </summary>
        /// <param name="serviceBusPlugin">The <see cref="ServiceBusPlugin"/> to register.</param>
        void RegisterPlugin(ServiceBusPlugin serviceBusPlugin);

        /// <summary>
        /// Unregisters a <see cref="ServiceBusPlugin"/>.
        /// </summary>
        /// <param name="serviceBusPluginName">The name <see cref="ServiceBusPlugin.Name"/> to be unregistered</param>
        void UnregisterPlugin(string serviceBusPluginName);
    }
}