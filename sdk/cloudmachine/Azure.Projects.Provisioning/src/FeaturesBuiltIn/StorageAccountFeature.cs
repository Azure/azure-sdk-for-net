// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Projects.Core;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;
using System.ClientModel.Primitives;

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
        infrastructure.AddResource(storage);

        FeatureRole blobContributor = new(
            StorageBuiltInRole.GetBuiltInRoleName(StorageBuiltInRole.StorageBlobDataContributor), StorageBuiltInRole.StorageBlobDataContributor.ToString()
        );
        FeatureRole tableContributor = new(
            StorageBuiltInRole.GetBuiltInRoleName(StorageBuiltInRole.StorageTableDataContributor), StorageBuiltInRole.StorageTableDataContributor.ToString()
        );

        RequiredSystemRoles.Add(storage, [blobContributor, tableContributor]);
        return storage;
    }
}

internal class BlobContainerFeature : AzureProjectFeature
{
    public string ContainerName { get; }
    public BlobServiceFeature Parent { get; }

    public BlobContainerFeature(BlobServiceFeature parent, string? containerName = default)
    {
        if (containerName == default) containerName = ProjectConnections.DefaultBlobContainerName;
        ContainerName = containerName;
        Parent = parent;
    }
    protected override ProvisionableResource EmitResources(ProjectInfrastructure cm)
    {
        BlobContainer container = new($"cm_storage_blobs_container_{ContainerName}", "2023-01-01")
        {
            Parent = (BlobService)Parent.Resource,
            Name = ContainerName
        };
        cm.AddResource(container);
        return container;
    }

    protected internal override void EmitConnections(ICollection<ClientConnection> connections, string cmId)
    {
        ClientConnection connection = new(
            $"Azure.Storage.Blobs.BlobContainerClient@{ContainerName}",
            $"https://{Parent.Account.Name}.blob.core.windows.net/{ContainerName}",
            ClientAuthenticationMethod.Credential
        );
        connections.Add(connection);
    }
}

internal class BlobServiceFeature : AzureProjectFeature
{
    public StorageAccountFeature Account { get; }

    public BlobServiceFeature(StorageAccountFeature account)
    {
        Account = account;
    }
    protected override ProvisionableResource EmitResources(ProjectInfrastructure cm)
    {
        BlobService blobs = new("cm_storage_blobs")
        {
            Parent = (StorageAccount)Account.Resource,
        };
        cm.AddResource(blobs);
        return blobs;
    }
}
