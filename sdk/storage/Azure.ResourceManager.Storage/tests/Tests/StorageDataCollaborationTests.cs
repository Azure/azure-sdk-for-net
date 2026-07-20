// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Authorization;
using Azure.ResourceManager.Authorization.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class StorageDataCollaborationTests : StorageManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private const string namePrefix = "teststoragemgmt";
        public StorageDataCollaborationTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CreateGetListDeleteStorageDataShare()
        {
            //create storage account with data collaboration enabled
            var canaryLocation = new AzureLocation("eastus2euap");
            string rgName = Recording.GenerateAssetName("teststorageRG-");
            _resourceGroup = (await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed, rgName, new Resources.ResourceGroupData(canaryLocation))).Value;
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var parameters = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardLrs),
                StorageKind.StorageV2,
                canaryLocation)
            {
                DataCollaborationPolicyProperties = new StorageDataCollaborationPolicyProperties()
                {
                    AllowStorageConnectors = true,
                    AllowStorageDataShares = true,
                    AllowCrossTenantDataSharing = false
                },
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            StorageAccountResource account = (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //create a blob container to share as an asset
            BlobContainerResource container = (await account.GetBlobService().GetBlobContainers()
                .CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("share"), new BlobContainerData())).Value;

            //create a data share
            string dataShareName = Recording.GenerateAssetName("ds");
            var dataShareProperties = new StorageDataShareProperties(
                new List<StorageDataShareAccessPolicy>(),
                new List<StorageDataShareAsset>
                {
                    new StorageDataShareAsset($"/{container.Data.Name}/data", "shared-data")
                });
            dataShareProperties.Description = "Test data share";

            var dataShareData = new StorageDataShareData(canaryLocation, dataShareProperties);
            StorageDataShareCollection dataShareCollection = account.GetStorageDataShares();
            StorageDataShareResource dataShare = (await dataShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, dataShareName, dataShareData)).Value;

            //validate created data share
            Assert.IsNotNull(dataShare.Data.Properties);
            Assert.AreEqual("Test data share", dataShare.Data.Properties.Description);
            Assert.IsNotNull(dataShare.Data.Properties.DataShareIdentifier);
            Assert.IsNotNull(dataShare.Data.Properties.DataShareUri);
            Assert.AreEqual(1, dataShare.Data.Properties.Assets.Count);

            //get data share
            StorageDataShareResource retrieved = (await dataShareCollection.GetAsync(dataShareName)).Value;
            Assert.AreEqual(dataShare.Data.Properties.DataShareIdentifier, retrieved.Data.Properties.DataShareIdentifier);

            //list data shares
            List<StorageDataShareResource> allShares = await dataShareCollection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(allShares.Count, 1);
            Assert.IsTrue(allShares.Any(s => s.Data.Name == dataShareName));

            // TODO: Uncomment and re-record when Location serialization issue is resolved.
            ////update data share
            StorageDataSharePatch patchData = new StorageDataSharePatch()
            {
                Properties = new StorageDataSharePropertiesPatch()
                {
                    Description = "Updated data share",
                },
                Tags =
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
                }
            };
            patchData.Properties.AccessPolicies.Add(new StorageDataShareAccessPolicy(
                account.Data.Identity.PrincipalId.Value.ToString(),
                account.Data.Identity.TenantId.Value.ToString(),
                StorageDataShareAccessPolicyPermission.Read));
            StorageDataShareResource updatedDataShare = (await dataShare.UpdateAsync(WaitUntil.Completed, patchData)).Value;
            Assert.AreEqual(patchData.Properties.Description, updatedDataShare.Data.Properties.Description);
            Assert.AreEqual(patchData.Properties.AccessPolicies.Count, updatedDataShare.Data.Properties.AccessPolicies.Count);
            Assert.AreEqual(patchData.Properties.AccessPolicies[0].PrincipalId, updatedDataShare.Data.Properties.AccessPolicies[0].PrincipalId);
            Assert.AreEqual(patchData.Properties.AccessPolicies[0].TenantId, updatedDataShare.Data.Properties.AccessPolicies[0].TenantId);
            Assert.AreEqual(patchData.Properties.AccessPolicies[0].Permission, updatedDataShare.Data.Properties.AccessPolicies[0].Permission);
            Assert.AreEqual(patchData.Tags.Count, updatedDataShare.Data.Tags.Count);
            Assert.AreEqual(patchData.Tags.First().Key, updatedDataShare.Data.Tags.First().Key);
            Assert.AreEqual(patchData.Tags.First().Value, updatedDataShare.Data.Tags.First().Value);

            //delete data share
            await dataShare.DeleteAsync(WaitUntil.Completed);

            if (Mode != RecordedTestMode.Playback)
            {
                //wait for sub-resources to clean up
                await Task.Delay(30000);
            }

            //verify deleted
            Assert.IsFalse((await dataShareCollection.ExistsAsync(dataShareName)).Value);
        }

        [Test]
        [RecordedTest]
        public async Task CreateGetListDeleteStorageConnector()
        {
            //create two storage accounts: one for the connector, one as data share source
            var canaryLocation = new AzureLocation("eastus2euap");
            string rgName = Recording.GenerateAssetName("teststorageRG-");
            _resourceGroup = (await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed, rgName, new Resources.ResourceGroupData(canaryLocation))).Value;
            string srcAccountName = await CreateValidAccountNameAsync(namePrefix);
            string connAccountName = await CreateValidAccountNameAsync(namePrefix);
            var accountParams = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardLrs),
                StorageKind.StorageV2,
                canaryLocation)
            {
                DataCollaborationPolicyProperties = new StorageDataCollaborationPolicyProperties()
                {
                    AllowStorageConnectors = true,
                    AllowStorageDataShares = true,
                    AllowCrossTenantDataSharing = false
                }
            };

            //connector account needs a managed identity for ManagedIdentityAuthProperties
            var connAccountParams = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardLrs),
                StorageKind.StorageV2,
                canaryLocation)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                DataCollaborationPolicyProperties = new StorageDataCollaborationPolicyProperties()
                {
                    AllowStorageConnectors = true,
                    AllowStorageDataShares = true,
                    AllowCrossTenantDataSharing = false
                }
            };

            StorageAccountCollection storageAccounts = _resourceGroup.GetStorageAccounts();
            StorageAccountResource srcAccount = (await storageAccounts.CreateOrUpdateAsync(WaitUntil.Completed, srcAccountName, accountParams)).Value;
            StorageAccountResource connAccount = (await storageAccounts.CreateOrUpdateAsync(WaitUntil.Completed, connAccountName, connAccountParams)).Value;

            //assign Storage Blob Data Reader role to connector's managed identity on the source account
            string storageBlobDataReaderRoleId = "2a2b9908-6ea1-4ae2-8e65-a410df84e7d1";
            Guid connPrincipalId = connAccount.Data.Identity.PrincipalId.Value;
            var roleAssignmentId = Recording.Random.NewGuid().ToString();
            var roleDefinitionId = new ResourceIdentifier($"/subscriptions/{DefaultSubscription.Data.SubscriptionId}/providers/Microsoft.Authorization/roleDefinitions/{storageBlobDataReaderRoleId}");
            var roleAssignmentData = new RoleAssignmentCreateOrUpdateContent(roleDefinitionId, connPrincipalId)
            {
                PrincipalType = RoleManagementPrincipalType.ServicePrincipal
            };
            await srcAccount.GetRoleAssignments().CreateOrUpdateAsync(WaitUntil.Completed, roleAssignmentId, roleAssignmentData);

            //wait for RBAC propagation
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(60000);
            }

            //create a data share on the source account
            BlobContainerResource container = (await srcAccount.GetBlobService().GetBlobContainers()
                .CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("src"), new BlobContainerData())).Value;

            string dataShareName = Recording.GenerateAssetName("ds");
            var dataShareData = new StorageDataShareData(canaryLocation,
                new StorageDataShareProperties(
                    new List<StorageDataShareAccessPolicy>(),
                    new List<StorageDataShareAsset>
                    {
                        new StorageDataShareAsset($"/{container.Data.Name}/data", "shared-data")
                    }));
            StorageDataShareResource dataShare = (await srcAccount.GetStorageDataShares()
                .CreateOrUpdateAsync(WaitUntil.Completed, dataShareName, dataShareData)).Value;

            //create a connector on the consumer account pointing to the data share
            string connectorName = Recording.GenerateAssetName("conn");
            var connectorProperties = new StorageConnectorProperties(
                StorageConnectorDataSourceType.AzureDataShare,
                new DataShareSource(
                    new DataShareConnection(dataShare.Data.Properties.DataShareUri),
                    new StorageConnectorManagedIdentityAuth()));
            connectorProperties.Description = "Test connector";

            var connectorData = new StorageConnectorData(canaryLocation, connectorProperties);
            StorageConnectorCollection connectorCollection = connAccount.GetStorageConnectors();
            StorageConnectorResource connector = (await connectorCollection.CreateOrUpdateAsync(WaitUntil.Completed, connectorName, connectorData)).Value;

            //validate created connector
            Assert.IsNotNull(connector.Data.Properties);
            Assert.AreEqual("Test connector", connector.Data.Properties.Description);
            Assert.IsNotNull(connector.Data.Properties.UniqueId);
            Assert.AreEqual(StorageConnectorDataSourceType.AzureDataShare, connector.Data.Properties.DataSourceType);

            //get connector
            StorageConnectorResource retrieved = (await connectorCollection.GetAsync(connectorName)).Value;
            Assert.AreEqual(connector.Data.Properties.UniqueId, retrieved.Data.Properties.UniqueId);

            //list connectors
            List<StorageConnectorResource> allConnectors = await connectorCollection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(allConnectors.Count, 1);
            Assert.IsTrue(allConnectors.Any(c => c.Data.Name == connectorName));

            //test existing connection
            var testContent = new StorageConnectorTestExistingConnectionContent(connector.Data.Properties.UniqueId);
            StorageConnectorTestConnectionResult testResult = (await connector.TestExistingConnectionAsync(WaitUntil.Completed, testContent)).Value;
            Assert.IsNotNull(testResult.StorageConnectorMethodName);
            Assert.IsNotNull(testResult.StorageConnectorRequestId);

            //update connector
            //string managedIdentityId = string.Format("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testgroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testid");
            StorageConnectorPatch patchData = new StorageConnectorPatch()
            {
                Properties = new StorageConnectorPropertiesPatch()
                {
                    Description = "Updated connector",
                },
                Tags =
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
                }
            };
            //ManagedIdentityAuthPropertiesPatch authPropertiesUpdate = new ManagedIdentityAuthPropertiesPatch(StorageConnectorAuthType.ManagedIdentity, null, managedIdentityId);
            //patchData.Properties.Source = new DataShareSourcePatch(StorageConnectorSourceType.DataShare, null, authPropertiesUpdate);

            StorageConnectorResource updatedConnector = (await connector.UpdateAsync(WaitUntil.Completed, patchData)).Value;

            //Assert.AreEqual(((ManagedIdentityAuthPropertiesPatch)((DataShareSourcePatch)patchData.Properties.Source).AuthProperties).IdentityResourceId,
            //    ((ManagedIdentityAuthProperties)((DataShareSource)updatedConnector.Data.Properties.Source).AuthProperties).IdentityResourceId);
            Assert.AreEqual(patchData.Properties.Description, updatedConnector.Data.Properties.Description);
            Assert.AreEqual(patchData.Tags.Count, updatedConnector.Data.Tags.Count);
            Assert.AreEqual(patchData.Tags.First().Key, updatedConnector.Data.Tags.First().Key);
            Assert.AreEqual(patchData.Tags.First().Value, updatedConnector.Data.Tags.First().Value);

            //delete connector, then data share
            await connector.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse((await connectorCollection.ExistsAsync(connectorName)).Value);

            await dataShare.DeleteAsync(WaitUntil.Completed);

            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(30000);
            }
        }
    }
}
