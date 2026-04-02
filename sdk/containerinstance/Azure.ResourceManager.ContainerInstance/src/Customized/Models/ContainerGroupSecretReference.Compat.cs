// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupSecretReference
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupSecretReference"/>. </summary>
        /// <param name="secretName"> The secret name. </param>
        /// <param name="keyVaultId"> The key vault resource identifier. </param>
        /// <param name="keyVaultUrl"> The key vault URL. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupSecretReference(string secretName, ResourceIdentifier keyVaultId, Uri keyVaultUrl)
            : this(secretName, keyVaultId, keyVaultUrl, default)
        {
        }
    }
}
