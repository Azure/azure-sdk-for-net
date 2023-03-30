// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class PatchSettings
    {
        /// <summary> Specifies the reboot setting for all AutomaticByPlatform patch installation operations. </summary>
        public WindowsVmGuestPatchAutomaticByPlatformRebootSetting? AutomaticByPlatformRebootSetting
        {
            get => AutomaticByPlatformSettings is null ? default : AutomaticByPlatformSettings.RebootSetting;
            set
            {
                if (AutomaticByPlatformSettings is null)
                    AutomaticByPlatformSettings = new WindowsVmGuestPatchAutomaticByPlatformSettings();
                AutomaticByPlatformSettings.RebootSetting = value;
            }
        }
    }
}
