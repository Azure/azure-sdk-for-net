// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256".
    /// Must be provided if the x-ms-encryption-key header is provided.
    /// </summary>
    [CodeGenModel("EncryptionAlgorithmType")]
    internal enum EncryptionAlgorithmTypeInternal
    {
        /// <summary>
        /// None.
        /// </summary>
        None,

        /// <summary>
        /// AES256.
        /// </summary>
        AES256
    }
}
