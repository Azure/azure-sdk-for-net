using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            _ = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testRg-"));
            _ = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testRg-"));
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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            _ = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2, tags).CreateOrUpdateAsync(Recording.GenerateAssetName("test1-"));
            _ = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2, tags).CreateOrUpdateAsync(Recording.GenerateAssetName("test2-"));
            _ = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("test4-"));
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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2, tags).CreateOrUpdateAsync(rgName);
            ResourceGroupResource rg = rgOp.Value;
            Assert.AreEqual(rgName, rg.Data.Name);

            Assert.Throws<ArgumentNullException>(() => { subscription.GetResourceGroups().Construct(null); });
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, null, new ResourceGroupData(AzureLocation.WestUS2)));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            string rgName = Recording.GenerateAssetName("testRg-");
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(rgName, WaitUntil.Started);
            ResourceGroupResource rg = await rgOp.WaitForCompletionAsync();
            Assert.AreEqual(rgName, rg.Data.Name);

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, null, new ResourceGroupData(AzureLocation.WestUS2));
                _ = await rgOp.WaitForCompletionAsync();
            });
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, rgName, null);
                _ = await rgOp.WaitForCompletionAsync();
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            string rgName = Recording.GenerateAssetName("testRg-");
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(rgName);
            ResourceGroupResource rg = rgOp.Value;
            ResourceGroupResource rg2 = await subscription.GetResourceGroups().GetAsync(rgName);
            Assert.AreEqual(rg.Data.Name, rg2.Data.Name);
            Assert.AreEqual(rg.Data.Id, rg2.Data.Id);
            Assert.AreEqual(rg.Data.ResourceType, rg2.Data.ResourceType);
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
        public async Task Exists()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgName = Recording.GenerateAssetName("testRg-");
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(rgName);
            ResourceGroupResource rg = rgOp.Value;
            Assert.IsTrue(await subscription.GetResourceGroups().ExistsAsync(rgName));
            Assert.IsFalse(await subscription.GetResourceGroups().ExistsAsync(rgName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetResourceGroups().ExistsAsync(null));
        }

        [RecordedTest]
        public async Task EnumerableInterface()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testRg-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgOp.Value;
            int count = 0;
            await foreach(var rgFromList in subscription.GetResourceGroups())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }
    }
}
