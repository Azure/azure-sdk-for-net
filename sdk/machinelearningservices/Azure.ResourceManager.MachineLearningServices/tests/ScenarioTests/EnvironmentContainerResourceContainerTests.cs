// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class EnvironmentContainerResourceContainerTests : MachineLearningServicesManagerTestBase
    {
        private const string ResourceGroupNamePrefix = "test-EnvironmentContainerResourceContainer";
        private const string WorkspacePrefix = "test-workspace";
        private const string ResourceNamePrefix = "test-resource";
        private readonly Location _defaultLocation = Location.WestUS2;
        private string _resourceGroupName = ResourceGroupNamePrefix;
        private string _workspaceName = WorkspacePrefix;
        private string _resourceName = ResourceNamePrefix;

        public EnvironmentContainerResourceContainerTests(bool isAsync)
         : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task SetupResources()
        {
            _resourceName = SessionRecording.GenerateAssetName(ResourceNamePrefix);
            _workspaceName = SessionRecording.GenerateAssetName(WorkspacePrefix);
            _resourceGroupName = SessionRecording.GenerateAssetName(ResourceGroupNamePrefix);

            ResourceGroup rg = await GlobalClient.DefaultSubscription.GetResourceGroups()
                .CreateOrUpdateAsync(_resourceGroupName, new ResourceGroupData(_defaultLocation));

            _ = await rg.GetWorkspaces().CreateOrUpdateAsync(
                _workspaceName,
                DataHelper.GenerateWorkspaceData());
            StopSessionRecording();
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);

            var count = (await ws.GetEnvironmentContainerResources().GetAllAsync().ToEnumerableAsync()).Count;
            Assert.Greater(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);

            var envs = await ws.GetEnvironmentContainerResources().GetAllAsync().ToEnumerableAsync();
            Assert.Greater(envs.Count, 1);
            var firstEnvName = envs.First().Data.Name;

            Assert.DoesNotThrowAsync(async () =>
            {
                var env = await ws.GetEnvironmentContainerResources().GetAsync(firstEnvName);
                Assert.AreEqual(firstEnvName, env.Value.Data.Name);
            });
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await ws.GetEnvironmentContainerResources().GetAsync("NonExistant"));
        }

        // BUGBUG Environment does not support C, R, D even as swagger indicated so
        //[TestCase]
        //[RecordedTest]
        public async Task CreateOrUpdate()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);

            EnvironmentContainerResource resource = null;
            Assert.DoesNotThrowAsync(async () => resource = await ws.GetEnvironmentContainerResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateEnvironmentContainerResourceData()));

            resource.Data.Properties.Description = "Updated";
            Assert.DoesNotThrowAsync(async () => resource = await ws.GetEnvironmentContainerResources().CreateOrUpdateAsync(
                _resourceName,
                resource.Data.Properties));
            Assert.AreEqual("Updated", resource.Data.Properties.Description);
        }

        // BUGBUG Environment does not support C, R, D even as swagger indicated so
        //[TestCase]
        //[RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);

            EnvironmentContainerResource resource = null;
            Assert.DoesNotThrowAsync(async () => resource = await (await ws.GetEnvironmentContainerResources().StartCreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateEnvironmentContainerResourceData())).WaitForCompletionAsync());

            resource.Data.Properties.Description = "Updated";
            Assert.DoesNotThrowAsync(async () => resource = await (await ws.GetEnvironmentContainerResources().StartCreateOrUpdateAsync(
                _resourceName,
                resource.Data.Properties)).WaitForCompletionAsync());
            Assert.AreEqual("Updated", resource.Data.Properties.Description);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);

            var envs = await ws.GetEnvironmentContainerResources().GetAllAsync().ToEnumerableAsync();
            Assert.Greater(envs.Count, 1);
            var firstEnvName = envs.First().Data.Name;

            Assert.IsTrue(await ws.GetEnvironmentContainerResources().CheckIfExistsAsync(firstEnvName));
            Assert.IsFalse(await ws.GetEnvironmentContainerResources().CheckIfExistsAsync(firstEnvName + "xyz"));
        }
    }
}
