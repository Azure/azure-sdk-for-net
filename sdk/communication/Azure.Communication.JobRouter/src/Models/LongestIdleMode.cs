// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    /// <summary> Jobs are directed to the worker who has been idle longest. </summary>
    public partial class LongestIdleMode
    {
        /// <summary> Initializes a new instance of LongestIdleMode. </summary>
        public LongestIdleMode()
        {
            Kind = DistributionModeKind.LongestIdle;
        }
    }
}
