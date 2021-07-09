// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    internal class JobScheduler : TransferScheduler
    {
        public JobScheduler(StorageTransferOptions transferOptions)
        : base((int)(transferOptions.MaximumJobConcurrency.HasValue && transferOptions.MaximumConcurrency > 0 ? transferOptions.MaximumJobConcurrency : 1))
        { }
    }
}
