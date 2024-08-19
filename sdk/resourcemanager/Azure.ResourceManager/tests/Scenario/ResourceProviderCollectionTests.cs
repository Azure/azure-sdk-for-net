using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ResourceProviderCollectionTests : ResourceManagerTestBase
    {
        public ResourceProviderCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase("microsoft.insights")]
        [RecordedTest]
        public async Task GetFromSubscription(string resourceNamespace)
        {
            var providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders();
            var result = await providerCollection.GetAsync(resourceNamespace);
            Assert.IsNotNull(result);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await providerCollection.GetAsync("DoesNotExist"));
            Assert.AreEqual(404, ex.Status);
        }

        [RecordedTest]
        public async Task GetNullException()
        {
            ResourceProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders();
            Assert.ThrowsAsync<ArgumentNullException>(async () => {await providerCollection.GetAsync(null); });
        }

        [RecordedTest]
        public async Task GetEmptyException()
        {
            ResourceProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders();
            Assert.ThrowsAsync<ArgumentException>(async () => {await providerCollection.GetAsync(""); });
        }

        [RecordedTest]
        public async Task List()
        {
            var providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders();
            var x = providerCollection.GetAllAsync();
            Assert.IsNotNull(x);
            await foreach (var p in x)
            {
                Assert.IsNotNull(p.Data.Id);
            }
        }

        [RecordedTest]
        public async Task Exists()
        {
            ResourceProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders();
            Assert.IsTrue(await providerCollection.ExistsAsync("microsoft.insights"));
            var response = await providerCollection.ExistsAsync("DoesNotExist");
            Assert.False(response);
        }
    }
}
