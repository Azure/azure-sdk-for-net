// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Compatibility shim preserving GA flattened DSC configuration create/update setters.
    [CodeGenSuppress("Description")]
    [CodeGenSuppress("IsLogProgressEnabled")]
    [CodeGenSuppress("IsLogVerboseEnabled")]
    public partial class DscConfigurationCreateOrUpdateContent
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

        /// <summary> Gets or sets the description of the configuration. </summary>
        public string Description
        {
            get => Properties.Description;
            set => Properties.Description = value;
        }
    }
}
