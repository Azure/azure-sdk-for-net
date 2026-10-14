// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Storage.Tests;

public class StorageApiVersionTests
{
    [TestCase("2023-01-01")]
    [TestCase("2025-06-01")]
    public void ExplicitApiVersionIsPreserved(string version)
    {
        StorageAccount storage = new("storage", version);
        Assert.That(storage.ResourceVersion, Is.EqualTo(version));
        Assert.That(StorageAccount.ResourceVersions.V2025_06_01, Is.EqualTo("2025-06-01"));
        Assert.That(StorageAccount.ResourceVersions.V2026_06_01, Is.EqualTo("2026-06-01"));
    }

    [Test]
    public async Task CreateStorageUsingAlignedApiVersion()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                StorageAccount storage = new("storage")
                {
                    Kind = StorageKind.StorageV2,
                    Sku = { Name = StorageSkuName.StandardLrs },
                    AccessTier = StorageAccountAccessTier.Smart,
                    AllowCrossTenantDelegationSas = true
                };
                infra.Add(storage);
                return infra;
            });
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource storage 'Microsoft.Storage/storageAccounts@2026-06-01' = {
              name: take('storage${uniqueString(resourceGroup().id)}', 24)
              location: location
              kind: 'StorageV2'
              properties: {
                accessTier: 'Smart'
                allowCrossTenantDelegationSas: true
              }
              sku: {
                name: 'Standard_LRS'
              }
            }
            """);
    }

    [Test]
    public async Task CreateContextCacheUsingAlignedApiVersion()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                ContextCache cache = new("cache")
                {
                    Properties = new ContextCacheProperties
                    {
                        AccountKind = ContextCacheAccountKind.Regional
                    }
                };
                infra.Add(cache);
                return infra;
            });
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource cache 'Microsoft.Storage/contextCaches@2026-06-01' = {
              name: take('cache-${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                accountKind: 'Regional'
              }
            }
            """);
    }
}
