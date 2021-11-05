// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Host.Executors;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    /// <summary>
    /// Class containing registration data used by the <see cref="SharedBlobQueueListener"/>.
    /// </summary>
    internal class BlobQueueRegistration
    {
        /// <summary>
        /// The function executor used to execute the function when a queue
        /// message is received for a blob that needs processing.
        /// </summary>
        public ITriggeredFunctionExecutor Executor { get; set; }

        /// <summary>
        /// The storage client to use to retrieve the blob (i.e., the
        /// storage account that the blob triggered function is listening
        /// to).
        /// </summary>
        public BlobServiceClient BlobServiceClient { get; set; }

        /// <summary>
        /// The storage client to use for the poison queue.
        /// </summary>
        public QueueServiceClient QueueServiceClient { get; set; }
    }
}
