using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ResourceGroupCollectionTests : ResourceManagerTestBase
    {
        public ResourceGroupCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            _ = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testRg-"));
            _ = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testRg-"));
            int count = 0;
            await foreach (var rg in subscription.GetResourceGroups().GetAllAsync())
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            _ = await subscription.GetResourceGroups().Construct(Location.WestUS2, tags).CreateOrUpdateAsync(Recording.GenerateAssetName("test1-"));
            _ = await subscription.GetResourceGroups().Construct(Location.WestUS2, tags).CreateOrUpdateAsync(Recording.GenerateAssetName("test2-"));
            _ = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("test4-"));
            int count = 0;
            await foreach (var rg in subscription.GetResourceGroups().GetAllAsync("tagName eq 'MyKey' and tagValue eq 'MyValue'", 2))
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(Location.WestUS2, tags).CreateOrUpdateAsync(rgName);
            ResourceGroup rg = rgOp.Value;
            Assert.AreEqual(rgName, rg.Data.Name);

            Assert.Throws<ArgumentNullException>(() => { subscription.GetResourceGroups().Construct(null); });
            Assert.ThrowsAsync<ArgumentException>(async () => _ = await subscription.GetResourceGroups().CreateOrUpdateAsync(null, new ResourceGroupData(Location.WestUS2)));
            Assert.ThrowsAsync<ArgumentException>(async () => _ = await subscription.GetResourceGroups().CreateOrUpdateAsync(" ", new ResourceGroupData(Location.WestUS2)));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            string rgName = Recording.GenerateAssetName("testRg-");
            var rgOp = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName, false);
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            Assert.AreEqual(rgName, rg.Data.Name);

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(null, new ResourceGroupData(Location.WestUS2), false);
                _ = await rgOp.WaitForCompletionAsync();
            });
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(" ", new ResourceGroupData(Location.WestUS2), false);
                _ = await rgOp.WaitForCompletionAsync();
            });
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, null, false);
                _ = await rgOp.WaitForCompletionAsync();
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            string rgName = Recording.GenerateAssetName("testRg-");
            var rgOp = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            ResourceGroup rg = rgOp.Value;
            ResourceGroup rg2 = await subscription.GetResourceGroups().GetAsync(rgName);
            Assert.AreEqual(rg.Data.Name, rg2.Data.Name);
            Assert.AreEqual(rg.Data.Id, rg2.Data.Id);
            Assert.AreEqual(rg.Data.Type, rg2.Data.Type);
            Assert.AreEqual(rg.Data.Properties.ProvisioningState, rg2.Data.Properties.ProvisioningState);
            Assert.AreEqual(rg.Data.Location, rg2.Data.Location);
            Assert.AreEqual(rg.Data.ManagedBy, rg2.Data.ManagedBy);
            Assert.AreEqual(rg.Data.Tags, rg2.Data.Tags);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetResourceGroups().GetAsync(null));
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await subscription.GetResourceGroups().GetAsync(rg.Data.Id + "x"));
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgName = Recording.GenerateAssetName("testRg-");
            var rgOp = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            ResourceGroup rg = rgOp.Value;
            Assert.IsTrue(await subscription.GetResourceGroups().CheckIfExistsAsync(rgName));
            Assert.IsFalse(await subscription.GetResourceGroups().CheckIfExistsAsync(rgName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetResourceGroups().CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task TryGet()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgName = Recording.GenerateAssetName("testRg-");
            var rgOp = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            ResourceGroup rg = rgOp.Value;
            ResourceGroup rg2 = await subscription.GetResourceGroups().GetIfExistsAsync(rgName);
            Assert.AreEqual(rg.Data.Name, rg2.Data.Name);

            var response = await subscription.GetResourceGroups().GetIfExistsAsync(rgName + "1");
            Assert.IsNull(response.Value);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetResourceGroups().CheckIfExistsAsync(null));
        }

        [RecordedTest]
        public async Task EnumerableInterface()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(Recording.GenerateAssetName("testRg-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgOp.Value;
            int count = 0;
            await foreach(var rgFromList in subscription.GetResourceGroups())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }
    }
}
