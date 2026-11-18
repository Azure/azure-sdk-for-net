// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    public partial class RouteData
    {
        // 1.15.0 exposed a setter; read the actual native response value instead of retaining disconnected storage.
        /// <summary> Gets whether this route overrides overlapping BGP routes. </summary>
        /// <remarks> The setter is retained for compatibility with version 1.15.0. Assignments have no effect because the current service model treats this property as read-only. </remarks>
        [CodeGenMember("HasBgpOverride")]
        [WirePath("properties.hasBgpOverride")]
        public bool? HasBgpOverride
        {
            get => Properties?.HasBgpOverride;
            set
            {
                // The current service model does not accept this flag in requests.
            }
        }
    }
}
