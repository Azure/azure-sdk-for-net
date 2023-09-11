// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            DataTransferStatus jobStatus = (DataTransferStatus)await checkpointer.GetByteValue(
                transferId,
                DataMovementConstants.JobPartPlanFile.AtomicJobStatusIndex,
                cancellationToken).ConfigureAwait(false);

            // Transfers marked as fully completed are not resumable
            return jobStatus != DataTransferStatus.Completed;
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
