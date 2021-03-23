// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class SharedTokenCacheCredentialTests : ClientTestBase
    {
        private const string expectedUsername = "mockuser@mockdomain.com";

        public SharedTokenCacheCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task VerifyAuthenticationRecordOption()
        {
            var expectedHomeId = $"{Guid.NewGuid()}.{Guid.NewGuid()}";

            var expectedEnvironment = AzureAuthorityHosts.AzurePublicCloud.ToString();

            var acquireTokenSilentCalled = false;

            var options = new SharedTokenCacheCredentialOptions
            {
                AuthenticationRecord = new AuthenticationRecord(expectedUsername, expectedEnvironment, expectedHomeId, Guid.NewGuid().ToString(), Guid.NewGuid().ToString())
            };

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount("nonexpecteduser@mockdomain.com") },
                ExtendedSilentAuthFactory = (_, account, __, ___) =>
                {
                    Assert.AreEqual(expectedUsername, account.Username);

                    Assert.AreEqual(expectedEnvironment, account.Environment);

                    Assert.AreEqual(expectedHomeId, account.HomeAccountId.Identifier);

                    acquireTokenSilentCalled = true;

                    return AuthenticationResultFactory.Create();
                }
            };

            var credential = InstrumentClient(new SharedTokenCacheCredential(null, null, options, null, mockMsalClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.IsTrue(acquireTokenSilentCalled);
        }

        [Test]
        public async Task OneAccountNoTentantNoUsername()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount(expectedUsername) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            var credential = InstrumentClient(new SharedTokenCacheCredential(null, null, null, null, mockMsalClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken, token.Token);

            Assert.AreEqual(expExpiresOn, token.ExpiresOn);
        }

        [Test]
        public async Task OneMatchingAccountUsernameOnly()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount("fakeuser@fakedomain.com"), new MockAccount(expectedUsername) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            var credential = InstrumentClient(new SharedTokenCacheCredential(null, expectedUsername, null, null, mockMsalClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken, token.Token);

            Assert.AreEqual(expExpiresOn, token.ExpiresOn);
        }

        [Test]
        public async Task OneMatchingAccountUsernameDifferentCasing()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount("fakeuser@fakedomain.com"), new MockAccount(expectedUsername) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            var credential = InstrumentClient(new SharedTokenCacheCredential(null, expectedUsername, null, null, mockMsalClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken, token.Token);

            Assert.AreEqual(expExpiresOn, token.ExpiresOn);
        }

        [Test]
        public async Task OneMatchingAccountTenantIdOnly()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);
            string nonMatchedTenantId = Guid.NewGuid().ToString();
            string tenantId = Guid.NewGuid().ToString();
            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount(expectedUsername, nonMatchedTenantId), new MockAccount("fakeuser@fakedomain.com"), new MockAccount(expectedUsername, tenantId) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            var credential = InstrumentClient(new SharedTokenCacheCredential(tenantId, null, null, null, mockMsalClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken, token.Token);

            Assert.AreEqual(expExpiresOn, token.ExpiresOn);
        }

        [Test]
        public async Task OneMatchingAccountTenantIdAndUsername()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);
            string tenantId = Guid.NewGuid().ToString();
            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount(expectedUsername, Guid.NewGuid().ToString()), new MockAccount("fakeuser@fakedomain.com"), new MockAccount(expectedUsername, tenantId) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            var credential = InstrumentClient(new SharedTokenCacheCredential(tenantId, expectedUsername, null, null, mockMsalClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken, token.Token);

            Assert.AreEqual(expExpiresOn, token.ExpiresOn);
        }

        [Test]
        public async Task NoAccounts()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            // without username
            var credential = InstrumentClient(new SharedTokenCacheCredential(null, null, null, null, mockMsalClient));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(SharedTokenCacheCredential.NoAccountsInCacheMessage, ex.Message);

            // with username
            var credential2 = InstrumentClient(new SharedTokenCacheCredential(null, expectedUsername, null, null, mockMsalClient));

            var ex2 = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential2.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(SharedTokenCacheCredential.NoAccountsInCacheMessage, ex2.Message);

            // with tenantId
            var credential3 = InstrumentClient(new SharedTokenCacheCredential(Guid.NewGuid().ToString(), null, null, null, mockMsalClient));

            var ex3 = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential3.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(SharedTokenCacheCredential.NoAccountsInCacheMessage, ex3.Message);

            // with tenantId and username
            var credential4 = InstrumentClient(new SharedTokenCacheCredential(Guid.NewGuid().ToString(), expectedUsername, null, null, mockMsalClient));

            var ex4 = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential4.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(SharedTokenCacheCredential.NoAccountsInCacheMessage, ex4.Message);

            await Task.CompletedTask;
        }

        [Test]
        public async Task MultipleAccountsNoTenantIdOrUsername()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);
            string fakeuserTenantId = Guid.NewGuid().ToString();
            string madeupuserTenantId = Guid.NewGuid().ToString();

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount("fakeuser@fakedomain.com", fakeuserTenantId), new MockAccount("madeupuser@madeupdomain.com", madeupuserTenantId) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            var credential = InstrumentClient(new SharedTokenCacheCredential(null, null, null, null, mockMsalClient));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(ex.Message, SharedTokenCacheCredential.MultipleAccountsInCacheMessage);

            await Task.CompletedTask;
        }

        [Test]
        public async Task NoMatchingAccountsUsernameOnly()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);
            string fakeuserTenantId = Guid.NewGuid().ToString();
            string madeupuserTenantId = Guid.NewGuid().ToString();

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount("fakeuser@fakedomain.com", fakeuserTenantId), new MockAccount("madeupuser@madeupdomain.com", madeupuserTenantId) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            // with username
            var credential = InstrumentClient(new SharedTokenCacheCredential(null, expectedUsername, null, null, mockMsalClient));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(ex.Message, $"SharedTokenCacheCredential authentication unavailable. No account matching the specified username: {expectedUsername} was found in the cache.");

            await Task.CompletedTask;
        }

        [Test]
        public async Task NoMatchingAccountsTenantIdOnly()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);
            string fakeuserTenantId = Guid.NewGuid().ToString();
            string madeupuserTenantId = Guid.NewGuid().ToString();
            string tenantId = Guid.NewGuid().ToString();

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount("fakeuser@fakedomain.com", fakeuserTenantId), new MockAccount("madeupuser@madeupdomain.com", madeupuserTenantId) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            // with username
            var credential = InstrumentClient(new SharedTokenCacheCredential(tenantId, null, null, null, mockMsalClient));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(ex.Message, $"SharedTokenCacheCredential authentication unavailable. No account matching the specified tenantId: {tenantId} was found in the cache.");

            await Task.CompletedTask;
        }

        [Test]
        public async Task NoMatchingAccountsTenantIdAndUsername()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);
            string fakeuserTenantId = Guid.NewGuid().ToString();
            string madeupuserTenantId = Guid.NewGuid().ToString();
            string tenantId = Guid.NewGuid().ToString();

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount("fakeuser@fakedomain.com", fakeuserTenantId), new MockAccount("madeupuser@madeupdomain.com", madeupuserTenantId) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            // with username
            var credential = InstrumentClient(new SharedTokenCacheCredential(tenantId, expectedUsername, null, null, mockMsalClient));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(ex.Message, $"SharedTokenCacheCredential authentication unavailable. No account matching the specified username: {expectedUsername} tenantId: {tenantId} was found in the cache.");

            await Task.CompletedTask;
        }

        [Test]
        public async Task MultipleMatchingAccountsUsernameOnly()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);
            string fakeuserTenantId = Guid.NewGuid().ToString();
            string mockuserTenantId = Guid.NewGuid().ToString();
            string mockuserGuestTenantId = fakeuserTenantId;

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount("fakeuser@fakedomain.com", fakeuserTenantId), new MockAccount(expectedUsername, mockuserTenantId), new MockAccount(expectedUsername, mockuserGuestTenantId) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            var credential = InstrumentClient(new SharedTokenCacheCredential(null, expectedUsername, null, null, mockMsalClient));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(ex.Message, $"SharedTokenCacheCredential authentication unavailable. Multiple accounts matching the specified username: {expectedUsername} were found in the cache.");

            await Task.CompletedTask;
        }

        [Test]
        public async Task MultipleMatchingAccountsTenantIdOnly()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);
            string fakeuserTenantId = Guid.NewGuid().ToString();
            string mockuserTenantId = Guid.NewGuid().ToString();
            string mockuserGuestTenantId = fakeuserTenantId;

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount("fakeuser@fakedomain.com", fakeuserTenantId), new MockAccount(expectedUsername, mockuserTenantId), new MockAccount(expectedUsername, mockuserGuestTenantId) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            var credential = InstrumentClient(new SharedTokenCacheCredential(mockuserGuestTenantId, null, null, null, mockMsalClient));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(ex.Message, $"SharedTokenCacheCredential authentication unavailable. Multiple accounts matching the specified tenantId: {mockuserGuestTenantId} were found in the cache.");

            await Task.CompletedTask;
        }

        [Test]
        public async Task MultipleMatchingAccountsUsernameAndTenantId()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);
            string fakeuserTenantId = Guid.NewGuid().ToString();
            string mockuserTenantId = Guid.NewGuid().ToString();
            string mockuserGuestTenantId = fakeuserTenantId;

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount("fakeuser@fakedomain.com", fakeuserTenantId), new MockAccount(expectedUsername, mockuserTenantId), new MockAccount(expectedUsername, mockuserTenantId) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            var credential = InstrumentClient(new SharedTokenCacheCredential(mockuserTenantId, expectedUsername, null, null, mockMsalClient));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.AreEqual(ex.Message, $"SharedTokenCacheCredential authentication unavailable. Multiple accounts matching the specified username: {expectedUsername} tenantId: {mockuserTenantId} were found in the cache.");

            await Task.CompletedTask;
        }

        [Test]
        public async Task MultipleMatchingAccountsUsernameAndTenantIdWithEnableGuestTenantAuthentication()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);
            string fakeuserTenantId = Guid.NewGuid().ToString();
            string mockuserTenantId1 = Guid.NewGuid().ToString();
            string mockuserTenantId2 = Guid.NewGuid().ToString();
            string mockuserGuestTenantId = fakeuserTenantId;

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount("fakeuser@fakedomain.com", fakeuserTenantId), new MockAccount(expectedUsername, mockuserTenantId1), new MockAccount(expectedUsername, mockuserTenantId2) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            var credential = InstrumentClient(new SharedTokenCacheCredential(mockuserTenantId1, expectedUsername, new SharedTokenCacheCredentialOptions { EnableGuestTenantAuthentication = true }, null, mockMsalClient));

            var token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken, token.Token);

            Assert.AreEqual(expExpiresOn, token.ExpiresOn);
        }

        [Test]
        public async Task UiRequiredException()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);

            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount(expectedUsername) },
                SilentAuthFactory = (_) => { throw new MsalUiRequiredException("code", "message"); }
            };

            // with username
            var credential = InstrumentClient(new SharedTokenCacheCredential(null, expectedUsername, null, null, mockMsalClient));

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            var expErrorMessage = $"SharedTokenCacheCredential authentication unavailable. Token acquisition failed for user {expectedUsername}. Ensure that you have authenticated with a developer tool that supports Azure single sign on.";

            Assert.AreEqual(expErrorMessage, ex.Message);

            await Task.CompletedTask;
        }

        [Test]
        public async Task MatchAnySingleTenantIdWithEnableGuestTenantAuthentication()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);
            string tenantId = Guid.NewGuid().ToString();
            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount(expectedUsername, Guid.NewGuid().ToString()) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            var credential = InstrumentClient(new SharedTokenCacheCredential(tenantId, null, new SharedTokenCacheCredentialOptions { EnableGuestTenantAuthentication = true }, null, mockMsalClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken, token.Token);

            Assert.AreEqual(expExpiresOn, token.ExpiresOn);
        }

        [Test]
        public async Task MatchAnyTenantIdWithEnableGuestTenantAuthenticationAndUsername()
        {
            string expToken = Guid.NewGuid().ToString();
            DateTimeOffset expExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);
            string tenantId = Guid.NewGuid().ToString();
            var mockMsalClient = new MockMsalPublicClient
            {
                Accounts = new List<IAccount> { new MockAccount(expectedUsername, Guid.NewGuid().ToString()), new MockAccount("fakeuser@fakedomain.com", Guid.NewGuid().ToString()) },
                SilentAuthFactory = (_) => { return AuthenticationResultFactory.Create(accessToken: expToken, expiresOn: expExpiresOn); }
            };

            var credential = InstrumentClient(new SharedTokenCacheCredential(tenantId, expectedUsername, new SharedTokenCacheCredentialOptions { EnableGuestTenantAuthentication = true }, null, mockMsalClient));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken, token.Token);

            Assert.AreEqual(expExpiresOn, token.ExpiresOn);
        }

        [Test]
        public void ValidateClientIdSetOnMsalClient()
        {
            var clientId = Guid.NewGuid().ToString();

            var credential = new SharedTokenCacheCredential(new SharedTokenCacheCredentialOptions { ClientId = clientId });

            Assert.AreEqual(clientId, credential.Client.ClientId);
        }
    }
}
