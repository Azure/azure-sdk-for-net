// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class KeyVaultAndKeyReference
    {
        /// <summary> Initializes a new instance of <see cref="KeyVaultAndKeyReference"/>. </summary>
        /// <param name="sourceVault"> Resource id of the KeyVault containing the key or secret. </param>
        /// <param name="keyUri"> Url pointing to a key or secret in KeyVault. </param>
        public KeyVaultAndKeyReference(WritableSubResource sourceVault, Uri keyUri) : this(keyUri)
        {
            SourceVaultId = sourceVault?.Id;
        }
    }
}
