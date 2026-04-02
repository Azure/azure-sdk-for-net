// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupEncryptionProperties
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupEncryptionProperties"/>. </summary>
        /// <param name="vaultBaseUri"> The vault base URI. </param>
        /// <param name="keyName"> The key name. </param>
        /// <param name="keyVersion"> The key version. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupEncryptionProperties(Uri vaultBaseUri, string keyName, string keyVersion)
            : this(keyName, keyVersion)
        {
        }
    }
}
