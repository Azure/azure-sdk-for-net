// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Specialized.Models
{
    /// <summary>
    /// Represents the envelope key details stored on the service.
    /// </summary>
    public class WrappedKey
    {
        /// <summary>
        /// The key identifier string.
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        /// The encrypted content encryption key.
        /// </summary>
        public byte[] EncryptedKey { get; set; }

        /// <summary>
        /// The algorithm used for wrapping.
        /// </summary>
        public string Algorithm { get; set; }
    }
}
