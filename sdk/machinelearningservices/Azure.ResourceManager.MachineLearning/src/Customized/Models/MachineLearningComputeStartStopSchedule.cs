// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Compute start stop schedule properties. </summary>
    public partial class MachineLearningComputeStartStopSchedule
    {
        /// <summary> Required if triggerType is Recurrence. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ComputeRecurrenceFrequency Recurrence
        {
            get
            {
                return new ComputeRecurrenceFrequency(RecurrenceSchedule.Frequency.Value.ToString());
            }
        }
        /// <summary> Required if triggerType is Cron. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CronTrigger Cron
        {
            get
            {
                return new CronTrigger(CronSchedule.Expression);
            }
        }
    }
}
