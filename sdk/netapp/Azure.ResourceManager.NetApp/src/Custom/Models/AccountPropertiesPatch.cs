// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetApp.Models
{
    [CodeGenSerialization(nameof(EntraIdConfig), "entraIdConfig")]
    internal partial class AccountPropertiesPatch
    {
        // Older preview API versions include this member even though 2026-09-01 does not.
        public EntraIdConfigPatch EntraIdConfig { get; set; }
    }
}
