using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.ManagementGroups.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ManagementGroupCollectionTests : ResourceManagerTestBase
    {
        private ManagementGroupResource _mgmtGroup;
        private string _mgmtGroupName;

        public ManagementGroupCollectionTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GetGlobalManagementGroup()
        {
            _mgmtGroupName = SessionRecording.GenerateAssetName("mgmt-group-");
            var mgmtGroupCollection = GlobalClient.GetManagementGroups();
            var mgmtOp = await mgmtGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, _mgmtGroupName, new ManagementGroupCreateOrUpdateContent());
            _mgmtGroup = mgmtOp.Value;
            _mgmtGroup = await _mgmtGroup.GetAsync();
            await StopSessionRecordingAsync();
        }

        [RecordedTest]
        public async Task List()
        {
            var mgmtGroupCollection = Client.GetManagementGroups();
            ManagementGroupResource mgmtGroup = null;
            await foreach(var item in mgmtGroupCollection.GetAllAsync("no-cache"))
            {
                mgmtGroup = item;
                break;
            }
            Assert.IsNotNull(mgmtGroup, "No management groups found in list");
            Assert.IsNotNull(mgmtGroup.Data.DisplayName, "DisplayName was null");
            Assert.IsNotNull(mgmtGroup.Data.Id, "Id was null");
            Assert.IsNotNull(mgmtGroup.Data.Name, "Name was null");
            Assert.IsNotNull(mgmtGroup.Data.TenantId, "TenantId was null");
            Assert.IsNotNull(mgmtGroup.Data.ResourceType, "Type was null");
            Assert.IsEmpty(mgmtGroup.Data.Children);
            Assert.IsNull(mgmtGroup.Data.Details);
        }

        [RecordedTest]
        public async Task Get()
        {
            ManagementGroupResource mgmtGroup = await Client.GetManagementGroups().GetAsync(_mgmtGroupName, cacheControl: "no-cache");
            CompareMgmtGroups(_mgmtGroup, mgmtGroup);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => _ = await Client.GetManagementGroups().GetAsync("NotThere", cacheControl: "no-cache"));
            Assert.AreEqual(403, ex.Status);
        }

        [RecordedTest]
        public async Task Exists()
        {
            Assert.IsTrue(await Client.GetManagementGroups().ExistsAsync(_mgmtGroup.Data.Name, cacheControl: "no-cache"));
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.GetManagementGroups().ExistsAsync(_mgmtGroup.Data.Name + "x", cacheControl: "no-cache"));
            Assert.AreEqual(403, ex.Status); //you get forbidden vs not found here for some reason by the service
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string mgmtGroupName = Recording.GenerateAssetName("mgmt-group-");
            var mgmtGroupOp = await Client.GetManagementGroups().CreateOrUpdateAsync(WaitUntil.Started, mgmtGroupName, new ManagementGroupCreateOrUpdateContent());
            ManagementGroupResource mgmtGroup = await mgmtGroupOp.WaitForCompletionAsync();
            Assert.AreEqual($"/providers/Microsoft.Management/managementGroups/{mgmtGroupName}", mgmtGroup.Data.Id.ToString());
            Assert.AreEqual(mgmtGroupName, mgmtGroup.Data.Name);
            Assert.AreEqual(mgmtGroupName, mgmtGroup.Data.DisplayName);
            Assert.AreEqual(ManagementGroupResource.ResourceType, mgmtGroup.Data.ResourceType);
        }

        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            string mgmtGroupName = Recording.GenerateAssetName("mgmt-group-");
            var mgmtGroupOp = await Client.GetManagementGroups().CreateOrUpdateAsync(WaitUntil.Started, mgmtGroupName, new ManagementGroupCreateOrUpdateContent());
            ManagementGroupResource mgmtGroup = await mgmtGroupOp.WaitForCompletionAsync();
            Assert.AreEqual($"/providers/Microsoft.Management/managementGroups/{mgmtGroupName}", mgmtGroup.Data.Id.ToString());
            Assert.AreEqual(mgmtGroupName, mgmtGroup.Data.Name);
            Assert.AreEqual(mgmtGroupName, mgmtGroup.Data.DisplayName);
            Assert.AreEqual(ManagementGroupResource.ResourceType, mgmtGroup.Data.ResourceType);
        }

        [RecordedTest]
        public async Task CheckNameAvailability()
        {
            var rq = new ManagementGroupNameAvailabilityContent();
            rq.Name = "this-should-not-exist";
            var rs = await Client.GetManagementGroups().CheckNameAvailabilityAsync(rq);
            Assert.IsTrue(rs.Value.NameAvailable);
        }

        [RecordedTest]
        public async Task GetEntities()
        {
            var mgmtGroupCollection = Client.GetManagementGroups();
            var rq = new ManagementGroupCollectionGetEntitiesOptions();
            EntityData entity;
            await foreach(var item in mgmtGroupCollection.GetEntitiesAsync(rq))
            {
                entity = item;
                break;
            }
        }
    }
}
