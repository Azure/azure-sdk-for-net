// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Identity;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Pipeline;

public class BearerTokenPolicyTests : SyncAsyncTestBase
{
    public BearerTokenPolicyTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task BearerTokenPolicyWithEmptyContextsAndNoMessageProperty()
    {
        // Arrange
        var tokenProvider = new MockAuthenticationTokenProvider();
        var policy = new BearerTokenPolicy(tokenProvider, Array.Empty<IReadOnlyDictionary<string, object>>());

        ClientPipeline pipeline = CreatePipelineWithPolicy(policy);

        // Act
        var message = await SendMessageAsync(pipeline);

        // Assert
        AssertNoAuthorization(message, tokenProvider);
    }

    [Test]
    public async Task BearerTokenPolicyWithPopulatedContextsAndNoMessageProperty()
    {
        // Arrange
        var tokenProvider = new MockAuthenticationTokenProvider();
        var contexts = CreateContexts("test-scope");
        var policy = new BearerTokenPolicy(tokenProvider, contexts);
        var pipeline = CreatePipelineWithPolicy(policy);

        // Act
        var message = await SendMessageAsync(pipeline);

        // Assert
        AssertHasAuthorization(message);
        AssertTokenProviderCalled(tokenProvider, shouldCallAsync: true);
    }

    [Test]
    public async Task BearerTokenPolicyWithEmptyContextsAndMessagePropertySet()
    {
        // Arrange
        var tokenProvider = new MockAuthenticationTokenProvider();
        var policy = new BearerTokenPolicy(tokenProvider, Array.Empty<IReadOnlyDictionary<string, object>>());
        var messageContexts = CreateContexts("message-scope");
        var pipeline = CreatePipelineWithPolicy(policy);

        // Act
        var message = await SendMessageAsync(pipeline, messageContexts);

        // Assert
        AssertHasAuthorization(message);
        AssertTokenProviderCalled(tokenProvider, shouldCallAsync: true);
    }

    [Test]
    public async Task BearerTokenPolicyWithPopulatedContextsAndMessagePropertySet()
    {
        // Arrange
        var tokenProvider = new MockAuthenticationTokenProvider();
        var serviceContexts = CreateContexts("service-scope");
        var policy = new BearerTokenPolicy(tokenProvider, serviceContexts);
        var messageContexts = CreateContexts("message-scope");
        var pipeline = CreatePipelineWithPolicy(policy);

        // Act
        var message = await SendMessageAsync(pipeline, messageContexts);

        AssertHasAuthorization(message);
        AssertTokenProviderCalled(tokenProvider, shouldCallAsync: true);
    }

    [Test]
    public async Task BearerTokenPolicyWithPopulatedContextsTokenCredential()
    {
        // Arrange
        var tokenProvider = new MockTokenCredential();
        var serviceContexts = new Dictionary<string, object>[]
        {
            new Dictionary<string, object>
            {
                { GetTokenOptions.ScopesPropertyName, new string[] { "https://ai.azure.com/.default" } },
                { "parentRequestId", "parentRequestIdValue" },
                { "claims", "claimsValue"},
                { "tenantId", "tenantIdValue" },
                { "isCaeEnabled", true },
                { "isProofOfPossessionEnabled", true },
                { "proofOfPossessionNonce", "proofOfPossessionNonceValue" },
                { "requestUri", new Uri("https://example.com") },
                { "requestMethod", "requestMethodValue" }
            }
        };
        var policy = new BearerTokenPolicy(tokenProvider, serviceContexts);
        var pipeline = CreatePipelineWithPolicy(policy);

        // Act
        var message = await SendMessageAsync(pipeline);

        AssertHasAuthorization(message);
        AssertTokenProviderCalled(tokenProvider, shouldCallAsync: true);
        Assert.AreEqual("parentRequestIdValue", tokenProvider.ReceivedRequestContext.ParentRequestId);
        Assert.AreEqual("claimsValue", tokenProvider.ReceivedRequestContext.Claims);
        Assert.AreEqual("tenantIdValue", tokenProvider.ReceivedRequestContext.TenantId);
        Assert.AreEqual(true, tokenProvider.ReceivedRequestContext.IsCaeEnabled);
        Assert.AreEqual(true, tokenProvider.ReceivedRequestContext.IsProofOfPossessionEnabled);
        Assert.AreEqual("proofOfPossessionNonceValue", tokenProvider.ReceivedRequestContext.ProofOfPossessionNonce);
        Assert.AreEqual(new Uri("https://example.com"), tokenProvider.ReceivedRequestContext.ResourceRequestUri);
        Assert.AreEqual("requestMethodValue", tokenProvider.ReceivedRequestContext.ResourceRequestMethod);
    }

