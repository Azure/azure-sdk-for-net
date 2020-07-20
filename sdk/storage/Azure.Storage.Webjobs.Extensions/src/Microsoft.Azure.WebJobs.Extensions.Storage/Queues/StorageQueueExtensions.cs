// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;

namespace Microsoft.Azure.WebJobs.Host.Queues
{
    internal static class StorageQueueExtensions
    {
        public static async Task AddMessageAndCreateIfNotExistsAsync(this CloudQueue queue,
            CloudQueueMessage message, CancellationToken cancellationToken)
        {
            if (queue == null)
            {
                throw new ArgumentNullException(nameof(queue));
            }

            bool isQueueNotFoundException = false;

            try
            {
                await queue.AddMessageAsync(message, cancellationToken).ConfigureAwait(false);
                return;
            }
            catch (StorageException exception)
            {
                if (!exception.IsNotFoundQueueNotFound())
                {
                    throw;
                }

                isQueueNotFoundException = true;
            }

            Debug.Assert(isQueueNotFoundException);
            await queue.CreateIfNotExistsAsync(cancellationToken).ConfigureAwait(false);
            await queue.AddMessageAsync(message, cancellationToken).ConfigureAwait(false);
        }
    }
}
