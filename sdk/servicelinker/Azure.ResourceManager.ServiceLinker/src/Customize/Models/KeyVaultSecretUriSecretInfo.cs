// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary> The secret info when type is keyVaultSecretUri. It&apos;s for scenario that user provides a secret stored in user&apos;s keyvault and source is Web App, Spring Cloud or Container App. </summary>
    [CodeGenSuppress("KeyVaultSecretUriSecretInfo", typeof(LinkerSecretType), typeof(string))]
    public partial class KeyVaultSecretUriSecretInfo : SecretBaseInfo
    {
        /// <summary> Initializes a new instance of KeyVaultSecretUriSecretInfo. </summary>
        /// <param name="secretType"> The secret type. </param>
        /// <param name="value"> URI to the keyvault secret. </param>
        internal KeyVaultSecretUriSecretInfo(LinkerSecretType secretType, string value)
        {
            Value = value;
            SecretType = secretType;
        }
    }
}
