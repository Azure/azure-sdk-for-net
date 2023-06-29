// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#nullable disable

namespace Azure.Communication.JobRouter
{
    /// <summary> Jobs are distributed in order to workers, starting with the worker that is after the last worker to receive a job. </summary>
    [CodeGenModel("RoundRobinMode")]
    [CodeGenSuppress("RoundRobinMode", typeof(int), typeof(int))]
    public partial class RoundRobinMode : DistributionMode
    {
        /// <summary> Initializes a new instance of RoundRobinModePolicy. </summary>
        public RoundRobinMode() : this(null)
        {
        }

        internal RoundRobinMode(string kind)
        {
            Kind = kind ?? "round-robin";
        }
    }
}
