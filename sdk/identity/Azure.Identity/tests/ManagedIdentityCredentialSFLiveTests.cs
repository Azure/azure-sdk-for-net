// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityCredentialSFLiveTests : IdentityRecordedTestBase
    {
        public ManagedIdentityCredentialSFLiveTests(bool isAsync) : base(isAsync, Core.TestFramework.RecordedTestMode.Record)
        {
        }

        [NonParallelizable]
        [Test]
        public async Task ValidateSystemAssignedIdentity()
        {
            if (string.IsNullOrEmpty(TestEnvironment.SFEnable) || !string.IsNullOrEmpty(TestEnvironment.UserAssignedVault))
            {
                Assert.Ignore();
            }

            TestEnvironment.RecordManagedIdentityEnvironmentVariables();

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
        public async Task ValidateUserAssignedIdentity()
        {
            if (string.IsNullOrEmpty(TestEnvironment.SFEnable) || string.IsNullOrEmpty(TestEnvironment.UserAssignedVault))
            {
                Assert.Ignore();
            }

            TestEnvironment.RecordManagedIdentityEnvironmentVariables();

            var vaultUri = new Uri(TestEnvironment.UserAssignedVault);

            var clientId = TestEnvironment.IMDSClientId;

            var cred = new ManagedIdentityCredential(clientId: clientId, options: InstrumentClientOptions(new TokenCredentialOptions()));

            // Hard code service version or recorded tests will fail: https://github.com/Azure/azure-sdk-for-net/issues/10432
            var kvoptions = InstrumentClientOptions(new SecretClientOptions(SecretClientOptions.ServiceVersion.V7_0));

            var kvclient = new SecretClient(vaultUri, cred, kvoptions);

            KeyVaultSecret secret = await kvclient.SetSecretAsync("identitytestsecret", "value");

            Assert.IsNotNull(secret);
        }
    }
}
