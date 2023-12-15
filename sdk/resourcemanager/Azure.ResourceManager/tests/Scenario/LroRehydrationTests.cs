using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class LroRehydrationTests : ResourceManagerTestBase
    {
        public LroRehydrationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task FakeLroTest()
        {
            string rgName = Recording.GenerateAssetName("testLroRg-");
            var tags = new Dictionary<string, string>()
            {
                { "key", "value"}
            };
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            // fake LRO - PUT
            var orgData = new ResourceGroupData(AzureLocation.WestUS2);
            orgData.Tags.ReplaceWith(tags);
            var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, rgName, orgData);
            //var rg = rgOp.Value;
            var rgOpId = rgOp.Id;
            var rehydratedOrgOperation = new ArmOperation<ResourceGroupResource>(Client, rgOpId);
            var rehydratedOrgResponse = await rehydratedOrgOperation.UpdateStatusAsync();
            //var rehydratedRg = rehydratedOrgOperation.Value;
            var response = rgOp.GetRawResponse();
            Assert.AreEqual(201, response.Status);
            Assert.AreEqual(200, rehydratedOrgResponse.Status);
            Assert.AreEqual(response.IsError, rehydratedOrgResponse.IsError);
            Assert.AreEqual(response.Headers.Count(), rehydratedOrgResponse.Headers.Count());

            // fake LRO - Delete
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignmentResource policyAssignment = await CreatePolicyAssignment(subscription, policyAssignmentName);
            var deleteOp = await policyAssignment.DeleteAsync(WaitUntil.Started);
            var deleteResponse = deleteOp.GetRawResponse();
            var deleteOpId = deleteOp.Id;
            var rehydratedDeleteOperation = new ArmOperation(Client, deleteOpId);
            var rehydatedDeleteResponse = await rehydratedDeleteOperation.UpdateStatusAsync();
            Assert.AreEqual(deleteResponse.Status, rehydatedDeleteResponse.Status);
            Assert.AreEqual(deleteResponse.ReasonPhrase, rehydatedDeleteResponse.ReasonPhrase);
            Assert.AreEqual(deleteResponse.IsError, rehydatedDeleteResponse.IsError);
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
            var orgData = new ResourceGroupData(AzureLocation.WestUS2);
            orgData.Tags.ReplaceWith(tags);
            var rgOp = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, rgName, orgData);
            var rg = rgOp.Value;

            await CreateGenericAvailabilitySetAsync(rg.Id);
            var genericResources = Client.GetGenericResources();
            for (int i = 0; i < 20; i++)
            {
                var resourceId = rg.Id.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
                await genericResources.CreateOrUpdateAsync(WaitUntil.Completed, resourceId, ConstructGenericAvailabilitySet());
            }

            // Template exportation is a real LRO with generic type
            var parameters = new ExportTemplate();
            parameters.Resources.Add("*");
            var originalOperation = await Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(subscription.Id.SubscriptionId, rgName)).ExportTemplateAsync(WaitUntil.Started, parameters);
            var originalOperationId = originalOperation.Id;
            var rehydratedOperation = new ArmOperation<ResourceGroupExportResult>(Client, originalOperationId);
            await rehydratedOperation.WaitForCompletionResponseAsync();
            Assert.AreEqual(rehydratedOperation.HasValue, true);
            var rehydratedResult = rehydratedOperation.Value;
            await originalOperation.UpdateStatusAsync();
            var originalResult = originalOperation.Value;
            Assert.AreEqual(JsonSerializer.Serialize(originalResult.Template), JsonSerializer.Serialize(rehydratedResult.Template));
            Assert.AreEqual(originalResult.Error, rehydratedResult.Error);
            var expResponse = originalOperation.GetRawResponse();
            var rehydratedExpResponse = rehydratedOperation.GetRawResponse();
            Assert.AreEqual(expResponse.Status, rehydratedExpResponse.Status);
            Assert.AreEqual(expResponse.ReasonPhrase, rehydratedExpResponse.ReasonPhrase);
            //Assert.AreEqual(expResponse.ClientRequestId, rehydratedExpResponse.ClientRequestId);
            Assert.AreEqual(expResponse.IsError, rehydratedExpResponse.IsError);
            Assert.AreEqual(expResponse.Headers.Count(), rehydratedExpResponse.Headers.Count());

            // The deletion of a resource group is a real LRO
            var originalDeleteOperation = await rg.DeleteAsync(WaitUntil.Started);
            var originalDeleteOperationId = originalDeleteOperation.Id;
            var rehydratedDeleteOperation = new ArmOperation(Client, originalDeleteOperationId);
            await rehydratedDeleteOperation.WaitForCompletionResponseAsync();
            Assert.AreEqual(rehydratedDeleteOperation.HasCompleted, true);
            var deleteFinalRehydratedLro = new ArmOperation(Client, rehydratedDeleteOperation.Id);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await rg.GetAsync());
            var deleteRehydratedResponse = await deleteFinalRehydratedLro.UpdateStatusAsync();
            Assert.AreEqual(404, ex.Status);
            Assert.AreEqual(200, deleteRehydratedResponse.Status);
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
