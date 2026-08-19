// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class LifecycleStage
    {
        /// <summary> The lifecycle stage end time. </summary>
        [CodeGenMember("EndTimeUtc")]
        public DateTimeOffset? EndOn { get; }

        /// <summary> The time when the lifecycle stage was last updated. </summary>
        [CodeGenMember("LastUpdatedUtc")]
        public DateTimeOffset? LastUpdatedOn { get; }

        /// <summary> The lifecycle stage start time. </summary>
        [CodeGenMember("StartTimeUtc")]
        public DateTimeOffset? StartOn { get; }
    }
}