    [Test]
    public async Task BearerTokenPolicyWithPopulatedContextsTokenCredentialRomScopes()
    {
        // Arrange
        var tokenProvider = new MockTokenCredential();
        var serviceContexts = new Dictionary<string, object>[]
        {
            new Dictionary<string, object>
            {
                { GetTokenOptions.ScopesPropertyName, new ReadOnlyMemory<string>( ["https://ai.azure.com/.default"]) },
                { "parentRequestId", "parentRequestIdValue" },
                { "claims", "claimsValue"},
                { "tenantId", "tenantIdValue" },
                { "isCaeEnabled", true },
                { "isProofOfPossessionEnabled", true },
                { "proofOfPossessionNonce", "proofOfPossessionNonceValue" },
                { "requestUri", new Uri("https://example.com") },
                { "requestMethod", "requestMethodValue" }
            }
        };
        var policy = new BearerTokenPolicy(tokenProvider, serviceContexts);
        var pipeline = CreatePipelineWithPolicy(policy);

        // Act
        var message = await SendMessageAsync(pipeline);

        AssertHasAuthorization(message);
        AssertTokenProviderCalled(tokenProvider, shouldCallAsync: true);
        Assert.AreEqual("parentRequestIdValue", tokenProvider.ReceivedRequestContext.ParentRequestId);
        Assert.AreEqual("claimsValue", tokenProvider.ReceivedRequestContext.Claims);
        Assert.AreEqual("tenantIdValue", tokenProvider.ReceivedRequestContext.TenantId);
        Assert.AreEqual(true, tokenProvider.ReceivedRequestContext.IsCaeEnabled);
        Assert.AreEqual(true, tokenProvider.ReceivedRequestContext.IsProofOfPossessionEnabled);
        Assert.AreEqual("proofOfPossessionNonceValue", tokenProvider.ReceivedRequestContext.ProofOfPossessionNonce);
        Assert.AreEqual(new Uri("https://example.com"), tokenProvider.ReceivedRequestContext.ResourceRequestUri);
        Assert.AreEqual("requestMethodValue", tokenProvider.ReceivedRequestContext.ResourceRequestMethod);
    }

    [Test]
    public async Task BearerTokenPolicyWithNoScopesTokenCredential()
    {
        // Arrange
        var tokenProvider = new MockTokenCredential();
        var serviceContexts = new Dictionary<string, object>[]
        {
            new Dictionary<string, object>
            {
                { "parentRequestId", "parentRequestIdValue" },
                { "claims", "claimsValue"},
                { "tenantId", "tenantIdValue" },
                { "isCaeEnabled", true },
                { "isProofOfPossessionEnabled", true },
                { "proofOfPossessionNonce", "proofOfPossessionNonceValue" },
                { "requestUri", new Uri("https://example.com") },
                { "requestMethod", "requestMethodValue" }
            }
        };
        var policy = new BearerTokenPolicy(tokenProvider, serviceContexts);
        var pipeline = CreatePipelineWithPolicy(policy);

        // Act
        var message = await SendMessageAsync(pipeline);

         Assert.IsFalse(message.Request.Headers.TryGetValue("Authorization", out var authHeader));
    }

    [Test]
    public async Task BearerTokenPolicyWithNullTokenFromProvider()
    {
        // Arrange
        var tokenProvider = new MockAuthenticationTokenProvider(returnNull: true);
        var contexts = CreateContexts("test-scope");
        var policy = new BearerTokenPolicy(tokenProvider, contexts);
        var pipeline = CreatePipelineWithPolicy(policy);

        // Act
        var message = await SendMessageAsync(pipeline);

        // Assert - no authorization header should be set when token is null
        Assert.IsFalse(message.Request.Headers.TryGetValue("Authorization", out _));
    }

    [Test]
    public void BearerTokenPolicyThrowsForNonHttpsUrls()
    {
        // Arrange
        var tokenProvider = new MockAuthenticationTokenProvider();
        var contexts = CreateContexts("test-scope");
        var policy = new BearerTokenPolicy(tokenProvider, contexts);
        var pipeline = CreatePipelineWithPolicy(policy);

        // Act & Assert
        var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await SendMessageAsync(pipeline, uri: "http://example.com"));

