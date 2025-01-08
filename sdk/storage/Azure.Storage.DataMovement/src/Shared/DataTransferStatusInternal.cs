// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement
{
    internal class DataTransferStatusInternal : TransferStatus
    {
        public DataTransferStatusInternal() : base()
        { }

        public DataTransferStatusInternal(
            TransferState state,
            bool hasFailedItems,
            bool hasSkippedItems)
            : base(state, hasFailedItems, hasSkippedItems)
        { }
    }
}
