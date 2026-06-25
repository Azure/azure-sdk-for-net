// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class KeyVaultAndSecretReference
    {
        /// <summary> Initializes a new instance of <see cref="KeyVaultAndSecretReference"/>. </summary>
        /// <param name="sourceVault"> Resource id of the KeyVault containing the key or secret. </param>
        /// <param name="secretUri"> Url pointing to a key or secret in KeyVault. </param>
        public KeyVaultAndSecretReference(WritableSubResource sourceVault, Uri secretUri) : this(secretUri)
        {
            SourceVaultId = sourceVault?.Id;
        }
    }
}
