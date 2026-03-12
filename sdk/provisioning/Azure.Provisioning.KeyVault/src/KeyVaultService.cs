// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.KeyVault
{
    /// <summary>
    /// Customization to preserve the original KeyVaultService name for backward compatibility.
    /// </summary>
    [CodeGenType("KeyVault")]
    public partial class KeyVaultService
    {
    }
}
