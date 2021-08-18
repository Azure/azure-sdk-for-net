// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.MachineLearningServices.Models;
using Azure.ResourceManager.MachineLearningServices.Tests.Extensions;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class OnlineDeploymentTrackedResourceOperationsTests : MachineLearningServicesManagerTestBase
    {
        private const string ResourceGroupNamePrefix = "test-OnlineDeploymentTrackedResourceOperations";
        private const string WorkspacePrefix = "test-workspace";
        private const string ParentPrefix = "test-parent";
        private const string ResourceNamePrefix = "test-resource";
        private const string ComputeNamePrefix = "test-compute";
        private readonly Location _defaultLocation = Location.WestUS2;
        private string _resourceName = ResourceNamePrefix;
        private string _workspaceName = WorkspacePrefix;
        private string _resourceGroupName = ResourceGroupNamePrefix;
        private string _parentPrefix = ParentPrefix;
        private string _computeName = ComputeNamePrefix;

        public OnlineDeploymentTrackedResourceOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task SetupResources()
        {
            _parentPrefix = SessionRecording.GenerateAssetName(ParentPrefix);
            _resourceName = SessionRecording.GenerateAssetName(ResourceNamePrefix);
            _resourceGroupName = SessionRecording.GenerateAssetName(ResourceGroupNamePrefix);
            _computeName = SessionRecording.GenerateAssetName(ComputeNamePrefix);

            // Create RG and Res with GlobalClient
            ResourceGroup rg = await GlobalClient.DefaultSubscription.GetResourceGroups()
                .CreateOrUpdateAsync(_resourceGroupName, new ResourceGroupData(_defaultLocation));

            Workspace ws = await rg.GetWorkspaces().CreateOrUpdateAsync(
                _workspaceName,
                DataHelper.GenerateWorkspaceData());

            ComputeResource compute = await ws.GetComputeResources().CreateOrUpdateAsync(
                _computeName,
                DataHelper.GenerateComputeResourceData());

            OnlineEndpointTrackedResource parent = await ws.GetOnlineEndpointTrackedResources().CreateOrUpdateAsync(
                _parentPrefix,
                DataHelper.GenerateOnlineEndpointTrackedResourceData());

            _ = await parent.GetOnlineDeploymentTrackedResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateOnlineDeploymentTrackedResourceData());
            StopSessionRecording();
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            OnlineEndpointTrackedResource parent = await ws.GetOnlineEndpointTrackedResources().GetAsync(_parentPrefix);

            var deleteResourceName = Recording.GenerateAssetName(ResourceNamePrefix) + "_delete";
            OnlineDeploymentTrackedResource res = null;
            Assert.DoesNotThrowAsync(async () => res = await parent.GetOnlineDeploymentTrackedResources().CreateOrUpdateAsync(
                deleteResourceName,
                DataHelper.GenerateOnlineDeploymentTrackedResourceData()));
            Assert.DoesNotThrowAsync(async () => _ = await res.DeleteAsync());
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            OnlineEndpointTrackedResource parent = await ws.GetOnlineEndpointTrackedResources().GetAsync(_parentPrefix);

            OnlineDeploymentTrackedResource resource = await parent.GetOnlineDeploymentTrackedResources().GetAsync(_resourceName);
            OnlineDeploymentTrackedResource resource1 = await resource.GetAsync();
            resource.AssertAreEqual(resource1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            OnlineEndpointTrackedResource parent = await ws.GetOnlineEndpointTrackedResources().GetAsync(_parentPrefix);

            OnlineDeploymentTrackedResource resource = await parent.GetOnlineDeploymentTrackedResources().GetAsync(_resourceName);
            var update = new PartialOnlineDeploymentPartialTrackedResource();
            OnlineDeploymentTrackedResource updatedResource = await resource.UpdateAsync(update);
            Assert.AreEqual("Updated", updatedResource.Data.Properties.Description);
        }
    }
}
