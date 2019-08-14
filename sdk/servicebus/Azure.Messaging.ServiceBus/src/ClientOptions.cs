// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Primitives;

namespace Azure.Messaging.ServiceBus
{
    public class AmqpClientOptions
    {
        public AmqpClientOptions()
        {
            this.RetryPolicy = RetryPolicy.Default;
        }

        /// <summary>
        /// Duration after which individual operations will timeout.
        /// </summary>
        public TimeSpan OperationTimeout { get; set; } = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Gets the ID to identify this client. This can be used to correlate logs and exceptions.
        /// </summary>
        /// <remarks>Every new client has a unique ID (in that process).</remarks>
        public string ClientId { get; set; }

        public string ClientIdPostfix { get; set; }

        /// <summary>
        /// Gets the <see cref="ServiceBus.RetryPolicy"/> defined on the client.
        /// </summary>
        public RetryPolicy RetryPolicy { get; set; }

        public TransportType TransportType { get; set; }


        /// <summary>
        /// Gets a list of currently registered plugins for this client.
        /// </summary>
        public IList<ServiceBusPlugin> RegisteredPlugins { get; } = new List<ServiceBusPlugin>();

        /// <summary>
        /// Registers a <see cref="ServiceBusPlugin"/> to be used with this client.
        /// </summary>
        /// <param name="serviceBusPlugin">The <see cref="ServiceBusPlugin"/> to register.</param>
        public void RegisterPlugin(ServiceBusPlugin serviceBusPlugin)
        {
            if (serviceBusPlugin == null)
            {
                throw new ArgumentNullException(nameof(serviceBusPlugin), Resources.ArgumentNullOrWhiteSpace.FormatForUser(nameof(serviceBusPlugin)));
            }

            if (this.RegisteredPlugins.Any(p => p.GetType() == serviceBusPlugin.GetType()))
            {
                throw new ArgumentException(nameof(serviceBusPlugin), Resources.PluginAlreadyRegistered.FormatForUser(serviceBusPlugin.Name));
            }
            this.RegisteredPlugins.Add(serviceBusPlugin);
        }

        /// <summary>
        /// Unregisters a <see cref="ServiceBusPlugin"/>.
        /// </summary>
        /// <param name="serviceBusPluginName">The name <see cref="ServiceBusPlugin.Name"/> to be unregistered</param>
        public void UnregisterPlugin(string serviceBusPluginName)
        {
            if (string.IsNullOrWhiteSpace(serviceBusPluginName))
            {
                throw new ArgumentNullException(nameof(serviceBusPluginName), Resources.ArgumentNullOrWhiteSpace.FormatForUser(nameof(serviceBusPluginName)));
            }
            if (this.RegisteredPlugins.Any(p => p.Name == serviceBusPluginName))
            {
                var plugin = this.RegisteredPlugins.First(p => p.Name == serviceBusPluginName);
                this.RegisteredPlugins.Remove(plugin);
            }
        }
    }
}