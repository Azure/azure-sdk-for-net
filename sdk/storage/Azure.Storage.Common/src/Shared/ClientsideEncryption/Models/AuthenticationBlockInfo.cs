// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.Cryptography.Models
{
    /// <summary>
    /// Describes the structure of authenticated encrypted blocks of data in a content stream.
    /// </summary>
    internal class AuthenticationBlockInfo
    {
        /// <summary>
        /// Length of the ciphertext block
        /// </summary>
        public long CiphertextLength { get; set; }

        /// <summary>
        /// Length of the nonce found in the content stream
        /// </summary>
        public int NonceLength { get; set; }

        public List<string> Order { get; set; }
    }
}
