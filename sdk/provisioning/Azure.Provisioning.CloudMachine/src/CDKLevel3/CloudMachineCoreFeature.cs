// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.EventGrid;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Azure.Provisioning.ServiceBus;
using Azure.Provisioning.Storage;

namespace Azure.CloudMachine;

internal class CloudMachineCoreFeature : CloudMachineFeature
{
    public CloudMachineCoreFeature()
    { }
    protected override ProvisionableResource EmitCore(CloudMachineInfrastructure infrastructure)
    {
        ManagedServiceIdentity managedServiceIdentity = new()
        {
            ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
            UserAssignedIdentities = { { BicepFunction.Interpolate($"{infrastructure.Identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
        };

        var _storage =
            new StorageAccount("cm_storage", StorageAccount.ResourceVersions.V2023_01_01)
            {
                Kind = StorageKind.StorageV2,
                Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
                IsHnsEnabled = true,
                AllowBlobPublicAccess = false
            };
        _storage.Identity = managedServiceIdentity;
        _storage.Name = infrastructure.Id;

        var _blobs = new BlobService("cm_storage_blobs")
        {
            Parent = _storage,
        };
        var _container = new BlobContainer("cm_storage_blobs_container", "2023-01-01")
        {
            Parent = _blobs,
            Name = "default"
        };

        var _serviceBusNamespace = new ServiceBusNamespace("cm_servicebus")
        {
            Sku = new ServiceBusSku
            {
                Name = ServiceBusSkuName.Standard,
                Tier = ServiceBusSkuTier.Standard
            },
            Name = infrastructure.Id,
        };
        var _serviceBusNamespaceAuthorizationRule = new ServiceBusNamespaceAuthorizationRule("cm_servicebus_auth_rule", "2021-11-01")
        {
            Parent = _serviceBusNamespace,
            Rights = [ServiceBusAccessRight.Listen, ServiceBusAccessRight.Send, ServiceBusAccessRight.Manage]
        };
        var _serviceBusTopic_private = new ServiceBusTopic("cm_servicebus_topic_private", "2021-11-01")
        {
            Name = "cm_servicebus_topic_private",
            Parent = _serviceBusNamespace,
            MaxMessageSizeInKilobytes = 256,
            DefaultMessageTimeToLive = TimeSpan.FromDays(14),
            RequiresDuplicateDetection = false,
            EnableBatchedOperations = true,
            SupportOrdering = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        var _serviceBusSubscription_private = new ServiceBusSubscription(CloudMachineInfrastructure.SB_PRIVATE_SUB, "2021-11-01")
        {
            Name = CloudMachineInfrastructure.SB_PRIVATE_SUB,
            Parent = _serviceBusTopic_private,
            IsClientAffine = false,
            LockDuration = TimeSpan.FromSeconds(30),
            RequiresSession = false,
            DefaultMessageTimeToLive = TimeSpan.FromDays(14),
            DeadLetteringOnFilterEvaluationExceptions = true,
            DeadLetteringOnMessageExpiration = true,
            MaxDeliveryCount = 10,
            EnableBatchedOperations = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        var _serviceBusTopic_default = new ServiceBusTopic("cm_servicebus_topic_default", "2021-11-01")
        {
            Name = "cm_servicebus_default_topic",
            Parent = _serviceBusNamespace,
            MaxMessageSizeInKilobytes = 256,
            DefaultMessageTimeToLive = TimeSpan.FromDays(14),
            RequiresDuplicateDetection = false,
            EnableBatchedOperations = true,
            SupportOrdering = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        var _serviceBusSubscription_default = new ServiceBusSubscription("cm_servicebus_subscription_default", "2021-11-01")
        {
            Name = "cm_servicebus_subscription_default",
            Parent = _serviceBusTopic_default,
            IsClientAffine = false,
            LockDuration = TimeSpan.FromSeconds(30),
            RequiresSession = false,
            DefaultMessageTimeToLive = TimeSpan.FromDays(14),
            DeadLetteringOnFilterEvaluationExceptions = true,
            DeadLetteringOnMessageExpiration = true,
            MaxDeliveryCount = 10,
            EnableBatchedOperations = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        var _eventGridTopic_blobs = new SystemTopic("cm_eventgrid_topic_blob", "2022-06-15")
        {
            TopicType = "Microsoft.Storage.StorageAccounts",
            Source = _storage.Id,
            Identity = new()
            {
                ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
                UserAssignedIdentities = { { BicepFunction.Interpolate($"{infrastructure.Identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
            },
            Name = infrastructure.Id
        };
        var _eventGridSubscription_blobs = new SystemTopicEventSubscription("cm_eventgrid_subscription_blob", "2022-06-15")
        {
            Name = "cm-eventgrid-subscription-blob",
            Parent = _eventGridTopic_blobs,
            DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity
            {
                Identity = new EventSubscriptionIdentity
                {
                    IdentityType = EventSubscriptionIdentityType.UserAssigned,
                    UserAssignedIdentity = infrastructure.Identity.Id
                },
                Destination = new ServiceBusTopicEventSubscriptionDestination
                {
                    ResourceId = _serviceBusTopic_private.Id
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

        infrastructure.AddResource(infrastructure.PrincipalIdParameter);
        //Add(PrincipalTypeParameter);
        //Add(PrincipalNameParameter);

        infrastructure.AddResource(infrastructure.Identity);
        infrastructure.AddResource(_storage);
        infrastructure.AddResource(_storage.CreateRoleAssignment(StorageBuiltInRole.StorageBlobDataContributor, RoleManagementPrincipalType.User, infrastructure.PrincipalIdParameter));
        infrastructure.AddResource(_storage.CreateRoleAssignment(StorageBuiltInRole.StorageTableDataContributor, RoleManagementPrincipalType.User, infrastructure.PrincipalIdParameter));
        infrastructure.AddResource(_container);
        infrastructure.AddResource(_blobs);
        infrastructure.AddResource(_serviceBusNamespace);
        infrastructure.AddResource(_serviceBusNamespace.CreateRoleAssignment(ServiceBusBuiltInRole.AzureServiceBusDataOwner, RoleManagementPrincipalType.User, infrastructure.PrincipalIdParameter));
        infrastructure.AddResource(_serviceBusNamespaceAuthorizationRule);
        infrastructure.AddResource(_serviceBusTopic_private);
        infrastructure.AddResource(_serviceBusTopic_default);
        infrastructure.AddResource(_serviceBusSubscription_private);
        infrastructure.AddResource(_serviceBusSubscription_default);

        // This is necessary until SystemTopic adds an AssignRole method.
        var role = ServiceBusBuiltInRole.AzureServiceBusDataSender;
        RoleAssignment roleAssignment = new RoleAssignment("cm_servicebus_role");
        roleAssignment.Name = BicepFunction.CreateGuid(_serviceBusNamespace.Id, infrastructure.Identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString()));
        roleAssignment.Scope = new IdentifierExpression(_serviceBusNamespace.BicepIdentifier);
        roleAssignment.PrincipalType = RoleManagementPrincipalType.ServicePrincipal;
        roleAssignment.RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString());
        roleAssignment.PrincipalId = infrastructure.Identity.PrincipalId;
        infrastructure.AddResource(roleAssignment);
        // the role assignment must exist before the system topic event subscription is created.
        _eventGridSubscription_blobs.DependsOn.Add(roleAssignment);
        infrastructure.AddResource(_eventGridSubscription_blobs);

        infrastructure.AddResource(_eventGridTopic_blobs);

        // Placeholders for now.
        infrastructure.AddResource(new ProvisioningOutput($"storage_name", typeof(string)) { Value = _storage.Name });
        infrastructure.AddResource(new ProvisioningOutput($"servicebus_name", typeof(string)) { Value = _serviceBusNamespace.Name });

        return _storage;
    }
}
