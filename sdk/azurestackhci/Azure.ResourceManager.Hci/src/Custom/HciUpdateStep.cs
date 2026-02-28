// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    // Backward-compat: preserves [Obsolete] from previous API version
    [CodeGenSuppress("StartTimeUtc")]
    [CodeGenSuppress("EndTimeUtc")]
    [CodeGenSuppress("LastUpdatedTimeUtc")]
    public partial class HciUpdateStep
    {
        /// <summary> When the step started, or empty if it has not started executing. </summary>
        [WirePath("startTimeUtc")]
        [Obsolete("This property is now deprecated. Please use the new property `StartOn` moving forward.")]
        public DateTimeOffset? StartTimeUtc { get; set; }

        /// <summary> When the step reached a terminal state. </summary>
        [WirePath("endTimeUtc")]
        [Obsolete("This property is now deprecated. Please use the new property `EndOn` moving forward.")]
        public DateTimeOffset? EndTimeUtc { get; set; }

        /// <summary> Completion time of this step or the last completed sub-step. </summary>
        [WirePath("lastUpdatedTimeUtc")]
        [Obsolete("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
        public DateTimeOffset? LastUpdatedTimeUtc { get; set; }
    }
}
