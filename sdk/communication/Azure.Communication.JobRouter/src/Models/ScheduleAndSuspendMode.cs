// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Used to specify a match mode for scheduled jobs. After reaching the scheduled time, no matching will be started by default.
    /// </summary>
    public class ScheduleAndSuspendMode : JobMatchingMode
    {
        /// <inheritdoc />
        public override string Kind => nameof(ScheduleAndSuspendMode);

        /// <summary>
        /// public constructor;
        /// </summary>
        /// <param name="scheduleAt"></param>
        public ScheduleAndSuspendMode(DateTimeOffset? scheduleAt)
        {
            ScheduleAt = scheduleAt;
        }

        /// <summary> Gets or sets the schedule at. </summary>
        public DateTimeOffset? ScheduleAt { get; }
    }
}
