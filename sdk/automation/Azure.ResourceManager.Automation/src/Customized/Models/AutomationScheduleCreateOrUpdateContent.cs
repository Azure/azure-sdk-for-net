// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Generated schedule content exposes required fields but keeps optional settings under ScheduleCreateOrUpdateProperties.
    // Keep GA top-level setters for description, expiry, interval, time zone, and advanced schedule.
    public partial class AutomationScheduleCreateOrUpdateContent
    {
        /// <summary> Gets or sets the description of the schedule. </summary>
        public string Description
        {
            get => Properties.Description;
            set => Properties.Description = value;
        }

        /// <summary> Gets or sets the end time of the schedule. </summary>
        public DateTimeOffset? ExpireOn
        {
            get => Properties.ExpireOn;
            set => Properties.ExpireOn = value;
        }

        /// <summary> Gets or sets the interval of the schedule. </summary>
        public BinaryData Interval
        {
            get => Properties.Interval;
            set => Properties.Interval = value;
        }

        /// <summary> Gets or sets the time zone of the schedule. </summary>
        public string TimeZone
        {
            get => Properties.TimeZone;
            set => Properties.TimeZone = value;
        }

        /// <summary> Gets or sets the AdvancedSchedule. </summary>
        public AutomationAdvancedSchedule AdvancedSchedule
        {
            get => Properties.AdvancedSchedule;
            set => Properties.AdvancedSchedule = value;
        }
    }
}
