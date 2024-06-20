// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    public abstract partial class DistributionMode
    {
        /// <summary> The type discriminator describing a sub-type of DistributionMode. </summary>
        public DistributionModeKind Kind { get; protected set; }

        /// <summary>
        /// Governs the minimum desired number of active concurrent offers a job can have.
        /// </summary>
        public int MinConcurrentOffers { get; set; } = 1;

        /// <summary>
        /// Governs the maximum number of active concurrent offers a job can have.
        /// </summary>
        public int MaxConcurrentOffers { get; set; } = 1;

        /// <summary>
        /// If set to true, then router will match workers to jobs even if they don't match label selectors.
        /// Warning: You may get workers that are not qualified for a job they are matched with if you set this variable to true.
        /// This flag is intended more for temporary usage. By default, set to false.
        /// </summary>
        public bool? BypassSelectors { get; set; }
    }
}
