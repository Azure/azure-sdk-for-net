// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobJobTransferSchedulerFactory
    {
        internal int _maxListServiceRequestWorkerCount;
        internal int _maxLocalListWorkerCount;

        public BlobJobTransferSchedulerFactory(
            int? maxListServiceRequestWorkerCount = default,
            int? maxLocalListWorkerCount = default)
        {
            // Set _maxWorkerCount
            if (maxListServiceRequestWorkerCount.HasValue && maxListServiceRequestWorkerCount > 0)
            {
                _maxListServiceRequestWorkerCount = maxListServiceRequestWorkerCount.Value;
            }
            else
            {
                // TODO: come up with an optimal amount to set the default
                // amount of workers. For now it will be 5, which is the current
                // constant amount of block blob transfer.
                _maxListServiceRequestWorkerCount = Constants.Blob.Block.DefaultConcurrentTransfersCount;
            }

            // Set _maxWorkerCount
            if (maxLocalListWorkerCount.HasValue && maxLocalListWorkerCount > 0)
            {
                _maxLocalListWorkerCount = maxLocalListWorkerCount.Value;
            }
            else
            {
                // TODO: come up with an optimal amount to set the default
                // amount of workers. For now it will be 5, which is the current
                // constant amount of block blob transfer.
                _maxLocalListWorkerCount = Constants.Blob.Block.DefaultConcurrentTransfersCount;
            }
        }

        public BlobJobTransferScheduler BuildBlobJobTransferScheduler()
        {
            return new BlobJobTransferScheduler(_maxListServiceRequestWorkerCount, _maxLocalListWorkerCount);
        }
    }
}
