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
            var rehydratedLro = new ArmOperation<ResourceGroupResource>(Client, rgOpId);
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
            // Template exportation is a real LRO with generic type
            var parameters = new ExportTemplate();
            parameters.Resources.Add("*");
            var expOp = await rg.ExportTemplateAsync(WaitUntil.Started, parameters);
            var expOpId = expOp.Id;
            var expRehydratedLro = new ArmOperation<ResourceGroupExportResult>(Client, expOpId);
            await expRehydratedLro.WaitForCompletionResponseAsync();
            Assert.AreEqual(expRehydratedLro.HasValue, true);
            var result = expRehydratedLro.Value;
            Assert.NotNull(result);
            // The deletion of a resource group is a real LRO
            var deleteOp = await rg.DeleteAsync(WaitUntil.Started);
            var deleteOpId = deleteOp.Id;
            var deleteRehydratedLro = new ArmOperation(Client, deleteOpId);
            await deleteRehydratedLro.UpdateStatusAsync();
            var deleteOpId2 = deleteRehydratedLro.Id;
            var deleteRehydratedLro2 = new ArmOperation(Client, deleteOpId2);
            await deleteRehydratedLro2.WaitForCompletionResponseAsync();
            Assert.AreEqual(deleteRehydratedLro2.HasCompleted, true);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await rg.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDeleteManagementLock()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string mgmtLockObjectName = Recording.GenerateAssetName("mgmtLock-");
            ManagementLockData input = new ManagementLockData(new ManagementLockLevel("CanNotDelete"));
            // The creation of a management lock is a fake LRO with generic type
            ArmOperation<ManagementLockResource> lro = await subscription.GetManagementLocks().CreateOrUpdateAsync(WaitUntil.Started, mgmtLockObjectName, input);
            var lroId = lro.Id;
            var rehydratedLro = new ArmOperation<ManagementLockResource>(Client, lroId);
            await rehydratedLro.WaitForCompletionResponseAsync();
            ManagementLockResource mgmtLock = rehydratedLro.Value;
            Assert.AreEqual(mgmtLockObjectName, mgmtLock.Data.Name);
            // The deletion of a management lock is a fake LRO
            var deleteOp = await mgmtLock.DeleteAsync(WaitUntil.Started);
            Assert.AreEqual(deleteOp.HasCompleted, true);
            var deleteOpId = deleteOp.Id;
            var deleteRehydratedLro = new ArmOperation(Client, deleteOpId);
            await deleteRehydratedLro.WaitForCompletionResponseAsync();
            // Assert.AreEqual(deleteRehydratedLro.Id, deleteOpId);
            Assert.AreEqual(deleteRehydratedLro.HasCompleted, true);
        }
    }
}
