// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity.Tests
{
    public class InteractiveBrowserCredentialTests
    {
        private const string MultiTenantClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        private const string SingleTenantClientId = "9985250a-c1c3-4caf-a039-9d98f2a0707a";
        private const string TenantId = "a7fc734e-9961-43ce-b4de-21b8b38403ba";

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task AuthenticateWithBrowserAsync()
        {
            var cred = new InteractiveBrowserCredential(MultiTenantClientId);

            AccessToken token = await cred.GetTokenAsync(new string[] { "https://vault.azure.net/.default" }).ConfigureAwait(false);

            Assert.NotNull(token.Token);
        }

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public void AuthenticateBrowserCancellationAsync()
        {
            var cred = new InteractiveBrowserCredential(MultiTenantClientId);

            var cancelSource = new CancellationTokenSource();

            Task<AccessToken> getTokenTask = cred.GetTokenAsync(new string[] { "https://vault.azure.net/.default" }, cancelSource.Token);

            cancelSource.Cancel();

            Assert.ThrowsAsync<OperationCanceledException>(async () => await getTokenTask.ConfigureAwait(false));
        }

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task AuthenticateWithBrowserSingleTenantAsync()
        {
            var cred = new InteractiveBrowserCredential(SingleTenantClientId, TenantId);

            AccessToken token = await cred.GetTokenAsync(new string[] { "https://vault.azure.net/.default" }).ConfigureAwait(false);

            Assert.NotNull(token.Token);
        }
    }

}

