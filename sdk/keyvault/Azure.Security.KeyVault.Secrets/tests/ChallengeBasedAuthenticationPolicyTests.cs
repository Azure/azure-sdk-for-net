// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
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
        public void GetClaimsFromChallengeHeaders()
        {
            MockResponse response401WithClaims = new MockResponse(401)
                .WithHeader("WWW-Authenticate", @"Bearer realm="""", authorization_uri=""https://login.microsoftonline.com/common/oauth2/authorize"", error=""insufficient_claims"", claims=""eyJhY2Nlc3NfdG9rZW4iOnsiYWNycyI6eyJlc3NlbnRpYWwiOnRydWUsInZhbHVlIjoiY3AxIn19fQ==""");
            Assert.AreEqual(ChallengeBasedAuthenticationPolicy.getDecodedClaimsParameter("insufficient_claims", response401WithClaims), @"{""access_token"":{""acrs"":{""essential"":true,""value"":""cp1""}}}");

            MockResponse response401 = new MockResponse(401)
                    .WithHeader("WWW-Authenticate", @"Bearer authorization=""https://login.windows.net/de763a21-49f7-4b08-a8e1-52c8fbc103b4"", resource=""https://vault.azure.net""");
            Assert.IsNull(ChallengeBasedAuthenticationPolicy.getDecodedClaimsParameter(null, response401));
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
                    case VaultHost when request.Headers.TryGetValue(AuthorizationHeader, out string headerValue) && headerValue == $"Bearer {AccessToken}":
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

        private class MockCredential : TokenCredential
        {
            private readonly HttpPipeline _pipeline;
            private readonly string _tenantId;
            private readonly string _clientId;
            private readonly string _clientSecret;

            public MockCredential(MockTransport transport, string tenantId = TenantId, string clientId = "test_id", string clientSecret = "test_secret")
            {
                _pipeline = new HttpPipeline(transport);
                _tenantId = tenantId ?? throw new ArgumentNullException(nameof(tenantId));
                _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
                _clientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) => GetTokenAsync(requestContext, cancellationToken).EnsureCompleted();

            public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
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
                    return await DeserializeAsync(response.ContentStream, cancellationToken);
                }

                throw new RequestFailedException(response.Status, response.ReasonPhrase);
            }

            private static async Task<AccessToken> DeserializeAsync(Stream content, CancellationToken cancellationToken)
            {
                using (JsonDocument json = await JsonDocument.ParseAsync(content, default, cancellationToken).ConfigureAwait(false))
                {
                    return Deserialize(json.RootElement);
                }
            }

            private static AccessToken Deserialize(JsonElement json)
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

                return new AccessToken(accessToken, expiresOn);
            }
        }
    }
}
