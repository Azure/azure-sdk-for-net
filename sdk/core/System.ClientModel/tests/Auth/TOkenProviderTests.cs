// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace System.ClientModel.Tests.Auth;

public class TokenProviderTests
{
    [Test]
    public void SampleUsage()
    {
        // usage for TokenProvider abstract type
        TokenProvider2<IScopedToken> provider = new ScopedTokenProvider<IScopedToken>();
        var client = new FooClient(new Uri("http://localhost"),  provider);

        // usage for TokenProvider2 abstract type
        ITokenProvider provider2 = new ScopedTokenProvider2();
        client = new FooClient(new Uri("http://localhost"),  provider);

        // usage for policy only and no public tokenProvider abstraction.
        var factory = new AuthenticationPolicyFactory();
        client = new FooClient(new Uri("http://localhost"), factory);
    }

    public class FooClient
    {
        public FooClient(Uri uri, ApiKeyCredential credential)
        {
            ClientPipeline pipeline = ClientPipeline.Create(new(),
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: [ApiKeyAuthenticationPolicy.CreateBasicAuthorizationPolicy(credential)],
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        }

        // Not ideal because the ctor must have a specific token provider type due to generic invariance.
        public FooClient(Uri uri, TokenProvider<IScopedToken> credential)
        {
            ClientPipeline pipeline = ClientPipeline.Create(new(),
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: [new ScopedAuthenticationPolicy((ITokenProvider)credential, "myScope")],
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        }

        public FooClient(Uri uri, ITokenProvider credential)
        {
            ClientPipeline pipeline = ClientPipeline.Create(new(),
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: [new ScopedAuthenticationPolicy(credential, "myScope")],
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        }

        // Generated from the TypeSpec spec.
        private readonly IReadOnlyDictionary<string, object> context = new Dictionary<string, object> {
            { "scopes", new string[] { "myScope_from_spec" } },
            { "authorizationUrl" , "https://myAuthserver.com/token"} };

        public FooClient(Uri uri, IOauthPolicyFactory authPolicyFactory)
        {
            ClientPipeline pipeline = ClientPipeline.Create(new(),
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: [authPolicyFactory.CreateAuthenticationPolicy(context)],
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        }
    }

    public class ScopedAuthenticationPolicy : OAuthPipelinePolicy
    {
        private TokenProvider<IScopedToken> _provider;
        private IScopedToken _context;
        private string[] _scopes;

        public ScopedAuthenticationPolicy(ITokenProvider provider, string scope)
        {
            _provider = (TokenProvider<IScopedToken>)provider;
            _scopes = [scope];
            _context = _provider.CreateContext(new Dictionary<string, object> { { "scopes", _scopes } });
        }

        public override Token GetToken(CancellationToken cancellationToken) =>
            _provider.GetAccessToken(_context, cancellationToken);

        public override ValueTask<Token> GetTokenAsync(CancellationToken cancellationToken) =>
            _provider.GetAccessTokenAsync(_context, cancellationToken);

        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            var token = _provider.GetAccessToken(_context, CancellationToken.None);
            // add token to authorization header
        }

        public async override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            var token = await _provider.GetAccessTokenAsync(_context, CancellationToken.None);
            // add token to authorization header
        }
    }

    // Azure.Identity: This is a simple example of a policy that uses a token provider to get a token with a scope.
    public class ScopedAuthenticationPolicy<TContext> : PipelinePolicy where TContext : IScopedToken
    {
        private TokenProvider<TContext> _provider;
        private TContext _context;
        private string[] _scopes;

        public ScopedAuthenticationPolicy(TokenProvider<TContext> provider, string scope)
        {
            _provider = provider;
            _scopes = [scope];
            _context = _provider.CreateContext(new Dictionary<string, object> { { "scopes", _scopes } });
        }

        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            var token = _provider.GetAccessToken(_context, CancellationToken.None);
        }

        public async override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            var token = await _provider.GetAccessTokenAsync(_context, CancellationToken.None);
        }
    }

