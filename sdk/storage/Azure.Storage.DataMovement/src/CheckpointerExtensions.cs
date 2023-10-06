// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.JobPlan;

namespace Azure.Storage.DataMovement
{
    internal partial class CheckpointerExtensions
    {
        internal static async Task<DataTransferStatus> GetJobStatusAsync(
            this TransferCheckpointer checkpointer,
            string transferId,
            CancellationToken cancellationToken = default)
        {
            using (Stream stream = await checkpointer.ReadJobPlanFileAsync(
                transferId,
                DataMovementConstants.JobPlanFile.JobStatusIndex,
                DataMovementConstants.IntSizeInBytes,
                cancellationToken).ConfigureAwait(false))
            {
                BinaryReader reader = new BinaryReader(stream);
                JobPlanStatus jobPlanStatus = (JobPlanStatus)reader.ReadInt32();
                return jobPlanStatus.ToDataTransferStatus();
            }
        }

        internal static async Task<bool> IsResumableAsync(
            this TransferCheckpointer checkpointer,
            string transferId,
            CancellationToken cancellationToken)
        {
            DataTransferStatus jobStatus = await checkpointer.GetJobStatusAsync(transferId, cancellationToken).ConfigureAwait(false);

            // Transfers marked as fully completed are not resumable
            return jobStatus.State != DataTransferState.Completed || jobStatus.HasFailedItems || jobStatus.HasSkippedItems;
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

        internal static async Task<bool> IsEnumerationCompleteAsync(
            this TransferCheckpointer checkpointer,
            string transferId,
            CancellationToken cancellationToken)
        {
            using (Stream stream = await checkpointer.ReadJobPlanFileAsync(
                transferId,
                DataMovementConstants.JobPlanFile.EnumerationCompleteIndex,
                DataMovementConstants.OneByte,
                cancellationToken).ConfigureAwait(false))
            {
                return Convert.ToBoolean(stream.ReadByte());
            }
        }

        internal static async Task OnEnumerationCompleteAsync(
            this TransferCheckpointer checkpointer,
            string transferId,
            CancellationToken cancellationToken)
        {
            byte[] enumerationComplete = { Convert.ToByte(true) };
            await checkpointer.WriteToJobPlanFileAsync(
                transferId,
                DataMovementConstants.JobPlanFile.EnumerationCompleteIndex,
                enumerationComplete,
                bufferOffset: 0,
                length: 1,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
