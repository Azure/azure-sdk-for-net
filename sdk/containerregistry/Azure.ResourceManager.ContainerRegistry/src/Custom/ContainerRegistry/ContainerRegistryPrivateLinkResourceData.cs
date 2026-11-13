// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerRegistry
{
    public partial class ContainerRegistryPrivateLinkResourceData
    {
        /// <summary> The private link resource private link DNS zone name. </summary>
        [WirePath("properties.requiredZoneNames")]
        public IReadOnlyList<string> RequiredZoneNames
        {
            get
            {
                return (IReadOnlyList<string>)Properties.RequiredZoneNames;
            }
        }
    }
}
