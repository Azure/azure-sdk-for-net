// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.EventGrid;
using Azure.Projects.ServiceBus;
using Azure.Projects.Storage;

namespace Azure.Projects;

public static class FeatureExtensions
{
    public static BlobContainerFeature AddBlobContainer(this ProjectInfrastructure infrastructure, string? containerName = default, bool isObservable = false)
    {
        StorageAccountFeature account = infrastructure.AddStorageAccount();
        var blobs = infrastructure.AddFeature(new BlobServiceFeature() { Account = account });
        var defaultContainer = infrastructure.AddFeature(new BlobContainerFeature() { Service = blobs });

        if (isObservable)
        {
            var sb = infrastructure.AddServiceBusNamespace();
            var sbTopicPrivate = infrastructure.AddFeature(new ServiceBusTopicFeature("cm_servicebus_topic_private", sb));
            var systemTopic = infrastructure.AddFeature(new EventGridSystemTopicFeature(infrastructure.ProjectId, account, "Microsoft.Storage.StorageAccounts"));
            infrastructure.AddFeature(new SystemTopicEventSubscriptionFeature("cm-eventgrid-subscription-blob", systemTopic, sbTopicPrivate, sb));
            infrastructure.AddFeature(new ServiceBusSubscriptionFeature("cm_servicebus_subscription_private", sbTopicPrivate)); // TODO: should private connections not be in the Connections collection?
        }

        return defaultContainer;
    }

    public static ServiceBusNamespaceFeature AddServiceBus(this ProjectInfrastructure infrastructure)
    {
        var sb = infrastructure.AddServiceBusNamespace();
        // Add core features
        var sbTopicDefault = infrastructure.AddFeature(new ServiceBusTopicFeature("cm_servicebus_default_topic", sb));
        infrastructure.AddFeature(new ServiceBusSubscriptionFeature("cm_servicebus_subscription_default", sbTopicDefault));
        return sb;
    }

    // TDOO: get rid of this.
    private static ServiceBusNamespaceFeature AddServiceBusNamespace(this ProjectInfrastructure infrastructure)
    {
        if (!infrastructure.Features.TryGet(out ServiceBusNamespaceFeature? serviceBusNamespace))
        {
            serviceBusNamespace = infrastructure.AddFeature(new ServiceBusNamespaceFeature(infrastructure.ProjectId));
        }
        return serviceBusNamespace!;
    }

    // TDOO: get rid of this.
    private static StorageAccountFeature AddStorageAccount(this ProjectInfrastructure infrastructure)
    {
        if (!infrastructure.Features.TryGet(out StorageAccountFeature? storageAccount))
        {
            storageAccount = infrastructure.AddFeature(new StorageAccountFeature(infrastructure.ProjectId));
        }
        return storageAccount!;
    }
}
