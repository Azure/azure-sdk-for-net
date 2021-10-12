using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ProviderContainerTests : ResourceManagerTestBase
    {
        public ProviderContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase("microsoft.insights")]
        [RecordedTest]
        public async Task GetFromSubscription(string resourceNamespace)
        {
            var providerContainer = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            var result = await providerContainer.GetAsync(resourceNamespace);
            Assert.IsNotNull(result);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await providerContainer.GetAsync("DoesNotExist"));
            Assert.AreEqual(404, ex.Status);
        }

        [RecordedTest]
        public async Task GetNullException()
        {
            ProviderContainer providerContainer = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            Assert.ThrowsAsync<ArgumentNullException>(async () => {await providerContainer.GetAsync(null); });
        }

        [RecordedTest]
        public async Task GetEmptyException()
        {
            ProviderContainer providerContainer = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            Assert.ThrowsAsync<ArgumentException>(async () => {await providerContainer.GetAsync(""); });
        }

        [RecordedTest]
        public async Task List()
        {
            var providerContainer = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            var x = providerContainer.GetAllAsync();
            Assert.IsNotNull(x);
            await foreach (var p in x)
            {
                Assert.IsNotNull(p.Data.Id);
            }
        }

        [RecordedTest]
        public async Task TryGet()
        {
            ProviderContainer providerContainer = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            Provider provider = await providerContainer.GetIfExistsAsync("microsoft.insights");
            Assert.IsNotNull(provider);

            var response = await providerContainer.GetIfExistsAsync("DoesNotExist");
            Assert.IsNull(response.Value);
        }

        [RecordedTest]
        public async Task CheckIfExists()
        {
            ProviderContainer providerContainer = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            Assert.IsTrue(await providerContainer.CheckIfExistsAsync("microsoft.insights"));
            var response = await providerContainer.CheckIfExistsAsync("DoesNotExist");
            Assert.False(response);
        }
    }
}
