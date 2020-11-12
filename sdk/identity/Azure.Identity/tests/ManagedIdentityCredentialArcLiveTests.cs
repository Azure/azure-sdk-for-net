// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
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
            Matcher = new ArcMiRecordedTestMatcher();
        }

        [NonParallelizable]
        [Test]
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

                var kvclient = new SecretClient(vaultUri, cred, kvoptions);

                KeyVaultSecret secret = await kvclient.SetSecretAsync("identitytestsecret", "value");

                Assert.IsNotNull(secret);
            }
        }


        [NonParallelizable]
        [Test]
        public void ValidateUserAssignedIdentity()
        {
            if (string.IsNullOrEmpty(TestEnvironment.ArcEnable))
            {
                Assert.Ignore();
            }

            using (ReadOrRestoreManagedIdentityEnvironment())
            {
                var vaultUri = new Uri(TestEnvironment.SystemAssignedVault);

                var cred = new ManagedIdentityCredential(clientId: Guid.NewGuid().ToString(), options: InstrumentClientOptions(new TokenCredentialOptions()));

                Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new TokenRequestContext(new string[] { AzureAuthorityHosts.GetDefaultScope(AzureAuthorityHosts.AzurePublicCloud) })));
            }
        }

        private class ArcMiRecordedTestMatcher : RecordMatcher
        {
            public override RecordEntry FindMatch(RecordEntry request, IList<RecordEntry> entries)
            {
                var match = base.FindMatch(request, entries);

                if (match.Response.Headers.TryGetValue("WWW-Authenticate", out string[] challenges) && challenges[0].StartsWith("Basic realm="))
                {
                    challenges[0] = challenges[0].Split('=')[0] + "=" + Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "mock-arc-mi-key.key");
                }

                return match;
            }
        }
    }
}
