// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Hci.Models
{
    // Backward-compat: preserve old property names as aliases
    public partial class HciUpdateStep
    {
        /// <summary> When the step started, or empty if it has not started executing. </summary>
        public DateTimeOffset? StartOn { get => StartTimeUtc; set => StartTimeUtc = value; }

        /// <summary> When the step reached a terminal state. </summary>
        public DateTimeOffset? EndOn { get => EndTimeUtc; set => EndTimeUtc = value; }

        /// <summary> Completion time of this step or the last completed sub-step. </summary>
        public DateTimeOffset? LastUpdatedOn { get => LastUpdatedTimeUtc; set => LastUpdatedTimeUtc = value; }
    }
}
