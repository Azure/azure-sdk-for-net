// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DeviceRegistry.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceRegistry.Tests.Scenario
{
    public class DeviceRegistrySchemaRegistriesOperationsTest : DeviceRegistryManagementTestBase
    {
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _rgNamePrefix = "adr-test-sdk-rg-schemaregistries";
        private readonly string _schemaRegistryNamespacePrefix = "namespace-sdk-test";
        private readonly string _schemaRegistryNamePrefix = "deviceregistry-test-schemaregistry-sdk";
        private readonly string _schemaRegistrySchemaNamePrefix = "deviceregistry-test-schemaregistryschema-sdk";
        private readonly string _schemaRegistrySchemaVersionNamePrefix = "1";

        public DeviceRegistrySchemaRegistriesOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task SchemaRegistriesCrudOperationsTest()
        {
            var schemaRegistryName = Recording.GenerateAssetName(_schemaRegistryNamePrefix);
            var schemaRegistrySchemaName = Recording.GenerateAssetName(_schemaRegistrySchemaNamePrefix);
            var schemaRegistrySchemaVersionName = Recording.GenerateAssetName(_schemaRegistrySchemaVersionNamePrefix);
            var schemaRegistryNamespace = Recording.GenerateAssetName(_schemaRegistryNamespacePrefix);

            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));
            var rg = await CreateResourceGroup(subscription, _rgNamePrefix, AzureLocation.WestUS);

            #region SchemaRegistries
            /*******************
            * SchemaRegistries *
            *******************/

            var schemaRegistriesCollection = rg.GetDeviceRegistrySchemaRegistries();

            // Create DeviceRegistry SchemaRegistry
            var schemaRegistryData = new DeviceRegistrySchemaRegistryData(AzureLocation.WestUS)
            {
                Properties = new()
                {
                    Namespace = schemaRegistryNamespace,
                    Description = "This is a Schema Registry instance.",
                    DisplayName = "Schema Registry SDK test",
                    StorageAccountContainerUri = new Uri("https://schemaregistrysdktest.blob.core.windows.net/schemaregistrysdkcontainertest")
                },
                Identity = new(ManagedServiceIdentityType.SystemAssigned)
            };
            var schemaRegistryCreateOrUpdateResponse = await schemaRegistriesCollection.CreateOrUpdateAsync(WaitUntil.Completed, schemaRegistryName, schemaRegistryData, CancellationToken.None);
            Assert.IsNotNull(schemaRegistryCreateOrUpdateResponse.Value);
            Assert.IsNotNull(schemaRegistryCreateOrUpdateResponse.Value.Data.Identity.TenantId);
            Assert.IsNotNull(schemaRegistryCreateOrUpdateResponse.Value.Data.Identity.PrincipalId);
            Assert.AreEqual(schemaRegistryCreateOrUpdateResponse.Value.Data.Identity.ManagedServiceIdentityType, ManagedServiceIdentityType.SystemAssigned);
            Assert.IsTrue(Guid.TryParse(schemaRegistryCreateOrUpdateResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(schemaRegistryCreateOrUpdateResponse.Value.Data.Properties.Namespace, schemaRegistryData.Properties.Namespace);
            Assert.AreEqual(schemaRegistryCreateOrUpdateResponse.Value.Data.Properties.Description, schemaRegistryData.Properties.Description);
            Assert.AreEqual(schemaRegistryCreateOrUpdateResponse.Value.Data.Properties.DisplayName, schemaRegistryData.Properties.DisplayName);
            Assert.AreEqual(schemaRegistryCreateOrUpdateResponse.Value.Data.Properties.StorageAccountContainerUri, schemaRegistryData.Properties.StorageAccountContainerUri);

            // Read DeviceRegistry SchemaRegistry
            var schemaRegistryReadResponse = await schemaRegistriesCollection.GetAsync(schemaRegistryName, CancellationToken.None);
            Assert.IsNotNull(schemaRegistryReadResponse.Value);
            Assert.IsNotNull(schemaRegistryReadResponse.Value.Data.Identity.TenantId);
            Assert.IsNotNull(schemaRegistryReadResponse.Value.Data.Identity.PrincipalId);
            Assert.AreEqual(schemaRegistryReadResponse.Value.Data.Identity.ManagedServiceIdentityType, ManagedServiceIdentityType.SystemAssigned);
            Assert.IsTrue(Guid.TryParse(schemaRegistryReadResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(schemaRegistryReadResponse.Value.Data.Properties.Namespace, schemaRegistryData.Properties.Namespace);
            Assert.AreEqual(schemaRegistryReadResponse.Value.Data.Properties.Description, schemaRegistryData.Properties.Description);
            Assert.AreEqual(schemaRegistryReadResponse.Value.Data.Properties.DisplayName, schemaRegistryData.Properties.DisplayName);
            Assert.AreEqual(schemaRegistryReadResponse.Value.Data.Properties.StorageAccountContainerUri, schemaRegistryData.Properties.StorageAccountContainerUri);

            // List DeviceRegistry SchemaRegistry by Resource Group
            var schemaRegistryResourcesListByResourceGroup = new List<DeviceRegistrySchemaRegistryResource>();
            var schemaRegistryResourceListByResourceGroupAsyncIteratorPage = schemaRegistriesCollection.GetAllAsync(CancellationToken.None).AsPages(null, 5);
            await foreach (var schemaRegistryEntryPage in schemaRegistryResourceListByResourceGroupAsyncIteratorPage)
            {
                schemaRegistryResourcesListByResourceGroup.AddRange(schemaRegistryEntryPage.Values);
            }
            Assert.IsNotEmpty(schemaRegistryResourcesListByResourceGroup);
            Assert.GreaterOrEqual(schemaRegistryResourcesListByResourceGroup.Count, 1);

            // List DeviceRegistry SchemaRegistry by Subscription
            var schemaRegistryResourcesListBySubscription = new List<DeviceRegistrySchemaRegistryResource>();
            var schemaRegistryResourceListBySubscriptionAsyncIteratorPage = subscription.GetDeviceRegistrySchemaRegistriesAsync(CancellationToken.None).AsPages(null, 5);
            await foreach (var schemaRegistryEntryPage in schemaRegistryResourceListBySubscriptionAsyncIteratorPage)
            {
                schemaRegistryResourcesListBySubscription.AddRange(schemaRegistryEntryPage.Values);
            }
            Assert.IsNotEmpty(schemaRegistryResourcesListBySubscription);
            Assert.GreaterOrEqual(schemaRegistryResourcesListBySubscription.Count, 1);

            // Update DeviceRegistry SchemaRegistry
            var schemaRegistry = schemaRegistryReadResponse.Value;
            var schemaRegistryPatchData = new DeviceRegistrySchemaRegistryPatch
            {
                Properties = new()
                {
                    Description = "This is a patched Schema Registry instance."
                }
            };
            var schemaRegistryUpdateResponse = await schemaRegistry.UpdateAsync(WaitUntil.Completed, schemaRegistryPatchData, CancellationToken.None);
            Assert.IsNotNull(schemaRegistryUpdateResponse.Value);
            Assert.IsNotNull(schemaRegistryUpdateResponse.Value.Data.Identity.TenantId);
            Assert.IsNotNull(schemaRegistryUpdateResponse.Value.Data.Identity.PrincipalId);
            Assert.AreEqual(schemaRegistryUpdateResponse.Value.Data.Identity.ManagedServiceIdentityType, ManagedServiceIdentityType.SystemAssigned);
            Assert.IsTrue(Guid.TryParse(schemaRegistryUpdateResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(schemaRegistryUpdateResponse.Value.Data.Properties.Namespace, schemaRegistryData.Properties.Namespace);
            Assert.AreEqual(schemaRegistryUpdateResponse.Value.Data.Properties.Description, schemaRegistryPatchData.Properties.Description);
            Assert.AreEqual(schemaRegistryUpdateResponse.Value.Data.Properties.DisplayName, schemaRegistryData.Properties.DisplayName);
            Assert.AreEqual(schemaRegistryUpdateResponse.Value.Data.Properties.StorageAccountContainerUri, schemaRegistryData.Properties.StorageAccountContainerUri);

            #endregion

            #region SchemaRegistries/Schemas
            /***************************
            * SchemaRegistries/Schemas *
            ***************************/

            var schemaRegistriesSchemasCollection = schemaRegistry.GetDeviceRegistrySchemas();

            // Create DeviceRegistry SchemaRegistry Schema
            var schemaRegistrySchemaData = new DeviceRegistrySchemaData()
            {
                Properties = new(DeviceRegistrySchemaFormat.JsonSchemaDraft7, DeviceRegistrySchemaType.MessageSchema)
                {
                    Description = "This is a Schema instance.",
                    DisplayName = "Schema SDK test"
                }
            };
            var schemaRegistrySchemaCreateOrUpdateResponse = await schemaRegistriesSchemasCollection.CreateOrUpdateAsync(WaitUntil.Completed, schemaRegistrySchemaName, schemaRegistrySchemaData, CancellationToken.None);
            Assert.IsNotNull(schemaRegistrySchemaCreateOrUpdateResponse.Value);
            Assert.IsTrue(Guid.TryParse(schemaRegistrySchemaCreateOrUpdateResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(schemaRegistrySchemaCreateOrUpdateResponse.Value.Data.Properties.SchemaType, schemaRegistrySchemaData.Properties.SchemaType);
            Assert.AreEqual(schemaRegistrySchemaCreateOrUpdateResponse.Value.Data.Properties.Format, schemaRegistrySchemaData.Properties.Format);
            Assert.AreEqual(schemaRegistrySchemaCreateOrUpdateResponse.Value.Data.Properties.Description, schemaRegistrySchemaData.Properties.Description);
            Assert.AreEqual(schemaRegistrySchemaCreateOrUpdateResponse.Value.Data.Properties.DisplayName, schemaRegistrySchemaData.Properties.DisplayName);

            // Read DeviceRegistry SchemaRegistry Schema
            var schemaRegistrySchemaReadResponse = await schemaRegistriesSchemasCollection.GetAsync(schemaRegistrySchemaName, CancellationToken.None);
            Assert.IsNotNull(schemaRegistrySchemaReadResponse.Value);
            Assert.IsTrue(Guid.TryParse(schemaRegistrySchemaReadResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(schemaRegistrySchemaReadResponse.Value.Data.Properties.SchemaType, schemaRegistrySchemaData.Properties.SchemaType);
            Assert.AreEqual(schemaRegistrySchemaReadResponse.Value.Data.Properties.Format, schemaRegistrySchemaData.Properties.Format);
            Assert.AreEqual(schemaRegistrySchemaReadResponse.Value.Data.Properties.Description, schemaRegistrySchemaData.Properties.Description);
            Assert.AreEqual(schemaRegistrySchemaReadResponse.Value.Data.Properties.DisplayName, schemaRegistrySchemaData.Properties.DisplayName);

            // List DeviceRegistry SchemaRegistry Schema by SchemaRegistry
            var schemaResourcesListBySchemaRegistry = new List<DeviceRegistrySchemaResource>();
            var schemaRegistrySchemaListBySchemaRegistryAsyncIterator = schemaRegistriesSchemasCollection.GetAllAsync(CancellationToken.None);
            await foreach (var schemaEntry in schemaRegistrySchemaListBySchemaRegistryAsyncIterator)
            {
                schemaResourcesListBySchemaRegistry.Add(schemaEntry);
            }
            Assert.IsNotEmpty(schemaResourcesListBySchemaRegistry);
            Assert.AreEqual(schemaResourcesListBySchemaRegistry.Count, 1);
            Assert.IsTrue(Guid.TryParse(schemaResourcesListBySchemaRegistry[0].Data.Properties.Uuid, out _));
            Assert.AreEqual(schemaResourcesListBySchemaRegistry[0].Data.Properties.SchemaType, schemaRegistrySchemaData.Properties.SchemaType);
            Assert.AreEqual(schemaResourcesListBySchemaRegistry[0].Data.Properties.Format, schemaRegistrySchemaData.Properties.Format);
            Assert.AreEqual(schemaResourcesListBySchemaRegistry[0].Data.Properties.Description, schemaRegistrySchemaData.Properties.Description);
            Assert.AreEqual(schemaResourcesListBySchemaRegistry[0].Data.Properties.DisplayName, schemaRegistrySchemaData.Properties.DisplayName);

            var schemaRegistrySchema = schemaRegistrySchemaReadResponse.Value;

            #endregion

            #region SchemaRegistries/Schemas/SchemaVersions
            /******************************************
            * SchemaRegistries/Schemas/SchemaVersions *
            ******************************************/

            var schemaRegistriesSchemaVersionsCollection = schemaRegistrySchema.GetDeviceRegistrySchemaVersions();

            // ** Uncomment during recording **
            // Manually add the Role Assignment to the target storage container
            //int delayMs = 120000;
            //Console.Error.WriteLine($"Waiting {delayMs / 1000}s. Please add MI for SR \"{schemaRegistryName}\", principal ID: \"{schemaRegistryCreateOrUpdateResponse.Value.Data.Identity.PrincipalId}\" as \"Storage Blob Data Contributor\" Role to storage account container \"{schemaRegistryData.Properties.StorageAccountContainerUri}\".");
            //await Task.Delay(delayMs);

            // Create DeviceRegistry SchemaRegistry Schema Version
            var schemaRegistrySchemaVersionData = new DeviceRegistrySchemaVersionData()
            {
                Properties = new()
                {
                    SchemaContent = "{\"foo\":\"bar\"}",
                    Description = "This is a Schema Version instance."
                }
            };
            var schemaRegistrySchemaVersionCreateOrUpdateResponse = await schemaRegistriesSchemaVersionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, schemaRegistrySchemaVersionName, schemaRegistrySchemaVersionData, CancellationToken.None);
            Assert.IsNotNull(schemaRegistrySchemaVersionCreateOrUpdateResponse.Value);
            Assert.IsTrue(Guid.TryParse(schemaRegistrySchemaVersionCreateOrUpdateResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(schemaRegistrySchemaVersionCreateOrUpdateResponse.Value.Data.Properties.SchemaContent, schemaRegistrySchemaVersionData.Properties.SchemaContent);
            Assert.AreEqual(schemaRegistrySchemaVersionCreateOrUpdateResponse.Value.Data.Properties.Description, schemaRegistrySchemaVersionData.Properties.Description);

            // Read DeviceRegistry SchemaRegistry Schema Version
            var schemaRegistrySchemaVersionReadResponse = await schemaRegistriesSchemaVersionsCollection.GetAsync(schemaRegistrySchemaVersionName, CancellationToken.None);
            Assert.IsNotNull(schemaRegistrySchemaVersionReadResponse.Value);
            Assert.IsTrue(Guid.TryParse(schemaRegistrySchemaVersionReadResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(schemaRegistrySchemaVersionReadResponse.Value.Data.Properties.SchemaContent, schemaRegistrySchemaVersionData.Properties.SchemaContent);
            Assert.AreEqual(schemaRegistrySchemaVersionReadResponse.Value.Data.Properties.Description, schemaRegistrySchemaVersionData.Properties.Description);

            var schemaRegistrySchemaVersion = schemaRegistrySchemaVersionReadResponse.Value;

            #endregion

            // Delete DeviceRegistry SchemaRegistry Schema Version
            await schemaRegistrySchemaVersion.DeleteAsync(WaitUntil.Completed, CancellationToken.None);

            // Delete DeviceRegistry SchemaRegistry Schema
            await schemaRegistrySchema.DeleteAsync(WaitUntil.Completed, CancellationToken.None);

            // Delete DeviceRegistry SchemaRegistry
            try
            {
                await schemaRegistry.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            }
            catch (RequestFailedException ex)
            {
                // Delete temporary returns 200 since async operation is defined for the resource but not implemented in RP
                if (ex.Status != 200)
                {
                    throw;
                }
            }
        }
    }
}
