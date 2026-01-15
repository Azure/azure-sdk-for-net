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
            Assert.That(opWorkspaceCreate.HasCompleted, Is.True);
            Assert.That(workspaceName, Is.EqualTo(opWorkspaceCreate.Value.Data.Name));

            Response<VirtualWorkspaceResource> getOp = await workspaceCollection.GetAsync(
                workspaceName);

            Assert.That(getOp.Value.Data.Name, Is.EqualTo(workspaceName));

            workspaceData.FriendlyName = "Friendly Name";
            opWorkspaceCreate = await workspaceCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                workspaceName,
                workspaceData);

            Assert.IsNotNull(opWorkspaceCreate);
            Assert.That(opWorkspaceCreate.HasCompleted, Is.True);
            Assert.That(workspaceName, Is.EqualTo(opWorkspaceCreate.Value.Data.Name));
            Assert.That(opWorkspaceCreate.Value.Data.FriendlyName, Is.EqualTo("Friendly Name"));

            getOp = await workspaceCollection.GetAsync(
                workspaceName);

            VirtualWorkspaceResource workspace = getOp.Value;
            ArmOperation deleteOp = await workspace.DeleteAsync(WaitUntil.Completed);

            Assert.IsNotNull(deleteOp);

            Assert.That(deleteOp.GetRawResponse().Status, Is.EqualTo(200));

            deleteOp = await workspace.DeleteAsync(WaitUntil.Completed);

            Assert.IsNotNull(deleteOp);

            Assert.That(deleteOp.GetRawResponse().Status, Is.EqualTo(204));

            try
            {
                getOp = await workspaceCollection.GetAsync(
                    workspaceName);
            }
            catch (Azure.RequestFailedException ex)
            {
                Assert.That(ex.Status, Is.EqualTo(404));
            }
        }
    }
}
