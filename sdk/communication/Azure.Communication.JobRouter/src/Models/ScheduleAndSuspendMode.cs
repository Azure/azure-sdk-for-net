// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ScheduleAndSuspendMode
    {
        /// <summary> Initializes a new instance of ScheduleAndSuspendMode. </summary>
        /// <param name="scheduleAt"> Requested schedule time. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scheduleAt"/> is null. </exception>
        public ScheduleAndSuspendMode(DateTimeOffset scheduleAt)
        {
            Argument.AssertNotNull(scheduleAt, nameof(scheduleAt));

            Kind = JobMatchingModeKind.ScheduleAndSuspend;
            ScheduleAt = scheduleAt;
        }
    }
}
