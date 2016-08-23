// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.WebKey
{
    public static class JsonWebKeyExtensions
    {
        /// <summary>
        /// Converts a WebKey of type Octet to an AES object.
        /// </summary>        
        /// <returns>An initialize AES provider</returns>
        /// <remarks>Throws InvalidOperationException if the JsonWebKey is not an Octet key</remarks>
        public static Aes ToAes( this JsonWebKey self )
        {
            if ( self == null )
                throw new ArgumentNullException( "self" );

            if ( !self.Kty.Equals( JsonWebKeyType.Octet ) )
                throw new InvalidOperationException( "key is not an octet key" );

            if ( self.K == null )
                throw new InvalidOperationException( "key does not contain a value" );

            Aes aesProvider = Aes.Create();

            if ( aesProvider != null )
                aesProvider.Key = self.K;

            return aesProvider;
        }

        /// <summary>
        /// Converts a WebKey of type RSA or RSA-HSM to a RSA provider
        /// </summary>
        /// <param name="includePrivateParameters">Determines whether private key material, if available, is included</param>
        /// <returns>An initialized RSACryptoServiceProvider instance</returns>
        /// <remarks>Throws InvalidOperationException if the JsonWebKey is not RSA key</remarks>
        public static RSACryptoServiceProvider ToRSA( this JsonWebKey self, bool includePrivateParameters = false )
        {
            if ( self == null )
                throw new ArgumentNullException( "self" );

            var rsaParameters = self.ToRSAParameters( includePrivateParameters );
            var rsaProvider   = new RSACryptoServiceProvider();

            rsaProvider.ImportParameters( rsaParameters );

            return rsaProvider;
        }


        /// <summary>
        /// Converts a WebKey of type RSA or RSA-HSM to a RSA provider
        /// </summary>
        /// <param name="includePrivateParameters">Determines whether private key material, if available, is included</param>
        /// <returns>An initialized RSACryptoServiceProvider instance</returns>
        /// <remarks>Throws InvalidOperationException if the JsonWebKey is not a RSA key</remarks>
        public static RSAParameters ToRSAParameters( this JsonWebKey self, bool includePrivateParameters = false )
        {
            if ( self == null )
                throw new ArgumentNullException( "self" );

            if ( !string.Equals( JsonWebKeyType.Rsa, self.Kty ) && !string.Equals( JsonWebKeyType.RsaHsm, self.Kty ) )
                throw new InvalidOperationException( "Key is not a RSA key" );

            var result = new RSAParameters()
            {
                Modulus  = self.N,
                Exponent = self.E,
            };

            if ( includePrivateParameters )
            {
                result.D        = self.D;
                result.DP       = self.DP;
                result.DQ       = self.DQ;
                result.InverseQ = self.QI;
                result.P        = self.P;
                result.Q        = self.Q;
            }

            return result;
        }
    }
 }
