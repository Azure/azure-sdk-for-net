using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Identity.Tests.Mock
{
    public class MockManagedIdentityCredentialTests
    {
        [Test]
        public async Task TokenCacheRefresh()
        {
            // ensure expired tokens are refreshed
            var expired = new ManagedIdentityCredential() { Client = MockIdentityClient.ExpiredTokenClient };

            HashSet<string> tokens = new HashSet<string>();

            for (int i = 0; i < 100; i++)
            {
                Assert.IsTrue(tokens.Add(await expired.GetTokenAsync(MockScopes.Default)), "token failed to refresh");
            }

            // ensure non expired tokens are not refeshed
            var live = new ManagedIdentityCredential() { Client = MockIdentityClient.LiveTokenClient };

            tokens.Clear();

            tokens.Add(await live.GetTokenAsync(MockScopes.Default));

            for (int i = 0; i < 100; i++)
            {
                Assert.IsFalse(tokens.Add(await live.GetTokenAsync(MockScopes.Default)));
            }
        }

        [Test]
        public async Task CancellationTokenHonoredAsync()
        {
            var credential = new ManagedIdentityCredential() { Client = new MockIdentityClient() };

            var cancellation = new CancellationTokenSource();

            ValueTask<string> getTokenComplete = credential.GetTokenAsync(MockScopes.Default, cancellation.Token);

            cancellation.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await getTokenComplete, "failed to cancel GetToken call");

            await Task.CompletedTask;
        }
        
        [Test]
        public async Task ScopesHonoredAsync()
        {
            var credential = new ManagedIdentityCredential() { Client = new MockIdentityClient() };

            string defaultScopeToken = await credential.GetTokenAsync(MockScopes.Default);

            Assert.IsTrue(new MockToken(defaultScopeToken).HasField("scopes", MockScopes.Default.ToString()));
        }
    }
}
