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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Core;

namespace Microsoft.Azure.KeyVault
{
    public class KeyVaultKeyResolver : IKeyResolver
    {
        private readonly KeyVaultClient _client;
        private readonly string         _name;

        public KeyVaultKeyResolver( KeyVaultClient.AuthenticationCallback cb )
            : this( new KeyVaultClient( cb ) )
        {
        }

        public KeyVaultKeyResolver( KeyVaultClient client )
            : this( string.Empty, client )
        {
        }

        public KeyVaultKeyResolver( string vaultName, KeyVaultClient client )
        {
            if ( client == null )
                throw new ArgumentNullException( "client" );

            _name   = vaultName;
            _client = client;
        }

        public async Task<IKey> ResolveKeyAsync( string kid, CancellationToken token = default(CancellationToken) )
        {
            if ( string.IsNullOrWhiteSpace( kid ) )
                throw new ArgumentNullException( "kid" );

            // If the resolver has a name prefix, only handle kid that have that prefix
            if ( !string.IsNullOrEmpty( _name ) && !kid.StartsWith( _name, StringComparison.OrdinalIgnoreCase ) )
                return null;

            if ( KeyIdentifier.IsKeyIdentifier( kid ) )
                return await ResolveKeyFromKeyAsync( kid, token );

            if ( SecretIdentifier.IsSecretIdentifier( kid ) )
                return await ResolveKeyFromSecretAsync( kid, token );

            // Return null rather than throw an exception here
            return null;
        }

        private Task<IKey> ResolveKeyFromKeyAsync( string kid, CancellationToken token )
        {
            return _client.GetKeyAsync( kid, token )
                .ContinueWith<IKey>( task =>
                {
                    var keyBundle = task.Result;

                    if ( keyBundle != null )
                    {
                        return new KeyVaultKey( _client, keyBundle );
                    }

                    return null;
                }, token );
        }

        private Task<IKey> ResolveKeyFromSecretAsync( string sid, CancellationToken token )
        {
            return _client.GetSecretAsync( sid, token )
                .ContinueWith<IKey>( task =>
                {
                    var secret = task.Result;

                    if ( secret != null && string.Equals( secret.ContentType, "application/octet-stream", StringComparison.OrdinalIgnoreCase ) )
                    {
                        var keyBytes = FromBase64UrlString( secret.Value );

                        if ( keyBytes != null )
                        {
                            return new SymmetricKey( sid, keyBytes );
                        }
                    }

                    return null;
                }, token );
        }

        /// <summary>
        /// Converts a byte array to a Base64Url encoded string
        /// </summary>
        /// <param name="input">The byte array to convert</param>
        /// <returns>The Base64Url encoded form of the input</returns>
        private static string ToBase64UrlString( byte[] input )
        {
            if ( input == null )
                throw new ArgumentNullException( "input" );

            return Convert.ToBase64String( input ).TrimEnd( '=' ).Replace( '+', '-' ).Replace( '/', '_' );
        }

        /// <summary>
        /// Converts a Base64Url encoded string to a byte array
        /// </summary>
        /// <param name="input">The Base64Url encoded string</param>
        /// <returns>The byte array represented by the enconded string</returns>
        private static byte[] FromBase64UrlString( string input )
        {
            if ( string.IsNullOrEmpty( input ) )
                throw new ArgumentNullException( "input" );

            return Convert.FromBase64String( Pad( input.Replace( '-', '+' ).Replace( '_', '/' ) ) );
        }

        /// <summary>
        /// Adds padding to the input
        /// </summary>
        /// <param name="input"> the input string </param>
        /// <returns> the padded string </returns>
        private static string Pad( string input )
        {
            var count = 3 - ( ( input.Length + 3 ) % 4 );

            if ( count == 0 )
            {
                return input;
            }

            return input + new string( '=', count );
        }

    }
}
