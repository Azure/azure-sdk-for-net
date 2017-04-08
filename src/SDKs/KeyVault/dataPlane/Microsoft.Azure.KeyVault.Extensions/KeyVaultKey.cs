// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Core;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.KeyVault.Models;

namespace Microsoft.Azure.KeyVault
{
    /// <summary>
    /// Key Vault key that performs cryptography operations at REST
    /// </summary>
    internal class KeyVaultKey : IKey
    {
        private readonly KeyVaultClient _client;
        private          IKey           _implementation;

        internal KeyVaultKey( KeyVaultClient client, KeyBundle keyBundle )
        {
            switch ( keyBundle.Key.Kty )
            {
                case JsonWebKeyType.Rsa:
                    _implementation = new RsaKey( keyBundle.Key.Kid, keyBundle.Key.ToRSA() );
                    break;

                case JsonWebKeyType.RsaHsm:
                    _implementation = new RsaKey( keyBundle.Key.Kid, keyBundle.Key.ToRSA() );
                    break;
            }

            if ( _implementation == null )
                throw new ArgumentException( string.Format( CultureInfo.InvariantCulture, "The key type \"{0}\" is not supported", keyBundle.Key.Kty ) );

            _client = client;
        }

        public string DefaultEncryptionAlgorithm
        {
            get
            {
                if ( _implementation == null )
                    throw new ObjectDisposedException( "KeyVaultKey" );

                return _implementation.DefaultEncryptionAlgorithm;
            }
        }

        public string DefaultKeyWrapAlgorithm
        {
            get
            {
                if ( _implementation == null )
                    throw new ObjectDisposedException( "KeyVaultKey" );

                return _implementation.DefaultKeyWrapAlgorithm;
            }
        }

        public string DefaultSignatureAlgorithm
        {
            get
            {
                if ( _implementation == null )
                    throw new ObjectDisposedException( "KeyVaultKey" );

                return _implementation.DefaultSignatureAlgorithm;
            }
        }

        public string Kid
        {
            get
            {
                if ( _implementation == null )
                    throw new ObjectDisposedException( "KeyVaultKey" );

                return _implementation.Kid;
            }
        }

        public Task<byte[]> DecryptAsync( byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, string algorithm = null, CancellationToken token = default(CancellationToken) )
        {
            if ( _implementation == null )
                throw new ObjectDisposedException( "KeyVaultKey" );

            if ( string.IsNullOrWhiteSpace( algorithm ) )
                algorithm = DefaultEncryptionAlgorithm;

            // Never local
            return _client.DecryptAsync( _implementation.Kid, algorithm, ciphertext, token )
                    .ContinueWith( result => result.Result.Result, token );
        }

        public Task<Tuple<byte[], byte[], string>> EncryptAsync( byte[] plaintext, byte[] iv, byte[] authenticationData, string algorithm = null, CancellationToken token = default(CancellationToken) )
        {
            if ( _implementation == null )
                throw new ObjectDisposedException( "KeyVaultKey" );

            return _implementation.EncryptAsync( plaintext, iv, authenticationData, algorithm, token );
        }

        public Task<Tuple<byte[], string>> WrapKeyAsync( byte[] plaintext, string algorithm = null, CancellationToken token = default(CancellationToken) )
        {
            if ( _implementation == null )
                throw new ObjectDisposedException( "KeyVaultKey" );

            return _implementation.WrapKeyAsync( plaintext, algorithm, token );
        }

        public Task<byte[]> UnwrapKeyAsync( byte[] ciphertext, string algorithm = null, CancellationToken token = default(CancellationToken) )
        {
            if ( _implementation == null )
                throw new ObjectDisposedException( "KeyVaultKey" );

            if ( string.IsNullOrWhiteSpace( algorithm ) )
                algorithm = DefaultKeyWrapAlgorithm;

            // Never local
            return _client.UnwrapKeyAsync( _implementation.Kid, algorithm, ciphertext, token )
                    .ContinueWith( result => result.Result.Result, token );
        }

        public Task<Tuple<byte[], string>> SignAsync( byte[] digest, string algorithm = null, CancellationToken token = default(CancellationToken) )
        {
            if ( _implementation == null )
                throw new ObjectDisposedException( "KeyVaultKey" );

            if ( string.IsNullOrWhiteSpace( algorithm ) )
                algorithm = DefaultSignatureAlgorithm;

            // Never local
            return _client.SignAsync( _implementation.Kid, algorithm, digest, token )
                .ContinueWith( result => new Tuple<byte[], string>( result.Result.Result, algorithm ), token );
        }

        public Task<bool> VerifyAsync( byte[] digest, byte[] signature, string algorithm = null, CancellationToken token = default(CancellationToken) )
        {
            if ( _implementation == null )
                throw new ObjectDisposedException( "KeyVaultKey" );

            return _implementation.VerifyAsync( digest, signature, algorithm, token );
        }

        public void Dispose()
        {
            if ( _implementation == null )
                throw new ObjectDisposedException( "KeyVaultKey" );

            Dispose( true );
            GC.SuppressFinalize( this );
        }

        private void Dispose( bool disposing )
        {
            if ( disposing )
            {
                if ( _implementation != null )
                {
                    _implementation.Dispose();
                    _implementation = null;
                }
            }
        }
    }
}
