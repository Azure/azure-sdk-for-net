// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    /// <summary>
    /// Represents the encryption agent stored on the service.
    /// </summary>
    [DataContract]
    public struct EncryptionAgent
    {
        /// <summary>
        /// The protocol version used for encryption.
        /// </summary>
        [DataMember]
        public string Protocol { get; set; }

        /// <summary>
        /// The algorithm used for encryption.
        /// </summary>
        [DataMember]
        public ClientsideEncryptionAlgorithm Algorithm { get; set; }
    }
}
