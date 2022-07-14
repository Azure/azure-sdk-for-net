// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary> The secret info when type is keyVaultSecretReference. It&apos;s for scenario that user provides a secret stored in user&apos;s keyvault and source is Azure Kubernetes. The key Vault&apos;s resource id is linked to secretStore.keyVaultId. </summary>
    [CodeGenSuppress("KeyVaultSecretReferenceSecretInfo", typeof(LinkerSecretType), typeof(string), typeof(string))]
    public partial class KeyVaultSecretReferenceSecretInfo : SecretBaseInfo
    {
        /// <summary> Initializes a new instance of KeyVaultSecretReferenceSecretInfo. </summary>
        /// <param name="secretType"> The secret type. </param>
        /// <param name="name"> Name of the Key Vault secret. </param>
        /// <param name="version"> Version of the Key Vault secret. </param>
        internal KeyVaultSecretReferenceSecretInfo(LinkerSecretType secretType, string name, string version)
        {
            Name = name;
            Version = version;
            SecretType = secretType;
        }
    }
}
