using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ResourceListOperationsTests : ResourceManagerTestBase
    {
        public ResourceListOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task ListAtContext()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            _ = await CreateGenericAvailabilitySetAsync(rg.Id);

            ResourceGroup rgOp = Client.GetResourceGroup(rg.Id);
            var result = 0;
            var pageable = ResourceListOperations.GetAtContextAsync(rgOp);
            await foreach (var resource in pageable)
            {
                result++;
            }
            Assert.AreEqual(1, result);

            result = 0;
            pageable = ResourceListOperations.GetAtContextAsync(Client.DefaultSubscription);
            await foreach (var resource in pageable)
            {
                result++;
            }
            Assert.GreaterOrEqual(result, 1);
        }
    }
}
