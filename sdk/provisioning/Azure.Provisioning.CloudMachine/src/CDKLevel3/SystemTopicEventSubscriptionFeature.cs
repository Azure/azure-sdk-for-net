// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.EventGrid;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.ServiceBus;

namespace Azure.CloudMachine;

public class SystemTopicEventSubscriptionFeature(string name, EventGridSystemTopicFeature parent, ServiceBusTopicFeature destination) : CloudMachineFeature
{
    protected override ProvisionableResource EmitCore(CloudMachineInfrastructure infrastructure)
    {
        var subscription = new SystemTopicEventSubscription("cm_eventgrid_subscription_blob", "2022-06-15")
        {
            Name = name,
            Parent = ValidateIsOfType<SystemTopic>(parent),
            DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity
            {
                Identity = new EventSubscriptionIdentity
                {
                    IdentityType = EventSubscriptionIdentityType.UserAssigned,
                    UserAssignedIdentity = infrastructure.Identity.Id
                },
                Destination = new ServiceBusTopicEventSubscriptionDestination
                {
                    ResourceId = ValidateIsOfType<ServiceBusTopic>(destination).Id
                }
            },
            Filter = new EventSubscriptionFilter
            {
                IncludedEventTypes =
                [
                    "Microsoft.Storage.BlobCreated",
                    "Microsoft.Storage.BlobDeleted",
                    "Microsoft.Storage.BlobRenamed"
                ],
                IsAdvancedFilteringOnArraysEnabled = true
            },
            EventDeliverySchema = EventDeliverySchema.EventGridSchema,
            RetryPolicy = new EventSubscriptionRetryPolicy
            {
                MaxDeliveryAttempts = 30,
                EventTimeToLiveInMinutes = 1440
            }
        };

        infrastructure.AddResource(subscription);
        Emitted = subscription;
        return subscription;
    }
}
