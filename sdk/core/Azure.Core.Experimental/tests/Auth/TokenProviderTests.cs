// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Auth;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Auth;

public class TokenProviderTests
{
    [Test]
    public void SampleUsage()
    {
        // usage for TokenProvider2 abstract type
        TokenProvider provider = new ClientCredentialTokenProvider("myClientId", "myClientSecret");
        var client = new FooClient(new Uri("http://localhost"), provider);
        client.Get();
    }

    public class FooClient
    {
        // Generated from the TypeSpec spec.
        private readonly Dictionary<string, object>[] flows = [
            new Dictionary<string, object> {
                { TokenFlowProperties.ScopesPropertyName, new string[] { "baselineScope" } },
                { TokenFlowProperties.TokenUrlPropertyName , "https://myauthserver.com/token"},
                { TokenFlowProperties.RefreshUrlPropertyName, "https://myauthserver.com/refresh"}
            }
        ];

        private readonly IReadOnlyDictionary<string, object> _emptyProperties = new Dictionary<string, object>();

        private ClientPipeline _pipeline;

        public FooClient(Uri uri, ApiKeyCredential credential)
        {
            var options = new ClientPipelineOptions();
            options.Transport = new MockPipelineTransport("foo", m => new MockPipelineResponse(200));
            ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: [ApiKeyAuthenticationPolicy.CreateBasicAuthorizationPolicy(credential)],
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
            _pipeline = pipeline;
        }

        public FooClient(Uri uri, TokenProvider credential)
        {
            var options = new ClientPipelineOptions();
            options.Transport = new MockPipelineTransport("foo",
            m =>
            {
                return new MockPipelineResponse(200);
            });
            ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: [new OAuth2BearerTokenAuthenticationPolicy(credential, flows)],
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
            _pipeline = pipeline;
        }

        public ClientResult Get()
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier.Create([200]);
            message.SetProperty(typeof(TokenFlowProperties), new TokenFlowProperties(["read"], _emptyProperties));

