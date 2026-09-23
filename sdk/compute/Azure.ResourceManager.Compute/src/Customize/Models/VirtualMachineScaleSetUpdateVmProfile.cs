// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    // Backward compatibility: flatten ScheduledEventsTerminateNotificationProfile from ScheduledEventsProfile.
    public partial class VirtualMachineScaleSetUpdateVmProfile
    {
        /// <summary> Specifies the properties for customizing the size of the virtual machine. Minimum api-version: 2021-11-01. Please follow the instructions in <see href="https://aka.ms/vmcustomization">VM Customization</see> for more details. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VirtualMachineSizeProperties HardwareVmSizeProperties
        {
            get => HardwareProfile is null ? default : HardwareProfile.VmSizeProperties;
            set
            {
                if (HardwareProfile is null)
                    HardwareProfile = new VirtualMachineScaleSetHardwareProfile();
                HardwareProfile.VmSizeProperties = value;
            }
        }

        /// <summary> Specifies Terminate Scheduled Event related configurations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TerminateNotificationProfile ScheduledEventsTerminateNotificationProfile
        {
            get => ScheduledEventsProfile is null ? default : ScheduledEventsProfile.TerminateNotificationProfile;
            set
            {
                if (ScheduledEventsProfile is null)
                    ScheduledEventsProfile = new ComputeScheduledEventsProfile();
                ScheduledEventsProfile.TerminateNotificationProfile = value;
            }
        }
    }
}
