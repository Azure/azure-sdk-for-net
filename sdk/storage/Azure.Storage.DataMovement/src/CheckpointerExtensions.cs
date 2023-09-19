// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    internal partial class CheckpointerExtensions
    {
        internal static async Task<bool> IsResumableAsync(
            this TransferCheckpointer checkpointer,
            string transferId,
            CancellationToken cancellationToken)
        {
            DataTransferState transferState = (DataTransferState) await checkpointer.GetByteValue(
                transferId,
                DataMovementConstants.JobPartPlanFile.AtomicJobStatusStateIndex,
                cancellationToken).ConfigureAwait(false);

            byte hasFailedItemsByte = await checkpointer.GetByteValue(
                transferId,
                DataMovementConstants.JobPartPlanFile.AtomicJobStatusHasFailedIndex,
                cancellationToken).ConfigureAwait(false);
            bool hasFailedItems = Convert.ToBoolean(hasFailedItemsByte);

            byte hasSkippedItemsByte = await checkpointer.GetByteValue(
                transferId,
                DataMovementConstants.JobPartPlanFile.AtomicJobStatusHasSkippedIndex,
                cancellationToken).ConfigureAwait(false);
            bool hasSkippedItems = Convert.ToBoolean(hasSkippedItemsByte);

            // Transfers marked as fully completed are not resumable
            return transferState != DataTransferState.Completed || hasFailedItems || hasSkippedItems;
        }

        internal static async Task<DataTransferProperties> GetDataTransferPropertiesAsync(
            this TransferCheckpointer checkpointer,
            string transferId,
            CancellationToken cancellationToken)
        {
            (string sourceResourceId, string destResourceId) = await checkpointer.GetResourceIdsAsync(
                    transferId,
                    cancellationToken).ConfigureAwait(false);

            (string sourcePath, string destPath) = await checkpointer.GetResourcePathsAsync(
                transferId,
                cancellationToken).ConfigureAwait(false);

            bool isContainer =
                (await checkpointer.CurrentJobPartCountAsync(transferId, cancellationToken).ConfigureAwait(false)) > 1;

            return new DataTransferProperties
            {
                TransferId = transferId,
                SourceTypeId = sourceResourceId,
                SourcePath = sourcePath,
                DestinationTypeId = destResourceId,
                DestinationPath = destPath,
                IsContainer = isContainer,
            };
        }
    }
}
