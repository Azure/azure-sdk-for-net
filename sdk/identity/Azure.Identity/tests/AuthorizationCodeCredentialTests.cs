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
    public class AuthorizationCodeCredentialTests : ClientTestBase
    {
        private const string ClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        private const string TenantId = "a0287521-e002-0026-7112-207c0c000000";
        private const string TenantIdHint = "a0287521-e002-0026-7112-207c0c001234";
        private const string Scope = "https://vault.azure.net/.default";
        private TokenCredentialOptions options;
        private string authCode;
        private string expectedToken;
        private DateTimeOffset expiresOn;
        private MockMsalConfidentialClient mockMsalClient;
        private string expectedTenantId;
        private string clientSecret = Guid.NewGuid().ToString();
        private Func<string[], string, AuthenticationAccount, ValueTask<AuthenticationResult>> silentFactory;

        public AuthorizationCodeCredentialTests(bool isAsync) : base(isAsync)
        { }

        [SetUp]
        public void TestSetup()
        {
            expectedTenantId = null;
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
            silentFactory = (_, _tenantId, _) =>
            {
                Assert.AreEqual(expectedTenantId, _tenantId);
                return new ValueTask<AuthenticationResult>(result);
            };
            mockMsalClient = new MockMsalConfidentialClient(silentFactory);
            mockMsalClient.AuthcodeFactory = (_, _tenantId, _) =>
            {
                Assert.AreEqual(expectedTenantId, _tenantId);
                return result;
            };
        }

        [Test]
        public async Task AuthenticateWithAuthCodeMockAsync([Values(null, TenantIdHint)] string tenantId, [Values(true, false)] bool preferHint)
        {
            options = new TokenCredentialOptions { PreferClientConfiguredTenantId = preferHint };
            var context = new TokenRequestContext(new TokenRequestContextOptions { Scopes = new[] { Scope }, TenantId = tenantId });
            expectedTenantId = TenantIdResolver.Resolve(TenantId, context, options) ;

            AuthorizationCodeCredential cred = InstrumentClient(new AuthorizationCodeCredential(TenantId, ClientId, clientSecret, authCode, options, mockMsalClient));

            AccessToken token = await cred.GetTokenAsync(context);

            Assert.AreEqual(token.Token, expectedToken, "Should be the expected token value");

            AccessToken token2 = await cred.GetTokenAsync(context);

            Assert.AreEqual(token2.Token, expectedToken, "Should be the expected token value");
        }
    }
}
