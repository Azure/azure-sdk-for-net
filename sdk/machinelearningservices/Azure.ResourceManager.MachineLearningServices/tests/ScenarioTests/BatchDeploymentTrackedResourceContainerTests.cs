// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class BatchDeploymentTrackedResourceContainerTests : MachineLearningServicesManagerTestBase
    {
        private const string ResourceGroupNamePrefix = "test-BatchDeploymentTrackedResourceContainer";
        private const string WorkspacePrefix = "test-workspace";
        private const string ParentPrefix = "test-parent";
        private const string ResourceNamePrefix = "test-resource";
        private readonly Location _defaultLocation = Location.WestUS2;
        private string _resourceGroupName = ResourceGroupNamePrefix;
        private string _workspaceName = WorkspacePrefix;
        private string _resourceName = ResourceNamePrefix;
        private string _parentPrefix = ParentPrefix;

        public BatchDeploymentTrackedResourceContainerTests(bool isAsync)
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

            _ = await ws.GetBatchEndpointTrackedResources().CreateOrUpdateAsync(
                _parentPrefix,
                DataHelper.GenerateBatchEndpointTrackedResourceData());
            StopSessionRecording();
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            BatchEndpointTrackedResource parent = await ws.GetBatchEndpointTrackedResources().GetAsync(_parentPrefix);

            Assert.DoesNotThrowAsync(async () => _ = await parent.GetBatchDeploymentTrackedResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateBatchDeploymentTrackedResourceData()));

            var count = (await parent.GetBatchDeploymentTrackedResources().GetAllAsync().ToEnumerableAsync()).Count;
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            BatchEndpointTrackedResource parent = await ws.GetBatchEndpointTrackedResources().GetAsync(_parentPrefix);

            Assert.DoesNotThrowAsync(async () => _ = await parent.GetBatchDeploymentTrackedResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateBatchDeploymentTrackedResourceData()));

            Assert.DoesNotThrowAsync(async () => await parent.GetBatchDeploymentTrackedResources().GetAsync(_resourceName));
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await parent.GetBatchDeploymentTrackedResources().GetAsync("NonExistant"));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            BatchEndpointTrackedResource parent = await ws.GetBatchEndpointTrackedResources().GetAsync(_parentPrefix);

            BatchDeploymentTrackedResource resource = null;
            Assert.DoesNotThrowAsync(async () => resource = await parent.GetBatchDeploymentTrackedResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateBatchDeploymentTrackedResourceData()));

            resource.Data.Properties.Description = "Updated";
            Assert.DoesNotThrowAsync(async () => resource = await parent.GetBatchDeploymentTrackedResources().CreateOrUpdateAsync(
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
            BatchEndpointTrackedResource parent = await ws.GetBatchEndpointTrackedResources().GetAsync(_parentPrefix);

            BatchDeploymentTrackedResource resource = null;
            Assert.DoesNotThrowAsync(async () => resource = await (await parent.GetBatchDeploymentTrackedResources().StartCreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateBatchDeploymentTrackedResourceData())).WaitForCompletionAsync());

            resource.Data.Properties.Description = "Updated";
            Assert.DoesNotThrowAsync(async () => resource = await (await parent.GetBatchDeploymentTrackedResources().StartCreateOrUpdateAsync(
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
            BatchEndpointTrackedResource parent = await ws.GetBatchEndpointTrackedResources().GetAsync(_parentPrefix);

            Assert.DoesNotThrowAsync(async () => _ = await (await parent.GetBatchDeploymentTrackedResources().StartCreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateBatchDeploymentTrackedResourceData())).WaitForCompletionAsync());

            Assert.IsTrue(await parent.GetBatchDeploymentTrackedResources().CheckIfExistsAsync(_resourceName));
            Assert.IsFalse(await parent.GetBatchDeploymentTrackedResources().CheckIfExistsAsync(_resourceName + "xyz"));
        }
    }
}
