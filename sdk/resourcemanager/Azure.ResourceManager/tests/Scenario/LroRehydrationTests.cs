#nullable enable

using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var rgOpRehydrationToken = rgOp.GetRehydrationToken();
            Assert.NotNull(rgOpRehydrationToken);
            var rehydratedOrgOperation = ArmOperation.Rehydrate<ResourceGroupResource>(Client, rgOpRehydrationToken!.Value);
            var rehydratedOrgResponse = rehydratedOrgOperation.GetRawResponse();
            var response = rgOp.GetRawResponse();
            Assert.AreEqual((int)HttpStatusCode.Created, response.Status);
            Assert.AreEqual((int)HttpStatusCode.OK, rehydratedOrgResponse.Status);
            Assert.AreEqual(response.IsError, rehydratedOrgResponse.IsError);
            Assert.AreEqual(response.Headers.Count(), rehydratedOrgResponse.Headers.Count());

            // fake LRO - Delete
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignmentResource policyAssignment = await CreatePolicyAssignment(subscription, policyAssignmentName);
            var deleteOp = await policyAssignment.DeleteAsync(WaitUntil.Started);
            var deleteResponse = deleteOp.GetRawResponse();
            var deleteOpRehydrationToken = deleteOp.GetRehydrationToken();
            Assert.NotNull(deleteOpRehydrationToken);
            var rehydratedDeleteOperation = ArmOperation.Rehydrate(Client, deleteOpRehydrationToken!.Value);
            var rehydatedDeleteResponse = rehydratedDeleteOperation.GetRawResponse();
            Assert.AreEqual((int)HttpStatusCode.NoContent, rehydatedDeleteResponse.Status);
            Assert.AreEqual(HttpStatusCode.NoContent.ToString(), rehydatedDeleteResponse.ReasonPhrase);
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
            var originalOperationToken = originalOperation.GetRehydrationToken();
            Assert.NotNull(originalOperationToken);
            var rehydratedOperation = await ArmOperation.RehydrateAsync<ResourceGroupExportResult>(Client, originalOperationToken!.Value);
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
            Assert.AreEqual(expResponse.IsError, rehydratedExpResponse.IsError);
            Assert.AreEqual(expResponse.Headers.Count(), rehydratedExpResponse.Headers.Count());

            // The deletion of a resource group is a real LRO
            var originalDeleteOperation = await rg.DeleteAsync(WaitUntil.Started);
            var originalDeleteOperationToken = originalDeleteOperation.GetRehydrationToken();
            Assert.NotNull(originalDeleteOperationToken);
            var rehydratedDeleteOperation = await ArmOperation.RehydrateAsync(Client, originalDeleteOperationToken!.Value);
            await rehydratedDeleteOperation.WaitForCompletionResponseAsync();
            Assert.AreEqual(rehydratedDeleteOperation.HasCompleted, true);
            var token = rehydratedDeleteOperation.GetRehydrationToken();
            Assert.NotNull(token);
            var deleteFinalRehydratedLro = ArmOperation.Rehydrate(Client, token!.Value);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await rg.GetAsync());
            Assert.AreEqual(404, ex?.Status);
            Assert.AreEqual(200, deleteFinalRehydratedLro.GetRawResponse().Status);
        }
    }
}
