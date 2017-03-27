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
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Core;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xunit;

namespace KeyVault.Extensions.Tests
{

    /// <summary>
    /// Verify Symmetric Key.
    /// </summary>
    public class KeyVaultKeyResolverTests : IUseFixture<TestFixture>
    {
        private string                        _vaultAddress;
        private ClientCredential              _credential;
        private TokenCache                    _tokenCache;

        public void SetFixture( TestFixture testFixture )
        {
            testFixture.Initialize( TestUtilities.GetCallingClass() );

            if ( HttpMockServer.Mode == HttpRecorderMode.Record )
            {
                // SECURITY: DO NOT USE IN PRODUCTION CODE; FOR TEST PURPOSES ONLY
                ServicePointManager.ServerCertificateValidationCallback += ( sender, cert, chain, sslPolicyErrors ) => true;

                _vaultAddress = testFixture.VaultAddress;
                _credential   = testFixture._ClientCredential;
                _tokenCache   = new TokenCache();
            }
        }

        private DelegatingHandler[] GetHandlers()
        {
            HttpMockServer server;

            try
            {
                server = HttpMockServer.CreateInstance();
            }
            catch ( ApplicationException )
            {
                // mock server has never been initialized, we will need to initialize it.
                HttpMockServer.Initialize( "TestEnvironment", "InitialCreation" );
                server = HttpMockServer.CreateInstance();
            }

            return new DelegatingHandler[] { server, new TestHttpMessageHandler() };
        }

        private KeyVaultClient CreateKeyVaultClient()
        {
            return new KeyVaultClient( new TestKeyVaultCredential( GetAccessToken ), GetHandlers() );
        }

        private KeyVaultClient GetKeyVaultClient()
        {
            if ( HttpMockServer.Mode == HttpRecorderMode.Record )
            {
                HttpMockServer.Variables["VaultAddress"] = _vaultAddress;
            }
            else
            {
                _vaultAddress = HttpMockServer.Variables["VaultAddress"];
            }

            return CreateKeyVaultClient();
        }

        private async Task<string> GetAccessToken( string authority, string resource, string scope )
        {
            var context = new AuthenticationContext( authority, _tokenCache );
            var result  = await context.AcquireTokenAsync( resource, _credential ).ConfigureAwait( false );

            return result.AccessToken;
        }

        /// <summary>
        /// Test resolving a key from a key in a vault using various KeyVaultKeyResolver constructors.
        /// </summary>
        [Fact]
        public void KeyVault_KeyResolver_ResolveKey()
        {
            using ( var undoContext = UndoContext.Current )
            {
                undoContext.Start();

                // Arrange
                var client = GetKeyVaultClient();
                var vault  = _vaultAddress;

                var key    = client.CreateKeyAsync( vault, "TestKey", JsonWebKeyType.Rsa ).GetAwaiter().GetResult();

                if ( key != null )
                {
                    try
                    {
                        VerifyResolver(client, vault, key.KeyIdentifier.BaseIdentifier, key.KeyIdentifier.Identifier);
                    }
                    finally
                    {
                        // Delete the key
                        client.DeleteKeyAsync( vault, "TestKey" ).GetAwaiter().GetResult();
                    }
                }
            }
        }

        /// <summary>
        /// Test resolving a key from a 128bit secret encoded as base64 in a vault using various KeyVaultKeyResolver constructors.
        /// </summary>
        [Fact]
        public void KeyVault_KeyResolver_ResolveSecret128Base64()
        {
            using ( var undoContext = UndoContext.Current )
            {
                undoContext.Start();
                VerifyResolveSecretBase64(128, VerifyResolver);
            }
        }

        /// <summary>
        /// Test resolving a key from a 192bit secret encoded as base64 in a vault using various KeyVaultKeyResolver constructors.
        /// </summary>
        [Fact]
        public void KeyVault_KeyResolver_ResolveSecret192Base64()
        {
            using ( var undoContext = UndoContext.Current )
            {
                undoContext.Start();
                VerifyResolveSecretBase64(192, VerifyResolver);
            }
        }

        /// <summary>
        /// Test resolving a key from a 256bit secret encoded as base64 in a vault using various KeyVaultKeyResolver constructors.
        /// </summary>
        [Fact]
        public void KeyVault_KeyResolver_ResolveSecret256Base64()
        {
            using ( var undoContext = UndoContext.Current )
            {
                undoContext.Start();
                VerifyResolveSecretBase64(256, VerifyResolver);
            }
        }

        private void VerifyResolveSecretBase64(int secretSize,
            Action<KeyVaultClient, string, string, string> verifyResolverCallback)
        {
            // Arrange
            var client = GetKeyVaultClient();
            var vault = _vaultAddress;

            var keyBytes = new byte[secretSize >> 3];

            new RNGCryptoServiceProvider().GetNonZeroBytes(keyBytes);

            var secret =
                client.SetSecretAsync(vault, "TestSecret", Convert.ToBase64String(keyBytes), null,
                    "application/octet-stream").GetAwaiter().GetResult();

            if (secret != null)
            {
                try
                {
                    verifyResolverCallback(client, vault, secret.SecretIdentifier.BaseIdentifier,
                        secret.SecretIdentifier.Identifier);
                }
                finally
                {
                    // Delete the key
                    client.DeleteSecretAsync(vault, "TestSecret").GetAwaiter().GetResult();
                }
            }
        }

        private void VerifyResolver(KeyVaultClient client, string vault, string baseIdentifier, string identifier)
        {
            // ctor with client
            var resolver = new KeyVaultKeyResolver(client);

            var baseKey = resolver.ResolveKeyAsync(baseIdentifier, default(CancellationToken)).GetAwaiter().GetResult();
            var versionKey = resolver.ResolveKeyAsync(identifier, default(CancellationToken)).GetAwaiter().GetResult();

            Assert.Equal(baseKey.Kid, versionKey.Kid);

            // NOTE: ctor with authentication callback. We cannot test this ctor unless
            //       we are running in live mode as it will create a new KeyVaultClient.
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                resolver = new KeyVaultKeyResolver(GetAccessToken);

                baseKey = resolver.ResolveKeyAsync(baseIdentifier, default(CancellationToken)).GetAwaiter().GetResult();
                versionKey = resolver.ResolveKeyAsync(identifier, default(CancellationToken)).GetAwaiter().GetResult();

                Assert.Equal(baseKey.Kid, versionKey.Kid);
            }

            // ctor with vault name and client
            resolver = new KeyVaultKeyResolver(vault, client);

            baseKey = resolver.ResolveKeyAsync(baseIdentifier, default(CancellationToken)).GetAwaiter().GetResult();
            versionKey = resolver.ResolveKeyAsync(identifier, default(CancellationToken)).GetAwaiter().GetResult();

            Assert.Equal(baseKey.Kid, versionKey.Kid);

            // NOTE: ctor with authentication callback. We cannot test this ctor unless
            //       we are running in live mode as it will create a new KeyVaultClient.
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                resolver = new KeyVaultKeyResolver(vault, GetAccessToken);

                baseKey = resolver.ResolveKeyAsync(baseIdentifier, default(CancellationToken)).GetAwaiter().GetResult();
                versionKey = resolver.ResolveKeyAsync(identifier, default(CancellationToken)).GetAwaiter().GetResult();

                Assert.Equal(baseKey.Kid, versionKey.Kid);
            }

            baseKey.Dispose();
            versionKey.Dispose();
        }
    }
}
