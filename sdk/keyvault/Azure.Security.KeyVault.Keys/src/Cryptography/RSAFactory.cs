// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

using Azure.Core;
using Azure.Security.KeyVault.Keys;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Extensions for creating RSA objects from a Key Vault client.
    /// </summary>
    public static class RSAFactory
    {
        /// <summary>
        /// Creates an RSA object
        /// </summary>
        /// <param name="credential"></param>
        /// <param name="keyId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static RSA Create(TokenCredential credential, Uri keyId, JsonWebKey key)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            if (keyId == null)
            {
                throw new ArgumentNullException(nameof(keyId));
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return new RSAKeyVault(new KeyVaultContext(credential, keyId, key));
        }

        /// <summary>
        /// Creates an RSA object
        /// </summary>
        /// <param name="credential"></param>
        /// <param name="keyId"></param>
        /// <param name="publicCertificate"></param>
        /// <returns></returns>
        public static RSA Create(TokenCredential credential, Uri keyId, X509Certificate2 publicCertificate)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            if (keyId == null)
            {
                throw new ArgumentNullException(nameof(keyId));
            }

            if (publicCertificate == null)
            {
                throw new ArgumentNullException(nameof(publicCertificate));
            }

            return new RSAKeyVault(new KeyVaultContext(credential, keyId, publicCertificate));
        }
    }
}
