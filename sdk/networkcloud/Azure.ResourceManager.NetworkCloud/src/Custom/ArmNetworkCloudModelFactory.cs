// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // The generated factory retains the synthesized flattened name even when CodeGenMember renames the property.
    [CodeGenSuppress("NetworkCloudClusterManagerPatch", typeof(ManagedServiceIdentity), typeof(IDictionary<string, string>), typeof(int?))]
    // Keep the released parameter prefix so null URI arguments do not become ambiguous with the new string parameter.
    [CodeGenSuppress("SecretArchiveSettings", typeof(ManagedServiceIdentitySelector), typeof(string), typeof(SecretArchiveProviderConfiguration), typeof(Uri))]
    public static partial class ArmNetworkCloudModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch"/>. </summary>
        /// <param name="identity"> The identity for the resource. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="rolloutRing"> The relative ordering group used to apply software updates to associated clusters. </param>
        /// <returns> A new <see cref="Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch"/> instance for mocking. </returns>
        public static NetworkCloudClusterManagerPatch NetworkCloudClusterManagerPatch(ManagedServiceIdentity identity = default, IDictionary<string, string> tags = default, int? rolloutRing = default)
        {
            return new NetworkCloudClusterManagerPatch(
                identity,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                rolloutRing is null ? default : new ClusterManagerPatchProperties(rolloutRing, default),
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings"/>. </summary>
        /// <param name="associatedIdentity"> The selection of the managed identity to use with this vault URI. The identity type must be either system assigned or user assigned. </param>
        /// <param name="vaultUri"> The URI of the secret archive endpoint. The URI must use the `https://` scheme. </param>
        /// <param name="encryptionPublicKey"> The public key used to encrypt secrets before they are written to the secret archive. Expected encoding is a PEM-encoded RSA public key with a minimum key size of 3072 bits. Additional key formats or sizes may be supported in future versions. </param>
        /// <param name="providerConfiguration"> The configuration indicating the use of self-supplied secret archive software. Specification of a provider configuration indicates that the provided configuration will be used. Exclusion of any providerConfiguration indicates the use of Azure Key Vault. If providerConfiguration is included in a PATCH, the body must be a complete, valid configuration for the chosen provider, including all fields required for that provider; omit providerConfiguration from PATCH bodies that do not change it. </param>
        /// <returns> A new <see cref="Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings"/> instance for mocking. </returns>
        public static SecretArchiveSettings SecretArchiveSettings(ManagedServiceIdentitySelector associatedIdentity = default, Uri vaultUri = default, string encryptionPublicKey = default, SecretArchiveProviderConfiguration providerConfiguration = default)
        {
            return new SecretArchiveSettings(associatedIdentity, encryptionPublicKey, providerConfiguration, vaultUri, default);
        }
    }
}