    // Azure.Identity: This is a factory  that creates the appropriate policy based on the token provider.
    public class AuthenticationPolicyFactory : IOauthPolicyFactory
    {
        public OAuthPipelinePolicy CreateAuthenticationPolicy(IReadOnlyDictionary<string, object> context)
        {
            if (context.TryGetValue("scopes", out var scopes) && scopes is string[] scopeArray)
            {
                return new ScopedAuthenticationPolicy(new ScopedTokenProvider<IScopedToken>(), scopeArray[0]);
            }
            throw new InvalidOperationException("Provided context does not match with a known policy.");
        }
    }

    public struct ScopedContext : IScopedToken
    {
        public ScopedContext(string[] scopes)
        {
            Scopes = scopes;
        }
        public string[] Scopes { get; }
    }

    public class ScopedTokenProvider<TContext> : TokenProvider2<IScopedToken>
    {
        public override Token GetAccessToken(IScopedToken context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<Token> GetAccessTokenAsync(IScopedToken context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override IScopedToken CreateContext(IReadOnlyDictionary<string, object> properties)
        {
            if (properties.TryGetValue("scopes", out var scopes) && scopes is string[] scopeArray)
            {
                return new ScopedContext(scopeArray);
            }
            throw new InvalidOperationException("Scopes are required.");
        }
    }

    public class ScopedTokenProvider2 : TokenProvider2<IScopedToken>
    {
        public override Token GetAccessToken(IScopedToken context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<Token> GetAccessTokenAsync(IScopedToken context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override IScopedToken CreateContext(IReadOnlyDictionary<string, object> properties)
        {
            if (properties.TryGetValue("scopes", out var scopes) && scopes is string[] scopeArray)
            {
                return new ScopedContext(scopeArray);
            }
            throw new InvalidOperationException("Scopes are required.");
        }
    }

    // This is a simple example of a policy that uses a token provider to get a token with a scope and claims.

    public class ScopedClaimsAuthenticationPolicy<TContext> : PipelinePolicy
        where TContext : IScopedToken, IClaimsToken
    {
        private TokenProvider<TContext> _provider;
        private TContext _context;
        private string[] _scopes;

        /// <summary>
        /// Creates a new instance of <see cref="BearerTokenAuthenticationPolicy"/> using provided token credential and scope to authenticate for.
        /// </summary>
        /// <param name="credential">The token credential to use for authentication.</param>
        /// <param name="scope">The scope to be included in acquired tokens.</param>
        public ScopedClaimsAuthenticationPolicy(TokenProvider<TContext> provider, string scope)
        {
            _provider = provider;
            _scopes = [scope];
            _context = _provider.CreateContext(new Dictionary<string, object> { { "scopes", _scopes } });
        }

        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            var token = _provider.GetAccessToken(_context, CancellationToken.None);
        }

        public async override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            var token = await _provider.GetAccessTokenAsync(_context, CancellationToken.None);
        }
    }

    public struct ScopedWithClaimsContext : IScopedToken, IClaimsToken
    {
        public ScopedWithClaimsContext(string[] scopes, string claims)
        {
            Scopes = scopes;
            Claims = claims;
        }
        public string[] Scopes { get; }

        public string Claims { get; }
    }

    public class ScopedWithClaimsTokenProvider<TContext> : TokenProvider<TContext> where TContext : IScopedToken, IClaimsToken
    {
        public override Token GetAccessToken(TContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<Token> GetAccessTokenAsync(TContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override TContext CreateContext(IReadOnlyDictionary<string, object> properties)
        {
            if (properties.TryGetValue("scopes", out var scopes) && properties.TryGetValue("claims", out var claims) && scopes is string[] scopeArray && claims is string claimsString)
            {
                return (TContext)(IScopedToken)new ScopedWithClaimsContext(scopeArray, claimsString);
            }
            throw new InvalidOperationException("Scopes and claims are required.");
        }
    }
}
