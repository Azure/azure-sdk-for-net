// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography
{
    /// <summary>
    /// Abstract Encryption Algorithm
    /// </summary>
    public abstract class EncryptionAlgorithm : Algorithm
    {
        protected EncryptionAlgorithm( string name ) : base( name )
        {
        }
    }

    /// <summary>
    /// Abstract Asymmetric Algorithm
    /// </summary>
    public abstract class AsymmetricEncryptionAlgorithm : EncryptionAlgorithm
    {
        protected AsymmetricEncryptionAlgorithm( string name )
            : base( name )
        {
        }

        /// <summary>
        /// Create an encryptor for the specified key
        /// </summary>
        /// <param name="key">The key used to create the encryptor</param>
        /// <returns>An ICryptoTransform for encrypting data</returns>
        public abstract ICryptoTransform CreateEncryptor( AsymmetricAlgorithm key );

        /// <summary>
        /// Create a decryptor for the specified key
        /// </summary>
        /// <param name="key">The key used to create decryptor</param>
        /// <returns>An ICryptoTransform for encrypting data</returns>
        public abstract ICryptoTransform CreateDecryptor( AsymmetricAlgorithm key );
    }

    /// <summary>
    /// Abstract Symmetric Algorithm
    /// </summary>
    public abstract class SymmetricEncryptionAlgorithm : EncryptionAlgorithm
    {
        protected SymmetricEncryptionAlgorithm( string name )
            : base( name )
        {
        }

        /// <summary>
        /// Create an encryptor for the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="iv">The initialization vector</param>
        /// <param name="authenticationData">Authentication data</param>
        /// <returns>An ICryptoTranform for encrypting data</returns>
        public abstract ICryptoTransform CreateEncryptor( byte[] key, byte[] iv, byte[] authenticationData );

        /// <summary>
        /// Crea a decryptor for the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="iv">The initialization vector</param>
        /// <param name="authenticationData">Authentication data</param>
        /// <returns>An ICryptoTransform for decrypting data</returns>
        public abstract ICryptoTransform CreateDecryptor( byte[] key, byte[] iv, byte[] authenticationData );
    }
}
