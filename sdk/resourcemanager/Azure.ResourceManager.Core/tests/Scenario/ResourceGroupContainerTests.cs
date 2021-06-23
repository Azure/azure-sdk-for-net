using System;
using System.Collections.Generic;
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
        public async Task CreateOrUpdate()
        {
            string rgName = Recording.GenerateAssetName("testRg-");
            var tags = new Dictionary<string, string>()
            {
                { "key", "value"}
            };
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2, tags).CreateOrUpdateAsync(rgName);
            Assert.AreEqual(rgName, rg.Data.Name);

            Assert.Throws<ArgumentNullException>(() => { Client.DefaultSubscription.GetResourceGroups().Construct(null); });
            Assert.ThrowsAsync<ArgumentException>(async () => _ = await Client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(null, new ResourceGroupData(LocationData.WestUS2)));
            Assert.ThrowsAsync<ArgumentException>(async () => _ = await Client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(" ", new ResourceGroupData(LocationData.WestUS2)));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(rgName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            string rgName = Recording.GenerateAssetName("testRg-");
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(rgName);
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            Assert.AreEqual(rgName, rg.Data.Name);

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                var rgOp = await Client.DefaultSubscription.GetResourceGroups().StartCreateOrUpdateAsync(null, new ResourceGroupData(LocationData.WestUS2));
                _ = await rgOp.WaitForCompletionAsync();
            });
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                var rgOp = await Client.DefaultSubscription.GetResourceGroups().StartCreateOrUpdateAsync(" ", new ResourceGroupData(LocationData.WestUS2));
                _ = await rgOp.WaitForCompletionAsync();
            });
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var rgOp = await Client.DefaultSubscription.GetResourceGroups().StartCreateOrUpdateAsync(rgName, null);
                _ = await rgOp.WaitForCompletionAsync();
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(rgName);
            ResourceGroup rg2 = await Client.DefaultSubscription.GetResourceGroups().GetAsync(rgName);
            Assert.AreEqual(rg.Data.Name, rg2.Data.Name);
            Assert.AreEqual(rg.Data.Id, rg2.Data.Id);
            Assert.AreEqual(rg.Data.Type, rg2.Data.Type);
            Assert.AreEqual(rg.Data.Properties.ProvisioningState, rg2.Data.Properties.ProvisioningState);
            Assert.AreEqual(rg.Data.Location, rg2.Data.Location);
            Assert.AreEqual(rg.Data.ManagedBy, rg2.Data.ManagedBy);
            Assert.AreEqual(rg.Data.Tags, rg2.Data.Tags);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetResourceGroups().GetAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task DoesExist()
        {
            var rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(rgName);
            Assert.IsTrue(await Client.DefaultSubscription.GetResourceGroups().DoesExistAsync(rgName));
            Assert.IsFalse(await Client.DefaultSubscription.GetResourceGroups().DoesExistAsync(rgName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetResourceGroups().DoesExistAsync(null));
        }
    }
}
