// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrackOne.Core;

namespace TrackOne
{
    /// <summary>
    /// Contract for all client entities with Open-Close/Abort state m/c
    /// main-purpose: closeAll related entities
    /// </summary>
    internal abstract class ClientEntity
    {
        private static int s_nextId;
        private RetryPolicy _retryPolicy;

        /// <summary></summary>
        /// <param name="clientId"></param>
        protected ClientEntity(string clientId)
        {
            ClientId = clientId;
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
        /// Gets the <see cref="TrackOne.RetryPolicy"/> for the ClientEntity.
        /// </summary>
        public RetryPolicy RetryPolicy
        {
            get => _retryPolicy;

            set
            {
                _retryPolicy = value;
                OnRetryPolicyUpdate();
            }
        }

        /// <summary>
        /// Closes the ClientEntity.
        /// </summary>
        /// <returns>The asynchronous operation</returns>
        public abstract Task CloseAsync();

        /// <summary>
        /// Registers a <see cref="EventHubsPlugin"/> to be used with this client.
        /// </summary>
        public virtual void RegisterPlugin(EventHubsPlugin eventHubsPlugin)
        {
            if (eventHubsPlugin == null)
            {
                throw new ArgumentNullException(nameof(eventHubsPlugin), Resources.ArgumentNullOrWhiteSpace.FormatForUser(nameof(eventHubsPlugin)));
            }
            if (RegisteredPlugins.Any(p => p.Value.Name == eventHubsPlugin.Name))
            {
                throw new ArgumentException(eventHubsPlugin.Name, Resources.PluginAlreadyRegistered.FormatForUser(eventHubsPlugin.Name));
            }
            if (!RegisteredPlugins.TryAdd(eventHubsPlugin.Name, eventHubsPlugin))
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
            if (RegisteredPlugins == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(pluginName))
            {
                throw new ArgumentNullException(nameof(pluginName), Resources.ArgumentNullOrWhiteSpace.FormatForUser(nameof(pluginName)));
            }

            RegisteredPlugins.TryRemove(pluginName, out EventHubsPlugin plugin);
        }

        /// <summary>
        /// Closes the ClientEntity.
        /// </summary>
        public void Close()
        {
            CloseAsync().GetAwaiter().GetResult();
        }

        /// <summary></summary>
        /// <returns></returns>
        protected static long GetNextId()
        {
            return Interlocked.Increment(ref s_nextId);
        }

        /// <summary>
        /// Derived entity to override for retry policy updates.
        /// </summary>
        protected virtual void OnRetryPolicyUpdate()
        {
            // NOOP
        }
    }
}
