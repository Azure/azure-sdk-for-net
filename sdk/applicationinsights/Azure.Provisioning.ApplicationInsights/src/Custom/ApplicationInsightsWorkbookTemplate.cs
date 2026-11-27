// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.ApplicationInsights
{
    public partial class ApplicationInsightsWorkbookTemplate
    {
        // Preserve the previously shipped provisioning name without renaming the shared
        // TypeSpec property used by the management SDK's read and patch models.
        /// <summary> Gets or sets the LocalizedGalleries. </summary>
        [CodeGenMember("Localized")]
        public BicepDictionary<BicepList<WorkbookTemplateLocalizedGallery>> LocalizedGalleries
        {
            get
            {
                return Properties is null ? default : Properties.Localized;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new WorkbookTemplateProperties();
                }
                Properties.Localized = value;
            }
        }
    }
}
