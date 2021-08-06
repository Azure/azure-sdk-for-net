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
    public class WorkspaceOperationsTests : MachineLearningServicesManagerTestBase
    {
        private const string ResourceGroupNamePrefix = "test-WorkspaceOperations";
        private const string ResourceNamePrefix = "test-resource";
        private readonly Location _defaultLocation = Location.WestUS2;
        private string _resourceName = ResourceNamePrefix;
        private string _resourceGroupName = ResourceGroupNamePrefix;

        public WorkspaceOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task SetupResources()
        {
            _resourceName = SessionRecording.GenerateAssetName(ResourceNamePrefix);
            _resourceGroupName = SessionRecording.GenerateAssetName(ResourceGroupNamePrefix);

            // Create RG and Res with GlobalClient
            ResourceGroup rg = await GlobalClient.DefaultSubscription.GetResourceGroups()
                .CreateOrUpdateAsync(_resourceGroupName, new ResourceGroupData(_defaultLocation));
            _ = await rg.GetWorkspaces().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateWorkspaceData());
            StopSessionRecording();
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            var deleteResourceName = Recording.GenerateAssetName(ResourceNamePrefix) + "_delete";
            Workspace ws = null;
            Assert.DoesNotThrowAsync(async () => ws = await rg.GetWorkspaces().CreateOrUpdateAsync(
                deleteResourceName,
                DataHelper.GenerateWorkspaceData()));
            Assert.DoesNotThrowAsync(async () => _ = await ws.DeleteAsync());
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace resource = await rg.GetWorkspaces().GetAsync(_resourceName);
            Workspace resource1 = await resource.GetAsync();
            resource.AssertAreEqual(resource1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace resource = await rg.GetWorkspaces().GetAsync(_resourceName);
            var update = new WorkspaceUpdateParameters { Description = "Updated" };
            Workspace updatedResource = await resource.UpdateAsync(update);
            Assert.AreEqual("Updated", updatedResource.Data.Description);
        }

        [Ignore("will be removed")]
        [TestCase]
        [RecordedTest]
        public async Task GetWorkspaceFeatures()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace resource = await rg.GetWorkspaces().GetAsync(_resourceName);
            var features = await resource.GetWorkspaceFeaturesAsync().ToEnumerableAsync();
            Assert.Greater(features.Count, 1);
        }
    }
}
