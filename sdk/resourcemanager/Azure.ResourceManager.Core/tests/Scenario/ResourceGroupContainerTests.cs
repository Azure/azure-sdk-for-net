using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            await foreach(var rg in Client.DefaultSubscription.GetResourceGroups().ListAsync())
            {
                count++;
            }
            Assert.Greater(count, 2);
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
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(rgName);
            ResourceGroup rg2 = await Client.DefaultSubscription.GetResourceGroups().GetAsync(rgName);
            Assert.AreEqual(rg.Data.Name, rg2.Data.Name);
        }
    }
}
