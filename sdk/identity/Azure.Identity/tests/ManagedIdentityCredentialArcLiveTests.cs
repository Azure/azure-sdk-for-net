// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityCredentialArcLiveTests : IdentityRecordedTestBase
    {
        public ManagedIdentityCredentialArcLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [NonParallelizable]
        [Test]
        public async Task ValidateImdsSystemAssignedIdentity()
        {
            if (string.IsNullOrEmpty(TestEnvironment.ArcEnable))
            {
                Assert.Ignore();
            }

            var vaultUri = new Uri(TestEnvironment.SystemAssignedVault);

            var cred = new ManagedIdentityCredential(options: InstrumentClientOptions(new TokenCredentialOptions()));

            // Hard code service version or recorded tests will fail: https://github.com/Azure/azure-sdk-for-net/issues/10432
            var kvoptions = InstrumentClientOptions(new SecretClientOptions(SecretClientOptions.ServiceVersion.V7_0));

            var kvclient = new SecretClient(vaultUri, cred, kvoptions);

            KeyVaultSecret secret = await kvclient.SetSecretAsync("identitytestsecret", "value");

            Assert.IsNotNull(secret);
        }


        [NonParallelizable]
        [Test]
        public async Task ValidateImdsUserAssignedIdentity()
        {
            if (string.IsNullOrEmpty(TestEnvironment.ArcEnable))
            {
                Assert.Ignore();
            }

            var vaultUri = new Uri(TestEnvironment.SystemAssignedVault);

            var clientId = TestEnvironment.IMDSClientId;

            var cred = new ManagedIdentityCredential(clientId = Guid.NewGuid().ToString(), options: InstrumentClientOptions(new TokenCredentialOptions()));

            Assert.Throws<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new TokenRequestContext(new string[] { AzureAuthorityHosts.GetDefaultScope(AzureAuthorityHosts.AzurePublicCloud) })));
            // Hard code service version or recorded tests will fail: https://github.com/Azure/azure-sdk-for-net/issues/10432
            var kvoptions = InstrumentClientOptions(new SecretClientOptions(SecretClientOptions.ServiceVersion.V7_0));

            var kvclient = new SecretClient(vaultUri, cred, kvoptions);

            KeyVaultSecret secret = await kvclient.GetSecretAsync("identitytestsecret");

            Assert.IsNotNull(secret);
        }

    }
}
