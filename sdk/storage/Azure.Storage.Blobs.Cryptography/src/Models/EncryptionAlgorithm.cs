// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    /// <summary>
    /// Specifies the encryption algorithm used to encrypt a resource.
    /// </summary>
    public enum ClientsideEncryptionAlgorithm
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores; supressed for serialization dependencies
        /// <summary>
        /// AES-CBC using a 256 bit key.
        /// </summary>
        AES_CBC_256
#pragma warning restore CA1707 // Identifiers should not contain underscores
    }
}
