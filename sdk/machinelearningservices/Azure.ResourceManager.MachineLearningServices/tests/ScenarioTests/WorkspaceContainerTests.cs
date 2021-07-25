// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class WorkspaceContainerTests : MachineLearningServicesManagerTestBase
    {
        public WorkspaceContainerTests(bool isAsync)
         : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            ResourceGroup rg = await CreateTestResourceGroup();

            Assert.DoesNotThrowAsync(async () => _ = await CreateMLWorkspaceAsync(rg));

            var count = (await rg.GetWorkspaces().ListAsync().ToEnumerableAsync()).Count;
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await CreateTestResourceGroup();

            Workspace workspace1 = await CreateMLWorkspaceAsync(rg);
            Workspace workspace2 = await rg.GetWorkspaces().GetAsync(workspace1.Data.Name);
            Assert.AreEqual(workspace1.Id, workspace2.Id);

            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await rg.GetWorkspaces().GetAsync("NonExistant"));
        }

        //public Task TryGet();

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ResourceGroup rg = await CreateTestResourceGroup();
            var workspaceName = Recording.GenerateAssetName("testmlCreate");
            var workspace = await CreateMLWorkspaceAsync(rg, workspaceName);

            Assert.AreEqual(rg.Id.AppendProviderResource("Microsoft.MachineLearningServices", "workspaces",workspaceName).ToString(), workspace.Data.Id.ToString());
            Assert.AreEqual(workspaceName, workspace.Data.Name);
            Assert.AreEqual(WorkspaceOperations.ResourceType, workspace.Data.Type);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            ResourceGroup rg = await CreateTestResourceGroup();
            var workspaceName = Recording.GenerateAssetName("testmlCreate");
            Workspace workspace = await (await rg.GetWorkspaces().StartCreateOrUpdateAsync(workspaceName, GenerateWorkspaceData())).WaitForCompletionAsync();

            Assert.AreEqual(rg.Id.AppendProviderResource("Microsoft.MachineLearningServices", "workspaces", workspaceName), workspace.Data.Id.ToString());
            Assert.AreEqual(workspaceName, workspace.Data.Name);
            Assert.AreEqual(WorkspaceOperations.ResourceType, workspace.Data.Type);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            ResourceGroup rg = await CreateTestResourceGroup();
            var workspace = await CreateMLWorkspaceAsync(rg);

            Assert.IsTrue(await rg.GetWorkspaces().DoesExistAsync(workspace.Data.Name));
            Assert.IsFalse(await rg.GetWorkspaces().DoesExistAsync(workspace.Data.Name + "xyz"));
        }

        private async Task<ResourceGroup> CreateTestResourceGroup()
        {
            return await Client
                .DefaultSubscription
                .GetResourceGroups()
                .Construct(Location.WestUS2)
                .CreateOrUpdateAsync(Recording.GenerateAssetName("testmlrg"));
        }
    }
}
