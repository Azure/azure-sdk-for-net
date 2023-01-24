// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.LoadTesting.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.LoadTesting.Tests.Samples
{
    public class Sample1_LoadTestingResourceOperations
    {
        private ResourceGroupResource _resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task createLoadTestResource_Basic()
        {
            #region Snippet:LoadTesting_CreateLoadTestResource_Basic
            LoadTestingResourceCollection loadTestingCollection = _resourceGroup.GetLoadTestingResources();
            string loadTestResourceName = "sample-loadtest";
            LoadTestingResourceData inputPayload = new LoadTestingResourceData(AzureLocation.WestUS2);
            ArmOperation<LoadTestingResource> loadTestingLro = await loadTestingCollection.CreateOrUpdateAsync(WaitUntil.Completed, loadTestResourceName, inputPayload);

            LoadTestingResource resource = loadTestingLro.Value;
            #endregion Snippet:LoadTesting_CreateLoadTestResource_Basic
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task createLoadTestResource_WithEncryption()
        {
            #region Snippet:LoadTesting_CreateLoadTestResource_WithEncryption
            LoadTestingResourceCollection loadTestingCollection = _resourceGroup.GetLoadTestingResources();
            string loadTestResourceName = "sample-loadtest";
            LoadTestingResourceData inputPayload = new LoadTestingResourceData(AzureLocation.WestUS2);

            // Managed identity properties
            ResourceIdentifier identityId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/sample-rg/providers/microsoft.managedidentity/userassignedidentities/identity1");
            inputPayload.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            inputPayload.Identity.UserAssignedIdentities.Add(identityId, new UserAssignedIdentity());

            // CMK encryption properties
            inputPayload.Encryption = new LoadTestingCmkEncryptionProperties();
            inputPayload.Encryption.KeyUri = new Uri("https://sample-kv.vault.azure.net/keys/cmkkey/2d1ccd5c50234ea2a0858fe148b69cde");
            inputPayload.Encryption.Identity = new LoadTestingCmkIdentity();
            inputPayload.Encryption.Identity.IdentityType = LoadTestingCmkIdentityType.UserAssigned;
            inputPayload.Encryption.Identity.ResourceId = identityId;

            ArmOperation<LoadTestingResource> loadTestingLro = await loadTestingCollection.CreateOrUpdateAsync(WaitUntil.Completed, loadTestResourceName, inputPayload);

            LoadTestingResource resource = loadTestingLro.Value;
            #endregion Snippet:LoadTesting_CreateLoadTestResource_WithEncryption
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task getLoadTestResource()
        {
            #region Snippet:LoadTesting_GetLoadTestResource
            LoadTestingResourceCollection loadTestingCollection = _resourceGroup.GetLoadTestingResources();

            string loadTestResourceName = "sample-loadtest";
            Response<LoadTestingResource> loadTestingResponse = await loadTestingCollection.GetAsync(loadTestResourceName);

            LoadTestingResource resource = loadTestingResponse.Value;
            #endregion Snippet:LoadTesting_GetLoadTestResource
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task updateLoadTestResource_WithEncryption()
        {
            #region Snippet:LoadTesting_UpdateLoadTestResource_WithEncryption
            LoadTestingResourceCollection loadTestingCollection = _resourceGroup.GetLoadTestingResources();
            string loadTestResourceName = "sample-loadtest";
            Response<LoadTestingResource> loadTestingResponse = await loadTestingCollection.GetAsync(loadTestResourceName);
            LoadTestingResource resource = loadTestingResponse.Value;

            ResourceIdentifier identityId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/sample-rg/providers/microsoft.managedidentity/userassignedidentities/identity1");
            LoadTestingResourcePatch resourcePatchPayload = new LoadTestingResourcePatch {
                Encryption = new LoadTestingCmkEncryptionProperties
                {
                    Identity = new LoadTestingCmkIdentity
                    {
                        // make sure that system-assigned managed identity is enabled on this resource and the identity has been granted required permissions to access the key.
                        IdentityType = LoadTestingCmkIdentityType.SystemAssigned,
                        ResourceId = null
                    },
                    KeyUri = new Uri("https://sample-kv.vault.azure.net/keys/cmkkey/2d1ccd5c50234ea2a0858fe148b69cde")
                }
            };

            ArmOperation<LoadTestingResource> loadTestingLro = await resource.UpdateAsync(WaitUntil.Completed, resourcePatchPayload);

            LoadTestingResource updatedResource = loadTestingLro.Value;
            #endregion Snippet:LoadTesting_UpdateLoadTestResource_WithEncryption
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task updateLoadTestResource_WithManagedIdentity()
        {
            #region Snippet:LoadTesting_UpdateLoadTestResource_WithManagedIdentity
            LoadTestingResourceCollection loadTestingCollection = _resourceGroup.GetLoadTestingResources();
            string loadTestResourceName = "sample-loadtest";
            Response<LoadTestingResource> loadTestingResponse = await loadTestingCollection.GetAsync(loadTestResourceName);
            LoadTestingResource resource = loadTestingResponse.Value;

            ResourceIdentifier identityId1 = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/sample-rg/providers/microsoft.managedidentity/userassignedidentities/identity1");
            ResourceIdentifier identityId2 = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/sample-rg/providers/microsoft.managedidentity/userassignedidentities/identity2");

            LoadTestingResourcePatch resourcePatchPayload = new LoadTestingResourcePatch();
            resourcePatchPayload.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            // removes user-assigned identity with resourceId <identityId1> (if already assigned to the load testing resource)
            resourcePatchPayload.Identity.UserAssignedIdentities.Add(identityId1, null);
            resourcePatchPayload.Identity.UserAssignedIdentities.Add(identityId2, new UserAssignedIdentity());

            ArmOperation<LoadTestingResource> loadTestingLro = await resource.UpdateAsync(WaitUntil.Completed, resourcePatchPayload);
            LoadTestingResource updatedResource = loadTestingLro.Value;
            #endregion Snippet:LoadTesting_UpdateLoadTestResource_WithManagedIdentity
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task deleteLoadTestResource()
        {
            #region Snippet:LoadTesting_DeleteLoadTestResource
            LoadTestingResourceCollection loadTestingCollection = _resourceGroup.GetLoadTestingResources();
            string loadTestResourceName = "sample-loadtest";
            Response<LoadTestingResource> loadTestingResponse = await loadTestingCollection.GetAsync(loadTestResourceName);
            LoadTestingResource resource = loadTestingResponse.Value;

            ArmOperation loadTestDeleteResponse = await resource.DeleteAsync(WaitUntil.Completed);
            #endregion Snippet:LoadTesting_DeleteLoadTestResource
        }

        [SetUp]
        [Ignore("Only verifying that the sample builds")]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();

            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with a specific name
            string rgName = "sample-rg";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroupResource> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = lro.Value;
            this._resourceGroup = resourceGroup;
        }
    }
}
