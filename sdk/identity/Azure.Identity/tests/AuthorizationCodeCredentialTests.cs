// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AuthorizationCodeCredentialTests : CredentialTestBase<AuthorizationCodeCredentialOptions>
    {
        private const string redirectUriString = "http://192.168.0.1/foo";

        public AuthorizationCodeCredentialTests(bool isAsync) : base(isAsync)
        { }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options) => InstrumentClient(
            new AuthorizationCodeCredential(TenantId, ClientId, clientSecret, authCode, options, mockConfidentialMsalClient));

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            if (config.TenantId == null)
            {
                Assert.Ignore("Null TenantId test does not apply to this credential");
            }

            var options = new AuthorizationCodeCredentialOptions
            {
                DisableInstanceDiscovery = config.DisableInstanceDiscovery,
                AdditionallyAllowedTenants = config.AdditionallyAllowedTenants,
                IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled,
            };
            if (config.Transport != null)
            {
                options.Transport = config.Transport;
            }
            var pipeline = CredentialPipeline.GetInstance(options);
            return InstrumentClient(
           new AuthorizationCodeCredential(config.TenantId, ClientId, clientSecret, authCode, options, config.MockConfidentialMsalClient, pipeline));
        }

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
            expectedTenantId = TenantIdResolverBase.Default.Resolve(TenantId, context, TenantIdResolverBase.AllTenants);

            var options = new AuthorizationCodeCredentialOptions { AdditionallyAllowedTenants = { TenantIdHint } };
            AuthorizationCodeCredential cred = InstrumentClient(
                new AuthorizationCodeCredential(TenantId, ClientId, clientSecret, authCode, options, mockConfidentialMsalClient));

            AccessToken token = await cred.GetTokenAsync(context);

            Assert.AreEqual(token.Token, expectedToken, "Should be the expected token value");

            AccessToken token2 = await cred.GetTokenAsync(context);

            Assert.AreEqual(token2.Token, expectedToken, "Should be the expected token value");
        }

        [Test]
        public async Task AuthenticateWithAutCodeHonorsRedirectUri([Values(null, redirectUriString)] string redirectUri)
        {
            var mockTransport = new MockTransport(req =>
            {
                if (redirectUri is not null && req.Uri.Path.EndsWith("/token"))
                {
                    var content = ReadMockRequestContent(req).GetAwaiter().GetResult();
                    Assert.That(WebUtility.UrlDecode(content), Does.Contain(redirectUri ?? string.Empty));
                }
                return CredentialTestHelpers.CreateMockMsalTokenResponse(200, expectedToken, TenantId, "foo");
            });
            var options = new AuthorizationCodeCredentialOptions { Transport = mockTransport };
            if (redirectUri != null)
            {
                options.RedirectUri = new Uri(redirectUri);
            }
            options.Retry.MaxDelay = TimeSpan.Zero;
            var pipeline = CredentialPipeline.GetInstance(options);

            AuthorizationCodeCredential credential =
                InstrumentClient(new AuthorizationCodeCredential(TenantId, ClientId, clientSecret, authCode, options, null, pipeline));

            var context = new TokenRequestContext(new[] { Scope }, tenantId: TenantId);
            await credential.GetTokenAsync(context);
        }
    }
}
