// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ScVmm.Models
{
    // The base inventory model is renamed to ScVmmInventoryItemProperties for the shipped C# API,
    // but AutoRest named the internal unknown discriminator proxy UnknownInventoryItemProperties.
    // Keep that proxy type name so PersistableModelProxyAttribute remains ApiCompat-compatible.
    [CodeGenType("UnknownScVmmInventoryItemProperties")]
    internal partial class UnknownInventoryItemProperties
    {
    }
}
