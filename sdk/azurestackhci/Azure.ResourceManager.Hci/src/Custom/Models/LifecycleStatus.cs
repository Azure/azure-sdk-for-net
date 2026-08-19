// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class LifecycleStatus
    {
        /// <summary> The time when the lifecycle status was last updated. </summary>
        [CodeGenMember("LastUpdatedUtc")]
        public DateTimeOffset LastUpdatedOn { get; }
    }
}
