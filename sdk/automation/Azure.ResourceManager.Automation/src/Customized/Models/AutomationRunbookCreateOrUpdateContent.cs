// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Generated runbook content exposes only selected fields and keeps the rest under RunbookCreateOrUpdateProperties.
    // Keep GA top-level setters for log, draft, content link, description, and trace settings.
    public partial class AutomationRunbookCreateOrUpdateContent
    {
        /// <summary> Gets or sets verbose log option. </summary>
        public bool? IsLogVerboseEnabled
        {
            get => Properties.IsLogVerboseEnabled;
            set => Properties.IsLogVerboseEnabled = value;
        }

        /// <summary> Gets or sets progress log option. </summary>
        public bool? IsLogProgressEnabled
        {
            get => Properties.IsLogProgressEnabled;
            set => Properties.IsLogProgressEnabled = value;
        }

        /// <summary> Gets or sets the draft runbook properties. </summary>
        public AutomationRunbookDraft Draft
        {
            get => Properties.Draft;
            set => Properties.Draft = value;
        }

        /// <summary> Gets or sets the published runbook content link. </summary>
        public AutomationContentLink PublishContentLink
        {
            get => Properties.PublishContentLink;
            set => Properties.PublishContentLink = value;
        }

        /// <summary> Gets or sets the description of the runbook. </summary>
        public string Description
        {
            get => Properties.Description;
            set => Properties.Description = value;
        }

        /// <summary> Gets or sets the activity-level tracing options of the runbook. </summary>
        public int? LogActivityTrace
        {
            get => Properties.LogActivityTrace;
            set => Properties.LogActivityTrace = value;
        }
    }
}
