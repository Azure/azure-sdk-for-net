// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Cryptography.Models
{
    /// <summary>
    /// Represents the encryption agent stored on the service.
    /// </summary>
    internal class EncryptionAgent
    {
        /// <summary>
        /// The protocol version used for encryption.
        /// </summary>
        public ClientSideEncryptionVersionInternal EncryptionVersion { get; set; }

        /// <summary>
        /// The algorithm used for encryption.
        /// </summary>
        public ClientSideEncryptionAlgorithm EncryptionAlgorithm { get; set; }
    }
}
