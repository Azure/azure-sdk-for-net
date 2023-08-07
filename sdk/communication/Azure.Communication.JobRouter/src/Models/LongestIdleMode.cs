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
        public LongestIdleMode() : this(null)
        {
        }

        internal LongestIdleMode(string kind)
        {
            Kind = kind ?? "longest-idle";
        }
    }
}
