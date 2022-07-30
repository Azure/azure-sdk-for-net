// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Storage.Blobs.DataMovement.Models;

namespace Azure.Storage.Blobs.DataMovement
{
    internal class BlobDownloadPartInternal : BlobJobPartInternal
    {
        public BlobDownloadPartInternal(BlobDownloadTransferJob job)
        {
            Job = job;
            OperationType = BlobTransferType.OperationType.Download;
        }
    }
}
