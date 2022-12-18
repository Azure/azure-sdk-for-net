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
            ResourceIdentifier identityId = new ResourceIdentifier("/subscriptions/7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a/resourcegroups/rpatibandla-testruns/providers/microsoft.managedidentity/userassignedidentities/rpatibandla-mi");
            _loadTestResourceData.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            _loadTestResourceData.Identity.UserAssignedIdentities.Add(identityId, new UserAssignedIdentity());
            _loadTestResourceData.Encryption = new CustomerManagedKeyEncryptionProperties();
            _loadTestResourceData.Encryption.KeyUri = new Uri("https://rpatibandla-dev-2.vault.azure.net/keys/cmk/2d1ccd5c50234ea2a0858fe148b69cde");
            _loadTestResourceData.Encryption.Identity = new CustomerManagedKeyIdentity();
            _loadTestResourceData.Encryption.Identity.IdentityType = CustomerManagedKeyIdentityType.UserAssigned;
            _loadTestResourceData.Encryption.Identity.ResourceId = new ResourceIdentifier("/subscriptions/7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a/resourceGroups/rpatibandla-testruns/providers/Microsoft.ManagedIdentity/userAssignedIdentities/rpatibandla-mi");
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

            //// Get
            Response<LoadTestingResource> loadTestGetResponse = await loadTestCreateResponse.Value.GetAsync();
            LoadTestingResource loadTestGetResponseValue = loadTestGetResponse.Value;

            //// Patch
            LoadTestingResourcePatch resourcePatchPayload = new LoadTestingResourcePatch
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Description = LoadTestResourceHelper.LOAD_TEST_DESCRIPTION,
                Encryption = new CustomerManagedKeyEncryptionProperties
                {
                    Identity = new CustomerManagedKeyIdentity
                    {
                        IdentityType = CustomerManagedKeyIdentityType.SystemAssigned,
                        ResourceId = null
                    },
                    KeyUri = new Uri("https://rpatibandla-dev-2.vault.azure.net/keys/cmk/2d1ccd5c50234ea2a0858fe148b69cde")
        }
            };
            try
            {
                ArmOperation<LoadTestingResource> loadTestPatchResponse = await loadTestGetResponseValue.UpdateAsync(WaitUntil.Completed, resourcePatchPayload);
                LoadTestingResource loadTestPatchResponseValue = loadTestPatchResponse.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
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
