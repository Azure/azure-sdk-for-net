// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class KeyVaultSigningKey
    {
        // Backward compatibility: old API used KeyType property, new uses TypeName
        [EditorBrowsable(EditorBrowsableState.Never)]
        public KeyVaultSigningKeyType KeyType
        {
            get => TypeName;
            set => TypeName = value;
        }
    }
}
