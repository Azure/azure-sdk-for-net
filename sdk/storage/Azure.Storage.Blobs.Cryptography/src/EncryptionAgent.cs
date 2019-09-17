using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Cryptography
{
    /// <summary>
    /// Represents the encryption agent stored on the service.
    /// </summary>
    internal struct EncryptionAgent
    {
        /// <summary>
        /// The protocol version used for encryption.
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// The algorithm used for encryption.
        /// </summary>
        public EncryptionAlgorithmType Algorithm { get; set; }
    }
}
