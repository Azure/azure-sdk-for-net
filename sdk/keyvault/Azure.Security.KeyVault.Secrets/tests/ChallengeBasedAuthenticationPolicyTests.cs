// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
#if !NET462
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
#endif
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Tests
{
    [NonParallelizable]
    public class ChallengeBasedAuthenticationPolicyTests
    {
        private const string TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
        private const string VaultHost = "test.vault.azure.net";
        private const string TokenBoundAuthHeader = "x-ms-tokenboundauth";

        private static Uri VaultUri => new Uri("https://" + VaultHost);

        [SetUp]
        public void Setup()
        {
            ChallengeBasedAuthenticationPolicy.ClearCache();
        }

        [Test]
        public async Task SingleRequest()
        {
            MockTransport transport = new MockTransportBuilder().Build();
            SecretClientOptions options = new SecretClientOptions
            {
                Transport = transport,
            };

            SecretClient client = new SecretClient(VaultUri, new MockCredential(transport), options);

            KeyVaultSecret secret = await client.GetSecretAsync("test-secret").ConfigureAwait(false);
            Assert.AreEqual("secret-value", secret.Value);
        }

        [TestCase("mtls_pop")]
        [TestCase("PoP")]
        public async Task RequestsProofOfPossessionTokenAndAddsTokenBoundAuthHeader(string tokenType)
        {
            bool sawAuthorizedVaultRequest = false;
            MockTransportBuilder builder = new MockTransportBuilder();
            builder.Request += (_, args) =>
            {
                if (args.Request.Uri.Host == VaultHost &&
                    args.Request.Headers.TryGetValue("Authorization", out string _) &&
                    args.Request.Headers.TryGetValue(TokenBoundAuthHeader, out string tokenBoundAuth))
                {
                    sawAuthorizedVaultRequest = true;
                    Assert.AreEqual("true", tokenBoundAuth);
                }
            };

            MockTransport transport = builder.Build();

            // The credential simulates a Proof-of-Possession-bound token by returning the mtls_pop (managed-identity
            // mTLS PoP) or pop token type - what MSAL/Azure.Identity actually returns when a credential honors
            // TokenRequestContext.IsProofOfPossessionEnabled.
            MockCredential credential = new MockCredential(transport, tokenType: tokenType);
            SecretClient client = new SecretClient(
                VaultUri,
                credential,
                new SecretClientOptions
                {
                    Transport = transport,
                    EnableProofOfPossession = true,
                });

            KeyVaultSecret secret = await client.GetSecretAsync("test-secret").ConfigureAwait(false);

            Assert.AreEqual("secret-value", secret.Value);
            Assert.IsTrue(sawAuthorizedVaultRequest);
            Assert.IsNotNull(credential.LastRequestContext);
            Assert.IsTrue(credential.LastRequestContext.IsProofOfPossessionEnabled);
            Assert.AreEqual(TenantId, credential.LastRequestContext.TenantId);
            CollectionAssert.AreEqual(new[] { "https://vault.azure.net/.default" }, credential.LastRequestContext.Scopes);
            Assert.AreEqual(RequestMethod.Get.ToString(), credential.LastRequestContext.ResourceRequestMethod);
            Assert.AreEqual(new Uri("https://test.vault.azure.net/secrets/test-secret?api-version=2025-07-01"), credential.LastRequestContext.ResourceRequestUri);
        }

        [Test]
        public async Task DoesNotAddTokenBoundAuthHeaderWhenCredentialDoesNotReturnPoPToken()
        {
            // Requesting PoP via TokenRequestContext.IsProofOfPossessionEnabled does not guarantee the credential
            // honors it - most credentials (anything other than Managed Identity with mTLS support) simply ignore
            // the flag and return a normal Bearer token. The SDK must not claim the request is token-bound in that
            // case, even though the transport supports being updated and PoP was requested.
            bool sawAuthorizedVaultRequest = false;
            MockTransportBuilder builder = new MockTransportBuilder();
            builder.Request += (_, args) =>
            {
                if (args.Request.Uri.Host == VaultHost &&
                    args.Request.Headers.TryGetValue("Authorization", out string _))
                {
                    sawAuthorizedVaultRequest = true;
                }
            };

            MockTransport transport = builder.Build();
            MockCredential credential = new MockCredential(transport);
            SecretClient client = new SecretClient(
                VaultUri,
                credential,
                new SecretClientOptions
                {
                    Transport = transport,
                    EnableProofOfPossession = true,
                });

            KeyVaultSecret secret = await client.GetSecretAsync("test-secret").ConfigureAwait(false);

            Assert.AreEqual("secret-value", secret.Value);
            Assert.IsTrue(sawAuthorizedVaultRequest);
            Assert.IsNotNull(credential.LastRequestContext);
            Assert.IsTrue(credential.LastRequestContext.IsProofOfPossessionEnabled);
        }

        [Test]
        public async Task DoesNotRequestProofOfPossessionTokenForCustomTransportWithoutUpdateSupport()
        {
            bool sawAuthorizedVaultRequest = false;
            MockTransportBuilder builder = new MockTransportBuilder();
            builder.Request += (_, args) =>
            {
                if (args.Request.Uri.Host == VaultHost &&
                    args.Request.Headers.TryGetValue("Authorization", out string _))
                {
                    sawAuthorizedVaultRequest = true;
                    Assert.IsFalse(args.Request.Headers.TryGetValue(TokenBoundAuthHeader, out string _));
                }
            };

            MockTransport transport = builder.Build();
            MockCredential credential = new MockCredential(transport);
            SecretClient client = new SecretClient(
                VaultUri,
                credential,
                new SecretClientOptions
                {
                    Transport = new NonUpdatingTransport(transport),
                    EnableProofOfPossession = true,
                });

            KeyVaultSecret secret = await client.GetSecretAsync("test-secret").ConfigureAwait(false);

            Assert.AreEqual("secret-value", secret.Value);
            Assert.IsTrue(sawAuthorizedVaultRequest);
            Assert.IsNotNull(credential.LastRequestContext);
            Assert.IsFalse(credential.LastRequestContext.IsProofOfPossessionEnabled);
        }

        [Test]
        public async Task DoesNotRequestProofOfPossessionByDefault()
        {
            // SecretClientOptions.EnableProofOfPossession defaults to false so existing applications see no
            // change in authentication behavior, transport/connection-pooling behavior, or resource usage unless
            // they explicitly opt in.
            MockTransportBuilder builder = new MockTransportBuilder();
            MockTransport transport = builder.Build();
            MockCredential credential = new MockCredential(transport);
            SecretClient client = new SecretClient(
                VaultUri,
                credential,
                new SecretClientOptions
                {
                    Transport = transport,
                    // EnableProofOfPossession intentionally left unset.
                });

            KeyVaultSecret secret = await client.GetSecretAsync("test-secret").ConfigureAwait(false);

            Assert.AreEqual("secret-value", secret.Value);
            Assert.IsNotNull(credential.LastRequestContext);
            Assert.IsFalse(credential.LastRequestContext.IsProofOfPossessionEnabled);
        }

        [Test]
        public void DoesNotCreateDedicatedTransportByDefault()
        {
            // The dedicated, updatable (and therefore disposable) transport used for PoP token binding must only
            // be created when EnableProofOfPossession is set to true - otherwise every client construction would
            // lose the shared, pooled default transport regardless of whether PoP is ever used. Verified here by
            // checking the concrete pipeline type: HttpPipelineBuilder.Build only returns a DisposableHttpPipeline
            // from the overload that accepts HttpPipelineTransportOptions.
            SecretClient defaultClient = new SecretClient(VaultUri, new MockCredential(new MockTransportBuilder().Build()));
            Assert.IsNotInstanceOf<IDisposable>(GetPipeline(defaultClient), "No dedicated transport should be created when EnableProofOfPossession is not set.");

            SecretClient optedInClient = new SecretClient(
                VaultUri,
                new MockCredential(new MockTransportBuilder().Build()),
                new SecretClientOptions { EnableProofOfPossession = true });
            Assert.IsInstanceOf<IDisposable>(GetPipeline(optedInClient), "A dedicated, disposable transport should be created when EnableProofOfPossession is true.");

            static object GetPipeline(SecretClient client) =>
                typeof(SecretClient).GetField("_pipeline", BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(client)!;
        }

#if !NET462
        // CertificateRequest was introduced in .NET Framework 4.7.2 and .NET Core 2.0, so the two tests below
        // that construct a binding certificate are excluded from the net462 TFM.
        [Test]
        public void ThrowsWhenTransportCannotApplyBindingCertificate()
        {
            // SupportsProofOfPossession is a best-effort, type-based check that cannot always predict whether
            // HttpPipelineTransport.Update will actually succeed on the specific transport instance in use (e.g.
            // HttpClientTransport.Shared overrides Update but throws InvalidOperationException because the shared
            // instance can never be updated in place). ThrowingUpdateTransport simulates that exact failure mode.
            // The token is Proof-of-Possession bound but the certificate was never applied, so the SDK must fail
            // closed with a clear error instead of sending a request the service cannot authenticate.
            MockTransport transport = new MockTransportBuilder().Build();
            using X509Certificate2 bindingCertificate = CreateSelfSignedCertificate();
            string expectedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(TenantId));
            CallbackTokenCredential credential = new((context, _) =>
                new AccessToken(expectedToken, DateTimeOffset.UtcNow.AddMinutes(5), refreshOn: null, tokenType: "mtls_pop", bindingCertificate: bindingCertificate));

            SecretClient client = new SecretClient(
                VaultUri,
                credential,
                new SecretClientOptions
                {
                    Transport = new ThrowingUpdateTransport(transport),
                    EnableProofOfPossession = true,
                });

            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(
                async () => await client.GetSecretAsync("test-secret").ConfigureAwait(false));
            StringAssert.Contains("EnableProofOfPossession", ex.Message);
        }

        [Test]
        public void ThrowsWhenTransportDoesNotOverrideUpdateAndCredentialReturnsBindingCertificate()
        {
            // Defense in depth: if a credential returns a binding certificate on a transport that does not
            // override Update() at all (the HttpPipelineTransport base implementation throws NotSupportedException),
            // the SDK must still fail closed with a clear error rather than sending a bound token the service
            // cannot validate.
            MockTransport transport = new MockTransportBuilder().Build();
            using X509Certificate2 bindingCertificate = CreateSelfSignedCertificate();
            string expectedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(TenantId));
            CallbackTokenCredential credential = new((context, _) =>
                new AccessToken(expectedToken, DateTimeOffset.UtcNow.AddMinutes(5), refreshOn: null, tokenType: "mtls_pop", bindingCertificate: bindingCertificate));

            SecretClient client = new SecretClient(
                VaultUri,
                credential,
                new SecretClientOptions
                {
                    Transport = new NonUpdatingTransport(transport),
                    EnableProofOfPossession = true,
                });

            Assert.ThrowsAsync<InvalidOperationException>(
                async () => await client.GetSecretAsync("test-secret").ConfigureAwait(false));
        }

        private static X509Certificate2 CreateSelfSignedCertificate()
        {
            using RSA key = RSA.Create(2048);
            var request = new CertificateRequest(
                $"CN=ChallengeBasedAuthenticationPolicyTests-{Guid.NewGuid()}",
                key,
                HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1);
            return request.CreateSelfSigned(DateTimeOffset.UtcNow.AddMinutes(-5), DateTimeOffset.UtcNow.AddHours(1));
        }
#endif

        // Test concurrent authentication requests with immediate, fast, and slow network simulations.
        [TestCase(10, 0, 0)]
        [TestCase(10, 20, 200)]
        [TestCase(10, 200, 2000)]
        public async Task MultipleRequests(int numberOfRequests, int minDelay, int maxDelay)
        {
            Random rand = new Random();

            MockTransportBuilder builder = new MockTransportBuilder();
            builder.Request += async (sender, args) =>
            {
                int delay;
                lock (rand)
                {
                    delay = rand.Next(minDelay, maxDelay);
                }

                Trace.WriteLine($"[{Thread.CurrentThread.ManagedThreadId:x4}] Delaying request [{args.Request.ClientRequestId}] by {delay}ms: {args.Request.Method} {args.Request.Uri}");
                await Task.Delay(delay);
            };

            MockTransport transport = builder.Build();
            SecretClientOptions options = new SecretClientOptions
            {
                Transport = transport,
                //Diagnostics =
                //{
                //    // Headers and content are fake so no PII is leaked and this is useful for debugging.
                //    LoggedHeaderNames = { "*" },
                //    IsLoggingContentEnabled = true,
                //},
            };

            //using AzureEventSourceListener logger = AzureEventSourceListener.CreateTraceLogger(EventLevel.Verbose);
            SecretClient client = new SecretClient(VaultUri, new MockCredential(transport), options);

            Task<Response<KeyVaultSecret>>[] tasks = new Task<Response<KeyVaultSecret>>[numberOfRequests];
            for (int i = 0; i < tasks.Length; ++i)
            {
                tasks[i] = Task.Run(async () => await client.GetSecretAsync("test-secret").ConfigureAwait(false));
            }

            foreach (KeyVaultSecret secret in await Task.WhenAll(tasks))
            {
                Assert.AreEqual("secret-value", secret.Value);
            }
        }

        [Test]
        public async Task TenantChangedRequest()
        {
            MockTransportBuilder builder = new MockTransportBuilder
            {
                AccessTokenLifetime = TimeSpan.Zero,
            };
            MockTransport transport = builder.Build();

            SecretClientOptions options = new SecretClientOptions
            {
                Transport = transport,
            };

            MockCredential credential = new MockCredential(transport);

            SecretClient client = new SecretClient(VaultUri, credential, options);

            KeyVaultSecret secret = await client.GetSecretAsync("test-secret").ConfigureAwait(false);
            Assert.AreEqual("secret-value", secret.Value);

            builder.TenantId = "de763a21-49f7-4b08-a8e1-52c8fbc103b4";

            try
            {
                await client.GetSecretAsync("test-secret").ConfigureAwait(false);
                Assert.Fail("Expected a 401 Unauthorized response");
            }
            catch (RequestFailedException ex) when (ex.Status == 401)
            {
            }
        }

        [Test]
        public async Task ReauthenticatesWhenTenantChanged()
        {
            MockTransport transport = new(new[]
            {
                // Initial tenant.
                new MockResponse(401)
                    .WithHeader("WWW-Authenticate", @"Bearer authorization=""https://login.windows.net/de763a21-49f7-4b08-a8e1-52c8fbc103b4"", resource=""https://vault.azure.net"""),

                new MockResponse(200)
                    .WithJson("""
                    {
                        "token_type": "Bearer",
                        "expires_in": 3599,
                        "resource": "https://vault.azure.net",
                        "access_token": "ZGU3NjNhMjEtNDlmNy00YjA4LWE4ZTEtNTJjOGZiYzEwM2I0"
                    }
                    """),

                new MockResponse(200)
                {
                    ContentStream = new KeyVaultSecret("test-secret", "secret-value").ToStream(),
                },

                // Moved tenants.
                new MockResponse(401)
                    .WithHeader("WWW-Authenticate", @"Bearer authorization=""https://login.windows.net/72f988bf-86f1-41af-91ab-2d7cd011db47"", resource=""https://vault.azure.net""")
                    .WithJson("""
                    {
                        "error": {
                            "code": "Unauthorized",
                            "message": "AKV10032: Invalid issuer. Expected one of https://sts.windows.net/72f988bf-86f1-41af-91ab-2d7cd011db47/, https://sts.windows.net/f8cdef31-a31e-4b4a-93e4-5f571e91255a/, https://sts.windows.net/e2d54eb5-3869-4f70-8578-dee5fc7331f4/, https://sts.windows.net/33e01921-4d64-4f8c-a055-5bdaffd5e33d/, https://sts.windows.net/975f013f-7f24-47e8-a7d3-abc4752bf346/, found https://sts.windows.net/96be4b7a-defb-4dc2-a31f-49ee6145d5ab/."
                        }
                    }
                    """),

                new MockResponse(200)
                    .WithJson("""
                    {
                        "token_type": "Bearer",
                        "expires_in": 3599,
                        "resource": "https://vault.azure.net",
                        "access_token": "NzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3"
                    }
                    """),

                new MockResponse(200)
                {
                    ContentStream = new KeyVaultSecret("test-secret", "secret-value").ToStream(),
                },
            });

            SecretClientOptions options = new()
            {
                Transport = transport,
            };

            SecretClient client = new(
                VaultUri,
                new MockCredential(transport),
                options);

            Response<KeyVaultSecret> response = await client.GetSecretAsync("test-secret");
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("secret-value", response.Value.Value);

            // Try it again now that the vault should have moved tenants.
            response = await client.GetSecretAsync("test-secret");
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("secret-value", response.Value.Value);
        }

        [Test]
        public async Task DstsV2AuthorizationUriExtractsTenantId()
        {
            string expectedTenantId = "de763a21-49f7-4b08-a8e1-52c8fbc103b4";
            string dstsVaultHost = "test.foo.bar.core.windows.net";
            Uri dstsVaultUri = new Uri("https://" + dstsVaultHost);

            string capturedTenantId = null;

            MockTransport transport = new(new[]
            {
                new MockResponse(401)
                    .WithHeader("WWW-Authenticate", @"Bearer authorization=""https://uswest2-passive-dsts.dsts.core.windows.net/dstsv2/" + expectedTenantId + @""", resource=""https://foo.bar.core.windows.net"""),

                new MockResponse(200)
                {
                    ContentStream = new KeyVaultSecret("test-secret", "secret-value").ToStream(),
                },
            });

            var credential = new CallbackTokenCredential((r, c) =>
            {
                capturedTenantId = r.TenantId;
                return new AccessToken("test-token", DateTimeOffset.UtcNow.AddHours(1));
            });

            SecretClient client = new(
                dstsVaultUri,
                credential,
                new SecretClientOptions()
                {
                    Transport = transport,
                });

            Response<KeyVaultSecret> response = await client.GetSecretAsync("test-secret");
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("secret-value", response.Value.Value);
            Assert.AreEqual(expectedTenantId, capturedTenantId);
        }

        [Test]
        public void GetClaimsFromChallengeHeaders()
        {
            MockResponse response401WithClaims = new MockResponse(401)
                .WithHeader("WWW-Authenticate", @"Bearer realm="""", authorization_uri=""https://login.microsoftonline.com/common/oauth2/authorize"", error=""insufficient_claims"", claims=""eyJhY2Nlc3NfdG9rZW4iOnsiYWNycyI6eyJlc3NlbnRpYWwiOnRydWUsInZhbHVlIjoiY3AxIn19fQ==""");
            Assert.AreEqual(ChallengeBasedAuthenticationPolicy.getDecodedClaimsParameter("insufficient_claims", response401WithClaims), @"{""access_token"":{""acrs"":{""essential"":true,""value"":""cp1""}}}");

            MockResponse response401 = new MockResponse(401)
                    .WithHeader("WWW-Authenticate", @"Bearer authorization=""https://login.windows.net/de763a21-49f7-4b08-a8e1-52c8fbc103b4"", resource=""https://vault.azure.net""");
            Assert.IsNull(ChallengeBasedAuthenticationPolicy.getDecodedClaimsParameter(null, response401));
        }

        [Test]
        public async Task HandlesCaeChallengeWhenChallengeCacheIsEmpty()
        {
            // Regression: a CAE challenge (error="insufficient_claims") that arrives with no prior entry in the
            // static challenge cache must not dereference a null challenge. AuthorizeRequestOnChallenge previously
            // read _challenge.Scopes[0] immediately after a cache miss and threw NullReferenceException; it now
            // falls back to the scope parsed from the response and completes authorization normally.
            ChallengeBasedAuthenticationPolicy.ClearCache();

            MockTransport transport = new MockTransport(request =>
            {
                if (request.Headers.TryGetValue("Authorization", out _))
                {
                    return new MockResponse(200, "OK")
                    {
                        ContentStream = new KeyVaultSecret("test-secret", "secret-value").ToStream(),
                    };
                }

                MockResponse challenge = new MockResponse(401, "Unauthorized");
                challenge.AddHeader(new HttpHeader(
                    "WWW-Authenticate",
                    $@"Bearer authorization=""https://login.windows.net/{TenantId}"", resource=""https://vault.azure.net"", error=""insufficient_claims"", claims=""eyJhY2Nlc3NfdG9rZW4iOnsiYWNycyI6eyJlc3NlbnRpYWwiOnRydWUsInZhbHVlIjoiY3AxIn19fQ=="""));
                return challenge;
            });

            SecretClient client = new SecretClient(
                VaultUri,
                new CallbackTokenCredential((_, _) => new AccessToken("token", DateTimeOffset.UtcNow.AddMinutes(5))),
                new SecretClientOptions { Transport = transport });

            KeyVaultSecret secret = await client.GetSecretAsync("test-secret").ConfigureAwait(false);
            Assert.AreEqual("secret-value", secret.Value);
        }

        private class MockTransportBuilder
        {
            private const string AuthorizationHeader = "Authorization";
            private const string ChallengeHeader = "WWW-Authenticate";
            private static readonly Regex s_loginPath = new Regex(@"^\/(?<tenantId>[\w-]+)\/oauth2\/v2\.0\/token$", RegexOptions.CultureInvariant);

            public event EventHandler<MockRequestEventArgs> Request;

            public string AccessToken => Base64(TenantId);

            public TimeSpan AccessTokenLifetime { get; set; } = TimeSpan.FromMinutes(5);

            public string TenantId { get; set; } = ChallengeBasedAuthenticationPolicyTests.TenantId;

            public MockTransport Build() => new MockTransport(request =>
            {
                OnRequest(request);

                switch (request.Uri.Host)
                {
                    // Accept both a plain Bearer token and a PoP-bound token carrying the same access token value,
                    // so tests can simulate a credential that honored TokenRequestContext.IsProofOfPossessionEnabled.
                    case VaultHost when request.Headers.TryGetValue(AuthorizationHeader, out string headerValue) &&
                        (headerValue == $"Bearer {AccessToken}" || headerValue == $"PoP {AccessToken}" || headerValue == $"mtls_pop {AccessToken}"):
                        return new MockResponse(200, "OK")
                        {
                            ContentStream = new KeyVaultSecret("test-secret", "secret-value").ToStream(),
                        };

                    // Key Vault returns 401 with a challenge for an unauthorized access token.
                    case VaultHost:
                        MockResponse response = new MockResponse(401, "Unauthorized");
                        response.AddHeader(new HttpHeader(ChallengeHeader, @$"Bearer authorization=""https://login.windows.net/{TenantId}"", resource=""https://vault.azure.net"""));

                        return response;

                    case "login.windows.net" when s_loginPath.IsMatch(request.Uri.Path):
                        string tenantId = s_loginPath.Match(request.Uri.Path).Groups["tenantId"].Value;
                        string accessToken = Base64(tenantId);

                        AccessToken token = new AccessToken(accessToken, DateTimeOffset.UtcNow + AccessTokenLifetime);
                        return new MockResponse(200, "OK")
                        {
                            ContentStream = token.ToStream(),
                        };

                    default:
                        throw new AssertionException($"Unexpected request: {request}");
                }
            });

            private static string Base64(string value)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(value);
                return Convert.ToBase64String(buffer);
            }

            private void OnRequest(MockRequest request)
            {
                Request?.Invoke(this, new MockRequestEventArgs(request));
            }
        }

        private class MockRequestEventArgs : EventArgs
        {
            public MockRequestEventArgs(MockRequest request)
            {
                Request = request;
            }

            public MockRequest Request { get; }
        }

        private class NonUpdatingTransport : HttpPipelineTransport
        {
            private readonly MockTransport _inner;

            public NonUpdatingTransport(MockTransport inner)
            {
                _inner = inner;
            }

            public override Request CreateRequest() => _inner.CreateRequest();

            public override void Process(HttpMessage message) => _inner.Process(message);

            public override ValueTask ProcessAsync(HttpMessage message) => _inner.ProcessAsync(message);
        }

        /// <summary>
        /// Simulates <see cref="HttpClientTransport.Shared"/>: it overrides <see cref="Update"/> (so
        /// <see cref="ChallengeBasedAuthenticationPolicy.SupportsProofOfPossession"/> reports it as capable), but
        /// the update itself always fails, exactly like calling <c>Update</c> on the real shared instance does.
        /// </summary>
        private class ThrowingUpdateTransport : HttpPipelineTransport
        {
            private readonly MockTransport _inner;

            public ThrowingUpdateTransport(MockTransport inner)
            {
                _inner = inner;
            }

            public override Request CreateRequest() => _inner.CreateRequest();

            public override void Process(HttpMessage message) => _inner.Process(message);

            public override ValueTask ProcessAsync(HttpMessage message) => _inner.ProcessAsync(message);

            public override void Update(HttpPipelineTransportOptions options) =>
                throw new InvalidOperationException("Simulated: this transport cannot be updated in place.");
        }

        private class MockCredential : TokenCredential
        {
            private readonly HttpPipeline _pipeline;
            private readonly string _tenantId;
            private readonly string _clientId;
            private readonly string _clientSecret;
            private readonly string _tokenType;

            public MockCredential(MockTransport transport, string tenantId = TenantId, string clientId = "test_id", string clientSecret = "test_secret", string tokenType = "Bearer")
            {
                _pipeline = new HttpPipeline(transport);
                _tenantId = tenantId ?? throw new ArgumentNullException(nameof(tenantId));
                _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
                _clientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
                _tokenType = tokenType ?? throw new ArgumentNullException(nameof(tokenType));
            }

            public TokenRequestContext LastRequestContext { get; private set; }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) => GetTokenAsync(requestContext, cancellationToken).EnsureCompleted();

            public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                LastRequestContext = requestContext;

                Request request = _pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Headers.Add(HttpHeader.Common.FormUrlEncodedContentType);

                request.Uri.Reset(new Uri($"https://login.windows.net/{_tenantId}/oauth2/v2.0/token"));

                string body = $"response_type=token&grant_type=client_credentials&client_id={Uri.EscapeDataString(_clientId)}&client_secret={Uri.EscapeDataString(_clientSecret)}&scope={Uri.EscapeDataString(string.Join(" ", requestContext.Scopes))}";
                ReadOnlyMemory<byte> content = Encoding.UTF8.GetBytes(body).AsMemory();
                request.Content = RequestContent.Create(content);

                Response response = await _pipeline.SendRequestAsync(request, cancellationToken);
                if (response.Status == 200 || response.Status == 201)
                {
                    return await DeserializeAsync(response.ContentStream, _tokenType, cancellationToken);
                }

                throw new RequestFailedException(response.Status, response.ReasonPhrase);
            }

            private static async Task<AccessToken> DeserializeAsync(Stream content, string tokenType, CancellationToken cancellationToken)
            {
                using (JsonDocument json = await JsonDocument.ParseAsync(content, default, cancellationToken).ConfigureAwait(false))
                {
                    return Deserialize(json.RootElement, tokenType);
                }
            }

            private static AccessToken Deserialize(JsonElement json, string tokenType)
            {
                string accessToken = null;
                DateTimeOffset expiresOn = DateTimeOffset.MaxValue;

                foreach (JsonProperty prop in json.EnumerateObject())
                {
                    switch (prop.Name)
                    {
                        case "access_token":
                            accessToken = prop.Value.GetString();
                            break;

                        case "expires_in":
                            expiresOn = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(prop.Value.GetInt64());
                            break;
                    }
                }

                return new AccessToken(accessToken, expiresOn, null, tokenType);
            }
        }

        private class CallbackTokenCredential : TokenCredential
        {
            private readonly Func<TokenRequestContext, CancellationToken, AccessToken> _callback;

            public CallbackTokenCredential(Func<TokenRequestContext, CancellationToken, AccessToken> callback)
            {
                _callback = callback;
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => _callback(requestContext, cancellationToken);

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new ValueTask<AccessToken>(_callback(requestContext, cancellationToken));
        }
    }
}
