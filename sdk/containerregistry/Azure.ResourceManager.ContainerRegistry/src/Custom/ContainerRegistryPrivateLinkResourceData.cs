// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerRegistry
{
    // Backward-compatibility: restores the public parameterless constructor that
    // was present in the AutoRest-generated SDK (≤ 1.4.0), and overrides
    // RequiredZoneNames to return IReadOnlyList<string> for ApiCompat.
    [CodeGenSuppress("RequiredZoneNames")]
    public partial class ContainerRegistryPrivateLinkResourceData
    {
        /// <summary> Initializes a new instance of <see cref="ContainerRegistryPrivateLinkResourceData"/>. </summary>
        public ContainerRegistryPrivateLinkResourceData()
        { }

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
