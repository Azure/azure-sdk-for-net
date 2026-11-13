// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class AgentPoolAvailableVersions : ResourceData
    {
        /// <summary> List of versions available for agent pool. </summary>
        [WirePath("properties.agentPoolVersions")]
        public IReadOnlyList<AgentPoolAvailableVersion> AgentPoolVersions
        {
            get
            {
                return Properties is null ? default : Properties.AgentPoolVersions.ToArray();
            }
        }
    }
}
