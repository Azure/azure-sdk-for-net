// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class OnlineEndpointTrackedResourceContainerTests : MachineLearningServicesManagerTestBase
    {
        private const string ResourceGroupNamePrefix = "test-OnlineEndpointTrackedResourceContainer";
        private const string WorkspacePrefix = "test-workspace";
        private const string ResourceNamePrefix = "test-resource";
        private const string ComputeNamePrefix = "test-compute";
        private readonly Location _defaultLocation = Location.WestUS2;
        private string _resourceGroupName = ResourceGroupNamePrefix;
        private string _workspaceName = WorkspacePrefix;
        private string _resourceName = ResourceNamePrefix;
        private string _computeName = ComputeNamePrefix;

        public OnlineEndpointTrackedResourceContainerTests(bool isAsync)
         : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task SetupResources()
        {
            _resourceName = SessionRecording.GenerateAssetName(ResourceNamePrefix);
            _workspaceName = SessionRecording.GenerateAssetName(WorkspacePrefix);
            _resourceGroupName = SessionRecording.GenerateAssetName(ResourceGroupNamePrefix);
            _computeName = SessionRecording.GenerateAssetName(ComputeNamePrefix);

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
            ComputeResource compute = await ws.GetComputeResources().CreateOrUpdateAsync(
                _computeName,
                DataHelper.GenerateComputeResourceData());

            Assert.DoesNotThrowAsync(async () => _ = await ws.GetOnlineEndpointTrackedResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateOnlineEndpointTrackedResourceData()));

            var count = (await ws.GetOnlineEndpointTrackedResources().GetAllAsync().ToEnumerableAsync()).Count;
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            ComputeResource compute = await ws.GetComputeResources().CreateOrUpdateAsync(
                _computeName,
                DataHelper.GenerateComputeResourceData());

            Assert.DoesNotThrowAsync(async () => _ = await ws.GetOnlineEndpointTrackedResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateOnlineEndpointTrackedResourceData()));

            Assert.DoesNotThrowAsync(async () => await ws.GetOnlineEndpointTrackedResources().GetAsync(_resourceName));
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await ws.GetOnlineEndpointTrackedResources().GetAsync("NonExistant"));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            ComputeResource compute = await ws.GetComputeResources().CreateOrUpdateAsync(
                _computeName,
                DataHelper.GenerateComputeResourceData());

            OnlineEndpointTrackedResource resource = null;
            Assert.DoesNotThrowAsync(async () => resource = await ws.GetOnlineEndpointTrackedResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateOnlineEndpointTrackedResourceData()));

            resource.Data.Properties.Description = "Updated";
            Assert.DoesNotThrowAsync(async () => resource = await ws.GetOnlineEndpointTrackedResources().CreateOrUpdateAsync(
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
            ComputeResource compute = await ws.GetComputeResources().CreateOrUpdateAsync(
                _computeName,
                DataHelper.GenerateComputeResourceData());

            OnlineEndpointTrackedResource resource = null;
            Assert.DoesNotThrowAsync(async () => resource = await (await ws.GetOnlineEndpointTrackedResources().StartCreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateOnlineEndpointTrackedResourceData())).WaitForCompletionAsync());

            resource.Data.Properties.Description = "Updated";
            Assert.DoesNotThrowAsync(async () => resource = await (await ws.GetOnlineEndpointTrackedResources().StartCreateOrUpdateAsync(
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
            ComputeResource compute = await ws.GetComputeResources().CreateOrUpdateAsync(
                _computeName,
                DataHelper.GenerateComputeResourceData());

            Assert.DoesNotThrowAsync(async () => _ = await (await ws.GetOnlineEndpointTrackedResources().StartCreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateOnlineEndpointTrackedResourceData())).WaitForCompletionAsync());

            Assert.IsTrue(await ws.GetOnlineEndpointTrackedResources().CheckIfExistsAsync(_resourceName));
            Assert.IsFalse(await ws.GetOnlineEndpointTrackedResources().CheckIfExistsAsync(_resourceName + "xyz"));
        }
    }
}
