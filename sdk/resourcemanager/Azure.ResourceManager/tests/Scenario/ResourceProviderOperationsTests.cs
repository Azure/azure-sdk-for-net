using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ResourceProviderOperationsTests : ResourceManagerTestBase
    {
        public ResourceProviderOperationsTests(bool isAsync)
         : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task GetProviderPermissions()
        {
            var subscription = await Client.GetDefaultSubscriptionAsync();
            var collection = subscription.GetResourceProviders();
            ResourceProviderResource provider = await collection.GetAsync("Microsoft.Resources");
            int count = 0;
            await foreach (var permission in provider.ProviderPermissionsAsync())
            {
                count++;
            }
            Assert.Greater(count, 0);
        }
    }
}
