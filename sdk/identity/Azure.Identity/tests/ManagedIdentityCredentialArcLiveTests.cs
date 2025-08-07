// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityCredentialArcLiveTests : ManagedIdentityCredentialLiveTestBase
    {
        public ManagedIdentityCredentialArcLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [NonParallelizable]
        [Test]
        [Ignore("path validation fails in playback mode")]
        public async Task ValidateSystemAssignedIdentity()
        {
            if (string.IsNullOrEmpty(TestEnvironment.ArcEnable))
            {
                Assert.Ignore();
            }

            using (ReadOrRestoreManagedIdentityEnvironment())
            {
                var vaultUri = new Uri(TestEnvironment.SystemAssignedVault);

                var cred = new ManagedIdentityCredential(options: InstrumentClientOptions(new TokenCredentialOptions()));

                // Hard code service version or recorded tests will fail: https://github.com/Azure/azure-sdk-for-net/issues/10432
                var kvoptions = InstrumentClientOptions(new SecretClientOptions(SecretClientOptions.ServiceVersion.V7_0));

                var kvclient = InstrumentClient(new SecretClient(vaultUri, cred, kvoptions));

                KeyVaultSecret secret = await kvclient.SetSecretAsync("identitytestsecret", "value");

                Assert.IsNotNull(secret);
            }
        }

        [NonParallelizable]
        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/43401")]
        public void ValidateUserAssignedIdentity()
        {
            if (string.IsNullOrEmpty(TestEnvironment.ArcEnable))
            {
                Assert.Ignore();
            }

            using (ReadOrRestoreManagedIdentityEnvironment())
            {
                var vaultUri = new Uri(TestEnvironment.SystemAssignedVault);

                var cred = InstrumentClient(new ManagedIdentityCredential(clientId: Guid.NewGuid().ToString(), options: InstrumentClientOptions(new TokenCredentialOptions())));

                Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new TokenRequestContext(new string[] { AzureAuthorityHosts.GetDefaultScope(AzureAuthorityHosts.AzurePublicCloud) })));
            }
        }
    }
}
