// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// The type of the role.
    /// </summary>
    [CodeGenType("RoleType")]
    public readonly partial struct KeyVaultRoleType
    {
        /// <summary>
        /// Built-in role.
        /// </summary>
        public static KeyVaultRoleType BuiltInRole { get; } = new KeyVaultRoleType("AKVBuiltInRole");

        /// <summary>
        /// Custom role.
        /// </summary>
        public static KeyVaultRoleType CustomRole { get; } = new KeyVaultRoleType("CustomRole");
    }
}
