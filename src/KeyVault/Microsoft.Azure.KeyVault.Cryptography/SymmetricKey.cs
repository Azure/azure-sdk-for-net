﻿//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Core;
using Microsoft.Azure.KeyVault.Cryptography;
using Microsoft.Azure.KeyVault.Cryptography.Algorithms;

#if PORTABLE
using TaskException = System.Threading.Tasks.Task;
#endif

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

        private static readonly int                   DefaultKeySize = KeySize256;
        private static readonly RandomNumberGenerator Rng            = RandomNumberGenerator.Create();

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
 
            Rng.GetBytes( _key );
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


        public Task<byte[]> DecryptAsync( byte[] ciphertext, byte[] iv, byte[] authenticationData = null, byte[] authenticationTag = null, string algorithm = null, CancellationToken token = default(CancellationToken) )
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
 
            try
            {
                using ( var encryptor = algo.CreateDecryptor( _key, iv, authenticationData, authenticationTag ) )
                {
                    return Task.FromResult( encryptor.TransformFinalBlock( ciphertext, 0, ciphertext.Length ) );
                }
            }
            catch ( Exception ex )
            {
                return TaskException.FromException<byte[]>( ex );
            }
        }

        public Task<Tuple<byte[], byte[], string>> EncryptAsync( byte[] plaintext, byte[] iv, byte[] authenticationData = null, string algorithm = null, CancellationToken token = default(CancellationToken) )
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

            try
            {
                using ( var encryptor = algo.CreateEncryptor( _key, iv, authenticationData ) )
                {
                    var    cipherText        = encryptor.TransformFinalBlock( plaintext, 0, plaintext.Length );
                    byte[] authenticationTag = null;
                    var    transform         = encryptor as IAuthenticatedCryptoTransform;

                    if ( transform != null )
                    {
                        authenticationTag = transform.Tag.Clone() as byte[];
                    }

                    var result = new Tuple<byte[], byte[], string>( cipherText, authenticationTag, algorithm );

                    return Task.FromResult( result );
                }
            }
            catch ( Exception ex )
            {
                return TaskException.FromException<Tuple<byte[], byte[], string>>( ex );
            }
        }

        public Task<Tuple<byte[], string>> WrapKeyAsync( byte[] key, string algorithm = null, CancellationToken token = default(CancellationToken) )
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

            try
            {
                using ( var encryptor = algo.CreateEncryptor( _key, null ) )
                {
                        var result = new Tuple<byte[], string>( encryptor.TransformFinalBlock( key, 0, key.Length ), algorithm );

                        return Task.FromResult( result );
                }
            }
            catch ( Exception ex )
            {
                return TaskException.FromException<Tuple<byte[], string>>( ex );
            }
        }

        public Task<byte[]> UnwrapKeyAsync( byte[] encryptedKey, string algorithm = null, CancellationToken token = default(CancellationToken) )
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

            try
            {
                using ( var encryptor = algo.CreateDecryptor( _key, null ) )
                {
                    var result = encryptor.TransformFinalBlock( encryptedKey, 0, encryptedKey.Length );

                    return Task.FromResult( result );
                }
            }
            catch ( Exception ex )
            {
                return TaskException.FromException<byte[]>( ex );
            }
        }

        public Task<Tuple<byte[], string>> SignAsync( byte[] digest, string algorithm = null, CancellationToken token = default(CancellationToken) )
        {
            return TaskException.FromException<Tuple<byte[], string>>( new NotImplementedException() );
        }

        public Task<bool> VerifyAsync( byte[] digest, byte[] signature, string algorithm = null, CancellationToken token = default(CancellationToken) )
        {
            return TaskException.FromException<bool>( new NotImplementedException() );
        }

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
