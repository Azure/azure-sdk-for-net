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
    }
}
