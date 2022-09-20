using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ProviderOperationsTests : ResourceManagerTestBase
    {
        public ProviderOperationsTests(bool isAsync)
         : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        [SyncOnly]
        public void NoDataValidation()
        {
            ///subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/microsoft.insights
            var resource = Client.GetResourceProviderResource(new ResourceIdentifier($"/subscriptions/{Guid.NewGuid()}/providers/microsoft.FakeNamespace"));
            Assert.Throws<InvalidOperationException>(() => { var data = resource.Data; });
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders();
            Response<ResourceProviderResource> response = await providerCollection.GetAsync("microsoft.insights");
            ResourceProviderResource result = response.Value;
            Assert.IsNotNull(result);

            ResourceIdentifier fakeId = new ResourceIdentifier(result.Data.Id.ToString() + "x");
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.GetResourceProviderResource(new ResourceIdentifier(fakeId)).GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Register()
        {
            ResourceProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders();
            Response<ResourceProviderResource> response = await providerCollection.GetAsync("microsoft.compute");
            var result = response.Value;
            var register = await result.RegisterAsync();
            Assert.IsNotNull(register);
        }

        [TestCase]
        [RecordedTest]
        public async Task Unregister()
        {
            ResourceProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders();
            Response<ResourceProviderResource> response = await providerCollection.GetAsync("Microsoft.HealthBot");
            var result = response.Value;
            var unregister = await result.UnregisterAsync();
            Assert.IsNotNull(unregister);
        }

        [TestCase]
        [RecordedTest]
        public async Task UnregisterNullException()
        {
            ResourceProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders();
            Response<ResourceProviderResource> response = await providerCollection.GetAsync("microsoft.insights");
        }

        [TestCase]
        [RecordedTest]
        public async Task UnregisterEmptyException()
        {
            ResourceProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders();
            Response<ResourceProviderResource> response = await providerCollection.GetAsync("microsoft.insights");
        }
    }
}
