// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    internal static partial class DataMovementExtensions
    {
        internal static StorageTransferJobDetails ToStorageTransferJobDetails(this TransferJobInternal transferJob)
        {
            if (transferJob == null)
            {
                return null;
            }

            return new StorageTransferJobDetails(
                jobId: transferJob.JobId,
                status: DataMovement.Models.StorageJobTransferStatus.Completed, //TODO: update with actual job status
                jobStartTime: DateTimeOffset.MinValue // TODO: udpate to actual start time
            );
        }
    }
}
