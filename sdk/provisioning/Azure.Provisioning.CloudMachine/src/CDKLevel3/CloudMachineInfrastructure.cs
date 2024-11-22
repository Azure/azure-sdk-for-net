// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.EventGrid;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Roles;
using Azure.Provisioning.ServiceBus;
using Azure.Provisioning.Storage;
using Azure.Provisioning.Primitives;
using System.Collections.Generic;
using Azure.Provisioning;
using Azure.Provisioning.CloudMachine;
using Azure.Core;
using System.Runtime.CompilerServices;

namespace Azure.CloudMachine;

public class CloudMachineInfrastructure
{
    internal const string SB_PRIVATE_TOPIC = "cm_servicebus_topic_private";
    internal const string SB_PRIVATE_SUB = "cm_servicebus_subscription_private";
    private readonly string _cmid;

    private Infrastructure _infrastructure = new Infrastructure("cm");
    private List<Provisionable> _resources = new();
    public FeatureCollection Features { get; } = new();
    internal List<Type> Endpoints { get; } = new();

    // storage
    private StorageAccount _storage;
    private BlobService _blobs;
    private BlobContainer _container;

    // servicebus
    private ServiceBusNamespace _serviceBusNamespace;
    private ServiceBusNamespaceAuthorizationRule _serviceBusNamespaceAuthorizationRule;

    private ServiceBusTopic _serviceBusTopic_default;
    private ServiceBusSubscription _serviceBusSubscription_default;

    private ServiceBusTopic _serviceBusTopic_private;
    private ServiceBusSubscription _serviceBusSubscription_private;

    // eventgrid
    private SystemTopic _eventGridTopic_blobs;
    private SystemTopicEventSubscription _eventGridSubscription_blobs;

    public UserAssignedIdentity Identity { get; private set; }
    public string Id => _cmid;

    /// <summary>
    /// The common principalId parameter.
    /// </summary>
    public ProvisioningParameter PrincipalIdParameter => new ProvisioningParameter("principalId", typeof(string));

    ///// <summary>
    ///// The common principalType parameter.
    ///// </summary>
    //public ProvisioningParameter PrincipalTypeParameter => new BicepParameter("principalType", typeof(string));

    ///// <summary>
    ///// The common principalName parameter.
    ///// </summary>
    //public ProvisioningParameter PrincipalNameParameter => new BicepParameter("principalName", typeof(string));

