// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Auth;

public class AuthenticationTokenProviderTests
{
    [Test]
    public void SampleUsage()
    {
        // usage for TokenProvider2 abstract type
        AuthenticationTokenProvider provider = new ClientCredentialTokenProvider("myClientId", "myClientSecret");
        var client = new FooClient(new Uri("http://localhost"), provider);
        client.Get();
    }

    [Test]
    public void SupportsNoServiceLevelAuth()
    {
        // usage for TokenProvider2 abstract type
        AuthenticationTokenProvider provider = new ClientCredentialTokenProvider("myClientId", "myClientSecret");
        var client = new NoAuthClient(new Uri("http://localhost"), provider);
        client.Get();
    }

    [Test]
    public void SupportsNoAuthAtOperationLevel()
    {
        // usage for TokenProvider2 abstract type
        AuthenticationTokenProvider provider = new ClientCredentialTokenProvider("myClientId", "myClientSecret");
        var client = new FooClient(new Uri("http://localhost"), provider);
        var result = client.GetNoAuth();
    }

    [Test]
    public void SupportsAuthAtOperationLevel()
    {
        // usage for TokenProvider2 abstract type
        AuthenticationTokenProvider provider = new ClientCredentialTokenProvider("myClientId", "myClientSecret");
        var client = new NoAuthClient(new Uri("http://localhost"), provider);
        var result = client.GetWithAuth();
    }

    public class FooClient
    {
        // Generated from the TypeSpec spec.

        private static readonly string readScope = "read";

        /// <summary>
        /// This is an example of how you can define the service level flows.
        /// The service level flows are used when the operation does not have its own flows defined.
        /// </summary>
        private readonly Dictionary<string, object>[] serviceFlows = [
            new Dictionary<string, object> {
                { GetTokenOptions.ScopesPropertyName, new string[] { "baselineScope" } },
                { GetTokenOptions.TokenUrlPropertyName , "https://myauthserver.com/token"},
                { GetTokenOptions.RefreshUrlPropertyName, "https://myauthserver.com/refresh"}
            }
        ];

        /// <summary>
        /// This is an example of how you can override the flows for a specific operation.
        /// The operation can have its own flows, or it can use the service level flows.
        /// </summary>
        private readonly Dictionary<string, object>[] getOperationsFlows = [
            new Dictionary<string, object> {
                { GetTokenOptions.ScopesPropertyName, new string[] { "baselineScope", readScope } },
                { GetTokenOptions.TokenUrlPropertyName , "https://myauthserver.com/token"},
                { GetTokenOptions.RefreshUrlPropertyName, "https://myauthserver.com/refresh"}
            }
        ];

        /// <summary>
        /// This is an example of how you can define a no-authentication flow.
        /// This flow can be used for operations that do not require authentication.
        /// It will override the service level flows and any operation specific flows.
        /// </summary>
        private readonly IReadOnlyDictionary<string, object>[] emptyFlows = [];

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

        public FooClient(Uri uri, AuthenticationTokenProvider credential)
        {
            var options = new ClientPipelineOptions();
            options.Transport = new MockPipelineTransport("foo",
            m =>
            {
                return new MockPipelineResponse(200);
            });
            ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: [new BearerTokenPolicy(credential, serviceFlows)],
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
            _pipeline = pipeline;
        }

        /// <summary>
        /// This operation uses its own authentication flows.
        /// It will override the service level flows and any operation specific flows.
        /// </summary>
        public ClientResult Get()
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier.Create([200]);
            message.SetProperty(typeof(GetTokenOptions), getOperationsFlows);

            PipelineRequest request = message.Request;
            request.Method = "GET";
            request.Uri = new Uri("https://localhost/foo");
            _pipeline.Send(message);
            return ClientResult.FromResponse(message.Response!);
        }

        /// <summary>
        /// This operation does not require authentication.
        /// It will override the service level flows by passing an empty array of flows.
        /// </summary>
        public ClientResult GetNoAuth()
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier.Create([200]);
            message.SetProperty(typeof(GetTokenOptions), emptyFlows);

