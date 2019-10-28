// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Testing;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity.Tests
{
    public class InteractiveBrowserCredentialTests : ClientTestBase
    {
        private const string MultiTenantClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        private const string SingleTenantClientId = "9985250a-c1c3-4caf-a039-9d98f2a0707a";
        private const string TenantId = "a7fc734e-9961-43ce-b4de-21b8b38403ba";

        public InteractiveBrowserCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("This test is an integration test which can only be run with user interaction")]
        public async Task AuthenticateWithBrowserAsync()
        {
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
        public async Task InteractiveBrowserAcquireTokenInteractiveException()
        {
            string expInnerExMessage = Guid.NewGuid().ToString();

            var mockMsalClient = new MockMsalPublicClient() { InteractiveAuthFactory = (_) => { throw new MockClientException(expInnerExMessage); } };

            var credential = InstrumentClient(new InteractiveBrowserCredential(CredentialPipeline.GetInstance(null), mockMsalClient));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsNotNull(ex.InnerException);

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
        }

        [Test]
        public async Task InteractiveBrowserAcquireTokenSilentException()
        {
            string expInnerExMessage = Guid.NewGuid().ToString();
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                InteractiveAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); },
                SilentAuthFactory = (_) => { throw new MockClientException(expInnerExMessage); }
            };

            var credential = InstrumentClient(new InteractiveBrowserCredential(CredentialPipeline.GetInstance(null), mockMsalClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken, token.Token);

            Assert.AreEqual(expExpiresOn, token.ExpiresOn);

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsNotNull(ex.InnerException);

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
        }

        [Test]
        public async Task InteractiveBrowserRefreshException()
        {
            string expInnerExMessage = Guid.NewGuid().ToString();
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                InteractiveAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); },
                SilentAuthFactory = (_) => { throw new MsalUiRequiredException("errorCode", "message"); }
            };

            var credential = InstrumentClient(new InteractiveBrowserCredential(CredentialPipeline.GetInstance(null), mockMsalClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken, token.Token);

            Assert.AreEqual(expExpiresOn, token.ExpiresOn);

            mockMsalClient.InteractiveAuthFactory = (_) => { throw new MockClientException(expInnerExMessage); };

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.IsNotNull(ex.InnerException);

            Assert.IsInstanceOf(typeof(MockClientException), ex.InnerException);

            Assert.AreEqual(expInnerExMessage, ex.InnerException.Message);

            await Task.CompletedTask;
        }
    }
}
