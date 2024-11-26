﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Authorization;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.EventGrid;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.ServiceBus;

namespace Azure.CloudMachine;

public class SystemTopicEventSubscriptionFeature(string name, EventGridSystemTopicFeature parent, ServiceBusTopicFeature destination, ServiceBusNamespaceFeature parentNamespace) : CloudMachineFeature
{
    protected override ProvisionableResource EmitCore(CloudMachineInfrastructure infrastructure)
    {
        var serviceBusNamespace = ValidateIsOfType<ServiceBusNamespace>(parentNamespace);

        var role = ServiceBusBuiltInRole.AzureServiceBusDataSender;
        var roleAssignment = new RoleAssignment($"cm_servicebus_{ValidateIsOfType<SystemTopic>(parent).Name.Value}_role")
        {
            Name = BicepFunction.CreateGuid(serviceBusNamespace.Id, infrastructure.Identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString())),
            Scope = new IdentifierExpression(serviceBusNamespace.BicepIdentifier),
            PrincipalType = RoleManagementPrincipalType.ServicePrincipal,
            RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString()),
            PrincipalId = infrastructure.Identity.PrincipalId,
        };

        var systemTopic = ValidateIsOfType<SystemTopic>(parent);
        var subscription = new SystemTopicEventSubscription("cm_eventgrid_subscription_blob", "2022-06-15")
        {
            Name = name,
            Parent = systemTopic,
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
        subscription.DependsOn.Add(roleAssignment);

        infrastructure.AddResource(subscription);
        infrastructure.AddResource(roleAssignment);

        Emitted = subscription;
        return subscription;
    }
}
