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
    public class EnvironmentSpecificationVersionResourceOperationsTests : MachineLearningServicesManagerTestBase
    {
        private const string ResourceGroupNamePrefix = "test-EnvironmentSpecificationVersionResourceOperations";
        private const string WorkspacePrefix = "test-workspace";
        private const string EnvironmentPrefix = "test-env";
        private const string ResourceNamePrefix = "test-resource";
        private readonly Location _defaultLocation = Location.WestUS2;
        private string _resourceName = ResourceNamePrefix;
        private string _workspaceName = WorkspacePrefix;
        private string _environmentName = EnvironmentPrefix;
        private string _resourceGroupName = ResourceGroupNamePrefix;

        public EnvironmentSpecificationVersionResourceOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task SetupResources()
        {
            _environmentName = SessionRecording.GenerateAssetName(EnvironmentPrefix);
            _resourceName = SessionRecording.GenerateAssetName(ResourceNamePrefix);
            _resourceGroupName = SessionRecording.GenerateAssetName(ResourceGroupNamePrefix);

            // Create RG and Res with GlobalClient
            ResourceGroup rg = await GlobalClient.DefaultSubscription.GetResourceGroups()
                .CreateOrUpdateAsync(_resourceGroupName, new ResourceGroupData(_defaultLocation));

            Workspace ws = await rg.GetWorkspaces().CreateOrUpdateAsync(
                _workspaceName,
                DataHelper.GenerateWorkspaceData());

            EnvironmentContainerResource env = await ws.GetEnvironmentContainerResources().CreateOrUpdateAsync(
                _environmentName,
                DataHelper.GenerateEnvironmentContainerResourceData());

            _ = await env.GetEnvironmentSpecificationVersionResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateEnvironmentSpecificationVersionResourceData());
            StopSessionRecording();
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            EnvironmentContainerResource env = await ws.GetEnvironmentContainerResources().GetAsync(_environmentName);

            var deleteResourceName = Recording.GenerateAssetName(ResourceNamePrefix) + "_delete";
            EnvironmentSpecificationVersionResource res = null;
            Assert.DoesNotThrowAsync(async () => res = await env.GetEnvironmentSpecificationVersionResources().CreateOrUpdateAsync(
                deleteResourceName,
                DataHelper.GenerateEnvironmentSpecificationVersionResourceData()));
            Assert.DoesNotThrowAsync(async () => _ = await res.DeleteAsync());
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            EnvironmentContainerResource env = await ws.GetEnvironmentContainerResources().GetAsync(_environmentName);

            EnvironmentSpecificationVersionResource resource = await env.GetEnvironmentSpecificationVersionResources().GetAsync(_resourceName);
            EnvironmentSpecificationVersionResource resource1 = await resource.GetAsync();
            resource.AssertAreEqual(resource1);
        }
    }
}
