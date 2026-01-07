// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Storage;
using NUnit.Framework;

namespace Azure.Provisioning.Tests;

public class BicepMetadataTests
{
    [Test]
    public void BicepMetadataDescriptionTest()
    {
        new Trycep()
            .Define(ctx =>
            {
                Infrastructure infra = new();

                StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2023_01_01)
                {
                    Kind = StorageKind.StorageV2,
                    Sku = { Name = StorageSkuName.StandardLrs }
                };
                storage.BicepMetadata.Description = "Production storage account";
                infra.Add(storage);

                return infra;
            })
            .Compare(
                """
                @description('The location for the resource(s) to be deployed.')
                param location string = resourceGroup().location

                @description('Production storage account')
                resource storage 'Microsoft.Storage/storageAccounts@2023-01-01' = {
                  name: take('storage${uniqueString(resourceGroup().id)}', 24)
                  kind: 'StorageV2'
                  location: location
                  sku: {
                    name: 'Standard_LRS'
                  }
                }
                """);
    }

    [Test]
    public void BicepMetadataBatchSizeTest()
    {
        new Trycep()
            .Define(ctx =>
            {
                Infrastructure infra = new();

                StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2023_01_01)
                {
                    Kind = StorageKind.StorageV2,
                    Sku = { Name = StorageSkuName.StandardLrs }
                };
                storage.BicepMetadata.BatchSize = 1;
                infra.Add(storage);

                return infra;
            })
            .Compare(
                """
                @description('The location for the resource(s) to be deployed.')
                param location string = resourceGroup().location

                @batchSize(1)
                resource storage 'Microsoft.Storage/storageAccounts@2023-01-01' = {
                  name: take('storage${uniqueString(resourceGroup().id)}', 24)
                  kind: 'StorageV2'
                  location: location
                  sku: {
                    name: 'Standard_LRS'
                  }
                }
                """);
    }

    [Test]
    public void BicepMetadataOnlyIfNotExistsTest()
    {
        new Trycep()
            .Define(ctx =>
            {
                Infrastructure infra = new();

                StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2023_01_01)
                {
                    Kind = StorageKind.StorageV2,
                    Sku = { Name = StorageSkuName.StandardLrs }
                };
                storage.BicepMetadata.OnlyIfNotExists = true;
                infra.Add(storage);

                return infra;
            })
            .Compare(
                """
                @description('The location for the resource(s) to be deployed.')
                param location string = resourceGroup().location

                @onlyIfNotExists()
                resource storage 'Microsoft.Storage/storageAccounts@2023-01-01' = {
                  name: take('storage${uniqueString(resourceGroup().id)}', 24)
                  kind: 'StorageV2'
                  location: location
                  sku: {
                    name: 'Standard_LRS'
                  }
                }
                """);
    }

    [Test]
    public void BicepMetadataAllCombinedTest()
    {
        new Trycep()
            .Define(ctx =>
            {
                Infrastructure infra = new();

                StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2023_01_01)
                {
                    Kind = StorageKind.StorageV2,
                    Sku = { Name = StorageSkuName.StandardLrs }
                };
                storage.BicepMetadata.OnlyIfNotExists = true;
                storage.BicepMetadata.Description = "Production storage account";
                storage.BicepMetadata.BatchSize = 1;
                infra.Add(storage);

                return infra;
            })
            .Compare(
                """
                @description('The location for the resource(s) to be deployed.')
                param location string = resourceGroup().location

                @onlyIfNotExists()
                @description('Production storage account')
                @batchSize(1)
                resource storage 'Microsoft.Storage/storageAccounts@2023-01-01' = {
                  name: take('storage${uniqueString(resourceGroup().id)}', 24)
                  kind: 'StorageV2'
                  location: location
                  sku: {
                    name: 'Standard_LRS'
                  }
                }
                """);
    }
}
