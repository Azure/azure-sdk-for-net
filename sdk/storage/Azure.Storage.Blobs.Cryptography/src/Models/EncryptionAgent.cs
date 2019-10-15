// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Specialized.Models
{
    /// <summary>
    /// Represents the encryption agent stored on the service.
    /// </summary>
    public class EncryptionAgent
    {
        /// <summary>
        /// The protocol version used for encryption.
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// The algorithm used for encryption.
        /// </summary>
        public string EncryptionAlgorithm { get; set; }
    }
}
