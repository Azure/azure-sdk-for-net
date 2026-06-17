// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class KeyVaultSecretReference
    {
        /// <summary> Initializes a new instance of <see cref="KeyVaultSecretReference"/>. </summary>
        /// <param name="secretUri"> Url pointing to a key or secret in KeyVault. </param>
        /// <param name="sourceVault"> Resource id of the KeyVault containing the key or secret. </param>
        public KeyVaultSecretReference(Uri secretUri, WritableSubResource sourceVault) : this(secretUri)
        {
            SourceVaultId = sourceVault?.Id;
        }
    }
}
