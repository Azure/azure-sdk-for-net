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
            var loadTestResourceName = Recording.GenerateAssetName("Sdk-LoadTesting-DotNet");

            //// Create
            ArmOperation<LoadTestingResource> loadTestCreateResponse = await _loadTestResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, loadTestResourceName, _loadTestResourceData);

            Assert.IsTrue(loadTestCreateResponse.HasCompleted);
            Assert.IsTrue(loadTestCreateResponse.HasValue);
            Assert.AreEqual(loadTestResourceName, loadTestCreateResponse.Value.Data.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION, loadTestCreateResponse.Value.Data.Location.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), loadTestCreateResponse.Value.Data.ResourceType.ToString().ToLower());

            //// Get
            Response<LoadTestingResource> loadTestGetResponse = await _loadTestResourceCollection.GetAsync(loadTestResourceName);
            LoadTestingResource loadTestGetResponseValue = loadTestGetResponse.Value;

            Assert.IsNotNull(loadTestGetResponseValue);
            Assert.AreEqual(loadTestResourceName, loadTestGetResponseValue.Data.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION, loadTestGetResponseValue.Data.Location.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), loadTestGetResponseValue.Data.ResourceType.ToString().ToLower());

            //// List outbound network dependencies
            AsyncPageable<OutboundEnvironmentEndpoint> outboundNetworkDependencyResponse = loadTestGetResponseValue.GetOutboundNetworkDependenciesEndpointsAsync();
            Assert.IsNotNull(outboundNetworkDependencyResponse);

            //// Patch
            LoadTestingResourcePatch resourcePatchPayload = new LoadTestingResourcePatch
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ArmOperation<LoadTestingResource> loadTestPatchResponse = await loadTestGetResponseValue.UpdateAsync(WaitUntil.Completed, resourcePatchPayload);
            LoadTestingResource loadTestPatchResponseValue = loadTestPatchResponse.Value;

            Assert.IsNotNull(loadTestPatchResponseValue);
            Assert.AreEqual(loadTestResourceName, loadTestPatchResponseValue.Data.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_LOCATION, loadTestPatchResponseValue.Data.Location.Name);
            Assert.AreEqual(LoadTestResourceHelper.LOADTESTS_RESOURCE_TYPE.ToLower(), loadTestPatchResponseValue.Data.ResourceType.ToString().ToLower());
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, loadTestPatchResponseValue.Data.Identity.ManagedServiceIdentityType);

            //// Delete
            ArmOperation loadTestDeleteResponse = await loadTestPatchResponseValue.DeleteAsync(WaitUntil.Completed);
            await loadTestDeleteResponse.WaitForCompletionResponseAsync();
            Assert.IsTrue(loadTestDeleteResponse.HasCompleted);
        }
    }
}
