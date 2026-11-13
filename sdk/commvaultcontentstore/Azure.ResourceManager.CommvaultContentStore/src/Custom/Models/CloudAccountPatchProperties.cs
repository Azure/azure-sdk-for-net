// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CommvaultContentStore.Models
{
    // [SUFFIX006] "Update" is an avoid-suffix; PATCH-body property bags use "Patch".
    // The generator synthesizes this type from ResourceUpdateModel<CloudAccount, CloudAccountProperties>,
    // so it cannot be renamed via @clientName in the spec; rename it here via [CodeGenType].
    [CodeGenType("CloudAccountUpdateProperties")]
    public partial class CloudAccountPatchProperties
    {
    }
}
