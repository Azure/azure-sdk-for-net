// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Contract for all client entities with Open-Close/Abort state m/c
    /// main-purpose: closeAll related entities
    /// </summary>
    public abstract class ClientEntity
    {
        static int nextId;

        protected ClientEntity(string clientId)
        {
            this.ClientId = clientId;
        }

        public string ClientId { get; private set; }

        public abstract Task CloseAsync();

        public void Close()
        {
            this.CloseAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        protected static long GetNextId()
        {
            return Interlocked.Increment(ref nextId);
        }
    }
}