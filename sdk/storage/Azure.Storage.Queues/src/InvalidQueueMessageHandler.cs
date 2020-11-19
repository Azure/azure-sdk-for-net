// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// TODO (kasobol-msft) add doc.
    /// </summary>
    public abstract class InvalidQueueMessageHandler
    {
        /// <summary>
        /// TODO (kasobol-msft) add doc.
        /// </summary>
        /// <param name="rawMessage"></param>
        /// <param name="cancellationToken"></param>
        public abstract void OnInvalidMessage(object rawMessage, CancellationToken cancellationToken);

        /// <summary>
        /// TODO (kasobol-msft) add doc.
        /// </summary>
        /// <param name="rawMessage"></param>
        /// <param name="cancellationToken"></param>
        public abstract Task OnInvalidMessageAsync(object rawMessage, CancellationToken cancellationToken);
    }
}
