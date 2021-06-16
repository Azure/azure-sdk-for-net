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
         : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/microsoft.insights")]
        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/microsoft.insights")]
        [RecordedTest]
        public async Task Get(string resourceId)
        {
            var providerContainer = Client.DefaultSubscription.GetProviders();
            var result = await providerContainer.GetAsync(resourceId);
            Assert.IsNotNull(result);
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
