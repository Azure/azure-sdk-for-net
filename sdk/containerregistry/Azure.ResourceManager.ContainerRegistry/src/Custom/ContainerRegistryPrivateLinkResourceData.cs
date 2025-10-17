// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerRegistry
{
    public partial class ContainerRegistryPrivateLinkResourceData
    {
        // This is a usage change in api version 2025-11-01, add this property back for compatibility reason.
        /// <summary> The private link resource Private link DNS zone name. </summary>
        [WirePath("properties.requiredZoneNames")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<string> RequiredZoneNames { get => (IReadOnlyList<string>)RequiredZoneNamesList; }
    }
}
