// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class SharedTokenCacheCredentialTests : ClientTestBase
    {
        public SharedTokenCacheCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task OneAccountNoUsername()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new IAccount[] { new MockAccount("mockuser@mockdomain.com") },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            // with username
            var credential = InstrumentClient(new SharedTokenCacheCredential(null, CredentialPipeline.GetInstance(null), mockMsalClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken, token.Token);

            Assert.AreEqual(expExpiresOn, token.ExpiresOn);
        }

        [Test]
        public async Task OneMatchingAccount()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new IAccount[] { new MockAccount("fakeuser@fakedomain.com"), new MockAccount("mockuser@mockdomain.com") },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            // with username
            var credential = InstrumentClient(new SharedTokenCacheCredential("mockuser@mockdomain.com", CredentialPipeline.GetInstance(null), mockMsalClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken, token.Token);

            Assert.AreEqual(expExpiresOn, token.ExpiresOn);
        }

        [Test]
        public async Task MultipleMatchingAccounts()
        {
            string expToken = Guid.NewGuid().ToString();
            string homeId = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new IAccount[] { new MockAccount("mockuser@mockdomain.com", homeId), new MockAccount("fakeuser@fakedomain.com"), new MockAccount("mockuser@mockdomain.com", homeId) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            // with username
            var credential = InstrumentClient(new SharedTokenCacheCredential("mockuser@mockdomain.com", CredentialPipeline.GetInstance(null), mockMsalClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken, token.Token);

            Assert.AreEqual(expExpiresOn, token.ExpiresOn);
        }

        [Test]
        public async Task MultipleMatchingAccountsDifferentHomeIds()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new IAccount[] { new MockAccount("mockuser@mockdomain.com"), new MockAccount("fakeuser@fakedomain.com"), new MockAccount("mockuser@mockdomain.com") },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            // with username
            var credential = InstrumentClient(new SharedTokenCacheCredential("mockuser@mockdomain.com", CredentialPipeline.GetInstance(null), mockMsalClient));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.True(ex.Message.Contains("Multiple entries for the user account 'mockuser@mockdomain.com' were found in the shared token cache. This is not currently supported by the SharedTokenCacheCredential."));

            await Task.CompletedTask;
        }

        [Test]
        public async Task NoAccounts()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new IAccount[] { },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            // without username
            var credential = InstrumentClient(new SharedTokenCacheCredential(null, CredentialPipeline.GetInstance(null), mockMsalClient));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(SharedTokenCacheCredential.NoAccountsErrorMessage, ex.Message);

            // with username
            var credential2 = InstrumentClient(new SharedTokenCacheCredential("mockuser@mockdomain.com", CredentialPipeline.GetInstance(null), mockMsalClient));

            var ex2 = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential2.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(SharedTokenCacheCredential.NoAccountsErrorMessage, ex2.Message);

            await Task.CompletedTask;
        }

        [Test]
        public async Task MultipleAccountsNoUsername()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new IAccount[] { new MockAccount("fakeuser@fakedomain.com"), new MockAccount("madeupuser@madeupdomain.com") },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            // with username
            var credential = InstrumentClient(new SharedTokenCacheCredential(null, CredentialPipeline.GetInstance(null), mockMsalClient));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.True(ex.Message.Contains(SharedTokenCacheCredential.MultipleAccountsErrorMessage));

            Assert.True(ex.Message.Contains($"Discovered Accounts: [ 'fakeuser@fakedomain.com', 'madeupuser@madeupdomain.com' ]"));

            await Task.CompletedTask;
        }

        [Test]
        public async Task NoMatchingAccounts()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new IAccount[] { new MockAccount("fakeuser@fakedomain.com"), new MockAccount("madeupuser@madeupdomain.com") },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            // with username
            var credential = InstrumentClient(new SharedTokenCacheCredential("mockuser@mockdomain.com", CredentialPipeline.GetInstance(null), mockMsalClient));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.True(ex.Message.Contains($"account 'mockuser@mockdomain.com' was not found"));

            Assert.True(ex.Message.Contains($"Discovered Accounts: [ 'fakeuser@fakedomain.com', 'madeupuser@madeupdomain.com' ]"));

            await Task.CompletedTask;
        }

        [Test]
        public async Task UiRequiredException()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new IAccount[] { new MockAccount("mockuser@mockdomain.com") },
                SilentAuthFactory = (_) => { throw new MsalUiRequiredException("code", "message"); }
            };

            // with username
            var credential = InstrumentClient(new SharedTokenCacheCredential("mockuser@mockdomain.com", CredentialPipeline.GetInstance(null), mockMsalClient));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            var expErrorMessage = "Token aquisition failed for user 'mockuser@mockdomain.com'. To fix, reauthenticate through tooling supporting azure developer sign on.";

            Assert.AreEqual(expErrorMessage, ex.Message);

            await Task.CompletedTask;
        }
    }
}
