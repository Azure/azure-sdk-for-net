// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Automation;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Compatibility shim preserving the GA constructor and flattened RunOn setter.
    [CodeGenSuppress("AutomationJobScheduleCreateOrUpdateContent")]
    [CodeGenSuppress("RunOn")]
    public partial class AutomationJobScheduleCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="AutomationJobScheduleCreateOrUpdateContent"/>. </summary>
        /// <param name="schedule"> Gets or sets the schedule. </param>
        /// <param name="runbook"> Gets or sets the runbook. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="schedule"/> or <paramref name="runbook"/> is null. </exception>
        public AutomationJobScheduleCreateOrUpdateContent(ScheduleAssociationProperty schedule, RunbookAssociationProperty runbook)
        {
            Argument.AssertNotNull(schedule, nameof(schedule));
            Argument.AssertNotNull(runbook, nameof(runbook));

            Properties = new JobScheduleCreateProperties(schedule, runbook, default, new ChangeTrackingDictionary<string, string>(), default);
        }

        /// <summary> Gets or sets the hybrid worker group that the scheduled job should run on. </summary>
        public string RunOn
        {
            get => Properties.RunOn;
            set => Properties.RunOn = value;
        }
    }
}
