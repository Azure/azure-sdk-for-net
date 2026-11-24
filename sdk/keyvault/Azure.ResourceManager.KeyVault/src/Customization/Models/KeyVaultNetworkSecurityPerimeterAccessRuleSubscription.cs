// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.KeyVault.Models
{
    // The common-type schema creates this inline model without a TypeSpec symbol that client.tsp can rename.
    // Include Key Vault and NSP context to distinguish it from other subscription models.
    [CodeGenType("AccessRulePropertiesSubscription")]
    public partial class KeyVaultNetworkSecurityPerimeterAccessRuleSubscription
    {
    }
}
