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
    /// <summary>
    /// Azure Key Vault KeyResolver. This class resolves Key Vault Key Identifiers and
    /// Secret Identifiers to implementations of IKey. Secret Identifiers can only
    /// be resolved if the Secret is a byte array with a length matching one of the AES
    /// key lengths (128, 192, 256) and the content-type of the secret is application/octet-stream.
    /// </summary>
    public class KeyVaultKeyResolver : IKeyResolver
    {
        private readonly KeyVaultClient _client;
        private readonly string         _name;

        /// <summary>
        /// Creates a new Key Vault KeyResolver that uses a KeyVaultClient constructed
        /// with the provided authentication callback.
        /// </summary>
        /// <param name="authenticationCallback">Key Vault authentication callback</param>
        public KeyVaultKeyResolver( KeyVaultClient.AuthenticationCallback authenticationCallback )
            : this( new KeyVaultClient( authenticationCallback ) )
        {
        }

        /// <summary>
        /// Create a new Key Vault KeyResolver that uses the specified KeyVaultClient
        /// </summary>
        /// <param name="client">Key Vault client</param>
        public KeyVaultKeyResolver( KeyVaultClient client )
        {
            if ( client == null )
                throw new ArgumentNullException( "client" );

            _name   = null;
            _client = client;
        }

        /// <summary>
        /// Creates a new Key Vault KeyResolver that uses a KeyVaultClient constructed
        /// with the provided authentication callback and only resolves keys for the 
        /// specified key vault
        /// </summary>
        /// <param name="vaultName">The URL for the Key Vault, e.g. https://myvault.vault.azure.net/ </param>
        /// <param name="authenticationCallback">Key Vault authentication callback</param>
        public KeyVaultKeyResolver( string vaultName, KeyVaultClient.AuthenticationCallback authenticationCallback )
            : this( vaultName, new KeyVaultClient( authenticationCallback ) )
        {
        }

        /// <summary>
        /// Creates a new Key Vault KeyResolver that uses the specified KeyVaultClient
        /// and only resolves keys for the specified key vault
        /// </summary>
        /// <param name="vaultName">The URL for the Key Vault, e.g. https://myvault.vault.azure.net/ </param>
        /// <param name="client">Key Vault client</param>
        public KeyVaultKeyResolver( string vaultName, KeyVaultClient client )
        {
            if ( string.IsNullOrWhiteSpace( vaultName ) )
                throw new ArgumentNullException( "vaultName" );

            if ( client == null )
                throw new ArgumentNullException( "client" );

            _name   = NormalizeVaultName( vaultName );
            _client = client;
        }

        #region IKeyResolver

        /// <summary>
        /// Provides an IKey implementation for the specified key or secret identifier.
        /// </summary>
        /// <param name="kid">The key or secret identifier to resolve</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>The resolved IKey implementation or null</returns>
        public async Task<IKey> ResolveKeyAsync( string kid, CancellationToken token )
        {
            if ( string.IsNullOrWhiteSpace( kid ) )
                throw new ArgumentNullException( "kid" );

            // If the resolver has a name prefix, only handle kid that have that prefix.
            if ( _name != null )
            {
                var vaultUrl = new Uri( _name );
                var keyUrl   = new Uri( kid );

                if ( string.Compare( vaultUrl.Scheme, keyUrl.Scheme, true ) != 0 || string.Compare( vaultUrl.Authority, keyUrl.Authority, true ) != 0 || vaultUrl.Port != keyUrl.Port )
                    return null;
            }

            if ( KeyIdentifier.IsKeyIdentifier( kid ) )
                return await ResolveKeyFromKeyAsync( kid, token ).ConfigureAwait( false );

            if ( SecretIdentifier.IsSecretIdentifier( kid ) )
                return await ResolveKeyFromSecretAsync( kid, token ).ConfigureAwait( false );

            // Return null rather than throw an exception here
            return null;
        }

        #endregion

        private string NormalizeVaultName( string vaultName )
        {
            Uri vaultUri = new Uri( vaultName, UriKind.Absolute );

            if ( vaultUri.Scheme != Uri.UriSchemeHttps )
                throw new ArgumentException( "The vaultName must use the https scheme" );

            if ( string.CompareOrdinal( vaultUri.PathAndQuery, "/" ) != 0 )
                throw new ArgumentException( "The vaultName cannot contain a path or query string" );

            return vaultUri.AbsoluteUri;
        }


        private Task<IKey> ResolveKeyFromKeyAsync( string kid, CancellationToken token )
        {
            // KeyVaultClient is thread-safe
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
            // KeyVaultClient is thread-safe
            return _client.GetSecretAsync( sid, token )
                .ContinueWith<IKey>( task =>
                {
                    var secret = task.Result;

                    if ( secret != null && string.Equals( secret.ContentType, "application/octet-stream", StringComparison.OrdinalIgnoreCase ) )
                    {
                        var keyBytes = FromBase64UrlString( secret.Value );

                        if ( keyBytes != null )
                        {
                            return new SymmetricKey( secret.Id, keyBytes );
                        }
                    }

                    return null;
                }, token );
        }

        /// <summary>
        /// Converts a Base64 or Base64Url encoded string to a byte array
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
