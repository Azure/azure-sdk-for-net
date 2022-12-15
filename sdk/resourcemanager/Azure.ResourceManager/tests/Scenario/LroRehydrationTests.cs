using System;
using System.Collections.Generic;
using System.Linq;
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
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDeleteResourceGroup()
        {
            string rgName = Recording.GenerateAssetName("testRg-");
            var tags = new Dictionary<string, string>()
            {
                { "key", "value"}
            };
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            // The creation of a resource group is a fake LRO
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2, tags).CreateOrUpdateAsync(rgName);
            var rgOpId = rgOp.Id;
            var rg = rgOp.Value;
#if NET7_0_OR_GREATER
            var rehydratedLro = ArmOperation<ResourceGroupResource>.Rehydrate(Client, rgOpId);
            await rehydratedLro.WaitForCompletionResponseAsync();
            // Assert.AreEqual(rehydratedLro.Id, rgOpId);
            ResourceGroupResource rehydratedRg = rehydratedLro.Value;
            Assert.AreEqual(rg.Data.Id, rehydratedRg.Data.Id);
            Assert.AreEqual(rg.Data.Name, rehydratedRg.Data.Name);
            Assert.AreEqual(rg.Data.ResourceType, rehydratedRg.Data.ResourceType);
            Assert.AreEqual(rg.Data.SystemData, rehydratedRg.Data.SystemData);
            Assert.AreEqual(rg.Data.Tags, rehydratedRg.Data.Tags);
            Assert.AreEqual(rg.Data.Location, rehydratedRg.Data.Location);
            Assert.AreEqual(rg.Data.ResourceGroupProvisioningState, rehydratedRg.Data.ResourceGroupProvisioningState);
            Assert.AreEqual(rg.Data.ManagedBy, rehydratedRg.Data.ManagedBy);
            var response = rgOp.GetRawResponse();
            var rehydratedResponse = rehydratedLro.GetRawResponse();
            Assert.AreEqual(response.Status, rehydratedResponse.Status);
            Assert.AreEqual(response.ReasonPhrase, rehydratedResponse.ReasonPhrase);
            //Assert.AreEqual(response.ContentStream, rehydratedResponse.ContentStream);
            Assert.AreEqual(response.ClientRequestId, rehydratedResponse.ClientRequestId);
            Assert.AreEqual(response.IsError, rehydratedResponse.IsError);
            CheckResponseHeaders(response.Headers, rehydratedResponse.Headers);

            // Template exportation is a real LRO with generic type
            var parameters = new ExportTemplate();
            parameters.Resources.Add("*");
            var expOp = await rg.ExportTemplateAsync(WaitUntil.Started, parameters);
            var expOpId = expOp.Id;
            var expRehydratedLro = ArmOperation<ResourceGroupExportResult>.Rehydrate(Client, expOpId);
            await expRehydratedLro.WaitForCompletionResponseAsync();
            Assert.AreEqual(expRehydratedLro.HasValue, true);
            var rehydratedResult = expRehydratedLro.Value;
            await expOp.UpdateStatusAsync();
            var result = expOp.Value;
            //Assert.AreEqual(result.Template, rehydratedResult.Template);
            Assert.AreEqual(result.Error, rehydratedResult.Error);
            var expResponse = expOp.GetRawResponse();
            var rehydratedExpResponse = expRehydratedLro.GetRawResponse();
            Assert.AreEqual(expResponse.Status, rehydratedExpResponse.Status);
            Assert.AreEqual(expResponse.ReasonPhrase, rehydratedExpResponse.ReasonPhrase);
            //Assert.AreEqual(expResponse.ContentStream, rehydratedResponse.ContentStream);
            Assert.AreEqual(expResponse.ClientRequestId, rehydratedExpResponse.ClientRequestId);
            Assert.AreEqual(expResponse.IsError, rehydratedExpResponse.IsError);
            Assert.AreEqual(expResponse.Headers.Count(), rehydratedExpResponse.Headers.Count());
            CheckResponseHeaders(expResponse.Headers, rehydratedExpResponse.Headers);
            // The deletion of a resource group is a real LRO
            var deleteOp = await rg.DeleteAsync(WaitUntil.Started);
            var deleteOpId = deleteOp.Id;
            var deleteRehydratedLro = ArmOperation.Rehydrate(Client, deleteOpId);
            await deleteRehydratedLro.UpdateStatusAsync();
            var deleteOpId2 = deleteRehydratedLro.Id;
            var deleteRehydratedLro2 = ArmOperation.Rehydrate(Client, deleteOpId2);
            await deleteRehydratedLro2.WaitForCompletionResponseAsync();
            Assert.AreEqual(deleteRehydratedLro2.HasCompleted, true);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await rg.GetAsync());
            Assert.AreEqual(404, ex.Status);
#else
            var ex = Assert.Throws<InvalidOperationException>(() => ArmOperation<ResourceGroupResource>.Rehydrate(Client, rgOpId));
            Assert.AreEqual("LRO rehydration is not supported in this version of .NET. Please upgrade to .NET 7.0 or later.", ex.Message);
#endif
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDeleteManagementLock()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string mgmtLockObjectName = Recording.GenerateAssetName("mgmtLock-");
            ManagementLockData input = new ManagementLockData(new ManagementLockLevel("CanNotDelete"));
            // The creation of a management lock is a fake LRO with generic type
            ArmOperation<ManagementLockResource> lro = await subscription.GetManagementLocks().CreateOrUpdateAsync(WaitUntil.Completed, mgmtLockObjectName, input);
            var lroId = lro.Id;
            var mgmtLock = lro.Value;
#if NET7_0_OR_GREATER
            var rehydratedLro = ArmOperation<ManagementLockResource>.Rehydrate(Client, lroId);
            await rehydratedLro.WaitForCompletionResponseAsync();
            ManagementLockResource rehydratedLock = rehydratedLro.Value;
            Assert.AreEqual(mgmtLock.Data.Id, rehydratedLock.Data.Id);
            Assert.AreEqual(mgmtLock.Data.Name, rehydratedLock.Data.Name);
            Assert.AreEqual(mgmtLock.Data.ResourceType, rehydratedLock.Data.ResourceType);
            Assert.AreEqual(mgmtLock.Data.Level, rehydratedLock.Data.Level);
            Assert.AreEqual(mgmtLock.Data.Notes, rehydratedLock.Data.Notes);
            Assert.AreEqual(mgmtLock.Data.Owners.Count, rehydratedLock.Data.Owners.Count);
            Assert.AreEqual(mgmtLock.Data.SystemData, rehydratedLock.Data.SystemData);
            // The deletion of a management lock is a fake LRO
            var deleteOp = await rehydratedLock.DeleteAsync(WaitUntil.Started);
            Assert.AreEqual(deleteOp.HasCompleted, true);
            var deleteOpId = deleteOp.Id;
            var deleteRehydratedLro = ArmOperation.Rehydrate(Client, deleteOpId);
            await deleteRehydratedLro.WaitForCompletionResponseAsync();
            // Assert.AreEqual(deleteRehydratedLro.Id, deleteOpId);
            Assert.AreEqual(deleteRehydratedLro.HasCompleted, true);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await rehydratedLock.GetAsync());
            Assert.AreEqual(404, ex.Status);
#else
            var ex = Assert.Throws<InvalidOperationException>(() => ArmOperation<ManagementLockResource>.Rehydrate(Client, lroId));
            Assert.AreEqual("LRO rehydration is not supported in this version of .NET. Please upgrade to .NET 7.0 or later.", ex.Message);
#endif
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
