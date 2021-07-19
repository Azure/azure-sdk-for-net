using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core.Extensions;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class GenericResourceExpandedOperationsTests : ResourceManagerTestBase
    {
        private const string GenericResourceExpandString = "createdTime,changedTime,provisioningState";

        public GenericResourceExpandedOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            var resExp = await GetGenericResourceExpandedAsync(aset.Id, null, GenericResourceExpandString);
            Assert.DoesNotThrowAsync(async () => await resExp.DeleteAsync());
        }

        [TestCase]
        [RecordedTest]
        public async Task StartDelete()
        {
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).StartCreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            var createOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
            GenericResource aset = await createOp.WaitForCompletionAsync();

            var resExp = await GetGenericResourceExpandedAsync(aset.Id, null, GenericResourceExpandString);
            Assert.DoesNotThrowAsync(async () =>
            {
                var deleteOp = await resExp.StartDeleteAsync();
                _ = await deleteOp.WaitForCompletionResponseAsync();
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task AddTag()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            var resExp = await GetGenericResourceExpandedAsync(aset.Id, null, GenericResourceExpandString);
            Assert.AreEqual(0, resExp.Data.Tags.Count);
            aset = await resExp.AddTagAsync("key", "value");

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);
        }

        [TestCase]
        [RecordedTest]
        public async Task SetTags()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            var resExp = await GetGenericResourceExpandedAsync(aset.Id, null, GenericResourceExpandString);
            Assert.AreEqual(0, resExp.Data.Tags.Count);

            Dictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("key", "value");
            aset = await resExp.SetTagsAsync(tags);

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);
        }

        [TestCase]
        [RecordedTest]
        public async Task RemoveTag()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            var resExp = await GetGenericResourceExpandedAsync(aset.Id, null, GenericResourceExpandString);
            Dictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("key", "value");
            _ = await resExp.SetTagsAsync(tags);

            aset = await resExp.RemoveTagAsync("key");

            Assert.IsFalse(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual(0, aset.Data.Tags.Count);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            var resExp = await GetGenericResourceExpandedAsync(aset.Id, null, GenericResourceExpandString);
            var data = ConstructGenericAvailabilitySet();
            data.Tags.Add("key", "value");
            aset = await resExp.UpdateAsync(data);

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await resExp.UpdateAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartUpdate()
        {
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).StartCreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            var createOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
            GenericResource aset = await createOp.WaitForCompletionAsync();

            var resExp = await GetGenericResourceExpandedAsync(aset.Id, null, GenericResourceExpandString);
            var data = ConstructGenericAvailabilitySet();
            data.Tags.Add("key", "value");
            var updateOp = await resExp.StartUpdateAsync(data);
            aset = await updateOp.WaitForCompletionAsync();

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var updateOp = await resExp.StartUpdateAsync(null);
                _ = await updateOp.WaitForCompletionAsync();
            });
        }

        private async Task<GenericResourceExpanded> GetGenericResourceExpandedAsync(
            ResourceIdentifier resourceId,
            string filter = default,
            string expand = default)
        {
            var resExp = await (Client.DefaultSubscription.GetGenericResources()
                .ListAsync(filter, expand)
                .FirstOrDefaultAsync(r => r.Id.Equals(resourceId)));

            Assert.NotNull(resExp);
            Assert.NotNull(resExp.Data.CreatedTime);
            Assert.NotNull(resExp.Data.ChangedTime);
            Assert.IsFalse(string.IsNullOrWhiteSpace(resExp.Data.ProvisioningState));

            return resExp;
        }
    }
}
