using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
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
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            var genericResources = subscription.GetGenericResourcesAsync();

            GenericResource aset2 = null;
            await foreach (GenericResource resource in genericResources)
            {
                if (resource.Data.Id == aset.Data.Id)
                {
                    aset2 = resource;
                    break;
                }
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg1 = rg1Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            var rg2Op = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg2 = rg2Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg2.Id);

            var count = await GetResourceCountAsync(subscription.GetGenericResourcesAsync());
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListWithExpand()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg1 = rg1Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            var rg2Op = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg2 = rg2Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg2.Id);

            int count = 0;
            //`createdTime`, `changedTime` and `provisioningState`
            await foreach (var genericResource in subscription.GetGenericResourcesAsync(expand: "createdTime"))
            {
                Assert.NotNull(genericResource.Data.CreatedTime);
                Assert.Null(genericResource.Data.ChangedTime);
                Assert.Null(genericResource.Data.ProvisioningState);
                count++;
            }

            //`createdTime`, `changedTime` and `provisioningState`
            await foreach (var genericResource in subscription.GetGenericResourcesAsync(expand: "changedTime,provisioningState"))
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
            var rg1Op = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg1 = rg1Op.Value;
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            _ = await CreateGenericAvailabilitySetAsync(rg1.Id);
            var rg2Op = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg2 = rg2Op.Value;
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            Assert.IsTrue(await Client.GetGenericResources().ExistsAsync(aset.Data.Id));
            Assert.IsFalse(await Client.GetGenericResources().ExistsAsync(new ResourceIdentifier(aset.Data.Id + "1")));
        }

        [TestCase]
        [RecordedTest]
        public async Task TryGet()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg.Id);

            GenericResource resource = await Client.GetGenericResources().GetIfExistsAsync(aset.Data.Id);
            Assert.AreEqual(aset.Data.Id, resource.Data.Id);

            var response = await Client.GetGenericResources().GetIfExistsAsync(new ResourceIdentifier(aset.Data.Id + "1"));
            Assert.IsNull(response.Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            Assert.DoesNotThrowAsync(async () => _ = await CreateGenericAvailabilitySetAsync(rg.Id));

            var genericResources = Client.GetGenericResources();
            var resourceId = rg.Id.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await genericResources.CreateOrUpdateAsync(true, resourceId, null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await genericResources.CreateOrUpdateAsync(true, null, ConstructGenericAvailabilitySet()));
            var rgId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await CreateGenericAvailabilitySetAsync(new ResourceIdentifier(rgId)));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = rgOp.Value;
            Assert.DoesNotThrowAsync(async () =>
            {
                var createOp = await StartCreateGenericAvailabilitySetAsync(rg.Id);
                _ = await createOp.WaitForCompletionAsync();
            });

            var genericResources = Client.GetGenericResources();
            var resourceId = rg.Id.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var createOp = await genericResources.CreateOrUpdateAsync(false, resourceId, null);
                _ = await createOp.WaitForCompletionAsync();
            });
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var createOp = await genericResources.CreateOrUpdateAsync(false, null, ConstructGenericAvailabilitySet());
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
