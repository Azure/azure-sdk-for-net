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
            var rehydration = new ResourcesArmOperationRehydration<ResourceGroupResource>(Client, rgOpId);
            var rehydratedLro = await rehydration.RehydrateAsync(WaitUntil.Completed);
            Assert.AreEqual(rehydratedLro.Id, rgOpId);
            ResourceGroupResource rg = rehydratedLro.Value;
            Assert.AreEqual(rgName, rg.Data.Name);
            // Template exportation is a real LRO with generic type
            var parameters = new ExportTemplate();
            parameters.Resources.Add("*");
            var expOp = await rg.ExportTemplateAsync(WaitUntil.Started, parameters);
            var expOpId = expOp.Id;
            var expRehydration = new ResourcesArmOperationRehydration<ResourceGroupExportResult>(Client, expOpId);
            var expRehydratedLro = await expRehydration.RehydrateAsync(WaitUntil.Started);
            await expRehydratedLro.WaitForCompletionAsync();
            Assert.AreEqual(expRehydratedLro.HasValue, true);
            var result = expRehydratedLro.Value;
            Assert.NotNull(result);
            // The deletion of a resource group is a real LRO
            var deleteOp = await rg.DeleteAsync(WaitUntil.Started);
            var deleteOpId = deleteOp.Id;
            var deleteRehydration = new ResourcesArmOperationRehydration(Client, deleteOpId);
            var deleteRehydratedLro = await deleteRehydration.RehydrateAsync(WaitUntil.Started);
            await deleteRehydratedLro.UpdateStatusAsync();
            var deleteOpId2 = deleteRehydratedLro.Id;
            var deleteRehydration2 = new ResourcesArmOperationRehydration(Client, deleteOpId2);
            var deleteRehydratedLro2 = await deleteRehydration2.RehydrateAsync(WaitUntil.Completed);
            Assert.AreEqual(deleteRehydratedLro2.HasCompleted, true);
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
            var rehydration = new ResourcesArmOperationRehydration<ManagementLockResource>(Client, lroId);
            var rehydratedLro = await rehydration.RehydrateAsync(WaitUntil.Completed);
            ManagementLockResource mgmtLock = rehydratedLro.Value;
            Assert.AreEqual(mgmtLockObjectName, mgmtLock.Data.Name);
            // The deletion of a management lock is a fake LRO
            var deleteOp = await mgmtLock.DeleteAsync(WaitUntil.Started);
            Assert.AreEqual(deleteOp.HasCompleted, true);
            var deleteOpId = deleteOp.Id;
            var deleteRehydration = new ResourcesArmOperationRehydration(Client, deleteOpId);
            var deleteRehydratedLro = await deleteRehydration.RehydrateAsync(WaitUntil.Completed);
            Assert.AreEqual(deleteRehydratedLro.Id, deleteOpId);
            Assert.AreEqual(deleteRehydratedLro.HasCompleted, true);
        }
    }
}
