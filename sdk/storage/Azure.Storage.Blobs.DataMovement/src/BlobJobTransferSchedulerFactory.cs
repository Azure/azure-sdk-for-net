// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Blobs.DataMovement
{
    internal class BlobJobTransferSchedulerFactory
    {
        internal int _maxConcurrency;

        public BlobJobTransferSchedulerFactory(
            int? maxConncurency = default)
        {
            // Set _maxWorkerCount
            if (maxConncurency.HasValue && maxConncurency > 0)
            {
                _maxConcurrency = maxConncurency.Value;
            }
            else
            {
                // TODO: come up with an optimal amount to set the default
                // amount of workers. For now it will be 5, which is the current
                // constant amount of block blob transfer.
                _maxConcurrency = Constants.Blob.Block.DefaultConcurrentTransfersCount;
            }
        }

        public JobPartScheduler BuildBlobJobTransferScheduler()
        {
            return new JobPartScheduler(_maxConcurrency);
        }
    }
}
