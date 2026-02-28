// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    // Backward-compat: preserve old property names as aliases + [Obsolete] on raw time properties
    [CodeGenSuppress("StartTimeUtc")]
    [CodeGenSuppress("EndTimeUtc")]
    [CodeGenSuppress("LastUpdatedTimeUtc")]
    public partial class HciUpdateStep
    {
        /// <summary> When the step started, or empty if it has not started executing. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `StartOn` moving forward.")]
        [WirePath("startTimeUtc")]
        public DateTimeOffset? StartTimeUtc { get; set; }

        /// <summary> When the step reached a terminal state. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `EndOn` moving forward.")]
        [WirePath("endTimeUtc")]
        public DateTimeOffset? EndTimeUtc { get; set; }

        /// <summary> Completion time of this step or the last completed sub-step. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
        [WirePath("lastUpdatedTimeUtc")]
        public DateTimeOffset? LastUpdatedTimeUtc { get; set; }

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
