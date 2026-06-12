// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Compatibility shim preserving the GA flattened IsGlobal setter.
    [CodeGenSuppress("IsGlobal")]
    public partial class AutomationConnectionTypeCreateOrUpdateContent
    {
        /// <summary> Gets or sets a Boolean value to indicate if the connection type is global. </summary>
        public bool? IsGlobal
        {
            get => Properties.IsGlobal;
            set => Properties.IsGlobal = value;
        }
    }
}
