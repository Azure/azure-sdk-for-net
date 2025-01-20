// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.CloudMachine.Core;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;

namespace Azure.CloudMachine.Storage;

internal class StorageAccountFeature : CloudMachineFeature
{
    private readonly StorageSkuName _skuName;
    public string Name { get; }

    public StorageAccountFeature(string accountName, StorageSkuName sku = StorageSkuName.StandardLrs)
    {
        _skuName = sku;
        Name = accountName;
    }

    protected override ProvisionableResource EmitResources(CloudMachineInfrastructure infrastructure)
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
        infrastructure.AddResource(storage);

        RequiredSystemRoles.Add(storage,
            [
                (StorageBuiltInRole.GetBuiltInRoleName(StorageBuiltInRole.StorageBlobDataContributor),StorageBuiltInRole.StorageBlobDataContributor.ToString()),
                (StorageBuiltInRole.GetBuiltInRoleName(StorageBuiltInRole.StorageTableDataContributor), StorageBuiltInRole.StorageTableDataContributor.ToString())
            ]
        );
        return storage;
    }
}

internal class BlobContainerFeature : CloudMachineFeature
{
    public string ContainerName { get; }
    public BlobServiceFeature Parent { get; }

    public BlobContainerFeature(BlobServiceFeature parent, string? containerName = default)
    {
        if (containerName == default) containerName = CloudMachineConnections.DefaultBlobContainerName;
        ContainerName = containerName;
        Parent = parent;
    }
    protected override ProvisionableResource EmitResources(CloudMachineInfrastructure cm)
    {
        BlobContainer container = new($"cm_storage_blobs_container_{ContainerName}", "2023-01-01")
        {
            Parent = (BlobService)Parent.Resource,
            Name = ContainerName
        };
        cm.AddResource(container);
        return container;
    }

    protected internal override void EmitConnections(ConnectionCollection connections, string cmId)
    {
        ClientConnection connection = new(
            $"Azure.Storage.Blobs.BlobContainerClient@{ContainerName}",
            $"https://{Parent.Account.Name}.blob.core.windows.net/{ContainerName}"
        );
        connections.Add(connection);
    }
}

internal class BlobServiceFeature : CloudMachineFeature
{
    public StorageAccountFeature Account { get; }

    public BlobServiceFeature(StorageAccountFeature account)
    {
        Account = account;
    }
    protected override ProvisionableResource EmitResources(CloudMachineInfrastructure cm)
    {
        BlobService blobs = new("cm_storage_blobs")
        {
            Parent = (StorageAccount)Account.Resource,
        };
        cm.AddResource(blobs);
        return blobs;
    }
}
