// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Base definition of a schedule. </summary>
    public partial class MachineLearningScheduleProperties : MachineLearningResourceBase
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningScheduleProperties"/>. </summary>
        /// <param name="action">
        /// [Required] Specifies the action of the schedule
        /// Please note <see cref="MachineLearningScheduleAction"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="MachineLearningJobScheduleAction"/>, <see cref="CreateMonitorAction"/> and <see cref="MachineLearningEndpointScheduleAction"/>.
        /// </param>
        /// <param name="trigger">
        /// [Required] Specifies the trigger details
        /// Please note <see cref="MachineLearningTriggerBase"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="CronTrigger"/> and <see cref="MachineLearningRecurrenceTrigger"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="action"/> or <paramref name="trigger"/> is null. </exception>
        public MachineLearningScheduleProperties(MachineLearningScheduleAction action, MachineLearningTriggerBase trigger)
        {
            Argument.AssertNotNull(trigger, nameof(trigger));
            Argument.AssertNotNull(action, nameof(action));

            Trigger = trigger;
            Action = action;
        }
    }
}
