// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Contract for all client entities with Open-Close/Abort state m/c
    /// main-purpose: closeAll related entities
    /// </summary>
    internal class ClientEntity
    {
        private static int nextId;

        internal AmqpClientOptions Options { get; }

        private readonly object syncLock;

        private bool isClosedOrClosing;

        internal ClientEntity(AmqpClientOptions options, string postfix)
        {
            options = options ?? new AmqpClientOptions();
            this.Options = options;
            this.syncLock = new object();
            this.ClientId = options.ClientId ?? GenerateClientId(this.GetType().Name, options.ClientIdPostfix);
            this.RetryPolicy = options.RetryPolicy;
            this.OperationTimeout = options.OperationTimeout;
            this.RegisteredPlugins = options.RegisteredPlugins.ToArray();
        }

        internal IReadOnlyList<ServiceBusPlugin> RegisteredPlugins { get; set; }

        /// <summary>
        /// Returns true if the client is closed or closing.
        /// </summary>
        internal bool IsClosedOrClosing
        {
            get
            {
                lock (syncLock)
                {
                    return isClosedOrClosing;
                }
            }
             set
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
        internal ServiceBusConnection ServiceBusConnection { get; set; }

        /// <summary>
        /// Returns true if connection is owned and false if connection is shared.
        /// </summary>
        internal bool OwnsConnection { get; set; }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets the ID to identify this client. This can be used to correlate logs and exceptions.
        /// </summary>
        /// <remarks>Every new client has a unique ID (in that process).</remarks>
        internal string ClientId { get; private set; }

        internal RetryPolicy RetryPolicy { get; }

        internal TimeSpan OperationTimeout { get; }

        /// <summary>
        /// Closes the Client. Closes the connections opened by it.
        /// </summary>
        public async Task CloseAsync(Func<Task> onClosing)
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
                await onClosing().ConfigureAwait(false);
                if (OwnsConnection && this.ServiceBusConnection.IsClosedOrClosing == false)
                {
                    await this.ServiceBusConnection.CloseAsync().ConfigureAwait(false);
                }
            }
        }

        internal static long GetNextId()
        {
            return Interlocked.Increment(ref nextId);
        }

        /// <summary>
        /// Generates a new client id that can be used to identify a specific client in logs and error messages.
        /// </summary>
        /// <param name="postfix">Information that can be appended by the client.</param>
        internal static string GenerateClientId(string clientTypeName, string postfix = "")
        {
            return $"{clientTypeName}{GetNextId()}{postfix}";
        }

        /// <summary>
        /// Updates the client id.
        /// </summary>
        internal void UpdateClientId(string newClientId)
        {
            MessagingEventSource.Log.UpdateClientId(this.ClientId, newClientId);
            this.ClientId = newClientId;
        }

        /// <summary>
        /// Throw an OperationCanceledException if the object is Closing.
        /// </summary>
        internal virtual void ThrowIfClosed()
        {
            this.ServiceBusConnection.ThrowIfClosed();
            if (this.IsClosedOrClosing)
            {
                throw new ObjectDisposedException($"{this.GetType().Name} with Id '{this.ClientId}' has already been closed. Please create a new {this.GetType().Name}.");
            }
        }
    }
}