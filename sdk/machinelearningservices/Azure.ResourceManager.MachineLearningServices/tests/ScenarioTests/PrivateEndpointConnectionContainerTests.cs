// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class PrivateEndpointConnectionContainerTests : MachineLearningServicesManagerTestBase
    {
        private const string ResourceGroupNamePrefix = "test-PrivateEndpointConnectionContainer";
        private const string WorkspacePrefix = "test-workspace";
        private const string ResourceNamePrefix = "test-resource";
        private readonly Location _defaultLocation = Location.WestUS2;
        private string _resourceGroupName = ResourceGroupNamePrefix;
        private string _workspaceName = WorkspacePrefix;
        private string _resourceName = ResourceNamePrefix;

        public PrivateEndpointConnectionContainerTests(bool isAsync)
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

            Assert.DoesNotThrowAsync(async () => _ = await ws.GetPrivateEndpointConnections().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GeneratePrivateEndpointConnectionData()));

            var count = (await ws.GetPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync()).Count;
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);

            Assert.DoesNotThrowAsync(async () => _ = await ws.GetPrivateEndpointConnections().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GeneratePrivateEndpointConnectionData()));

            Assert.DoesNotThrowAsync(async () => await ws.GetPrivateEndpointConnections().GetAsync(_resourceName));
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await ws.GetPrivateEndpointConnections().GetAsync("NonExistant"));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);

            PrivateEndpointConnection resource = null;
            Assert.DoesNotThrowAsync(async () => resource = await ws.GetPrivateEndpointConnections().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GeneratePrivateEndpointConnectionData()));

            resource.Data.Tags.Add("UpdatedKey", "UpdatedValue");
            Assert.DoesNotThrowAsync(async () => resource = await ws.GetPrivateEndpointConnections().CreateOrUpdateAsync(
                _resourceName,
                resource.Data));
            Assert.AreEqual("Updated", resource.Data.Tags["UpdatedKey"]);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);

            PrivateEndpointConnection resource = null;
            Assert.DoesNotThrowAsync(async () => resource = await (await ws.GetPrivateEndpointConnections().StartCreateOrUpdateAsync(
                _resourceName,
                DataHelper.GeneratePrivateEndpointConnectionData())).WaitForCompletionAsync());

            resource.Data.Tags.Add("UpdatedKey", "UpdatedValue");
            Assert.DoesNotThrowAsync(async () => resource = await (await ws.GetPrivateEndpointConnections().StartCreateOrUpdateAsync(
                _resourceName,
                resource.Data)).WaitForCompletionAsync());
            Assert.AreEqual("Updated", resource.Data.Tags["UpdatedKey"]);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);

            Assert.DoesNotThrowAsync(async () => _ = await (await ws.GetPrivateEndpointConnections().StartCreateOrUpdateAsync(
                _resourceName,
                DataHelper.GeneratePrivateEndpointConnectionData())).WaitForCompletionAsync());

            Assert.IsTrue(await ws.GetPrivateEndpointConnections().CheckIfExistsAsync(_resourceName));
            Assert.IsFalse(await ws.GetPrivateEndpointConnections().CheckIfExistsAsync(_resourceName + "xyz"));
        }
    }
}
