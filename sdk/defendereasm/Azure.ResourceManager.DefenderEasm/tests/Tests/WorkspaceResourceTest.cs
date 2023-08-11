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

        [TestCase]
        [RecordedTest]
        public async Task WorkspaceCRUDTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(TestEnvironment.ResourceGroupName);
            WorkspaceResourceCollection workspaces = resourceGroup.GetWorkspaceResources();
            String workspaceName = Recording.GenerateAssetName("workspace");
            WorkspaceResourceData workspaceResourceData = new WorkspaceResourceData("eastus");

            // create
            var createWorkspaceOperation = await workspaces.CreateOrUpdateAsync(WaitUntil.Completed, workspaceName, workspaceResourceData);
            Assert.AreEqual(workspaceResourceData.Location, createWorkspaceOperation.Value.Data.Location);

            // get
            WorkspaceResource getWorkspaceOperation = await workspaces.GetAsync(workspaceName);
            Assert.AreEqual(workspaceResourceData.Location, getWorkspaceOperation.Data.Location);

            // update
            WorkspaceResourcePatch workspaceResourcePatch = new WorkspaceResourcePatch();
            workspaceResourcePatch.Tags.Add(new KeyValuePair<string, string>("testkey", "testvalue"));
            WorkspaceResource updateWorkspaceOperation = await getWorkspaceOperation.UpdateAsync(workspaceResourcePatch);
            Assert.AreEqual(updateWorkspaceOperation.Data.Tags.Count, 1);

            // delete
            WorkspaceResource w = await workspaces.GetAsync(workspaceName);
            ArmOperation operation = await w.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(operation.HasCompleted);
        }
    }
}
