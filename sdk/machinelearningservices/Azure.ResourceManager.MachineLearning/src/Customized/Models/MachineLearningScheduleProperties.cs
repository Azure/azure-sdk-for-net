// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: preserve the GA constructor parameter order of trigger before action.
    // The TypeSpec generator emits the schema order, so this overload forwards to the generated
    // constructor to keep source compatibility with the previous SDK.
    public partial class MachineLearningScheduleProperties
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningScheduleProperties"/>. </summary>
        public MachineLearningScheduleProperties(MachineLearningTriggerBase trigger, MachineLearningScheduleAction action) : this(action, trigger)
        {
        }
    }
}
