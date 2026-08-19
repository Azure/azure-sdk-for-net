// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    public abstract partial class EdgeMachineNetworkAdapterJobProperties
    {
        /// <summary> The job end time. </summary>
        [CodeGenMember("EndTimeUtc")]
        public DateTimeOffset? EndOn { get; }

        /// <summary> The job start time. </summary>
        [CodeGenMember("StartTimeUtc")]
        public DateTimeOffset? StartOn { get; }
    }
}
