// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.ComputeFleet.Models
{
    public partial class ComputeFleetKeyVaultSecretReference
    {
        /// <summary> Initializes a new instance of <see cref="ComputeFleetKeyVaultSecretReference"/>. </summary>
        /// <param name="secretUri"> The URL referencing a secret in a Key Vault. </param>
        /// <param name="sourceVault"> The relative URL of the Key Vault containing the secret. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="secretUri"/> or <paramref name="sourceVault"/> is null. </exception>
        public ComputeFleetKeyVaultSecretReference(Uri secretUri, WritableSubResource sourceVault) : this(secretUri)
        {
            SourceVault = new(sourceVault.Id, null);
        }
    }
}
