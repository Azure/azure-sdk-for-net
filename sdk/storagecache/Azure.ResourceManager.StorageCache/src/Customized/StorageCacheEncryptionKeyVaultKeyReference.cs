// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.StorageCache.Models
{
    public partial class StorageCacheEncryptionKeyVaultKeyReference
    {
        /// <summary> Initializes a new instance of <see cref="StorageCacheEncryptionKeyVaultKeyReference"/>. </summary>
        /// <param name="keyUri"> The URL referencing a key encryption key in key vault. </param>
        /// <param name="sourceVault"> Describes a resource Id to source key vault. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="keyUri"/> is null. </exception>
        public StorageCacheEncryptionKeyVaultKeyReference(Uri keyUri, WritableSubResource sourceVault)
            : this(keyUri)
        {
            SourceVaultId = sourceVault?.Id;
        }
    }
}
