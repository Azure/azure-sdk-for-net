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

            Assert.That(loadTestCreateResponse.HasCompleted, Is.True);
            Assert.That(loadTestCreateResponse.HasValue, Is.True);
            Assert.That(loadTestCreateResponse.Value.HasData, Is.True);
            Assert.That(loadTestCreateResponse.Value.Data.Name, Is.EqualTo(loadTestResourceName));
            Assert.That(loadTestCreateResponse.Value.Data.Location.Name, Is.EqualTo(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION));
            Assert.That(loadTestCreateResponse.Value.Data.ResourceType.ToString().ToLower(), Is.EqualTo(ProviderConstants.DefaultProviderNamespace.ToLower() + LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower()));
            Assert.That(loadTestCreateResponse.Value.Data.ProvisioningState, Is.EqualTo(LoadTestingProvisioningState.Succeeded));
            Assert.That(loadTestCreateResponse.Value.Data.DataPlaneUri, Is.Not.Null);
            Assert.That(loadTestCreateResponse.Value.Data.Encryption, Is.Null);

            //// Get
            Response<LoadTestingResource> loadTestGetResponse = await loadTestCreateResponse.Value.GetAsync();
            LoadTestingResource loadTestGetResponseValue = loadTestGetResponse.Value;

            Assert.That(loadTestGetResponseValue, Is.Not.Null);
            Assert.That(loadTestGetResponseValue.HasData, Is.True);
            Assert.That(loadTestGetResponseValue.Data.Name, Is.EqualTo(loadTestResourceName));
            Assert.That(loadTestGetResponseValue.Data.Location.Name, Is.EqualTo(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION));
            Assert.That(loadTestGetResponseValue.Data.ResourceType.ToString().ToLower(), Is.EqualTo(ProviderConstants.DefaultProviderNamespace.ToLower() + LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower()));
            Assert.That(loadTestGetResponseValue.Data.ProvisioningState, Is.EqualTo(LoadTestingProvisioningState.Succeeded));
            Assert.That(loadTestGetResponseValue.Data.DataPlaneUri, Is.Not.Null);
            Assert.That(loadTestGetResponseValue.Data.Encryption, Is.Null);

            loadTestGetResponse = await _loadTestResourceCollection.GetAsync(loadTestResourceName);
            loadTestGetResponseValue = loadTestGetResponse.Value;

            Assert.That(loadTestGetResponseValue, Is.Not.Null);
            Assert.That(loadTestGetResponseValue.HasData, Is.True);
            Assert.That(loadTestGetResponseValue.Data.Name, Is.EqualTo(loadTestResourceName));
            Assert.That(loadTestGetResponseValue.Data.Location.Name, Is.EqualTo(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION));
            Assert.That(loadTestGetResponseValue.Data.ResourceType.ToString().ToLower(), Is.EqualTo(ProviderConstants.DefaultProviderNamespace.ToLower() + LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower()));
            Assert.That(loadTestGetResponseValue.Data.ProvisioningState, Is.EqualTo(LoadTestingProvisioningState.Succeeded));
            Assert.That(loadTestGetResponseValue.Data.DataPlaneUri, Is.Not.Null);
            Assert.That(loadTestGetResponseValue.Data.Encryption, Is.Null);

            List<LoadTestingResource> loadTestResources = await _loadTestResourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(loadTestResources, Is.Not.Empty);
            foreach (LoadTestingResource resource in loadTestResources)
            {
                Assert.That(resource, Is.Not.Null);
                Assert.That(resource.HasData, Is.True);
                Assert.That(resource.Data.Id, Is.Not.Null);
                Assert.That(resource.Data.Name, Is.Not.Null);
                Assert.That(resource.Data.ResourceType.ToString().ToLower(), Is.EqualTo(ProviderConstants.DefaultProviderNamespace.ToLower() + LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower()));
                Assert.That(resource.Data.ProvisioningState, Is.EqualTo(LoadTestingProvisioningState.Succeeded));
                Assert.That(resource.Data.DataPlaneUri, Is.Not.Null);
                Assert.That(resource.Data.Encryption, Is.Null);
            }

            //// List outbound network dependencies
            List<LoadTestingOutboundEnvironmentEndpoint> outboundNetworkDependencyResponse = await loadTestGetResponseValue.GetOutboundNetworkDependenciesEndpointsAsync().ToEnumerableAsync();
            Assert.That(outboundNetworkDependencyResponse, Is.Not.Null);

            //// Patch
            LoadTestingResourcePatch resourcePatchPayload = new LoadTestingResourcePatch
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Description = LoadTestResourceHelper.LOAD_TEST_DESCRIPTION
            };
            ArmOperation<LoadTestingResource> loadTestPatchResponse = await loadTestGetResponseValue.UpdateAsync(WaitUntil.Completed, resourcePatchPayload);
            LoadTestingResource loadTestPatchResponseValue = loadTestPatchResponse.Value;

            Assert.That(loadTestPatchResponseValue, Is.Not.Null);
            Assert.That(loadTestPatchResponseValue.HasData, Is.True);
            Assert.That(loadTestPatchResponseValue.Data.Name, Is.EqualTo(loadTestResourceName));
            Assert.That(loadTestPatchResponseValue.Data.Location.Name, Is.EqualTo(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION));
            Assert.That(loadTestPatchResponseValue.Data.ResourceType.ToString().ToLower(), Is.EqualTo(ProviderConstants.DefaultProviderNamespace.ToLower() + LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower()));
            Assert.That(loadTestPatchResponseValue.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            Assert.That(loadTestPatchResponseValue.Data.ProvisioningState, Is.EqualTo(LoadTestingProvisioningState.Succeeded));
            Assert.That(loadTestPatchResponseValue.Data.Description, Is.EqualTo(LoadTestResourceHelper.LOAD_TEST_DESCRIPTION));
            Assert.That(loadTestPatchResponseValue.Data.DataPlaneUri, Is.Not.Null);
            Assert.That(loadTestPatchResponseValue.Data.Encryption, Is.Null);

            //// Delete
            ArmOperation loadTestDeleteResponse = await loadTestPatchResponseValue.DeleteAsync(WaitUntil.Completed);
            await loadTestDeleteResponse.WaitForCompletionResponseAsync();
            Assert.That(loadTestDeleteResponse.HasCompleted, Is.True);
        }

        [RecordedTest]
        [PlaybackOnly("Ignoring on live tests, due to possibility of huge service calls.")]
        public async Task LoadTestResourceOperationExtensionTests()
        {
            AsyncPageable<LoadTestingResource> loadtestResources = Subscription.GetLoadTestingResourcesAsync();
            List<LoadTestingResource> resourceList = await loadtestResources.ToEnumerableAsync();
            Assert.That(resourceList, Is.Not.Null);
        }
    }
}
