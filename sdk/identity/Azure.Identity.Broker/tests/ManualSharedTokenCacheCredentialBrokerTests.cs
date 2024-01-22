// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    public class ManualSharedTokenCacheCredentialBrokerTests
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task SilentAuthenticateWithBrokerAsync()
        {
            IntPtr parentWindowHandle = GetForegroundWindow();

            TokenCachePersistenceOptions persistenceOptions = new TokenCachePersistenceOptions();

            // to fully manually verify the InteractiveBrowserCredential this test should be run both authenticating with a
            // school / organization account as well as a personal live account, i.e. a @outlook.com, @live.com, or @hotmail.com
            var cred = new InteractiveBrowserCredential(new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle) { TokenCachePersistenceOptions = persistenceOptions});

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" })).ConfigureAwait(false);

            Assert.NotNull(token.Token);

            var silentCred = new SharedTokenCacheCredential(new SharedTokenCacheCredentialBrokerOptions());

            // The calls below this should be silent and not require user interaction
            token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" })).ConfigureAwait(false);

            Assert.NotNull(token.Token);

            token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://management.core.windows.net//.default" })).ConfigureAwait(false);

            Assert.NotNull(token.Token);
        }

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task AuthenticateWithBrokerWithUseOperatingSystemAccount_DoesNotPrompt()
        {
            var cred = new SharedTokenCacheCredential(new SharedTokenCacheCredentialBrokerOptions() { UseOperatingSystemAccount = true });

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://vault.azure.net/.default" })).ConfigureAwait(false);

            Assert.NotNull(token.Token);
        }
    }
}
