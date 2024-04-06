using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            GenericResource aset2 = null;
            for (int i = 0; i < 3; i++)
            {
                // Retry due to the delay of resource creation
                var genericResources = subscription.GetGenericResourcesAsync();
                await foreach (GenericResource resource in genericResources)
                {
                    if (resource.Data.Id == aset.Data.Id)
                    {
                        aset2 = resource;
                        break;
                    }
                }
                if (aset2 != null)
                    break;
            }

            AssertAreEqual(aset, aset2);

            var genericResourceCollection = Client.GetGenericResources();
            var resourceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1/providers/Microsoft.Compute/availabilitySets/foo-1";
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await genericResourceCollection.GetAsync(new ResourceIdentifier(resourceId)));
            resourceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1/providers/Microsoft.Compute/fake/foo-1";
            Assert.ThrowsAsync<InvalidOperationException>(async () => _ = await genericResourceCollection.GetAsync(new ResourceIdentifier(resourceId)));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg1 = rg1Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            var rg2Op = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg2 = rg2Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg2.Id);

            var count = await GetResourceCountAsync(subscription.GetGenericResourcesAsync());
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListWithExpand()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg1 = rg1Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            var rg2Op = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg2 = rg2Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg2.Id);

            int count = 0;
            //`createdTime`, `changedTime` and `provisioningState`
            await foreach (var genericResource in subscription.GetGenericResourcesAsync(expand: "createdTime"))
            {
                Assert.NotNull(genericResource.Data.CreatedOn);
                Assert.Null(genericResource.Data.ChangedOn);
                Assert.Null(genericResource.Data.ProvisioningState);
                count++;
            }

            //`createdTime`, `changedTime` and `provisioningState`
            await foreach (var genericResource in subscription.GetGenericResourcesAsync(expand: "changedTime,provisioningState"))
            {
                Assert.Null(genericResource.Data.CreatedOn);
                Assert.NotNull(genericResource.Data.ChangedOn);
                Assert.NotNull(genericResource.Data.ProvisioningState);
            }

            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListByResourceGroup()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg1 = rg1Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            var rg2Op = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg2 = rg2Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg2.Id);

            var count = await GetResourceCountAsync(rg1.GetGenericResourcesAsync());
            Assert.AreEqual(2, count);

            count = await GetResourceCountAsync(rg2.GetGenericResourcesAsync());
            Assert.AreEqual(1, count);

            //Assert.Throws<ArgumentNullException>(() => { genericResources.GetByResourceGroupAsync(null); });
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            Assert.IsTrue(await Client.GetGenericResources().ExistsAsync(aset.Data.Id));
            Assert.IsFalse(await Client.GetGenericResources().ExistsAsync(new ResourceIdentifier(aset.Data.Id + "1")));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg = rgOp.Value;
            Assert.DoesNotThrowAsync(async () => _ = await CreateGenericAvailabilitySetAsync(rg.Id));

            var genericResources = Client.GetGenericResources();
            var resourceId = rg.Id.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await genericResources.CreateOrUpdateAsync(WaitUntil.Completed, resourceId, null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await genericResources.CreateOrUpdateAsync(WaitUntil.Completed, null, ConstructGenericAvailabilitySet()));
            var rgId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await CreateGenericAvailabilitySetAsync(new ResourceIdentifier(rgId)));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg = rgOp.Value;
            Assert.DoesNotThrowAsync(async () =>
            {
                var createOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
                _ = await createOp.WaitForCompletionAsync();
            });

            var genericResources = Client.GetGenericResources();
            var resourceId = rg.Id.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var createOp = await genericResources.CreateOrUpdateAsync(WaitUntil.Started, resourceId, null);
                _ = await createOp.WaitForCompletionAsync();
            });
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var createOp = await genericResources.CreateOrUpdateAsync(WaitUntil.Started, null, ConstructGenericAvailabilitySet());
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
