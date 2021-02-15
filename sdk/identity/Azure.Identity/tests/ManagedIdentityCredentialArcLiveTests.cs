// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
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

                var kvclient = InstrumentClient(new SecretClient(vaultUri, cred, kvoptions));

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

                var cred = InstrumentClient(new ManagedIdentityCredential(clientId: Guid.NewGuid().ToString(), options: InstrumentClientOptions(new TokenCredentialOptions())));

                Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new TokenRequestContext(new string[] { AzureAuthorityHosts.GetDefaultScope(AzureAuthorityHosts.AzurePublicCloud) })));
            }
        }
        // This RecordMatcher updates the authentication challange returned from Arc MI endpoint. In this case the auth challange header contains a path to a file on the local disk.
        // When we run in playback we replace the path the service returned for when playing back the test, with the path to a static file binplaced when we build the tests.
        // This path differs depending on the machine your running the tests on, so it can't updated it in the recording scrubber. I originally tried to update the header in the scrubber
        // to be a relative path, but this introduces failures depending on how the tests are run and the working directly. Also, I tried to implement on a pipeline policy which woud only
        // be added on playback, but ResponseHeaders is immutable so a policy cannot update them.
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
