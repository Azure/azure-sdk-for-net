// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Communication.JobRouter
{
    /// <summary> Jobs are distributed in order to workers, starting with the worker that is after the last worker to receive a job. </summary>
    public partial class RoundRobinMode
    {
        /// <summary> Initializes a new instance of RoundRobinModePolicy. </summary>
        public RoundRobinMode()
        {
            Kind = DistributionModeKind.RoundRobin;
        }
    }
}
