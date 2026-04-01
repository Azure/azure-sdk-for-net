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
        public DateTimeOffset? StartTimeUtc
        {
            get => throw new NotSupportedException("This property is obsolete. Use StartOn instead.");
            set => throw new NotSupportedException("This property is obsolete. Use StartOn instead.");
        }

        /// <summary> When the step reached a terminal state. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `EndOn` moving forward.")]
        [WirePath("endTimeUtc")]
        public DateTimeOffset? EndTimeUtc
        {
            get => throw new NotSupportedException("This property is obsolete. Use EndOn instead.");
            set => throw new NotSupportedException("This property is obsolete. Use EndOn instead.");
        }

        /// <summary> Completion time of this step or the last completed sub-step. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
        [WirePath("lastUpdatedTimeUtc")]
        public DateTimeOffset? LastUpdatedTimeUtc
        {
            get => throw new NotSupportedException("This property is obsolete. Use LastUpdatedOn instead.");
            set => throw new NotSupportedException("This property is obsolete. Use LastUpdatedOn instead.");
        }

        /// <summary> When the step started, or empty if it has not started executing. </summary>
        [WirePath("startTimeUtc")]
        public DateTimeOffset? StartOn { get; set; }

        /// <summary> When the step reached a terminal state. </summary>
        [WirePath("endTimeUtc")]
        public DateTimeOffset? EndOn { get; set; }

        /// <summary> Completion time of this step or the last completed sub-step. </summary>
        [WirePath("lastUpdatedTimeUtc")]
        public DateTimeOffset? LastUpdatedOn { get; set; }
    }
}
