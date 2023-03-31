// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    [ClientTestFixture(true, "2022-09-01", "2019-10-01")]
    public class ResourceGroupOperationsTests : ResourceManagerTestBase
    {
        public ResourceGroupOperationsTests(bool isAsync, string apiVersion)
            : base(isAsync, ResourceGroupResource.ResourceType, apiVersion)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        [SyncOnly]
        public void NoDataValidation()
        {
            ////subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/myRg
            var resource = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Guid.NewGuid()}/resourceGroups/fakeRg"));
            Assert.Throws<InvalidOperationException>(() => { var data = resource.Data; });
        }

        [RecordedTest]
        public async Task DeleteRg()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgOp.Value;
            await rg.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task StartDeleteRg()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgOp.Value;
            var deleteOp = await rg.DeleteAsync(WaitUntil.Started);
            var response = deleteOp.GetRawResponse();
            Assert.AreEqual(202, response.Status);
            await deleteOp.UpdateStatusAsync();
            await deleteOp.WaitForCompletionResponseAsync();
            await deleteOp.WaitForCompletionResponseAsync(TimeSpan.FromSeconds(2));
        }

        [RecordedTest]
        public void StartDeleteNonExistantRg()
        {
            var rgOp = InstrumentClientExtension(Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/fake")));
            var deleteOpTask = rgOp.DeleteAsync(WaitUntil.Started);
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await deleteOpTask);
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            ResourceGroupResource rg2 = await rg1.GetAsync();
            Assert.AreEqual(rg1.Data.Name, rg2.Data.Name);
            Assert.AreEqual(rg1.Data.Id, rg2.Data.Id);
            Assert.AreEqual(rg1.Data.ResourceType, rg2.Data.ResourceType);
            Assert.AreEqual(rg1.Data.Properties.ProvisioningState, rg2.Data.Properties.ProvisioningState);
            Assert.AreEqual(rg1.Data.Location, rg2.Data.Location);
            Assert.AreEqual(rg1.Data.ManagedBy, rg2.Data.ManagedBy);
            Assert.AreEqual(rg1.Data.Tags, rg2.Data.Tags);

            ResourceIdentifier fakeId = new ResourceIdentifier(rg1.Data.Id.ToString() + "x");
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.GetResourceGroupResource(new ResourceIdentifier(fakeId)).GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [RecordedTest]
        public async Task Update()
        {
            var rgName = Recording.GenerateAssetName("testrg");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value"}
            };
            var rg1Op = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2, tags).CreateOrUpdateAsync(rgName);
            ResourceGroupResource rg1 = rg1Op.Value;
            var parameters = new ResourceGroupPatch
            {
                Name = rgName
            };
            ResourceGroupResource rg2 = await rg1.UpdateAsync(parameters);
            Assert.AreEqual(rg1.Data.Name, rg2.Data.Name);
            Assert.AreEqual(rg1.Data.Id, rg2.Data.Id);
            Assert.AreEqual(rg1.Data.ResourceType, rg2.Data.ResourceType);
            Assert.AreEqual(rg1.Data.Properties.ProvisioningState, rg2.Data.Properties.ProvisioningState);
            Assert.AreEqual(rg1.Data.Location, rg2.Data.Location);
            Assert.AreEqual(rg1.Data.ManagedBy, rg2.Data.ManagedBy);
            Assert.AreEqual(rg1.Data.Tags, rg2.Data.Tags);

            var parameters3 = new ResourceGroupPatch
            {
                Name = rgName,
                Tags = {} // This does not touch the ChangeTrackingDictionary and no tags property will be sent in the patch request.
            };
            ResourceGroupResource rg3 = await rg2.UpdateAsync(parameters3);
            Assert.AreEqual(rg1.Data.Tags, rg3.Data.Tags);

            var parameters4 = new ResourceGroupPatch
            {
                Name = rgName
            };
            parameters4.Tags.Clear();
            ResourceGroupResource rg4 = await rg3.UpdateAsync(parameters4);
            Assert.AreEqual(0, rg4.Data.Tags.Count);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg1.UpdateAsync(null));
        }

        [RecordedTest]
        public async Task StartExportTemplate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgOp.Value;
            var parameters = new ExportTemplate();
            parameters.Resources.Add("*");
            var expOp = await rg.ExportTemplateAsync(WaitUntil.Started, parameters);
            await expOp.WaitForCompletionAsync();

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var expOp = await rg.ExportTemplateAsync(WaitUntil.Started, null);
                _ = await expOp.WaitForCompletionAsync();
            });
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            Assert.AreEqual(0, rg1.Data.Tags.Count);
            ResourceGroupResource rg2 = await rg1.AddTagAsync("key", "value");
            Assert.AreEqual(1, rg2.Data.Tags.Count);
            Assert.IsTrue(rg2.Data.Tags.Contains(new KeyValuePair<string, string>("key", "value")));
            Assert.AreEqual(rg1.Data.Name, rg2.Data.Name);
            Assert.AreEqual(rg1.Data.Id, rg2.Data.Id);
            Assert.AreEqual(rg1.Data.ResourceType, rg2.Data.ResourceType);
            Assert.AreEqual(rg1.Data.Properties.ProvisioningState, rg2.Data.Properties.ProvisioningState);
            Assert.AreEqual(rg1.Data.Location, rg2.Data.Location);
            Assert.AreEqual(rg1.Data.ManagedBy, rg2.Data.ManagedBy);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg1.AddTagAsync(null, "value"));
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => _ = await rg1.AddTagAsync(" ", "value"));
            Assert.AreEqual(400, ex.Status);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            Assert.AreEqual(0, rg1.Data.Tags.Count);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value"}
            };
            ResourceGroupResource rg2 = await rg1.SetTagsAsync(tags);
            Assert.AreEqual(tags, rg2.Data.Tags);
            Assert.AreEqual(rg1.Data.Name, rg2.Data.Name);
            Assert.AreEqual(rg1.Data.Id, rg2.Data.Id);
            Assert.AreEqual(rg1.Data.ResourceType, rg2.Data.ResourceType);
            Assert.AreEqual(rg1.Data.Properties.ProvisioningState, rg2.Data.Properties.ProvisioningState);
            Assert.AreEqual(rg1.Data.Location, rg2.Data.Location);
            Assert.AreEqual(rg1.Data.ManagedBy, rg2.Data.ManagedBy);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg1.SetTagsAsync(null));
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task RemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            var tags = new Dictionary<string, string>()
            {
                { "k1", "v1"},
                { "k2", "v2"}
            };
            rg1 = await rg1.SetTagsAsync(tags);
            ResourceGroupResource rg2 = await rg1.RemoveTagAsync("k1");
            var tags2 = new Dictionary<string, string>()
            {
                { "k2", "v2"}
            };
            Assert.AreEqual(tags2, rg2.Data.Tags);
            Assert.AreEqual(rg1.Data.Name, rg2.Data.Name);
            Assert.AreEqual(rg1.Data.Id, rg2.Data.Id);
            Assert.AreEqual(rg1.Data.ResourceType, rg2.Data.ResourceType);
            Assert.AreEqual(rg1.Data.Properties.ProvisioningState, rg2.Data.Properties.ProvisioningState);
            Assert.AreEqual(rg1.Data.Location, rg2.Data.Location);
            Assert.AreEqual(rg1.Data.ManagedBy, rg2.Data.ManagedBy);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg1.RemoveTagAsync(null));
            Assert.DoesNotThrowAsync(async () => rg2 = await rg1.RemoveTagAsync(" "));
            //removing something that wasn't there should not have changed the tags
            Assert.AreEqual(tags2, rg2.Data.Tags);
        }

        [RecordedTest]
        public async Task ListAvailableLocations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgOp.Value;
            var locations = await rg.GetAvailableLocationsAsync();
            int count = 0;
            foreach (var location in locations.Value)
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [RecordedTest]
        public async Task MoveResources()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            var rg2Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            ResourceGroupResource rg2 = rg2Op.Value;
            var genericResources = subscription.GetGenericResourcesAsync();
            var aset = await CreateGenericAvailabilitySetAsync(rg1.Id);

            int countRg1 = await GetResourceCountAsync(rg1.GetGenericResourcesAsync());
            int countRg2 = await GetResourceCountAsync(rg2.GetGenericResourcesAsync());
            Assert.AreEqual(1, countRg1);
            Assert.AreEqual(0, countRg2);

            var moveInfo = new ResourcesMoveContent();
            moveInfo.TargetResourceGroup = rg2.Id;
            moveInfo.Resources.Add(aset.Id);
            _ = await rg1.MoveResourcesAsync(WaitUntil.Completed, moveInfo);

            countRg1 = await GetResourceCountAsync(rg1.GetGenericResourcesAsync());
            countRg2 = await GetResourceCountAsync(rg2.GetGenericResourcesAsync());
            Assert.AreEqual(0, countRg1);
            Assert.AreEqual(1, countRg2);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg1.MoveResourcesAsync(WaitUntil.Completed, null));
        }

        [RecordedTest]
        public async Task StartMoveResources()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            var rg2Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            ResourceGroupResource rg2 = rg2Op.Value;
            var genericResources = subscription.GetGenericResourcesAsync();
            var asetOp = await StartCreateGenericAvailabilitySetAsync(rg1.Id);
            GenericResource aset = await asetOp.WaitForCompletionAsync();

            int countRg1 = await GetResourceCountAsync(rg1.GetGenericResourcesAsync());
            int countRg2 = await GetResourceCountAsync(rg2.GetGenericResourcesAsync());
            Assert.AreEqual(1, countRg1);
            Assert.AreEqual(0, countRg2);

            var moveInfo = new ResourcesMoveContent();
            moveInfo.TargetResourceGroup = rg2.Id;
            moveInfo.Resources.Add(aset.Id);
            var moveOp = await rg1.MoveResourcesAsync(WaitUntil.Started, moveInfo);
            _ = await moveOp.WaitForCompletionResponseAsync();

            countRg1 = await GetResourceCountAsync(rg1.GetGenericResourcesAsync());
            countRg2 = await GetResourceCountAsync(rg2.GetGenericResourcesAsync());
            Assert.AreEqual(0, countRg1);
            Assert.AreEqual(1, countRg2);

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var moveOp = await rg1.MoveResourcesAsync(WaitUntil.Started, null);
                _ = await moveOp.WaitForCompletionResponseAsync();
            });
        }

        [RecordedTest]
        public async Task ValidateMoveResources()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            var rg2Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            ResourceGroupResource rg2 = rg2Op.Value;
            var aset = await CreateGenericAvailabilitySetAsync(rg1.Id);

            var moveInfo = new ResourcesMoveContent();
            moveInfo.TargetResourceGroup = rg2.Id;
            moveInfo.Resources.Add(aset.Id);
            var validateOp = await rg1.ValidateMoveResourcesAsync(WaitUntil.Completed, moveInfo);
            Response response = validateOp.GetRawResponse();

            Assert.AreEqual(204, response.Status);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg1.ValidateMoveResourcesAsync(WaitUntil.Completed, null));
        }

        [RecordedTest]
        public async Task StartValidateMoveResources()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rg1Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            var rg2Op = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testrg"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg1 = rg1Op.Value;
            ResourceGroupResource rg2 = rg2Op.Value;
            var asetOp = await StartCreateGenericAvailabilitySetAsync(rg1.Id);
            GenericResource aset = await asetOp.WaitForCompletionAsync();

            var moveInfo = new ResourcesMoveContent();
            moveInfo.TargetResourceGroup = rg2.Id;
            moveInfo.Resources.Add(aset.Id);
            var validateOp = await rg1.ValidateMoveResourcesAsync(WaitUntil.Started, moveInfo);
            Response response = await validateOp.WaitForCompletionResponseAsync();

            Assert.AreEqual(204, response.Status);

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var moveOp = await rg1.ValidateMoveResourcesAsync(WaitUntil.Started, null);
                _ = await moveOp.WaitForCompletionResponseAsync();
            });
        }
    }
}
