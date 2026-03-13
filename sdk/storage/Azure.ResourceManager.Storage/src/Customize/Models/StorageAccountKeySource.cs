// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden enum aliases for older key-source names.
// Could use @@clientName on enum values in spec.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct StorageAccountKeySource
    {
        /// <summary> Microsoft.Keyvault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageAccountKeySource KeyVault => MicrosoftKeyvault;

        /// <summary> Microsoft.Storage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageAccountKeySource Storage => MicrosoftStorage;
    }
}
