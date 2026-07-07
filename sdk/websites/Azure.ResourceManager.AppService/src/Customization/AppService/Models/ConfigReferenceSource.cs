// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
// Rename an anonymous model.
namespace Azure.ResourceManager.AppService.Models
{
    [CodeGenType("ApiKVReferencePropertiesSource")]
    public readonly partial struct ConfigReferenceSource
    {
    }
}
