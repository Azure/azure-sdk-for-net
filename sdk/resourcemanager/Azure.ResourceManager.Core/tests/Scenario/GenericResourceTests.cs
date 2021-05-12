using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class GenericResourceTests : ResourceManagerTestBase
    {
        private string _rgName;

        private readonly string _location = "southcentralus";

        public GenericResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task LocalOneTimeSetup()
        {
            _rgName = SessionRecording.GenerateAssetName("testRg-");
            var subscription = await GlobalClient.GetSubscriptions().TryGetAsync(SessionEnvironment.SubscriptionId);
            _ = await subscription.GetResourceGroups().Construct(_location).StartCreateOrUpdateAsync(_rgName).ConfigureAwait(false);
            StopSessionRecording();
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsConfirmException()
        {
            var asetid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}/providers/Microsoft.Compute/availabilitySets/testavset";
            ArmClientOptions options = new ArmClientOptions();
            _ = GetArmClient(options); // setup providers client
            var subOp = await Client.GetSubscriptions().TryGetAsync(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, asetid);
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await genericResourceOperations.GetAsync());
            Assert.AreEqual(404, exception.Status);
            Assert.True(exception.Message.Contains("ResourceNotFound"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsBadNameSpace()
        {
            var asetid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}/providers/Microsoft.NotAValidNameSpace123/availabilitySets/testavset";
            ArmClientOptions options = new ArmClientOptions();
            _ = GetArmClient(options); // setup providers client
            var subOp = await Client.GetSubscriptions().TryGetAsync(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, asetid);
            InvalidOperationException exception = Assert.ThrowsAsync<InvalidOperationException>(async () => await genericResourceOperations.GetAsync());
            Assert.IsTrue(exception.Message.Equals($"An invalid resouce id was given {asetid}"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsBadApiVersion()
        {
            ResourceGroupResourceIdentifier rgid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}";
            ArmClientOptions options = new ArmClientOptions();
            options.ApiVersions.SetApiVersion(rgid.ResourceType, "1500-10-10");
            var client = GetArmClient(options);
            var subOp = await client.GetSubscriptions().TryGetAsync(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, rgid);
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await genericResourceOperations.GetAsync());
            Assert.IsTrue(exception.Message.Contains("InvalidApiVersionParameter"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsGoodApiVersion()
        {
            ResourceGroupResourceIdentifier rgid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}";
            ArmClientOptions options = new ArmClientOptions();
            var client = GetArmClient(options);
            var subOp = await client.GetSubscriptions().TryGetAsync(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, rgid);
            var rg = await genericResourceOperations.GetAsync();
            Assert.IsNotNull(rg.Value);
            Assert.IsTrue(rg.Value.Data.Name.Equals(_rgName));
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            Assert.DoesNotThrowAsync(async () => await aset.DeleteAsync());
        }

        [TestCase]
        [RecordedTest]
        public async Task StartDelete()
        {
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            var asetOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
            GenericResource aset = await asetOp.WaitForCompletionAsync();

            Assert.DoesNotThrowAsync(async () => {
                var deleteOp = await aset.StartDeleteAsync();
                _ = await deleteOp.WaitForCompletionResponseAsync();
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task AddTag()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            aset = await aset.AddTagAsync("key", "value");

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartAddTag()
        {
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            var asetOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
            GenericResource aset = await asetOp.WaitForCompletionAsync();

            var addTagOp = await aset.StartAddTagAsync("key", "value");
            aset = await addTagOp.WaitForCompletionAsync();

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            GenericResource aset2 = await aset.GetAsync();

            AssertAreEqual(aset, aset2);
        }

        [TestCase]
        [RecordedTest]
        public async Task SetTags()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            Dictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("key", "value");
            aset = await aset.SetTagsAsync(tags);

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartSetTags()
        {
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            var asetOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
            GenericResource aset = await asetOp.WaitForCompletionAsync();

            Dictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("key", "value");
            var setTagsOp = await aset.StartSetTagsAsync(tags);
            aset = await setTagsOp.WaitForCompletionAsync();

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);
        }

        [TestCase]
        [RecordedTest]
        public async Task RemoveTag()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            Dictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("key", "value");
            aset = await aset.SetTagsAsync(tags);

            aset = await aset.RemoveTagAsync("key");

            Assert.IsFalse(aset.Data.Tags.ContainsKey("key"));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartRemoveTag()
        {
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            var asetOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
            GenericResource aset = await asetOp.WaitForCompletionAsync();

            Dictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("key", "value");
            var setTagsOp = await aset.StartSetTagsAsync(tags);
            aset = await setTagsOp.WaitForCompletionAsync();

            var removeTagOp = await aset.StartRemoveTagAsync("key");
            aset = await removeTagOp.WaitForCompletionAsync();

            Assert.IsFalse(aset.Data.Tags.ContainsKey("key"));
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            var data = ConstructGenericAvailabilitySet();
            data.Tags.Add("key", "value");
            aset = await aset.UpdateAsync(data);

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartUpdate()
        {
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            var asetOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
            GenericResource aset = await asetOp.WaitForCompletionAsync();

            var data = ConstructGenericAvailabilitySet();
            data.Tags.Add("key", "value");
            var updateOp = await aset.StartUpdateAsync(data);
            aset = await updateOp.WaitForCompletionAsync();

            Assert.IsTrue(aset.Data.Tags.ContainsKey("key"));
            Assert.AreEqual("value", aset.Data.Tags["key"]);
        }
    }
}
