using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class GenericResourceCollectionTests : ResourceManagerTestBase
    {
        public GenericResourceCollectionTests(bool isAsync)
         : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            var genericResources = subscription.GetGenericResources();
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg1 = rg1Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            var rg2Op = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg2 = rg2Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg2.Id);

            var count = await GetResourceCountAsync(subscription.GetGenericResources());
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListWithExpand()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg1 = rg1Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            var rg2Op = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg2 = rg2Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg2.Id);

            int count = 0;
            //`createdTime`, `changedTime` and `provisioningState`
            await foreach (var genericResource in subscription.GetGenericResources().GetAllAsync(expand: "createdTime"))
            {
                Assert.NotNull(genericResource.Data.CreatedTime);
                Assert.Null(genericResource.Data.ChangedTime);
                Assert.Null(genericResource.Data.ProvisioningState);
                count++;
            }

            //`createdTime`, `changedTime` and `provisioningState`
            await foreach (var genericResource in subscription.GetGenericResources().GetAllAsync(expand: "changedTime,provisioningState"))
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg1 = rg1Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            var rg2Op = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg2 = rg2Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg2.Id);

            var genericResources = subscription.GetGenericResources();

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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            Assert.IsTrue(await subscription.GetGenericResources().CheckIfExistsAsync(aset.Data.Id));
            Assert.IsFalse(await subscription.GetGenericResources().CheckIfExistsAsync(aset.Data.Id + "1"));
        }

        [TestCase]
        [RecordedTest]
        public async Task TryGet()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            GenericResource resource = await subscription.GetGenericResources().GetIfExistsAsync(aset.Data.Id);
            Assert.AreEqual(aset.Data.Id, resource.Data.Id);

            var response = await subscription.GetGenericResources().GetIfExistsAsync(aset.Data.Id + "1");
            Assert.IsNull(response.Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            Assert.DoesNotThrowAsync(async () => _ = await CreateGenericAvailabilitySetAsync(rg.Id));

            var genericResources = subscription.GetGenericResources();
            var resourceId = rg.Id.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await genericResources.CreateOrUpdateAsync(resourceId, null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await genericResources.CreateOrUpdateAsync(null, ConstructGenericAvailabilitySet()));
            var rgId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await CreateGenericAvailabilitySetAsync(new ResourceIdentifier(rgId)));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            Assert.DoesNotThrowAsync(async () =>
            {
                var createOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
                _ = await createOp.WaitForCompletionAsync();
            });

            var genericResources = subscription.GetGenericResources();
            var resourceId = rg.Id.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var createOp = await genericResources.CreateOrUpdateAsync(resourceId, null, false);
                _ = await createOp.WaitForCompletionAsync();
            });
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var createOp = await genericResources.CreateOrUpdateAsync(null, ConstructGenericAvailabilitySet(), false);
                _ = await createOp.WaitForCompletionAsync();
            });
            var rgId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var createOp = await StartCreateGenericAvailabilitySetAsync(new ResourceIdentifier(rgId));
                _ = await createOp.WaitForCompletionAsync();
            });
        }
    }
}
