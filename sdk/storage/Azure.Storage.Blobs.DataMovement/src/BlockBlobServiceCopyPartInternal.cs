// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs.DataMovement.Models;

namespace Azure.Storage.Blobs.DataMovement
{
    internal class BlockBlobServiceCopyPartInternal : BlobJobPartInternal
    {
        public BlockBlobServiceCopyPartInternal(BlockBlobServiceCopyTransferJob job)
        {
            Job = job;
            OperationType = BlobTransferType.OperationType.Copy;
        }
    }
}
