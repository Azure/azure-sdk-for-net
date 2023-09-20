// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenSuppress("ScheduleAndSuspendMode")]
    [CodeGenSuppress("ScheduleAndSuspendMode", typeof(DateTimeOffset?))]
    public partial class ScheduleAndSuspendMode
    {
        /// <summary> Initializes a new instance of ScheduleAndSuspendMode. </summary>
        /// <param name="scheduleAt">The time at which the job will be scheduled.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="scheduleAt"/> is null. </exception>
        public ScheduleAndSuspendMode(DateTimeOffset scheduleAt)
        {
            Argument.AssertNotNull(scheduleAt, nameof(scheduleAt));
            ScheduleAt = scheduleAt;
        }
    }
}
