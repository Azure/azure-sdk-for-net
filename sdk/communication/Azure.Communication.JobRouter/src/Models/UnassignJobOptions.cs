// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for unassigning a job.
    /// </summary>
    public partial class UnassignJobOptions
    {
        /// <summary>
        /// If SuspendMatching is true, then the job is not queued for re-matching with a
        /// worker.
        /// </summary>
        public bool? SuspendMatching { get; set; }
    }
}
