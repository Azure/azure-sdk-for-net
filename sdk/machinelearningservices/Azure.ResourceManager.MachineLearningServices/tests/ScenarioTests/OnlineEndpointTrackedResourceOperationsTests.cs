// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.MachineLearningServices.Models;
using Azure.ResourceManager.MachineLearningServices.Tests.Extensions;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class OnlineEndpointTrackedResourceOperationsTests : MachineLearningServicesManagerTestBase
    {
        private const string ResourceGroupNamePrefix = "test-mlrg";
        private const string WorkspacePrefix = "test-workspace";
        private const string ResourceNamePrefix = "test-resource";
        private const string ComputeNamePrefix = "test-compute";
        private readonly Location _defaultLocation = Location.WestUS2;
        private string _resourceName = ResourceNamePrefix;
        private string _workspaceName = WorkspacePrefix;
        private string _resourceGroupName = ResourceGroupNamePrefix;
        private string _computeName = ComputeNamePrefix;

        public OnlineEndpointTrackedResourceOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task SetupResources()
        {
            _resourceName = SessionRecording.GenerateAssetName(ResourceNamePrefix);
            _resourceGroupName = SessionRecording.GenerateAssetName(ResourceGroupNamePrefix);
            _computeName = SessionRecording.GenerateAssetName(ComputeNamePrefix);

            // Create RG and Res with GlobalClient
            ResourceGroup rg = await GlobalClient.DefaultSubscription.GetResourceGroups()
                .CreateOrUpdateAsync(_resourceGroupName, new ResourceGroupData(_defaultLocation));

            var id = $"/subscriptions/{SessionEnvironment.SubscriptionId}/resourceGroups/test-ml-common/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mltestid";
            var result = GlobalClient.DefaultSubscription.GetGenericResources().GetAsync(id)
                .ConfigureAwait(false).GetAwaiter().GetResult();

            Workspace ws = await rg.GetWorkspaces().CreateOrUpdateAsync(
                _workspaceName,
                DataHelper.GenerateWorkspaceData());

            _ = await ws.GetOnlineEndpointTrackedResources().CreateOrUpdateAsync(
                _resourceName,
                DataHelper.GenerateOnlineEndpointTrackedResourceData(result));
            StopSessionRecording();
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);
            ComputeResource compute = await ws.GetComputeResources().GetAsync(_computeName);

            var deleteResourceName = Recording.GenerateAssetName(ResourceNamePrefix) + "_delete";
            OnlineEndpointTrackedResource res = null;
            Assert.DoesNotThrowAsync(async () => res = await ws.GetOnlineEndpointTrackedResources().CreateOrUpdateAsync(
                deleteResourceName,
                DataHelper.GenerateOnlineEndpointTrackedResourceData()));
            Assert.DoesNotThrowAsync(async () => _ = await res.DeleteAsync());
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);

            OnlineEndpointTrackedResource resource = await ws.GetOnlineEndpointTrackedResources().GetAsync(_resourceName);
            OnlineEndpointTrackedResource resource1 = await resource.GetAsync();
            resource.AssertAreEqual(resource1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync(_resourceGroupName);
            Workspace ws = await rg.GetWorkspaces().GetAsync(_workspaceName);

            OnlineEndpointTrackedResource resource = await ws.GetOnlineEndpointTrackedResources().GetAsync(_resourceName);
            var update = new PartialOnlineEndpointPartialTrackedResource() { Properties = new PartialOnlineEndpoint() { Traffic = { { "deployment1", 0 } } } };
            OnlineEndpointTrackedResource updatedResource = await resource.UpdateAsync(update);
            Assert.AreEqual(0, updatedResource.Data.Properties.Traffic["deployment1"]);
        }

        private ComputeResourceData GenerateComputeResourceData(string rgId)
        {
            return new ComputeResourceData
            {
                Location = Location.WestUS2,
                Properties = new ComputeInstance
                {
                    Properties = new ComputeInstanceProperties
                    {
                        VmSize = "STANDARD_NC6",
                        ApplicationSharingPolicy = ApplicationSharingPolicy.Personal,
                        SshSettings = new ComputeInstanceSshSettings() { SshPublicAccess = SshPublicAccess.Disabled },
                        ComputeInstanceAuthorizationType = ComputeInstanceAuthorizationType.Personal,
                        PersonalComputeInstanceSettings = new PersonalComputeInstanceSettings(new AssignedUser(Environment.GetEnvironmentVariable("OBJECT_ID"), SessionEnvironment.TenantId)),
                        Subnet = new ResourceId(rgId + "/providers/Microsoft.Network/virtualNetworks/testvnet/subnets/testvnet")
                    }
                }
            };
        }
    }
}
