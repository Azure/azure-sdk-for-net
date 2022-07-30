// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Storage.Blobs.DataMovement.Models;

namespace Azure.Storage.Blobs.DataMovement
{
    internal class BlobUploadPartInternal : BlobJobPartInternal
    {
        //public BlobUploadTransferJob Job { get; internal set; }

        public BlobUploadPartInternal(BlobUploadTransferJob job)
        {
            Job = job;
            OperationType = BlobTransferType.OperationType.Upload;
        }

        /*
        public override async Task ProcessJobPartToJobChunk(Channel<Func<Task>> chunkChannel)
        {
             await foreach (Func<Task> item in Job.ProcessPartToChunkAsync().ConfigureAwait(false))
            {
                await QueueChunk(chunkChannel, item).ConfigureAwait(false);
            }
        }
        */
    }
}
