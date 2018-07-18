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

using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Win32.SafeHandles;

namespace Microsoft.Azure.KeyVault
{
    public static class KeyVaultClientExtensions
    {
        /// <summary>
        /// Decrypts a single block of encrypted data.
        /// </summary>
        /// <param name="keyBundle">The key to use for decryption</param>
        /// <param name="algorithm">The encryption algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <param name="cipherText">The encrypted data</param>
        /// <returns></returns>
        public static async Task<KeyOperationResult> DecryptDataAsync( this KeyVaultClient client, KeyBundle keyBundle, string algorithm, byte[] cipherText )
        {
            if ( keyBundle == null )
                throw new ArgumentNullException( "keyBundle" );

            return await client.DecryptDataAsync( keyBundle.Key, algorithm, cipherText ).ConfigureAwait( false );
        }

        /// <summary>
        /// Decrypts a single block of encrypted data.
        /// </summary>
        /// <param name="key">The web key to use for decryption</param>
        /// <param name="algorithm">The encryption algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <param name="cipherText">The encrypted data</param>
        /// <returns></returns>
        public static async Task<KeyOperationResult> DecryptDataAsync( this KeyVaultClient client, JsonWebKey key, string algorithm, byte[] cipherText )
        {
            if ( key == null )
                throw new ArgumentNullException( "key" );

            return await client.DecryptAsync( key.Kid, algorithm, cipherText ).ConfigureAwait( false );
        }

        /// <summary>
        /// Encrypts a single block of data. The amount of data that may be encrypted is determined
        /// by the target key type and the encryption algorithm.
        /// </summary>
        /// <param name="keyBundle">The key bundle to use for encryption</param>
        /// <param name="algorithm">The encryption algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <param name="plaintext">The plain text to encrypt</param>
        /// <returns></returns>
        public static async Task<KeyOperationResult> EncryptDataAsync( this KeyVaultClient client, KeyBundle keyBundle, string algorithm, byte[] plaintext )
        {
            if ( keyBundle == null )
                throw new ArgumentNullException( "keyBundle" );

            return await client.EncryptDataAsync( keyBundle.Key, algorithm, plaintext ).ConfigureAwait( false );
        }

        /// <summary>
        /// Encrypts a single block of data. The amount of data that may be encrypted is determined
        /// by the target key type and the encryption algorithm.
        /// </summary>
        /// <param name="key">The web key to use for encryption</param>
        /// <param name="algorithm">The encryption algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <param name="plaintext">The plain text to encrypt</param>
        /// <returns></returns>
        public static async Task<KeyOperationResult> EncryptDataAsync( this KeyVaultClient client, JsonWebKey key, string algorithm, byte[] plaintext )
        {            
            if ( key == null )
                throw new ArgumentNullException( "key" );

            if ( string.IsNullOrEmpty( algorithm ) )
                throw new ArgumentNullException( "algorithm" );

            if ( plaintext == null )
                throw new ArgumentNullException( "plaintext" );

            return await client.EncryptAsync( key.Kid, algorithm, plaintext ).ConfigureAwait( false );           
        }
        
       

        /// <summary>
        /// Creates a signature from a digest using the specified key in the vault.
        /// </summary>
        /// <param name="keyBundle">The key bundle of the signing key </param>
        /// <param name="algorithm">The signing algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <param name="digest">The signing digest hash value </param>
        /// <returns> signature </returns>
        public static async Task<KeyOperationResult> SignAsync( this KeyVaultClient client, KeyBundle keyBundle, string algorithm, byte[] digest )
        {
            if ( keyBundle == null )
                throw new ArgumentNullException( "keyBundle" );

            return await client.SignAsync( keyBundle.Key, algorithm, digest ).ConfigureAwait( false );
        }

        /// <summary>
        /// Creates a signature from a digest using the specified key in the vault.
        /// </summary>
        /// <param name="key"> The web key of the signing key </param>
        /// <param name="algorithm"> The signing algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <param name="digest"> The signing digest hash value </param>
        /// <returns> signature </returns>
        public static async Task<KeyOperationResult> SignAsync( this KeyVaultClient client, JsonWebKey key, string algorithm, byte[] digest )
        {
            if ( key == null )
                throw new ArgumentNullException( "key" );

            return await client.SignAsync( key.Kid, algorithm, digest ).ConfigureAwait( false );
        }

