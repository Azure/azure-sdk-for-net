// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: retain legacy schedule properties constructor behavior after TypeSpec renamed
    // the schedule properties model.
    public partial class MachineLearningScheduleProperties
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningScheduleProperties"/>. </summary>
        public MachineLearningScheduleProperties(MachineLearningTriggerBase trigger, MachineLearningScheduleAction action) : this(action, trigger)
        {
        }
    }
}
