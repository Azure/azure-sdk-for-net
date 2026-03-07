// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct EncryptionScopeSource
    {
        /// <summary> Microsoft.KeyVault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EncryptionScopeSource KeyVault => MicrosoftKeyVault;

        /// <summary> Microsoft.Storage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EncryptionScopeSource Storage => MicrosoftStorage;
    }
}
