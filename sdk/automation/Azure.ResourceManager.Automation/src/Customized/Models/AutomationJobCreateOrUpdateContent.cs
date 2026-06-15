// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Generated job create content stores RunbookName and RunOn under JobCreateProperties.
    // Keep GA top-level setters and initialize the nested Properties model for callers.
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
