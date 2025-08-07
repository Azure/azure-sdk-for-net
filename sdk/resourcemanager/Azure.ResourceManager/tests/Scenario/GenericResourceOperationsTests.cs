using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
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
            _ = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(rgName);
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
            _ = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(rgName);
            var asetid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{rgName}/providers/Microsoft.NotAValidNameSpace123/availabilitySets/testavset";
            var genericResourceOperations = Client.GetGenericResource(new ResourceIdentifier(asetid));
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await genericResourceOperations.GetAsync());
            Assert.AreEqual(404, exception.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsBadApiVersion()
        {
            var rgName = Recording.GenerateAssetName("testrg");
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(rgName);
            ResourceGroupResource rg = rgOp.Value;
            ArmClientOptions options = new ArmClientOptions();
            options.SetApiVersion(rg.Id.ResourceType, "1500-10-10");
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
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(rgName);
            ResourceGroupResource rg = rgOp.Value;
            var genericResourceOperations = Client.GetGenericResource(rg.Id);
            var genericResource = await genericResourceOperations.GetAsync();
            Assert.IsNotNull(genericResource.Value);
            Assert.IsTrue(genericResource.Value.Data.Name.Equals(rgName));
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            Assert.DoesNotThrowAsync(async () => await aset.DeleteAsync(WaitUntil.Completed));

            var fakeId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await CreateGenericAvailabilitySetAsync(new ResourceIdentifier(fakeId)));
        }

        [TestCase]
        [RecordedTest]
        [LiveOnly] // Playback error: Fast polling interval of 00:00:00 detected in playback mode. Please use the default WaitForCompletion(). The test framework would automatically reduce the interval in playback.
        public async Task StartDelete()
        {
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg = rgOp.Value;
            var createOp = InstrumentOperation(await StartCreateGenericAvailabilitySetAsync(rg.Id));
            GenericResource aset = await createOp.WaitForCompletionAsync();

            Assert.DoesNotThrowAsync(async () =>
            {
                var deleteOp = await aset.DeleteAsync(WaitUntil.Started);
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
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            Assert.AreEqual(0, aset.Data.Tags.Count);

            aset = await aset.AddTagAsync("key", "value");

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);
            Assert.AreEqual(1, aset.Data.Tags.Count);

            GenericResource aset2 = await aset.AddTagAsync("key2", "value2");

            Assert.IsTrue(aset2.Data.Tags.ContainsKey("key2"));
            Assert.AreEqual("value2", aset2.Data.Tags["key2"]);
            Assert.AreEqual(2, aset2.Data.Tags.Count);

            GenericResource aset3 = await aset2.AddTagAsync("key", "value3");

            Assert.IsTrue(aset3.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value3", aset3.Data.Tags["key"]);
            Assert.AreEqual(2, aset3.Data.Tags.Count);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg = rgOp.Value;
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
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            Assert.AreEqual(0, aset.Data.Tags.Count);

            Dictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("key", "value");
            aset = await aset.SetTagsAsync(tags);

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);
            Assert.AreEqual(1, aset.Data.Tags.Count);

            Dictionary<string, string> tags2 = new Dictionary<string, string>();
            tags2.Add("key2", "value2");
            GenericResource aset2 = await aset.SetTagsAsync(tags2);

            Assert.IsTrue(aset2.Data.Tags.ContainsKey("key2"));
            Assert.AreEqual("value2", aset2.Data.Tags["key2"]);
            Assert.AreEqual(1, aset2.Data.Tags.Count);
        }

        [TestCase]
        [RecordedTest]
        public async Task RemoveTag()
        {
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            Dictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("key", "value");
            tags.Add("key2", "value2");
            aset = await aset.SetTagsAsync(tags);

            Assert.AreEqual(2, aset.Data.Tags.Count);

            aset = await aset.RemoveTagAsync("key");

            Assert.IsFalse(aset.Data.Tags.ContainsKey("key"));
            Assert.IsTrue(aset.Data.Tags.ContainsKey("key2"));
            Assert.AreEqual(1, aset.Data.Tags.Count);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            var data = ConstructGenericAvailabilitySet();
            data.Tags.Add("key", "value");
            var asetOp = await aset.UpdateAsync(WaitUntil.Completed, data);
            aset = asetOp.Value;

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);

            var data2 = ConstructGenericAvailabilitySet();
            var asetOp2 = await aset.UpdateAsync(WaitUntil.Completed, data2);
            aset = asetOp2.Value;
            // Tags should not be changed with Tags:{} when constructing GenericResourceData
            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);

            data2.Tags.Clear();
            var asetOp3 = await aset.UpdateAsync(WaitUntil.Completed, data2);
            Assert.AreEqual(0, asetOp3.Value.Data.Tags.Count);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await aset.UpdateAsync(WaitUntil.Completed, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartUpdate()
        {
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg = rgOp.Value;
            var createOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
            GenericResource aset = await createOp.WaitForCompletionAsync();

            var data = ConstructGenericAvailabilitySet();
            data.Tags.Add("key", "value");
            var updateOp = await aset.UpdateAsync(WaitUntil.Started, data);
            aset = await updateOp.WaitForCompletionAsync();

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var updateOp = await aset.UpdateAsync(WaitUntil.Started, null);
                _ = await updateOp.WaitForCompletionAsync();
            });
        }

        [Test]
        [RecordedTest]
        public async Task CreateWithApiVersionSetting()
        {
            var options = new ArmClientOptions();
            options.SetApiVersion(new ResourceType("Microsoft.Compute/test"), "2022-09-01");
            var client = GetArmClient(options);
            var rgOp = await (await client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            GenericResourceData data = ConstructGenericAvailabilitySet();
            var asetId = rgOp.Value.Id.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
            var op = await client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, asetId, data);
            Assert.NotNull(op.Value);
        }
    }
}
