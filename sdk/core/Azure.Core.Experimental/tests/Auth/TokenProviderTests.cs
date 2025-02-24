// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Auth;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
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
    }

    public class FooClient
    {
        // Generated from the TypeSpec spec.
        private readonly IReadOnlyDictionary<string, object> context = new Dictionary<string, object> {
            { "scopes", new string[] { "myScope_from_spec" } },
            { "authorizationUrl" , "https://myAuthserver.com/token"} };

        private ClientPipeline _pipeline;

        public FooClient(Uri uri, ApiKeyCredential credential)
        {
            ClientPipeline pipeline = ClientPipeline.Create(new(),
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: [ApiKeyAuthenticationPolicy.CreateBasicAuthorizationPolicy(credential)],
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
            _pipeline = pipeline;
        }

        public FooClient(Uri uri, ITokenProvider credential)
        {
            ClientPipeline pipeline = ClientPipeline.Create(new(),
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: [new OAuth2BearerTokenAuthenticationPolicy(credential)],
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
            _pipeline = pipeline;
        }

        public ClientResult Get()
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
            message.SetProperty(typeof())

            PipelineRequest request = message.Request;
            request.Method = "GET";
            request.Uri = new Uri("http://localhost/foo");

        }
    }

    public class ClientCredentialTokenProvider : TokenProvider<IClientCredentialsFlowToken>
    {
        public override Token GetAccessToken(IClientCredentialsFlowToken context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<Token> GetAccessTokenAsync(IClientCredentialsFlowToken context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override IClientCredentialsFlowToken CreateContext(IReadOnlyDictionary<string, object> properties)
        {
            if (properties.TryGetValue("scopes", out var scopes) && scopes is string[] scopeArray &&
                properties.TryGetValue("tokenUri", out var tokenUri) && tokenUri is Uri tokenUriValue &&
                properties.TryGetValue("refreshUri", out var refreshUri) && refreshUri is Uri refreshUriValue)
            {
                return new ClientCredentialsContext(tokenUriValue, refreshUriValue, scopeArray);
            }
            throw new InvalidOperationException("All required properties were not present.");
        }
    }

    public struct ClientCredentialsContext(Uri tokenUri, Uri refreshUri, string[] scopes) : IClientCredentialsFlowToken
    {
        public string[] Scopes { get; } = scopes;

        public Uri TokenUri { get; } = tokenUri;

        public Uri RefreshUri { get; } = refreshUri;
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
