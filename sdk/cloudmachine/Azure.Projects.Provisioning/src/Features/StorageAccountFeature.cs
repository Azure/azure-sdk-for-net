// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Projects.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;

namespace Azure.Projects;

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
        var storageAccount = new StorageAccount("storageAccount", StorageAccount.ResourceVersions.V2023_01_01)
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

    public override string ToString() => $"{this.GetType().Name} {this.Id} {Name}";
}

public class BlobServiceFeature : AzureProjectFeature
{
    public BlobServiceFeature()
    {}

    public StorageAccountFeature? Account { get; set; }

    protected internal override void EmitFeatures(ProjectInfrastructure infrastructure)
    {
        FeatureCollection features = infrastructure.Features;
        if (!features.TryGet(out StorageAccountFeature? storageAccount))
        {
            storageAccount = new(infrastructure.ProjectId);
            features.Append(storageAccount);
        }
        Account = storageAccount;
        features.Append(this);
    }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        if (Account == null)
        {
            throw new InvalidOperationException("Account is not set.");
        }
        StorageAccount storageAccount = infrastructure.GetConstruct<StorageAccount>(Account.Id);

        BlobService blobService = new("storageBlobService", BlobService.ResourceVersions.V2024_01_01)
        {
            Parent = storageAccount
        };
        infrastructure.AddConstruct(Id, blobService);
    }

    public override string ToString() => $"{this.GetType().Name} {this.Id}";
}

public class BlobContainerFeature : AzureProjectFeature
{
    private readonly bool _isObservable;
    public string ContainerName { get; }
    public BlobServiceFeature? Service { get; set; }

    public BlobContainerFeature(string containerName, bool isObservable = true)
        : base($"{typeof(BlobContainerFeature).FullName}_{containerName}")
    {
        ContainerName = containerName;
        _isObservable = isObservable;
    }

    protected internal override void EmitFeatures(ProjectInfrastructure infrastructure)
    {
        FeatureCollection features = infrastructure.Features;
        string projectId = infrastructure.ProjectId;
        if (!features.TryGet(out StorageAccountFeature? storageAccount))
        {
            storageAccount = new(projectId);
            features.Append(storageAccount);
        }

        if (!features.TryGet(out BlobServiceFeature? blobBervice))
        {
            blobBervice = new BlobServiceFeature() { Account = storageAccount };
            features.Append(blobBervice);
        }

        Service = blobBervice;

        features.Append(this);

        if (_isObservable)
        {
            string namespaceName = infrastructure.ProjectId;
            string topicName = "cm_servicebus_topic_private";
            string subscriptionName = "cm_servicebus_subscription_private";

            var sb = infrastructure.AddFeature(new ServiceBusNamespaceFeature(namespaceName));
            var sbTopicPrivate = infrastructure.AddFeature(new ServiceBusTopicFeature(namespaceName, topicName));
            var systemTopic = infrastructure.AddFeature(new EventGridSystemTopicFeature(namespaceName, storageAccount!, "Microsoft.Storage.StorageAccounts"));
            infrastructure.AddFeature(new SystemTopicEventSubscriptionFeature("cm-eventgrid-subscription-blob", systemTopic, sbTopicPrivate, sb));
            // TODO: should private connections not be in the Connections collection?
            infrastructure.AddFeature(new ServiceBusSubscriptionFeature(namespaceName, topicName, subscriptionName));
        }
    }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        if (Service == null || Service.Account == null)
        {
            throw new InvalidOperationException("Service or Account is not set.");
        }

        BlobService blobService = infrastructure.GetConstruct<BlobService>(Service.Id);
        BlobContainer blobContainer = new($"storageBlobContainer_{ContainerName}", BlobContainer.ResourceVersions.V2023_01_01)
        {
            Parent = blobService,
            Name = ContainerName
        };
        infrastructure.AddConstruct(Id, blobContainer);

        EmitConnection(infrastructure,
            $"Azure.Storage.Blobs.BlobContainerClient@{ContainerName}",
            $"https://{Service.Account.Name}.blob.core.windows.net/{ContainerName}"
        );
    }

    public override string ToString() => $"{this.GetType().Name} {this.Id} {ContainerName}";
}
