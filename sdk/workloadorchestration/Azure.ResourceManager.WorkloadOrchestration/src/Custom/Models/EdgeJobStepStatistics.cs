// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.WorkloadOrchestration.Models
{
    /// <summary>
    /// Base Job Step Statistics
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="DeployJobStepStatistics"/>.
    /// </summary>
    public abstract partial class EdgeJobStepStatistics
    {
        /// <summary> Initializes a new instance of <see cref="EdgeJobStepStatistics"/> for deserialization. </summary>
        protected EdgeJobStepStatistics()       // The new MPG made this constructor private; change it back to protected to preserve backward compatibility.
        {
        }
    }
}
