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
            var rgOp1 = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp1.Value;
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
            pageable = ResourceListOperations.GetAtContextAsync(await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false));
            await foreach (var resource in pageable)
            {
                result++;
            }
            Assert.GreaterOrEqual(result, 1);
        }
    }
}
