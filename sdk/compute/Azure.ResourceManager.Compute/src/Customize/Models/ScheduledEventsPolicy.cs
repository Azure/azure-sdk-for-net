// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class ScheduledEventsPolicy
    {
        /// <summary> Specifies if event grid and resource graph is enabled for Scheduled event related configurations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Enable
        {
            get => ScheduledEventsAdditionalPublishingTargetsEventGridAndResourceGraph?.IsEnabled;
            set
            {
                if (ScheduledEventsAdditionalPublishingTargetsEventGridAndResourceGraph is null)
                {
                    ScheduledEventsAdditionalPublishingTargetsEventGridAndResourceGraph = new EventGridAndResourceGraph();
                }
                ScheduledEventsAdditionalPublishingTargetsEventGridAndResourceGraph.IsEnabled = value;
            }
        }
    }
}
