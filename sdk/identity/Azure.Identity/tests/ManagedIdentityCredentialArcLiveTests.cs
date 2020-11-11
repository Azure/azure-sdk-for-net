// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityCredentialArcLiveTests : IdentityRecordedTestBase
    {
        public ManagedIdentityCredentialArcLiveTests(bool isAsync) : base(isAsync)
        {
            Sanitizer = new ArcMiRecordedTestSanitizer();
        }

        [NonParallelizable]
        [Test]
        public async Task ValidateSystemAssignedIdentity()
        {
            if (string.IsNullOrEmpty(TestEnvironment.ArcEnable))
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
        public void ValidateUserAssignedIdentity()
        {
            if (string.IsNullOrEmpty(TestEnvironment.ArcEnable))
            {
                Assert.Ignore();
            }

            TestEnvironment.RecordManagedIdentityEnvironmentVariables();

            var vaultUri = new Uri(TestEnvironment.SystemAssignedVault);

            var cred = new ManagedIdentityCredential(clientId: Guid.NewGuid().ToString(), options: InstrumentClientOptions(new TokenCredentialOptions()));

            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new TokenRequestContext(new string[] { AzureAuthorityHosts.GetDefaultScope(AzureAuthorityHosts.AzurePublicCloud) })));
        }

        private class ArcMiRecordedTestSanitizer : IdentityRecordedTestSanitizer
        {
            public override void Sanitize(RecordEntry entry)
            {
                if (entry.Response.Headers.TryGetValue("WWW-Authenticate", out string[] challenges) && challenges[0].StartsWith("Basic realm="))
                {
                    challenges[0] = challenges[0].Split('=')[0] + "=" + Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "mock-arc-mi-key.key");
                }
                base.Sanitize(entry);
            }
        }
    }
}
