// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.JobPlan;

namespace Azure.Storage.DataMovement
{
    internal static partial class JobPlanExtensions
    {
        internal static async Task<string> GetHeaderLongValue(
            this TransferCheckpointer checkpointer,
            string transferId,
            int startIndex,
            int streamReadLength,
            int valueLength,
            CancellationToken cancellationToken)
        {
            string value;
            using (Stream stream = await checkpointer.ReadJobPartPlanFileAsync(
                transferId: transferId,
                partNumber: 0,
                offset: startIndex,
                length: streamReadLength,
                cancellationToken: cancellationToken).ConfigureAwait(false))
            {
                BinaryReader reader = new BinaryReader(stream);

                // Read Path Length
                byte[] pathLengthBuffer = reader.ReadBytes(DataMovementConstants.LongSizeInBytes);
                long pathLength = pathLengthBuffer.ToLong();

                // Read Path
                byte[] pathBuffer = reader.ReadBytes(valueLength);
                value = pathBuffer.ToString(pathLength);
            }
            return value;
        }

        internal static async Task<byte> GetByteValue(
            this TransferCheckpointer checkpointer,
            string transferId,
            int startIndex,
            CancellationToken cancellationToken)
        {
            byte value;
            using (Stream stream = await checkpointer.ReadJobPartPlanFileAsync(
                transferId: transferId,
                partNumber: 0,
                offset: startIndex,
                length: DataMovementConstants.OneByte,
                cancellationToken: cancellationToken).ConfigureAwait(false))
            {
                BinaryReader reader = new BinaryReader(stream);

                // Read Byte
                value = reader.ReadByte();
            }
            return value;
        }

        internal static JobPlanStatus ToJobPlanStatus(this DataTransferStatus transferStatus)
        {
            if (transferStatus == default)
            {
                return JobPlanStatus.None;
            }

            JobPlanStatus jobPlanStatus = (JobPlanStatus)Enum.Parse(typeof(JobPlanStatus), transferStatus.State.ToString());
            if (transferStatus.HasFailedItems)
            {
                jobPlanStatus |= JobPlanStatus.HasFailed;
            }
            if (transferStatus.HasSkippedItems)
            {
                jobPlanStatus |= JobPlanStatus.HasSkipped;
            }

            return jobPlanStatus;
        }

        internal static DataTransferStatus ToDataTransferStatus(this JobPlanStatus jobPlanStatus)
        {
            DataTransferState state;
            if (jobPlanStatus.HasFlag(JobPlanStatus.Queued))
            {
                state = DataTransferState.Queued;
            }
            else if (jobPlanStatus.HasFlag(JobPlanStatus.InProgress))
            {
                state = DataTransferState.InProgress;
            }
            else if (jobPlanStatus.HasFlag(JobPlanStatus.Pausing))
            {
                state = DataTransferState.Pausing;
            }
            else if (jobPlanStatus.HasFlag(JobPlanStatus.Stopping))
            {
                state = DataTransferState.Stopping;
            }
            else if (jobPlanStatus.HasFlag(JobPlanStatus.Paused))
            {
                state = DataTransferState.Paused;
            }
            else if (jobPlanStatus.HasFlag(JobPlanStatus.Completed))
            {
                state = DataTransferState.Completed;
            }
            else
            {
                state = DataTransferState.None;
            }

            bool hasFailed = jobPlanStatus.HasFlag(JobPlanStatus.HasFailed);
            bool hasSkipped = jobPlanStatus.HasFlag(JobPlanStatus.HasSkipped);

            return new DataTransferStatus(state, hasFailed, hasSkipped);
        }
    }
}
