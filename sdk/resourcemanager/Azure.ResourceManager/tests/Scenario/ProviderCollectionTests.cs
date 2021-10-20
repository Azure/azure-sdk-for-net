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
            var providerCollection = Client.DefaultSubscription.GetProviders();
            var result = await providerCollection.GetAsync(resourceNamespace);
            Assert.IsNotNull(result);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await providerCollection.GetAsync("DoesNotExist"));
            Assert.AreEqual(404, ex.Status);
        }

        [RecordedTest]
        public void GetNullException()
        {
            ProviderCollection providerCollection = Client.DefaultSubscription.GetProviders();
            Assert.ThrowsAsync<ArgumentNullException>(async () => {await providerCollection.GetAsync(null); });
        }

        [RecordedTest]
        public void GetEmptyException()
        {
            ProviderCollection providerCollection = Client.DefaultSubscription.GetProviders();
            Assert.ThrowsAsync<ArgumentException>(async () => {await providerCollection.GetAsync(""); });
        }

        [RecordedTest]
        public async Task List()
        {
            var providerCollection = Client.DefaultSubscription.GetProviders();
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
            ProviderCollection providerCollection = Client.DefaultSubscription.GetProviders();
            Provider provider = await providerCollection.GetIfExistsAsync("microsoft.insights");
            Assert.IsNotNull(provider);

            var response = await providerCollection.GetIfExistsAsync("DoesNotExist");
            Assert.IsNull(response.Value);
        }

        [RecordedTest]
        public async Task CheckIfExists()
        {
            ProviderCollection providerCollection = Client.DefaultSubscription.GetProviders();
            Assert.IsTrue(await providerCollection.CheckIfExistsAsync("microsoft.insights"));
            var response = await providerCollection.CheckIfExistsAsync("DoesNotExist");
            Assert.False(response);
        }
    }
}
