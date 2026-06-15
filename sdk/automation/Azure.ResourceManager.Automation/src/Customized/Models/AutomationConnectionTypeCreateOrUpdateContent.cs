// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Generated connection type content keeps IsGlobal under ConnectionTypeCreateOrUpdateProperties.
    // Keep the GA top-level settable IsGlobal property.
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
