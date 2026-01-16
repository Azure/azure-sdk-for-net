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
            Assert.That(mgmtGroup, Is.Not.Null, "No management groups found in list");
            Assert.That(mgmtGroup.Data.DisplayName, Is.Not.Null, "DisplayName was null");
            Assert.That(mgmtGroup.Data.Id, Is.Not.Null, "Id was null");
            Assert.That(mgmtGroup.Data.Name, Is.Not.Null, "Name was null");
            Assert.That(mgmtGroup.Data.TenantId, Is.Not.Null, "TenantId was null");
            Assert.That(mgmtGroup.Data.ResourceType, Is.Not.Null, "Type was null");
            Assert.That(mgmtGroup.Data.Children, Is.Empty);
            Assert.That(mgmtGroup.Data.Details, Is.Null);
        }

        [RecordedTest]
        public async Task Get()
        {
            ManagementGroupResource mgmtGroup = await Client.GetManagementGroups().GetAsync(_mgmtGroupName, cacheControl: "no-cache");
            CompareMgmtGroups(_mgmtGroup, mgmtGroup);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => _ = await Client.GetManagementGroups().GetAsync("NotThere", cacheControl: "no-cache"));
            Assert.That(ex.Status, Is.EqualTo(403));
        }

        [RecordedTest]
        public async Task Exists()
        {
            Assert.That((bool)await Client.GetManagementGroups().ExistsAsync(_mgmtGroup.Data.Name, cacheControl: "no-cache"), Is.True);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.GetManagementGroups().ExistsAsync(_mgmtGroup.Data.Name + "x", cacheControl: "no-cache"));
            Assert.That(ex.Status, Is.EqualTo(403)); //you get forbidden vs not found here for some reason by the service
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string mgmtGroupName = Recording.GenerateAssetName("mgmt-group-");
            var mgmtGroupOp = await Client.GetManagementGroups().CreateOrUpdateAsync(WaitUntil.Started, mgmtGroupName, new ManagementGroupCreateOrUpdateContent());
            ManagementGroupResource mgmtGroup = await mgmtGroupOp.WaitForCompletionAsync();
            Assert.That(mgmtGroup.Data.Id.ToString(), Is.EqualTo($"/providers/Microsoft.Management/managementGroups/{mgmtGroupName}"));
            Assert.That(mgmtGroup.Data.Name, Is.EqualTo(mgmtGroupName));
            Assert.That(mgmtGroup.Data.DisplayName, Is.EqualTo(mgmtGroupName));
            Assert.That(mgmtGroup.Data.ResourceType, Is.EqualTo(ManagementGroupResource.ResourceType));
        }

        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            string mgmtGroupName = Recording.GenerateAssetName("mgmt-group-");
            var mgmtGroupOp = await Client.GetManagementGroups().CreateOrUpdateAsync(WaitUntil.Started, mgmtGroupName, new ManagementGroupCreateOrUpdateContent());
            ManagementGroupResource mgmtGroup = await mgmtGroupOp.WaitForCompletionAsync();
            Assert.That(mgmtGroup.Data.Id.ToString(), Is.EqualTo($"/providers/Microsoft.Management/managementGroups/{mgmtGroupName}"));
            Assert.That(mgmtGroup.Data.Name, Is.EqualTo(mgmtGroupName));
            Assert.That(mgmtGroup.Data.DisplayName, Is.EqualTo(mgmtGroupName));
            Assert.That(mgmtGroup.Data.ResourceType, Is.EqualTo(ManagementGroupResource.ResourceType));
        }

        [RecordedTest]
        public async Task CheckNameAvailability()
        {
            var rq = new ManagementGroupNameAvailabilityContent();
            rq.Name = "this-should-not-exist";
            var rs = await Client.GetManagementGroups().CheckNameAvailabilityAsync(rq);
            Assert.That(rs.Value.NameAvailable, Is.True);
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
