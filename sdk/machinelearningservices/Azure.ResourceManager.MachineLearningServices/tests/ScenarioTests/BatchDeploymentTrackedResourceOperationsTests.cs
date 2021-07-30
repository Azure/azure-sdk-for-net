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
    public class BatchDeploymentTrackedResourceOperationsTests : MachineLearningServicesManagerTestBase
    {
        private const string ResourceGroupNamePrefix = "test-BatchDeploymentTrackedResourceOperations";
        private const string WorkspacePrefix = "test-workspace";
        private const string ParentPrefix = "test-parent";
        private const string ResourceNamePrefix = "test-resource";
        private readonly Location _defaultLocation = Location.WestUS2;
        private string _resourceName = ResourceNamePrefix;
        private string _workspaceName = WorkspacePrefix;
        private string _resourceGroupName = ResourceGroupNamePrefix;
        private string _parentPrefix = ParentPrefix;

        public BatchDeploymentTrackedResourceOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task SetupResources()
        {
            _parentPrefix = SessionRecording.GenerateAssetName(ParentPrefix);
            _resourceName = SessionRecording.GenerateAssetName(ResourceNamePrefix);
            _resourceGroupName = SessionRecording.GenerateAssetName(ResourceGroupNamePrefix);

            // Create RG and Res with GlobalClient
            ResourceGroup rg = await GlobalClient.DefaultSubscription.GetResourceGroups()
                .CreateOrUpdateAsync(_resourceGroupName, new ResourceGroupData(_defaultLocation));

            Workspace ws = await rg.GetWorkspaces().CreateOrUpdateAsync(
                _workspaceName,
                DataHelper.GenerateWorkspaceData());

            BatchEndpointTrackedResource parent = await ws.GetBatchEndpointTrackedResources().CreateOrUpdateAsync(
                _parentPrefix,
                DataHelper.GenerateBatchEndpointTrackedResourceData());

            _ = await parent.GetBatchDeploymentTrackedResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateBatchDeploymentTrackedResourceData());
            StopSessionRecording();
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            BatchEndpointTrackedResource parent = await ws.GetBatchEndpointTrackedResources().GetAsync(_parentPrefix);

            var deleteResourceName = Recording.GenerateAssetName(ResourceNamePrefix) + "_delete";
            BatchDeploymentTrackedResource res = null;
            Assert.DoesNotThrowAsync(async () => res = await parent.GetBatchDeploymentTrackedResources().CreateOrUpdateAsync(
                deleteResourceName,
                DataHelper.GenerateBatchDeploymentTrackedResourceData()));
            Assert.DoesNotThrowAsync(async () => _ = await res.DeleteAsync());
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            BatchEndpointTrackedResource parent = await ws.GetBatchEndpointTrackedResources().GetAsync(_parentPrefix);

            BatchDeploymentTrackedResource resource = await parent.GetBatchDeploymentTrackedResources().GetAsync(_resourceName);
            BatchDeploymentTrackedResource resource1 = await resource.GetAsync();
            resource.AssertAreEqual(resource1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            BatchEndpointTrackedResource parent = await ws.GetBatchEndpointTrackedResources().GetAsync(_parentPrefix);

            BatchDeploymentTrackedResource resource = await parent.GetBatchDeploymentTrackedResources().GetAsync(_resourceName);
            var update = new PartialBatchDeploymentPartialTrackedResource();
            BatchDeploymentTrackedResource updatedResource = await resource.UpdateAsync(update);
            Assert.AreEqual("Updated", updatedResource.Data.Properties.Description);
        }
    }
}
