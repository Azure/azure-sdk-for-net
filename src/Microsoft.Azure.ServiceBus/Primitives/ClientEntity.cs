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

        public bool IsClosedOrClosing
        {
            get;
            set;
        }

        public string ClientId { get; private set; }

        public RetryPolicy RetryPolicy { get; private set; }

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

        public abstract Task OnClosingAsync();

        protected static long GetNextId()
        {
            return Interlocked.Increment(ref nextId);
        }
    }
}