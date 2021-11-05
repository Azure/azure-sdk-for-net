// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityCredentialSFLiveTests : ManagedIdentityCredentialLiveTestBase
    {
        public ManagedIdentityCredentialSFLiveTests(bool isAsync) : base(isAsync)
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

            using (ReadOrRestoreManagedIdentityEnvironment())
            {
                var vaultUri = new Uri(TestEnvironment.SystemAssignedVault);

                CredentialPipeline pipeline = CredentialPipeline.GetInstance(InstrumentClientOptions(new TokenCredentialOptions { Transport = ServiceFabricManagedIdentitySource.GetServiceFabricMITransport() }));

                var cred = new ManagedIdentityCredential(new ManagedIdentityClient(new ManagedIdentityClientOptions { Pipeline = pipeline, PreserveTransport = true }));

                // Hard code service version or recorded tests will fail: https://github.com/Azure/azure-sdk-for-net/issues/10432
                var kvoptions = InstrumentClientOptions(new SecretClientOptions(SecretClientOptions.ServiceVersion.V7_0));

                var kvclient = InstrumentClient(new SecretClient(vaultUri, cred, kvoptions));

                KeyVaultSecret secret = await kvclient.SetSecretAsync("identitytestsecret", "value");

                Assert.IsNotNull(secret);
            }
        }

        [NonParallelizable]
        [Test]
        public async Task ValidateUserAssignedIdentity()
        {
            if (string.IsNullOrEmpty(TestEnvironment.SFEnable) || string.IsNullOrEmpty(TestEnvironment.UserAssignedVault))
            {
                Assert.Ignore();
            }

            using (ReadOrRestoreManagedIdentityEnvironment())
            {
                var vaultUri = new Uri(TestEnvironment.UserAssignedVault);

                var clientId = TestEnvironment.IMDSClientId;

                CredentialPipeline pipeline = CredentialPipeline.GetInstance(InstrumentClientOptions(new TokenCredentialOptions { Transport = ServiceFabricManagedIdentitySource.GetServiceFabricMITransport() }));

                var cred = new ManagedIdentityCredential(new ManagedIdentityClient(new ManagedIdentityClientOptions { Pipeline = pipeline, ClientId = clientId, PreserveTransport = true }));

                // Hard code service version or recorded tests will fail: https://github.com/Azure/azure-sdk-for-net/issues/10432
                var kvoptions = InstrumentClientOptions(new SecretClientOptions(SecretClientOptions.ServiceVersion.V7_0));

                var kvclient = InstrumentClient(new SecretClient(vaultUri, cred, kvoptions));

                KeyVaultSecret secret = await kvclient.SetSecretAsync("identitytestsecret", "value");

                Assert.IsNotNull(secret);
            }
        }
    }
}
