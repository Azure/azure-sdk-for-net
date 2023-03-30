// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class LinuxPatchSettings
    {
        /// <summary> Specifies the reboot setting for all AutomaticByPlatform patch installation operations. </summary>
        public LinuxVmGuestPatchAutomaticByPlatformRebootSetting? AutomaticByPlatformRebootSetting
        {
            get => AutomaticByPlatformSettings is null ? default : AutomaticByPlatformSettings.RebootSetting;
            set
            {
                if (AutomaticByPlatformSettings is null)
                    AutomaticByPlatformSettings = new LinuxVmGuestPatchAutomaticByPlatformSettings();
                AutomaticByPlatformSettings.RebootSetting = value;
            }
        }
    }
}
