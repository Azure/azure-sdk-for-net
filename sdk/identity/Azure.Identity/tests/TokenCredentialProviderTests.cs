// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using Azure.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity.Tests
{
    public class TokenCredentialProviderTests
    {
        public class MockException : Exception
        {

        }

        public class SimpleMockTokenCredential : TokenCredential
        {
            private readonly string _scope;
            private readonly string _token;

            public SimpleMockTokenCredential(string scope, string token)
            {
                _scope = scope;
                _token = token;
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return _scope == requestContext.Scopes[0] ? new AccessToken(_token, DateTimeOffset.MaxValue) : default;
            }

            public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                await Task.CompletedTask;

                return _scope == requestContext.Scopes[0] ? new AccessToken(_token, DateTimeOffset.MaxValue) : default;
            }
        }

        public class ExceptionalMockTokenCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                throw new MockException();
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                throw new MockException();
            }
        }

        [Test]
        public void CtorInvalidInput()
        {
            Assert.Throws<ArgumentException>(() => new ChainedTokenCredential(null));

            Assert.Throws<ArgumentException>(() => new ChainedTokenCredential((TokenCredential)null));

            Assert.Throws<ArgumentException>(() => new ChainedTokenCredential());

            Assert.Throws<ArgumentException>(() => new ChainedTokenCredential(new TokenCredential[] { }));
        }

        [Test]
        public async Task CredentialSequenceValid()
        {
            var cred1 = new SimpleMockTokenCredential("scopeA", "tokenA");
            var cred2 = new SimpleMockTokenCredential("scopeB", "tokenB");
            var cred3 = new SimpleMockTokenCredential("scopeB", "NotToBeReturned");
            var cred4 = new SimpleMockTokenCredential("scopeC", "tokenC");
            var provider = new ChainedTokenCredential(cred1, cred2, cred3, cred4);

            Assert.AreEqual("tokenA", (await provider.GetTokenAsync(new TokenRequestContext(new string[] { "scopeA" }))).Token);
            Assert.AreEqual("tokenB", (await provider.GetTokenAsync(new TokenRequestContext(new string[] { "scopeB" }))).Token);
            Assert.AreEqual("tokenC", (await provider.GetTokenAsync(new TokenRequestContext(new string[] { "scopeC" }))).Token);
            Assert.IsNull((await provider.GetTokenAsync(new TokenRequestContext(new string[] { "scopeD" }))).Token);
        }

        [Test]
        public async Task CredentialThrows()
        {
            var cred1 = new SimpleMockTokenCredential("scopeA", "tokenA");
            var cred2 = new ExceptionalMockTokenCredential();
            var cred3 = new SimpleMockTokenCredential("scopeB", "tokenB");
            var provider = new ChainedTokenCredential(cred1, cred2, cred3);

            Assert.AreEqual("tokenA", (await provider.GetTokenAsync(new TokenRequestContext(new string[] { "scopeA" }))).Token);
            Assert.ThrowsAsync<MockException>(async () => await provider.GetTokenAsync(new TokenRequestContext(new string[] { "ScopeB" })));
            Assert.ThrowsAsync<MockException>(async () => await provider.GetTokenAsync(new TokenRequestContext(new string[] { "ScopeC" })));
        }
    }
}
