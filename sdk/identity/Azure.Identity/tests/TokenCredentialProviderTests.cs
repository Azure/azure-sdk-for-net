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
            private string _scope;
            private string _token;
            private ValueTask<string> _tokenTask;

            public SimpleMockTokenCredential(string scope, string token)
            {
                _scope = scope;
                _token = token;
                _tokenTask = new ValueTask<string>(token);
            }

            public override string GetToken(string[] scopes, CancellationToken cancellationToken)
            {
                return _scope == scopes[0] ? _token : null;
            }

            public override ValueTask<string> GetTokenAsync(string[] scopes, CancellationToken cancellationToken)
            {
                return _scope == scopes[0] ? _tokenTask : default;
            }
        }

        public class ExceptionalMockTokenCredential : TokenCredential
        {
            public override string GetToken(string[] scopes, CancellationToken cancellationToken)
            {
                throw new MockException();
            }

            public override ValueTask<string> GetTokenAsync(string[] scopes, CancellationToken cancellationToken)
            {
                throw new MockException();
            }
        }

        [Test]
        public void CtorInvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => new AggregateCredential(null));

            Assert.Throws<ArgumentException>(() => new AggregateCredential((TokenCredential)null));

            Assert.Throws<ArgumentException>(() => new AggregateCredential());

            Assert.Throws<ArgumentException>(() => new AggregateCredential(new TokenCredential[] { }));
        }

        [Test]
        public async Task CredentialSequenceValid()
        {
            var cred1 = new SimpleMockTokenCredential("scopeA", "tokenA");
            var cred2 = new SimpleMockTokenCredential("scopeB", "tokenB");
            var cred3 = new SimpleMockTokenCredential("scopeB", "NotToBeReturned");
            var cred4 = new SimpleMockTokenCredential("scopeC", "tokenC");
            var provider = new AggregateCredential(cred1, cred2, cred3, cred4);

            Assert.AreEqual("tokenA", await provider.GetTokenAsync(new string[] { "scopeA" }));
            Assert.AreEqual("tokenB", await provider.GetTokenAsync(new string[] { "scopeB" }));
            Assert.AreEqual("tokenC", await provider.GetTokenAsync(new string[] { "scopeC" }));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await provider.GetTokenAsync(new string[] { "scopeD" }));
        }

        [Test]
        public async Task CredentialThrows()
        {
            var cred1 = new SimpleMockTokenCredential("scopeA", "tokenA");
            var cred2 = new ExceptionalMockTokenCredential();
            var cred3 = new SimpleMockTokenCredential("scopeB", "tokenB");
            var provider = new AggregateCredential(cred1, cred2, cred3);

            Assert.AreEqual("tokenA", await provider.GetTokenAsync(new string[] { "scopeA" }));
            Assert.ThrowsAsync<MockException>(async () => await provider.GetTokenAsync(new string[] { "ScopeB" }));
            Assert.ThrowsAsync<MockException>(async () => await provider.GetTokenAsync(new string[] { "ScopeC" }));
        }
    }
}
