using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class GenericResourceOperationsTests : ResourceManagerTestBase
    {
        public GenericResourceOperationsTests(bool isAsync)
         : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            GenericResource aset1 = await CreateGenericAvailabilitySetAsync(rg.Id);
            GenericResource aset2 = await aset1.GetAsync();
            Assert.AreEqual(aset1.Data.Id, aset2.Data.Id);
            Assert.AreEqual(aset1.Data.Name, aset2.Data.Name);
            Assert.AreEqual(aset1.Data.Type, aset2.Data.Type);
            Assert.AreEqual(aset1.Data.Location, aset2.Data.Location);
            Assert.AreEqual(aset1.Data.Plan, aset2.Data.Plan);
            //Assert.AreEqual(aset1.Data.Properties, aset2.Data.Properties);
            Assert.AreEqual(aset1.Data.Kind, aset2.Data.Kind);
            Assert.AreEqual(aset1.Data.ManagedBy, aset2.Data.ManagedBy);
            Assert.AreEqual(aset1.Data.Sku, aset2.Data.Sku);
            Assert.AreEqual(aset1.Data.Identity, aset2.Data.Identity);
            Assert.AreEqual(aset1.Data.Tags, aset2.Data.Tags);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            GenericResource aset = await CreateGenericAvailabilitySetAsync(rg.Id);
            await aset.DeleteAsync();

            var fakeId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await CreateGenericAvailabilitySetAsync(fakeId));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartDelete()
        {
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            var createOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
            GenericResource aset = await createOp.WaitForCompletionAsync();
            var deleteOp = await aset.StartDeleteAsync();
            await deleteOp.WaitForCompletionResponseAsync();

            var fakeId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var createOp = await StartCreateGenericAvailabilitySetAsync(fakeId);
                _ = await createOp.WaitForCompletionAsync();
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            GenericResource aset1 = await CreateGenericAvailabilitySetAsync(rg.Id);
            var data = new GenericResourceData();
            data.Location = LocationData.EastUS2;
            GenericResource aset2 = await aset1.UpdateAsync(data);
            Assert.AreEqual(aset1.Data.Id, aset2.Data.Id);
            Assert.AreEqual(aset1.Data.Name, aset2.Data.Name);
            Assert.AreEqual(aset1.Data.Type, aset2.Data.Type);
            Assert.AreEqual(aset1.Data.Location, aset2.Data.Location);
            Assert.AreEqual(aset1.Data.Plan, aset2.Data.Plan);
            Assert.AreEqual(aset1.Data.Properties, aset2.Data.Properties);
            Assert.AreEqual(aset1.Data.Kind, aset2.Data.Kind);
            Assert.AreEqual(aset1.Data.ManagedBy, aset2.Data.ManagedBy);
            Assert.AreEqual(aset1.Data.Sku, aset2.Data.Sku);
            Assert.AreEqual(aset1.Data.Identity, aset2.Data.Identity);
            Assert.AreEqual(aset1.Data.Tags, aset2.Data.Tags);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await aset1.UpdateAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartUpdate()
        {
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            var createOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
            GenericResource aset1 = await createOp.WaitForCompletionAsync();
            var data = new GenericResourceData();
            data.Location = LocationData.EastUS2;
            var updateOp = await aset1.StartUpdateAsync(data);
            GenericResource aset2 = await updateOp.WaitForCompletionAsync();
            Assert.AreEqual(aset1.Data.Id, aset2.Data.Id);
            Assert.AreEqual(aset1.Data.Name, aset2.Data.Name);
            Assert.AreEqual(aset1.Data.Type, aset2.Data.Type);
            Assert.AreEqual(aset1.Data.Location, aset2.Data.Location);
            Assert.AreEqual(aset1.Data.Plan, aset2.Data.Plan);
            Assert.AreEqual(aset1.Data.Properties, aset2.Data.Properties);
            Assert.AreEqual(aset1.Data.Kind, aset2.Data.Kind);
            Assert.AreEqual(aset1.Data.ManagedBy, aset2.Data.ManagedBy);
            Assert.AreEqual(aset1.Data.Sku, aset2.Data.Sku);
            Assert.AreEqual(aset1.Data.Identity, aset2.Data.Identity);
            Assert.AreEqual(aset1.Data.Tags, aset2.Data.Tags);

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var updateOp = await aset1.StartUpdateAsync(null);
                _ = await updateOp.WaitForCompletionAsync();
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task AddTag()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            GenericResource aset1 = await CreateGenericAvailabilitySetAsync(rg.Id);
            Assert.AreEqual(0, aset1.Data.Tags.Count);
            GenericResource aset2 = await aset1.AddTagAsync("key", "value");
            Assert.AreEqual(1, aset2.Data.Tags.Count);
            Assert.IsTrue(aset2.Data.Tags.Contains(new KeyValuePair<string, string>("key", "value")));
            Assert.AreEqual(aset1.Data.Id, aset2.Data.Id);
            Assert.AreEqual(aset1.Data.Name, aset2.Data.Name);
            Assert.AreEqual(aset1.Data.Type, aset2.Data.Type);
            Assert.AreEqual(aset1.Data.Location, aset2.Data.Location);
            Assert.AreEqual(aset1.Data.Plan, aset2.Data.Plan);
            Assert.AreEqual(aset1.Data.Properties, aset2.Data.Properties);
            Assert.AreEqual(aset1.Data.Kind, aset2.Data.Kind);
            Assert.AreEqual(aset1.Data.ManagedBy, aset2.Data.ManagedBy);
            Assert.AreEqual(aset1.Data.Sku, aset2.Data.Sku);
            Assert.AreEqual(aset1.Data.Identity, aset2.Data.Identity);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartAddTag()
        {
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            var createOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
            GenericResource aset1 = await createOp.WaitForCompletionAsync();
            Assert.AreEqual(0, aset1.Data.Tags.Count);
            var addTagOp = await aset1.StartAddTagAsync("key", "value");
            GenericResource aset2 = await addTagOp.WaitForCompletionAsync();
            Assert.AreEqual(1, aset2.Data.Tags.Count);
            Assert.IsTrue(aset2.Data.Tags.Contains(new KeyValuePair<string, string>("key", "value")));
            Assert.AreEqual(aset1.Data.Id, aset2.Data.Id);
            Assert.AreEqual(aset1.Data.Name, aset2.Data.Name);
            Assert.AreEqual(aset1.Data.Type, aset2.Data.Type);
            Assert.AreEqual(aset1.Data.Location, aset2.Data.Location);
            Assert.AreEqual(aset1.Data.Plan, aset2.Data.Plan);
            Assert.AreEqual(aset1.Data.Properties, aset2.Data.Properties);
            Assert.AreEqual(aset1.Data.Kind, aset2.Data.Kind);
            Assert.AreEqual(aset1.Data.ManagedBy, aset2.Data.ManagedBy);
            Assert.AreEqual(aset1.Data.Sku, aset2.Data.Sku);
            Assert.AreEqual(aset1.Data.Identity, aset2.Data.Identity);
        }

        [TestCase]
        [RecordedTest]
        public async Task SetTags()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            GenericResource aset1 = await CreateGenericAvailabilitySetAsync(rg.Id);
            Assert.AreEqual(0, aset1.Data.Tags.Count);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value"}
            };
            GenericResource aset2 = await aset1.SetTagsAsync(tags);
            Assert.AreEqual(tags, aset2.Data.Tags);
            Assert.AreEqual(aset1.Data.Id, aset2.Data.Id);
            Assert.AreEqual(aset1.Data.Name, aset2.Data.Name);
            Assert.AreEqual(aset1.Data.Type, aset2.Data.Type);
            Assert.AreEqual(aset1.Data.Location, aset2.Data.Location);
            Assert.AreEqual(aset1.Data.Plan, aset2.Data.Plan);
            Assert.AreEqual(aset1.Data.Properties, aset2.Data.Properties);
            Assert.AreEqual(aset1.Data.Kind, aset2.Data.Kind);
            Assert.AreEqual(aset1.Data.ManagedBy, aset2.Data.ManagedBy);
            Assert.AreEqual(aset1.Data.Sku, aset2.Data.Sku);
            Assert.AreEqual(aset1.Data.Identity, aset2.Data.Identity);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartSetTags()
        {
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            var createOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
            GenericResource aset1 = await createOp.WaitForCompletionAsync();
            Assert.AreEqual(0, aset1.Data.Tags.Count);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value"}
            };
            var setTagsOp = await aset1.StartSetTagsAsync(tags);
            GenericResource aset2 = await setTagsOp.WaitForCompletionAsync();
            Assert.AreEqual(tags, aset2.Data.Tags);
            Assert.AreEqual(aset1.Data.Id, aset2.Data.Id);
            Assert.AreEqual(aset1.Data.Name, aset2.Data.Name);
            Assert.AreEqual(aset1.Data.Type, aset2.Data.Type);
            Assert.AreEqual(aset1.Data.Location, aset2.Data.Location);
            Assert.AreEqual(aset1.Data.Plan, aset2.Data.Plan);
            Assert.AreEqual(aset1.Data.Properties, aset2.Data.Properties);
            Assert.AreEqual(aset1.Data.Kind, aset2.Data.Kind);
            Assert.AreEqual(aset1.Data.ManagedBy, aset2.Data.ManagedBy);
            Assert.AreEqual(aset1.Data.Sku, aset2.Data.Sku);
            Assert.AreEqual(aset1.Data.Identity, aset2.Data.Identity);
        }

        [TestCase]
        [RecordedTest]
        public async Task RemoveTag()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            GenericResource aset1 = await CreateGenericAvailabilitySetAsync(rg.Id);
            var tags1 = new Dictionary<string, string>()
            {
                { "k1", "v1"},
                { "k2", "v2"}
            };
            GenericResource aset2 = await aset1.SetTagsAsync(tags1);
            GenericResource aset3 = await aset2.RemoveTagAsync("k1");
            var tags2 = new Dictionary<string, string>()
            {
                { "k2", "v2"}
            };
            Assert.AreEqual(tags2, aset3.Data.Tags);
            Assert.AreEqual(aset1.Data.Id, aset3.Data.Id);
            Assert.AreEqual(aset1.Data.Name, aset3.Data.Name);
            Assert.AreEqual(aset1.Data.Type, aset3.Data.Type);
            Assert.AreEqual(aset1.Data.Location, aset3.Data.Location);
            Assert.AreEqual(aset1.Data.Plan, aset3.Data.Plan);
            Assert.AreEqual(aset1.Data.Properties, aset3.Data.Properties);
            Assert.AreEqual(aset1.Data.Kind, aset3.Data.Kind);
            Assert.AreEqual(aset1.Data.ManagedBy, aset3.Data.ManagedBy);
            Assert.AreEqual(aset1.Data.Sku, aset3.Data.Sku);
            Assert.AreEqual(aset1.Data.Identity, aset3.Data.Identity);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartRemoveTag()
        {
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            var createOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
            GenericResource aset1 = await createOp.WaitForCompletionAsync();
            var tags1 = new Dictionary<string, string>()
            {
                { "k1", "v1"},
                { "k2", "v2"}
            };
            var setTagsOp = await aset1.StartSetTagsAsync(tags1);
            GenericResource aset2 = await setTagsOp.WaitForCompletionAsync();
            var removeTagOp = await aset2.StartRemoveTagAsync("k1");
            GenericResource aset3 = await removeTagOp.WaitForCompletionAsync();
            var tags2 = new Dictionary<string, string>()
            {
                { "k2", "v2"}
            };
            Assert.AreEqual(tags2, aset3.Data.Tags);
            Assert.AreEqual(aset1.Data.Id, aset3.Data.Id);
            Assert.AreEqual(aset1.Data.Name, aset3.Data.Name);
            Assert.AreEqual(aset1.Data.Type, aset3.Data.Type);
            Assert.AreEqual(aset1.Data.Location, aset3.Data.Location);
            Assert.AreEqual(aset1.Data.Plan, aset3.Data.Plan);
            Assert.AreEqual(aset1.Data.Properties, aset3.Data.Properties);
            Assert.AreEqual(aset1.Data.Kind, aset3.Data.Kind);
            Assert.AreEqual(aset1.Data.ManagedBy, aset3.Data.ManagedBy);
            Assert.AreEqual(aset1.Data.Sku, aset3.Data.Sku);
            Assert.AreEqual(aset1.Data.Identity, aset3.Data.Identity);
        }
    }
}
