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
            Assert.That(result, Is.Not.Null);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await providerCollection.GetAsync("DoesNotExist"));
            Assert.That(ex.Status, Is.EqualTo(404));
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
            Assert.That(x, Is.Not.Null);
            await foreach (var p in x)
            {
                Assert.That(p.Data.Id, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task Exists()
        {
            ResourceProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders();
            Assert.That((bool)await providerCollection.ExistsAsync("microsoft.insights"), Is.True);
            var response = await providerCollection.ExistsAsync("DoesNotExist");
            Assert.That((bool)response, Is.False);
        }
    }
}
