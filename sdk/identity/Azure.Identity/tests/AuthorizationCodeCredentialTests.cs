// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AuthorizationCodeCredentialTests : CredentialTestBase
    {
        public AuthorizationCodeCredentialTests(bool isAsync) : base(isAsync)
        { }

        [SetUp]
        public void Setup()
        {
            TestSetup();
            expectedTenantId = TenantId;
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
                new AuthorizationCodeCredential(TenantId, ClientId, clientSecret, authCode, options, mockConfidentialMsalClient));

            AccessToken token = await cred.GetTokenAsync(context);

            Assert.AreEqual(token.Token, expectedToken, "Should be the expected token value");

            AccessToken token2 = await cred.GetTokenAsync(context);

            Assert.AreEqual(token2.Token, expectedToken, "Should be the expected token value");
        }

        [Test]
        public async Task AuthenticateWithAuthCodeHonorsTenantId([Values(null, TenantIdHint)] string tenantId, [Values(true)] bool allowMultiTenantAuthentication)
        {
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolver.Resolve(TenantId, context);

            AuthorizationCodeCredential cred = InstrumentClient(
                new AuthorizationCodeCredential(TenantId, ClientId, clientSecret, authCode, options, mockConfidentialMsalClient));

            AccessToken token = await cred.GetTokenAsync(context);

            Assert.AreEqual(token.Token, expectedToken, "Should be the expected token value");

            AccessToken token2 = await cred.GetTokenAsync(context);

            Assert.AreEqual(token2.Token, expectedToken, "Should be the expected token value");
        }
    }
}
