// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.Testing;
using Azure.Core;

namespace Azure.Identity.Tests.Mock
{
    public class MockManagedIdentityCredentialTests
    {
        [Test]
        public async Task CancellationTokenHonoredAsync()
        {
            var credential = new ManagedIdentityCredential();

            credential._client(new MockManagedIdentityClient());

            var cancellation = new CancellationTokenSource();

            Task<AccessToken> getTokenComplete = credential.GetTokenAsync(MockScopes.Default, cancellation.Token);

            cancellation.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await getTokenComplete, "failed to cancel GetToken call");

            await Task.CompletedTask;
        }

        [Test]
        public async Task ScopesHonoredAsync()
        {
            var credential = new ManagedIdentityCredential();

            credential._client(new MockManagedIdentityClient());

            AccessToken defaultScopeToken = await credential.GetTokenAsync(MockScopes.Default);

            Assert.IsTrue(new MockToken(defaultScopeToken.Token).HasField("scopes", MockScopes.Default.ToString()));
        }
    }
}
