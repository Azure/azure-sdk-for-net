// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Generated DSC configuration content keeps optional settings under DscConfigurationCreateOrUpdateProperties.
    // Keep GA top-level setters for log flags and description.
    public partial class DscConfigurationCreateOrUpdateContent
    {
        /// <summary> Gets or sets verbose log option. </summary>
        public bool? IsLogVerboseEnabled
        {
            get => Properties.IsLogVerboseEnabled;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => Properties.IsLogVerboseEnabled = value;
        }

        /// <summary> Gets or sets progress log option. </summary>
        public bool? IsLogProgressEnabled
        {
            get => Properties.IsLogProgressEnabled;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => Properties.IsLogProgressEnabled = value;
        }

        /// <summary> Gets or sets the description of the configuration. </summary>
        public string Description
        {
            get => Properties.Description;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => Properties.Description = value;
        }
    }
}
