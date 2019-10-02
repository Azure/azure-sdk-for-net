// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    /// <summary>
    /// Represents the envelope key details stored on the service.
    /// </summary>
    [DataContract]
    public struct WrappedKey
    {
        /// <summary>
        /// The key identifier string.
        /// </summary>
        [DataMember]
        public string KeyId { get; set; }

        /// <summary>
        /// The encrypted content encryption key.
        /// </summary>
        [DataMember]
        public byte[] EncryptedKey { get; set; }

        /// <summary>
        /// The algorithm used for wrapping.
        /// </summary>
        [DataMember]
        public string Algorithm { get; set; }
    }
}
