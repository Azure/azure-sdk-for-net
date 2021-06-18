// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement
{
    internal class StorageTransferItem
    {
        internal StorageTransferJob _transferJob;
        public StorageTransferItem(StorageTransferJob transferJob)
        {
            _transferJob = transferJob;
        }
    }
}
