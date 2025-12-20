// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Storage;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Tests;

public class BicepMetadataTests
{
    [Test]
    public void BicepMetadataDescriptionTest()
    {
        Infrastructure infra = new();

        StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2023_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = { Name = StorageSkuName.StandardLrs }
        };
        storage.BicepMetadata.Description = "Production storage account";
        infra.Add(storage);

        ProvisioningPlan plan = infra.Build();
        string bicep = plan.Compile()["main.bicep"];

        Assert.That(bicep, Does.Contain("@description('Production storage account')"));
        Assert.That(bicep, Does.Contain("resource storage 'Microsoft.Storage/storageAccounts@2023-01-01'"));
    }

    [Test]
    public void BicepMetadataConditionTest()
    {
        Infrastructure infra = new();

        ProvisioningParameter deployStorage = new("deployStorage", typeof(bool)) { Value = true };
        infra.Add(deployStorage);

        StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2023_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = { Name = StorageSkuName.StandardLrs }
        };
        storage.BicepMetadata.Condition = "deployStorage";
        infra.Add(storage);

        ProvisioningPlan plan = infra.Build();
        string bicep = plan.Compile()["main.bicep"];

        Assert.That(bicep, Does.Contain("= if (deployStorage)"));
    }

    [Test]
    public void BicepMetadataBatchSizeTest()
    {
        Infrastructure infra = new();

        StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2023_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = { Name = StorageSkuName.StandardLrs }
        };
        storage.BicepMetadata.BatchSize = 1;
        infra.Add(storage);

        ProvisioningPlan plan = infra.Build();
        string bicep = plan.Compile()["main.bicep"];

        Assert.That(bicep, Does.Contain("@batchSize(1)"));
    }

    [Test]
    public void BicepMetadataOnlyIfNotExistsTest()
    {
        Infrastructure infra = new();

        StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2023_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = { Name = StorageSkuName.StandardLrs }
        };
        storage.BicepMetadata.OnlyIfNotExists = true;
        infra.Add(storage);

        ProvisioningPlan plan = infra.Build();
        string bicep = plan.Compile()["main.bicep"];

        Assert.That(bicep, Does.Contain("@onlyIfNotExists()"));
    }

    [Test]
    public void BicepMetadataAllCombinedTest()
    {
        Infrastructure infra = new();

        ProvisioningParameter deployStorage = new("deployStorage", typeof(bool)) { Value = true };
        infra.Add(deployStorage);

        StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2023_01_01)
        {
            Kind = StorageKind.StorageV2,
            Sku = { Name = StorageSkuName.StandardLrs }
        };
        storage.BicepMetadata.OnlyIfNotExists = true;
        storage.BicepMetadata.Description = "Assign Cosmos DB SQL Role Assignment to the API principal";
        storage.BicepMetadata.BatchSize = 1;
        storage.BicepMetadata.Condition = "deployStorage";
        infra.Add(storage);

        ProvisioningPlan plan = infra.Build();
        string bicep = plan.Compile()["main.bicep"];

        // Verify all decorators are present
        Assert.That(bicep, Does.Contain("@onlyIfNotExists()"));
        Assert.That(bicep, Does.Contain("@description('Assign Cosmos DB SQL Role Assignment to the API principal')"));
        Assert.That(bicep, Does.Contain("@batchSize(1)"));
        Assert.That(bicep, Does.Contain("= if (deployStorage)"));

        // Verify the expected output structure (decorators should come before resource)
        int onlyIfNotExistsPos = bicep.IndexOf("@onlyIfNotExists()");
        int descriptionPos = bicep.IndexOf("@description(");
        int batchSizePos = bicep.IndexOf("@batchSize(");
        int resourcePos = bicep.IndexOf("resource storage");

        Assert.That(onlyIfNotExistsPos, Is.LessThan(resourcePos));
        Assert.That(descriptionPos, Is.LessThan(resourcePos));
        Assert.That(batchSizePos, Is.LessThan(resourcePos));
    }
}
