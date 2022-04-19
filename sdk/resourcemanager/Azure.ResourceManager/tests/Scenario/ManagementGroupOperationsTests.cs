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
            Assert.AreEqual(403, ex.Status);
        }

        [RecordedTest]
        public async Task Delete()
        {
            var mgmtGroupOp = await Client.GetManagementGroups().CreateOrUpdateAsync(WaitUntil.Started, Recording.GenerateAssetName("mgmt-group-"), new ManagementGroupCreateOrUpdateContent());
            await mgmtGroupOp.WaitForCompletionAsync();
            ManagementGroupResource mgmtGroup = mgmtGroupOp.Value;
            await mgmtGroup.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await mgmtGroup.GetAsync());
            Assert.AreEqual(404, ex.Status);
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
            Assert.AreEqual(404, ex.Status);
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
            Assert.IsNull(descendant); //should have no descendants
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
            Assert.AreEqual("New Display Name", patchedMgmtGroup.Data.DisplayName);
            Assert.AreEqual(mgmtGroup.Data.Id, patchedMgmtGroup.Data.Id);
            Assert.AreEqual(mgmtGroup.Data.Name, patchedMgmtGroup.Data.Name);
            Assert.AreEqual(mgmtGroup.Data.TenantId, patchedMgmtGroup.Data.TenantId);
            Assert.AreEqual(mgmtGroup.Data.ResourceType, patchedMgmtGroup.Data.ResourceType);
        }
    }
}
