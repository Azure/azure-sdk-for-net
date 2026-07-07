// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService
{
    public partial class AgentPoolUpgradeProfileData : ResourceData
    {
        /// <summary> List of orchestrator types and versions available for upgrade. </summary>
        [WirePath("properties.upgrades")]
        public IReadOnlyList<AgentPoolUpgradeProfilePropertiesUpgradesItem> Upgrades
        {
            get
            {
                var upgrades = Properties?.Upgrades;
                return upgrades is null ? default : upgrades.ToArray();
            }
        }
    }
}
