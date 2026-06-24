// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Automation.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Automation
{
    public partial class AutomationModuleData : TrackedResourceData
    {
        // This enum was changed to extensible enum, so keep the original enum here to avoid breaking changes.
        /// <summary> Gets or sets the provisioning state of the module. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModuleProvisioningState? ProvisioningState
        {
            get
            {
                return Properties is null ? default : Properties.ModuleProvisioningState?.ToString().ToModuleProvisioningState();
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new ModuleProperties();
                }
                Properties.ModuleProvisioningState = new AutomationModuleProvisioningState(value.ToString());
            }
        }
    }
}
