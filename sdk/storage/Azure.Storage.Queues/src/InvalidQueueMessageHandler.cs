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
        /// <param name="messageId"></param>
        /// <param name="popReceipt"></param>
        /// <param name="rawBody"></param>
        /// <param name="cancellationToken"></param>
        public abstract void OnInvalidMessage(string messageId, string popReceipt, string rawBody, CancellationToken cancellationToken);

        /// <summary>
        /// TODO (kasobol-msft) add doc.
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="popReceipt"></param>
        /// <param name="rawBody"></param>
        /// <param name="cancellationToken"></param>
        public abstract Task OnInvalidMessageAsync(string messageId, string popReceipt, string rawBody, CancellationToken cancellationToken);
    }
}
