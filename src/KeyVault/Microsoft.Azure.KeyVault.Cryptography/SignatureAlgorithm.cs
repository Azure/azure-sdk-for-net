// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography
{
    /// <summary>
    /// Abstract SignatureAlgorithm
    /// </summary>
    public abstract class SignatureAlgorithm : Algorithm
    {
        protected SignatureAlgorithm( string name )
            : base( name )
        {
        }
    }

    /// <summary>
    /// Abstract Asymmetric Signature algorithm
    /// </summary>
    public abstract class AsymmetricSignatureAlgorithm : SignatureAlgorithm
    {
        protected AsymmetricSignatureAlgorithm( string name )
            : base( name )
        {
        }

        /// <summary>
        /// Sign a digest using the specified key
        /// </summary>
        /// <param name="key">The key to use</param>
        /// <param name="digest">The digest to sign</param>
        /// <returns>The signature</returns>
        public abstract byte[] SignHash( AsymmetricAlgorithm key, byte[] digest );

        /// <summary>
        /// Verify a signature of a digest using the specified key
        /// </summary>
        /// <param name="key">The key to use</param>
        /// <param name="digest">The digest that was signed</param>
        /// <param name="signature">The signature value</param>
        /// <returns>True if the computed signature matches the supplied signature</returns>
        public abstract bool VerifyHash( AsymmetricAlgorithm key, byte[] digest, byte[] signature );
    }
}
