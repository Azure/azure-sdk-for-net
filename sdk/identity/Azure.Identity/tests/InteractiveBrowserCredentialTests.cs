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
        private const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task AuthenticateWithBrowserAsync()
        {
            var cred = new InteractiveBrowserCredential(ClientId);

            AccessToken token = await cred.GetTokenAsync(new string[] { "https://vault.azure.net/.default" }).ConfigureAwait(false);

            Assert.NotNull(token.Token);
        }

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public void AuthenticateBrowserCancellationAsync()
        {
            var cred = new InteractiveBrowserCredential(ClientId);

            var cancelSource = new CancellationTokenSource();

            Task<AccessToken> getTokenTask = cred.GetTokenAsync(new string[] { "https://vault.azure.net/.default" }, cancelSource.Token);

            cancelSource.Cancel();

            Assert.ThrowsAsync<OperationCanceledException>(async () => await getTokenTask.ConfigureAwait(false));
        }
    }

}

