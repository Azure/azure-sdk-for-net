// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;

namespace Azure.CloudMachine;

public class StorageFeature : CloudMachineFeature
{
    private readonly List<string> _containerNames;
    private readonly StorageSkuName _skuName;
    private readonly string _name;

    public StorageFeature(string accountName, StorageSkuName sku = StorageSkuName.StandardLrs, IEnumerable<string>? containerNames = null)
    {
        _skuName = sku;
        _name = accountName;
        if (containerNames != null)
            _containerNames = containerNames.ToList();
        else
            _containerNames = ["default"];
    }

    protected override ProvisionableResource EmitInfrastructure(CloudMachineInfrastructure infrastructure)
    {
        var _storage =
            new StorageAccount("cm_storage", StorageAccount.ResourceVersions.V2023_01_01)
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
        infrastructure.AddConstruct(_storage);

        var _blobs = new BlobService("cm_storage_blobs")
        {
            Parent = _storage,
        };
        infrastructure.AddConstruct(_blobs);

        foreach (var containerName in _containerNames)
        {
            infrastructure.AddConstruct(
                new BlobContainer("cm_storage_blobs_container_" + containerName, "2023-01-01")
                {
                    Parent = _blobs,
                    Name = containerName
                }
            );
        }

        RequiredSystemRoles.Add(
            _storage,
            [
                (StorageBuiltInRole.GetBuiltInRoleName(StorageBuiltInRole.StorageBlobDataContributor),StorageBuiltInRole.StorageBlobDataContributor.ToString()),
                (StorageBuiltInRole.GetBuiltInRoleName(StorageBuiltInRole.StorageTableDataContributor), StorageBuiltInRole.StorageTableDataContributor.ToString())
            ]);

        // Placeholders for now.
        infrastructure.AddConstruct(new ProvisioningOutput($"storage_name", typeof(string)) { Value = _storage.Name });

        Emitted = _storage;
        return _storage;
    }

    protected internal override void EmitConnections(ConnectionCollection connections, string cmId)
    {
        connections.Add(new ClientConnection("Azure.Storage.Blobs.BlobContainerClient@default", $"https://{cmId}.blob.core.windows.net/default"));
    }
}
