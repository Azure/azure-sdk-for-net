using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class LroRehydrationTests : ResourceManagerTestBase
    {
        public LroRehydrationTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDeleteResourceGroup()
        {
            string rgName = Recording.GenerateAssetName("testLroRg-");
            var tags = new Dictionary<string, string>()
            {
                { "key", "value"}
            };
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            // The creation of a resource group is a fake LRO
            var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, rgName, new ResourceGroupData());
            await rgOp.UpdateStatusAsync();
            //await rgOp.WaitForCompletionAsync();
            var rgOpId = rgOp.Id;
            var rg = rgOp.Value;
            Assert.Throws<ArgumentException>(() => new ArmOperation<ResourceGroupData>(Client, rgOpId));
            var response = rgOp.GetRawResponse();

            // Template exportation is a real LRO with generic type
            var parameters = new ExportTemplate();
            parameters.Resources.Add("*");
            await CreateGenericAvailabilitySetAsync(rg.Id);
            var genericResources = Client.GetGenericResources();
            for (int i = 0; i < 20; i++)
            {
                var resourceId = rg.Id.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
                await genericResources.CreateOrUpdateAsync(WaitUntil.Completed, resourceId, ConstructGenericAvailabilitySet());
            }
            var expOp = await Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(subscription.Id.SubscriptionId, rgName)).ExportTemplateAsync(WaitUntil.Started, parameters);
            var expOpId = expOp.Id;
            var modelRehydratedLro = new ArmOperation<ResourceGroupExportResult>(Client, expOpId);
            await modelRehydratedLro.WaitForCompletionResponseAsync();
            Assert.AreEqual(modelRehydratedLro.HasValue, true);
            var rehydratedResult = modelRehydratedLro.Value;
            await expOp.UpdateStatusAsync();
            var result = expOp.Value;
            Assert.AreEqual(JsonSerializer.Serialize(result.Template), JsonSerializer.Serialize(rehydratedResult.Template));
            Assert.AreEqual(result.Error, rehydratedResult.Error);
            var expResponse = expOp.GetRawResponse();
            var rehydratedExpResponse = modelRehydratedLro.GetRawResponse();
            Assert.AreEqual(expResponse.Status, rehydratedExpResponse.Status);
            Assert.AreEqual(expResponse.ReasonPhrase, rehydratedExpResponse.ReasonPhrase);
            //Assert.AreEqual(expResponse.ClientRequestId, rehydratedExpResponse.ClientRequestId);
            Assert.AreEqual(expResponse.IsError, rehydratedExpResponse.IsError);
            Assert.AreEqual(expResponse.Headers.Count(), rehydratedExpResponse.Headers.Count());
            //CheckResponseHeaders(expResponse.Headers, rehydratedExpResponse.Headers);

            // The deletion of a resource group is a real LRO
            var deleteOp = await rg.DeleteAsync(WaitUntil.Started);
            var deleteOpId = deleteOp.Id;
            var deleteRehydratedLro = new ArmOperation(Client, deleteOpId);
            await deleteRehydratedLro.UpdateStatusAsync();
            var deleteOpId2 = deleteRehydratedLro.Id;
            var deleteRehydratedLro2 = new ArmOperation(Client, deleteOpId2);
            await deleteRehydratedLro2.WaitForCompletionResponseAsync();
            Assert.AreEqual(deleteRehydratedLro2.HasCompleted, true);
            Assert.Throws<ArgumentException>(() => new ArmOperation(Client, deleteRehydratedLro2.Id));
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await rg.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [Ignore("")]
        [RecordedTest]
        public async Task CreateDeleteManagementLock()
        {
            string rgName = Recording.GenerateAssetName("testLroRg-");
            var tags = new Dictionary<string, string>()
            {
                { "key", "value"}
            };
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            // The creation of a resource group is a fake LRO
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2, tags).CreateOrUpdateAsync(rgName);
            var rgOpId = rgOp.Id;
            var rg = rgOp.Value;
            string mgmtLockObjectName = Recording.GenerateAssetName("mgmtLock-");
            ManagementLockData input = new ManagementLockData(new ManagementLockLevel("CanNotDelete"));
            // The creation of a management lock is a fake LRO with generic type
            ArmOperation<ManagementLockResource> lro = await rg.GetManagementLocks().CreateOrUpdateAsync(WaitUntil.Completed, mgmtLockObjectName, input);
            var lroId = lro.Id;
            var mgmtLock = lro.Value;
            var rehydratedLro = new ArmOperation<ManagementLockData>(Client, lroId);
            await rehydratedLro.WaitForCompletionResponseAsync();
            ManagementLockData rehydratedLock = rehydratedLro.Value;
            Assert.AreEqual(mgmtLock.Data.Id, rehydratedLock.Id);
            Assert.AreEqual(mgmtLock.Data.Name, rehydratedLock.Name);
            Assert.AreEqual(mgmtLock.Data.ResourceType, rehydratedLock.ResourceType);
            Assert.AreEqual(mgmtLock.Data.Level, rehydratedLock.Level);
            Assert.AreEqual(mgmtLock.Data.Notes, rehydratedLock.Notes);
            Assert.AreEqual(mgmtLock.Data.Owners.Count, rehydratedLock.Owners.Count);
            Assert.AreEqual(mgmtLock.Data.SystemData, rehydratedLock.SystemData);
            // The deletion of a management lock is a fake LRO
            var rehydratedLockResource = Client.GetManagementLockResource(rehydratedLock.Id);
            var deleteOp = await rehydratedLockResource.DeleteAsync(WaitUntil.Started);
            Assert.AreEqual(deleteOp.HasCompleted, true);
            var deleteOpId = deleteOp.Id;
            var deleteRehydratedLro = new ArmOperation(Client, deleteOpId);
            await deleteRehydratedLro.WaitForCompletionResponseAsync();
            // Assert.AreEqual(deleteRehydratedLro.Id, deleteOpId);
            Assert.AreEqual(deleteRehydratedLro.HasCompleted, true);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await rehydratedLockResource.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        private void CheckResponseHeaders(ResponseHeaders left, ResponseHeaders right)
        {
            Assert.AreEqual(left.Count(), right.Count());
            foreach (var header in left)
            {
                var value = header.Value;
                right.TryGetValue(header.Name, out var rightValue);
                Assert.AreEqual(value, rightValue);
            }
        }
    }
}
