// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class VirtualMachineData
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
