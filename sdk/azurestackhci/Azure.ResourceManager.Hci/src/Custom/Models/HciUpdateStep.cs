// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    // Backward compat: the GA SDK (1.2.1) exposed StartOn/EndOn/LastUpdatedOn as aliases
    // for the generated StartTimeUtc/EndTimeUtc/LastUpdatedTimeUtc properties.
    // Both names must coexist since we can't remove either without a breaking change.
    // TODO: after regen, the CodeGenSuppress will take effect and the generated properties
    // will be removed. Then uncomment the [Obsolete] re-declarations below to restore
    // the [Obsolete] attributes from GA and remove the baseline entries.
    [CodeGenSuppress("StartTimeUtc")]
    [CodeGenSuppress("EndTimeUtc")]
    [CodeGenSuppress("LastUpdatedTimeUtc")]
    public partial class HciUpdateStep
    {
        /// <summary> When the step started, or empty if it has not started executing. </summary>
        [WirePath("startTimeUtc")]
        public DateTimeOffset? StartOn { get; set; }

        /// <summary> When the step reached a terminal state. </summary>
        [WirePath("endTimeUtc")]
        public DateTimeOffset? EndOn { get; set; }

        /// <summary> Completion time of this step or the last completed sub-step. </summary>
        [WirePath("lastUpdatedTimeUtc")]
        public DateTimeOffset? LastUpdatedOn { get; set; }

        /// <summary> When the step started, or empty if it has not started executing. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `StartOn` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("startTimeUtc")]
        public DateTimeOffset? StartTimeUtc { get => StartOn; set => StartOn = value; }

        /// <summary> When the step reached a terminal state. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `EndOn` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("endTimeUtc")]
        public DateTimeOffset? EndTimeUtc { get => EndOn; set => EndOn = value; }

        /// <summary> Completion time of this step or the last completed sub-step. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("lastUpdatedTimeUtc")]
        public DateTimeOffset? LastUpdatedTimeUtc { get => LastUpdatedOn; set => LastUpdatedOn = value; }
    }
}
