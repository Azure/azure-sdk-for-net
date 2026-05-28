// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Secrets;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    // These tests are intended to be only run live on an azure VM with managed identity enabled.
    public class ManagedIdentityCredentialImdsLiveTests : ManagedIdentityCredentialLiveTestBase
    {
        public ManagedIdentityCredentialImdsLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [NonParallelizable]
        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/43401")]
        public async Task ValidateImdsSystemAssignedIdentity()
        {
            if (string.IsNullOrEmpty(TestEnvironment.IMDSEnable))
            {
                Assert.Ignore();
            }

            using (ReadOrRestoreManagedIdentityEnvironment())
            {
                var vaultUri = new Uri(TestEnvironment.SystemAssignedVault);

                var cred = CreateManagedIdentityCredential();

                // Hard code service version or recorded tests will fail: https://github.com/Azure/azure-sdk-for-net/issues/10432
                var kvoptions = InstrumentClientOptions(new SecretClientOptions(SecretClientOptions.ServiceVersion.V7_0));

                var kvclient = InstrumentClient(new SecretClient(vaultUri, cred, kvoptions));

                KeyVaultSecret secret = await kvclient.GetSecretAsync("identitytestsecret");

                Assert.IsNotNull(secret);
            }
        }

        [NonParallelizable]
        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/43401")]
        public async Task ValidateImdsUserAssignedIdentity()
        {
            if (string.IsNullOrEmpty(TestEnvironment.IMDSEnable))
            {
                Assert.Ignore();
            }

            using (ReadOrRestoreManagedIdentityEnvironment())
            {
                var vaultUri = new Uri(TestEnvironment.UserAssignedVault);

                var clientId = TestEnvironment.IMDSClientId;

                var cred = CreateManagedIdentityCredential(clientId);

                // Hard code service version or recorded tests will fail: https://github.com/Azure/azure-sdk-for-net/issues/10432
                var kvoptions = InstrumentClientOptions(new SecretClientOptions(SecretClientOptions.ServiceVersion.V7_0));

                var kvclient = InstrumentClient(new SecretClient(vaultUri, cred, kvoptions));

                KeyVaultSecret secret = await kvclient.GetSecretAsync("identitytestsecret");

                Assert.IsNotNull(secret);
            }
        }

        private ManagedIdentityCredential CreateManagedIdentityCredential(string clientId = null, TokenCredentialOptions options = null)
        {
            options = InstrumentClientOptions(options ?? new TokenCredentialOptions());
            var cred = new ManagedIdentityCredential(clientId, options);
            return cred;
        }
    }
}
