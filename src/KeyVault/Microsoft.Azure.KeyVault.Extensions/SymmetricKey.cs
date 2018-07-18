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
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Core;
using Microsoft.Azure.KeyVault.Cryptography;
using Microsoft.Azure.KeyVault.Cryptography.Algorithms;

namespace Microsoft.Azure.KeyVault
{
    /// <summary>
    /// A simple Symmetric Key
    /// </summary>
    public class SymmetricKey : IKey
    {
        public const int KeySize128 = 128 >> 3;
        public const int KeySize192 = 192 >> 3;
        public const int KeySize256 = 256 >> 3;
        public const int KeySize384 = 384 >> 3;
        public const int KeySize512 = 512 >> 3;

        private static readonly int                      DefaultKeySize = KeySize256;
        private static readonly RNGCryptoServiceProvider Rng            = new RNGCryptoServiceProvider();

        private byte[] _key;
        private bool   _isDisposed;
 
        /// <summary>
        /// Default constructor
        /// </summary>
        public SymmetricKey()
            : this( Guid.NewGuid().ToString( "N" ), DefaultKeySize )
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kid">The key identifier to use</param>
        public SymmetricKey( string kid )
            : this( kid, DefaultKeySize )
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kid">The key identifier to use</param>
        /// <param name="keySize">The key size in bytes</param>
        public SymmetricKey( string kid, int keySize )
        {
            if ( string.IsNullOrWhiteSpace( kid ) )
                throw new ArgumentNullException( "kid" );

            if ( keySize != KeySize128 && keySize != KeySize192 && keySize != KeySize256 && keySize != KeySize384 && keySize != KeySize512 )
                throw new ArgumentOutOfRangeException( "keySize", "The key size must be 128, 192, 256, 384 or 512 bits of data" );

            Kid = kid;
            _key = new byte[keySize];
 
            Rng.GetNonZeroBytes( _key );
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kid">The key identifier</param>
        /// <param name="keyBytes">The key material</param>
        public SymmetricKey( string kid, byte[] keyBytes )
        {
            if ( string.IsNullOrWhiteSpace( kid ) )
                throw new ArgumentNullException( "kid" );

            if ( keyBytes == null )
                throw new ArgumentNullException( "keyBytes" );

            if ( keyBytes.Length != KeySize128 && keyBytes.Length != KeySize192 && keyBytes.Length != KeySize256 && keyBytes.Length != KeySize384 && keyBytes.Length != KeySize512 )
                throw new ArgumentOutOfRangeException( "keyBytes", "The key material must be 128, 192, 256, 384 or 512 bits of data" );

            Kid = kid;
            _key = keyBytes;
        }
 
        [Obsolete("The Key property will be removed in a future release, please remove references to it")]
        public byte[] Key
        {
            get
            {
                return _key;
            }
        }
 
        #region IKey Implementation

        public string Kid { get; protected set; }

        public string DefaultEncryptionAlgorithm
        {
            get
            {
                switch ( _key.Length )
                {
                    case KeySize128:
                        return Aes128Cbc.AlgorithmName;

                    case KeySize192:
                        return Aes192Cbc.AlgorithmName;

                    case KeySize256:
                        return Aes128CbcHmacSha256.AlgorithmName;

                    case KeySize384:
                        return Aes192CbcHmacSha384.AlgorithmName;

                    case KeySize512:
                        return Aes256CbcHmacSha512.AlgorithmName;
                }

                return null;
            }
        }

        public string DefaultKeyWrapAlgorithm
        {
            get
            {
                switch ( _key.Length )
                {
                    case KeySize128:
                        return AesKw128.AlgorithmName;

                    case KeySize192:
                        return AesKw192.AlgorithmName;

                    case KeySize256:
                        return AesKw256.AlgorithmName;

                    case KeySize384:
                        // Default to longest allowed key length for wrap
                        return AesKw256.AlgorithmName;

                    case KeySize512:
                        // Default to longest allowed key length for wrap
                        return AesKw256.AlgorithmName;
                }

                return null;
            }
        }

        public string DefaultSignatureAlgorithm
        {
            get { return null; }
        }

        // Warning 1998: This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
#pragma warning disable 1998

        public async Task<byte[]> DecryptAsync( byte[] ciphertext, byte[] iv, byte[] authenticationData = null, byte[] authenticationTag = null, string algorithm = null, CancellationToken token = default(CancellationToken) )
        {
            if ( _isDisposed )
                throw new ObjectDisposedException( string.Format( "SymmetricKey {0} is disposed", Kid ) );
 
            if ( string.IsNullOrWhiteSpace( algorithm ) )
                algorithm = DefaultEncryptionAlgorithm;

            if ( ciphertext == null )
                throw new ArgumentNullException( "ciphertext" );

            if ( iv == null )
                throw new ArgumentNullException( "iv" );

            var algo = AlgorithmResolver.Default[algorithm] as SymmetricEncryptionAlgorithm;

            if ( algo == null )
                throw new NotSupportedException( algorithm );
 
            using ( var encryptor = algo.CreateDecryptor( _key, iv, authenticationData ) )
            {
                var result    = encryptor.TransformFinalBlock( ciphertext, 0, ciphertext.Length );
                var transform = encryptor as IAuthenticatedCryptoTransform;

                if ( transform == null )
                    return result;

                if ( authenticationData == null || authenticationTag == null )
                    throw new CryptographicException( "AuthenticatingCryptoTransform requires authenticationData and authenticationTag" );

                if ( !authenticationTag.SequenceEqualConstantTime( transform.Tag ) )
                    throw new CryptographicException( "Data is not authentic" );

                return result;
            }
        }

        public async Task<Tuple<byte[], byte[], string>> EncryptAsync( byte[] plaintext, byte[] iv, byte[] authenticationData = null, string algorithm = null, CancellationToken token = default(CancellationToken) )
        {
            if ( _isDisposed )
                throw new ObjectDisposedException( string.Format( "SymmetricKey {0} is disposed", Kid ) );
 
            if ( string.IsNullOrWhiteSpace( algorithm ) )
                algorithm = DefaultEncryptionAlgorithm;

            if ( plaintext == null )
                throw new ArgumentNullException( "plaintext" );

            if ( iv == null )
                throw new ArgumentNullException( "iv" );

            var algo = AlgorithmResolver.Default[algorithm] as SymmetricEncryptionAlgorithm;

            if ( algo == null )
                throw new NotSupportedException( algorithm );
 
            using ( var encryptor = algo.CreateEncryptor( _key, iv, authenticationData ) )
            {
                var    cipherText        = encryptor.TransformFinalBlock( plaintext, 0, plaintext.Length );
                byte[] authenticationTag = null;
                var    transform         = encryptor as IAuthenticatedCryptoTransform;

                if ( transform != null )
                {
                    authenticationTag = transform.Tag.Clone() as byte[];
                }

                return new Tuple<byte[],byte[], string>( cipherText, authenticationTag, algorithm );
            }
        }

        public async Task<Tuple<byte[], string>> WrapKeyAsync( byte[] key, string algorithm = null, CancellationToken token = default(CancellationToken) )
        {
            if ( _isDisposed )
                throw new ObjectDisposedException( string.Format( "SymmetricKey {0} is disposed", Kid ) );
 
            if ( string.IsNullOrWhiteSpace( algorithm ) )
                algorithm = DefaultKeyWrapAlgorithm;

            if ( key == null || key.Length == 0 )
                throw new ArgumentNullException( "key" );

            var algo = AlgorithmResolver.Default[algorithm] as KeyWrapAlgorithm;

            if ( algo == null )
                throw new NotSupportedException( algorithm );
 
            using ( var encryptor = algo.CreateEncryptor( _key, null ) )
            {
                return new Tuple<byte[], string>( encryptor.TransformFinalBlock( key, 0, key.Length ), algorithm );
            }
        }

        public async Task<byte[]> UnwrapKeyAsync( byte[] encryptedKey, string algorithm = null, CancellationToken token = default(CancellationToken) )
        {
            if ( _isDisposed )
                throw new ObjectDisposedException( string.Format( "SymmetricKey {0} is disposed", Kid ) );
 
            if ( string.IsNullOrWhiteSpace( algorithm ) )
                algorithm = DefaultKeyWrapAlgorithm;

            if ( encryptedKey == null || encryptedKey.Length == 0 )
                throw new ArgumentNullException( "encryptedKey" );
 
            var algo = AlgorithmResolver.Default[algorithm] as KeyWrapAlgorithm;

            if ( algo == null )
                throw new NotSupportedException( algorithm );
 
            using ( var encryptor = algo.CreateDecryptor( _key, null ) )
            {
                return encryptor.TransformFinalBlock( encryptedKey, 0, encryptedKey.Length );
            }
        }

        public async Task<Tuple<byte[], string>> SignAsync( byte[] digest, string algorithm = null, CancellationToken token = default(CancellationToken) )
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyAsync( byte[] digest, byte[] signature, string algorithm = null, CancellationToken token = default(CancellationToken) )
        {
            throw new NotImplementedException();
        }

#pragma warning restore 1998

        #endregion

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        protected virtual void Dispose( bool disposing )
        {
            if ( disposing )
            {
                if ( !_isDisposed )
                {
                    _isDisposed = true;
                    _key.Zero();
                }
            }
        }
    }
}
