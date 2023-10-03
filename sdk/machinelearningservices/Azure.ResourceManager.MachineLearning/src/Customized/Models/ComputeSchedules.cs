// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

[assembly: CodeGenSuppressType("ComputeSchedules")]
namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The list of schedules to be applied on the computes. </summary>
    internal partial class ComputeSchedules
    {
        /// <summary> Initializes a new instance of ComputeSchedules. </summary>
        internal ComputeSchedules()
        {
            ComputeStartStop = new ChangeTrackingList<MachineLearningComputeStartStopSchedule>();
        }

        /// <summary> Initializes a new instance of ComputeSchedules. </summary>
        /// <param name="computeStartStop"> The list of compute start stop schedules to be applied. </param>
        internal ComputeSchedules(IReadOnlyList<MachineLearningComputeStartStopSchedule> computeStartStop)
        {
            ComputeStartStop = computeStartStop;
        }

        /// <summary> The list of compute start stop schedules to be applied. </summary>
        public IReadOnlyList<MachineLearningComputeStartStopSchedule> ComputeStartStop { get; }
    }
}
