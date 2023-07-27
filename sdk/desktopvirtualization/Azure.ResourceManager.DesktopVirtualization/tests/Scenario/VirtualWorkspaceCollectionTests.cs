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

        [TestCase]
        public async Task WorkspaceCrud()
        {
            string workspaceName = "testWorkspaceCrudWS";
            string resourceGroupName = Recording.GetVariable("DESKTOPVIRTUALIZATION_RESOURCE_GROUP", DefaultResourceGroupName);
            ResourceGroupResource rg = (ResourceGroupResource)await ResourceGroups.GetAsync(resourceGroupName);
            Assert.IsNotNull(rg);
            VirtualWorkspaceCollection workspaceCollection = rg.GetVirtualWorkspaces();
            VirtualWorkspaceData workspaceData = new VirtualWorkspaceData(
                DefaultLocation);

            ArmOperation<VirtualWorkspaceResource> opWorkspaceCreate = await workspaceCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                workspaceName,
                workspaceData);

            Assert.IsNotNull(opWorkspaceCreate);
            Assert.IsTrue(opWorkspaceCreate.HasCompleted);
            Assert.AreEqual(opWorkspaceCreate.Value.Data.Name, workspaceName);

            Response<VirtualWorkspaceResource> getOp = await workspaceCollection.GetAsync(
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

            VirtualWorkspaceResource workspace = getOp.Value;
            ArmOperation deleteOp = await workspace.DeleteAsync(WaitUntil.Completed);

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
