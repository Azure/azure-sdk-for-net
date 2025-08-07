// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary> Progress representation of the update run steps. </summary>
    public partial class HciUpdateStep
    {
        /// <summary> When the step started, or empty if it has not started executing. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `StartOn` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? StartTimeUtc { get => StartOn; set => StartOn = value; }
        /// <summary> When the step reached a terminal state. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `EndOn` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? EndTimeUtc { get => EndOn; set => EndOn = value; }
        /// <summary> Completion time of this step or the last completed sub-step. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? LastUpdatedTimeUtc { get => LastUpdatedOn; set => LastUpdatedOn = value; }
    }
}
