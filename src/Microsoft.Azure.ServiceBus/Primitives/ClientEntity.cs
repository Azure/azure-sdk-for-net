// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Contract for all client entities with Open-Close/Abort state m/c
    /// main-purpose: closeAll related entities
    /// </summary>
    public abstract class ClientEntity : IClientEntity
    {
        static int nextId;
        readonly object syncLock;

        /// <summary></summary>
        /// <param name="clientId"></param>
        /// <param name="retryPolicy"></param>
        protected ClientEntity(string clientId, RetryPolicy retryPolicy)
        {
            if (retryPolicy == null)
            {
                throw new ArgumentNullException(nameof(retryPolicy));
            }

            this.ClientId = clientId;
            this.RetryPolicy = retryPolicy;
            this.syncLock = new object();
        }

        /// <summary>
        /// Gets or sets the state of closing.
        /// </summary>
        public bool IsClosedOrClosing
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the client ID.
        /// </summary>
        public string ClientId { get; private set; }

        /// <summary>
        /// Gets the <see cref="RetryPolicy.RetryPolicy"/> for the ClientEntity.
        /// </summary>
        public RetryPolicy RetryPolicy { get; private set; }

        /// <summary>
        /// Closes the ClientEntity.
        /// </summary>
        /// <returns>The asynchronous operation</returns>
        public async Task CloseAsync()
        {
            bool callClose = false;
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
            }
        }

        /// <summary></summary>
        /// <returns></returns>
        protected abstract Task OnClosingAsync();

        /// <summary></summary>
        /// <returns></returns>
        protected static long GetNextId()
        {
            return Interlocked.Increment(ref nextId);
        }
    }
}