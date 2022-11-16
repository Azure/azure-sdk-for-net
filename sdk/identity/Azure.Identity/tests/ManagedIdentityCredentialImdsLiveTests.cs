// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Secrets;
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
        [TestCaseSource(nameof(AuthorityHostValues))]
        public async Task ValidateImdsSystemAssignedIdentity(Uri authority)
        {
            if (string.IsNullOrEmpty(TestEnvironment.IMDSEnable))
            {
                Assert.Ignore();
            }

            using (ReadOrRestoreManagedIdentityEnvironment())
            {
                var vaultUri = new Uri(TestEnvironment.SystemAssignedVault);

                var cred = CreateManagedIdentityCredential(authority: authority);

                // Hard code service version or recorded tests will fail: https://github.com/Azure/azure-sdk-for-net/issues/10432
                var kvoptions = InstrumentClientOptions(new SecretClientOptions(SecretClientOptions.ServiceVersion.V7_0));

                var kvclient = InstrumentClient(new SecretClient(vaultUri, cred, kvoptions));

                KeyVaultSecret secret = await kvclient.GetSecretAsync("identitytestsecret");

                Assert.IsNotNull(secret);
            }
        }

        [NonParallelizable]
        [Test]
        [TestCaseSource(nameof(AuthorityHostValues))]
        public async Task ValidateImdsUserAssignedIdentity(Uri authority)
        {
            if (string.IsNullOrEmpty(TestEnvironment.IMDSEnable))
            {
                Assert.Ignore();
            }

            using (ReadOrRestoreManagedIdentityEnvironment())
            {
                var vaultUri = new Uri(TestEnvironment.UserAssignedVault);

                var clientId = TestEnvironment.IMDSClientId;

                var cred = CreateManagedIdentityCredential(clientId, authority: authority);

                // Hard code service version or recorded tests will fail: https://github.com/Azure/azure-sdk-for-net/issues/10432
                var kvoptions = InstrumentClientOptions(new SecretClientOptions(SecretClientOptions.ServiceVersion.V7_0));

                var kvclient = InstrumentClient(new SecretClient(vaultUri, cred, kvoptions));

                KeyVaultSecret secret = await kvclient.GetSecretAsync("identitytestsecret");

                Assert.IsNotNull(secret);
            }
        }

        public static IEnumerable<object[]> AuthorityHostValues()
        {
            // params
            // az thrown Exception message, expected message, expected  exception
            yield return new object[] { AzureAuthorityHosts.AzureChina };
            yield return new object[] { AzureAuthorityHosts.AzureGermany };
            yield return new object[] { AzureAuthorityHosts.AzureGovernment };
            yield return new object[] { AzureAuthorityHosts.AzurePublicCloud };
            yield return new object[] { new Uri("https://foo.bar") };
        }

        private ManagedIdentityCredential CreateManagedIdentityCredential(string clientId = null, TokenCredentialOptions options = null, Uri authority = null)
        {
            options = InstrumentClientOptions(options ?? new TokenCredentialOptions());
            options.AuthorityHost = authority;

            var pipeline = CredentialPipeline.GetInstance(options);

            var cred = new ManagedIdentityCredential(new ManagedIdentityClient(pipeline, clientId));

            return cred;
        }
    }
}
