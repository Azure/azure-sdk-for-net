using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ProviderCollectionTests : ResourceManagerTestBase
    {
        public ProviderCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase("microsoft.insights")]
        [RecordedTest]
        public async Task GetFromSubscription(string resourceNamespace)
        {
            var providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            var result = await providerCollection.GetAsync(resourceNamespace);
            Assert.IsNotNull(result);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await providerCollection.GetAsync("DoesNotExist"));
            Assert.AreEqual(404, ex.Status);
        }

        [RecordedTest]
        public async Task GetNullException()
        {
            ProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            Assert.ThrowsAsync<ArgumentNullException>(async () => {await providerCollection.GetAsync(null); });
        }

        [RecordedTest]
        public async Task GetEmptyException()
        {
            ProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            Assert.ThrowsAsync<ArgumentException>(async () => {await providerCollection.GetAsync(""); });
        }

        [RecordedTest]
        public async Task List()
        {
            var providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            var x = providerCollection.GetAllAsync();
            Assert.IsNotNull(x);
            await foreach (var p in x)
            {
                Assert.IsNotNull(p.Data.Id);
            }
        }

        [RecordedTest]
        public async Task TryGet()
        {
            ProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            Provider provider = await providerCollection.GetIfExistsAsync("microsoft.insights");
            Assert.IsNotNull(provider);

            var response = await providerCollection.GetIfExistsAsync("DoesNotExist");
            Assert.IsNull(response.Value);
        }

        [RecordedTest]
        public async Task CheckIfExists()
        {
            ProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            Assert.IsTrue(await providerCollection.CheckIfExistsAsync("microsoft.insights"));
            var response = await providerCollection.CheckIfExistsAsync("DoesNotExist");
            Assert.False(response);
        }
    }
}
