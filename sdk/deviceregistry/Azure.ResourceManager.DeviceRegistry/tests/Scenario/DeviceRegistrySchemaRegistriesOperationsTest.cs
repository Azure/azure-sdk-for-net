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
using SystemAssignedManagedIdentityType = Azure.ResourceManager.DeviceRegistry.Models.SystemAssignedServiceIdentityType;

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
                Identity = new(SystemAssignedManagedIdentityType.SystemAssigned)
            };
            var schemaRegistryCreateOrUpdateResponse = await schemaRegistriesCollection.CreateOrUpdateAsync(WaitUntil.Completed, schemaRegistryName, schemaRegistryData, CancellationToken.None);
            Assert.That(schemaRegistryCreateOrUpdateResponse.Value, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(schemaRegistryCreateOrUpdateResponse.Value.Data.Identity.TenantId, Is.Not.Null);
                Assert.That(schemaRegistryCreateOrUpdateResponse.Value.Data.Identity.PrincipalId, Is.Not.Null);
                Assert.That(SystemAssignedManagedIdentityType.SystemAssigned, Is.EqualTo(schemaRegistryCreateOrUpdateResponse.Value.Data.Identity.Type));
                Assert.That(Guid.TryParse(schemaRegistryCreateOrUpdateResponse.Value.Data.Properties.Uuid, out _), Is.True);
                Assert.That(schemaRegistryData.Properties.Namespace, Is.EqualTo(schemaRegistryCreateOrUpdateResponse.Value.Data.Properties.Namespace));
                Assert.That(schemaRegistryData.Properties.Description, Is.EqualTo(schemaRegistryCreateOrUpdateResponse.Value.Data.Properties.Description));
                Assert.That(schemaRegistryData.Properties.DisplayName, Is.EqualTo(schemaRegistryCreateOrUpdateResponse.Value.Data.Properties.DisplayName));
                Assert.That(schemaRegistryData.Properties.StorageAccountContainerUri, Is.EqualTo(schemaRegistryCreateOrUpdateResponse.Value.Data.Properties.StorageAccountContainerUri));
            });

            // Read DeviceRegistry SchemaRegistry
            var schemaRegistryReadResponse = await schemaRegistriesCollection.GetAsync(schemaRegistryName, CancellationToken.None);
            Assert.That(schemaRegistryReadResponse.Value, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(schemaRegistryReadResponse.Value.Data.Identity.TenantId, Is.Not.Null);
                Assert.That(schemaRegistryReadResponse.Value.Data.Identity.PrincipalId, Is.Not.Null);
                Assert.That(SystemAssignedManagedIdentityType.SystemAssigned, Is.EqualTo(schemaRegistryReadResponse.Value.Data.Identity.Type));
                Assert.That(Guid.TryParse(schemaRegistryReadResponse.Value.Data.Properties.Uuid, out _), Is.True);
                Assert.That(schemaRegistryData.Properties.Namespace, Is.EqualTo(schemaRegistryReadResponse.Value.Data.Properties.Namespace));
                Assert.That(schemaRegistryData.Properties.Description, Is.EqualTo(schemaRegistryReadResponse.Value.Data.Properties.Description));
                Assert.That(schemaRegistryData.Properties.DisplayName, Is.EqualTo(schemaRegistryReadResponse.Value.Data.Properties.DisplayName));
                Assert.That(schemaRegistryData.Properties.StorageAccountContainerUri, Is.EqualTo(schemaRegistryReadResponse.Value.Data.Properties.StorageAccountContainerUri));
            });

            // List DeviceRegistry SchemaRegistry by Resource Group
            var schemaRegistryResourcesListByResourceGroup = new List<DeviceRegistrySchemaRegistryResource>();
            var schemaRegistryResourceListByResourceGroupAsyncIteratorPage = schemaRegistriesCollection.GetAllAsync(CancellationToken.None).AsPages(null, 5);
            await foreach (var schemaRegistryEntryPage in schemaRegistryResourceListByResourceGroupAsyncIteratorPage)
            {
                schemaRegistryResourcesListByResourceGroup.AddRange(schemaRegistryEntryPage.Values);
            }
            Assert.That(schemaRegistryResourcesListByResourceGroup, Is.Not.Empty);
            Assert.That(schemaRegistryResourcesListByResourceGroup.Count, Is.GreaterThanOrEqualTo(1));

            // List DeviceRegistry SchemaRegistry by Subscription
            var schemaRegistryResourcesListBySubscription = new List<DeviceRegistrySchemaRegistryResource>();
            var schemaRegistryResourceListBySubscriptionAsyncIteratorPage = subscription.GetDeviceRegistrySchemaRegistriesAsync(CancellationToken.None).AsPages(null, 5);
            await foreach (var schemaRegistryEntryPage in schemaRegistryResourceListBySubscriptionAsyncIteratorPage)
            {
                schemaRegistryResourcesListBySubscription.AddRange(schemaRegistryEntryPage.Values);
            }
            Assert.That(schemaRegistryResourcesListBySubscription, Is.Not.Empty);
            Assert.That(schemaRegistryResourcesListBySubscription.Count, Is.GreaterThanOrEqualTo(1));

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
            Assert.That(schemaRegistryUpdateResponse.Value, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(schemaRegistryUpdateResponse.Value.Data.Identity.TenantId, Is.Not.Null);
                Assert.That(schemaRegistryUpdateResponse.Value.Data.Identity.PrincipalId, Is.Not.Null);
                Assert.That(SystemAssignedManagedIdentityType.SystemAssigned, Is.EqualTo(schemaRegistryUpdateResponse.Value.Data.Identity.Type));
                Assert.That(Guid.TryParse(schemaRegistryUpdateResponse.Value.Data.Properties.Uuid, out _), Is.True);
                Assert.That(schemaRegistryData.Properties.Namespace, Is.EqualTo(schemaRegistryUpdateResponse.Value.Data.Properties.Namespace));
                Assert.That(schemaRegistryPatchData.Properties.Description, Is.EqualTo(schemaRegistryUpdateResponse.Value.Data.Properties.Description));
                Assert.That(schemaRegistryData.Properties.DisplayName, Is.EqualTo(schemaRegistryUpdateResponse.Value.Data.Properties.DisplayName));
                Assert.That(schemaRegistryData.Properties.StorageAccountContainerUri, Is.EqualTo(schemaRegistryUpdateResponse.Value.Data.Properties.StorageAccountContainerUri));
            });

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
            Assert.Multiple(() =>
            {
                Assert.That(schemaRegistrySchemaCreateOrUpdateResponse.Value, Is.Not.Null);
                Assert.That(Guid.TryParse(schemaRegistrySchemaCreateOrUpdateResponse.Value.Data.Properties.Uuid, out _), Is.True);
                Assert.That(schemaRegistrySchemaData.Properties.SchemaType, Is.EqualTo(schemaRegistrySchemaCreateOrUpdateResponse.Value.Data.Properties.SchemaType));
                Assert.That(schemaRegistrySchemaData.Properties.Format, Is.EqualTo(schemaRegistrySchemaCreateOrUpdateResponse.Value.Data.Properties.Format));
                Assert.That(schemaRegistrySchemaData.Properties.Description, Is.EqualTo(schemaRegistrySchemaCreateOrUpdateResponse.Value.Data.Properties.Description));
                Assert.That(schemaRegistrySchemaData.Properties.DisplayName, Is.EqualTo(schemaRegistrySchemaCreateOrUpdateResponse.Value.Data.Properties.DisplayName));
            });

            // Read DeviceRegistry SchemaRegistry Schema
            var schemaRegistrySchemaReadResponse = await schemaRegistriesSchemasCollection.GetAsync(schemaRegistrySchemaName, CancellationToken.None);
            Assert.Multiple(() =>
            {
                Assert.That(schemaRegistrySchemaReadResponse.Value, Is.Not.Null);
                Assert.That(Guid.TryParse(schemaRegistrySchemaReadResponse.Value.Data.Properties.Uuid, out _), Is.True);
                Assert.That(schemaRegistrySchemaData.Properties.SchemaType, Is.EqualTo(schemaRegistrySchemaReadResponse.Value.Data.Properties.SchemaType));
                Assert.That(schemaRegistrySchemaData.Properties.Format, Is.EqualTo(schemaRegistrySchemaReadResponse.Value.Data.Properties.Format));
                Assert.That(schemaRegistrySchemaData.Properties.Description, Is.EqualTo(schemaRegistrySchemaReadResponse.Value.Data.Properties.Description));
                Assert.That(schemaRegistrySchemaData.Properties.DisplayName, Is.EqualTo(schemaRegistrySchemaReadResponse.Value.Data.Properties.DisplayName));
            });

            // List DeviceRegistry SchemaRegistry Schema by SchemaRegistry
            var schemaResourcesListBySchemaRegistry = new List<DeviceRegistrySchemaResource>();
            var schemaRegistrySchemaListBySchemaRegistryAsyncIterator = schemaRegistriesSchemasCollection.GetAllAsync(CancellationToken.None);
            await foreach (var schemaEntry in schemaRegistrySchemaListBySchemaRegistryAsyncIterator)
            {
                schemaResourcesListBySchemaRegistry.Add(schemaEntry);
            }
            Assert.That(schemaResourcesListBySchemaRegistry, Is.Not.Empty);
            Assert.Multiple(() =>
            {
                Assert.That(schemaResourcesListBySchemaRegistry, Has.Count.EqualTo(1));
                Assert.That(Guid.TryParse(schemaResourcesListBySchemaRegistry[0].Data.Properties.Uuid, out _), Is.True);
                Assert.That(schemaRegistrySchemaData.Properties.SchemaType, Is.EqualTo(schemaResourcesListBySchemaRegistry[0].Data.Properties.SchemaType));
                Assert.That(schemaRegistrySchemaData.Properties.Format, Is.EqualTo(schemaResourcesListBySchemaRegistry[0].Data.Properties.Format));
                Assert.That(schemaRegistrySchemaData.Properties.Description, Is.EqualTo(schemaResourcesListBySchemaRegistry[0].Data.Properties.Description));
                Assert.That(schemaRegistrySchemaData.Properties.DisplayName, Is.EqualTo(schemaResourcesListBySchemaRegistry[0].Data.Properties.DisplayName));
            });

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
            Assert.Multiple(() =>
            {
                Assert.That(schemaRegistrySchemaVersionCreateOrUpdateResponse.Value, Is.Not.Null);
                Assert.That(Guid.TryParse(schemaRegistrySchemaVersionCreateOrUpdateResponse.Value.Data.Properties.Uuid, out _), Is.True);
                Assert.That(schemaRegistrySchemaVersionData.Properties.SchemaContent, Is.EqualTo(schemaRegistrySchemaVersionCreateOrUpdateResponse.Value.Data.Properties.SchemaContent));
                Assert.That(schemaRegistrySchemaVersionData.Properties.Description, Is.EqualTo(schemaRegistrySchemaVersionCreateOrUpdateResponse.Value.Data.Properties.Description));
            });

            // Read DeviceRegistry SchemaRegistry Schema Version
            var schemaRegistrySchemaVersionReadResponse = await schemaRegistriesSchemaVersionsCollection.GetAsync(schemaRegistrySchemaVersionName, CancellationToken.None);
            Assert.Multiple(() =>
            {
                Assert.That(schemaRegistrySchemaVersionReadResponse.Value, Is.Not.Null);
                Assert.That(Guid.TryParse(schemaRegistrySchemaVersionReadResponse.Value.Data.Properties.Uuid, out _), Is.True);
                Assert.That(schemaRegistrySchemaVersionData.Properties.SchemaContent, Is.EqualTo(schemaRegistrySchemaVersionReadResponse.Value.Data.Properties.SchemaContent));
                Assert.That(schemaRegistrySchemaVersionData.Properties.Description, Is.EqualTo(schemaRegistrySchemaVersionReadResponse.Value.Data.Properties.Description));
            });

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
