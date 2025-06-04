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
        internal static ITransferCheckpointer BuildCheckpointer(TransferCheckpointStoreOptions options)
        {
            if (options?.Enabled == false)
            {
                return new DisabledTransferCheckpointer();
            }
            else
            {
                return new LocalTransferCheckpointer(options?.CheckpointPath);
            }
        }

        internal static bool IsLocalResource(this StorageResource resource) => resource.Uri.IsFile;

        internal static async Task<TransferStatus> GetJobStatusAsync(
            this SerializerTransferCheckpointer checkpointer,
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
                return jobPlanStatus.ToTransferStatus();
            }
        }

        internal static async Task<bool> IsResumableAsync(
            this ITransferCheckpointer checkpointer,
            string transferId,
            CancellationToken cancellationToken)
        {
            TransferStatus jobStatus = await checkpointer.GetJobStatusAsync(transferId, cancellationToken).ConfigureAwait(false);

            // Transfers marked as fully completed are not resumable
            return jobStatus.State != TransferState.Completed || jobStatus.HasFailedItems || jobStatus.HasSkippedItems;
        }

        internal static async Task<TransferProperties> GetTransferPropertiesAsync(
            this SerializerTransferCheckpointer checkpointer,
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

            return new TransferProperties
            {
                TransferId = transferId,
                SourceUri = new Uri(header.ParentSourcePath),
                SourceProviderId = header.SourceProviderId,
                SourceCheckpointDetails = header.SourceCheckpointDetails,
                DestinationUri = new Uri(header.ParentDestinationPath),
                DestinationProviderId = header.DestinationProviderId,
                DestinationCheckpointDetails = header.DestinationCheckpointDetails,
                IsContainer = header.IsContainer,
            };
        }

        internal static async Task<bool> IsEnumerationCompleteAsync(
            this SerializerTransferCheckpointer checkpointer,
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
            this SerializerTransferCheckpointer checkpointer,
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
