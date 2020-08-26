// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.Storage.Blob;
using Azure.Storage.Queues;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
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
        public CloudBlobClient BlobClient { get; set; }

        /// <summary>
        /// The storage client to use for the poison queue.
        /// </summary>
        public QueueServiceClient QueueClient { get; set; }
    }
}
