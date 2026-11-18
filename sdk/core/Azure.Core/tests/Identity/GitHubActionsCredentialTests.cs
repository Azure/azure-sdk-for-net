// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Core.Tests.Identity
{
    [NonParallelizable]
    public class GitHubActionsCredentialTests : CredentialTestBase<GitHubActionsCredentialOptions>
    {
        private const string RequestUrl = "https://token.actions.githubusercontent.com/oidc?api-version=2.0";
        private const string RequestToken = "github-request-token";
        private const string IdToken = "github-id-token";

        public GitHubActionsCredentialTests(bool isAsync) : base(isAsync)
        { }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var credentialOptions = CreateOptions();
            credentialOptions.Diagnostics.IsAccountIdentifierLoggingEnabled = options.Diagnostics.IsAccountIdentifierLoggingEnabled;
            credentialOptions.MsalClient = mockConfidentialMsalClient;
            credentialOptions.Pipeline = CredentialPipeline.GetInstance(null);

            return InstrumentClient(new GitHubActionsCredential(credentialOptions));
        }

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            if (config.TenantId == null)
            {
                Assert.Ignore("Null TenantId test does not apply to this credential");
            }
            if (config.AuthorityHost != null && GitHubActionsCredential.GetAudience(config.AuthorityHost) == null)
            {
                Assert.Ignore("GitHubActionsCredential doesn't support this authority host");
            }

            var options = CreateOptions(tenantId: config.TenantId);
            options.DisableInstanceDiscovery = config.DisableInstanceDiscovery;
            options.AdditionallyAllowedTenants = config.AdditionallyAllowedTenants;
            options.IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled;
            options.MsalClient = config.MockConfidentialMsalClient;
            if (config.AuthorityHost != null)
            {
                options.AuthorityHost = config.AuthorityHost;
            }
            if (config.Transport != null)
            {
                options.Transport = config.Transport;
            }
            if (config.TokenCachePersistenceOptions != null)
            {
                options.TokenCachePersistenceOptions = config.TokenCachePersistenceOptions;
            }
            config.TransportConfig.ResponseHandler = (req, resp) =>
            {
                if (req.Uri.Host == "token.actions.githubusercontent.com")
                {
                    Assert.That(req.Headers.TryGetValue("Authorization", out var authHeader), Is.True);
                    Assert.That(authHeader, Is.EqualTo($"Bearer {RequestToken}"));
                    resp.SetContent($$"""{"value": "{{IdToken}}"}""");
                }
            };
            options.Pipeline = CredentialPipeline.GetInstance(options);

            return InstrumentClient(new GitHubActionsCredential(options));
        }

        [Test]
        public void OptionsLoadFromEnvironment()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "ACTIONS_ID_TOKEN_REQUEST_URL", RequestUrl },
                { "ACTIONS_ID_TOKEN_REQUEST_TOKEN", RequestToken },
                { "AZURE_TENANT_ID", TenantId },
                { "AZURE_CLIENT_ID", ClientId },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", "tenant1;tenant2" },
            }))
            {
                var options = new GitHubActionsCredentialOptions();

                Assert.AreEqual(RequestUrl, options.RequestUrl);
                Assert.AreEqual(RequestToken, options.RequestToken);
                Assert.AreEqual(TenantId, options.TenantId);
                Assert.AreEqual(ClientId, options.ClientId);
                CollectionAssert.AreEquivalent(new[] { "tenant1", "tenant2" }, options.AdditionallyAllowedTenants);
            }
        }

        [Test]
        public void ConstructorDoesNotThrowWhenNotConfigured()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "ACTIONS_ID_TOKEN_REQUEST_URL", null },
                { "ACTIONS_ID_TOKEN_REQUEST_TOKEN", null },
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", null },
            }))
            {
                GitHubActionsCredential credential = null;
                Assert.DoesNotThrow(() => credential = new GitHubActionsCredential());

                var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await GetTokenAsync(credential));
                Assert.That(ex.Message, Does.Contain("ACTIONS_ID_TOKEN_REQUEST_URL"));
                Assert.That(ex.Message, Does.Contain("ACTIONS_ID_TOKEN_REQUEST_TOKEN"));
                Assert.That(ex.Message, Does.Contain("id-token: write"));
            }
        }

        [Test]
        [TestCase(null, RequestToken, TestTenantId, TestClientId, "ACTIONS_ID_TOKEN_REQUEST_URL")]
        [TestCase(" ", RequestToken, TestTenantId, TestClientId, "ACTIONS_ID_TOKEN_REQUEST_URL")]
        [TestCase(RequestUrl, null, TestTenantId, TestClientId, "ACTIONS_ID_TOKEN_REQUEST_TOKEN")]
        [TestCase(RequestUrl, "", TestTenantId, TestClientId, "ACTIONS_ID_TOKEN_REQUEST_TOKEN")]
        [TestCase(RequestUrl, RequestToken, null, TestClientId, "AZURE_TENANT_ID")]
        [TestCase(RequestUrl, RequestToken, TestTenantId, null, "AZURE_CLIENT_ID")]
        [TestCase("not-a-url", RequestToken, TestTenantId, TestClientId, "ACTIONS_ID_TOKEN_REQUEST_URL")]
        [TestCase("http://token.actions.githubusercontent.com", RequestToken, TestTenantId, TestClientId, "HTTPS")]
        [TestCase("https://user:secret@token.actions.githubusercontent.com", RequestToken, TestTenantId, TestClientId, "user information")]
        public void GetTokenThrowsCredentialUnavailableWhenMisconfigured(string requestUrl, string requestToken, string tenantId, string clientId, string expectedMessage)
        {
            var transport = new MockTransport(_ => throw new InvalidOperationException("No requests expected"));
            var options = CreateOptions(requestUrl, requestToken, tenantId, clientId, transport);
            var credential = new GitHubActionsCredential(options);

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await GetTokenAsync(credential));

            Assert.That(ex.Message, Does.Contain(expectedMessage));
            Assert.That(ex.Message, Does.Contain(GitHubActionsCredential.Troubleshooting));
            Assert.IsEmpty(transport.Requests);
        }

        [Test]
        public void GetTokenThrowsCredentialUnavailableForUnsupportedAuthorityHost()
        {
            var options = CreateOptions();
            options.AuthorityHost = new Uri("https://login.example.com");
            var credential = new GitHubActionsCredential(options);

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await GetTokenAsync(credential));

            Assert.That(ex.Message, Does.Contain("login.example.com"));
        }

        [Test]
        public void ConstructorThrowsForInvalidTenantId()
        {
            Assert.Throws<ArgumentException>(() => new GitHubActionsCredential(CreateOptions(tenantId: "invalid tenant")));
        }

        [Test]
        [TestCase("https://login.microsoftonline.com/", "api://AzureADTokenExchange")]
        [TestCase("https://login.chinacloudapi.cn/", "api://AzureADTokenExchangeChina")]
        [TestCase("https://login.microsoftonline.us/", "api://AzureADTokenExchangeUSGov")]
        [TestCase("https://login.sovcloud-identity.fr/", "api://AzureADTokenExchangeFrance")]
        [TestCase("https://login.sovcloud-identity.de/", "api://AzureADTokenExchangeGermany")]
        [TestCase("https://login.sovcloud-identity.sg/", "api://AzureADTokenExchangeGovSG")]
        [TestCase("https://LOGIN.MICROSOFTONLINE.COM/", "api://AzureADTokenExchange")]
        public async Task IdTokenRequestUsesAudienceForAuthorityHost(string authorityHost, string expectedAudience)
        {
            var transport = CreateTransport();
            var options = CreateOptions(transport: transport);
            options.AuthorityHost = new Uri(authorityHost);
            var credential = new GitHubActionsCredential(options);

            await GetTokenAsync(credential);

            MockRequest oidcRequest = transport.Requests.Single(r => r.Uri.Host == "token.actions.githubusercontent.com");
            Assert.That(oidcRequest.Uri.ToUri().Query, Is.EqualTo($"?api-version=2.0&audience={Uri.EscapeDataString(expectedAudience)}"));
        }

        [Test]
        [TestCase("https://token.actions.githubusercontent.com/oidc", "?audience=api%3A%2F%2FAzureADTokenExchange")]
        [TestCase("https://token.actions.githubusercontent.com/oidc?api-version=2.0", "?api-version=2.0&audience=api%3A%2F%2FAzureADTokenExchange")]
        [TestCase("https://token.actions.githubusercontent.com/oidc?audience=old&api-version=2.0&audience=other", "?api-version=2.0&audience=api%3A%2F%2FAzureADTokenExchange")]
        public async Task IdTokenRequestAppendsAudienceAndSendsRequestToken(string requestUrl, string expectedQuery)
        {
            var transport = CreateTransport();
            var credential = new GitHubActionsCredential(CreateOptions(requestUrl: requestUrl, transport: transport));

            AccessToken token = await GetTokenAsync(credential);

            Assert.AreEqual("mytoken", token.Token);
            MockRequest oidcRequest = transport.Requests.Single(r => r.Uri.Host == "token.actions.githubusercontent.com");
            Assert.AreEqual(RequestMethod.Get, oidcRequest.Method);
            Assert.AreEqual(expectedQuery, oidcRequest.Uri.ToUri().Query);
            Assert.That(oidcRequest.Headers.TryGetValue("Authorization", out string authorization), Is.True);
            Assert.AreEqual($"Bearer {RequestToken}", authorization);

            Assert.That(_lastEntraRequestBody, Does.Contain($"client_assertion={IdToken}"));
            Assert.That(_lastEntraRequestBody, Does.Contain("client_assertion_type=urn%3Aietf%3Aparams%3Aoauth%3Aclient-assertion-type%3Ajwt-bearer"));
            Assert.That(_lastEntraRequestBody, Does.Contain($"client_id={TestClientId}"));
        }

        [Test]
        public void IdTokenNon200ResponseThrowsAuthenticationFailed()
        {
            var transport = CreateTransport(oidcResponse: new MockResponse(401).WithContent("unauthorized details"));
            var credential = new GitHubActionsCredential(CreateOptions(transport: transport));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await GetTokenAsync(credential));

            Assert.That(ex.Message, Does.Contain("401"));
            Assert.That(ex.Message, Does.Not.Contain("unauthorized details"));
            Assert.That(ex.Message, Does.Not.Contain(RequestToken));
            Assert.That(ex.Message, Does.Contain(GitHubActionsCredential.Troubleshooting));
        }

        [Test]
        [TestCase("not json")]
        [TestCase("{\"value\": \"token\"} trailing")]
        [TestCase("[]")]
        [TestCase("{}")]
        [TestCase("{\"value\": \"\"}")]
        [TestCase("{\"value\": \" \\n\"}")]
        [TestCase("{\"value\": 123}")]
        [TestCase("{\"value\": null}")]
        [TestCase("{\"nested\": {\"value\": \"token\"}}")]
        public void IdTokenInvalidResponseThrowsAuthenticationFailed(string content)
        {
            var transport = CreateTransport(oidcResponse: new MockResponse(200).WithContent(content));
            var credential = new GitHubActionsCredential(CreateOptions(transport: transport));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await GetTokenAsync(credential));

            Assert.That(ex.Message, Does.Contain("\"value\""));
            Assert.That(ex.Message, Does.Not.Contain(content));
        }

        [Test]
        public async Task IdTokenIsRequestedOnlyWhenAccessTokenIsNotCached()
        {
            var transport = CreateTransport();
            var credential = new GitHubActionsCredential(CreateOptions(transport: transport));

            await GetTokenAsync(credential);
            await GetTokenAsync(credential);
            Assert.AreEqual(1, transport.Requests.Count(r => r.Uri.Host == "token.actions.githubusercontent.com"));

            await GetTokenAsync(credential, new TokenRequestContext(new[] { DefaultScope }, claims: """{"access_token":{"nbf":{"essential":true,"value":"1"}}}"""));
            Assert.AreEqual(2, transport.Requests.Count(r => r.Uri.Host == "token.actions.githubusercontent.com"));
            Assert.That(_lastEntraRequestBody, Does.Contain("claims="));
        }

        [Test]
        public async Task CustomPoliciesApplyToIdTokenAndEntraRequests()
        {
            var transport = CreateTransport();
            var options = CreateOptions(transport: transport);
            options.AddPolicy(new AddHeaderPolicy("x-custom", "value"), HttpPipelinePosition.PerCall);
            var credential = new GitHubActionsCredential(options);

            await GetTokenAsync(credential);

            Assert.That(transport.Requests, Has.Some.Matches<MockRequest>(r => r.Uri.Host == "token.actions.githubusercontent.com"));
            Assert.That(transport.Requests, Has.Some.Matches<MockRequest>(r => r.Uri.Host == "login.microsoftonline.com"));
            foreach (MockRequest request in transport.Requests)
            {
                Assert.That(request.Headers.TryGetValue("x-custom", out string value), Is.True, request.Uri.ToString());
                Assert.AreEqual("value", value);
            }
        }

        [Test]
        public async Task WorksInChainedCredentialWhenNotConfigured()
        {
            var options = CreateOptions(requestUrl: null, requestToken: null);
            var chained = new ChainedTokenCredential(new GitHubActionsCredential(options), new MockCredential());

            AccessToken token = await chained.GetTokenAsync(new TokenRequestContext(new[] { "scope" }), CancellationToken.None);

            Assert.AreEqual("TEST TOKEN scope", token.Token);
        }

        private const string TestTenantId = "a0287521-e002-0026-7112-207c0c000000";
        private const string TestClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";

        private GitHubActionsCredentialOptions CreateOptions(
            string requestUrl = RequestUrl,
            string requestToken = RequestToken,
            string tenantId = TestTenantId,
            string clientId = TestClientId,
            MockTransport transport = null)
        {
            var options = new GitHubActionsCredentialOptions
            {
                RequestUrl = requestUrl,
                RequestToken = requestToken,
                TenantId = tenantId,
                ClientId = clientId,
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
                DisableInstanceDiscovery = true,
            };
            if (transport != null)
            {
                options.Transport = transport;
            }
            return options;
        }

        private string _lastEntraRequestBody;

        private MockTransport CreateTransport(MockResponse oidcResponse = null)
        {
            return new MockTransport(request =>
            {
                if (request.Uri.Host == "token.actions.githubusercontent.com")
                {
                    return oidcResponse ?? new MockResponse(200).WithContent($$"""{"value": "{{IdToken}}"}""");
                }
                _lastEntraRequestBody = ReadBody(request);
                return new MockResponse(200).WithContent("""{"token_type": "Bearer", "expires_in": 9999, "ext_expires_in": 9999, "access_token": "mytoken"}""");
            });
        }

        private const string DefaultScope = "https://management.azure.com/.default";

        private async ValueTask<AccessToken> GetTokenAsync(TokenCredential credential, TokenRequestContext? requestContext = null)
        {
            TokenRequestContext context = requestContext ?? new TokenRequestContext(new[] { DefaultScope });
            return IsAsync ? await credential.GetTokenAsync(context, CancellationToken.None) : credential.GetToken(context, CancellationToken.None);
        }

        private static string ReadBody(MockRequest request)
        {
            using var stream = new System.IO.MemoryStream();
            request.Content.WriteTo(stream, CancellationToken.None);
            return System.Text.Encoding.UTF8.GetString(stream.ToArray());
        }

        private class AddHeaderPolicy : HttpPipelineSynchronousPolicy
        {
            private readonly string _name;
            private readonly string _value;

            public AddHeaderPolicy(string name, string value)
            {
                _name = name;
                _value = value;
            }

            public override void OnSendingRequest(HttpMessage message) => message.Request.Headers.SetValue(_name, _value);
        }
    }
}
