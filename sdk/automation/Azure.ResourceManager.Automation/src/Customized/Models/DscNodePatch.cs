// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Automation.Models
{
    // TypeSpec generates the wire-derived NamePropertiesNodeConfigurationName property name.
    // Keep the GA DscNodeUpdateParametersName alias that forwards to the generated property.
    public partial class DscNodePatch
    {
        /// <summary> Gets or sets the name of the dsc node configuration. </summary>
        public string DscNodeUpdateParametersName
        {
            get => NamePropertiesNodeConfigurationName;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => NamePropertiesNodeConfigurationName = value;
        }
    }
}
