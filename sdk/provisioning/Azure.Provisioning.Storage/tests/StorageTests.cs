// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.KeyVaults;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.Provisioning.Storage.Tests
{
    public class StorageTests : ProvisioningTestBase
    {
        public StorageTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task StorageBlobDefaults()
        {
            var infra = new TestInfrastructure();
            var storageAccount = infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            infra.AddBlobService();
            storageAccount.AssignProperty(a => a.PrimaryEndpoints,
                new Parameter(
                    "primaryEndpoints",
                    BicepType.Object,
                    defaultValue: "{ " +
                                  "'blob': 'https://photoacct.blob.core.windows.net/' " + Environment.NewLine +
                                  "'file': 'https://photoacct.file.core.windows.net/' " + Environment.NewLine +
                                    "'queue': 'https://photoacct.queue.core.windows.net/' " + Environment.NewLine +
                                  "}"));

            infra.Build(GetOutputPath());
            await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task StorageBlobDefaultsInPromptMode()
        {
            var infra = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            infra.AddBlobService();
            infra.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task CanAddCustomLocationParameterInInteractiveMode()
        {
            var infra = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var sa = infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            sa.AssignProperty(d => d.Location, new Parameter("myLocationParam"));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync(BinaryData.FromObjectAsJson(
                new
                {
                    myLocationParam = new { value = "eastus" },
                }),
                interactiveMode: true);
        }

        [RecordedTest]
        public async Task CanAssignParameterToMultipleResources()
        {
            var infra = new TestInfrastructure();
            infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            var overrideLocation = new Parameter("overrideLocation");

            var account1 = infra.AddStorageAccount(
                name: "sa1",
                kind: StorageKind.BlobStorage,
                sku: StorageSkuName.StandardLrs
            );
            account1.AssignProperty(a => a.Location, overrideLocation);

            var account2 = infra.AddStorageAccount(
                name: "sa2",
                kind: StorageKind.BlobStorage,
                sku: StorageSkuName.PremiumLrs
            );
            account2.AssignProperty(a => a.Location, overrideLocation);

            infra.Build(GetOutputPath());

            await ValidateBicepAsync(BinaryData.FromObjectAsJson(
                new
                {
                    overrideLocation = new { value = "eastus" },
                }));
        }

        [RecordedTest]
        public async Task StorageBlobDropDown()
        {
            var infra = new TestInfrastructure();
            infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            var blob = infra.AddBlobService();
            blob.Properties.DeleteRetentionPolicy = new DeleteRetentionPolicy()
            {
                IsEnabled = true
            };
            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task OutputsSpanningModules()
        {
            var infra = new TestInfrastructure();
            var rg1 = new ResourceGroup(infra, "rg1");
            var rg2 = new ResourceGroup(infra, "rg2");
            var rg3 = new ResourceGroup(infra, "rg3");
            var storageAccount1 = infra.AddStorageAccount(kind: StorageKind.Storage, sku: StorageSkuName.StandardGrs, parent: rg1);

            var output1 = storageAccount1.AddOutput("STORAGE_KIND", data => data.Kind);
            var output2 = storageAccount1.AddOutput("PRIMARY_ENDPOINTS", data => data.PrimaryEndpoints, BicepType.Object);

            KeyVaults.KeyVault keyVault = infra.AddKeyVault(resourceGroup: rg1);
            keyVault.AssignProperty(data => data.Properties.EnableSoftDelete, new Parameter("enableSoftDelete", description: "Enable soft delete", defaultValue: true, isSecure: false));

            var storageAccount2 = infra.AddStorageAccount(kind: StorageKind.Storage, sku: StorageSkuName.StandardGrs, parent: rg2);

            storageAccount2.AssignProperty(data => data.Kind, new Parameter(output1));
            storageAccount2.AssignProperty(data => data.PrimaryEndpoints, new Parameter(output2));

            infra.AddStorageAccount(kind: StorageKind.Storage, sku: StorageSkuName.StandardGrs, parent: rg3);
            infra.Build(GetOutputPath());

            Assert.AreEqual(3, infra.GetParameters().Count());
            Assert.AreEqual(2, infra.GetOutputs().Count());

            await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task StorageAccountWithNetworkRuleSet()
        {
            var infra = new TestInfrastructure();
            var storageAccount = infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            storageAccount.AssignProperty(p => p.NetworkRuleSet.DefaultAction, "'Allow'");
            storageAccount.AssignProperty(p => p.NetworkRuleSet.Bypass, "'AzureServices'");
            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task ExistingResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();
            var sa = StorageAccount.FromExisting(infra, "'existingStorage'", rg);
            infra.AddResource(sa);
            infra.AddResource(BlobService.FromExisting(infra, "'existingBlobService'", sa));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}
