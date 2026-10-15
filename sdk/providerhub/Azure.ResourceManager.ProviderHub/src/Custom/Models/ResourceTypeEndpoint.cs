// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ProviderHub.Models
{
    [CodeGenSerialization(nameof(DstsConfiguration), "dstsConfiguration")]
    public partial class ResourceTypeEndpoint
    {
        // Preserve the released authentication configuration and its wire name.
        /// <summary> The dsts configuration. </summary>
        public ProviderDstsConfiguration DstsConfiguration { get; set; }
    }
}
