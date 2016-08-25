// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

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
using KeyVault.TestFramework;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.KeyVault.Extensions.Tests
{

    /// <summary>
    /// Verify Symmetric Key.
    /// </summary>
    public class KeyVaultKeyResolverTests : IClassFixture<KeyVaultTestFixture>
    {
        private KeyVaultTestFixture fixture;

        public KeyVaultKeyResolverTests(KeyVaultTestFixture fixture)
        {
            this.fixture = fixture;
            _standardVaultOnly = fixture.standardVaultOnly;
            _vaultAddress = fixture.vaultAddress;
            _keyName = fixture.keyName;
            _keyVersion = fixture.keyVersion;
            _keyIdentifier = fixture.keyIdentifier;
        }

        private bool _standardVaultOnly = false;
        private string _vaultAddress = "";
        private string _keyName = "";
        private string _keyVersion = "";
        private KeyIdentifier _keyIdentifier;

        private KeyVaultClient GetKeyVaultClient()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables["VaultAddress"] = _vaultAddress;
                HttpMockServer.Variables["KeyName"] = _keyName;
                HttpMockServer.Variables["KeyVersion"] = _keyVersion;
            }
            else
            {
                _vaultAddress = HttpMockServer.Variables["VaultAddress"];
                _keyName = HttpMockServer.Variables["KeyName"];
                _keyVersion = HttpMockServer.Variables["KeyVersion"];
            }
            _keyIdentifier = new KeyIdentifier(_vaultAddress, _keyName, _keyVersion);
            return fixture.CreateKeyVaultClient();
        }

        /// <summary>
        /// Test resolving a key from a key in a vault using various KeyVaultKeyResolver constructors.
        /// </summary>
        [Fact]
        public void KeyVault_KeyResolver_ResolveKey()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Arrange
                var client = GetKeyVaultClient();
                var vault = _vaultAddress;

                var key = client.CreateKeyAsync(vault, "TestKey", JsonWebKeyType.Rsa).GetAwaiter().GetResult();

                if (key != null)
                {
                    try
                    {
                        VerifyResolver(client, vault, key.KeyIdentifier.BaseIdentifier, key.KeyIdentifier.Identifier);
                    }
                    finally
                    {
                        // Delete the key
                        client.DeleteKeyAsync(vault, "TestKey").GetAwaiter().GetResult();
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                VerifyResolveSecretBase64(128, VerifyResolver);
            }
        }

        /// <summary>
        /// Test resolving a key from a 192bit secret encoded as base64 in a vault using various KeyVaultKeyResolver constructors.
        /// </summary>
        [Fact]
        public void KeyVault_KeyResolver_ResolveSecret192Base64()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                VerifyResolveSecretBase64(192, VerifyResolver);
            }
        }

        /// <summary>
        /// Test resolving a key from a 256bit secret encoded as base64 in a vault using various KeyVaultKeyResolver constructors.
        /// </summary>
        [Fact]
        public void KeyVault_KeyResolver_ResolveSecret256Base64()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
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

            RandomNumberGenerator.Create().GetBytes(keyBytes);

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
                resolver = new KeyVaultKeyResolver(fixture.GetAccessToken);

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
                resolver = new KeyVaultKeyResolver(vault, fixture.GetAccessToken);

                baseKey = resolver.ResolveKeyAsync(baseIdentifier, default(CancellationToken)).GetAwaiter().GetResult();
                versionKey = resolver.ResolveKeyAsync(identifier, default(CancellationToken)).GetAwaiter().GetResult();

                Assert.Equal(baseKey.Kid, versionKey.Kid);
            }

            baseKey.Dispose();
            versionKey.Dispose();
        }
    }
}
