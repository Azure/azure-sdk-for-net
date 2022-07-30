// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Storage.Blobs.DataMovement.Models;

namespace Azure.Storage.Blobs.DataMovement
{
    internal abstract class BlobJobPartInternal
    {
        public BlobTransferJobInternal Job { get; internal set; }

        public BlobTransferType.OperationType OperationType;

        public delegate Task QueueChunkDelegate(Func<Task> item);
        public QueueChunkDelegate QueueChunk { get; internal set; }

        protected internal BlobJobPartInternal() { }
        public void SetQueueChunkDelegate(QueueChunkDelegate queueChunkDelegate)
        {
            QueueChunk = queueChunkDelegate;
        }

        /// <summary>
        /// Processes the job part to the chunk processor / uploader / downloader
        /// </summary>
        /// <returns>An IEnumerable that contains the job parts</returns>
        public async Task ProcessJobPartToJobChunk()
        {
            await foreach (Func<Task> item in Job.ProcessPartToChunkAsync().ConfigureAwait(false))
            {
                await QueueChunk(item).ConfigureAwait(false);
            }
        }
    }
}
