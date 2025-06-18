// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.EventGrid;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.ServiceBus;

namespace Azure.Projects;

internal class SystemTopicEventSubscriptionFeature : AzureProjectFeature
{
    private string _name;
    private EventGridSystemTopicFeature _parent;
    private ServiceBusTopicFeature _destination;
    private ServiceBusNamespaceFeature _parentNamespace;

    public SystemTopicEventSubscriptionFeature(string name, EventGridSystemTopicFeature parent, ServiceBusTopicFeature destination, ServiceBusNamespaceFeature parentNamespace)
    {
        _name = name;
        _parent = parent;
        _destination = destination;
        _parentNamespace = parentNamespace;
    }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        ServiceBusNamespace serviceBusNamespace = infrastructure.GetConstruct<ServiceBusNamespace>(_parentNamespace.Id);
        SystemTopic parentTopic = infrastructure.GetConstruct<SystemTopic>(_parent.Id);
        ServiceBusTopic destinationTopic = infrastructure.GetConstruct<ServiceBusTopic>(_destination.Id);

        ServiceBusBuiltInRole role = ServiceBusBuiltInRole.AzureServiceBusDataSender;
        var roleAssignment = new RoleAssignment($"cm_servicebus_{parentTopic.Name.Value}_role", RoleAssignment.ResourceVersions.V2022_04_01)
        {
            Name = BicepFunction.CreateGuid(serviceBusNamespace.Id, infrastructure.Identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString())),
            Scope = new IdentifierExpression(serviceBusNamespace.BicepIdentifier),
            PrincipalType = RoleManagementPrincipalType.ServicePrincipal,
            RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString()),
            PrincipalId = infrastructure.Identity.PrincipalId,
        };

        var subscription = new SystemTopicEventSubscription("cm_eventgrid_subscription_blob", SystemTopicEventSubscription.ResourceVersions.V2022_06_15)
        {
            Name = _name,
            Parent = parentTopic,
            DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity
            {
                Identity = new EventSubscriptionIdentity
                {
                    IdentityType = EventSubscriptionIdentityType.UserAssigned,
                    UserAssignedIdentity = infrastructure.Identity.Id
                },
                Destination = new ServiceBusTopicEventSubscriptionDestination
                {
                    ResourceId = destinationTopic.Id,
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

        infrastructure.AddConstruct(Id + "_subscription", subscription);
        infrastructure.AddConstruct(Id + "_role", roleAssignment);
    }
}
