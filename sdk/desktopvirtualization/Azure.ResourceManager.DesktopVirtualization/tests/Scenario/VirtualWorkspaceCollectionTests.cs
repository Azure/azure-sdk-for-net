// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DesktopVirtualization.Tests.Tests
{
    public class VirtualWorkspaceCollectionTests : DesktopVirtualizationManagementClientBase
    {
        public VirtualWorkspaceCollectionTests() : base(true)
        {
        }

        public VirtualWorkspaceCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        public VirtualWorkspaceCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        [Test]
        public async Task WorkspaceCrud()
        {
            var workspaceName = "testWorkspaceCrudWS";
            var resourceGroupName = Recording.GetVariable("DESKTOPVIRTUALIZATION_RESOURCE_GROUP", "azsdkRG");
            var rg = (ResourceGroupResource)await ResourceGroups.GetAsync(resourceGroupName);
            Assert.IsNotNull(rg);
            var workspaceCollection = rg.GetVirtualWorkspaces();
            var workspaceData = new VirtualWorkspaceData(
                "brazilsouth");

            var opWorkspaceCreate = await workspaceCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                workspaceName,
                workspaceData);

            Assert.IsNotNull(opWorkspaceCreate);
            Assert.IsTrue(opWorkspaceCreate.HasCompleted);
            Assert.AreEqual(opWorkspaceCreate.Value.Data.Name, workspaceName);

            var getOp = await workspaceCollection.GetAsync(
                workspaceName);

            Assert.AreEqual(workspaceName, getOp.Value.Data.Name);

            workspaceData.FriendlyName = "Friendly Name";
            opWorkspaceCreate = await workspaceCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                workspaceName,
                workspaceData);

            Assert.IsNotNull(opWorkspaceCreate);
            Assert.IsTrue(opWorkspaceCreate.HasCompleted);
            Assert.AreEqual(opWorkspaceCreate.Value.Data.Name, workspaceName);
            Assert.AreEqual(opWorkspaceCreate.Value.Data.FriendlyName, "Friendly Name");

            getOp = await workspaceCollection.GetAsync(
                workspaceName);

            var workspace = getOp.Value;
            var deleteOp = await workspace.DeleteAsync(WaitUntil.Completed);

            Assert.IsNotNull(deleteOp);

            Assert.AreEqual(200, deleteOp.GetRawResponse().Status);

            deleteOp = await workspace.DeleteAsync(WaitUntil.Completed);

            Assert.IsNotNull(deleteOp);

            Assert.AreEqual(204, deleteOp.GetRawResponse().Status);

            try
            {
                getOp = await workspaceCollection.GetAsync(
                    workspaceName);
            }
            catch (Azure.RequestFailedException ex)
            {
                Assert.AreEqual(404, ex.Status);
            }
        }
    }
}