        /// <summary>
        /// Unwraps a symmetric key using the specified wrapping key and algorithm.
        /// </summary>        
        /// <param name="wrappingKey">The wrapping key</param>
        /// <param name="wrappedKey">The symmetric key to unwrap</param>
        /// <param name="algorithm">The algorithm to use. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <returns>The unwrapped key</returns>
        public static async Task<KeyOperationResult> UnwrapKeyAsync( this KeyVaultClient client, KeyBundle wrappingKey, byte[] wrappedKey, string algorithm )
        {
            if ( wrappingKey == null )
                throw new ArgumentNullException( "wrappingKey" );

            return await client.UnwrapKeyAsync( wrappingKey.Key, wrappedKey, algorithm ).ConfigureAwait( false );
        }

        /// <summary>
        /// Unwraps a symmetric key using the specified wrapping key and algorithm.
        /// </summary>        
        /// <param name="wrappingKey">The wrapping key</param>
        /// <param name="wrappedKey">The symmetric key to unwrap</param>
        /// <param name="algorithm">The algorithm to use. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <returns>The unwrapped key</returns>
        public static async Task<KeyOperationResult> UnwrapKeyAsync( this KeyVaultClient client, JsonWebKey wrappingKey, byte[] wrappedKey, string algorithm )
        {
            if ( wrappingKey == null )
                throw new ArgumentNullException( "wrappingKey" );

            if ( wrappedKey == null )
                throw new ArgumentNullException( "wrappedKey" );

            return await client.UnwrapKeyAsync( wrappingKey.Kid, algorithm, wrappedKey ).ConfigureAwait( false );
        }

        
        /// <summary>
        /// Verifies a signature using the specified key.
        /// </summary>        
        /// <param name="verifyKey">The verification key</param>
        /// <param name="algorithm">The signing algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <param name="digest">The digest hash value</param>
        /// <param name="signature">The signature to verify</param>
        /// <returns>True if verification succeeds, false if verification fails</returns>
        public static async Task<bool> VerifyAsync( this KeyVaultClient client, KeyBundle verifyKey, string algorithm, byte[] digest, byte[] signature )
        {
            return await client.VerifyAsync( verifyKey.Key, algorithm, digest, signature ).ConfigureAwait( false );
        }

        /// <summary>
        /// Verifies a signature using the specified key.
        /// </summary>        
        /// <param name="verifyKey">The verification key</param>
        /// <param name="algorithm">The signing algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <param name="digest">The digest hash value</param>
        /// <param name="signature">The signature to verify</param>
        /// <returns>true if verification succeeds, false if verification fails</returns>
        public static async Task<bool> VerifyAsync( this KeyVaultClient client, JsonWebKey verifyKey, string algorithm, byte[] digest, byte[] signature )
        {            
            if ( verifyKey == null )
                throw new ArgumentNullException( "verifyKey" );

            if ( digest == null )
                throw new ArgumentNullException( "digest" );

            if ( signature == null )
                throw new ArgumentNullException( "signature" );

            return await client.VerifyAsync( verifyKey.Kid, algorithm, digest, signature ).ConfigureAwait( false );
                    
        }
        

        private static string MapAlgToHashAlgorithm(string alg)
        {
            switch (alg)
            {
                case "RS256":
                    return "SHA256";

                case "RS384":
                    return "SHA384";

                case "RS512":
                    return "SHA512";

                default:
                    throw new ArgumentException("Invalid algorithm: " + alg);
            }
        }

        /// <summary>
        /// Wraps a symmetric key using the specified wrapping key and algorithm.
        /// </summary>        
        /// <param name="wrappingKey">The wrapping key</param>
        /// <param name="key">The key to wrap</param>
        /// <param name="algorithm">The algorithm to use. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <returns>The wrapped key</returns>
        public static async Task<KeyOperationResult> WrapKeyAsync( this KeyVaultClient client, KeyBundle wrappingKey, byte[] key, string algorithm )
        {
            if ( wrappingKey == null )
                throw new ArgumentNullException( "keyBundle" );

            return await client.WrapKeyAsync( wrappingKey.Key, key, algorithm ).ConfigureAwait( false );
        }

        /// <summary>
        /// Wraps a symmetric key using the specified wrapping key and algorithm.
        /// </summary>        
        /// <param name="wrappingKey">The wrapping key</param>
        /// <param name="key">The key to wrap</param>
        /// <param name="algorithm">The algorithm to use. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <returns>The wrapped key</returns>
        public static async Task<KeyOperationResult> WrapKeyAsync( this KeyVaultClient client, JsonWebKey wrappingKey, byte[] key, string algorithm )
        {            
            if ( wrappingKey == null )
                throw new ArgumentNullException( "wrappingKey" );

            if ( key == null )
                throw new ArgumentNullException( "key" );

            return await client.WrapKeyAsync(wrappingKey.Kid, algorithm, key).ConfigureAwait(false);            
        }

    }
}
