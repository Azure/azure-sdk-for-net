// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.EventGrid;
using Azure.Projects.ServiceBus;
using Azure.Projects.Storage;

namespace Azure.Projects;

public static class OfxExtensions
{
    public static void AddOfx(this ProjectInfrastructure infra)
    {
        infra.AddBlobsContainer();
        infra.AddServiceBus();
    }

    public static void AddBlobsContainer(this ProjectInfrastructure infra, string? containerName = default, bool enableEvents = true)
    {
        StorageAccountFeature account = infra.AddStorageAccount();
        var blobs = infra.AddFeature(new BlobServiceFeature() { Account = account });
        var defaultContainer = infra.AddFeature(new BlobContainerFeature() { Service = blobs });

        if (enableEvents)
        {
            var sb = infra.AddServiceBusNamespace();
            var sbTopicPrivate = infra.AddFeature(new ServiceBusTopicFeature("cm_servicebus_topic_private", sb));
            var systemTopic = infra.AddFeature(new EventGridSystemTopicFeature(infra.ProjectId, account, "Microsoft.Storage.StorageAccounts"));
            infra.AddFeature(new SystemTopicEventSubscriptionFeature("cm-eventgrid-subscription-blob", systemTopic, sbTopicPrivate, sb));
            infra.AddFeature(new ServiceBusSubscriptionFeature("cm_servicebus_subscription_private", sbTopicPrivate)); // TODO: should private connections not be in the Connections collection?
        }
    }

    private static ServiceBusNamespaceFeature AddServiceBusNamespace(this ProjectInfrastructure infra)
    {
        if (!infra.Features.TryGet(out ServiceBusNamespaceFeature? serviceBusNamespace))
        {
            serviceBusNamespace = infra.AddFeature(new ServiceBusNamespaceFeature(infra.ProjectId));
        }
        return serviceBusNamespace!;
    }

    private static StorageAccountFeature AddStorageAccount(this ProjectInfrastructure infra)
    {
        if (!infra.Features.TryGet(out StorageAccountFeature? storageAccount))
        {
            storageAccount = infra.AddFeature(new StorageAccountFeature(infra.ProjectId));
        }
        return storageAccount!;
    }

    private static void AddServiceBus(this ProjectInfrastructure infra)
    {
        var sb = infra.AddServiceBusNamespace();
        // Add core features
        var sbTopicDefault = infra.AddFeature(new ServiceBusTopicFeature("cm_servicebus_default_topic", sb));
        infra.AddFeature(new ServiceBusSubscriptionFeature("cm_servicebus_subscription_default", sbTopicDefault));
    }
}
