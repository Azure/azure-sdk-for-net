// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Projects.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;

namespace Azure.Projects.Storage;

public class StorageAccountFeature : AzureProjectFeature
{
    private readonly StorageSkuName _skuName;
    public string Name { get; }

    public StorageAccountFeature(string accountName, StorageSkuName sku = StorageSkuName.StandardLrs)
    {
        _skuName = sku;
        Name = accountName;
    }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        var storageAccount = new StorageAccount("cm_storage", StorageAccount.ResourceVersions.V2023_01_01)
        {
            Name = Name,
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = _skuName },
            IsHnsEnabled = true,
            AllowBlobPublicAccess = false,
            AllowSharedKeyAccess = false,
            Identity = new()
            {
                ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
                UserAssignedIdentities = { { BicepFunction.Interpolate($"{infrastructure.Identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
            }
        };
        infrastructure.AddConstruct(Id, storageAccount);

        infrastructure.AddSystemRole(
            storageAccount,
            StorageBuiltInRole.GetBuiltInRoleName(StorageBuiltInRole.StorageBlobDataContributor),
            StorageBuiltInRole.StorageBlobDataContributor.ToString()
        );
        infrastructure.AddSystemRole(
            storageAccount,
            StorageBuiltInRole.GetBuiltInRoleName(StorageBuiltInRole.StorageTableDataContributor),
            StorageBuiltInRole.StorageTableDataContributor.ToString()
        );
    }
}

public class BlobServiceFeature : AzureProjectFeature
{
    public StorageAccountFeature? Account { get; set; }

    protected internal override void EmitFeatures(FeatureCollection features, string projectId)
    {
        // This should use feature.Id, just like GetConstruct<T>
        StorageAccountFeature? account = features.FindAll<StorageAccountFeature>().FirstOrDefault();
        if (account == default)
        {
            account = new(projectId);
            features.Append(account);
        }
        Account = account;
    }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        if (Account == null)
        {
            throw new InvalidOperationException("Account is not set.");
        }
        StorageAccount storageAccount = infrastructure.GetConstruct<StorageAccount>(Account.Id);

        BlobService blobService = new("cm_storage_blobs")
        {
            Parent = storageAccount
        };
        infrastructure.AddConstruct(Id, blobService);
    }
}

public class BlobContainerFeature : AzureProjectFeature
{
    public string ContainerName { get; }
    public BlobServiceFeature? Service { get; set; }

    public BlobContainerFeature(string containerName = "default")
    {
        ContainerName = containerName;
    }

    protected internal override void EmitFeatures(FeatureCollection features, string projectId)
    {
        // TODO: is it OK that we return the first one?
        BlobServiceFeature? blobBervice = features.FindAll<BlobServiceFeature>().FirstOrDefault();
        if (blobBervice == default)
        {
            StorageAccountFeature? storageAccount = features.FindAll<StorageAccountFeature>().FirstOrDefault();
            if (storageAccount == default)
            {
                storageAccount = new(projectId);
                features.Append(storageAccount);
            }

            blobBervice = new BlobServiceFeature() { Account = storageAccount };
            features.Append(blobBervice);
        }
        Service = blobBervice;
    }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        if (Service == null || Service.Account == null)
        {
            throw new InvalidOperationException("Service or Account is not set.");
        }

        BlobService blobService = infrastructure.GetConstruct<BlobService>(Service.Id);
        BlobContainer blobContainer = new($"cm_storage_blobs_container_{ContainerName}", "2023-01-01")
        {
            Parent = blobService,
            Name = ContainerName
        };
        infrastructure.AddConstruct(Id, blobContainer);

        EmitConnections(infrastructure,
            $"Azure.Storage.Blobs.BlobContainerClient@{ContainerName}",
            $"https://{Service.Account.Name}.blob.core.windows.net/{ContainerName}"
        );
    }
}
