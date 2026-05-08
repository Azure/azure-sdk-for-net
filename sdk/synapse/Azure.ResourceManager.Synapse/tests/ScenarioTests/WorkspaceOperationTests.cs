// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Synapse.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Synapse.Tests
{
    [Ignore("Test recordings need re-recording with current Storage SDK. See https://github.com/Azure/azure-sdk-for-net/issues/57594")]
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
        public async Task TestWorkspaceLifeCycle()
        {
            // create workspace
            string workspaceName = Recording.GenerateAssetName("synapsesdkworkspace");
            var createParams = CommonData.PrepareWorkspaceCreateParams();
            SynapseWorkspaceCollection workspaceCollection = ResourceGroup.GetSynapseWorkspaces();
            var workspaceCreate = (await workspaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, workspaceName, createParams)).Value;
            Assert.That(workspaceCreate.Id.ResourceType, Is.EqualTo(CommonTestFixture.WorkspaceType));
            Assert.That(workspaceCreate.Id.Name, Is.EqualTo(workspaceName));

            // update workspace
            createParams.Tags.Add("TestTag", "TestUpdate");
            var workspaceUpdate = (await workspaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, workspaceName, createParams)).Value;
            Assert.That(workspaceUpdate.Data.Tags, Is.Not.Null);
            Assert.That(workspaceUpdate.Data.Tags["TestTag"], Is.EqualTo("TestUpdate"));

            // list workspace from resource group
            var workspaceFromResourceGroup = workspaceCollection.GetAllAsync();
            var workspaceList = await workspaceFromResourceGroup.ToEnumerableAsync();
            var workspaceCount = workspaceList.Count;
            var workspace = workspaceList.Single(workspace => workspace.Data.Name == workspaceName);

            Assert.That(workspace != null, Is.True, string.Format("Workspace created earlier is not found when listing all in resource group {0}", CommonData.ResourceGroupName));

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
            Assert.That(workspaceList.Count, Is.EqualTo(workspaceCount - 1));
        }
    }
}
