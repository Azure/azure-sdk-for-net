﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography
{
    /// <summary>
    /// An abstract Key Wrap Algorithm
    /// </summary>
    public abstract class KeyWrapAlgorithm : Algorithm
    {
        protected KeyWrapAlgorithm( string name )
            : base( name )
        {
        }

        /// <summary>
        /// Create an encryptor for the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="iv">The initialization vector</param>
        /// <returns>An ICryptoTranform for encrypting data</returns>
        public abstract ICryptoTransform CreateEncryptor( byte[] key, byte[] iv );

        /// <summary>
        /// Create a decryptor for the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="iv">The initialization vector</param>
        /// <returns>An ICryptoTransform for decrypting data</returns>
        public abstract ICryptoTransform CreateDecryptor( byte[] key, byte[] iv );
    }
}
