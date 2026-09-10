// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.KeyVault
{
    // The TypeSpec spec defines the resource as "KeyVault", but the existing provisioning library
    // uses "KeyVaultService" to avoid collision with the namespace. This customization renames
    // the generated "KeyVault" type to "KeyVaultService" for backward compatibility.
    [CodeGenType("KeyVault")]
    public partial class KeyVaultService
    {
    }
}
