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
            Assert.That(rgOpRehydrationToken, Is.Not.Null);
            var rehydratedOrgOperation = ArmOperation.Rehydrate<ResourceGroupResource>(Client, rgOpRehydrationToken!.Value);
            var rehydratedOrgResponse = rehydratedOrgOperation.GetRawResponse();
            var response = rgOp.GetRawResponse();
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.Created));
            Assert.That(rehydratedOrgResponse.Status, Is.EqualTo((int)HttpStatusCode.OK));
            Assert.That(rehydratedOrgResponse.IsError, Is.EqualTo(response.IsError));
            Assert.That(rehydratedOrgResponse.Headers.Count(), Is.EqualTo(response.Headers.Count()));

            // fake LRO - Delete
            string policyAssignmentName = Recording.GenerateAssetName("polAssign-");
            PolicyAssignmentResource policyAssignment = await CreatePolicyAssignment(subscription, policyAssignmentName);
            var deleteOp = await policyAssignment.DeleteAsync(WaitUntil.Started);
            var deleteResponse = deleteOp.GetRawResponse();
            var deleteOpRehydrationToken = deleteOp.GetRehydrationToken();
            Assert.That(deleteOpRehydrationToken, Is.Not.Null);
            var rehydratedDeleteOperation = ArmOperation.Rehydrate(Client, deleteOpRehydrationToken!.Value);
            var rehydatedDeleteResponse = rehydratedDeleteOperation.GetRawResponse();
            Assert.That(rehydatedDeleteResponse.Status, Is.EqualTo((int)HttpStatusCode.NoContent));
            Assert.That(rehydatedDeleteResponse.ReasonPhrase, Is.EqualTo(HttpStatusCode.NoContent.ToString()));
            Assert.That(rehydatedDeleteResponse.IsError, Is.EqualTo(deleteResponse.IsError));
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
            Assert.That(originalOperationToken, Is.Not.Null);
            var rehydratedOperation = await ArmOperation.RehydrateAsync<ResourceGroupExportResult>(Client, originalOperationToken!.Value);
            await rehydratedOperation.WaitForCompletionResponseAsync();
            Assert.That(rehydratedOperation.HasValue, Is.EqualTo(true));
            var rehydratedResult = rehydratedOperation.Value;
            await originalOperation.UpdateStatusAsync();
            var originalResult = originalOperation.Value;
            Assert.That(JsonSerializer.Serialize(rehydratedResult.Template), Is.EqualTo(JsonSerializer.Serialize(originalResult.Template)));
            Assert.That(rehydratedResult.Error, Is.EqualTo(originalResult.Error));
            var expResponse = originalOperation.GetRawResponse();
            var rehydratedExpResponse = rehydratedOperation.GetRawResponse();
            Assert.That(rehydratedExpResponse.Status, Is.EqualTo(expResponse.Status));
            Assert.That(rehydratedExpResponse.ReasonPhrase, Is.EqualTo(expResponse.ReasonPhrase));
            Assert.That(rehydratedExpResponse.IsError, Is.EqualTo(expResponse.IsError));
            Assert.That(rehydratedExpResponse.Headers.Count(), Is.EqualTo(expResponse.Headers.Count()));

            // The deletion of a resource group is a real LRO
            var originalDeleteOperation = await rg.DeleteAsync(WaitUntil.Started);
            var originalDeleteOperationToken = originalDeleteOperation.GetRehydrationToken();
            Assert.That(originalDeleteOperationToken, Is.Not.Null);
            var rehydratedDeleteOperation = await ArmOperation.RehydrateAsync(Client, originalDeleteOperationToken!.Value);
            await rehydratedDeleteOperation.WaitForCompletionResponseAsync();
            Assert.That(rehydratedDeleteOperation.HasCompleted, Is.EqualTo(true));
            var token = rehydratedDeleteOperation.GetRehydrationToken();
            Assert.That(token, Is.Not.Null);
            var deleteFinalRehydratedLro = ArmOperation.Rehydrate(Client, token!.Value);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await rg.GetAsync());
            Assert.That(ex?.Status, Is.EqualTo(404));
            Assert.That(deleteFinalRehydratedLro.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
