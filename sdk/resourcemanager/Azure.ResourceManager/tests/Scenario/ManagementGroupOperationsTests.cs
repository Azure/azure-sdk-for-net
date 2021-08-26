using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Management.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ManagementGroupOperationsTests : ResourceManagerTestBase
    {
        private ManagementGroup _mgmtGroup;
        private string _mgmtGroupName;
        
        public ManagementGroupOperationsTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GetGlobalManagementGroup()
        {
            _mgmtGroupName = SessionRecording.GenerateAssetName("mgmt-group-");
            _mgmtGroup = await GlobalClient.GetManagementGroups().CreateOrUpdateAsync(_mgmtGroupName, new CreateManagementGroupOptions());
            _mgmtGroup = await _mgmtGroup.GetAsync();
            StopSessionRecording();
        }

        [RecordedTest]
        public async Task Get()
        {
            var mgmtGroup = await Client.GetManagementGroup(_mgmtGroup.Id).GetAsync();
            CompareMgmtGroups(_mgmtGroup, mgmtGroup.Value);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => _ = await Client.GetManagementGroup(_mgmtGroup.Id + "x").GetAsync());
            Assert.AreEqual(403, ex.Status);
        }

        [RecordedTest]
        public async Task Delete()
        {
            ManagementGroup mgmtGroup = await Client.GetManagementGroups().CreateOrUpdateAsync(Recording.GenerateAssetName("mgmt-group-"), new CreateManagementGroupOptions());
            await mgmtGroup.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await mgmtGroup.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [RecordedTest]
        public async Task StartDelete()
        {
            ManagementGroup mgmtGroup = await Client.GetManagementGroups().CreateOrUpdateAsync(Recording.GenerateAssetName("mgmt-group-"), new CreateManagementGroupOptions());
            var deleteOp = await mgmtGroup.StartDeleteAsync();
            await deleteOp.WaitForCompletionResponseAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await mgmtGroup.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [RecordedTest]
        public async Task GetDescendants()
        {
            ManagementGroup mgmtGroup = await Client.GetManagementGroup(_mgmtGroup.Id).GetAsync();
            DescendantInfo descendant = null;
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
            ManagementGroup mgmtGroup = await Client.GetManagementGroups().CreateOrUpdateAsync(Recording.GenerateAssetName("mgmt-group-"), new CreateManagementGroupOptions());
            PatchManagementGroupOptions patch = new PatchManagementGroupOptions();
            patch.DisplayName = "New Display Name";
            ManagementGroup patchedMgmtGroup = await mgmtGroup.UpdateAsync(patch);
            Assert.AreEqual("New Display Name", patchedMgmtGroup.Data.DisplayName);
            Assert.AreEqual(mgmtGroup.Data.Id, patchedMgmtGroup.Data.Id);
            Assert.AreEqual(mgmtGroup.Data.Name, patchedMgmtGroup.Data.Name);
            Assert.AreEqual(mgmtGroup.Data.TenantId, patchedMgmtGroup.Data.TenantId);
            Assert.AreEqual(mgmtGroup.Data.Type, patchedMgmtGroup.Data.Type);
        }
    }
}
