// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Compatibility shim preserving GA setters for flattened job create/update properties.
    [CodeGenSuppress("AutomationJobCreateOrUpdateContent")]
    [CodeGenSuppress("RunbookName")]
    [CodeGenSuppress("RunOn")]
    public partial class AutomationJobCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="AutomationJobCreateOrUpdateContent"/>. </summary>
        public AutomationJobCreateOrUpdateContent()
        {
            Properties = new JobCreateProperties();
        }

        /// <summary> Gets or sets the name of the runbook. </summary>
        public string RunbookName
        {
            get => Properties is null ? default : Properties.RunbookName;
            set => Properties.RunbookName = value;
        }

        /// <summary> Gets or sets the runOn which specifies the group name where the job is to be executed. </summary>
        public string RunOn
        {
            get => Properties is null ? default : Properties.RunOn;
            set => Properties.RunOn = value;
        }
    }
}
