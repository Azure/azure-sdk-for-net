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
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xunit;

namespace KeyVault.Extensions.Tests
{

    /// <summary>
    /// Verify Symmetric Key.
    /// </summary>
    public class KeyVaultKeyResolverTests : IUseFixture<TestFixture>
    {
        ClientCredential _credential;

        public void SetFixture( TestFixture data )
        {
            // Intentionally empty
        }

        private KeyVaultClient CreateKeyVaultClient()
        {
            _credential = new ClientCredential( ConfigurationManager.AppSettings["AuthClientId"], ConfigurationManager.AppSettings["AuthClientSecret"] );

            return new KeyVaultClient( GetAccessToken );
        }

        private async Task<string> GetAccessToken( string authority, string resource, string scope )
        {
            var context = new AuthenticationContext( authority, TokenCache.DefaultShared );
            var result  = await context.AcquireTokenAsync( resource, _credential ).ConfigureAwait( false );

            return result.AccessToken;
        }

        /// <summary>
        /// Test resolving a key from a key in a vault using various KeyVaultKeyResolver constructors.
        /// </summary>
        [Fact]
        public async Task KeyVault_KeyVaultKeyResolver_Key()
        {
            // Arrange
            var client = CreateKeyVaultClient();
            var vault  = ConfigurationManager.AppSettings["VaultUrl"];

            var key    = await client.CreateKeyAsync( vault, "TestKey", JsonWebKeyType.Rsa ).ConfigureAwait( false );

            if ( key != null )
            {
                try
                {
                    // ctor with client
                    var resolver = new KeyVaultKeyResolver( client );

                    var baseKey    = await resolver.ResolveKeyAsync( key.KeyIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    var versionKey = await resolver.ResolveKeyAsync( key.KeyIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );

                    // ctor with authentication callback
                    resolver = new KeyVaultKeyResolver( GetAccessToken );

                    baseKey    = await resolver.ResolveKeyAsync( key.KeyIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    versionKey = await resolver.ResolveKeyAsync( key.KeyIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );

                    // ctor with vault name and client
                    resolver = new KeyVaultKeyResolver( vault, client );

                    baseKey    = await resolver.ResolveKeyAsync( key.KeyIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    versionKey = await resolver.ResolveKeyAsync( key.KeyIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );

                    // ctor with vault name and authentication callback
                    resolver = new KeyVaultKeyResolver( vault, GetAccessToken );

                    baseKey    = await resolver.ResolveKeyAsync( key.KeyIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    versionKey = await resolver.ResolveKeyAsync( key.KeyIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );
                }
                finally
                {
                    // Delete the key
                    client.DeleteKeyAsync( vault, "TestKey" ).GetAwaiter().GetResult();
                }
            }
        }

        /// <summary>
        /// Test resolving a key from a 128bit secret encoded as base64 in a vault using various KeyVaultKeyResolver constructors.
        /// </summary>
        [Fact]
        public async Task KeyVault_KeyVaultKeyResolver_Secret128Base64()
        {
            // Arrange
            var client   = CreateKeyVaultClient();
            var vault    = ConfigurationManager.AppSettings["VaultUrl"];

            var keyBytes = new byte[128 >> 3];

            new RNGCryptoServiceProvider().GetNonZeroBytes( keyBytes );

            var secret   = await client.SetSecretAsync( vault, "TestSecret", Convert.ToBase64String( keyBytes ), null, "application/octet-stream" ).ConfigureAwait( false );

            if ( secret != null )
            {
                try
                {
                    // ctor with client
                    var resolver = new KeyVaultKeyResolver( client );

                    var baseKey    = await resolver.ResolveKeyAsync( secret.SecretIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    var versionKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );

                    // ctor with authentication callback
                    resolver = new KeyVaultKeyResolver( GetAccessToken );

                    baseKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    versionKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );

                    // ctor with vault name and client
                    resolver = new KeyVaultKeyResolver( vault, client );

                    baseKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    versionKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );

                    // ctor with vault name and authentication callback
                    resolver = new KeyVaultKeyResolver( vault, GetAccessToken );

                    baseKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    versionKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );
                }
                finally
                {
                    // Delete the key
                    client.DeleteSecretAsync( vault, "TestSecret" ).GetAwaiter().GetResult();
                }
            }
        }

        /// <summary>
        /// Test resolving a key from a 192bit secret encoded as base64 in a vault using various KeyVaultKeyResolver constructors.
        /// </summary>
        [Fact]
        public async Task KeyVault_KeyVaultKeyResolver_Secret192Base64()
        {
            // Arrange
            var client   = CreateKeyVaultClient();
            var vault    = ConfigurationManager.AppSettings["VaultUrl"];

            var keyBytes = new byte[192 >> 3];

            new RNGCryptoServiceProvider().GetNonZeroBytes( keyBytes );

            var secret   = await client.SetSecretAsync( vault, "TestSecret", Convert.ToBase64String( keyBytes ), null, "application/octet-stream" ).ConfigureAwait( false );

            if ( secret != null )
            {
                try
                {
                    // ctor with client
                    var resolver = new KeyVaultKeyResolver( client );

                    var baseKey    = await resolver.ResolveKeyAsync( secret.SecretIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    var versionKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );

                    // ctor with authentication callback
                    resolver = new KeyVaultKeyResolver( GetAccessToken );

                    baseKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    versionKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );

                    // ctor with vault name and client
                    resolver = new KeyVaultKeyResolver( vault, client );

                    baseKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    versionKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );

                    // ctor with vault name and authentication callback
                    resolver = new KeyVaultKeyResolver( vault, GetAccessToken );

                    baseKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    versionKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );
                }
                finally
                {
                    // Delete the key
                    client.DeleteSecretAsync( vault, "TestSecret" ).GetAwaiter().GetResult();
                }
            }
        }

        /// <summary>
        /// Test resolving a key from a 256bit secret encoded as base64 in a vault using various KeyVaultKeyResolver constructors.
        /// </summary>
        [Fact]
        public async Task KeyVault_KeyVaultKeyResolver_Secret256Base64()
        {
            // Arrange
            var client   = CreateKeyVaultClient();
            var vault    = ConfigurationManager.AppSettings["VaultUrl"];

            var keyBytes = new byte[256 >> 3];

            new RNGCryptoServiceProvider().GetNonZeroBytes( keyBytes );

            var secret   = await client.SetSecretAsync( vault, "TestSecret", Convert.ToBase64String( keyBytes ), null, "application/octet-stream" ).ConfigureAwait( false );

            if ( secret != null )
            {
                try
                {
                    // ctor with client
                    var resolver = new KeyVaultKeyResolver( client );

                    var baseKey    = await resolver.ResolveKeyAsync( secret.SecretIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    var versionKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );

                    // ctor with authentication callback
                    resolver = new KeyVaultKeyResolver( GetAccessToken );

                    baseKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    versionKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );

                    // ctor with vault name and client
                    resolver = new KeyVaultKeyResolver( vault, client );

                    baseKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    versionKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );

                    // ctor with vault name and authentication callback
                    resolver = new KeyVaultKeyResolver( vault, GetAccessToken );

                    baseKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.BaseIdentifier, default( CancellationToken ) ).ConfigureAwait( false );
                    versionKey = await resolver.ResolveKeyAsync( secret.SecretIdentifier.Identifier, default( CancellationToken ) ).ConfigureAwait( false );

                    Assert.Equal( baseKey.Kid, versionKey.Kid );
                }
                finally
                {
                    // Delete the key
                    client.DeleteSecretAsync( vault, "TestSecret" ).GetAwaiter().GetResult();
                }
            }
        }
    }
}
