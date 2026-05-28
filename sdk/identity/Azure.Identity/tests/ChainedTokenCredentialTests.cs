// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using Azure.Core;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity.Tests.Mock;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using Azure.Core.Pipeline;

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
            _pipeline = new CredentialPipeline(new HttpPipeline(new MockTransport()), new ClientDiagnostics(new TokenCredentialOptions() { AuthorityHost = new Uri("https://a.b.com")}));
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

                Assert.AreEqual("tokenA", (await provider.GetTokenAsync(new TokenRequestContext(new string[] { "scopeA" }))).Token);
            Assert.AreEqual("tokenB", (await provider.GetTokenAsync(new TokenRequestContext(new string[] { "scopeB" }))).Token);
            Assert.AreEqual("tokenC", (await provider.GetTokenAsync(new TokenRequestContext(new string[] { "scopeC" }))).Token);
            var ex = Assert.CatchAsync<AuthenticationFailedException>(async () => await provider.GetTokenAsync(new TokenRequestContext(new string[] { "ScopeD" })));

            Assert.IsInstanceOf(typeof(AggregateException), ex.InnerException);

            CollectionAssert.AllItemsAreInstancesOfType(((AggregateException)ex.InnerException).InnerExceptions, typeof(CredentialUnavailableException));
        }

        [Test]
        public async Task CredentialThrows()
        {
            var cred1 = new SimpleMockTokenCredential("scopeA", "tokenA", _pipeline);
            var cred2 = new ExceptionalMockTokenCredential(_pipeline);
            var cred3 = new SimpleMockTokenCredential("scopeB", "tokenB", _pipeline);
            var provider = InstrumentClient(new ChainedTokenCredential(cred1, cred2, cred3));

            Assert.AreEqual("tokenA", (await provider.GetTokenAsync(new TokenRequestContext(new string[] { "scopeA" }))).Token);
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

            Assert.IsInstanceOf(typeof(AggregateException), ex.InnerException);

            CollectionAssert.AllItemsAreInstancesOfType(((AggregateException)ex.InnerException).InnerExceptions, typeof(CredentialUnavailableException));

            await Task.CompletedTask;
        }
    }
}
