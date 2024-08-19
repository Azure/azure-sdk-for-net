using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.ManagementGroups.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ManagementGroupSubscriptionCollectionTests : ResourceManagerTestBase
    {
        public ManagementGroupSubscriptionCollectionTests(bool isAsync)
            :base(isAsync,RecordedTestMode.Record)
        {
        }

        public async Task<ManagementGroupResource> CreateManagementGroupAsync()
        {
            var mgmtGroupName = Recording.GenerateAssetName("mgmt-group-");
            var mgmtGroupOp = await Client.GetManagementGroups().CreateOrUpdateAsync(WaitUntil.Started, mgmtGroupName, new ManagementGroupCreateOrUpdateContent());
            var mgmtGroup = await mgmtGroupOp.WaitForCompletionAsync();
            return mgmtGroup;
        }

        [RecordedTest]
        [Ignore("Unable to test this.")]
        public async Task CreateOrUpdate()
        {
            var mgmtGroup = await CreateManagementGroupAsync();
            var subscriptionUnderMgmtGroupCollection = mgmtGroup.GetManagementGroupSubscriptions();
            var subscriptionId = (await Client.GetDefaultSubscriptionAsync()).Id.SubscriptionId;
            var subscriptionUnderMgmtGroup = (await subscriptionUnderMgmtGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed,subscriptionId)).Value;
            Assert.AreEqual(subscriptionUnderMgmtGroup.Data.Id.SubscriptionId,subscriptionId);
        }

        [RecordedTest]
        [Ignore("Unable to test this.")]
        public async Task Get()
        {
            var mgmtGroup = await CreateManagementGroupAsync();
            var subscriptionUnderMgmtGroupCollection = mgmtGroup.GetManagementGroupSubscriptions();
            var subscriptionId = (await Client.GetDefaultSubscriptionAsync()).Id.SubscriptionId;
            var subscriptionUnderMgmtGroup = (await subscriptionUnderMgmtGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, subscriptionId)).Value;
            var subscriptionUnderMgmtGroup1 = (await subscriptionUnderMgmtGroupCollection.GetAsync(subscriptionId)).Value;
            Assert.AreEqual(subscriptionUnderMgmtGroup.Data.Name,subscriptionUnderMgmtGroup1.Data.Name);
            Assert.AreEqual(subscriptionUnderMgmtGroup.Data.Id.SubscriptionId,subscriptionUnderMgmtGroup1.Data.Id.SubscriptionId);
        }

        [RecordedTest]
        [Ignore("Unable to test this.")]
        public async Task GetAll()
        {
            ArmClientOptions options1 = new ArmClientOptions();
            ArmClientOptions options2 = new ArmClientOptions();
            var client1 = GetArmClient(options1);
            var client2 = GetArmClient(options2);
            var subscription1 = await client1.GetDefaultSubscriptionAsync();
            var subscription2 = await client2.GetDefaultSubscriptionAsync();
            var mgmtGroup = await CreateManagementGroupAsync();
            var subscriptionUnderMgmtGroupCollection = mgmtGroup.GetManagementGroupSubscriptions();
            _ = await subscriptionUnderMgmtGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, subscription1.Id.SubscriptionId);
            _ = await subscriptionUnderMgmtGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, subscription2.Id.SubscriptionId);
            var count = 0;
            await foreach (var item in subscriptionUnderMgmtGroupCollection.GetAllAsync())
            {
                count++;
            };
            Assert.AreEqual(2, count);
        }

        [RecordedTest]
        [Ignore("Unable to test this.")]
        public async Task Exist()
        {
            var mgmtGroup = await CreateManagementGroupAsync();
            var subscriptionUnderMgmtGroupCollection = mgmtGroup.GetManagementGroupSubscriptions();
            var subscriptionId = (await Client.GetDefaultSubscriptionAsync()).Id.SubscriptionId;
            _ = await subscriptionUnderMgmtGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, subscriptionId);
            Assert.IsTrue(await subscriptionUnderMgmtGroupCollection.ExistsAsync(subscriptionId));
            Assert.IsFalse(await subscriptionUnderMgmtGroupCollection.ExistsAsync(subscriptionId + 1));
        }
    }
}
