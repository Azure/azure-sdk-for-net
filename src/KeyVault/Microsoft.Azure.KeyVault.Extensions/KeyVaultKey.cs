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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Core;
using Microsoft.Azure.KeyVault.WebKey;

namespace Microsoft.Azure.KeyVault
{
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