    public CloudMachineInfrastructure(string cmId)
    {
        _cmid = cmId;

        // setup CM identity
        Identity = new UserAssignedIdentity("cm_identity");
        Identity.Name = _cmid;
        _infrastructure.Add(new ProvisioningOutput($"cm_managed_identity_id", typeof(string)) { Value = Identity.Id });
        ManagedServiceIdentity managedServiceIdentity = new()
        {
            ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
            UserAssignedIdentities = { { BicepFunction.Interpolate($"{Identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
        };

        _storage =
            new StorageAccount("cm_storage", StorageAccount.ResourceVersions.V2023_01_01)
            {
                Kind = StorageKind.StorageV2,
                Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
                IsHnsEnabled = true,
                AllowBlobPublicAccess = false
            };
        _storage.Identity = managedServiceIdentity;
        _storage.Name = _cmid;

        _blobs = new("cm_storage_blobs")
        {
            Parent = _storage,
        };
        _container = new BlobContainer("cm_storage_blobs_container", "2023-01-01")
        {
            Parent = _blobs,
            Name = "default"
        };

        _serviceBusNamespace = new("cm_servicebus")
        {
            Sku = new ServiceBusSku
            {
                Name = ServiceBusSkuName.Standard,
                Tier = ServiceBusSkuTier.Standard
            },
            Name = _cmid,
        };
        _serviceBusNamespaceAuthorizationRule = new("cm_servicebus_auth_rule", "2021-11-01")
        {
            Parent = _serviceBusNamespace,
            Rights = [ServiceBusAccessRight.Listen, ServiceBusAccessRight.Send, ServiceBusAccessRight.Manage]
        };
        _serviceBusTopic_private = new("cm_servicebus_topic_private", "2021-11-01")
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
        _serviceBusSubscription_private = new(SB_PRIVATE_SUB, "2021-11-01")
        {
            Name = SB_PRIVATE_SUB,
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
        _serviceBusTopic_default = new("cm_servicebus_topic_default", "2021-11-01")
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
        _serviceBusSubscription_default = new("cm_servicebus_subscription_default", "2021-11-01")
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
        _eventGridTopic_blobs = new("cm_eventgrid_topic_blob", "2022-06-15")
        {
            TopicType = "Microsoft.Storage.StorageAccounts",
            Source = _storage.Id,
            Identity = new()
            {
                ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
                UserAssignedIdentities = { { BicepFunction.Interpolate($"{Identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
            },
            Name = _cmid
        };
        _eventGridSubscription_blobs = new("cm_eventgrid_subscription_blob", "2022-06-15")
        {
            Name = "cm-eventgrid-subscription-blob",
            Parent = _eventGridTopic_blobs,
            DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity
            {
                Identity = new EventSubscriptionIdentity
                {
                    IdentityType = EventSubscriptionIdentityType.UserAssigned,
                    UserAssignedIdentity = Identity.Id
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
    }

    public void AddResource(NamedProvisionableConstruct resource)
    {
        _resources.Add(resource);
    }
    public void AddFeature(CloudMachineFeature feature)
    {
        feature.AddTo(this);
    }

    public void AddEndpoints<T>()
    {
        Type endpointsType = typeof(T);
        if (!endpointsType.IsInterface)
            throw new InvalidOperationException("Endpoints type must be an interface.");
        Endpoints.Add(endpointsType);
    }

    public ProvisioningPlan Build(ProvisioningBuildOptions? context = null)
    {
        Features.Emit(this);

        // Always add a default location parameter.
        // azd assumes there will be a location parameter for every module.
        // The Infrastructure location resolver will resolve unset Location properties to this parameter.
        _infrastructure.Add(new ProvisioningParameter("location", typeof(string))
        {
            Description = "The location for the resource(s) to be deployed.",
            Value = BicepFunction.GetResourceGroup().Location
        });

        _infrastructure.Add(PrincipalIdParameter);
        //Add(PrincipalTypeParameter);
        //Add(PrincipalNameParameter);

        var storageBlobDataContributor = StorageBuiltInRole.StorageBlobDataContributor;
        var storageTableDataContributor = StorageBuiltInRole.StorageTableDataContributor;
        var azureServiceBusDataSender = ServiceBusBuiltInRole.AzureServiceBusDataSender;
        var azureServiceBusDataOwner = ServiceBusBuiltInRole.AzureServiceBusDataOwner;

        _infrastructure.Add(Identity);
        _infrastructure.Add(_storage);
        _infrastructure.Add(_storage.CreateRoleAssignment(storageBlobDataContributor, RoleManagementPrincipalType.User, PrincipalIdParameter));
        _infrastructure.Add(CreateRoleAssignment(_storage, _storage.Id, storageBlobDataContributor, Identity));
        _infrastructure.Add(_storage.CreateRoleAssignment(storageTableDataContributor, RoleManagementPrincipalType.User, PrincipalIdParameter));
        _infrastructure.Add(CreateRoleAssignment(_storage, _storage.Id, storageTableDataContributor, Identity));
        _infrastructure.Add(_container);
        _infrastructure.Add(_blobs);
        _infrastructure.Add(_serviceBusNamespace);
        _infrastructure.Add(_serviceBusNamespace.CreateRoleAssignment(azureServiceBusDataOwner, RoleManagementPrincipalType.User, PrincipalIdParameter));
        _infrastructure.Add(CreateRoleAssignment(_serviceBusNamespace,_serviceBusNamespace.Id, azureServiceBusDataOwner, Identity));
        _infrastructure.Add(_serviceBusNamespaceAuthorizationRule);
        _infrastructure.Add(_serviceBusTopic_private);
        _infrastructure.Add(_serviceBusTopic_default);
        _infrastructure.Add(_serviceBusSubscription_private);
        _infrastructure.Add(_serviceBusSubscription_default);

        RoleAssignment roleAssignment = CreateRoleAssignment(_serviceBusNamespace, _serviceBusNamespace.Id, azureServiceBusDataSender, Identity);
        _infrastructure.Add(roleAssignment);

        CreateRoleAssignment(_serviceBusNamespace, _serviceBusNamespace.Id, azureServiceBusDataSender, Identity);
        // the role assignment must exist before the system topic event subscription is created.
        _eventGridSubscription_blobs.DependsOn.Add(roleAssignment);
        _infrastructure.Add(_eventGridSubscription_blobs);
        _infrastructure.Add(_eventGridTopic_blobs);

        // Placeholders for now.
        _infrastructure.Add(new ProvisioningOutput($"storage_name", typeof(string)) { Value = _storage.Name });
        _infrastructure.Add(new ProvisioningOutput($"servicebus_name", typeof(string)) { Value = _serviceBusNamespace.Name });

        // Add any add-on resources to the infrastructure.
        foreach (Provisionable resource in _resources)
        {
            _infrastructure.Add(resource);
        }

        return _infrastructure.Build(context);
    }

    // Temporary until the bug is fixed in the CDK generator which uses the PrincipalId instead of the Id in BicepFunction.CreateGuid.
    internal RoleAssignment CreateRoleAssignment(ProvisionableResource resource, BicepValue<ResourceIdentifier> Id, object role, UserAssignedIdentity identity)
    {
        if (role is null) throw new ArgumentException("Role must not be null.", nameof(role));
        var method = role.GetType().GetMethod("GetBuiltInRoleName", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        string roleName = (string)method!.Invoke(null, [role])!;

        return new($"{resource.BicepIdentifier}_{identity.BicepIdentifier}_{roleName}")
        {
            Name = BicepFunction.CreateGuid(Id, identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role!.ToString()!)),
            Scope = new IdentifierExpression(resource.BicepIdentifier),
            PrincipalType = RoleManagementPrincipalType.ServicePrincipal,
            RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString()!),
            PrincipalId = identity.PrincipalId
        };
    }
}
