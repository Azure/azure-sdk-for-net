//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

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
