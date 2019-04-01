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
        /// Creates a signature transformation implementation that may
        /// be used to sign or verify.
        /// </summary>
        /// <param name="key">The asymmetric key to use.</param>
        /// <returns>An ISignatureTransform implementation.</returns>
        /// <remarks>The transform implementation "borrows" the supplied
        /// AsymmetricAlgorithm; callers should not call Dispose on the
        /// AsymmetricAlgorithm until use of the transform implementation
        /// is complete.
        /// </remarks>
        public abstract ISignatureTransform CreateSignatureTransform( AsymmetricAlgorithm key );
    }
}
