// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Used to specify a match mode when no action is taken on a job.
    /// </summary>
    public partial class SuspendMode
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public SuspendMode()
        {
            Kind = JobMatchingModeKind.Suspend;
        }
    }
}
