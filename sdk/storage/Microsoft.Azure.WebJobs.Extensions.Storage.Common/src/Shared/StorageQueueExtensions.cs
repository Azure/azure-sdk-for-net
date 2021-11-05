// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common
{
    internal static class StorageQueueExtensions
    {
        public static async Task<SendReceipt> AddMessageAndCreateIfNotExistsAsync(this QueueClient queue,
            BinaryData body, CancellationToken cancellationToken)
        {
            if (queue == null)
            {
                throw new ArgumentNullException(nameof(queue));
            }

            bool isQueueNotFoundException = false;

            SendReceipt receipt = null;
            try
            {
                receipt = await queue.SendMessageAsync(body, cancellationToken: cancellationToken).ConfigureAwait(false);
                return receipt;
            }
            catch (RequestFailedException exception)
            {
                if (!exception.IsNotFoundQueueNotFound())
                {
                    throw;
                }

                isQueueNotFoundException = true;
            }

            Debug.Assert(isQueueNotFoundException);
            await queue.CreateAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            receipt = await queue.SendMessageAsync(body, cancellationToken: cancellationToken).ConfigureAwait(false);
            return receipt;
        }
    }
}
