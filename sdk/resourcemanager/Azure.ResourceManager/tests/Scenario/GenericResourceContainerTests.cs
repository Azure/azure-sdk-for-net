using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class GenericResourceContainerTests : ResourceManagerTestBase
    {
        public GenericResourceContainerTests(bool isAsync)
         : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            var genericResources = Client.DefaultSubscription.GetGenericResources();
            GenericResource aset2 = await genericResources.GetAsync(aset.Data.Id);

            AssertAreEqual(aset, aset2);

            var resourceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1/providers/Microsoft.Compute/availabilitySets/foo-1";
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await genericResources.GetAsync(resourceId));
            resourceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1/providers/Microsoft.Compute/fake/foo-1";
            Assert.ThrowsAsync<InvalidOperationException>(async () => _ = await genericResources.GetAsync(resourceId));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            ResourceGroup rg1 = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            ResourceGroup rg2 = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            _ = await CreateGenericAvailabilitySetAsync(rg2.Id);

            var count = await GetResourceCountAsync(Client.DefaultSubscription.GetGenericResources());
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListWithExpand()
        {
            ResourceGroup rg1 = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            ResourceGroup rg2 = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            _ = await CreateGenericAvailabilitySetAsync(rg2.Id);

            int count = 0;
            //`createdTime`, `changedTime` and `provisioningState`
            await foreach (var genericResource in Client.DefaultSubscription.GetGenericResources().GetAllAsync(expand: "createdTime"))
            {
                Assert.NotNull(genericResource.Data.CreatedTime);
                Assert.Null(genericResource.Data.ChangedTime);
                Assert.Null(genericResource.Data.ProvisioningState);
                count++;
            }

            //`createdTime`, `changedTime` and `provisioningState`
            await foreach (var genericResource in Client.DefaultSubscription.GetGenericResources().GetAllAsync(expand: "changedTime,provisioningState"))
            {
                Assert.Null(genericResource.Data.CreatedTime);
                Assert.NotNull(genericResource.Data.ChangedTime);
                Assert.NotNull(genericResource.Data.ProvisioningState);
            }

            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListByResourceGroup()
        {
            ResourceGroup rg1 = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            ResourceGroup rg2 = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            _ = await CreateGenericAvailabilitySetAsync(rg2.Id);

            var genericResources = Client.DefaultSubscription.GetGenericResources();

            var count = await GetResourceCountAsync(genericResources, rg1);
            Assert.AreEqual(2, count);

            count = await GetResourceCountAsync(genericResources, rg2);
            Assert.AreEqual(1, count);

            Assert.Throws<ArgumentNullException>(() => { genericResources.GetByResourceGroupAsync(null); });
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            Assert.IsTrue(await Client.DefaultSubscription.GetGenericResources().CheckIfExistsAsync(aset.Data.Id));
            Assert.IsFalse(await Client.DefaultSubscription.GetGenericResources().CheckIfExistsAsync(aset.Data.Id + "1"));
        }

        [TestCase]
        [RecordedTest]
        public async Task TryGet()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            GenericResource resource = await Client.DefaultSubscription.GetGenericResources().GetIfExistsAsync(aset.Data.Id);
            Assert.AreEqual(aset.Data.Id, resource.Data.Id);

            var response = await Client.DefaultSubscription.GetGenericResources().GetIfExistsAsync(aset.Data.Id + "1");
            Assert.IsNull(response.Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            Assert.DoesNotThrowAsync(async () => _ = await CreateGenericAvailabilitySetAsync(rg.Id));

            var genericResources = Client.DefaultSubscription.GetGenericResources();
            var resourceId = rg.Id.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await genericResources.CreateOrUpdateAsync(resourceId, null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await genericResources.CreateOrUpdateAsync(null, ConstructGenericAvailabilitySet()));
            var rgId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await CreateGenericAvailabilitySetAsync(rgId));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).StartCreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            Assert.DoesNotThrowAsync(async () =>
            {
                var createOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
                _ = await createOp.WaitForCompletionAsync();
            });

            var genericResources = Client.DefaultSubscription.GetGenericResources();
            var resourceId = rg.Id.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var createOp = await genericResources.StartCreateOrUpdateAsync(resourceId, null);
                _ = await createOp.WaitForCompletionAsync();
            });
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var createOp = await genericResources.StartCreateOrUpdateAsync(null, ConstructGenericAvailabilitySet());
                _ = await createOp.WaitForCompletionAsync();
            });
            var rgId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var createOp = await StartCreateGenericAvailabilitySetAsync(rgId);
                _ = await createOp.WaitForCompletionAsync();
            });
        }
    }
}
