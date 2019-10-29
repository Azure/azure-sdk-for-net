//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using System;
using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    /// <summary>
    /// Abstract Elliptic Curve Digital Signature Algorithm (ECDSA).
    /// </summary>
    public abstract class Ecdsa : AsymmetricSignatureAlgorithm
    {
        protected Ecdsa( string name ) : base( name )
        {
        }

        protected static ISignatureTransform CreateSignatureTransform( AsymmetricAlgorithm key, string algorithmName )
        {
            if ( key == null )
                throw new ArgumentNullException( nameof( key ) );

            var ecdsa = key as ECDsa;
            if ( ecdsa == null )
                throw new ArgumentException( "Invalid key type." );

#if FullNetFx
            if ( ecdsa.SignatureAlgorithm != algorithmName )
                throw new ArgumentException( $"Invalid key algorithm. Expected {algorithmName}, found {ecdsa.SignatureAlgorithm}." );
#endif

            return new EcdsaSignatureTransform( ecdsa );
        }
    }

    internal sealed class EcdsaSignatureTransform : ISignatureTransform
    {
        private readonly ECDsa _key;

        public EcdsaSignatureTransform(ECDsa key)
        {
            _key = key;
        }

        public byte[] Sign(byte[] digest)
        {
            return _key.SignHash(digest);
        }

        public bool Verify(byte[] digest, byte[] signature)
        {
            return _key.VerifyHash(digest, signature);
        }
    }

}
