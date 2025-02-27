// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Auth;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Auth;

public class TokenProviderTests
{
    [Test]
    public void SampleUsage()
    {
        // usage for TokenProvider2 abstract type
        ITokenProvider provider = new ClientCredentialTokenProvider();
        var client = new FooClient(new Uri("http://localhost"), provider);
        client.Get();
    }

    public class FooClient
    {
        // Generated from the TypeSpec spec.
        private readonly Dictionary<string, object>[] flows = [
            new Dictionary<string, object> {
                { "scopes", new string[] { "baselineScope" } },
                { "tokenUrl" , new Uri("https://myAuthserver.com/token")},
                { "refreshUrl" , new Uri("https://myAuthserver.com/refresh")}
            }
        ];

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

        public FooClient(Uri uri, ITokenProvider credential)
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
            message.ResponseClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
            message.SetProperty(typeof(IScopedFlowToken), new ScopedContext(["read"]));

            PipelineRequest request = message.Request;
            request.Method = "GET";
            request.Uri = new Uri("http://localhost/foo");
            _pipeline.Send(message);
            return ClientResult.FromResponse(message.Response);
        }
    }

    internal struct ScopedContext : IScopedFlowToken
    {
        public string[] Scopes { get; }

        public ScopedContext(string[] scopes)
        {
            Scopes = scopes;
        }

        public object CloneWithAdditionalScopes(string[] additionalScopes)
        {
            return new ScopedContext([.. Scopes, .. additionalScopes]);
        }
    }

    public class ClientCredentialTokenProvider : TokenProvider<IClientCredentialsFlowToken>
    {
        public override Token GetAccessToken(IClientCredentialsFlowToken context, CancellationToken cancellationToken)
        {
            return new Token("token", "Bearer", DateTimeOffset.UtcNow.AddHours(1));
        }

        public override ValueTask<Token> GetAccessTokenAsync(IClientCredentialsFlowToken context, CancellationToken cancellationToken)
        {
            return new ValueTask<Token>(new Token("token", "Bearer", DateTimeOffset.UtcNow.AddHours(1)));
        }

        public override IClientCredentialsFlowToken CreateContext(IReadOnlyDictionary<string, object> properties)
        {
            if (properties.TryGetValue("scopes", out var scopes) && scopes is string[] scopeArray &&
                properties.TryGetValue("tokenUrl", out var tokenUri) && tokenUri is Uri tokenUriValue &&
                properties.TryGetValue("refreshUrl", out var refreshUri) && refreshUri is Uri refreshUriValue)
            {
                return new ClientCredentialsContext(tokenUriValue, refreshUriValue, scopeArray);
            }
            return null;
        }
    }

    public struct ClientCredentialsContext(Uri tokenUri, Uri refreshUri, string[] scopes) : IClientCredentialsFlowToken
    {
        public string[] Scopes { get; } = scopes;

        public Uri TokenUri { get; } = tokenUri;

        public Uri RefreshUri { get; } = refreshUri;

        public object CloneWithAdditionalScopes(string[] additionalScopes)
        {
            return new ClientCredentialsContext(TokenUri, RefreshUri, [.. Scopes, .. additionalScopes]);
        }
    }

    public class ClientCredentialToken : RefreshableToken
    {
        private TokenProvider<IClientCredentialsFlowToken> _provider;
        private IClientCredentialsFlowToken _context;

        public ClientCredentialToken(TokenProvider<IClientCredentialsFlowToken> provider, IClientCredentialsFlowToken context, string tokenValue, string tokenType, DateTimeOffset expiresOn, DateTimeOffset? refreshOn = null)
            : base(tokenValue, tokenType, expiresOn, refreshOn)
        {
            _provider = provider;
            _context = context;
        }
        public override async Task RefreshAsync(CancellationToken cancellationToken)
        {
            var token = await _provider.GetAccessTokenAsync(_context, cancellationToken);
            TokenValue = token.TokenValue;
            TokenType = token.TokenType;
            ExpiresOn = token.ExpiresOn;
            RefreshOn = token.RefreshOn;
        }
    }
}
