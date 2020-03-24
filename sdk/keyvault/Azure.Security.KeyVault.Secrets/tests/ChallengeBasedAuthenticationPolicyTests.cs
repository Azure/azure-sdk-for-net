// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Tests
{
    public class ChallengeBasedAuthenticationPolicyTests
    {
        private const string TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
        private const string AccessToken = "NzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3"; // base64(TenantId)
        private const string VaultHost = "test.vault.azure.net";
        private static readonly Uri s_vaultUri = new Uri("https://" + VaultHost);

        [Test]
        public async Task SingleRequest()
        {
            MockTransport transport = new MockTransportBuilder().Build();
            SecretClientOptions options = new SecretClientOptions
            {
                Transport = transport,
                Diagnostics =
                {
                    LoggedHeaderNames = { "*" },
                    IsLoggingContentEnabled = true,
                },
            };

            using AzureEventSourceListener logger = AzureEventSourceListener.CreateTraceLogger(EventLevel.Verbose);
            SecretClient client = new SecretClient(s_vaultUri, new MockCredential(transport), options);

            KeyVaultSecret secret = await client.GetSecretAsync("test-secret").ConfigureAwait(false);
            Assert.AreEqual("secret-value", secret.Value);
        }

        [TestCase(10, 0, 0)]
        [TestCase(10, 0, 500)]
        public async Task MultipleRequests(int numberOfRequests, int minDelay, int maxDelay)
        {
            Random rand = new Random();

            MockTransportBuilder builder = new MockTransportBuilder();
            builder.Request += (sender, args) =>
            {
                int delay;
                lock (rand)
                {
                    delay = rand.Next(minDelay, maxDelay);
                }

                Thread.Sleep(delay);
            };

            MockTransport transport = builder.Build();
            SecretClientOptions options = new SecretClientOptions
            {
                Transport = transport,
                Diagnostics =
                {
                    LoggedHeaderNames = { "*" },
                    IsLoggingContentEnabled = true,
                },
            };

            using AzureEventSourceListener logger = AzureEventSourceListener.CreateTraceLogger(EventLevel.Verbose);
            SecretClient client = new SecretClient(s_vaultUri, new MockCredential(transport), options);

            Task<Response<KeyVaultSecret>>[] tasks = new Task<Response<KeyVaultSecret>>[numberOfRequests];
            for (int i = 0; i < tasks.Length; ++i)
            {
                tasks[i] = client.GetSecretAsync("test-secret");
            }

            await Task.WhenAll(tasks).ConfigureAwait(false);

            for (int i = 0; i < tasks.Length; ++i)
            {
                KeyVaultSecret secret = await tasks[i].ConfigureAwait(false);
                Assert.AreEqual("secret-value", secret.Value);
            }
        }

        private class MockTransportBuilder
        {
            private const string AuthorizationHeader = "Authorization";
            private const string ChallengeHeader = "WWW-Authenticate";
            private static readonly Regex s_loginPath = new Regex(@"^\/(?<tenantId>[\w-]+)\/oauth2\/v2\.0\/token$", RegexOptions.CultureInvariant);

            public event EventHandler<MockRequestEventArgs> Request;

            public MockTransport Build() => new MockTransport(request =>
            {
                OnRequest(request);

                switch (request.Uri.Host)
                {
                    case VaultHost when !request.Headers.TryGetValue(AuthorizationHeader, out _):
                        MockResponse response = new MockResponse(401, "Unauthorized");
                        response.AddHeader(new HttpHeader(ChallengeHeader, @$"Bearer authorization=""https://login.windows.net/{TenantId}"", resource=""https://vault.azure.net"""));

                        return response;

                    case VaultHost when request.Headers.TryGetValue(AuthorizationHeader, out string headerValue):
                        if (headerValue == $"Bearer {AccessToken}")
                        {
                            return new MockResponse(200, "OK")
                            {
                                ContentStream = new KeyVaultSecret("test-secret", "secret-value").ToStream(),
                            };
                        }

                        return new MockResponse(403, "Forbidden");

                    case "login.windows.net" when s_loginPath.IsMatch(request.Uri.Path):
                        string tenantId = s_loginPath.Match(request.Uri.Path).Groups["tenantId"].Value;
                        string accessToken = Base64(tenantId);

                        return new MockResponse(200, "OK")
                        {
                            ContentStream = new AccessToken(accessToken, DateTimeOffset.UtcNow.AddMinutes(5)).ToStream(),
                        };

                    default:
                        throw new AssertionException("Unexpected request");
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
