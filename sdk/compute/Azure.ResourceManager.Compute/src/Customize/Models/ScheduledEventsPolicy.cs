// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> Specifies Redeploy, Reboot and ScheduledEventsAdditionalPublishingTargets Scheduled Event related configurations. </summary>
    public partial class ScheduledEventsPolicy
    {
        /// <summary> Specifies if event grid and resource graph is enabled for Scheduled event related configurations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Enable
        {
            get => ScheduledEventsAdditionalPublishingTargets.EventGridAndResourceGraph?.IsEnabled;
            set
            {
                if (ScheduledEventsAdditionalPublishingTargets is null)
                    ScheduledEventsAdditionalPublishingTargets = new ScheduledEventsAdditionalPublishingTargets()
                    {
                        EventGridAndResourceGraph = new()
                    };
                ScheduledEventsAdditionalPublishingTargets.EventGridAndResourceGraph.IsEnabled = value;
            }
        }
    }
}
