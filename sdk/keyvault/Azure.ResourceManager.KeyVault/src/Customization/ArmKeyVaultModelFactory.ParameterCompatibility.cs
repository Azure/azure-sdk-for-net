// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.KeyVault.Models
{
    [CodeGenSuppress("KeyVaultCreateOrUpdateContent", typeof(ManagedServiceIdentity), typeof(AzureLocation), typeof(IDictionary<string, string>), typeof(KeyVaultProperties))]
    [CodeGenSuppress("KeyVaultPatch", typeof(ManagedServiceIdentity), typeof(IDictionary<string, string>), typeof(KeyVaultPatchProperties))]
    public static partial class ArmKeyVaultModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent"/>. </summary>
        /// <param name="location"> The supported Azure location where the key vault should be created. </param>
        /// <param name="tags"> The tags that will be assigned to the key vault. </param>
        /// <param name="properties"> Properties of the vault. </param>
        /// <param name="identity"> Managed service identity assigned to the vault. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.KeyVault.Models.KeyVaultCreateOrUpdateContent"/> instance for mocking. </returns>
        public static KeyVaultCreateOrUpdateContent KeyVaultCreateOrUpdateContent(AzureLocation location = default, IDictionary<string, string> tags = default, KeyVaultProperties properties = default, ManagedServiceIdentity identity = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new KeyVaultCreateOrUpdateContent(identity, location, tags, properties, default);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.KeyVault.Models.KeyVaultPatch"/>. </summary>
        /// <param name="tags"> The tags that will be assigned to the key vault. </param>
        /// <param name="properties"> Properties of the vault. </param>
        /// <param name="identity"> Managed service identity assigned to the vault. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.KeyVault.Models.KeyVaultPatch"/> instance for mocking. </returns>
        public static KeyVaultPatch KeyVaultPatch(IDictionary<string, string> tags = default, KeyVaultPatchProperties properties = default, ManagedServiceIdentity identity = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new KeyVaultPatch(identity, tags, properties, default);
        }
    }
}
