// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using Azure.Projects.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
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

    protected override ProvisionableResource EmitResources(ProjectInfrastructure infrastructure)
    {
        var storage = new StorageAccount("cm_storage", StorageAccount.ResourceVersions.V2023_01_01)
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
        infrastructure.AddConstruct(storage);

        infrastructure.AddSystemRole(
            storage,
            StorageBuiltInRole.GetBuiltInRoleName(StorageBuiltInRole.StorageBlobDataContributor),
            StorageBuiltInRole.StorageBlobDataContributor.ToString()
        );
        infrastructure.AddSystemRole(
            storage,
            StorageBuiltInRole.GetBuiltInRoleName(StorageBuiltInRole.StorageTableDataContributor),
            StorageBuiltInRole.StorageTableDataContributor.ToString()
        );

        return storage;
    }
}

public class BlobServiceFeature : AzureProjectFeature
{
    public StorageAccountFeature? Account { get; set; }

    protected internal override void AddImplicitFeatures(FeatureCollection features, string projectId)
    {
        StorageAccountFeature? account = features.FindAll<StorageAccountFeature>().FirstOrDefault();
        if (account == default)
        {
            account = new(projectId);
            features.Append(account);
        }
        Account = account;
    }

    protected override ProvisionableResource EmitResources(ProjectInfrastructure cm)
    {
        if (Account == null)
        {
            throw new InvalidOperationException("Parent StorageAccountFeature is not set.");
        }

        BlobService blobs = new("cm_storage_blobs")
        {
            Parent = (StorageAccount)Account.Resource,
        };
        cm.AddConstruct(blobs);
        return blobs;
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

    protected internal override void AddImplicitFeatures(FeatureCollection features, string projectId)
    {
        // TODO: is it OK that we return the first one?
        BlobServiceFeature? service = features.FindAll<BlobServiceFeature>().FirstOrDefault();
        if (service == default)
        {
            StorageAccountFeature? account = features.FindAll<StorageAccountFeature>().FirstOrDefault();
            if (account == default)
            {
                account = new(projectId);
                features.Append(account);
            }

            service = new BlobServiceFeature() { Account = account };
            features.Append(service);
        }
        Service = service;
        features.Append(this);
    }

    protected override ProvisionableResource EmitResources(ProjectInfrastructure infrastructure)
    {
        if (Service == null || Service.Account == null)
        {
            throw new InvalidOperationException("Service or Account is not set.");
        }

        BlobContainer container = new($"cm_storage_blobs_container_{ContainerName}", "2023-01-01")
        {
            Parent = (BlobService)Service.Resource,
            Name = ContainerName
        };
        infrastructure.AddConstruct(container);

        EmitConnection(infrastructure,
            $"Azure.Storage.Blobs.BlobContainerClient@{ContainerName}",
            $"https://{Service.Account.Name}.blob.core.windows.net/{ContainerName}"
        );

        return container;
    }
}