            PipelineRequest request = message.Request;
            request.Method = "GET";
            request.Uri = new Uri("https://localhost/foo");
            _pipeline.Send(message);
            return ClientResult.FromResponse(message.Response);
        }
    }

    public class ClientCredentialTokenProvider : TokenProvider
    {
        private string _clientId;
        private string _clientSecret;
        private HttpClient _client;

        // Create a mock token response
        private HttpResponseMessage mockResponse = new HttpResponseMessage(Net.HttpStatusCode.OK)
        {
            Content = new StringContent(
                """
{
    "access_token": "mock_token",
    "token_type": "Bearer",
    "expires_in": 3600
}
""", Encoding.UTF8, "application/json")
        };

        public ClientCredentialTokenProvider(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            // Create a mock handler that returns the predefined response
            var mockHandler = new MockHttpMessageHandler(req =>
            {
                Assert.AreEqual(req.RequestUri.ToString(), "https://myauthserver.com/token");
                // Extract the Authorization header
                var authHeader = req.Headers.Authorization;
                Assert.IsNotNull(authHeader, "Authorization header is missing");
                Assert.AreEqual("Basic", authHeader.Scheme, "Authorization scheme should be 'Basic'");

                // Decode the Base64 parameter
                byte[] credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                string decodedCredentials = Encoding.ASCII.GetString(credentialBytes);

                // Verify the decoded credentials
                Assert.AreEqual($"{_clientId}:{_clientSecret}", decodedCredentials, "Decoded credentials don't match expected values");

                return mockResponse;
            });

            // Create an HttpClient with the mock handler
            _client = new HttpClient(mockHandler);
        }

        public override Token GetToken(TokenFlowProperties properties, CancellationToken cancellationToken)
        {
            return GetAccessTokenInternal(false, properties, cancellationToken).GetAwaiter().GetResult();
        }

        public override async ValueTask<Token> GetTokenAsync(TokenFlowProperties properties, CancellationToken cancellationToken)
        {
            return await GetAccessTokenInternal(true, properties, cancellationToken).ConfigureAwait(false);
        }

        public override TokenFlowProperties CreateContext(IReadOnlyDictionary<string, object> properties)
        {
            if (properties.TryGetValue(TokenFlowProperties.ScopesPropertyName, out var scopes) && scopes is string[] scopeArray &&
                properties.TryGetValue(TokenFlowProperties.TokenUrlPropertyName, out var tokenUri) && tokenUri is string tokenUriValue &&
                properties.TryGetValue(TokenFlowProperties.RefreshUrlPropertyName, out var refreshUri) && refreshUri is string refreshUriValue)
            {
                return new TokenFlowProperties(scopeArray, new Dictionary<string, object>
                {
                    { TokenFlowProperties.TokenUrlPropertyName, tokenUriValue },
                    { TokenFlowProperties.RefreshUrlPropertyName, refreshUriValue }
                });
            }
            return null;
        }

        internal async ValueTask<Token> GetAccessTokenInternal(bool async, TokenFlowProperties properties, CancellationToken cancellationToken)
        {
            if (!properties.Properties.TryGetValue("tokenUrl", out var tokenUri) || tokenUri is not string tokenUriValue)
            {
                throw new ArgumentException("Argument properties did not contain the expected value 'tokenUrl'.", nameof(properties));
            }
            var request = new HttpRequestMessage(HttpMethod.Post, tokenUriValue);

            // Add Basic Authentication header
            var authBytes = System.Text.Encoding.ASCII.GetBytes($"{_clientId}:{_clientSecret}");
            var authHeader = Convert.ToBase64String(authBytes);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authHeader);

            // Create form content
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("scope", properties.Scopes[0])
            });

            request.Content = formContent;

            using HttpResponseMessage response = async ?
                await _client.SendAsync(request) :
                _client.SendAsync(request).GetAwaiter().GetResult();

            response.EnsureSuccessStatusCode();

            // Deserialize the JSON response using System.Text.Json
            using var responseStream = await response.Content.ReadAsStreamAsync();
            using JsonDocument jsonDoc = await JsonDocument.ParseAsync(responseStream);
            JsonElement root = jsonDoc.RootElement;

            string accessToken = root.GetProperty("access_token").GetString();
            string tokenType = root.GetProperty("token_type").GetString();
            int expiresIn = root.GetProperty("expires_in").GetInt32();

            // Calculate expiration and refresh times based on current UTC time
            var now = DateTimeOffset.UtcNow;
            DateTimeOffset expiresOn = now.AddSeconds(expiresIn);
            DateTimeOffset refreshOn = now.AddSeconds(expiresIn * 0.85);

            return new Token(accessToken, tokenType, expiresOn, refreshOn);
        }
    }

    public class ClientCredentialToken : RefreshableToken
    {
        private TokenProvider _provider;
        private TokenFlowProperties properties;

        public ClientCredentialToken(TokenProvider provider, TokenFlowProperties properties, string tokenValue, string tokenType, DateTimeOffset expiresOn, DateTimeOffset? refreshOn = null)
            : base(tokenValue, tokenType, expiresOn, refreshOn)
        {
            _provider = provider;
            this.properties = properties;
        }
        public override async Task RefreshAsync(CancellationToken cancellationToken)
        {
            var token = await _provider.GetTokenAsync(properties, cancellationToken);
            TokenValue = token.TokenValue;
            TokenType = token.TokenType;
            ExpiresOn = token.ExpiresOn;
            RefreshOn = token.RefreshOn;
        }
    }

    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _responseFactory;

        public MockHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> responseFactory)
        {
            _responseFactory = responseFactory;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_responseFactory(request));
        }
#if !NETFRAMEWORK
        protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _responseFactory(request);
        }
#endif
    }
}