        Assert.That(ex!.Message, Contains.Substring("Bearer token authentication is not permitted for non TLS protected (https) endpoints"));
    }

    [Test]
    public async Task BearerTokenPolicyWithScopeConstructor()
    {
        // Arrange
        var tokenProvider = new MockAuthenticationTokenProvider();
        var policy = new BearerTokenPolicy(tokenProvider, "test-scope");
        var pipeline = CreatePipelineWithPolicy(policy);

        // Act
        var message = await SendMessageAsync(pipeline);

        // Assert
        AssertHasAuthorization(message);
        AssertTokenProviderCalled(tokenProvider, shouldCallAsync: true);
    }

    private class MockAuthenticationTokenProvider : AuthenticationTokenProvider
    {
        private readonly bool _returnNull;
        public bool GetTokenCalled { get; private set; }
        public bool GetTokenAsyncCalled { get; private set; }
        public bool CreateTokenOptionsCalled { get; private set; }

        public MockAuthenticationTokenProvider(bool returnNull = false)
        {
            _returnNull = returnNull;
        }

        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
        {
            GetTokenCalled = true;
            return _returnNull ? null! : new AuthenticationToken("mock_token_value", "Bearer", DateTimeOffset.UtcNow.AddHours(1));
        }

        public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
        {
            GetTokenAsyncCalled = true;
            var token = _returnNull ? null! : new AuthenticationToken("mock_token_value", "Bearer", DateTimeOffset.UtcNow.AddHours(1));
            return new ValueTask<AuthenticationToken>(token);
        }

        public override GetTokenOptions? CreateTokenOptions(IReadOnlyDictionary<string, object> properties)
        {
            CreateTokenOptionsCalled = true;
            if (properties.TryGetValue(GetTokenOptions.ScopesPropertyName, out var scopes))
            {
                return new GetTokenOptions(properties);
            }
            return null;
        }
    }

    private class MockTokenCredential : TokenCredential
    {
        private readonly bool _returnNull;
        public bool GetTokenCalled { get; private set; }
        public bool GetTokenAsyncCalled { get; private set; }
        public bool CreateTokenOptionsCalled { get; private set; }
        public TokenRequestContext ReceivedRequestContext { get; private set; }

        public MockTokenCredential(bool returnNull = false)
        {
            _returnNull = returnNull;
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            GetTokenAsyncCalled = true;
            ReceivedRequestContext = requestContext;
            return new ValueTask<AccessToken>(new AccessToken("mock_token_value", DateTimeOffset.UtcNow.AddHours(1)));
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            GetTokenCalled = true;
            ReceivedRequestContext = requestContext;
            return new AccessToken("mock_token_value", DateTimeOffset.UtcNow.AddHours(1));
        }
    }

    private static IReadOnlyDictionary<string, object> CreateContext(string scope)
    {
        return new Dictionary<string, object>
        {
            { GetTokenOptions.ScopesPropertyName, new string[] { scope } }
        };
    }

    private static List<IReadOnlyDictionary<string, object>> CreateContexts(params string[] scopes)
    {
        return scopes.Select(CreateContext).ToList();
    }

    private ClientPipeline CreatePipelineWithPolicy(PipelinePolicy policy)
    {
        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", new int[] { 200 })
        };

        return ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: new PipelinePolicy[] { policy },
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
    }

    private async Task<PipelineMessage> SendMessageAsync(ClientPipeline pipeline, IEnumerable<IReadOnlyDictionary<string, object>>? messageContexts = null, string uri = "https://example.com")
    {
        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Uri = new Uri(uri);

        if (messageContexts != null)
        {
            message.SetProperty(typeof(GetTokenOptions), messageContexts);
        }

        await pipeline.SendSyncOrAsync(message, IsAsync);
        return message;
    }

    private static void AssertNoAuthorization(PipelineMessage message, MockAuthenticationTokenProvider tokenProvider)
    {
        Assert.IsFalse(message.Request.Headers.TryGetValue("Authorization", out _));
        Assert.IsFalse(tokenProvider.GetTokenCalled);
        Assert.IsFalse(tokenProvider.GetTokenAsyncCalled);
    }

    private static void AssertHasAuthorization(PipelineMessage message, string expectedToken = "Bearer mock_token_value")
    {
        Assert.IsTrue(message.Request.Headers.TryGetValue("Authorization", out var authHeader));
        Assert.AreEqual(expectedToken, authHeader);
    }

    private void AssertTokenProviderCalled(MockAuthenticationTokenProvider tokenProvider, bool shouldCallAsync)
    {
        if (shouldCallAsync && IsAsync)
        {
            Assert.IsTrue(tokenProvider.GetTokenAsyncCalled);
        }
        else
        {
            Assert.IsTrue(tokenProvider.GetTokenCalled);
        }
    }

    private void AssertTokenProviderCalled(MockTokenCredential tokenProvider, bool shouldCallAsync)
    {
        if (shouldCallAsync && IsAsync)
        {
            Assert.IsTrue(tokenProvider.GetTokenAsyncCalled);
        }
        else
        {
            Assert.IsTrue(tokenProvider.GetTokenCalled);
        }
    }
}
