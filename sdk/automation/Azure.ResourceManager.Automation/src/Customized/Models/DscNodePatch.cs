// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Automation.Models
{
    // Compatibility shim preserving the GA DSC node configuration-name alias.
    public partial class DscNodePatch
    {
        /// <summary> Gets or sets the name of the dsc node configuration. </summary>
        public string DscNodeUpdateParametersName
        {
            get => NamePropertiesNodeConfigurationName;
            set => NamePropertiesNodeConfigurationName = value;
        }
    }
}
