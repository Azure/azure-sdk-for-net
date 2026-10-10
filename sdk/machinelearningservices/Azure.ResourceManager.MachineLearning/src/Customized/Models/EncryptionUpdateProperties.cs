// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The EncryptionUpdateProperties. </summary>
    public partial class EncryptionUpdateProperties
    {
        /// <summary> Initializes a new instance of EncryptionUpdateProperties. </summary>
        /// <param name="keyIdentifier"></param>
        public EncryptionUpdateProperties(string keyIdentifier)
        {
            KeyVaultProperties = new EncryptionKeyVaultUpdateProperties(keyIdentifier);
        }

        // The generated constructor follows the current TypeSpec shape, but GA exposed this keyVaultProperties-only overload.
        // TypeSpec decorators cannot create constructor overloads, so keep the compatibility overload in SDK custom code.
        /// <summary> Initializes a new instance of <see cref="EncryptionUpdateProperties"/>. </summary>
        public EncryptionUpdateProperties(EncryptionKeyVaultUpdateProperties keyVaultProperties) : this(keyVaultProperties, null)
        {
        }
    }
}
