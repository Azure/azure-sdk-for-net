// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#nullable disable

namespace Azure.Communication.JobRouter
{
    /// <summary> Jobs are directed to the worker who has been idle longest. </summary>
    [CodeGenSuppress("LongestIdleMode", typeof(int), typeof(int))]
    public partial class LongestIdleMode : DistributionMode
    {
        /// <summary> Initializes a new instance of LongestIdleModePolicy. </summary>
        /// <param name="minConcurrentOffers"> (Optional) Governs the minimum desired number of active concurrent offers a job can have. By default, set to 1. </param>
        /// <param name="maxConcurrentOffers"> (Optional) Governs the maximum number of active concurrent offers a job can have. By default, set to 1. </param>
        /// <param name="bypassSelectors">
        /// (Optional)
        ///
        /// If set to true, then router will match workers to jobs even if they don&apos;t match label selectors.
        ///
        /// Warning: You may get workers that are not qualified for the job they are matched with if you set this
        ///
        /// variable to true. This flag is intended more for temporary usage.
        ///
        /// By default, set to false.
        /// </param>
        public LongestIdleMode(int minConcurrentOffers = 1, int maxConcurrentOffers = 1, bool? bypassSelectors = false)
            : this(null, minConcurrentOffers, maxConcurrentOffers, bypassSelectors)
        {
        }
    }
}