            PipelineRequest request = message.Request;
            request.Method = "GET";
            request.Uri = new Uri("https://localhost/noAuth");
            _pipeline.Send(message);
            return ClientResult.FromResponse(message.Response!);
        }
    }

    public class NoAuthClient
    {
        private static readonly string readScope = "read";

        /// <summary>
        /// This is an example of how no-authentication flows are defined at the service level,
        /// by passing an empty array of flows.
        /// </summary>
        private readonly IReadOnlyDictionary<string, object>[] emptyServiceFlows = [];

        private ClientPipeline _pipeline;

        /// <summary>
        /// This is an example of how you can override the flows for a specific operation.
        /// The operation can have its own flows, or it can use the service level flows.
        /// </summary>
        private readonly Dictionary<string, object>[] getOperationsFlows = [
            new Dictionary<string, object> {
                { GetTokenOptions.ScopesPropertyName, new string[] { "baselineScope", readScope } },
                { GetTokenOptions.TokenUrlPropertyName , "https://myauthserver.com/token"},
                { GetTokenOptions.RefreshUrlPropertyName, "https://myauthserver.com/refresh"}
            }
        ];

        public NoAuthClient(Uri uri, ApiKeyCredential credential)
        {
            var options = new ClientPipelineOptions();
            options.Transport = new MockPipelineTransport("foo", m => new MockPipelineResponse(200));
            ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: [ApiKeyAuthenticationPolicy.CreateBasicAuthorizationPolicy(credential)],
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
            _pipeline = pipeline;
        }

        public NoAuthClient(Uri uri, AuthenticationTokenProvider credential)
        {
            var options = new ClientPipelineOptions();
            options.Transport = new MockPipelineTransport("foo",
            m =>
            {
                m.TryGetProperty(typeof(GetTokenOptions), out var flowsObj);
                if (
                    flowsObj == null ||
                    (flowsObj is IReadOnlyDictionary<string, object>[] flowsArr && flowsArr.Length == 0)
                )
                {
                    // Only assert no Authorization header if operation does not override the service level flows.
                    Assert.IsFalse(m.Request.Headers.TryGetValue("Authorization", out _), "Request should not have an Authorization header.");
                }
                else
                {
                    // If operation overrides service level flows, Authorization header should be present and populated.
                    Assert.IsTrue(m.Request.Headers.TryGetValue("Authorization", out var authHeader), "Request should have an Authorization header.");
                    Assert.IsNotNull(authHeader);
                    Assert.IsNotEmpty(authHeader);
                }
                return new MockPipelineResponse(200);
            });
            ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: [new BearerTokenPolicy(credential, emptyServiceFlows)],
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
            _pipeline = pipeline;
        }

        /// <summary>
        /// This operation does not require authentication and uses the service level flows defined with an empty array.
        /// </summary>
        public ClientResult Get()
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier.Create([200]);

            PipelineRequest request = message.Request;
            request.Method = "GET";
            request.Uri = new Uri("https://localhost/noAuth");
            _pipeline.Send(message);
            return ClientResult.FromResponse(message.Response!);
        }

        /// <summary>
        /// This operation requires authentication, even though the client does not have authentication flows defined at the service level.
        /// It will use the authentication flows defined at the operation level.
        /// </summary>
        public ClientResult GetWithAuth()
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier.Create([200]);
            message.SetProperty(typeof(GetTokenOptions), getOperationsFlows);
            PipelineRequest request = message.Request;
            request.Method = "GET";
            request.Uri = new Uri("https://localhost/foo");
            _pipeline.Send(message);
            return ClientResult.FromResponse(message.Response!);
        }
    }

    public class ClientCredentialTokenProvider : AuthenticationTokenProvider
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
                Assert.AreEqual(req.RequestUri?.ToString(), "https://myauthserver.com/token");
                // Extract the Authorization header
                var authHeader = req.Headers.Authorization;
                Assert.IsNotNull(authHeader, "Authorization header is missing");
                Assert.AreEqual("Basic", authHeader?.Scheme, "Authorization scheme should be 'Basic'");

                // Decode the Base64 parameter
                byte[] credentialBytes = Convert.FromBase64String(authHeader!.Parameter!);
                string decodedCredentials = Encoding.ASCII.GetString(credentialBytes);

                // Verify the decoded credentials
                Assert.AreEqual($"{_clientId}:{_clientSecret}", decodedCredentials, "Decoded credentials don't match expected values");

                // Validate form content
                var content = req?.Content?.ReadAsStringAsync().GetAwaiter().GetResult();
                Assert.That(content, Contains.Substring("grant_type=client_credentials"), "grant_type should be client_credentials");
                Assert.That(content, Contains.Substring("scope=baselineScope+read"), "scope should be baselineScope+read");

                return mockResponse;
            });

            // Create an HttpClient with the mock handler
            _client = new HttpClient(mockHandler);
        }

        public override AuthenticationToken GetToken(GetTokenOptions properties, CancellationToken cancellationToken)
        {
            return GetAccessTokenInternal(false, properties, cancellationToken).GetAwaiter().GetResult();
        }

        public override async ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions properties, CancellationToken cancellationToken)
        {
            return await GetAccessTokenInternal(true, properties, cancellationToken).ConfigureAwait(false);
        }

        public override GetTokenOptions? CreateTokenOptions(IReadOnlyDictionary<string, object> properties)
        {
            if (properties.TryGetValue(GetTokenOptions.ScopesPropertyName, out var scopes) && scopes is string[] scopeArray &&
                properties.TryGetValue(GetTokenOptions.TokenUrlPropertyName, out var tokenUri) && tokenUri is string tokenUriValue &&
                properties.TryGetValue(GetTokenOptions.RefreshUrlPropertyName, out var refreshUri) && refreshUri is string refreshUriValue)
            {
                return new GetTokenOptions(new Dictionary<string, object>
                {
                    { GetTokenOptions.ScopesPropertyName, new ReadOnlyMemory<string>(scopeArray) },
                    { GetTokenOptions.TokenUrlPropertyName, tokenUriValue },
                    { GetTokenOptions.RefreshUrlPropertyName, refreshUriValue }
                });
            }
            return null;
        }

        internal async ValueTask<AuthenticationToken> GetAccessTokenInternal(bool async, GetTokenOptions properties, CancellationToken cancellationToken)
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
            var scopes = ExtractScopes(properties.Properties);

            // Create form content
            var formContent = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("scope", string.Join(" ", scopes.ToArray()))
            ]);

            request.Content = formContent;

            using HttpResponseMessage response = async ?
                await _client.SendAsync(request) :
                _client.SendAsync(request).GetAwaiter().GetResult();

            response.EnsureSuccessStatusCode();

            // Deserialize the JSON response using System.Text.Json
            using var responseStream = await response.Content.ReadAsStreamAsync();
            using JsonDocument jsonDoc = await JsonDocument.ParseAsync(responseStream);
            JsonElement root = jsonDoc.RootElement;

            string? accessToken = root.GetProperty("access_token").GetString();
            string? tokenType = root.GetProperty("token_type").GetString();
            int expiresIn = root.GetProperty("expires_in").GetInt32();

            // Calculate expiration and refresh times based on current UTC time
            var now = DateTimeOffset.UtcNow;
            DateTimeOffset expiresOn = now.AddSeconds(expiresIn);
            DateTimeOffset refreshOn = now.AddSeconds(expiresIn * 0.85);

            return new AuthenticationToken(accessToken!, tokenType!, expiresOn, refreshOn);
        }

        private static ReadOnlyMemory<string> ExtractScopes(IReadOnlyDictionary<string, object> properties)
        {
            if (!properties.TryGetValue(GetTokenOptions.ScopesPropertyName, out var scopesValue) || scopesValue is null)
            {
                return ReadOnlyMemory<string>.Empty;
            }

            return scopesValue switch
            {
                ReadOnlyMemory<string> memory => memory,
                Memory<string> memory => memory,
                string[] array => new ReadOnlyMemory<string>(array),
                ICollection<string> collection => new ReadOnlyMemory<string>([.. collection]),
                IEnumerable<string> enumerable => new ReadOnlyMemory<string>([.. enumerable]),
                _ => ReadOnlyMemory<string>.Empty
            };
        }
    }

    public class ClientCredentialToken : AuthenticationToken
    {
        private AuthenticationTokenProvider _provider;
        private GetTokenOptions properties;

        public ClientCredentialToken(AuthenticationTokenProvider provider, GetTokenOptions properties, string tokenValue, string tokenType, DateTimeOffset expiresOn, DateTimeOffset? refreshOn = null)
            : base(tokenValue, tokenType, expiresOn, refreshOn)
        {
            _provider = provider;
            this.properties = properties;
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
