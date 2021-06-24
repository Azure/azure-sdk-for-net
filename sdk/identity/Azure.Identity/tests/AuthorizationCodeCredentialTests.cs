// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AuthorizationCodeCredentialTests : ClientTestBase
    {
        private const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        private const string TenantId = "a0287521-e002-0026-7112-207c0c000000";
        private const string TenantIdHint = "a0287521-e002-0026-7112-207c0c001234";
        private const string ReplyUrl = "https://myredirect/";
        private const string Scope = "https://vault.azure.net/.default";
        private TokenCredentialOptions options;
        private string authCode;
        private string expectedToken;
        private DateTimeOffset expiresOn;
        private MockMsalConfidentialClient mockMsalClient;
        private string expectedTenantId;
        private string expectedReplyUri;
        private string clientSecret = Guid.NewGuid().ToString();
        private Func<string[], string, string, AuthenticationAccount, ValueTask<AuthenticationResult>> silentFactory;

        public AuthorizationCodeCredentialTests(bool isAsync) : base(isAsync)
        { }

        [SetUp]
        public void TestSetup()
        {
            expectedTenantId = TenantId;
            expectedReplyUri = null;
            authCode = Guid.NewGuid().ToString();
            expectedToken = Guid.NewGuid().ToString();
            expiresOn = DateTimeOffset.Now.AddHours(1);
            var result = new AuthenticationResult(
                expectedToken,
                false,
                null,
                expiresOn,
                expiresOn,
                TenantId,
                new MockAccount("username"),
                null,
                new[] { Scope },
                Guid.NewGuid(),
                null,
                "Bearer");
            silentFactory = (_, _tenantId, _replyUri, _) =>
            {
                Assert.AreEqual(expectedTenantId, _tenantId);
                Assert.AreEqual(expectedReplyUri, _replyUri);
                return new ValueTask<AuthenticationResult>(result);
            };
            mockMsalClient = new MockMsalConfidentialClient(silentFactory);
            mockMsalClient.AuthcodeFactory = (_, _tenantId, _replyUri, _) =>
            {
                Assert.AreEqual(expectedTenantId, _tenantId);
                Assert.AreEqual(expectedReplyUri, _replyUri);
                return result;
            };
        }

        [Test]
        public async Task AuthenticateWithAuthCodeHonorsReplyUrl([Values(null, ReplyUrl)] string replyUri)
        {
            AuthorizationCodeCredentialOptions options = null;
            if (replyUri != null)
            {
                options = new AuthorizationCodeCredentialOptions { RedirectUri = new Uri(replyUri) };
            }
            var context = new TokenRequestContext(new[] { Scope });
            expectedReplyUri = replyUri;

            AuthorizationCodeCredential cred = InstrumentClient(
                new AuthorizationCodeCredential(TenantId, ClientId, clientSecret, authCode, options, mockMsalClient));

            AccessToken token = await cred.GetTokenAsync(context);

            Assert.AreEqual(token.Token, expectedToken, "Should be the expected token value");

            AccessToken token2 = await cred.GetTokenAsync(context);

            Assert.AreEqual(token2.Token, expectedToken, "Should be the expected token value");
        }

        [Test]
        public async Task AuthenticateWithAuthCodeHonorsTenantId([Values(null, TenantIdHint)] string tenantId, [Values(true)] bool allowMultiTenantAuthentication)
        {
            options = new TokenCredentialOptions { AllowMultiTenantAuthentication = allowMultiTenantAuthentication };
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolver.Resolve(TenantId, context, options.AllowMultiTenantAuthentication);

            AuthorizationCodeCredential cred = InstrumentClient(new AuthorizationCodeCredential(TenantId, ClientId, clientSecret, authCode, options, mockMsalClient));

            AccessToken token = await cred.GetTokenAsync(context);

            Assert.AreEqual(token.Token, expectedToken, "Should be the expected token value");

            AccessToken token2 = await cred.GetTokenAsync(context);

            Assert.AreEqual(token2.Token, expectedToken, "Should be the expected token value");
        }
    }
}
