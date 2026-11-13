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
    public partial class ManagedClusterUpgradeProfileData : ResourceData
    {
        /// <summary> The list of available upgrade versions for agent pools. </summary>
        [WirePath("properties.agentPoolProfiles")]
        public IReadOnlyList<ManagedClusterPoolUpgradeProfile> AgentPoolProfiles
        {
            get
            {
                return Properties is null ? default : Properties.AgentPoolProfiles.ToArray();
            }
        }
    }
}
