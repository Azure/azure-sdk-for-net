using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.Cryptography
{
    /// <summary>
    /// Represents the envelope key details stored on the service.
    /// </summary>
    internal struct WrappedKey
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
