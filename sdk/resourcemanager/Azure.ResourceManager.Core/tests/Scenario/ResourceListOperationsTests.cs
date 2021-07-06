using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
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
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            _ = await CreateGenericAvailabilitySetAsync(rg.Id);

            ResourceGroupOperations rgOp = Client.GetResourceGroupOperations(rg.Id);
            var result = 0;
            var pageable = ResourceListOperations.ListAtContextAsync(rgOp);
            await foreach (var resource in pageable)
            {
                result++;
            }
            Assert.AreEqual(1, result);

            result = 0;
            pageable = ResourceListOperations.ListAtContextAsync(Client.DefaultSubscription);
            await foreach (var resource in pageable)
            {
                result++;
            }
            Assert.GreaterOrEqual(result, 1);
        }
    }
}
