// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class DataVersionResourceContainerTests : MachineLearningServicesManagerTestBase
    {
        private const string ResourceGroupNamePrefix = "test-DataVersionResourceContainer";
        private const string WorkspacePrefix = "test-workspace";
        private const string ParentPrefix = "test-parent";
        private const string ResourceNamePrefix = "test-resource";
        private readonly Location _defaultLocation = Location.WestUS2;
        private string _resourceGroupName = ResourceGroupNamePrefix;
        private string _workspaceName = WorkspacePrefix;
        private string _resourceName = ResourceNamePrefix;
        private string _parentPrefix = ParentPrefix;

        public DataVersionResourceContainerTests(bool isAsync)
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

            _ = await ws.GetDataContainerResources().CreateOrUpdateAsync(
                _parentPrefix,
                DataHelper.GenerateDataContainerResourceData());
            StopSessionRecording();
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            DataContainerResource parent = await ws.GetDataContainerResources().GetAsync(_parentPrefix);

            Assert.DoesNotThrowAsync(async () => _ = await parent.GetDataVersionResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateDataVersionResourceData()));

            var count = (await parent.GetDataVersionResources().GetAllAsync().ToEnumerableAsync()).Count;
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            DataContainerResource parent = await ws.GetDataContainerResources().GetAsync(_parentPrefix);

            Assert.DoesNotThrowAsync(async () => _ = await parent.GetDataVersionResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateDataVersionResourceData()));

            Assert.DoesNotThrowAsync(async () => await parent.GetDataVersionResources().GetAsync(_resourceName));
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await parent.GetDataVersionResources().GetAsync("NonExistant"));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            DataContainerResource parent = await ws.GetDataContainerResources().GetAsync(_parentPrefix);

            DataVersionResource resource = null;
            Assert.DoesNotThrowAsync(async () => resource = await parent.GetDataVersionResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateDataVersionResourceData()));

            resource.Data.Properties.Description = "Updated";
            Assert.DoesNotThrowAsync(async () => resource = await parent.GetDataVersionResources().CreateOrUpdateAsync(
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
            DataContainerResource parent = await ws.GetDataContainerResources().GetAsync(_parentPrefix);

            DataVersionResource resource = null;
            Assert.DoesNotThrowAsync(async () => resource = await (await parent.GetDataVersionResources().StartCreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateDataVersionResourceData())).WaitForCompletionAsync());

            resource.Data.Properties.Description = "Updated";
            Assert.DoesNotThrowAsync(async () => resource = await (await parent.GetDataVersionResources().StartCreateOrUpdateAsync(
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
            DataContainerResource parent = await ws.GetDataContainerResources().GetAsync(_parentPrefix);

            Assert.DoesNotThrowAsync(async () => _ = await (await parent.GetDataVersionResources().StartCreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateDataVersionResourceData())).WaitForCompletionAsync());

            Assert.IsTrue(await parent.GetDataVersionResources().CheckIfExistsAsync(_resourceName));
            Assert.IsFalse(await parent.GetDataVersionResources().CheckIfExistsAsync(_resourceName + "xyz"));
        }
    }
}
