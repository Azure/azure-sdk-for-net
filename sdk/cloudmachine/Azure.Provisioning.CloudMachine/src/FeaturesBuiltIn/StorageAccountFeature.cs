// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.CloudMachine.Core;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;

namespace Azure.CloudMachine;

internal class StorageAccountFeature : CloudMachineFeature
{
    private readonly StorageSkuName _skuName;
    private readonly string _name;
    public StorageAccountFeature(string accountName, StorageSkuName sku = StorageSkuName.StandardLrs)
    {
        _skuName = sku;
        _name = accountName;
    }

    protected override ProvisionableResource EmitConstructs(CloudMachineInfrastructure infrastructure)
    {
        var storage = new StorageAccount("cm_storage", StorageAccount.ResourceVersions.V2023_01_01)
        {
            Name = _name,
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = _skuName },
            IsHnsEnabled = true,
            AllowBlobPublicAccess = false,
            Identity = new()
            {
                ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
                UserAssignedIdentities = { { BicepFunction.Interpolate($"{infrastructure.Identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
            }
        };
        infrastructure.AddConstruct(storage);

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
    protected override ProvisionableResource EmitConstructs(CloudMachineInfrastructure cm)
    {
        BlobContainer container = new($"cm_storage_blobs_container_{ContainerName}", "2023-01-01")
        {
            Parent = (BlobService)Parent.Emitted,
            Name = ContainerName
        };
        cm.AddConstruct(container);
        return container;
    }

    protected internal override void EmitConnections(ConnectionCollection connections, string cmId)
    {
        ClientConnection connection = new(
            $"Azure.Storage.Blobs.BlobContainerClient@{ContainerName}",
            $"https://{cmId}.blob.core.windows.net/{ContainerName}"
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
    protected override ProvisionableResource EmitConstructs(CloudMachineInfrastructure cm)
    {
        BlobService blobs = new("cm_storage_blobs")
        {
            Parent = (StorageAccount)Account.Emitted,
        };
        cm.AddConstruct(blobs);
        return blobs;
    }
}
