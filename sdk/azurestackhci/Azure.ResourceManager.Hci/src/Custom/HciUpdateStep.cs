// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class HciUpdateStep
    {
        /// <summary> When the step started, or empty if it has not started executing. </summary>
        [WirePath("startTimeUtc")]
        public DateTimeOffset? StartOn { get => StartTimeUtc; set => StartTimeUtc = value; }

        /// <summary> When the step reached a terminal state. </summary>
        [WirePath("endTimeUtc")]
        public DateTimeOffset? EndOn { get => EndTimeUtc; set => EndTimeUtc = value; }

        /// <summary> Completion time of this step or the last completed sub-step. </summary>
        [WirePath("lastUpdatedTimeUtc")]
        public DateTimeOffset? LastUpdatedOn { get => LastUpdatedTimeUtc; set => LastUpdatedTimeUtc = value; }
    }
}
