// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;

    /// <summary>
    /// Contract for all client entities with Open-Close/Abort state m/c
    /// main-purpose: closeAll related entities
    /// </summary>
    public abstract class ClientEntity : IClientEntity
    {
        static int nextId;
        readonly string clientTypeName;
        readonly object syncLock;
        bool isClosedOrClosing;

        protected ClientEntity(string clientTypeName, string postfix, RetryPolicy retryPolicy)
        {
            this.clientTypeName = clientTypeName;
            this.ClientId = GenerateClientId(clientTypeName, postfix);
            this.RetryPolicy = retryPolicy ?? RetryPolicy.Default;
            this.syncLock = new object();
        }

        /// <summary>
        /// Returns true if the client is closed or closing.
        /// </summary>
        public bool IsClosedOrClosing
        {
            get
            {
                lock (syncLock)
                {
                    return isClosedOrClosing;
                }
            }
            internal set
            {
                lock (syncLock)
                {
                    isClosedOrClosing = value;
                }
            }
        }

        /// <summary>
        /// Connection object to the service bus namespace.
        /// </summary>
        public abstract ServiceBusConnection ServiceBusConnection { get; }

        /// <summary>
        /// Returns true if connection is owned and false if connection is shared.
        /// </summary>
        public bool OwnsConnection { get; internal set; }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        public abstract string Path { get; }

        /// <summary>
        /// Duration after which individual operations will timeout.
        /// </summary>
        public abstract TimeSpan OperationTimeout { get; set; }

        /// <summary>
        /// Gets the ID to identify this client. This can be used to correlate logs and exceptions.
        /// </summary>
        /// <remarks>Every new client has a unique ID (in that process).</remarks>
        public string ClientId { get; private set; }

        /// <summary>
        /// Gets the <see cref="ServiceBus.RetryPolicy"/> defined on the client.
        /// </summary>
        public RetryPolicy RetryPolicy { get; }

        /// <summary>
        /// Closes the Client. Closes the connections opened by it.
        /// </summary>
        public async Task CloseAsync()
        {
            var callClose = false;
            lock (this.syncLock)
            {
                if (!this.IsClosedOrClosing)
                {
                    this.IsClosedOrClosing = true;
                    callClose = true;
                }
            }

            if (callClose)
            {
                await this.OnClosingAsync().ConfigureAwait(false);
                if (OwnsConnection && this.ServiceBusConnection.IsClosedOrClosing == false)
                {
                    await this.ServiceBusConnection.CloseAsync().ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Gets a list of currently registered plugins for this client.
        /// </summary>
        public abstract IList<ServiceBusPlugin> RegisteredPlugins { get; }

        /// <summary>
        /// Registers a <see cref="ServiceBusPlugin"/> to be used with this client.
        /// </summary>
        /// <param name="serviceBusPlugin">The <see cref="ServiceBusPlugin"/> to register.</param>
        public abstract void RegisterPlugin(ServiceBusPlugin serviceBusPlugin);

        /// <summary>
        /// Unregisters a <see cref="ServiceBusPlugin"/>.
        /// </summary>
        /// <param name="serviceBusPluginName">The name <see cref="ServiceBusPlugin.Name"/> to be unregistered</param>
        public abstract void UnregisterPlugin(string serviceBusPluginName);

        protected abstract Task OnClosingAsync();

        protected static long GetNextId()
        {
            return Interlocked.Increment(ref nextId);
        }

        /// <summary>
        /// Generates a new client id that can be used to identify a specific client in logs and error messages.
        /// </summary>
        /// <param name="postfix">Information that can be appended by the client.</param>
        protected static string GenerateClientId(string clientTypeName, string postfix = "")
        {
            return $"{clientTypeName}{GetNextId()}{postfix}";
        }

        /// <summary>
        /// Throw an OperationCanceledException if the object is Closing.
        /// </summary>
        protected virtual void ThrowIfClosed()
        {
            this.ServiceBusConnection.ThrowIfClosed();
            if (this.IsClosedOrClosing)
            {
                throw new ObjectDisposedException($"{this.clientTypeName} with Id '{this.ClientId}' has already been closed. Please create a new {this.clientTypeName}.");
            }            
        }

        /// <summary>
        /// Updates the client id.
        /// </summary>
        internal void UpdateClientId(string newClientId)
        {
            MessagingEventSource.Log.UpdateClientId(this.ClientId, newClientId);
            this.ClientId = newClientId;
        }
    }
}