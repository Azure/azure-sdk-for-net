// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class KeyVaultKeyReference
    {
        /// <summary> Initializes a new instance of <see cref="KeyVaultKeyReference"/>. </summary>
        /// <param name="keyUri"> Url pointing to a key or secret in KeyVault. </param>
        /// <param name="sourceVault"> Resource id of the KeyVault containing the key or secret. </param>
        public KeyVaultKeyReference(Uri keyUri, WritableSubResource sourceVault) : this(keyUri)
        {
            SourceVaultId = sourceVault?.Id;
        }
    }
}
