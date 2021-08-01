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
    public class EnvironmentSpecificationVersionResourceContainerTests : MachineLearningServicesManagerTestBase
    {
        private const string ResourceGroupNamePrefix = "test-EnvironmentSpecificationVersionResourceContainer";
        private const string WorkspacePrefix = "test-workspace";
        private const string EnvironmentPrefix = "test-env";
        private const string ResourceNamePrefix = "testenvversion";
        private readonly Location _defaultLocation = Location.WestUS2;
        private string _resourceGroupName = ResourceGroupNamePrefix;
        private string _workspaceName = WorkspacePrefix;
        private string _environmentName = EnvironmentPrefix;
        private string _resourceName = ResourceNamePrefix;

        public EnvironmentSpecificationVersionResourceContainerTests(bool isAsync)
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

            Workspace ws = await rg.GetWorkspaces().CreateOrUpdateAsync(
                _workspaceName,
                DataHelper.GenerateWorkspaceData());

            var envs = await ws.GetEnvironmentContainerResources().GetAllAsync().ToEnumerableAsync();
            Assert.Greater(envs.Count, 1);
            _environmentName = envs.First().Data.Name;

            StopSessionRecording();
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            EnvironmentContainerResource env = await ws.GetEnvironmentContainerResources().GetAsync(_environmentName);

            Assert.DoesNotThrowAsync(async () => _ = await env.GetEnvironmentSpecificationVersionResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateEnvironmentSpecificationVersionResourceData()));

            var count = (await env.GetEnvironmentSpecificationVersionResources().GetAllAsync().ToEnumerableAsync()).Count;
            Assert.Greater(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            EnvironmentContainerResource env = await ws.GetEnvironmentContainerResources().GetAsync(_environmentName);

            Assert.DoesNotThrowAsync(async () => _ = await env.GetEnvironmentSpecificationVersionResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateEnvironmentSpecificationVersionResourceData()));

            Assert.DoesNotThrowAsync(async () => await env.GetEnvironmentSpecificationVersionResources().GetAsync(_resourceName));
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await env.GetEnvironmentSpecificationVersionResources().GetAsync("NonExistant"));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            EnvironmentContainerResource env = await ws.GetEnvironmentContainerResources().GetAsync(_environmentName);

            EnvironmentSpecificationVersionResource resource = null;
            Assert.DoesNotThrowAsync(async () => resource = await env.GetEnvironmentSpecificationVersionResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateEnvironmentSpecificationVersionResourceData()));

            resource.Data.Properties.Description = "Updated";
            Assert.DoesNotThrowAsync(async () => resource = await env.GetEnvironmentSpecificationVersionResources().CreateOrUpdateAsync(
                _resourceName,
                resource.Data.Properties));
            Assert.AreEqual("Updated", resource.Data.Properties.Description);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            EnvironmentContainerResource env = await ws.GetEnvironmentContainerResources().GetAsync(_environmentName);

            EnvironmentSpecificationVersionResource resource = null;
            Assert.DoesNotThrowAsync(async () => resource = await (await env.GetEnvironmentSpecificationVersionResources().StartCreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateEnvironmentSpecificationVersionResourceData())).WaitForCompletionAsync());

            resource.Data.Properties.Description = "Updated";
            Assert.DoesNotThrowAsync(async () => resource = await (await env.GetEnvironmentSpecificationVersionResources().StartCreateOrUpdateAsync(
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
            EnvironmentContainerResource env = await ws.GetEnvironmentContainerResources().GetAsync(_environmentName);

            Assert.DoesNotThrowAsync(async () => _ = await (await env.GetEnvironmentSpecificationVersionResources().StartCreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateEnvironmentSpecificationVersionResourceData())).WaitForCompletionAsync());

            Assert.IsTrue(await env.GetEnvironmentSpecificationVersionResources().CheckIfExistsAsync(_resourceName));
            Assert.IsFalse(await env.GetEnvironmentSpecificationVersionResources().CheckIfExistsAsync(_resourceName + "xyz"));
        }
    }
}
