// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.DataMovement.JobPlan;

namespace Azure.Storage.DataMovement
{
    internal static partial class JobPlanExtensions
    {
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
