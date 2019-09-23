using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    /// <summary>
    /// Specifies the encryption algorithm used to encrypt a resource.
    /// </summary>
    internal enum ClientsideEncryptionAlgorithm
    {
        /// <summary>
        /// AES-CBC using a 256 bit key.
        /// </summary>
        AES_CBC_256
    }
}
