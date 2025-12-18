// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.KeyVault
{
    [CodeGenType("KeyVault")]
    public partial class KeyVaultData : TrackedResourceData
    {}
}
