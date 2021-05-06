using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class ResourceGroupContainerTests : ResourceManagerTestBase
    {
        public ResourceGroupContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            _ = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testRg-"));
            _ = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testRg-"));
            int count = 0;
            await foreach (var rg in Client.DefaultSubscription.GetResourceGroups().ListAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task Create()
        {
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(rgName);
            Assert.AreEqual(rgName, rg.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreate()
        {
            string rgName = Recording.GenerateAssetName("testRg-");
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(rgName);
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            Assert.AreEqual(rgName, rg.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroup rg3 = await Client.DefaultSubscription.GetResourceGroups().GetAsync("azhang-test");
            /*ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(rgName);
            ResourceGroup rg2 = await Client.DefaultSubscription.GetResourceGroups().GetAsync(rgName);
            Assert.AreEqual(rg.Data.Name, rg2.Data.Name);
            Assert.AreEqual(rg.Data.Id, rg2.Data.Id);
            Assert.AreEqual(rg.Data.Type, rg2.Data.Type);
            Assert.AreEqual(rg.Data.Properties, rg2.Data.Properties);
            Assert.AreEqual(rg.Data.Location, rg2.Data.Location);
            Assert.AreEqual(rg.Data.ManagedBy, rg2.Data.ManagedBy);
            Assert.AreEqual(rg.Data.Tags, rg2.Data.Tags);*/
        }
    }
}
