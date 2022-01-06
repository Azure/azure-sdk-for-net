using System;
using System.Threading.Tasks;
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
            var resource = Client.GetProvider(new ResourceIdentifier($"/subscriptions/{Guid.NewGuid()}/providers/microsoft.FakeNamespace"));
            Assert.Throws<InvalidOperationException>(() => { var data = resource.Data; });
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            Response<Provider> response = await providerCollection.GetAsync("microsoft.insights");
            Provider result = response.Value;
            Assert.IsNotNull(result);

            ResourceIdentifier fakeId = new ResourceIdentifier(result.Data.Id.ToString() + "x");
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.GetProvider(new ResourceIdentifier(fakeId)).GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Register()
        {
            ProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            Response<Provider> response = await providerCollection.GetAsync("microsoft.compute");
            var result = response.Value;
            var register = await result.RegisterAsync("microsoft.insights");
            Assert.IsNotNull(register);
        }

        [TestCase]
        [RecordedTest]
        public async Task RegisterNullException()
        {
            ProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            Response<Provider> response = await providerCollection.GetAsync("microsoft.insights");
            Assert.ThrowsAsync<ArgumentNullException>(async () => {await response.Value.RegisterAsync(null); });
        }

        [TestCase]
        [RecordedTest]
        public async Task RegisterEmptyException()
        {
            ProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            Response<Provider> response = await providerCollection.GetAsync("microsoft.insights");
            Assert.ThrowsAsync<RequestFailedException>(async () => {await response.Value.RegisterAsync(""); });
        }

        [TestCase]
        [RecordedTest]
        public async Task Unregister()
        {
            ProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            Response<Provider> response = await providerCollection.GetAsync("microsoft.insights");
            var result = response.Value;
            var unregister = await result.UnregisterAsync("microsoft.insights");
            Assert.IsNotNull(unregister);
        }

        [TestCase]
        [RecordedTest]
        public async Task UnregisterNullException()
        {
            ProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            Response<Provider> response = await providerCollection.GetAsync("microsoft.insights");
            Assert.ThrowsAsync<ArgumentNullException>(async () => {await response.Value.UnregisterAsync(null); });
        }

        [TestCase]
        [RecordedTest]
        public async Task UnregisterEmptyException()
        {
            ProviderCollection providerCollection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders();
            Response<Provider> response = await providerCollection.GetAsync("microsoft.insights");
            Assert.ThrowsAsync<RequestFailedException>(async () => {await response.Value.UnregisterAsync(""); });
        }
    }
}
