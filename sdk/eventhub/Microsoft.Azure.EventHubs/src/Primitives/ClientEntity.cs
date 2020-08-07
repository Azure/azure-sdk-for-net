// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.Core;

    /// <summary>
    /// Contract for all client entities with Open-Close/Abort state m/c
    /// main-purpose: closeAll related entities
    /// </summary>
    public abstract class ClientEntity
    {
        static int nextId;
        RetryPolicy retryPolicy;

        /// <summary></summary>
        /// <param name="clientId"></param>
        protected ClientEntity(string clientId)
        {
            this.ClientId = clientId;
        }

        /// <summary>
        /// Gets the client ID.
        /// </summary>
        public string ClientId
        {
            get; private set;
        }

        /// <summary>
        /// Gets a list of currently registered plugins for this Client.
        /// </summary>
        public virtual ConcurrentDictionary<string, EventHubsPlugin> RegisteredPlugins { get; }
            = new ConcurrentDictionary<string, EventHubsPlugin>();

        /// <summary>
        /// Gets the <see cref="EventHubs.RetryPolicy"/> for the ClientEntity.
        /// </summary>
        public RetryPolicy RetryPolicy
        {
            get => this.retryPolicy;

            set
            {
                this.retryPolicy = value;
                this.OnRetryPolicyUpdate();
            }
        }

        /// <summary>
        /// Closes the ClientEntity.
        /// </summary>
        /// <returns>The asynchronous operation</returns>
        public abstract Task CloseAsync();

        /// <summary>
        /// Returns a boolean representing whether client object is closed or not.
        /// </summary>
        /// <value>Returns <see cref="System.Boolean" />.</value>
        public bool IsClosed { get; protected set; }

        /// <summary>
        /// Registers a <see cref="EventHubsPlugin"/> to be used with this client.
        /// </summary>
        public virtual void RegisterPlugin(EventHubsPlugin eventHubsPlugin)
        {
            if (eventHubsPlugin == null)
            {
                throw new ArgumentNullException(nameof(eventHubsPlugin), Resources.ArgumentNullOrWhiteSpace.FormatForUser(nameof(eventHubsPlugin)));
            }
            if (this.RegisteredPlugins.Any(p => p.Value.Name == eventHubsPlugin.Name))
            {
                throw new ArgumentException(eventHubsPlugin.Name, Resources.PluginAlreadyRegistered.FormatForUser(eventHubsPlugin.Name));
            }
            if (!this.RegisteredPlugins.TryAdd(eventHubsPlugin.Name, eventHubsPlugin))
            {
                throw new ArgumentException(eventHubsPlugin.Name, Resources.PluginRegistrationFailed.FormatForUser(eventHubsPlugin.Name));
            }
        }

        /// <summary>
        /// Unregisters a <see cref="EventHubsPlugin"/>.
        /// </summary>
        /// <param name="pluginName">The <see cref="EventHubsPlugin.Name"/> of the plugin to be unregistered.</param>
        public virtual void UnregisterPlugin(string pluginName)
        {
            if (this.RegisteredPlugins == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(pluginName))
            {
                throw new ArgumentNullException(nameof(pluginName), Resources.ArgumentNullOrWhiteSpace.FormatForUser(nameof(pluginName)));
            }

            this.RegisteredPlugins.TryRemove(pluginName, out EventHubsPlugin plugin);
        }

        /// <summary>
        /// Closes the ClientEntity.
        /// </summary>
        public void Close()
        {
            this.CloseAsync().GetAwaiter().GetResult();
        }

        /// <summary></summary>
        /// <returns></returns>
        protected static long GetNextId()
        {
            return Interlocked.Increment(ref nextId);
        }

        /// <summary>
        /// Derived entity to override for retry policy updates.
        /// </summary>
        protected virtual void OnRetryPolicyUpdate()
        {
            // NOOP
        }

        /// <summary>
        /// Throws an exception if client object is already closed.
        /// </summary>
        protected void ThrowIfClosed()
        {
            if (this.IsClosed)
            {
                throw new InvalidOperationException(Resources.ClientAlreadyClosed);
            }
        }
    }
}