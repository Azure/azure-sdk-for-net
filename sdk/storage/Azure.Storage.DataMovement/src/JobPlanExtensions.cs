// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.DataMovement.JobPlan;

namespace Azure.Storage.DataMovement
{
    internal static partial class JobPlanExtensions
    {
        internal static JobPlanStatus ToJobPlanStatus(this TransferStatus transferStatus)
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

        internal static TransferStatus ToTransferStatus(this JobPlanStatus jobPlanStatus)
        {
            TransferState state;
            if (jobPlanStatus.HasFlag(JobPlanStatus.Queued))
            {
                state = TransferState.Queued;
            }
            else if (jobPlanStatus.HasFlag(JobPlanStatus.InProgress))
            {
                state = TransferState.InProgress;
            }
            else if (jobPlanStatus.HasFlag(JobPlanStatus.Pausing))
            {
                state = TransferState.Pausing;
            }
            else if (jobPlanStatus.HasFlag(JobPlanStatus.Stopping))
            {
                state = TransferState.Stopping;
            }
            else if (jobPlanStatus.HasFlag(JobPlanStatus.Paused))
            {
                state = TransferState.Paused;
            }
            else if (jobPlanStatus.HasFlag(JobPlanStatus.Completed))
            {
                state = TransferState.Completed;
            }
            else
            {
                state = TransferState.None;
            }

            bool hasFailed = jobPlanStatus.HasFlag(JobPlanStatus.HasFailed);
            bool hasSkipped = jobPlanStatus.HasFlag(JobPlanStatus.HasSkipped);

            return new TransferStatus(state, hasFailed, hasSkipped);
        }
    }
}
