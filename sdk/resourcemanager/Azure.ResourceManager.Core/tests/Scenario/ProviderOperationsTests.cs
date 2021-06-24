using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Linq;

namespace Azure.ResourceManager.Core.Tests
{
    public class ProviderOperationsTests : ResourceManagerTestBase
    {
        public ProviderOperationsTests(bool isAsync)
         : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ProviderContainer providerContainer = Client.DefaultSubscription.GetProviders();
            Response<Provider> response = await providerContainer.GetAsync("microsoft.insights");
            Provider result = response.Value;
            Assert.IsNotNull(result);
        }

        [TestCase]
        [RecordedTest]
        public async Task Register()
        {
            ProviderContainer providerContainer = Client.DefaultSubscription.GetProviders();
            Response<Provider> response = await providerContainer.GetAsync("microsoft.compute");
            var result = response.Value;
            var register = await result.RegisterAsync("testerNamespace");
            Assert.IsNotNull(register);
        }

        [TestCase]
        [RecordedTest]
        public void RegisterNullException()
        {
            ProviderContainer providerContainer = Client.DefaultSubscription.GetProviders();
            Response<Provider> response = providerContainer.Get("microsoft.insights");
            Assert.Throws<ArgumentNullException>(async () => {await response.Value.RegisterAsync(null); });
        }

        [TestCase]
        [RecordedTest]
        public void RegisterEmptyException()
        {
            ProviderContainer providerContainer = Client.DefaultSubscription.GetProviders();
            Response<Provider> response = providerContainer.Get("microsoft.insights");
            Assert.Throws<ArgumentException>(async () => {await response.Value.RegisterAsync(""); });
        }

        [TestCase]
        [RecordedTest]
        public async Task Unregister()
        {
            ProviderContainer providerContainer = Client.DefaultSubscription.GetProviders();
            Response<Provider> response = await providerContainer.GetAsync("microsoft.insights");
            var result = response.Value;
            var unregister = await result.UnregisterAsync("testerNamespace");
            Assert.IsNotNull(unregister);
        }

        [TestCase]
        [RecordedTest]
        public void UnregisterNullException()
        {
            ProviderContainer providerContainer = Client.DefaultSubscription.GetProviders();
            Response<Provider> response = providerContainer.Get("microsoft.insights");
            Assert.Throws<ArgumentNullException>(async () => {await response.Value.UnregisterAsync(null); });
        }

        [TestCase]
        [RecordedTest]
        public void UnregisterEmptyException()
        {
            ProviderContainer providerContainer = Client.DefaultSubscription.GetProviders();
            Response<Provider> response = providerContainer.Get("microsoft.insights");
            Assert.Throws<ArgumentException>(async () => {await response.Value.UnregisterAsync(""); });
        }
    }
}
