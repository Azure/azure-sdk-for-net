// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The algorithm used to produce the encryption key hash. Currently, the only accepted value is "AES256".
    /// Must be provided if the x-ms-encryption-key header is provided.
    /// </summary>
    public enum EncryptionAlgorithmType
    {
        /// <summary>
        /// AES256
        /// </summary>
        Aes256
    }
}
