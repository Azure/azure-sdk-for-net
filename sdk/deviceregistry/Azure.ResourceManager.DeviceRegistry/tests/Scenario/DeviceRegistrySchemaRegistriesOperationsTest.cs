// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DeviceRegistry.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceRegistry.Tests.Scenario
{
    public class DeviceRegistrySchemaRegistriesOperationsTest : DeviceRegistryManagementTestBase
    {
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _rgNamePrefix = "adr-test-sdk-rg";
        private readonly string _assetSchemaRegistryNamePrefix = "deviceregistry-test-schemaregistry-sdk";
        private readonly string _assetSchemaRegistrySchemaNamePrefix = "deviceregistry-test-schemaregistryschema-sdk";
        private readonly string _assetSchemaRegistrySchemaVersionNamePrefix = "deviceregistry-test-schemaregistryschemaversion-sdk";

        public DeviceRegistrySchemaRegistriesOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task SchemaRegistriesCrudOperationsTest()
        {
            var schemaRegistryName = Recording.GenerateAssetName(_assetSchemaRegistryNamePrefix);
            var schemaRegistrySchemaName = Recording.GenerateAssetName(_assetSchemaRegistrySchemaNamePrefix);
            var schemaRegistrySchemaVersionName = Recording.GenerateAssetName(_assetSchemaRegistrySchemaVersionNamePrefix);

            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));
            var rg = await CreateResourceGroup(subscription, _rgNamePrefix, AzureLocation.WestUS);

            /*******************
            *                  *
            * SchemaRegistries *
            *                  *
            *******************/

            var schemaRegistriesCollection = rg.GetSchemaRegistries();

            // Create DeviceRegistry SchemaRegistry
            var schemaRegistryData = new SchemaRegistryData(AzureLocation.WestUS)
            {
                Properties = new()
                {
                    Namespace = "sdktest",
                    Description = "This is a Schema Registry instance.",
                    DisplayName = "Schema Registry SDK test",
                    StorageAccountContainerUri = new Uri("https://storageaccount.blob.core.windows.net/container")
                }
            };
            var schemaRegistryCreateOrUpdateResponse = await schemaRegistriesCollection.CreateOrUpdateAsync(WaitUntil.Completed, schemaRegistryName, schemaRegistryData, CancellationToken.None);
            Assert.IsNotNull(schemaRegistryCreateOrUpdateResponse.Value);
            Assert.IsNotNull(schemaRegistryCreateOrUpdateResponse.Value.Data.Identity.TenantId);
            Assert.IsNotNull(schemaRegistryCreateOrUpdateResponse.Value.Data.Identity.PrincipalId);
            Assert.AreEqual(schemaRegistryCreateOrUpdateResponse.Value.Data.Identity.ManagedServiceIdentityType, ResourceManager.Models.ManagedServiceIdentityType.SystemAssigned);
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
            Assert.AreEqual(schemaRegistryReadResponse.Value.Data.Identity.ManagedServiceIdentityType, ResourceManager.Models.ManagedServiceIdentityType.SystemAssigned);
            Assert.IsTrue(Guid.TryParse(schemaRegistryReadResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(schemaRegistryReadResponse.Value.Data.Properties.Namespace, schemaRegistryData.Properties.Namespace);
            Assert.AreEqual(schemaRegistryReadResponse.Value.Data.Properties.Description, schemaRegistryData.Properties.Description);
            Assert.AreEqual(schemaRegistryReadResponse.Value.Data.Properties.DisplayName, schemaRegistryData.Properties.DisplayName);
            Assert.AreEqual(schemaRegistryReadResponse.Value.Data.Properties.StorageAccountContainerUri, schemaRegistryData.Properties.StorageAccountContainerUri);

            // List DeviceRegistry SchemaRegistry by Resource Group
            var schemaRegistryResourcesListByResourceGroup = new List<SchemaRegistryResource>();
            var schemaRegistryResourceListByResourceGroupAsyncIterator = schemaRegistriesCollection.GetAllAsync(CancellationToken.None);
            await foreach (var schemaRegistryEntry in schemaRegistryResourceListByResourceGroupAsyncIterator)
            {
                schemaRegistryResourcesListByResourceGroup.Add(schemaRegistryEntry);
            }
            Assert.IsNotEmpty(schemaRegistryResourcesListByResourceGroup);
            Assert.AreEqual(schemaRegistryResourcesListByResourceGroup.Count, 1);
            Assert.IsNotNull(schemaRegistryResourcesListByResourceGroup[0].Data.Identity.TenantId);
            Assert.IsNotNull(schemaRegistryResourcesListByResourceGroup[0].Data.Identity.PrincipalId);
            Assert.AreEqual(schemaRegistryResourcesListByResourceGroup[0].Data.Identity.ManagedServiceIdentityType, ResourceManager.Models.ManagedServiceIdentityType.SystemAssigned);
            Assert.IsTrue(Guid.TryParse(schemaRegistryResourcesListByResourceGroup[0].Data.Properties.Uuid, out _));
            Assert.AreEqual(schemaRegistryResourcesListByResourceGroup[0].Data.Properties.Namespace, schemaRegistryData.Properties.Namespace);
            Assert.AreEqual(schemaRegistryResourcesListByResourceGroup[0].Data.Properties.Description, schemaRegistryData.Properties.Description);
            Assert.AreEqual(schemaRegistryResourcesListByResourceGroup[0].Data.Properties.DisplayName, schemaRegistryData.Properties.DisplayName);
            Assert.AreEqual(schemaRegistryResourcesListByResourceGroup[0].Data.Properties.StorageAccountContainerUri, schemaRegistryData.Properties.StorageAccountContainerUri);

            // List DeviceRegistry SchemaRegistry by Subscription
            var schemaRegistryResourcesListBySubscription = new List<SchemaRegistryResource>();
            var schemaRegistryResourceListBySubscriptionAsyncIterator = subscription.GetSchemaRegistriesAsync(CancellationToken.None);
            await foreach (var schemaRegistryEntry in schemaRegistryResourceListBySubscriptionAsyncIterator)
            {
                schemaRegistryResourcesListBySubscription.Add(schemaRegistryEntry);
            }
            Assert.IsNotEmpty(schemaRegistryResourcesListBySubscription);
            Assert.AreEqual(schemaRegistryResourcesListBySubscription.Count, 1);
            Assert.IsNotNull(schemaRegistryResourcesListBySubscription[0].Data.Identity.TenantId);
            Assert.IsNotNull(schemaRegistryResourcesListBySubscription[0].Data.Identity.PrincipalId);
            Assert.AreEqual(schemaRegistryResourcesListBySubscription[0].Data.Identity.ManagedServiceIdentityType, ResourceManager.Models.ManagedServiceIdentityType.SystemAssigned);
            Assert.IsTrue(Guid.TryParse(schemaRegistryResourcesListBySubscription[0].Data.Properties.Uuid, out _));
            Assert.AreEqual(schemaRegistryResourcesListBySubscription[0].Data.Properties.Namespace, schemaRegistryData.Properties.Namespace);
            Assert.AreEqual(schemaRegistryResourcesListBySubscription[0].Data.Properties.Description, schemaRegistryData.Properties.Description);
            Assert.AreEqual(schemaRegistryResourcesListBySubscription[0].Data.Properties.DisplayName, schemaRegistryData.Properties.DisplayName);
            Assert.AreEqual(schemaRegistryResourcesListBySubscription[0].Data.Properties.StorageAccountContainerUri, schemaRegistryData.Properties.StorageAccountContainerUri);

            // Update DeviceRegistry SchemaRegistry
            var schemaRegistry = schemaRegistryReadResponse.Value;
            var schemaRegistryPatchData = new SchemaRegistryPatch
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
            Assert.AreEqual(schemaRegistryUpdateResponse.Value.Data.Identity.ManagedServiceIdentityType, ResourceManager.Models.ManagedServiceIdentityType.SystemAssigned);
            Assert.IsTrue(Guid.TryParse(schemaRegistryUpdateResponse.Value.Data.Properties.Uuid, out _));
            Assert.AreEqual(schemaRegistryUpdateResponse.Value.Data.Properties.Namespace, schemaRegistryData.Properties.Namespace);
            Assert.AreEqual(schemaRegistryUpdateResponse.Value.Data.Properties.Description, schemaRegistryPatchData.Properties.Description);
            Assert.AreEqual(schemaRegistryUpdateResponse.Value.Data.Properties.DisplayName, schemaRegistryData.Properties.DisplayName);
            Assert.AreEqual(schemaRegistryUpdateResponse.Value.Data.Properties.StorageAccountContainerUri, schemaRegistryData.Properties.StorageAccountContainerUri);

            /***************************
            *                          *
            * SchemaRegistries/Schemas *
            *                          *
            ***************************/

            var schemaRegistriesSchemasCollection = schemaRegistry.GetSchemas();

            // Create DeviceRegistry SchemaRegistry Schema
            var schemaRegistrySchemaData = new SchemaData()
            {
                Properties = new()
                {
                    SchemaType = SchemaType.MessageSchema,
                    Format = Format.JsonSchemaDraft7,
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
            var schemaResourcesListBySchemaRegistry = new List<SchemaResource>();
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

            /******************************************
            *                                         *
            * SchemaRegistries/Schemas/SchemaVersions *
            *                                         *
            ******************************************/

            var schemaRegistriesSchemaVersionsCollection = schemaRegistrySchema.GetSchemaVersions();

            // Create DeviceRegistry SchemaRegistry Schema Version
            var schemaRegistrySchemaVersionData = new SchemaVersionData()
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

            // Delete DeviceRegistry SchemaRegistry Schema Version
            await schemaRegistrySchemaVersion.DeleteAsync(WaitUntil.Completed, CancellationToken.None);

            // Delete DeviceRegistry SchemaRegistry Schema
            await schemaRegistrySchema.DeleteAsync(WaitUntil.Completed, CancellationToken.None);

            // Delete DeviceRegistry SchemaRegistry
            await schemaRegistry.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
        }
    }
}
