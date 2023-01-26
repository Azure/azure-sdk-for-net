// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.LoadTesting.Models;
using Azure.ResourceManager.LoadTesting.Tests.Helpers;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.LoadTesting.Tests
{
    public class LoadTestingResourceOperations : LoadTestingManagementTestBase
    {
        private LoadTestingResourceCollection _loadTestResourceCollection { get; set; }
        private LoadTestingResource _loadTestResource { get; set; }
        private LoadTestingResourceData _loadTestResourceData { get; set; }

        public LoadTestingResourceOperations(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await TryRegisterResourceGroupAsync(ResourceGroupsOperations, LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION, resourceGroupName);

            _loadTestResourceCollection = (await GetResourceGroupAsync(resourceGroupName)).GetLoadTestingResources();
            _loadTestResourceData = new LoadTestingResourceData(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [RecordedTest]
        public async Task LoadTestingResourceOperationTests()
        {
            var loadTestResourceName = Recording.GenerateAssetName("Sdk-LoadTestService-DotNet");

            //// Create
            ArmOperation<LoadTestingResource> loadTestCreateResponse = await _loadTestResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, loadTestResourceName, _loadTestResourceData);

            Assert.IsTrue(loadTestCreateResponse.HasCompleted);
            Assert.IsTrue(loadTestCreateResponse.HasValue);
            Assert.IsTrue(loadTestCreateResponse.Value.HasData);
            Assert.AreEqual(loadTestResourceName, loadTestCreateResponse.Value.Data.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION, loadTestCreateResponse.Value.Data.Location.Name);
            Assert.AreEqual(ProviderConstants.DefaultProviderNamespace.ToLower() + LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), loadTestCreateResponse.Value.Data.ResourceType.ToString().ToLower());
            Assert.AreEqual(LoadTestingProvisioningState.Succeeded, loadTestCreateResponse.Value.Data.ProvisioningState);
            Assert.NotNull(loadTestCreateResponse.Value.Data.DataPlaneUri);
            Assert.IsNull(loadTestCreateResponse.Value.Data.Encryption);

            //// Get
            Response<LoadTestingResource> loadTestGetResponse = await loadTestCreateResponse.Value.GetAsync();
            LoadTestingResource loadTestGetResponseValue = loadTestGetResponse.Value;

            Assert.IsNotNull(loadTestGetResponseValue);
            Assert.IsTrue(loadTestGetResponseValue.HasData);
            Assert.AreEqual(loadTestResourceName, loadTestGetResponseValue.Data.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION, loadTestGetResponseValue.Data.Location.Name);
            Assert.AreEqual(ProviderConstants.DefaultProviderNamespace.ToLower() + LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), loadTestGetResponseValue.Data.ResourceType.ToString().ToLower());
            Assert.AreEqual(LoadTestingProvisioningState.Succeeded, loadTestGetResponseValue.Data.ProvisioningState);
            Assert.NotNull(loadTestGetResponseValue.Data.DataPlaneUri);
            Assert.IsNull(loadTestGetResponseValue.Data.Encryption);

            loadTestGetResponse = await _loadTestResourceCollection.GetAsync(loadTestResourceName);
            loadTestGetResponseValue = loadTestGetResponse.Value;

            Assert.IsNotNull(loadTestGetResponseValue);
            Assert.IsTrue(loadTestGetResponseValue.HasData);
            Assert.AreEqual(loadTestResourceName, loadTestGetResponseValue.Data.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION, loadTestGetResponseValue.Data.Location.Name);
            Assert.AreEqual(ProviderConstants.DefaultProviderNamespace.ToLower() + LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), loadTestGetResponseValue.Data.ResourceType.ToString().ToLower());
            Assert.AreEqual(LoadTestingProvisioningState.Succeeded, loadTestGetResponseValue.Data.ProvisioningState);
            Assert.NotNull(loadTestGetResponseValue.Data.DataPlaneUri);
            Assert.IsNull(loadTestGetResponseValue.Data.Encryption);

            List<LoadTestingResource> loadTestResources = await _loadTestResourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(loadTestResources);
            foreach (LoadTestingResource resource in loadTestResources)
            {
                Assert.IsNotNull(resource);
                Assert.IsTrue(resource.HasData);
                Assert.IsNotNull(resource.Data.Id);
                Assert.IsNotNull(resource.Data.Name);
                Assert.AreEqual(ProviderConstants.DefaultProviderNamespace.ToLower() + LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), resource.Data.ResourceType.ToString().ToLower());
                Assert.AreEqual(LoadTestingProvisioningState.Succeeded, resource.Data.ProvisioningState);
                Assert.NotNull(resource.Data.DataPlaneUri);
                Assert.IsNull(resource.Data.Encryption);
            }

            //// List outbound network dependencies
            List<LoadTestingOutboundEnvironmentEndpoint> outboundNetworkDependencyResponse = await loadTestGetResponseValue.GetOutboundNetworkDependenciesEndpointsAsync().ToEnumerableAsync();
            Assert.IsNotNull(outboundNetworkDependencyResponse);

            //// Patch
            LoadTestingResourcePatch resourcePatchPayload = new LoadTestingResourcePatch
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Description = LoadTestResourceHelper.LOAD_TEST_DESCRIPTION
            };
            ArmOperation<LoadTestingResource> loadTestPatchResponse = await loadTestGetResponseValue.UpdateAsync(WaitUntil.Completed, resourcePatchPayload);
            LoadTestingResource loadTestPatchResponseValue = loadTestPatchResponse.Value;

            Assert.IsNotNull(loadTestPatchResponseValue);
            Assert.IsTrue(loadTestPatchResponseValue.HasData);
            Assert.AreEqual(loadTestResourceName, loadTestPatchResponseValue.Data.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION, loadTestPatchResponseValue.Data.Location.Name);
            Assert.AreEqual(ProviderConstants.DefaultProviderNamespace.ToLower() + LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), loadTestPatchResponseValue.Data.ResourceType.ToString().ToLower());
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, loadTestPatchResponseValue.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(LoadTestingProvisioningState.Succeeded, loadTestPatchResponseValue.Data.ProvisioningState);
            Assert.AreEqual(LoadTestResourceHelper.LOAD_TEST_DESCRIPTION, loadTestPatchResponseValue.Data.Description);
            Assert.NotNull(loadTestPatchResponseValue.Data.DataPlaneUri);
            Assert.IsNull(loadTestPatchResponseValue.Data.Encryption);

            //// Delete
            ArmOperation loadTestDeleteResponse = await loadTestPatchResponseValue.DeleteAsync(WaitUntil.Completed);
            await loadTestDeleteResponse.WaitForCompletionResponseAsync();
            Assert.IsTrue(loadTestDeleteResponse.HasCompleted);
        }

        [RecordedTest]
        [PlaybackOnly("Ignoring on live tests, due to possibility of huge service calls.")]
        public async Task LoadTestResourceOperationExtensionTests()
        {
            AsyncPageable<LoadTestingResource> loadtestResources = Subscription.GetLoadTestingResourcesAsync();
            List<LoadTestingResource> resourceList = await loadtestResources.ToEnumerableAsync();
            Assert.IsNotNull(resourceList);
        }
    }
}
