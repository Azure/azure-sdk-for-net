// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.DataMovement.JobPlan
{
    [Flags]
    internal enum JobPlanStatus : int
    {
        None = 0,
        Queued = 1,
        InProgress = 2,
        Pausing = 4,
        Stopping = 8,
        Paused = 16,
        Completed = 32,
        HasFailed = 64,
        HasSkipped = 128,
    }
}
