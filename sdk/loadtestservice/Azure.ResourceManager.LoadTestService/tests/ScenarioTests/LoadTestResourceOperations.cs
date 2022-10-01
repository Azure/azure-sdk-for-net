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
using Azure.ResourceManager.LoadTestService.Models;
using Azure.ResourceManager.LoadTestService.Tests.Helpers;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.LoadTestService.Tests
{
    public class LoadTestResourceOperations : LoadTestServiceManagementTestBase
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
            await LoadTestResourceHelper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, LoadTestResourceHelper.RESOURCE_LOCATION, resourceGroupName);

            _loadTestResourceCollection = (await GetResourceGroupAsync(resourceGroupName)).GetLoadTestResources();
            _loadTestResourceData = new LoadTestResourceData(LoadTestResourceHelper.RESOURCE_LOCATION);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task LoadTestResourceOperationTests()
        {
            var loadTestResourceName = Recording.GenerateAssetName("Sdk-LoadTestService-DotNet");

            //// Create
            ArmOperation<LoadTestResource> loadTestCreateResponse = await _loadTestResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, loadTestResourceName, _loadTestResourceData);
            await loadTestCreateResponse.WaitForCompletionAsync();

            Assert.IsTrue(loadTestCreateResponse.HasCompleted);
            Assert.IsTrue(loadTestCreateResponse.HasValue);
            Assert.AreEqual(loadTestResourceName, loadTestCreateResponse.Value.Data.Name);
            Assert.AreEqual(LoadTestResourceHelper.RESOURCE_LOCATION, loadTestCreateResponse.Value.Data.Location.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), loadTestCreateResponse.Value.Data.ResourceType.ToString().ToLower());

            //// Get
            Response<LoadTestResource> loadTestGetResponse = await _loadTestResourceCollection.GetAsync(loadTestResourceName);
            LoadTestResource loadTestGetResponseValue = loadTestGetResponse.Value;

            Assert.IsNotNull(loadTestGetResponseValue);
            Assert.AreEqual(loadTestResourceName, loadTestGetResponseValue.Data.Name);
            Assert.AreEqual(LoadTestResourceHelper.RESOURCE_LOCATION, loadTestGetResponseValue.Data.Location.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), loadTestGetResponseValue.Data.ResourceType.ToString().ToLower());

            //// List outbound network dependencies
            AsyncPageable<OutboundEnvironmentEndpoint> outboundNetworkDependencyResponse = loadTestGetResponseValue.GetOutboundNetworkDependenciesEndpointsAsync();
            Assert.IsNotNull(outboundNetworkDependencyResponse);

            //// Patch
            LoadTestResourcePatch resourcePatchPayload = new LoadTestResourcePatch
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ArmOperation<LoadTestResource> loadTestPatchResponse = await loadTestGetResponseValue.UpdateAsync(WaitUntil.Completed, resourcePatchPayload);
            LoadTestResource loadTestPatchResponseValue = loadTestPatchResponse.Value;

            Assert.IsNotNull(loadTestPatchResponseValue);
            Assert.AreEqual(loadTestResourceName, loadTestPatchResponseValue.Data.Name);
            Assert.AreEqual(LoadTestResourceHelper.RESOURCE_LOCATION, loadTestPatchResponseValue.Data.Location.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), loadTestPatchResponseValue.Data.ResourceType.ToString().ToLower());
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, loadTestPatchResponseValue.Data.Identity.ManagedServiceIdentityType);

            //// Delete
            ArmOperation loadTestDeleteResponse = await loadTestPatchResponseValue.DeleteAsync(WaitUntil.Completed);
            await loadTestDeleteResponse.WaitForCompletionResponseAsync();
            Assert.IsTrue(loadTestDeleteResponse.HasCompleted);
        }
    }
}
