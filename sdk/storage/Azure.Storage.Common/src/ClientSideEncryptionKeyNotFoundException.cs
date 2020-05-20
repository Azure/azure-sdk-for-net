// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage
{
    /// <summary>
    /// Thrown when the client fails to resolve the necessary key to decrypt data using client-side encryption.
    /// </summary>
    public class ClientSideEncryptionKeyNotFoundException : Exception
    {
        /// <summary>
        /// Key that could not be resolved.
        /// </summary>
        public string KeyId { get; }

        /// <summary>
        /// Constructs the exception.
        /// </summary>
        /// <param name="keyId">Key id.</param>
        public ClientSideEncryptionKeyNotFoundException(string keyId)
            : base($"Provided key resolver ould not resolve key of id `{keyId}`.")
        {
            KeyId = keyId;
        }
    }
}
