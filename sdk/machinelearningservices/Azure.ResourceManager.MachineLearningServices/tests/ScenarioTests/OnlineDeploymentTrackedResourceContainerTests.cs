// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class OnlineDeploymentTrackedResourceContainerTests : MachineLearningServicesManagerTestBase
    {
        private const string ResourceGroupNamePrefix = "test-OnlineDeploymentTrackedResourceContainer";
        private const string WorkspacePrefix = "test-workspace";
        private const string ParentPrefix = "test-parent";
        private const string ResourceNamePrefix = "test-resource";
        private readonly Location _defaultLocation = Location.WestUS2;
        private string _resourceGroupName = ResourceGroupNamePrefix;
        private string _workspaceName = WorkspacePrefix;
        private string _resourceName = ResourceNamePrefix;
        private string _parentPrefix = ParentPrefix;

        public OnlineDeploymentTrackedResourceContainerTests(bool isAsync)
         : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task SetupResources()
        {
            _parentPrefix = SessionRecording.GenerateAssetName(ParentPrefix);
            _resourceName = SessionRecording.GenerateAssetName(ResourceNamePrefix);
            _workspaceName = SessionRecording.GenerateAssetName(WorkspacePrefix);
            _resourceGroupName = SessionRecording.GenerateAssetName(ResourceGroupNamePrefix);

            ResourceGroup rg = await GlobalClient.DefaultSubscription.GetResourceGroups()
                .CreateOrUpdateAsync(_resourceGroupName, new ResourceGroupData(_defaultLocation));

            Workspace ws = await rg.GetWorkspaces().CreateOrUpdateAsync(
                _workspaceName,
                DataHelper.GenerateWorkspaceData());

            _ = await ws.GetOnlineEndpointTrackedResources().CreateOrUpdateAsync(
                _parentPrefix,
                DataHelper.GenerateOnlineEndpointTrackedResourceData(ws));
            StopSessionRecording();
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            OnlineEndpointTrackedResource parent = await ws.GetOnlineEndpointTrackedResources().GetAsync(_parentPrefix);

            Assert.DoesNotThrowAsync(async () => _ = await parent.GetOnlineDeploymentTrackedResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateOnlineDeploymentTrackedResourceData()));

            var count = (await parent.GetOnlineDeploymentTrackedResources().GetAllAsync().ToEnumerableAsync()).Count;
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            OnlineEndpointTrackedResource parent = await ws.GetOnlineEndpointTrackedResources().GetAsync(_parentPrefix);

            Assert.DoesNotThrowAsync(async () => _ = await parent.GetOnlineDeploymentTrackedResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateOnlineDeploymentTrackedResourceData()));

            Assert.DoesNotThrowAsync(async () => await parent.GetOnlineDeploymentTrackedResources().GetAsync(_resourceName));
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await parent.GetOnlineDeploymentTrackedResources().GetAsync("NonExistant"));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            OnlineEndpointTrackedResource parent = await ws.GetOnlineEndpointTrackedResources().GetAsync(_parentPrefix);

            OnlineDeploymentTrackedResource resource = null;
            Assert.DoesNotThrowAsync(async () => resource = await parent.GetOnlineDeploymentTrackedResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateOnlineDeploymentTrackedResourceData()));

            resource.Data.Properties.Description = "Updated";
            Assert.DoesNotThrowAsync(async () => resource = await parent.GetOnlineDeploymentTrackedResources().CreateOrUpdateAsync(
                _resourceName,
                resource.Data));
            Assert.AreEqual("Updated", resource.Data.Properties.Description);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            OnlineEndpointTrackedResource parent = await ws.GetOnlineEndpointTrackedResources().GetAsync(_parentPrefix);

            OnlineDeploymentTrackedResource resource = null;
            Assert.DoesNotThrowAsync(async () => resource = await (await parent.GetOnlineDeploymentTrackedResources().StartCreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateOnlineDeploymentTrackedResourceData())).WaitForCompletionAsync());

            resource.Data.Properties.Description = "Updated";
            Assert.DoesNotThrowAsync(async () => resource = await (await parent.GetOnlineDeploymentTrackedResources().StartCreateOrUpdateAsync(
                _resourceName,
                resource.Data)).WaitForCompletionAsync());
            Assert.AreEqual("Updated", resource.Data.Properties.Description);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            OnlineEndpointTrackedResource parent = await ws.GetOnlineEndpointTrackedResources().GetAsync(_parentPrefix);

            Assert.DoesNotThrowAsync(async () => _ = await (await parent.GetOnlineDeploymentTrackedResources().StartCreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateOnlineDeploymentTrackedResourceData())).WaitForCompletionAsync());

            Assert.IsTrue(await parent.GetOnlineDeploymentTrackedResources().CheckIfExistsAsync(_resourceName));
            Assert.IsFalse(await parent.GetOnlineDeploymentTrackedResources().CheckIfExistsAsync(_resourceName + "xyz"));
        }
    }
}
