// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Storage.DataMovement
{
    internal class JobPartStatusEventArgs : DataTransferEventArgs
    {
        public int PartNumber { get; }

        public DataTransferStatus TransferStatus { get; }

        public JobPartStatusEventArgs(
            string transferId,
            int partNumber,
            DataTransferStatus transferStatus,
            bool isRunningSynchronously,
            CancellationToken cancellationToken)
            : base(transferId, isRunningSynchronously, cancellationToken)
        {
            PartNumber = partNumber;
            TransferStatus = transferStatus;
        }
    }
}
