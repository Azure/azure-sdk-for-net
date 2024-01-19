// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.JobPlan;

namespace Azure.Storage.DataMovement
{
    internal static partial class CheckpointerExtensions
    {
        internal static TransferCheckpointer GetCheckpointer(this TransferCheckpointStoreOptions options)
        {
            if (!string.IsNullOrEmpty(options?.CheckpointerPath))
            {
                return new LocalTransferCheckpointer(options.CheckpointerPath);
            }
            else
            {
                // Default TransferCheckpointer
                return new LocalTransferCheckpointer(default);
            }
        }

        internal static bool IsLocalResource(this StorageResource resource) => resource.Uri.IsFile;

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
            JobPlanHeader header;
            using (Stream stream = await checkpointer.ReadJobPlanFileAsync(
                transferId,
                offset: 0,
                length: 0,  // Read whole file
                cancellationToken).ConfigureAwait(false))
            {
                header = JobPlanHeader.Deserialize(stream);
            }

            return new DataTransferProperties
            {
                TransferId = transferId,
                SourceUri = new Uri(header.ParentSourcePath),
                SourceProviderId = header.SourceProviderId,
                SourceCheckpointData = header.SourceCheckpointData,
                DestinationUri = new Uri(header.ParentDestinationPath),
                DestinationProviderId = header.DestinationProviderId,
                DestinationCheckpointData = header.DestinationCheckpointData,
                IsContainer = header.IsContainer,
            };
        }

        internal static async Task<bool> IsEnumerationCompleteAsync(
            this TransferCheckpointer checkpointer,
            string transferId,
            CancellationToken cancellationToken = default)
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
            CancellationToken cancellationToken = default)
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
