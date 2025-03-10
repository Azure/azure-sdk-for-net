// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Projects.ServiceBus;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.EventGrid;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.ServiceBus;

namespace Azure.Projects.EventGrid;

internal class SystemTopicEventSubscriptionFeature(string name, EventGridSystemTopicFeature parent, ServiceBusTopicFeature destination, ServiceBusNamespaceFeature parentNamespace) : AzureProjectFeature
{
    protected override ProvisionableResource EmitResources(ProjectInfrastructure infrastructure)
    {
        ServiceBusNamespace serviceBusNamespace = EnsureEmits<ServiceBusNamespace>(parentNamespace);

        ServiceBusBuiltInRole role = ServiceBusBuiltInRole.AzureServiceBusDataSender;
        var roleAssignment = new RoleAssignment($"cm_servicebus_{EnsureEmits<SystemTopic>(parent).Name.Value}_role")
        {
            Name = BicepFunction.CreateGuid(serviceBusNamespace.Id, infrastructure.Identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString())),
            Scope = new IdentifierExpression(serviceBusNamespace.BicepIdentifier),
            PrincipalType = RoleManagementPrincipalType.ServicePrincipal,
            RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString()),
            PrincipalId = infrastructure.Identity.PrincipalId,
        };

        SystemTopic systemTopic = EnsureEmits<SystemTopic>(parent);
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
                    ResourceId = EnsureEmits<ServiceBusTopic>(destination).Id
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

        infrastructure.AddConstruct(subscription);
        infrastructure.AddConstruct(roleAssignment);
        return subscription;
    }
}
