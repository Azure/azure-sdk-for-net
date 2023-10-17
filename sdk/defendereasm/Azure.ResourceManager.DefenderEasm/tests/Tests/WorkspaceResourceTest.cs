// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.DefenderEasm.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DefenderEasm.Tests.Tests
{
    public class WorkspaceResourceTest : DefenderEasmManagementTestBase
    {
        public WorkspaceResourceTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("Service not ready.")]
        public async Task WorkspaceCRUDTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(TestEnvironment.ResourceGroupName);
            EasmWorkspaceCollection workspaces = resourceGroup.GetEasmWorkspaces();
            String workspaceName = Recording.GenerateAssetName("workspace");
            EasmWorkspaceData workspaceResourceData = new EasmWorkspaceData("eastus");

            // create
            var createWorkspaceOperation = await workspaces.CreateOrUpdateAsync(WaitUntil.Completed, workspaceName, workspaceResourceData);
            Assert.AreEqual(workspaceResourceData.Location, createWorkspaceOperation.Value.Data.Location);

            // get
            EasmWorkspaceResource getWorkspaceOperation = await workspaces.GetAsync(workspaceName);
            Assert.AreEqual(workspaceResourceData.Location, getWorkspaceOperation.Data.Location);

            // update
            EasmWorkspacePatch workspaceResourcePatch = new EasmWorkspacePatch();
            workspaceResourcePatch.Tags.Add(new KeyValuePair<string, string>("testkey", "testvalue"));
            EasmWorkspaceResource updateWorkspaceOperation = await getWorkspaceOperation.UpdateAsync(workspaceResourcePatch);
            Assert.AreEqual(updateWorkspaceOperation.Data.Tags.Count, 1);

            // delete
            EasmWorkspaceResource w = await workspaces.GetAsync(workspaceName);
            ArmOperation operation = await w.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(operation.HasCompleted);
        }
    }
}
