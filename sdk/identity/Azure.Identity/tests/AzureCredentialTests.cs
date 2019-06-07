using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AzureCredentialTests
    {
        public class MockRefreshAzureCredential : AzureCredential
        {
            private DateTimeOffset _expires;

            public int AuthCount;

            public MockRefreshAzureCredential(DateTimeOffset expires)
                : base(null)
            {
                _expires = expires;
            }

            protected override AccessToken GetTokenCore(string[] scopes, CancellationToken cancellationToken)
            {
                AuthCount++;

                return new AccessToken("mocktoken", _expires);
            }

            protected override async Task<AccessToken> GetTokenCoreAsync(string[] scopes, CancellationToken cancellationToken)
            {
                AuthCount++;

                await Task.CompletedTask;

                return new AccessToken("mocktoken", _expires);
            }
        }

        [Test]
        public async Task RefreshLogicDefaultAsync()
        {
            TimeSpan refreshBuffer = new IdentityClientOptions().RefreshBuffer;

            var refreshCred1 = new MockRefreshAzureCredential(DateTime.UtcNow);

            var refreshCred2 = new MockRefreshAzureCredential(DateTime.UtcNow + refreshBuffer);

            var notRefreshCred1 = new MockRefreshAzureCredential(DateTime.UtcNow + refreshBuffer + TimeSpan.FromMinutes(2));


            foreach (var cred in new AzureCredential[] { refreshCred1, refreshCred2, notRefreshCred1 })
            {
                await cred.GetTokenAsync(new string[] { "mockscope" });
                await cred.GetTokenAsync(new string[] { "mockscope" });
            }

            Assert.AreEqual(2, refreshCred1.AuthCount);
            Assert.AreEqual(2, refreshCred2.AuthCount);
            Assert.AreEqual(1, notRefreshCred1.AuthCount);
        }
    }
}
