// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Synapse.Tests.Helpers;
using NUnit.Framework;
using System.Linq;
using System;
using System.IO;

namespace Azure.ResourceManager.Synapse.Tests
{
    public class WorkspaceOperationTests : SynapseManagementTestBase
    {
        public WorkspaceOperationTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task Initialize()
        {
            await TestInitialize();
        }

        [Test]
        [RecordedTest]
        [Ignore("This test is failing due to the api-version sanitization.")]
        public async Task TestWorkspaceLifeCycle()
        {
            // create workspace
            string workspaceName = Recording.GenerateAssetName("synapsesdkworkspace");
            var createParams = CommonData.PrepareWorkspaceCreateParams();
            SynapseWorkspaceCollection workspaceCollection = ResourceGroup.GetSynapseWorkspaces();
            var workspaceCreate = (await workspaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, workspaceName, createParams)).Value;
            Assert.AreEqual(CommonTestFixture.WorkspaceType, workspaceCreate.Id.ResourceType);
            Assert.AreEqual(workspaceName, workspaceCreate.Id.Name);

            // update workspace
            createParams.Tags.Add("TestTag", "TestUpdate");
            var workspaceUpdate = (await workspaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, workspaceName, createParams)).Value;
            Assert.NotNull(workspaceUpdate.Data.Tags);
            Assert.AreEqual("TestUpdate", workspaceUpdate.Data.Tags["TestTag"]);

            // list workspace from resource group
            var workspaceFromResourceGroup = workspaceCollection.GetAllAsync();
            var workspaceList = await workspaceFromResourceGroup.ToEnumerableAsync();
            var workspaceCount = workspaceList.Count;
            var workspace = workspaceList.Single(workspace => workspace.Data.Name == workspaceName);

            Assert.True(workspace != null, string.Format("Workspace created earlier is not found when listing all in resource group {0}", CommonData.ResourceGroupName));

            try
            {
                // delete workspace
                await workspace.DeleteAsync(WaitUntil.Completed);
            }
            catch (Exception)
            {
                // Ignore
            }

            workspaceList = await workspaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(workspaceCount - 1, workspaceList.Count);
        }
    }
}
