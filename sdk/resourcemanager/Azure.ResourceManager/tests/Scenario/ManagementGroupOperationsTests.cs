using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.ManagementGroups.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ManagementGroupOperationsTests : ResourceManagerTestBase
    {
        private ManagementGroupResource _mgmtGroup;
        private string _mgmtGroupName;
        
        public ManagementGroupOperationsTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GetGlobalManagementGroup()
        {
            _mgmtGroupName = SessionRecording.GenerateAssetName("mgmt-group-");
            var mgmtOp = await GlobalClient.GetManagementGroups().CreateOrUpdateAsync(WaitUntil.Started, _mgmtGroupName, new ManagementGroupCreateOrUpdateContent());
            await mgmtOp.WaitForCompletionAsync();
            _mgmtGroup = mgmtOp.Value;
            _mgmtGroup = await _mgmtGroup.GetAsync();
            await StopSessionRecordingAsync();
        }

        [RecordedTest]
        public async Task Get()
        {
            var mgmtGroup = await Client.GetManagementGroupResource(_mgmtGroup.Id).GetAsync();
            CompareMgmtGroups(_mgmtGroup, mgmtGroup.Value);
            ResourceIdentifier fakeId = new ResourceIdentifier(_mgmtGroup.Id.ToString() + "x");
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => _ = await Client.GetManagementGroupResource(new ResourceIdentifier(fakeId)).GetAsync());
            Assert.That(ex.Status, Is.EqualTo(403));
        }

        [RecordedTest]
        public async Task Delete()
        {
            var mgmtGroupOp = await Client.GetManagementGroups().CreateOrUpdateAsync(WaitUntil.Started, Recording.GenerateAssetName("mgmt-group-"), new ManagementGroupCreateOrUpdateContent());
            await mgmtGroupOp.WaitForCompletionAsync();
            ManagementGroupResource mgmtGroup = mgmtGroupOp.Value;
            await mgmtGroup.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await mgmtGroup.GetAsync());
            Assert.That(ex.Status, Is.EqualTo(404));
        }

        [RecordedTest]
        public async Task StartDelete()
        {
            var mgmtGroupOp = await Client.GetManagementGroups().CreateOrUpdateAsync(WaitUntil.Started, Recording.GenerateAssetName("mgmt-group-"), new ManagementGroupCreateOrUpdateContent());
            await mgmtGroupOp.WaitForCompletionAsync();
            ManagementGroupResource mgmtGroup = mgmtGroupOp.Value;
            var deleteOp = await mgmtGroup.DeleteAsync(WaitUntil.Started);
            await deleteOp.WaitForCompletionResponseAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await mgmtGroup.GetAsync());
            Assert.That(ex.Status, Is.EqualTo(404));
        }

        [RecordedTest]
        public async Task GetDescendants()
        {
            ManagementGroupResource mgmtGroup = await Client.GetManagementGroupResource(_mgmtGroup.Id).GetAsync();
            DescendantData descendant = null;
            await foreach(var desc in mgmtGroup.GetDescendantsAsync())
            {
                descendant = desc;
                break;
            }
            Assert.That(descendant, Is.Null); //should have no descendants
        }

        [RecordedTest]
        public async Task Update()
        {
            var mgmtGroupOp = await Client.GetManagementGroups()
                .CreateOrUpdateAsync(WaitUntil.Started, Recording.GenerateAssetName("mgmt-group-"), new ManagementGroupCreateOrUpdateContent());
            await mgmtGroupOp.WaitForCompletionAsync();
            ManagementGroupResource mgmtGroup = mgmtGroupOp.Value;
            ManagementGroupPatch patch = new ManagementGroupPatch();
            patch.DisplayName = "New Display Name";
            ManagementGroupResource patchedMgmtGroup = await mgmtGroup.UpdateAsync(patch);
            Assert.That(patchedMgmtGroup.Data.DisplayName, Is.EqualTo("New Display Name"));
            Assert.That(patchedMgmtGroup.Data.Id, Is.EqualTo(mgmtGroup.Data.Id));
            Assert.That(patchedMgmtGroup.Data.Name, Is.EqualTo(mgmtGroup.Data.Name));
            Assert.That(patchedMgmtGroup.Data.TenantId, Is.EqualTo(mgmtGroup.Data.TenantId));
            Assert.That(patchedMgmtGroup.Data.ResourceType, Is.EqualTo(mgmtGroup.Data.ResourceType));
        }
    }
}
