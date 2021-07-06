using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Linq;

namespace Azure.ResourceManager.Core.Tests
{
    public class ProviderContainerTests : ResourceManagerTestBase
    {
        public ProviderContainerTests(bool isAsync)
         : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase("microsoft.insights")]
        [RecordedTest]
        public async Task GetFromSubscription(string resourceNamespace)
        {
            var providerContainer = Client.DefaultSubscription.GetProviders();
            var result = await providerContainer.GetAsync(resourceNamespace);
            Assert.IsNotNull(result);
        }

        [TestCase("microsoft.compute")]
        [RecordedTest]
        public async Task GetFromTenant(string resourceNamespace)
        {
            var providerContainer = Client.Tenant.GetProviders();
            var result = await providerContainer.GetAsync(resourceNamespace);
            Assert.IsNotNull(result);
        }

        [TestCase]
        [RecordedTest]
        public void GetNullException()
        {
            ProviderContainer providerContainer = Client.DefaultSubscription.GetProviders();
            Assert.ThrowsAsync<ArgumentNullException>(async () => {await providerContainer.GetAsync(null); });
        }

        [TestCase]
        [RecordedTest]
        public void GetEmptyException()
        {
            ProviderContainer providerContainer = Client.DefaultSubscription.GetProviders();
            Assert.ThrowsAsync<ArgumentException>(async () => {await providerContainer.GetAsync(""); });
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            var providerContainer = Client.DefaultSubscription.GetProviders();
            var x = providerContainer.ListAsync();
            Assert.IsNotNull(x);
            await foreach (var p in x)
            {
                Assert.IsNotNull(p.Data.Id);
            }
        }
    }
}
