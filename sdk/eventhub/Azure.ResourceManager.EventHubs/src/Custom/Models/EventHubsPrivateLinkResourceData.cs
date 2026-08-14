// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventHubs.Models
{
    // Override the generated RequiredMembers and RequiredZoneNames properties to return IReadOnlyList<string>
    // instead of IList<string> for backward compatibility with the old AutoRest-generated SDK (version 1.2.x).
    public partial class EventHubsPrivateLinkResourceData
    {
        /// <summary> The private link resource required member names. </summary>
        [WirePath("properties.requiredMembers")]
        public IReadOnlyList<string> RequiredMembers
        {
            get { return Properties?.RequiredMembers as IReadOnlyList<string>; }
        }

        /// <summary> The private link resource Private link DNS zone name. </summary>
        [WirePath("properties.requiredZoneNames")]
        public IReadOnlyList<string> RequiredZoneNames
        {
            get { return Properties?.RequiredZoneNames as IReadOnlyList<string>; }
        }
    }
}
