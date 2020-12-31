// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class InteractiveBrowserCredentialLiveTests
    {
        private const string SingleTenantClientId = "9985250a-c1c3-4caf-a039-9d98f2a0707a";
        private const string TenantId = "a7fc734e-9961-43ce-b4de-21b8b38403ba";

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task AuthenticateWithBrowserAsync()
        {
            // to fully manually verify the InteractiveBrowserCredential this test should be run both authenticating with a
            // school / organization account as well as a personal live account, i.e. a @outlook.com, @live.com, or @hotmail.com
            var cred = new InteractiveBrowserCredential();

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" })).ConfigureAwait(false);

            Assert.NotNull(token.Token);
        }

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public void AuthenticateBrowserCancellationAsync()
        {
            var cred = new InteractiveBrowserCredential();

            var cancelSource = new CancellationTokenSource();

            ValueTask<AccessToken> getTokenTask = cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" }), cancelSource.Token);

            cancelSource.Cancel();

            Assert.ThrowsAsync<OperationCanceledException>(async () => await getTokenTask.ConfigureAwait(false));
        }

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task AuthenticateWithBrowserSingleTenantAsync()
        {
            var cred = new InteractiveBrowserCredential(TenantId, SingleTenantClientId);

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" })).ConfigureAwait(false);

            Assert.NotNull(token.Token);
        }

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task AuthenticateFollowedByGetTokenAsync()
        {
            var cred = new InteractiveBrowserCredential();

            // this should pop browser
            await cred.AuthenticateAsync();

            // this should not pop browser
            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" })).ConfigureAwait(false);

            Assert.NotNull(token.Token);
        }

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task AuthenticateWithSharedTokenCacheAsync()
        {
            var cred = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenCache = new PersistentTokenCache() });

            // this should pop browser
            AuthenticationRecord record = await cred.AuthenticateAsync();

            var cred2 = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenCache = new PersistentTokenCache(), AuthenticationRecord = record });

            // this should not pop browser
            AccessToken token = await cred2.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" })).ConfigureAwait(false);

            Assert.NotNull(token.Token);
        }

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task AuthenticateWithCommonTokenCacheAsync()
        {
            var tokenCache = new TokenCache();

            var cred = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenCache = tokenCache });

            // this should pop browser
            AuthenticationRecord record = await cred.AuthenticateAsync();

            var cred2 = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenCache = tokenCache, AuthenticationRecord = record });

            // this should not pop browser
            AccessToken token = await cred2.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" })).ConfigureAwait(false);

            Assert.NotNull(token.Token);
        }

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        // This test should be run with an MSA account to validate that the refresh for MSA accounts works properly
        public async Task AuthenticateWithMSAWithSubsequentSilentRefresh()
        {
            var cred = new InteractiveBrowserCredential();

            // this should pop browser
            var authRecord = await cred.AuthenticateAsync();

            Assert.NotNull(authRecord);

            // this should not pop browser
            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" })).ConfigureAwait(false);

            Assert.NotNull(token.Token);
        }
    }
}
