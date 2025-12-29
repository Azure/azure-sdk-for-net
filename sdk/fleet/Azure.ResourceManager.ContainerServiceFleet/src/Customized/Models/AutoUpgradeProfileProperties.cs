// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ContainerServiceFleet.Models
{
    [CodeGenType(nameof(AutoUpgradeProfileProperties))]
    internal partial class AutoUpgradeProfileProperties
    {
        /// <summary> Configures how auto-upgrade will be run. </summary>
        [CodeGenMember("Channel")]
        public ContainerServiceFleetUpgradeChannel? Channel { get; set; }
    }
}
