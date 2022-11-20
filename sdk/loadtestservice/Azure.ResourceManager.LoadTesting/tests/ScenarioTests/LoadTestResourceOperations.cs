// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.LoadTesting;
using Azure.ResourceManager.LoadTesting.Models;
using Azure.ResourceManager.LoadTesting.Tests;
using Azure.ResourceManager.LoadTesting.Tests.Helpers;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.LoadTestService.Tests
{
    public class LoadTestResourceOperations : LoadTestingManagementTestBase
    {
        private LoadTestResourceCollection _loadTestResourceCollection { get; set; }
        private LoadTestResource _loadTestResource { get; set; }
        private LoadTestResourceData _loadTestResourceData { get; set; }

        public LoadTestResourceOperations(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
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

            _loadTestResourceCollection = (await GetResourceGroupAsync(resourceGroupName)).GetLoadTestResources();
            _loadTestResourceData = new LoadTestResourceData(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [RecordedTest]
        public async Task LoadTestResourceOperationTests()
        {
            var loadTestResourceName = Recording.GenerateAssetName("Sdk-LoadTestService-DotNet");

            //// Create
            ArmOperation<LoadTestResource> loadTestCreateResponse = await _loadTestResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, loadTestResourceName, _loadTestResourceData);

            Assert.IsTrue(loadTestCreateResponse.HasCompleted);
            Assert.IsTrue(loadTestCreateResponse.HasValue);
            Assert.IsTrue(loadTestCreateResponse.Value.HasData);
            Assert.AreEqual(loadTestResourceName, loadTestCreateResponse.Value.Data.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION, loadTestCreateResponse.Value.Data.Location.Name);
            Assert.AreEqual(ProviderConstants.DefaultProviderNamespace.ToLower() + LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), loadTestCreateResponse.Value.Data.ResourceType.ToString().ToLower());
            Assert.AreEqual(ResourceState.Succeeded, loadTestCreateResponse.Value.Data.ProvisioningState);
            Assert.NotNull(loadTestCreateResponse.Value.Data.DataPlaneUri);
            Assert.IsNull(loadTestCreateResponse.Value.Data.Encryption);

            //// Get
            Response<LoadTestResource> loadTestGetResponse = await loadTestCreateResponse.Value.GetAsync();
            LoadTestResource loadTestGetResponseValue = loadTestGetResponse.Value;

            Assert.IsNotNull(loadTestGetResponseValue);
            Assert.IsTrue(loadTestGetResponseValue.HasData);
            Assert.AreEqual(loadTestResourceName, loadTestGetResponseValue.Data.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION, loadTestGetResponseValue.Data.Location.Name);
            Assert.AreEqual(ProviderConstants.DefaultProviderNamespace.ToLower() + LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), loadTestGetResponseValue.Data.ResourceType.ToString().ToLower());
            Assert.AreEqual(ResourceState.Succeeded, loadTestGetResponseValue.Data.ProvisioningState);
            Assert.NotNull(loadTestGetResponseValue.Data.DataPlaneUri);
            Assert.IsNull(loadTestGetResponseValue.Data.Encryption);

            loadTestGetResponse = await _loadTestResourceCollection.GetAsync(loadTestResourceName);
            loadTestGetResponseValue = loadTestGetResponse.Value;

            Assert.IsNotNull(loadTestGetResponseValue);
            Assert.IsTrue(loadTestGetResponseValue.HasData);
            Assert.AreEqual(loadTestResourceName, loadTestGetResponseValue.Data.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION, loadTestGetResponseValue.Data.Location.Name);
            Assert.AreEqual(ProviderConstants.DefaultProviderNamespace.ToLower() + LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), loadTestGetResponseValue.Data.ResourceType.ToString().ToLower());
            Assert.AreEqual(ResourceState.Succeeded, loadTestGetResponseValue.Data.ProvisioningState);
            Assert.NotNull(loadTestGetResponseValue.Data.DataPlaneUri);
            Assert.IsNull(loadTestGetResponseValue.Data.Encryption);

            List<LoadTestResource> loadTestResources = await _loadTestResourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(loadTestResources);
            foreach (LoadTestResource resource in loadTestResources)
            {
                Assert.IsNotNull(resource);
                Assert.IsTrue(resource.HasData);
                Assert.IsNotNull(resource.Data.Id);
                Assert.IsNotNull(resource.Data.Name);
                Assert.AreEqual(ProviderConstants.DefaultProviderNamespace.ToLower() + LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), resource.Data.ResourceType.ToString().ToLower());
                Assert.AreEqual(ResourceState.Succeeded, resource.Data.ProvisioningState);
                Assert.NotNull(resource.Data.DataPlaneUri);
                Assert.IsNull(resource.Data.Encryption);
            }

            //// List outbound network dependencies
            List<OutboundEnvironmentEndpoint> outboundNetworkDependencyResponse = await loadTestGetResponseValue.GetOutboundNetworkDependenciesEndpointsAsync().ToEnumerableAsync();
            Assert.IsNotNull(outboundNetworkDependencyResponse);

            //// Patch
            LoadTestResourcePatch resourcePatchPayload = new LoadTestResourcePatch
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Description = LoadTestResourceHelper.LOAD_TEST_DESCRIPTION
            };
            ArmOperation<LoadTestResource> loadTestPatchResponse = await loadTestGetResponseValue.UpdateAsync(WaitUntil.Completed, resourcePatchPayload);
            LoadTestResource loadTestPatchResponseValue = loadTestPatchResponse.Value;

            Assert.IsNotNull(loadTestPatchResponseValue);
            Assert.IsTrue(loadTestPatchResponseValue.HasData);
            Assert.AreEqual(loadTestResourceName, loadTestPatchResponseValue.Data.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION, loadTestPatchResponseValue.Data.Location.Name);
            Assert.AreEqual(ProviderConstants.DefaultProviderNamespace.ToLower() + LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), loadTestPatchResponseValue.Data.ResourceType.ToString().ToLower());
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, loadTestPatchResponseValue.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(ResourceState.Succeeded, loadTestPatchResponseValue.Data.ProvisioningState);
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
            AsyncPageable<LoadTestResource> loadtestResources = Subscription.GetLoadTestResourcesAsync();
            List<LoadTestResource> l = await loadtestResources.ToEnumerableAsync();
            Assert.IsNotNull(l);
        }
    }
}
