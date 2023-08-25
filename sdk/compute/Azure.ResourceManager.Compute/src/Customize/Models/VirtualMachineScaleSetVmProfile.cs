// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class VirtualMachineScaleSetVmProfile
    {
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
