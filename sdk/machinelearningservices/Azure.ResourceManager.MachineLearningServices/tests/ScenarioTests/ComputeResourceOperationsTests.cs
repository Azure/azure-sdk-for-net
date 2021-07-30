// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.MachineLearningServices.Models;
using Azure.ResourceManager.MachineLearningServices.Tests.Extensions;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class ComputeResourceOperationsTests : MachineLearningServicesManagerTestBase
    {
        private const string ResourceGroupNamePrefix = "test-ComputeResourceOperations";
        private const string WorkspacePrefix = "test-workspace";
        private const string ResourceNamePrefix = "mlcomp";
        private readonly Location _defaultLocation = Location.WestUS2;
        private string _resourceName = ResourceNamePrefix;
        private string _workspaceName = WorkspacePrefix;
        private string _resourceGroupName = ResourceGroupNamePrefix;

        public ComputeResourceOperationsTests(bool isAsync)
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

            Workspace ws = await rg.GetWorkspaces().CreateOrUpdateAsync(
                _workspaceName,
                DataHelper.GenerateWorkspaceData());

            _ = await ws.GetComputeResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateComputeResourceData());
            StopSessionRecording();
        }

        //BUGBUG
        //[TestCase]
        //[RecordedTest]
        public async Task Delete()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);

            var deleteResourceName = Recording.GenerateAssetName(ResourceNamePrefix) + "d";
            ComputeResource res = null;
            Assert.DoesNotThrowAsync(async () => res = await ws.GetComputeResources().CreateOrUpdateAsync(
                deleteResourceName,
                DataHelper.GenerateComputeResourceData()));
            Assert.DoesNotThrowAsync(async () => _ = await res.DeleteAsync());
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);

            ComputeResource resource = await ws.GetComputeResources().GetAsync(_resourceName);
            ComputeResource resource1 = await resource.GetAsync();
            resource.AssertAreEqual(resource1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);

            ComputeResource resource = await ws.GetComputeResources().GetAsync(_resourceName);
            var update = new ScaleSettings(5, 0, TimeSpan.FromMinutes(5));

            ComputeResource updatedResource = await resource.UpdateAsync(update);
            //BUGBUG
            //Assert.AreEqual(5, (updatedResource.Data.Properties as AmlCompute)?.Properties.ScaleSettings.MaxNodeCount);
            //Assert.AreEqual(0, (updatedResource.Data.Properties as AmlCompute)?.Properties.ScaleSettings.MinNodeCount);
            //Assert.AreEqual(TimeSpan.FromMinutes(5), (updatedResource.Data.Properties as AmlCompute)?.Properties.ScaleSettings.NodeIdleTimeBeforeScaleDown);
        }
    }
}
