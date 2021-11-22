using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class GenericResourceOperationsTests : ResourceManagerTestBase
    {
        public GenericResourceOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsConfirmException()
        {
            var rgName = Recording.GenerateAssetName("testrg");
            _ = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            var asetid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{rgName}/providers/Microsoft.Compute/availabilitySets/testavset";
            var genericResourceOperations = Client.GetGenericResource(new ResourceIdentifier(asetid));
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await genericResourceOperations.GetAsync());
            Assert.AreEqual(404, exception.Status);
            Assert.True(exception.Message.Contains("ResourceNotFound"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsBadNameSpace()
        {
            var rgName = Recording.GenerateAssetName("testrg");
            _ = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            var asetid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{rgName}/providers/Microsoft.NotAValidNameSpace123/availabilitySets/testavset";
            var genericResourceOperations = Client.GetGenericResource(new ResourceIdentifier(asetid));
            InvalidOperationException exception = Assert.ThrowsAsync<InvalidOperationException>(async () => await genericResourceOperations.GetAsync());
            Assert.IsTrue(exception.Message.Equals($"An invalid resouce id was given {asetid}"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsBadApiVersion()
        {
            var rgName = Recording.GenerateAssetName("testrg");
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            ResourceGroup rg = rgOp.Value;
            ArmClientOptions options = new ArmClientOptions();
            options.ApiVersions.SetApiVersion(rg.Id.ResourceType, "1500-10-10");
            var client = GetArmClient(options);
            var genericResourceOperations = client.GetGenericResource(rg.Id);
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await genericResourceOperations.GetAsync());
            Assert.IsTrue(exception.Message.Contains("InvalidApiVersionParameter"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsGoodApiVersion()
        {
            var rgName = Recording.GenerateAssetName("testrg");
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            ResourceGroup rg = rgOp.Value;
            var genericResourceOperations = Client.GetGenericResource(rg.Id);
            var genericResource = await genericResourceOperations.GetAsync();
            Assert.IsNotNull(genericResource.Value);
            Assert.IsTrue(genericResource.Value.Data.Name.Equals(rgName));
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            Assert.DoesNotThrowAsync(async () => await aset.DeleteAsync());

            var fakeId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await CreateGenericAvailabilitySetAsync(new ResourceIdentifier(fakeId)));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartDelete()
        {
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            var createOp = InstrumentOperation(await StartCreateGenericAvailabilitySetAsync(rg.Id));
            GenericResource aset = await createOp.WaitForCompletionAsync();

            Assert.DoesNotThrowAsync(async () =>
            {
                var deleteOp = await aset.DeleteAsync(false);
                _ = await deleteOp.WaitForCompletionResponseAsync();
            });

            var fakeId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var createOp = await StartCreateGenericAvailabilitySetAsync(new ResourceIdentifier(fakeId));
                _ = await createOp.WaitForCompletionAsync();
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task AddTag()
        {
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            Assert.AreEqual(0, aset.Data.Tags.Count);

            aset = await aset.AddTagAsync("key", "value");

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            GenericResource aset2 = await aset.GetAsync();

            AssertAreEqual(aset, aset2);

            ResourceIdentifier fakeId = new ResourceIdentifier(aset2.Id.ToString() + "x");
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => _ = await Client.GetGenericResource(new ResourceIdentifier(fakeId)).GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task SetTags()
        {
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            Assert.AreEqual(0, aset.Data.Tags.Count);

            Dictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("key", "value");
            aset = await aset.SetTagsAsync(tags);

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);
        }

        [TestCase]
        [RecordedTest]
        public async Task RemoveTag()
        {
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            Dictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("key", "value");
            aset = await aset.SetTagsAsync(tags);

            aset = await aset.RemoveTagAsync("key");

            Assert.IsFalse(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual(0, aset.Data.Tags.Count);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            var data = ConstructGenericAvailabilitySet();
            data.Tags.Add("key", "value");
            var asetOp = await aset.UpdateAsync(data);
            aset = asetOp.Value;

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await aset.UpdateAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartUpdate()
        {
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            var createOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
            GenericResource aset = await createOp.WaitForCompletionAsync();

            var data = ConstructGenericAvailabilitySet();
            data.Tags.Add("key", "value");
            var updateOp = await aset.UpdateAsync(data, false);
            aset = await updateOp.WaitForCompletionAsync();

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var updateOp = await aset.UpdateAsync(null, false);
                _ = await updateOp.WaitForCompletionAsync();
            });
        }
    }
}
