using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
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
            _ = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testRg-"));
            _ = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testRg-"));
            int count = 0;
            await foreach (var rg in Client.DefaultSubscription.GetResourceGroups().GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListWithParameters()
        {
            var tags = new Dictionary<string, string>();
            tags.Add("MyKey", "MyValue");
            _ = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2, tags).CreateOrUpdateAsync(Recording.GenerateAssetName("test1-"));
            _ = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2, tags).CreateOrUpdateAsync(Recording.GenerateAssetName("test2-"));
            _ = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("test4-"));
            int count = 0;
            await foreach (var rg in Client.DefaultSubscription.GetResourceGroups().GetAllAsync("tagName eq 'MyKey' and tagValue eq 'MyValue'", 2))
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
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2, tags).CreateOrUpdateAsync(rgName);
            ResourceGroup rg = rgOp.Value;
            Assert.AreEqual(rgName, rg.Data.Name);

            Assert.Throws<ArgumentNullException>(() => { Client.DefaultSubscription.GetResourceGroups().Construct(null); });
            Assert.ThrowsAsync<ArgumentException>(async () => _ = await Client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(null, new ResourceGroupData(Location.WestUS2)));
            Assert.ThrowsAsync<ArgumentException>(async () => _ = await Client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(" ", new ResourceGroupData(Location.WestUS2)));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(rgName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            string rgName = Recording.GenerateAssetName("testRg-");
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName, false);
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            Assert.AreEqual(rgName, rg.Data.Name);

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                var rgOp = await Client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(null, new ResourceGroupData(Location.WestUS2), false);
                _ = await rgOp.WaitForCompletionAsync();
            });
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                var rgOp = await Client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(" ", new ResourceGroupData(Location.WestUS2), false);
                _ = await rgOp.WaitForCompletionAsync();
            });
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var rgOp = await Client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(rgName, null, false);
                _ = await rgOp.WaitForCompletionAsync();
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string rgName = Recording.GenerateAssetName("testRg-");
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            ResourceGroup rg = rgOp.Value;
            ResourceGroup rg2 = await Client.DefaultSubscription.GetResourceGroups().GetAsync(rgName);
            Assert.AreEqual(rg.Data.Name, rg2.Data.Name);
            Assert.AreEqual(rg.Data.Id, rg2.Data.Id);
            Assert.AreEqual(rg.Data.Type, rg2.Data.Type);
            Assert.AreEqual(rg.Data.Properties.ProvisioningState, rg2.Data.Properties.ProvisioningState);
            Assert.AreEqual(rg.Data.Location, rg2.Data.Location);
            Assert.AreEqual(rg.Data.ManagedBy, rg2.Data.ManagedBy);
            Assert.AreEqual(rg.Data.Tags, rg2.Data.Tags);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetResourceGroups().GetAsync(null));
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.DefaultSubscription.GetResourceGroups().GetAsync(rg.Data.Id + "x"));
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var rgName = Recording.GenerateAssetName("testRg-");
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            ResourceGroup rg = rgOp.Value;
            Assert.IsTrue(await Client.DefaultSubscription.GetResourceGroups().CheckIfExistsAsync(rgName));
            Assert.IsFalse(await Client.DefaultSubscription.GetResourceGroups().CheckIfExistsAsync(rgName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetResourceGroups().CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task TryGet()
        {
            var rgName = Recording.GenerateAssetName("testRg-");
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            ResourceGroup rg = rgOp.Value;
            ResourceGroup rg2 = await Client.DefaultSubscription.GetResourceGroups().GetIfExistsAsync(rgName);
            Assert.AreEqual(rg.Data.Name, rg2.Data.Name);

            var response = await Client.DefaultSubscription.GetResourceGroups().GetIfExistsAsync(rgName + "1");
            Assert.IsNull(response.Value);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetResourceGroups().CheckIfExistsAsync(null));
        }
    }
}
