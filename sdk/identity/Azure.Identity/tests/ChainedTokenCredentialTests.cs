// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ChainedTokenCredentialTests : ClientTestBase
    {
        private CredentialPipeline _pipeline;

        public ChainedTokenCredentialTests(bool isAsync) : base(isAsync)
        { }

        public class MockException : Exception
        {
        }

        [SetUp]
        public void Setup()
        {
            _pipeline = new CredentialPipeline(new HttpPipeline(new MockTransport()), new ClientDiagnostics(new TokenCredentialOptions() { AuthorityHost = new Uri("https://a.b.com") }));
        }

        public class SimpleMockTokenCredential : TokenCredential
        {
            private readonly string _scope;
            private readonly string _token;
            private CredentialPipeline _pipeline;

            internal SimpleMockTokenCredential(string scope, string token, CredentialPipeline pipeline)
            {
                _scope = scope;
                _token = token;
                _pipeline = pipeline;
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                using var scope = _pipeline.StartGetTokenScope("ChainedTokenCredential.GetToken", requestContext);
                try
                {
                    return _scope == requestContext.Scopes[0] ? new AccessToken(_token, DateTimeOffset.MaxValue) : throw new CredentialUnavailableException("unavailable");
                }
                catch (Exception ex)
                {
                    scope.FailWrapAndThrow(ex);
                    return default;
                }
            }

            public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                using var scope = _pipeline.StartGetTokenScope("ChainedTokenCredential.GetToken", requestContext);
                await Task.CompletedTask;
                try
                {
                    return _scope == requestContext.Scopes[0] ? new AccessToken(_token, DateTimeOffset.MaxValue) : throw new CredentialUnavailableException("unavailable");
                }
                catch (Exception ex)
                {
                    scope.FailWrapAndThrow(ex);
                    return default;
                }
            }
        }

        public class ExceptionalMockTokenCredential : TokenCredential
        {
            private CredentialPipeline _pipeline;

            internal ExceptionalMockTokenCredential(CredentialPipeline pipeline)
            {
                _pipeline = pipeline;
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                using var scope = _pipeline.StartGetTokenScope("ChainedTokenCredential.GetToken", requestContext);
                scope.FailWrapAndThrow(new MockException());
                return default;
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                using var scope = _pipeline.StartGetTokenScope("ChainedTokenCredential.GetToken", requestContext);
                scope.FailWrapAndThrow(new MockException());
                return default;
            }
        }

        public class UnavailbleCredential : TokenCredential
        {
            private CredentialPipeline _pipeline;

            internal UnavailbleCredential(CredentialPipeline pipeline)
            {
                _pipeline = pipeline;
            }
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                using var scope = _pipeline.StartGetTokenScope("ChainedTokenCredential.GetToken", requestContext);
                scope.FailWrapAndThrow(new CredentialUnavailableException("unavailable"));
                return default;
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                using var scope = _pipeline.StartGetTokenScope("ChainedTokenCredential.GetToken", requestContext);
                scope.FailWrapAndThrow(new CredentialUnavailableException("unavailable"));
                return default;
            }
        }

        [Test]
        public void CtorInvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => new ChainedTokenCredential(null));

            Assert.Throws<ArgumentException>(() => new ChainedTokenCredential(Array.Empty<TokenCredential>()));

            Assert.Throws<ArgumentException>(() => new ChainedTokenCredential((TokenCredential)null));

            Assert.Throws<ArgumentException>(() => new ChainedTokenCredential(new TokenCredential[] { }));
        }

        [Test]
        public async Task CredentialSequenceValid()
        {
            var cred1 = new SimpleMockTokenCredential("scopeA", "tokenA", _pipeline);
            var cred2 = new SimpleMockTokenCredential("scopeB", "tokenB", _pipeline);
            var cred3 = new SimpleMockTokenCredential("scopeB", "NotToBeReturned", _pipeline);
            var cred4 = new SimpleMockTokenCredential("scopeC", "tokenC", _pipeline);
            var provider = InstrumentClient(new ChainedTokenCredential(cred1, cred2, cred3, cred4));

            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))

                Assert.That((await provider.GetTokenAsync(new TokenRequestContext(new string[] { "scopeA" }))).Token, Is.EqualTo("tokenA"));
            Assert.That((await provider.GetTokenAsync(new TokenRequestContext(new string[] { "scopeB" }))).Token, Is.EqualTo("tokenB"));
            Assert.That((await provider.GetTokenAsync(new TokenRequestContext(new string[] { "scopeC" }))).Token, Is.EqualTo("tokenC"));
            var ex = Assert.CatchAsync<AuthenticationFailedException>(async () => await provider.GetTokenAsync(new TokenRequestContext(new string[] { "ScopeD" })));

            Assert.That(ex.InnerException, Is.InstanceOf(typeof(AggregateException)));

            Assert.That(((AggregateException)ex.InnerException).InnerExceptions, Is.All.InstanceOf(typeof(CredentialUnavailableException)));
        }

        [Test]
        public async Task CredentialThrows()
        {
            var cred1 = new SimpleMockTokenCredential("scopeA", "tokenA", _pipeline);
            var cred2 = new ExceptionalMockTokenCredential(_pipeline);
            var cred3 = new SimpleMockTokenCredential("scopeB", "tokenB", _pipeline);
            var provider = InstrumentClient(new ChainedTokenCredential(cred1, cred2, cred3));

            Assert.That((await provider.GetTokenAsync(new TokenRequestContext(new string[] { "scopeA" }))).Token, Is.EqualTo("tokenA"));
            Assert.CatchAsync<AuthenticationFailedException>(async () => await provider.GetTokenAsync(new TokenRequestContext(new string[] { "ScopeB" })));
            Assert.CatchAsync<AuthenticationFailedException>(async () => await provider.GetTokenAsync(new TokenRequestContext(new string[] { "ScopeC" })));
        }

        [Test]
        public async Task AllCredentialSkipped()
        {
            var cred1 = new UnavailbleCredential(_pipeline);
            var cred2 = new UnavailbleCredential(_pipeline);

            var chain = InstrumentClient(new ChainedTokenCredential(cred1, cred2));

            var ex = Assert.CatchAsync<AuthenticationFailedException>(async () => await chain.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            Assert.That(ex.InnerException, Is.InstanceOf(typeof(AggregateException)));

            Assert.That(((AggregateException)ex.InnerException).InnerExceptions, Is.All.InstanceOf(typeof(CredentialUnavailableException)));

            await Task.CompletedTask;
        }
    }
}
