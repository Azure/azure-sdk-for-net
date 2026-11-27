// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CognitiveServices.Models
{
    // The inline query-parameter type cannot be named in TypeSpec; identify the resource it applies to.
    [CodeGenType("DeleteRequestClusterDisposition")]
    public readonly partial struct AttachedAksClusterDeleteDisposition
    {
    }
}
