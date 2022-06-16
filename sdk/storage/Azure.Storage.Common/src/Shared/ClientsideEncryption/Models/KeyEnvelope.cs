// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.Cryptography;

namespace Azure.Storage.Cryptography.Models
{
    /// <summary>
    /// Represents the envelope key details JSON schema stored on the service.
    /// In the envelope technique, a securely generated content encryption key (CEK) is generated
    /// for every encryption operation. It is then encrypted (wrapped) with the user-provided key
    /// encryption key (KEK), using a key-wrap algorithm. The wrapped CEK is stored with the
    /// encrypted data, and needs the KEK to be unwrapped. The KEK and key-wrapping operation is
    /// never seen by this SDK.
    /// </summary>
    internal class KeyEnvelope
    {
        /// <summary>
        /// The key identifier string.
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        /// The encrypted content encryption key.
        /// In V2, the content encryption algorithm is wrapped in with the key,
        /// authenticating the selected decryption algorithm.
        /// </summary>
        public byte[] EncryptedKey { get; set; }

        /// <summary>
        /// The algorithm used to wrap the content encryption key.
        /// </summary>
        public string Algorithm { get; set; }
    }
}
