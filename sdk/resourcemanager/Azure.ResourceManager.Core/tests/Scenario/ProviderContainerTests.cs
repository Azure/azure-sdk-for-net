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
         : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public void Get()
        {
            ProviderContainer providerContainer = Client.DefaultSubscription.GetProviders();
            Assert.IsNotNull(providerContainer.Id);
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            var providerContainer = Client.DefaultSubscription.GetProviders();
            var x = providerContainer.ListAsync(); // x is null?
            await foreach (var p in x)
            {
                Console.WriteLine(p.Id);
            }
        }

        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/microsoft.insights")]
        public void testGet(string resourceId)
        {
            var providerContainer = Client.DefaultSubscription.GetProviders();
            providerContainer.Get(resourceId);
        }
    }
}
